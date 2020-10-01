using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdminClientApp.NewsSVC;

namespace AdminClientApp
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                string searchOption = searchBox.Text;
                NewsServiceClient newsSvc = new NewsServiceClient();
                AdminClientApp.NewsSVC.New[] newsArr = newsSvc.GetTenNews(searchOption);
               LV1.DataSource = newsArr;
               LV1.DataBind();


                int[] userIDs = new int[5] { 1, 2, 3, 4, 5 };
                Random random = new Random();
                int index = random.Next(0, userIDs.Length);
                int userID = userIDs[index];
                Session["userID"] = userID;

            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            NewsServiceClient newsSvc = new NewsServiceClient();
            string searchOption = searchBox.Text;
            var listOfStrings = new List<AdminClientApp.NewsSVC.New>();
            AdminClientApp.NewsSVC.New[] newsArr = listOfStrings.ToArray();
            if (rbtnTenNews.Checked == true)
            {
                newsArr = newsSvc.GetTenNews(searchOption);  
            }
            if (rtbnSimilar.Checked == true)
            {
                newsArr = newsSvc.GetSimilarNews(searchOption);
            }
            if (rtbnPositive.Checked == true)
            {
                newsArr = newsSvc.GetNBestPossitive(searchOption);
            }
            if (rtbnNegative.Checked == true)
            {
                newsArr = newsSvc.GetNBestNegative(searchOption);
            }
            LV1.DataSource = newsArr;
            LV1.DataBind();
        }
      
        protected void BtnRank_Click(object sender, CommandEventArgs e)
        {
            NewsServiceClient newsSvc = new NewsServiceClient();
            AdminClientApp.NewsSVC.Ranking ranking = new AdminClientApp.NewsSVC.Ranking();
            using (ListView row = (ListView)((ImageButton)sender).Parent.Parent.Parent.Parent.Parent)
            {
                int newsID = int.Parse( e.CommandArgument.ToString());
                ranking.NewsID = newsID;
                ranking.UserID = int.Parse( Session["userID"].ToString());
                if (e.CommandName.ToString() == "Positive")
                    ranking.Rank = 1;
                else
                    ranking.Rank = 0;
                newsSvc.AddToRanking(ranking);
            }
        }
       
    }
}