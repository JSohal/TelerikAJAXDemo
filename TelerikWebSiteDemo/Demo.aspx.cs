using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace TelerikWebSiteDemo
{
    public partial class Demo : System.Web.UI.Page
    {
        protected StringBuilder eventCalls = new StringBuilder();
        List<string> eventList = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            eventList.Add("Page_Load");
            NotifyEventCalls();
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
           
            eventList.Add("PopulateHonarariumTexts");
            NotifyEventCalls();
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
          
            eventList.Add("RadGrid2_NeedDataSource");
            NotifyEventCalls();
            RadGrid2.DataSource = this.Sellers;
        }

        protected void RadListBox1_ItemCheck(object sender, RadListBoxItemEventArgs e)
        {
           
            eventList.Add("RadListBox1_ItemCheck");
            NotifyEventCalls();
            RadGrid2.MasterTableView.RenderColumns.First(x=>x.UniqueName== e.Item.Text).Display = e.Item.Checked;
            //var CheckedItems = RadListBox1.CheckedItems.Select(x => x.Text).ToList();
            //List<GridColumn> cols = RadGrid2.MasterTableView.RenderColumns.Where(p => CheckedItems.Contains(p.UniqueName)).ToList();
            //foreach (GridColumn column in cols)
            //{
            //    if (column.UniqueName != "TierLevel")
            //    {
            //        column.Display = true;

            //    }
            //}           
        }

        protected void RadGrid2_PreRender(object sender, EventArgs e)
        {
            
            eventList.Add("RadGrid2_PreRender");
            NotifyEventCalls();
            var CheckedItems = RadListBox1.CheckedItems.Select(x => x.Text).ToList();
            List<GridColumn> cols = RadGrid2.MasterTableView.RenderColumns.Where(p => p.Display == true && !CheckedItems.Contains(p.UniqueName)).ToList();
            foreach (GridColumn column in cols)
            {
                if (column.UniqueName != "TierLevel")
                {
                    column.Display = false;
                   
                }
            }            
        }

     
        protected void RadDatePicker1_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            
            eventList.Add("RadDatePicker1_SelectedDateChanged");
            NotifyEventCalls();
            Label1.Text = e.NewDate?.ToLongDateString();
        }

        protected void NotifyEventCalls()
        {                   
            ListBox2.DataSource = eventList;
            ListBox2.DataBind();
        }

        
    }
}