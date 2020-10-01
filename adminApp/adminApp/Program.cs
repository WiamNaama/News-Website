using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using NewsLibrary;
using System.Data;
using System.IO;

namespace adminApp
{
    public class NewsManager : MarshalByRefObject, INewsManager
    {
        SqlDataReader reader;
        SqlConnection con;
        SqlCommand myCommand;
        SqlDataAdapter myAdapter;
        public  NewsManager()
        {
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
               DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
            Console.WriteLine("NewsManager.Constructor : object created");

            //connect to DB
            string connString = " Data Source =.; Initial Catalog = NewsDB; Integrated Security = True; MultipleActiveResultSets=True;";
            con = new SqlConnection(connString);
            con.Open();
        }

        void INewsManager.addNews(News newsObj)
        {

            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
               DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
            Console.WriteLine("NewsManager.addNews : adding news to DB");

            //get max news ID
            string sql = "SELECT MAX(ID) FROM News";
            myCommand = con.CreateCommand();
            myCommand.CommandText = sql;
            int id = 0;
            try
            {
               id = (int)myCommand.ExecuteScalar();
            }
            catch
            {
                id = 1;
            }
            id++;
            // Insert statement.
            sql = "Insert into News ([ID], [AgencyID],[Date],[Title] ,[Abstract], [Text],[Category],[TotalReads],[Photo],[Probability]) "
                                             + " values (@id, @agencyId, @date,@title,@abstract,@text,@category,@totalReads,@photo,@probability) ";

            using (myCommand = new SqlCommand())
            {
                myCommand = con.CreateCommand();
                myCommand.CommandText = sql;


                // Create Parameter.
                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@ID", id);
                myCommand.Parameters.AddWithValue("@agencyId", newsObj.newsAgencyId);
                myCommand.Parameters.AddWithValue("@date", newsObj.date);
                myCommand.Parameters.AddWithValue("@title", newsObj.title);
                myCommand.Parameters.AddWithValue("@abstract", newsObj.newsAbstract);
                myCommand.Parameters.AddWithValue("@text", newsObj.text);
                myCommand.Parameters.AddWithValue("@category", newsObj.category);
                myCommand.Parameters.AddWithValue("@totalReads",0);
                myCommand.Parameters.AddWithValue("@photo", newsObj.photo);
                myCommand.Parameters.AddWithValue("@probability", 0);

                myCommand.ExecuteNonQuery();
            }
        }

        void INewsManager.removeNews(int ID)
        {
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
               DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
            Console.WriteLine("NewsManager.removeNews : deleting News from DB whose ID is:{0}", arg0: ID);

            // delete news statement.
            string sql = "delete from News where ID= @ID";
            myCommand.CommandText = sql;
            // Create Parameter.
            myCommand.Parameters.Clear();
            myCommand.Parameters.AddWithValue("@ID", ID);

            myCommand.ExecuteNonQuery();
        }
        void INewsManager.updateNewsPhoto(News newsObj)
        {
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
              DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
            Console.WriteLine("NewsManager.updateNewsPhoto : updating News photo whose ID is:{0}", arg0: newsObj.id);

            // update photo statement.
            string sql = "Update News set photo =@photo where ID=@ID ";

            myCommand = con.CreateCommand();
            myCommand.CommandText = sql;

            // Create Parameter.
            myCommand.Parameters.Clear();
            myCommand.Parameters.AddWithValue("@ID", newsObj.id);
            myCommand.Parameters.AddWithValue("@photo", newsObj.photo);

            myCommand.ExecuteNonQuery();
        }
        Agency[] INewsManager.getAgencies()
        {
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
             DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
            Console.WriteLine("NewsManager.getAgencies : retrive all agencies from DB");

            List<Agency> Agencies = new List<Agency>();
            SqlCommand cmd = new SqlCommand("select * from Agency", con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Agency agencyObj = new Agency();
                    agencyObj.id = Convert.ToInt32(reader[0]);
                    agencyObj.city = Convert.ToString(reader[1]);
                    agencyObj.language = Convert.ToString(reader[2]);

                    Agencies.Add(agencyObj);

                }
            }
            return Agencies.ToArray();
        }
        DataTable INewsManager.getNews(int ID)
        {
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
                         DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
            Console.WriteLine("NewsManager.getNews : retrive news from DB whose ID is {0}",ID);


            string sql = "Select * from News where ID =@ID";
            myCommand = con.CreateCommand();
            myCommand.CommandText = sql;
            myCommand.Parameters.Clear();
            myCommand.Parameters.AddWithValue("@ID", ID);
            myAdapter = new SqlDataAdapter(myCommand);
            DataTable dt = new DataTable();
            myAdapter.Fill(dt);
            return dt;
        }
        DataTable INewsManager.getLastTenNews()
        {
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
                        DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
            Console.WriteLine("NewsManager.getLastTenNews : retrive last 10 news from DB");

            string sql = "Select top 10 ID, Title,Abstract,Text,Date,TotalReads,Classification,Probability,N.AgencyID,City, Language" +
                " from News N , Agency A where N.AgencyID=A.AgencyID order by Date desc ";
            myCommand = con.CreateCommand();
            myCommand.CommandText = sql;

            myAdapter = new SqlDataAdapter(myCommand);
            DataTable dt = new DataTable();
            myAdapter.Fill(dt);
            return dt;
        }
         DataTable INewsManager.getAgencyNews(int AgencyId)
        {
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
                        DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
            Console.WriteLine("NewsManager.getAgencyNews : retrive news from DB whose Agency ID is {0}", AgencyId);


            string sql = "Select * from News where AgencyID =@AgencyID";
            myCommand = con.CreateCommand();
            myCommand.CommandText = sql;
            myCommand.Parameters.Clear();
            myCommand.Parameters.AddWithValue("@AgencyID", AgencyId);
            myAdapter = new SqlDataAdapter(myCommand);
            DataTable dt = new DataTable();
            myAdapter.Fill(dt);
            return dt;
        }
        byte[] INewsManager.getNewsImage(int ID)
        {
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
                         DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
            Console.WriteLine("NewsManager.getNewsImage : retrive image of news whose ID is {0}", ID);


            string sql = "Select photo from News where ID =@ID";
            SqlCommand cmd = new SqlCommand();
            object img;
            using (cmd = new SqlCommand())
            {
                cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", ID);
                img = cmd.ExecuteScalar();
                    
            }
            try
            {
                return (byte[])img;
            }
            catch
            {
                return null;
            }
        }
        DataTable INewsManager.getAllNews()
        {
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
              DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
            Console.WriteLine("NewsManager.getAllNews : retrive all news from DB");

            // delete news statement.
            string sql = "Select ID, Title,Abstract,Text,Date,TotalReads,Classification,Probability,N.AgencyID,City, Language" +
                " from News N , Agency A where N.AgencyID=A.AgencyID order by Date desc ";
            myCommand = con.CreateCommand();
            myCommand.CommandText = sql;

            myAdapter = new SqlDataAdapter(myCommand);
            DataTable dt = new DataTable();
            myAdapter.Fill(dt);
            return dt;
        }
        void INewsManager.addAgency(Agency agencyObj)
        {

            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
               DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
            Console.WriteLine("NewsManager.addAgency : adding Agency to DB");

            //get max news ID
            int agencyID = 0;
            string sql = "SELECT MAX(AgencyID) FROM Agency";
            using (myCommand = new SqlCommand())
            {  
                myCommand = con.CreateCommand();
                myCommand.CommandText = sql;
                try
                {
                    agencyID = (int)myCommand.ExecuteScalar();
                }
                catch
                {
                    agencyID = 1;
                }
                agencyID++;
            }
            // Insert statement.
            sql = "Insert into Agency ([AgencyID], [City],[Language])  values (@agencyID, @city, @language) ";

            using (myCommand = new SqlCommand())
            {
                myCommand = con.CreateCommand();
                myCommand.CommandText = sql;


                // Create Parameter.
                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@agencyID", agencyID);
                myCommand.Parameters.AddWithValue("@city", agencyObj.city);
                myCommand.Parameters.AddWithValue("@language", agencyObj.language);
                myCommand.ExecuteNonQuery();
            }
        }
        void INewsManager.updateAgency(Agency agencyObj)
        {
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
               DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
            Console.WriteLine("NewsManager.updateAgency : editting Agency whose ID is: {0}",agencyObj.id);

            // update statement.
            string sql = "Update  Agency set  [City] = @city,[Language]=@language where [AgencyID]=@agencyID ";

            using (myCommand = new SqlCommand())
            {
                myCommand = con.CreateCommand();
                myCommand.CommandText = sql;

                // Create Parameter.
                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@agencyID", agencyObj.id);
                myCommand.Parameters.AddWithValue("@city", agencyObj.city);
                myCommand.Parameters.AddWithValue("@language", agencyObj.language);
                myCommand.ExecuteNonQuery();
            }
        }
        void INewsManager.deleteAgency(int agencyID)
        {
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
              DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
            Console.WriteLine("NewsManager.deleteAgency : delete Agency whose ID is: {0}", agencyID);

            // delete statement.
            string sql = "Delete from  Agency where [AgencyID]=@agencyID ";

            using (myCommand = new SqlCommand())
            {
                myCommand = con.CreateCommand();
                myCommand.CommandText = sql;

                // Create Parameter.
                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@agencyID", agencyID);
                myCommand.ExecuteNonQuery();
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            HttpChannel chnl = new HttpChannel(1234);
            ChannelServices.RegisterChannel(chnl,false);
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
              DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
            Console.WriteLine("Server.Main : Server is ready to be used at port 1234");

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(NewsManager),"NewsManager.soap",WellKnownObjectMode.Singleton);
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
            DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
            Console.WriteLine("Server.Main : SingleTone Remoting is configured");
            Console.ReadKey();
        }
    }
}
