using System;
using System.Windows.Forms;
using DomainModel.Entities;
using System.Collections;



namespace DataAdministration
{
    public class ProductCategoriesCheckedListBox : CheckedListBox
    {
        private CategoryCollection selectedItems;

        public IList SelectedDataSource 
        {
            get
            {
                return this.selectedItems;
            }

            set
            {
                if (value == null) return;

                for (int i = 0; i < value.Count; i++)
                {
                    Category item = value[i] as Category;
                    this.selectedItems.Add(item);
                }
            }
        }

        public IEnumerable AllDataSource 
        {
            get
            {
                if (this.DataSource == null) return null;
                return this.DataSource as IEnumerable;
            }

            set
            {
                this.DataSource = value;
                this.DisplayMember = "CategoryName";
                this.ValueMember = "CategoryId";
            }
        }

        public ApplicationProduct Product { get; private set; }

        public delegate void Add(Category category, ApplicationProduct Product);
        public delegate void Remove(Category category, ApplicationProduct Product);


        public Add AddAction { get; set; }
        public Remove RemoveAction { get; set; }


        public ProductCategoriesCheckedListBox(ApplicationProduct product)
        {
            this.selectedItems = new CategoryCollection();
            this.Product = product;
            this.FormattingEnabled = true;
            this.Size = new System.Drawing.Size(180, 130);
        }


        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (this.Visible)
            {
                MarkSelectedItems();
            }
        }


        void OptionCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.Product.ProductId <= 0)
            {
                throw new InvalidOperationException("Product Id must be > 0");
            }
            else
            {
                if (this.Items[e.Index] != null)
                {
                    Category item = this.Items[e.Index] as Category;
                    if (e.NewValue == CheckState.Checked)
                    {
                        AddToSelectedDataSource(item);
                        AddAction(item, this.Product);
                    }
                    else if (e.NewValue == CheckState.Unchecked)
                    {
                        RemoveFromSelectedDataSource(item);
                        RemoveAction(item, this.Product);
                    }
                }
            }
        }


        private void RemoveFromSelectedDataSource(Category option)
        {
            int itemIndex = 0;
            for (itemIndex = 0; itemIndex < this.selectedItems.Count; itemIndex++)
            {
                if (this.selectedItems[itemIndex].CategoryId == option.CategoryId)
                {
                    this.selectedItems.RemoveAt(itemIndex);
                }
            }
        }


        private void AddToSelectedDataSource(Category option)
        {
            this.selectedItems.Add(option);
        }


        private void MarkSelectedItems()
        {
            this.ItemCheck -= new ItemCheckEventHandler(OptionCheckedListBox_ItemCheck);

            if (this.selectedItems.Count > 0)
            {
                // Clear all marks
                ClearSelected();

                // Mark datasource items
                foreach (Category item in this.selectedItems)
                {
                    int index = FindById(item.CategoryId);
                    if (index >= 0)
                    {
                        SetItemCheckState(index, CheckState.Checked);
                    }
                }
            }
            
            this.ItemCheck += new ItemCheckEventHandler(OptionCheckedListBox_ItemCheck);
        }


        private int FindById(int ProductOptionId)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (((Category)this.Items[i]).CategoryId == ProductOptionId) return i;
            }

            return -1;
        }
    }
}
