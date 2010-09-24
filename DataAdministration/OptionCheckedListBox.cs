using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DomainModel.Entities;
using System.Collections;



namespace DataAdministration
{
    public class OptionCheckedListBox : CheckedListBox
    {
        private List<ProductOptionBase> selectedItems;

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
                    ProductOptionBase item = (ProductOptionBase)value[i];
                    this.selectedItems.Add(item);
                }
            }
        }

        public IEnumerable AllDataSource 
        {
            get
            {
                if (this.DataSource == null) return null;
                return (List<ProductOptionBase>)this.DataSource;
            }

            set
            {
                this.DataSource = value;
                this.DisplayMember = "Name";
                this.ValueMember = "Id";
            }
        }

        public ApplicationProduct Product { get; private set; }

        public delegate void Add(ProductOptionBase option, ApplicationProduct Product, string table);
        public delegate void Remove(ProductOptionBase option, ApplicationProduct Product, string table);


        public Add AddAction { get; set; }
        public Remove RemoveAction { get; set; }


        public OptionCheckedListBox(ApplicationProduct product)
        {
            this.selectedItems = new List<ProductOptionBase>();
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
                    ProductOptionBase item = (ProductOptionBase)this.Items[e.Index];
                    if (e.NewValue == CheckState.Checked)
                    {
                        AddToSelectedDataSource(item);
                        AddAction(item, this.Product, this.Name.Replace("chbx", ""));
                    }
                    else if (e.NewValue == CheckState.Unchecked)
                    {
                        RemoveFromSelectedDataSource(item);
                        RemoveAction(item, this.Product, this.Name.Replace("chbx", ""));
                    }
                }
            }
        }


        private void RemoveFromSelectedDataSource(ProductOptionBase option)
        {
            int itemIndex = 0;
            for (itemIndex = 0; itemIndex < this.selectedItems.Count; itemIndex++)
            {
                if (this.selectedItems[itemIndex].Id == option.Id)
                {
                    this.selectedItems.RemoveAt(itemIndex);
                }
            }
        }


        private void AddToSelectedDataSource(ProductOptionBase option)
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
                foreach (ProductOptionBase item in this.selectedItems)
                {
                    int index = FindById(item.Id);
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
                if (((ProductOptionBase)this.Items[i]).Id == ProductOptionId) return i;
            }

            return -1;
        }
    }
}
