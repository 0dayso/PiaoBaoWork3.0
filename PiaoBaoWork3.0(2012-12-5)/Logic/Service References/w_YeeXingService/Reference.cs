﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.296
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace PbProject.Logic.w_YeeXingService {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="w_YeeXingService.YeeXingSerivceSoap")]
    public interface YeeXingSerivceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ParsePnrMatchAirpContract", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ParsePnrMatchAirpContract(string UserName, string appUserName, string PNR, string PNRContent, string PatContent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ParsePnrBookContract", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ParsePnrBookContract(string UserName, string appUserName, string PNR, string PNRContent, string PatContent, string policyId, string PMPrice, string orderId, string policy, string extReward);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PayOutContract", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet PayOutContract(string UserName, string appUserName, string outOrderId, string Price, string PayWay, string Pay_Notify_url, string Ticket_Notify_url);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/OrderQueryContract", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet OrderQueryContract(string UserName, string appUserName, string outOrderId, string orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UserSign", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet UserSign(string UserName, string appUserName, string appPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UserUnsign", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet UserUnsign(string UserName, string appUserName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/RegisterNewUser", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet RegisterNewUser(string UserName, string LoginName, string LoginPwd, string Drcname, string Drcmobile, string Drcemail, string Localcity, string Drccompname, string Drccompadd, string Drccomptel, string Drccomppost);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/QueryFlight", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet QueryFlight(string UserName, string FromCityCode, string ToCityCode, string FromDate, string FromTime, string CarryCode);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface YeeXingSerivceSoapChannel : PbProject.Logic.w_YeeXingService.YeeXingSerivceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class YeeXingSerivceSoapClient : System.ServiceModel.ClientBase<PbProject.Logic.w_YeeXingService.YeeXingSerivceSoap>, PbProject.Logic.w_YeeXingService.YeeXingSerivceSoap {
        
        public YeeXingSerivceSoapClient() {
        }
        
        public YeeXingSerivceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public YeeXingSerivceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public YeeXingSerivceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public YeeXingSerivceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet ParsePnrMatchAirpContract(string UserName, string appUserName, string PNR, string PNRContent, string PatContent) {
            return base.Channel.ParsePnrMatchAirpContract(UserName, appUserName, PNR, PNRContent, PatContent);
        }
        
        public System.Data.DataSet ParsePnrBookContract(string UserName, string appUserName, string PNR, string PNRContent, string PatContent, string policyId, string PMPrice, string orderId, string policy, string extReward) {
            return base.Channel.ParsePnrBookContract(UserName, appUserName, PNR, PNRContent, PatContent, policyId, PMPrice, orderId, policy, extReward);
        }
        
        public System.Data.DataSet PayOutContract(string UserName, string appUserName, string outOrderId, string Price, string PayWay, string Pay_Notify_url, string Ticket_Notify_url) {
            return base.Channel.PayOutContract(UserName, appUserName, outOrderId, Price, PayWay, Pay_Notify_url, Ticket_Notify_url);
        }
        
        public System.Data.DataSet OrderQueryContract(string UserName, string appUserName, string outOrderId, string orderId) {
            return base.Channel.OrderQueryContract(UserName, appUserName, outOrderId, orderId);
        }
        
        public System.Data.DataSet UserSign(string UserName, string appUserName, string appPassword) {
            return base.Channel.UserSign(UserName, appUserName, appPassword);
        }
        
        public System.Data.DataSet UserUnsign(string UserName, string appUserName) {
            return base.Channel.UserUnsign(UserName, appUserName);
        }
        
        public System.Data.DataSet RegisterNewUser(string UserName, string LoginName, string LoginPwd, string Drcname, string Drcmobile, string Drcemail, string Localcity, string Drccompname, string Drccompadd, string Drccomptel, string Drccomppost) {
            return base.Channel.RegisterNewUser(UserName, LoginName, LoginPwd, Drcname, Drcmobile, Drcemail, Localcity, Drccompname, Drccompadd, Drccomptel, Drccomppost);
        }
        
        public System.Data.DataSet QueryFlight(string UserName, string FromCityCode, string ToCityCode, string FromDate, string FromTime, string CarryCode) {
            return base.Channel.QueryFlight(UserName, FromCityCode, ToCityCode, FromDate, FromTime, CarryCode);
        }
    }
}
