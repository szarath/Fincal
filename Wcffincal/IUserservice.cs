using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Wcffincal
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDatamanagement" in both code and config file together.
    [ServiceContract]
    public interface IUserservice
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        //user operations 
        [OperationContract]
        //[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/AndroidinsertAd")]
        int insertUser(string Username, string Password, string firstName, string surname, string Email, DateTime DoB, string skill, string gitrepo);

        [OperationContract]
        //  [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/AndroidinsertAd")]
        Object[] Authenticate(string UserEmail, string Password);

        [OperationContract]
        //  [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/getUserDetailsManagement")]
        Object[] getUserDetailsManagement(int userID);

        [OperationContract]
        //  [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/updateUserInfo")]
        int updateUserInfo(string ID, string firstName, string surname, DateTime DoB, string skill, string gitrepo);

        [OperationContract]
        //  [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/deleteUser")]
        int deleteUser(string ID);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
