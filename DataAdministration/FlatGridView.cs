using System;
using System.Windows.Forms;
using System.Drawing;

namespace PresentationUtil
{
    public class FlatGridView : DataGridView
    {
        DataGridViewCellStyle headerCellStyle;
        DataGridViewCellStyle defaultCellStyle;

        //ContextMenuStrip ctxMenu;

        protected bool bShowContextMenu;
        public bool ShowContextMenu
        {
            get { return bShowContextMenu; }
            set { this.bShowContextMenu = value; }
        }


        public FlatGridView()
            : base()
        {
            this.headerCellStyle = new DataGridViewCellStyle();

            this.headerCellStyle.ForeColor = Color.White;
            this.headerCellStyle.BackColor = Color.FromArgb(255, 80, 80, 85);
            this.headerCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.headerCellStyle.Font = new System.Drawing.Font("Tahoma", 10.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(178)));
            this.headerCellStyle.SelectionBackColor = System.Drawing.Color.Moccasin;
            this.headerCellStyle.SelectionForeColor = System.Drawing.Color.DarkGoldenrod;
            this.headerCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

            this.defaultCellStyle = new DataGridViewCellStyle();

            this.defaultCellStyle.ForeColor = Color.Black;
            this.defaultCellStyle.BackColor = Color.FromArgb(255, 250, 250, 245);
            this.defaultCellStyle.SelectionBackColor = Color.FromArgb(255, 245, 215, 155);  // Color.FromArgb(255, 245, 190, 85)
            this.defaultCellStyle.SelectionForeColor = Color.Black;
            this.defaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.defaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(178)));
            this.defaultCellStyle.WrapMode = DataGridViewTriState.False;


            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.ColumnHeadersDefaultCellStyle = this.headerCellStyle;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.RowHeadersVisible = false;

            this.DefaultCellStyle = this.defaultCellStyle;


            this.RightToLeft = RightToLeft.Yes;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeRows = false;
            this.AutoGenerateColumns = true;
            this.BorderStyle = BorderStyle.None;
            this.EditMode = DataGridViewEditMode.EditOnF2;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.EnableHeadersVisualStyles = false;
            this.MultiSelect = false;

            /*
            this.ctxMenu = new ContextMenuStrip();
            this.ctxMenu.Items.Add(Properties.Resources.MenuEdit);
            this.ctxMenu.Items.Add(Properties.Resources.MenuNew);
            this.ctxMenu.Items.Add(Properties.Resources.MenuDelete);
            this.ctxMenu.ItemClicked += new ToolStripItemClickedEventHandler(ctxMenu_ItemClicked);*/

            // this.ContextMenuStrip = this.ctxMenu;
            this.bShowContextMenu = true;

            this.Columns.CollectionChanged += new System.ComponentModel.CollectionChangeEventHandler(Columns_CollectionChanged);
            this.CellMouseClick += new DataGridViewCellMouseEventHandler(FlatGridView_CellMouseClick);
            //this.BindingContext[].Current
        }



        void FlatGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                this.Rows[e.RowIndex].Selected = true;

                Rectangle r = this.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //if (this.bShowContextMenu) this.ctxMenu.Show((Control)sender, r.Left + e.X, r.Top + e.Y);
            }
        }



        void Columns_CollectionChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e)
        {
            if (this.Columns.Count > 0) AdjustColumns();
        }



        private void AdjustColumns()
        {
            foreach (DataGridViewColumn column in this.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            //this.Columns[this.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        /*
        void ctxMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == Properties.Resources.MenuDelete)
            {
                BeginInvoke(new RaiseMenuItemSelectedDelegate(RaiseMenuItemSelected), new object[] { MenuActions.Delete });
                //RaiseMenuItemSelected();
            }
            else if (e.ClickedItem.Text == Properties.Resources.MenuEdit)
            {
                BeginInvoke(new RaiseMenuItemSelectedDelegate(RaiseMenuItemSelected), new object[] { MenuActions.Edit });
                //RaiseMenuItemSelected(MenuActions.Edit);
            }
            else if (e.ClickedItem.Text == Properties.Resources.MenuNew)
            {
                BeginInvoke(new RaiseMenuItemSelectedDelegate(RaiseMenuItemSelected), new object[] { MenuActions.New });
                //RaiseMenuItemSelected(MenuActions.New);
            }
        }*/



        public object SelectedItem
        {
            get
            {
                if (this.DataSource != null && this.BindingContext != null && this.BindingContext[this.DataSource] != null)
                {
                    if (this.BindingContext[this.DataSource].Count <= 0 || this.BindingContext[this.DataSource].Position < 0) return null;

                    return this.BindingContext[this.DataSource].Current;
                }

                return null;
            }
        }



        #region events


        public enum MenuActions
        {
            Delete,
            Edit,
            New
        }

        public delegate void MenuItemSelectedEvent(object sender, MenuItemEventArgs e);
        public event MenuItemSelectedEvent MenuItemSelected;

        protected delegate void RaiseMenuItemSelectedDelegate(MenuActions menuAction);
        protected void RaiseMenuItemSelected(MenuActions menuAction)
        {
            if (this.MenuItemSelected != null)
            {
                MenuItemSelected(this, new MenuItemEventArgs(menuAction));
            }
        }

        public class MenuItemEventArgs : EventArgs
        {
            protected MenuActions menuAction;
            public MenuActions MenuAction
            {
                get { return this.menuAction; }
            }

            public MenuItemEventArgs(MenuActions menuAction)
            {
                this.menuAction = menuAction;
            }
        }

        #endregion



        // UNDONE : SAVE COLUMN SIZEZ
    }
}
