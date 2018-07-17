using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace TelerikWebSiteDemo
{
    public partial class TierLevel : System.Web.UI.Page
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
            for (var i =1 ; i <= 10; i++)
            {
                data.Columns.Add("HonarariumText " + i, typeof(int));
            }
            for (var i = 1; i <= 500; i++)
            {
                data.Rows.Add(i,"TierLevel " + i);
            }
            return data;
        }

        public List<string> GetCities()
        {
            return new List<string>()
        {
            "Seattle",
            "Tacoma",
            "Kirkland",
            "Redmond",
            "London",
            "Philadelphia",
            "New York",
            "Seattle",
            "London",
            "Boston"
        };
        }

        //protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        //{
        //    RadGrid2.DataSource = this.Sellers;
        //}


        
      

        protected void RadGrid2_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //RadComboBox comboBox = e.Item.FindControl("RCB_City") as RadComboBox;
            //if (comboBox != null)
            //{
            //    if (!(e.Item.DataItem is GridInsertionObject))
            //    {
            //        comboBox.SelectedValue = (e.Item.DataItem as DataRowView)["City"].ToString();
            //    }
            //    comboBox.DataTextField = string.Empty;
            //    comboBox.DataSource = this.GetCities();
            //    comboBox.DataBind();
            //    if (this.RadGrid1.ResolvedRenderMode == RenderMode.Mobile)
            //    {
            //        (e.Item.FindControl("TB_Age") as WebControl).Enabled = false;
            //    }
            //    else
            //    {
            //        ((e.Item as GridEditableItem)["Age"].Controls[0] as WebControl).Enabled = false;
            //    }
            //}
        }

      
    }
}
