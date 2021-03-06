﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fincal.Chatmanagement {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Chatmanagement.IChat")]
    public interface IChat {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/getprojchat", ReplyAction="http://tempuri.org/IChat/getprojchatResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[][]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[][] getprojchat(string projid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/getprojchat", ReplyAction="http://tempuri.org/IChat/getprojchatResponse")]
        System.Threading.Tasks.Task<object[][]> getprojchatAsync(string projid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/getissuechat", ReplyAction="http://tempuri.org/IChat/getissuechatResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[][]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[][] getissuechat(string issueid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/getissuechat", ReplyAction="http://tempuri.org/IChat/getissuechatResponse")]
        System.Threading.Tasks.Task<object[][]> getissuechatAsync(string issueid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/insertprojchat", ReplyAction="http://tempuri.org/IChat/insertprojchatResponse")]
        int insertprojchat(string message, string projid, string uid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/insertprojchat", ReplyAction="http://tempuri.org/IChat/insertprojchatResponse")]
        System.Threading.Tasks.Task<int> insertprojchatAsync(string message, string projid, string uid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/insertissuechat", ReplyAction="http://tempuri.org/IChat/insertissuechatResponse")]
        int insertissuechat(string message, string issueid, string uid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/insertissuechat", ReplyAction="http://tempuri.org/IChat/insertissuechatResponse")]
        System.Threading.Tasks.Task<int> insertissuechatAsync(string message, string issueid, string uid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/deleteprojchat", ReplyAction="http://tempuri.org/IChat/deleteprojchatResponse")]
        int deleteprojchat(string projid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/deleteprojchat", ReplyAction="http://tempuri.org/IChat/deleteprojchatResponse")]
        System.Threading.Tasks.Task<int> deleteprojchatAsync(string projid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/deleteissuechat", ReplyAction="http://tempuri.org/IChat/deleteissuechatResponse")]
        int deleteissuechat(string issueid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/deleteissuechat", ReplyAction="http://tempuri.org/IChat/deleteissuechatResponse")]
        System.Threading.Tasks.Task<int> deleteissuechatAsync(string issueid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/deletespecificprojmessage", ReplyAction="http://tempuri.org/IChat/deletespecificprojmessageResponse")]
        int deletespecificprojmessage(string pcID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/deletespecificprojmessage", ReplyAction="http://tempuri.org/IChat/deletespecificprojmessageResponse")]
        System.Threading.Tasks.Task<int> deletespecificprojmessageAsync(string pcID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/deletespecificissuemessage", ReplyAction="http://tempuri.org/IChat/deletespecificissuemessageResponse")]
        int deletespecificissuemessage(string icID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/deletespecificissuemessage", ReplyAction="http://tempuri.org/IChat/deletespecificissuemessageResponse")]
        System.Threading.Tasks.Task<int> deletespecificissuemessageAsync(string icID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/deleteprojchatuser", ReplyAction="http://tempuri.org/IChat/deleteprojchatuserResponse")]
        int deleteprojchatuser(string uid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/deleteprojchatuser", ReplyAction="http://tempuri.org/IChat/deleteprojchatuserResponse")]
        System.Threading.Tasks.Task<int> deleteprojchatuserAsync(string uid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/deleteisschatuser", ReplyAction="http://tempuri.org/IChat/deleteisschatuserResponse")]
        int deleteisschatuser(string uid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/deleteisschatuser", ReplyAction="http://tempuri.org/IChat/deleteisschatuserResponse")]
        System.Threading.Tasks.Task<int> deleteisschatuserAsync(string uid);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatChannel : Fincal.Chatmanagement.IChat, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatClient : System.ServiceModel.ClientBase<Fincal.Chatmanagement.IChat>, Fincal.Chatmanagement.IChat {
        
        public ChatClient() {
        }
        
        public ChatClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ChatClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChatClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChatClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public object[][] getprojchat(string projid) {
            return base.Channel.getprojchat(projid);
        }
        
        public System.Threading.Tasks.Task<object[][]> getprojchatAsync(string projid) {
            return base.Channel.getprojchatAsync(projid);
        }
        
        public object[][] getissuechat(string issueid) {
            return base.Channel.getissuechat(issueid);
        }
        
        public System.Threading.Tasks.Task<object[][]> getissuechatAsync(string issueid) {
            return base.Channel.getissuechatAsync(issueid);
        }
        
        public int insertprojchat(string message, string projid, string uid) {
            return base.Channel.insertprojchat(message, projid, uid);
        }
        
        public System.Threading.Tasks.Task<int> insertprojchatAsync(string message, string projid, string uid) {
            return base.Channel.insertprojchatAsync(message, projid, uid);
        }
        
        public int insertissuechat(string message, string issueid, string uid) {
            return base.Channel.insertissuechat(message, issueid, uid);
        }
        
        public System.Threading.Tasks.Task<int> insertissuechatAsync(string message, string issueid, string uid) {
            return base.Channel.insertissuechatAsync(message, issueid, uid);
        }
        
        public int deleteprojchat(string projid) {
            return base.Channel.deleteprojchat(projid);
        }
        
        public System.Threading.Tasks.Task<int> deleteprojchatAsync(string projid) {
            return base.Channel.deleteprojchatAsync(projid);
        }
        
        public int deleteissuechat(string issueid) {
            return base.Channel.deleteissuechat(issueid);
        }
        
        public System.Threading.Tasks.Task<int> deleteissuechatAsync(string issueid) {
            return base.Channel.deleteissuechatAsync(issueid);
        }
        
        public int deletespecificprojmessage(string pcID) {
            return base.Channel.deletespecificprojmessage(pcID);
        }
        
        public System.Threading.Tasks.Task<int> deletespecificprojmessageAsync(string pcID) {
            return base.Channel.deletespecificprojmessageAsync(pcID);
        }
        
        public int deletespecificissuemessage(string icID) {
            return base.Channel.deletespecificissuemessage(icID);
        }
        
        public System.Threading.Tasks.Task<int> deletespecificissuemessageAsync(string icID) {
            return base.Channel.deletespecificissuemessageAsync(icID);
        }
        
        public int deleteprojchatuser(string uid) {
            return base.Channel.deleteprojchatuser(uid);
        }
        
        public System.Threading.Tasks.Task<int> deleteprojchatuserAsync(string uid) {
            return base.Channel.deleteprojchatuserAsync(uid);
        }
        
        public int deleteisschatuser(string uid) {
            return base.Channel.deleteisschatuser(uid);
        }
        
        public System.Threading.Tasks.Task<int> deleteisschatuserAsync(string uid) {
            return base.Channel.deleteisschatuserAsync(uid);
        }
    }
}
