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
using System.IO;
using System.Net;
using System.Data;

namespace AdminClientApp
{
    public partial class AddNews : System.Web.UI.Page
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
                Agencies.DataSource = dt;
                Agencies.DataBind();
            }
            else
            {
                mgr = (INewsManager)Activator.GetObject(typeof(INewsManager), "http://localhost:1234/NewsManager.soap");
                Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
               DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
                Console.WriteLine("Client.Main : Proxy is created");
            }
        }
        protected void addBtn_Click(object sender, EventArgs e)
        {
            News newsObj = new News();
            newsObj.newsAgencyId = Convert.ToInt32( Agencies.SelectedValue);
            newsObj.category = CategoryBox.Text;
            newsObj.title = tileBox.Text;
            newsObj.newsAbstract = AbstractBox.Text;
            newsObj.text = NewsText.Text;
            newsObj.date = DateTime.Now;
            newsObj.totalReads = 0;
            byte[] imgarray = null;
            if(!photo.HasFile)
            {
                string url = "images/noimg.jpg";
                imgarray = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath(url)); 
            }
           else
            {

                int imagefilelenth = photo.PostedFile.ContentLength;
                imgarray = new byte[imagefilelenth];
                BinaryReader br = new BinaryReader(photo.PostedFile.InputStream);
                imgarray = br.ReadBytes(photo.PostedFile.ContentLength); 
            }
            newsObj.photo = imgarray;
            try
            {
                mgr.addNews(newsObj);
                msgLbl.Text = "New is added sucssessfully";
                tileBox.Text ="";
                AbstractBox.Text="";
                NewsText.Text="";
                Agencies.SelectedIndex = 0;
                Agencies.SelectedValue = "";
                photo.Dispose();
            }
            catch
            {
                msgLbl.Text = "There is an error..";
            }
            
        }
    }
}