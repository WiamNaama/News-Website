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
    public partial class AddAgency : System.Web.UI.Page
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
            }
        }
        protected void addBtn_Click(object sender, EventArgs e)
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

            Agency agencyObj = new Agency();
            agencyObj.city = cityBox.Text;
            agencyObj.language = languageBox.Text;
            try
            {
                mgr.addAgency(agencyObj);
                msgLbl.Text = "Agency is added sucssessfully";
                cityBox.Text = "";
                languageBox.Text = "";
            }
            catch
            {
                msgLbl.Text = "There is an error..";
            }

        }
    }
}