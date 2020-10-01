using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Project
{
    
    [ServiceContract]
    public interface INewsService
    {
        [OperationContract]
        List<New> GetTenNews(String Userinput);


        [OperationContract]
        List<New> GetSimilarNews(String Userinput);

        [OperationContract]
        List<New> GetNBestPossitive(String Userinput);


        [OperationContract]
        List<New> GetNBestNegative(String Userinput);

        [OperationContract]
        void AddToRanking(Ranking UserRanking);

        [OperationContract]
        byte[] GetNewsPhoto(int NewsID);

    }

   
}
