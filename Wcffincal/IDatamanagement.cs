using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Wcffincal
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "I" in both code and config file together.
    [ServiceContract]
    public interface IDatamanagement
    {

        // task operations 
        [OperationContract]
        int inserttask(string name, int complete, string category, string googleid, string uid);

        [OperationContract]
        int deletetask(string GoogleID, string uid);

        [OperationContract]
        object[] gettaskcat();

        [OperationContract]
        object[] gettask(string GoogleID , string uid);

        [OperationContract]
        int updatetask(string name, int complete, string uid, string tcid, string googleid);

        [OperationContract]
        string checktasks(string ID,string uid);

        [OperationContract]
        object[] gettaskids(string uid);



        //event operations 
        [OperationContract]
        int insertevent(DateTime edate, string summary, string location, string googleid, string uid, string desc);

        [OperationContract]
        int updateevent(DateTime edate, string summary, string location, string desc, string eid);

        [OperationContract]
        string checkevents(string ID, string uid);

        [OperationContract]
        int deleteevent(string GoogleID, string uid);

        [OperationContract]
        object[] getevent(string googleid, string uid);

        [OperationContract]
        int deleteeventpics(string GoogleID, string uid);

        [OperationContract]
        object[] geteventids(string uid);


        //event pictures operations
        [OperationContract]
        int inserteventpic(string eid, string pic, string egoogleid, string uid);

        [OperationContract]
        object[] geteventpics(string id, string uid);

        [OperationContract]
        string geteventfirstpics(string id, string uid);




        // picture operations 
        [OperationContract]
        int insertpicture(string picture, string description, string uid);

        [OperationContract]
        int deletepicture(string id, string uid);

        [OperationContract]
        int deleteallpictures(string uid);

        [OperationContract]
        object[][] getalluserpictures(string uid);

        [OperationContract]
        object[] getpic(string id, string uid);

        [OperationContract]
        int updatepic(string id, string description, string uid);

        [OperationContract]
        object[][] getfewpics(string uid);



        //scheduling operations 
        [OperationContract]
        int insertsechedule(DateTime starttime, DateTime endtime, string category);

        [OperationContract]
        int deleteschedule(string id);

        [OperationContract]
        int updateschedule(DateTime starttime, DateTime endtime, string category, string id);
    }
}
