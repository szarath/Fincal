using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Wcffincal
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IChat" in both code and config file together.
    [ServiceContract]
    public interface IChat
    {
        

        [OperationContract]
        Object[][] getprojchat(string projid);

        [OperationContract]
        Object[][] getissuechat(string issueid);

        [OperationContract]
        int insertprojchat(string message, string projid, string uid);

        [OperationContract]
        int insertissuechat(string message, string issueid, string uid);

        [OperationContract]
        int deleteprojchat(string projid);

        [OperationContract]
        int deleteissuechat(string issueid);

        [OperationContract]
        int deletespecificprojmessage(string pcID);

        [OperationContract]
        int deletespecificissuemessage(string icID);

        [OperationContract]
        int deleteprojchatuser(string uid);

        [OperationContract]
        int deleteisschatuser(string uid);


    }
}
