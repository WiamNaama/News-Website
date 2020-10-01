using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace NewsLibrary
{
    public interface INewsManager
    {
       void addNews(News newsObj);
        void removeNews(int newsID);
        void updateNewsPhoto(News newsObj);
        DataTable getLastTenNews();
        DataTable getAllNews();
        DataTable getNews(int ID);
        byte[] getNewsImage(int ID);
        Agency[] getAgencies();
        DataTable getAgencyNews(int newsAgencyId);
        void addAgency(Agency agencyObj);
        void updateAgency(Agency agencyObj);
        void deleteAgency(int agencyID);
    }
    [Serializable]
    public class News
    {
       public int id;
        public int newsAgencyId;
        public DateTime date;
        public string title;
        public string newsAbstract;
        public string text;
        public string category;
        public byte[] photo;
        public int totalReads;
        public int ranking;

        public News()
        {
            Console.WriteLine("{0}:{1}:{2}:{3}",DateTime.Now.Hour.ToString(),
                DateTime.Now.Minute.ToString(),DateTime.Now.Second.ToString(),DateTime.Now.Millisecond.ToString());
            Console.WriteLine("News.Constructor :news object created");
        }


    }
    [Serializable]
    public class Agency
    {
        public int id;
        public string city;
        public string language;
        public Agency()
        {
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
                DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
            Console.WriteLine("Agency.Constructor : agency object created");
        }
    }
}
