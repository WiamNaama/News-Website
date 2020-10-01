using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Drawing;
using AdminClientApp.NewsSVC;

namespace AdminClientApp
{
    /// <summary>
    /// Summary description for NewsImage
    /// </summary>
    public class NewsImage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            NewsServiceClient newsSvc = new NewsServiceClient();
            int id = int.Parse(context.Request.QueryString["ID"]);
            byte[] imageArr = newsSvc.GetNewsPhoto(id);

            context.Response.ContentType = "image/*";
            context.Response.OutputStream.Write(imageArr, 0, imageArr.Length);
            //byte[] buffer = new byte[4096];
           // int byteSeq;
           // if (strm != null)
              //  byteSeq = strm.Read(buffer, 0, 4096);
            //else
              //  byteSeq = 0;

            //while (byteSeq > 0)
           // {
            //    context.Response.OutputStream.Write(buffer, 0, byteSeq);
               // byteSeq = strm.Read(buffer, 0, 4096);
           // }  
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}