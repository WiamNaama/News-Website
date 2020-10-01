using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Project
{

    public class NewsService : INewsService
    {
     
        public List<New> GetTenNews(string Userinput)

        {
            string[] words = new string[] { };

            words = Userinput.Split(' ');

            var ctx = new NewsDBDataContext();

            var result = (from part in ctx.News
                         orderby part.Date descending
                         select part).ToList();


            foreach (var term in words)
            {
                result = (from part in result
                          where part.Title.Contains(term) || part.Text.Contains(term) 
                          select part).Take(10).ToList();
            }

            return result;

        }
     



    

        public List <New> GetSimilarNews(string Userinput)
        {
            var ctx = new NewsDBDataContext();

            var news = (from similer in ctx.News
                        where similer.Category == Userinput

                        select similer
                       ).ToList();

            return news;

           
        }

        public List<New> GetNBestPossitive(string Userinput)
        {
            var ctx = new NewsDBDataContext();

            int n = int.Parse(Userinput);

            var BestNP = (from best in ctx.News
                          where best.Classification == "Postive"
                          orderby best.Probability descending
                          select best).Take(n).ToList();

            return BestNP;

        }

        public List<New> GetNBestNegative(string Userinput)
        {
            var ctx = new NewsDBDataContext();


            int n = int.Parse(Userinput);

            var BestNN = (from best in ctx.News
                          where best.Classification=="Negative"
                          orderby best.Probability ascending
                          select best).Take(n).ToList();

            return BestNN;
        }


        public void AddToRanking(Ranking UserRanking)
        {
            var ctx = new NewsDBDataContext();

            
            var newRank = (from oldR in ctx.Rankings
                        where oldR.UserID == UserRanking.UserID && oldR.NewsID == UserRanking.NewsID

                        select oldR
                    ).SingleOrDefault();

            if(newRank == null) {
                //Add the new Ranking and save it.
                ctx.Rankings.InsertOnSubmit(UserRanking);
                ctx.SubmitChanges();
            }
            else
            {
                newRank.Rank = UserRanking.Rank;
                ctx.SubmitChanges();
                
            }

            

            
            int NewsId = UserRanking.NewsID;

            //Calculate the number of like for the NewsID
            int sumofNews = (int)(from s in ctx.Rankings
                             where NewsId == s.NewsID
                             select s.Rank).Sum();

           


            //Count number of all Ranking for NewsID

            int countofNews = (from s in ctx.Rankings

                               where NewsId == s.NewsID 

                               select s
                              ).Count();


            //calculate the Probability for NewsID 
            float NewPro =( float )sumofNews / countofNews;

            NewPro = (float)System.Math.Round(NewPro, 2);




            //Search for NewsID in News table
            var news = (from n in ctx.News
                        where n.ID == NewsId

                        select n
                      ).SingleOrDefault();

           
            if(NewPro >= 0.5)
            {
                news.Classification = "Postive";
                news.Probability = NewPro;
                ctx.SubmitChanges();
            }
            else
            {
                news.Classification = "Negative";
                news.Probability = NewPro;
                ctx.SubmitChanges();

            }

        }
        public byte[] GetNewsPhoto(int NewsID)
        {
            var ctx = new NewsDBDataContext();

            var photo = (from similer in ctx.News
                        where similer.ID == NewsID

                        select similer.photo
                       ).Single();

            return photo.ToArray();
        }






    }
}
