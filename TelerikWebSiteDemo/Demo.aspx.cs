using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace TelerikWebSiteDemo
{
    public partial class Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateHonarariumTexts();
            }
        }
        public DataTable Sellers
        {
            get
            {
                DataTable data = Session["Data"] as DataTable;

                if (data == null)
                {
                    data = GetSellers();
                    Session["Data"] = data;
                }

                return data;
            }
        }


        public void PopulateHonarariumTexts()
        {
            for (var i = 1; i <= 10; i++)
            {
                RadListBoxItem item = new RadListBoxItem("HonarariumText " + i, i.ToString());

                RadListBox1.Items.Add(item);
            }
        }

        public DataTable GetSellers()
        {
            DataTable data = new DataTable();
            data.Columns.Add("ID", typeof(int));
            data.Columns.Add("TierLevel", typeof(string));
            for (var i = 1; i <= 10; i++)
            {                
                data.Columns.Add("HonarariumText " + i, typeof(int));               
            }
            for (var i = 1; i <= 500; i++)
            {
                data.Rows.Add(i, "TierLevel " + i);
            }
            return data;
        }
        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid2.DataSource = this.Sellers;
        }

        protected void RadListBox1_ItemCheck(object sender, RadListBoxItemEventArgs e)
        {
            RadGrid2.MasterTableView.RenderColumns.First(x=>x.UniqueName== e.Item.Text).Display = e.Item.Checked;
            var CheckedItems = RadListBox1.CheckedItems.Select(x => x.Text).ToList();
            List<GridColumn> cols = RadGrid2.MasterTableView.RenderColumns.Where(p => CheckedItems.Contains(p.UniqueName)).ToList();
            foreach (GridColumn column in cols)
            {
                if (column.UniqueName != "TierLevel")
                {
                    column.Display = true;

                }
            }
        }

        protected void RadGrid2_PreRender(object sender, EventArgs e)
        {
            var CheckedItems = RadListBox1.CheckedItems.Select(x => x.Text).ToList();
            List<GridColumn> cols = RadGrid2.MasterTableView.RenderColumns.Where(p => !CheckedItems.Contains(p.UniqueName)).ToList();
            foreach (GridColumn column in cols)
            {
                if (column.UniqueName != "TierLevel")
                {
                    column.Display = false;
                   
                }
            }           
        }
    }
}