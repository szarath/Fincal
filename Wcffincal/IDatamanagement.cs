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
        int deletetask(string GoogleID);

        [OperationContract]
        object[] gettaskcat();

        [OperationContract]
        object[] gettask(string GoogleID);

        [OperationContract]
        int updatetask(string name, int complete, string uid, string tcid, string googleid);

        [OperationContract]
        string checktasks(string ID);

        [OperationContract]
        object[] gettaskids(string uid);



        //event operations 
        [OperationContract]
        int insertevent(DateTime edate, string summary, string location, string googleid, string uid, string desc);

        [OperationContract]
        int updateevent(DateTime edate, string summary, string location, string desc, string eid);

        [OperationContract]
        string checkevents(string ID);

        [OperationContract]
        int deleteevent(string GoogleID);

        [OperationContract]
        object[] getevent(string googleid);

        [OperationContract]
        int deleteeventpics(string GoogleID);

        [OperationContract]
        object[] geteventids(string uid);


        //event pictures operations
        [OperationContract]
        int inserteventpic(string eid, string pic, string egoogleid, string uid);

        [OperationContract]
        object[] geteventpics(string id);

        [OperationContract]
        string geteventfirstpics(string id);




        // picture operations 
        [OperationContract]
        int insertpicture(string picture, string description, string uid);

        [OperationContract]
        int deletepicture(string id);

        [OperationContract]
        int deleteallpictures(string uid);

        [OperationContract]
        object[][] getalluserpictures(string uid);

        [OperationContract]
        object[] getpic(string id);

        [OperationContract]
        int updatepic(string id, string description);





        //scheduling operations 
        [OperationContract]
        int insertsechedule(DateTime starttime, DateTime endtime, string category);

        [OperationContract]
        int deleteschedule(string id);

        [OperationContract]
        int updateschedule(DateTime starttime, DateTime endtime, string category, string id);
    }
}
