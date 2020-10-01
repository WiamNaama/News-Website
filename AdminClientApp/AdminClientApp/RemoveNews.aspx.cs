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

namespace AdminClientApp
{
    public partial class RemoveNews : System.Web.UI.Page
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



                GridView1.DataSource = mgr.getAllNews();
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
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

            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            mgr.removeNews(id);
            GridView1.DataSource = mgr.getAllNews();
            GridView1.DataBind();
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

            GridView1.DataSource = mgr.getAllNews();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
        
    }
}