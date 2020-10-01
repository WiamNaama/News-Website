using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using NewsLibrary;

namespace AdminClientApp
{
    public partial class _Default : Page
    {
        INewsManager mgr;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                HttpChannel chnl = new HttpChannel();
                try
                {
                    ChannelServices.RegisterChannel(chnl, false);
                }
                catch (RemotingException ex)
                {
                    //all good, nobody cares, but we log it
                }
 
                mgr = (INewsManager)Activator.GetObject(typeof(INewsManager), "http://localhost:1234/NewsManager.soap");
              
                LV1.DataSource = mgr.getLastTenNews();
                LV1.DataBind();
            }
        }

        protected void LV1_OnItemDataBound(object sender,ListViewItemEventArgs e)
        {
            HttpChannel chnl = new HttpChannel();
            try
            {
                ChannelServices.RegisterChannel(chnl, false);
            }
            catch (RemotingException ex)
            {
                //all good, nobody cares, but we log it
            }

            mgr = (INewsManager)Activator.GetObject(typeof(INewsManager), "http://localhost:1234/NewsManager.soap");

            HiddenField hiddenID = (HiddenField)e.Item.FindControl("IDHid");

            System.Web.UI.WebControls.Image imageControl = (System.Web.UI.WebControls.Image)e.Item.FindControl("newsPhoto");
          
            string ID = hiddenID.Value;
            int newsID = Convert.ToInt32(ID);
            byte[] imageArr = mgr.getNewsImage(newsID);
            imageControl.ImageUrl = "data:image;base64," + Convert.ToBase64String(imageArr);
        }
    }
}