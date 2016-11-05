﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.296
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace PbProject.Logic.w_PMWebService {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://203.88.210.234:116/PMService.asmx", ConfigurationName="w_PMWebService.PMServiceSoap")]
    public interface PMServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://203.88.210.234:116/PMService.asmx/GetPolicyDataByDC", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetPolicyDataByDC(string Date, string Flightno, string FromCityCode, string ToCityCode, string dataFormat, string Seat, string UID, string PWD);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://203.88.210.234:116/PMService.asmx/GetPolicyDataByWFLC", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetPolicyDataByWFLC(string Type, string Date, string Date2, string Flightno, string Flightno2, string FromCityCode, string FromCityCode2, string ToCityCode, string ToCityCode2, string dataFormat, string Seat, string Seat2, string UID, string PWD);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://203.88.210.234:116/PMService.asmx/CreateOrder", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet CreateOrder(string PolicyID, string PnrCode, string UID, string PWD);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://203.88.210.234:116/PMService.asmx/CreateOrderByPAT", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet CreateOrderByPAT(string policyID, string bigPNR, string rtData, string patData, string isChild, string UID, string PWD);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://203.88.210.234:116/PMService.asmx/PMPay", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet PMPay(string OrderID, string UID, string PWD);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://203.88.210.234:116/PMService.asmx/PMOrderQuery", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet PMOrderQuery(string OrderID, string UID, string PWD);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://203.88.210.234:116/PMService.asmx/PMOrderTF", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string PMOrderTF(string OrderID, string Ticketno, string Status, string Comment, string Refoundfee, string UID, string PWD);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PMServiceSoapChannel : PbProject.Logic.w_PMWebService.PMServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PMServiceSoapClient : System.ServiceModel.ClientBase<PbProject.Logic.w_PMWebService.PMServiceSoap>, PbProject.Logic.w_PMWebService.PMServiceSoap {
        
        public PMServiceSoapClient() {
        }
        
        public PMServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PMServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PMServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PMServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet GetPolicyDataByDC(string Date, string Flightno, string FromCityCode, string ToCityCode, string dataFormat, string Seat, string UID, string PWD) {
            return base.Channel.GetPolicyDataByDC(Date, Flightno, FromCityCode, ToCityCode, dataFormat, Seat, UID, PWD);
        }
        
        public System.Data.DataSet GetPolicyDataByWFLC(string Type, string Date, string Date2, string Flightno, string Flightno2, string FromCityCode, string FromCityCode2, string ToCityCode, string ToCityCode2, string dataFormat, string Seat, string Seat2, string UID, string PWD) {
            return base.Channel.GetPolicyDataByWFLC(Type, Date, Date2, Flightno, Flightno2, FromCityCode, FromCityCode2, ToCityCode, ToCityCode2, dataFormat, Seat, Seat2, UID, PWD);
        }
        
        public System.Data.DataSet CreateOrder(string PolicyID, string PnrCode, string UID, string PWD) {
            return base.Channel.CreateOrder(PolicyID, PnrCode, UID, PWD);
        }
        
        public System.Data.DataSet CreateOrderByPAT(string policyID, string bigPNR, string rtData, string patData, string isChild, string UID, string PWD) {
            return base.Channel.CreateOrderByPAT(policyID, bigPNR, rtData, patData, isChild, UID, PWD);
        }
        
        public System.Data.DataSet PMPay(string OrderID, string UID, string PWD) {
            return base.Channel.PMPay(OrderID, UID, PWD);
        }
        
        public System.Data.DataSet PMOrderQuery(string OrderID, string UID, string PWD) {
            return base.Channel.PMOrderQuery(OrderID, UID, PWD);
        }
        
        public string PMOrderTF(string OrderID, string Ticketno, string Status, string Comment, string Refoundfee, string UID, string PWD) {
            return base.Channel.PMOrderTF(OrderID, Ticketno, Status, Comment, Refoundfee, UID, PWD);
        }
    }
}
