using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using NewsLibrary;
using System.Data;

namespace AdminClientApp
{
    public partial class ViewAgencies : System.Web.UI.Page
    {
        INewsManager mgr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpChannel chnl = new HttpChannel();
                try
                {
                    ChannelServices.RegisterChannel(chnl, false);
                    Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
                    DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
                    Console.WriteLine("Client.Main : Channel is created and registered");
                }
                catch (RemotingException ex)
                {
                    //all good, nobody cares, but we log it
                }

                mgr = (INewsManager)Activator.GetObject(typeof(INewsManager), "http://localhost:1234/NewsManager.soap");
                Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
                DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
                Console.WriteLine("Client.Main : Proxy is created");

                Agency[] Array_L = mgr.getAgencies();
                DataTable dt = new DataTable();
                dt.Columns.Add("AgencyID");
                dt.Columns.Add("City");
                dt.Columns.Add("Language");
                for (int i = 0; i < Array_L.Count(); i++)
                {
                    dt.Rows.Add();
                    dt.Rows[i]["AgencyID"] = Array_L[i].id.ToString();
                    dt.Rows[i]["City"] = Array_L[i].city.ToString();
                    dt.Rows[i]["Language"] = Array_L[i].language.ToString();
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void GridView1_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].CssClass = "hiddencol";
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].CssClass = "hiddencol";

            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            HttpChannel chnl = new HttpChannel();
            try
            {
                ChannelServices.RegisterChannel(chnl, false);
                Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
                DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
                Console.WriteLine("Client.Main : Channel is created and registered");
            }
            catch (RemotingException ex)
            {
                //all good, nobody cares, but we log it
            }

            mgr = (INewsManager)Activator.GetObject(typeof(INewsManager), "http://localhost:1234/NewsManager.soap");
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
           DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
            Console.WriteLine("Client.Main : Proxy is created");

            
            GridView1.PageIndex = e.NewPageIndex;
            Agency[] Array_L = mgr.getAgencies();
            DataTable dt = new DataTable();
            dt.Columns.Add("AgencyID");
            dt.Columns.Add("City");
            dt.Columns.Add("Language");
            for (int i = 0; i < Array_L.Count(); i++)
            {
                dt.Rows.Add();
                dt.Rows[i]["AgencyID"] = Array_L[i].id.ToString();
                dt.Rows[i]["City"] = Array_L[i].city.ToString();
                dt.Rows[i]["Language"] = Array_L[i].language.ToString();
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}