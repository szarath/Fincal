﻿using System;
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
        int inserttask(string name, string complete, string category, string googleid, string uid);

        [OperationContract]
        int deletetask(string GoogleID, string uid);

        [OperationContract]
        object[] gettaskcat();

        [OperationContract]
        object[] gettask(string GoogleID , string uid);

        [OperationContract]
        int updatetask(string name, string complete, string uid, string tcid, string googleid,string taskid);

        [OperationContract]
        string checktasks(string ID,string uid);

        [OperationContract]
        object[] gettaskids(string uid);

        [OperationContract]
        int deleteallusertasks(string uid);


        //event operations 
        [OperationContract]
        int insertevent(DateTime edate, string summary, string location, string googleid, string uid, string desc);

        [OperationContract]
        int updateevent(DateTime edate, string summary, string location, string desc,string googleid, string eid);

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

        [OperationContract]
        Object[][] getalluserevents(string uid);

        [OperationContract]
        int deletealluserevents(string uid);

        //event pictures operations
        [OperationContract]
        int inserteventpic(string eid, string pic, string egoogleid, string uid);

        [OperationContract]
        object[] geteventpics(string id, string uid);

        [OperationContract]
        string geteventfirstpics(string id, string uid);




        // picture operations 
        [OperationContract]
        int insertpicture(string picture, string title, string description, string uid);

        [OperationContract]
        int deletepicture(string id, string uid);

        [OperationContract]
        int deleteallpictures(string uid);

        [OperationContract]
        object[][] getalluserpictures(string uid);

        [OperationContract]
        object[] getpic(string id, string uid);

        [OperationContract]
        int updatepic(string id, string title, string description, string uid);

        [OperationContract]
        object[][] getfewpics(string uid);



        //Time management operations 
        [OperationContract]
        int insertsechedule(DateTime starttime, DateTime endtime, string category);

        [OperationContract]
        int deleteschedule(string id);

        [OperationContract]
        int updateschedule(DateTime starttime, DateTime endtime, string category, string id);






        //skills operations 
        [OperationContract]
        object[] getskills();



        //porject operations


        [OperationContract]
        object[] getassignedprojects(string uid);

        [OperationContract]
        object[] getprojectdetails(string projid);

        [OperationContract]
        object[][] getprojects(string uid);

        [OperationContract]
        int createproject(string title, string description, string uid, DateTime pcredate);

        [OperationContract]
        int updateproject(string title, string description, string projID);

        [OperationContract]
        int deleteproject(string projid);

        [OperationContract]
        Object[][] getassignedprojdetials(string uid);


        //issues operations

        [OperationContract]
        object[] getassignedissues(string uid);

        [OperationContract]
        object[][] getissues(string uid);

        [OperationContract]
        object[][] getprojissues(string projid);

        [OperationContract]
        object[] getissuedetails(string issueid);


        [OperationContract]
        int createissue(string title, string description,  string projid, string category, string uid, DateTime iscredate);

        [OperationContract]
        int updateissue(string isid, string status, string assid);

        [OperationContract]
        int deleteissue(string issueid);

        [OperationContract]
        int deleteprojissues(string projid);

        [OperationContract]
        Object[][] issueteam(string isID);


        [OperationContract]
        Object[][] getassignedissdetials(string uid);


        [OperationContract]
        int deleteuserfromprojteams(string uid);

        // project teams operaiotns 
        [OperationContract]
        int addprojteam(string uid, string projid);


        [OperationContract]
        int deleteprojteam(string projid);

        [OperationContract]
        int deleteassiguserfromteam(string uid, string projid);

        [OperationContract]
        object[] getprojectmembers(string projid);

        [OperationContract]
        int deleteuserfromissteams(string uid);


        //issue teams operations 
        [OperationContract]
        int addissteam(string uid, string issueid);


        [OperationContract]
        int deleteissteam(string issueid);

        [OperationContract]
        int deleteassiguserformissue(string uid, string issueid);

        [OperationContract]
        object[] getissuemembers(string issid);


        //notification project operations 

        [OperationContract]
        object[][] getprojnotification(string projectnotificationuserid);

        [OperationContract]
        int insertprojectnotifications(string porjid, string uid,DateTime credate);

        [OperationContract]
        int deleteporjnotificaiton(string projid, string uid);

        [OperationContract]
        int deleteallprojnotificaion(string projid);

        [OperationContract]
        object[] getprojnoticedetails(string projnoticeid);

      

       
        //notificaiotns issue operations

        [OperationContract]
        object[][] getissuenotifications(string issuenotificationuserid); 

        [OperationContract]
        int deleteissuenotification(string issid, string uid);

        [OperationContract]
        int insertissuenotifications(string issueid, string uid, DateTime credate);

        [OperationContract]
        int deleteissnoticeiss(string issid);

        [OperationContract]
        Object[][] getuserinformation();

        [OperationContract]
        object[] getissnoticeiss(string isid);

        [OperationContract]
        object[] getprojectleaderinformaion(string uid);

        [OperationContract]
        object[] getspecificuserinformation(string uid);

        [OperationContract]
        object[] getissuenoticedetails(string isnid);


        //meeting 
        [OperationContract]
        object[][] getmeetinginfromations(string uid);

        [OperationContract]
        int deletemeeting(string meetid);

        [OperationContract]
        Object[][] getusermeetings(string uid);

        [OperationContract]
        int insertmeeting(string meettitle,string meetdesc,string meetdatetime,string projid,string uid);

        [OperationContract]
        int insertmeetingmember(string meetid,string uid,string mlaccept);

        [OperationContract]
        int updatemeetinglink(string mlID, string mlaccept);

        [OperationContract]
        int updatemeeting(string meetingid, string meettitle, string meetdesc, string meetdatetime, string projid, string uid);

        [OperationContract]
        int deletemeetingmembers(string meetid);

        [OperationContract]
        int deletespecificmember(string meetid, string uid);

        [OperationContract]
        object[] getprojmeetings(string projid);

        [OperationContract]
        Object[][] getmeetingmembers(string projID);

        [OperationContract]
        object[] getmeetinginformation(string meetid);

        [OperationContract]
        Object[][] getmeetingattendance(string meetID);

        [OperationContract]
        object[] getmeetinglink(string mlid);

        [OperationContract]
        int deleteuserfrommeetinglink(string uid);

        [OperationContract]
        Object[][] getallattendingmeeting(string meetid);

        //flagging 
        [OperationContract]
        int insertissflag(string isstitle, string issdesc, string projid, string uid);

        [OperationContract]
        Object[][] getissueflags(string projID);

        [OperationContract]
        int deleteissflag(string isfid);

        [OperationContract]
        object[] getspecificissflag(string isfid);

        [OperationContract]
        int deleteissflagproj(string projid);

        [OperationContract]
        int deleteuserfromisflags(string uid);
    }
}
