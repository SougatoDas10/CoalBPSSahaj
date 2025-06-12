using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace COALBPS_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceCOALBPS
    {

        #region Login Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppLogin"

       )]
        CustomerDetails COALBPSLogin(Stream ReceiveData);

        #endregion

        #region loginwithPin Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "/COALBPSAppLoginWithpin"

        )]
        CustomerDetails COALBPSLoginWithpin(Stream ReceiveData);



        #endregion loginwithPin Interface

        #region loginCheckExistPIN Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "/COALBPSAppLoginCheckExistPIN"

        )]
        loginWithPin COALBPSLoginCheckExistPIN(Stream ReceiveData);



        #endregion loginCheckExistPIN Interface

        #region LoginCreatePIN Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "/COALBPSAppLoginCreatePIN"

        )]
        loginWithPin LoginCreatePIN(Stream ReceiveData);



        #endregion loginCheckExistPIN Interface




        #region Location Source Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppSourceLocation"

       )]
        SourceLocationList COALBPSSourceLocation(Stream ReceiveData);

        #endregion

        #region Product List Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppProdList"

       )]
        ProductList COALBPSProdList(Stream ReceiveData);

        #endregion

        #region Product Price  Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppProdPrice"

       )]
        ProductPriceList COALBPSProdPrice(Stream ReceiveData);

        #endregion

        #region DashBoard Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppDashBoard"

       )]
        Dashboard COALBPSDashBoard(Stream ReceiveData);

        //New Dashboardstatus
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSDashBoardStatus"

       )]
        Dashboard COALBPSDashBoardStatus(Stream ReceiveData);

        //Only Data Collection for Categoryid 1
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppDashBoardFooter"

       )]
        Dashboard COALBPSDashBoardFooter(Stream ReceiveData);

        #endregion

        #region Truck, Category and State Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppCatStatTruc"

       )]
        CatStatTruc COALBPSCatStatTruc(Stream ReceiveData);


        #endregion




        #region Truck, Category and State Interface for OutStation

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppOutStationCatStatTruc"

       )]
        CatStatTruc OutStationCOALBPSCatStatTruc(Stream ReceiveData);


        #endregion

        #region Truck Change

        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "/COALBPSAppTruckChange"

      )]
        TruckChangeUpdate COALBPSTruckChange(Stream ReceiveData);



        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "/COALBPSAppTruckChangeList"

      )]
        TruckChangeList COALBPSTruckChangeList(Stream ReceiveData);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "/COALBPSAppApproveRejectTruckChange"

         )]
        TruckChangeUpdate COALBPSApproveRejectTruckChange(Stream ReceiveData);

        #endregion

        #region Send Booking Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppSendBooking"

       )]
        Booking COALBPSSendBooking(Stream ReceiveData);

        #endregion

        #region Booking Status Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppBookingStatus"
       )]
        BookingStatus COALBPSBookingStatus(Stream ReceiveData);

        #endregion

        #region BookingApprove List

        #endregion

        #region Booking Cancel List Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppBookingCancelList"
       )]
        CancelBookingList COALBPSBookingCancelList(Stream ReceiveData);

        #endregion

        #region Booking Cancel Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppBookingCancel"
       )]
        CancelBooking COALBPSBookingCancel(Stream ReceiveData);

        #endregion

        #region Contact Link Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppContactLink"
       )]
        ContactLink COALBPSContactLink(Stream ReceiveData);

        #endregion

        #region Booking Extend List Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppBookingExtendList"
       )]
        ExtendBookingList COALBPSBookingExtendList(Stream ReceiveData);

        #endregion

        #region Booking Extend Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppBookingExtend"
       )]
        ExtendBooking COALBPSBookingExtend(Stream ReceiveData);

        #endregion

        #region Contact Link Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppCustomerContactLink"
       )]
        CustomerContactLink COALBPSCustomerContactLink(Stream ReceiveData);

        #endregion

        #region Contact Link Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppRefundRequest"
       )]
        RefundRequest COALBPSRefundRequest(Stream ReceiveData);

        #endregion

        #region OTP Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppOTPRequest"
       )]

        CustomerDetails COALBPSOTPRequest(Stream ReceiveData);

        #endregion
        #region Notification
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppShownotification"

       )]
        Notification COALBPSAppShownotification(Stream ReceiveData);
        #endregion Notification



        #region Get truck Booking No
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppTruckBookingNo"

       )]
        TruckBookingNo COALBPSGetTruckBookingNo(Stream ReceiveData);
        #endregion

        #region get vts Details
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppVtsDetails"

        )]
        VTSDetails COALBPSGetVtsDetails(Stream ReceiveData);
        #endregion




        #region Get Booking Approve Details

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppapproveTruckBookingDetails"

       )]
        ApproveBookingStatus COALBPSApproveBookingStatus(Stream ReceiveData);
        #endregion


        #region Get Booking Confirm Details
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSConfirmBookingStatus"

        )]
        ApproveBookingStatus COALBPSConfirmBookingStatus(Stream ReceiveData);
        #endregion
        #region Update Truck Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppUpdateTruck"

       )]
        TruckUpdate COALBPSUpdateTruck(Stream ReceiveData);

        #endregion

        #region Update BookingPin

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppUpdateBookPin"

       )]
        BookPinUpdate COALBPSUpdateBookPin(Stream ReceiveData);

        #endregion BookingPin

        #region Complain
        [OperationContract]
        [WebInvoke(Method = "POST",
      ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped,
      UriTemplate = "/COALBPSAppLodgeComplains"
     )]
        UpdateComplain COALBPSLodgeComplain(Stream ReceiveData);

        [OperationContract]
        [WebInvoke(Method = "POST",
    ResponseFormat = WebMessageFormat.Json,
    BodyStyle = WebMessageBodyStyle.Wrapped,
    UriTemplate = "/COALBPSAppSubmitReply"
   )]
        UpdateReply COALBPSSubmitReply(Stream ReceiveData);


        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "/COALBPSAppComplainList"
        )]
        ComplainList COALBPSComplainList(Stream ReceiveData);


        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppReplyList"
       )]
        ReplyList COALBPSReplyList(Stream ReceiveData);



        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppCloseComplain"
       )]
        UpdateComplain COALBPSCloseComplain(Stream ReceiveData);


        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppChangeQty"
       )]
        UpdateQty COALBPSChangeQty(Stream ReceiveData);

        #endregion

        #region UpdateMobileVersion

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "/COALBPSAppUpdateMobileVersion"

        )]
        MobileVersion COALBPSUpdateMobileVersion(Stream ReceiveData);

        #endregion UpdateMobileVersion


        #region GetMobileVersion

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "/COALBPSAppCOALBPSGetMobileVersion"

        )]
        MobileVersion COALBPSGetMobileVersion(Stream ReceiveData);

        #endregion GetMobileVersion

        #region Survey
        [OperationContract]
        [WebInvoke(Method = "POST",
      ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped,
      UriTemplate = "/COALBPSAppQuestionList"

     )]
        QuestionList COALBPSQuestionList(Stream ReceiveData);

        [OperationContract]
        [WebInvoke(Method = "POST",
      ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped,
      UriTemplate = "/COALBPSAppSubmitAnswer"

     )]
        UpdateAnswer COALBPSSubmitAnswer(Stream ReceiveData);

        #endregion

        #region Sayantan

        #region Response Interface

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSResponseRequest"

       )]
        RefundResponseRequestList COALBPSResponseRequest(Stream ReceiveData);

        #endregion

        #region Sms
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSResendSmsRequest"

       )]
        ResendSmsStat COALBPSResendSmsRequest(Stream ReceiveData);




        #endregion

        #endregion

        #region Suman
        #region Invoice History

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSInvoiceHistory"

       )]
        InvoiceHistoryList COALBPSInvoiceHistory(Stream ReceiveData);

        #endregion

        #region Payment History

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSPaymentHistory"

       )]
        PaymentHistoryList COALBPSPaymentHistory(Stream ReceiveData);

        #endregion
        #endregion

        #region Debojyoti

        #region BOOKING HISTORY
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppBookingHistory"
       )]
        BookingHistoryStatus COALBPSBookingHistory(Stream ReceiveData);
        #endregion

        #region FEEDBACK COMMUNICATION
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppFeedbackCommunication"
       )]
        FeedbackCommunicationStatus COALBPSFeedbackCommunication(Stream ReceiveData);
        #endregion

        #region ADD BACK
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppAddBack"
       )]
        AddBackReceive COALBPSAddBack(Stream ReceiveData);
        #endregion

        #region AppInfo
        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/COALBPSAppInfo"
       )]
        CustomerAppInfoReceive COALBPSAppInfo();
        #endregion
        #endregion

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.

    #region Customer Details data contract
    [DataContract]
    public class CustomerDetails
    {
        [DataMember]
        public string cust_identity { get; set; }
        [DataMember]
        public string mj_cust_code { get; set; }
        [DataMember]
        public string company_name { get; set; }
        [DataMember]
        public string cust_addr { get; set; }
        [DataMember]
        public string cmp_auc_id { get; set; }
        [DataMember]
        public string cmp_auc_pwd { get; set; }
        [DataMember]
        public string cust_zip { get; set; }
        [DataMember]
        public string cust_city_code { get; set; }
        [DataMember]
        public string cust_city { get; set; }
        [DataMember]
        public string cust_state_code { get; set; }
        [DataMember]
        public string cust_state { get; set; }
        [DataMember]
        public string cust_region { get; set; }
        [DataMember]
        public string cust_country_code { get; set; }
        [DataMember]
        public string cust_country { get; set; }
        [DataMember]
        public string cust_mobile1 { get; set; }
        [DataMember]
        public string cust_mobile2 { get; set; }
        [DataMember]
        public string cust_email { get; set; }
        [DataMember]
        public string cust_pan_no { get; set; }
        [DataMember]
        public string cust_shipping_addr { get; set; }
        [DataMember]
        public string cust_tisco_code { get; set; }
        [DataMember]
        public string cst_no { get; set; }
        [DataMember]
        public string tin_no { get; set; }
        [DataMember]
        public string GSTIN { get; set; }
        [DataMember]
        public string tisco_sap_code { get; set; }
        [DataMember]
        public string cust_mj_sap { get; set; }
        [DataMember]
        public string TaxId { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
        [DataMember]
        public string CategoryID { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string LocationID { get; set; }
        [DataMember]
        public string LocationName { get; set; }
        [DataMember]
        public string PinNo { get; set; }
        [DataMember]
        public string rescount { get; set; }

    }
    #endregion


    #region Customer Login data contract
    [DataContract]
    public class Login
    {

        [DataMember]
        public string SAPCode { get; set; }
        [DataMember]
        public string MobileNo { get; set; }

    }
    #endregion

    #region Customer login  with pin
    public class loginWithPin
    {
        [DataMember]
        public string SAPCode { get; set; }

        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public string PinNo { get; set; }
        [DataMember]
        public string DeviceID { get; set; }
        [DataMember]

        public string StatusCode { get; set; }
        [DataMember]

        public string Message { get; set; }

        [DataMember]

        public string rescount { get; set; }


    }
    #endregion Customer login  with pin

    #region Location and Product and Source list data contract
    [DataContract]
    public class SourceLocationList
    {

        [DataMember]
        public List<Source> SourceList { get; set; }
        [DataMember]
        public List<Location> LocationList { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }

    }
    [DataContract]
    public class ProductList
    {
        [DataMember]
        public List<Product> Product_List { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
    }
    [DataContract]
    public class Product
    {
        [DataMember]
        public string ProductID { get; set; }
        [DataMember]
        public string ProductName { get; set; }


    }
    [DataContract]
    public class ProductPriceList
    {
        [DataMember]
        public ProductPrice ProductPrice_List { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
    }
    [DataContract]
    public class ProductPrice
    {
        [DataMember]
        public string Rate { get; set; }
        [DataMember]
        public string ED { get; set; }
        [DataMember]
        public string TaxPercent { get; set; }
        [DataMember]
        public string Surcharge { get; set; }
        [DataMember]
        public string DO_Y_N { get; set; }
        [DataMember]
        public string GST_Y_N { get; set; }
        //[DataMember]
        //public string GSTStructure { get; set; }
        [DataMember]
        public string GST { get; set; }
        [DataMember]
        public string CESS { get; set; }
        [DataMember]
        public string TotalAmount { get; set; }
    }
    [DataContract]
    public class Location
    {
        [DataMember]
        public string LocationID { get; set; }
        [DataMember]
        public string LocationName { get; set; }

    }
    [DataContract]
    public class Source
    {
        [DataMember]
        public string SourceID { get; set; }
        [DataMember]
        public string SourceName { get; set; }

    }
    [DataContract]
    public class RecivedTax
    {
        [DataMember]
        public string TaxId { get; set; }
        [DataMember]
        public string SAPCode { get; set; }
    }
    [DataContract]
    public class RecivedProductRequest
    {
        [DataMember]
        public string SourceID { get; set; }
        [DataMember]
        public string LocationID { get; set; }
    }
    [DataContract]
    public class RecivedProductPriceRequest
    {
        [DataMember]
        public string SourceID { get; set; }
        [DataMember]
        public string LocationID { get; set; }
        [DataMember]
        public string ProductID { get; set; }
        [DataMember]
        public string CustID { get; set; }
    }

    #endregion

    #region Dashboard data contract
    [DataContract]
    public class Dashboard
    {

        [DataMember]
        public string DocValid { get; set; }
        [DataMember]
        public string DONumber { get; set; }
        [DataMember]
        public string Balance { get; set; }
        [DataMember]
        public string Quantity { get; set; }
        [DataMember]
        public string Rate { get; set; }
        [DataMember]
        public string ReconciledDate { get; set; }
        [DataMember]
        public string PermitLimit { get; set; }
        [DataMember]
        public string LicenseNo { get; set; }
        [DataMember]
        public string LicenseValidity { get; set; }
        [DataMember]
        public string LimitApplicable { get; set; }
        [DataMember]
        public string LicenseApplicable { get; set; }
        [DataMember]
        public string DoValidity { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string BasePrice { get; set; }
        [DataMember]
        public string BalanceAmt { get; set; }
        [DataMember]
        public string BalanceQty { get; set; }
        [DataMember]
        public string OnDateSalesQty { get; set; }
        [DataMember]
        public string MTDSalesQty { get; set; }
        [DataMember]
        public string YTDSalesQty { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }

        [DataMember]
        public string IsReverseCamAvailableNo { get; set; }//Added 09-06-2022


        [DataMember]
        public string BookingWindowStatus { get; set; }//Added 16-06-2022
        [DataMember]
        public List<Dashboard> DashboardList { get; set; }
    }

    [DataContract]
    public class DashboardStatus
    {

        [DataMember]
        public string DocValid { get; set; }
        [DataMember]
        public string DONumber { get; set; }
        [DataMember]
        public string Balance { get; set; }
        [DataMember]
        public string Quantity { get; set; }
        [DataMember]
        public string Rate { get; set; }
        [DataMember]
        public string ReconciledDate { get; set; }
        [DataMember]
        public string PermitLimit { get; set; }
        [DataMember]
        public string LicenseNo { get; set; }
        [DataMember]
        public string LicenseValidity { get; set; }
        [DataMember]
        public string LimitApplicable { get; set; }
        [DataMember]
        public string LicenseApplicable { get; set; }
        [DataMember]
        public string DoValidity { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string BasePrice { get; set; }
        [DataMember]
        public string BalanceAmt { get; set; }
        [DataMember]
        public string BalanceQty { get; set; }
        [DataMember]
        public string OnDateSalesQty { get; set; }
        [DataMember]
        public string MTDSalesQty { get; set; }
        [DataMember]
        public string YTDSalesQty { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }

        [DataMember]
        public string IsReverseCamAvailableNo { get; set; }//Added 09-06-2022


        [DataMember]
        public string BookingWindowStatus { get; set; }//Added 16-06-2022
        [DataMember]
        public List<Dashboard> DashboardList { get; set; }
    }

    [DataContract]
    public class DashboardRecive
    {
        [DataMember]
        public string SAPCode { get; set; }
        [DataMember]
        public string ProductID { get; set; }
        [DataMember]
        public string SourceID { get; set; }
        [DataMember]
        public string LocationID { get; set; }
    }
    #endregion

    #region Truck, State and Category contract
    [DataContract]
    public class CatStatTruc
    {

        [DataMember]
        public List<Category> CategoryList { get; set; }
        [DataMember]
        public List<State> StateList { get; set; }
        [DataMember]
        public List<Truck> TruckList { get; set; }
        [DataMember]
        public List<Capacity> CapacityList { get; set; }
        [DataMember]
        public List<DriverList> DriverList { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }


    }
    [DataContract]
    public class Category
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }

    }
    [DataContract]
    public class State
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }

    }
    [DataContract]
    public class Truck
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string TruckNo { get; set; }

    }
    [DataContract]
    public class Capacity
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string CapacityQty { get; set; }

    }

    [DataContract]
    public class CatStatTrucRecive
    {
        [DataMember]
        public string SAPCode { get; set; }

    }

    [DataContract]
    public class DriverList
    {
        [DataMember]
        public string DriverLicenscid { get; set; }
        [DataMember]
        public string Driver_Name { get; set; }
        [DataMember]
        public string Driving_LicenseNo { get; set; }
        [DataMember]
        public string Driver_MobileNo { get; set; }

    }
    #endregion

    #region Send Booking data contract
    [DataContract]
    public class Booking
    {

        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public string ReceiptNo { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }

    }
    [DataContract]
    public class BookingRecive
    {
        [DataMember]
        public string DONumber { get; set; }
        [DataMember]
        public string Quantity { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public string TruckNo { get; set; }
        [DataMember]
        public string StateId { get; set; }
        [DataMember]
        public string CategoryId { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string BookingDate { get; set; }
        [DataMember]
        public string Driving_LicenseNo { get; set; }
        [DataMember]
        public string IMEI_NO { get; set; }
        [DataMember]
        public string BookPinNo { get; set; }
        [DataMember]
        public string IsReverseCamAvailable { get; set; }
    }
    #endregion

    #region Booking Status contract
    [DataContract]
    public class BookingStatus
    {

        [DataMember]
        public List<Status> StatusList { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }

    }

    [DataContract]
    public class ApproveBookingListRecive
    {
        [DataMember]
        public string SAPCode { get; set; }
        [DataMember]
        public string ProductID { get; set; }
        [DataMember]
        public string LocationID { get; set; }
        [DataMember]
        public string SourceID { get; set; }
        public string BookingDate { get; set; }
        [DataMember]
        public string TruckNo { get; set; }
        [DataMember]
        public string BookingNo { get; set; }
        [DataMember]
        public DateTime ApprovalDate { get; set; }
        [DataMember]
        public string Changed_Trukno { get; set; }

    }

    [DataContract]
    public class Status
    {
        [DataMember]
        public string BookingDate { get; set; }
        [DataMember]
        public List<BookingDetails> BookingDetailsList { get; set; }

        [DataMember]
        public string TruckNo { get; set; }
        [DataMember]
        public string BookingNo { get; set; }
        [DataMember]
        public string ApprovalDate { get; set; }
        [DataMember]
        public string Changed_Trukno { get; set; }
        [DataMember]
        public string Quantity { get; set; }
        [DataMember]
        public string noOfChange { get; set; }
        [DataMember]
        public string TruckChangeRequestStatus { get; set; }
    }

    [DataContract]
    public class BookingDetails
    {
        [DataMember]
        public string BookingDate { get; set; }
        [DataMember]
        public string TruckNo { get; set; }
        [DataMember]
        public string Quantity { get; set; }
        [DataMember]
        public string ReceiptNo { get; set; }
        [DataMember]
        public string BookingStatus { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public string DONumber { get; set; }
        [DataMember]
        public string Flag { get; set; }
        [DataMember]
        public string BookingConfirmationID { get; set; }

        [DataMember]
        public string Driving_LicenseNo { get; set; }

        [DataMember]
        public string BookPinNo { get; set; }

        [DataMember]
        public string BookingID { get; set; }
    }

    [DataContract]
    public class BookingStatusRecive
    {
        [DataMember]
        public string SAPCode { get; set; }
        [DataMember]
        public string ProductID { get; set; }
        [DataMember]
        public string SourceID { get; set; }
        [DataMember]
        public string LocationID { get; set; }
    }
    #endregion

    #region Booking Cancel contract
    [DataContract]
    public class CancelBookingList
    {

        [DataMember]
        public List<BookingDetails> StatusList { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }

    }

    [DataContract]
    public class CancelBookingListRecive
    {
        [DataMember]
        public string SAPCode { get; set; }
        [DataMember]
        public string ProductID { get; set; }
        [DataMember]
        public string LocationID { get; set; }
        [DataMember]
        public string SourceID { get; set; }
    }
    [DataContract]
    public class CancelBooking
    {
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
    }

    [DataContract]
    public class CancelBookingRecive
    {
        [DataMember]
        public string SAPCode { get; set; }
        [DataMember]
        public string DONumber { get; set; }
        [DataMember]
        public string ReceiptNumber { get; set; }

    }
    #endregion

    #region Contact Link contract
    [DataContract]
    public class ContactLink
    {
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
    }

    [DataContract]
    public class ContactLinkRecive
    {
        [DataMember]
        public string SAPCode { get; set; }
        [DataMember]
        public string DONumber { get; set; }
        [DataMember]
        public string ReceiptNumber { get; set; }
        [DataMember]
        public string Query { get; set; }

    }
    #endregion

    #region Booking Extend contract
    [DataContract]
    public class ExtendBookingList
    {

        [DataMember]
        public List<BookingDetails> StatusList { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }

    }

    [DataContract]
    public class ExtendBookingListRecive
    {
        [DataMember]
        public string SAPCode { get; set; }
        [DataMember]
        public string ProductID { get; set; }
        [DataMember]
        public string LocationID { get; set; }
        [DataMember]
        public string SourceID { get; set; }
    }
    [DataContract]
    public class ExtendBooking
    {
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
    }

    [DataContract]
    public class ExtendBookingRecive
    {
        [DataMember]
        public string SAPCode { get; set; }
        [DataMember]
        public string DONumber { get; set; }
        [DataMember]
        public string ReceiptNumber { get; set; }

    }
    #endregion

    #region Booking Approve Status contract
    [DataContract]
    public class ApproveBookingStatus
    {

        [DataMember]
        public List<Status> ApproveStatusList { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }

    }
    #endregion


    #region Refund Request contract
    [DataContract]
    public class RefundRequest
    {
        [DataMember]
        public string MailStatus { get; set; }
        [DataMember]
        public string MailMessage { get; set; }
        [DataMember]
        public string ReceiptNumber { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
    }

    [DataContract]
    public class RefundRequestRecive
    {
        [DataMember]
        public string SAPCode { get; set; }
        [DataMember]
        public string DoNumber { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string BalanceAmount { get; set; }
        [DataMember]
        public string RefundAmount { get; set; }
        [DataMember]
        public string ReconciledDate { get; set; }
        [DataMember]
        public string CustomerMobile { get; set; }

    }
    #endregion

    #region OTP Generate contract
    [DataContract]
    public class OTP
    {

        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
    }

    [DataContract]
    public class OTPRecive
    {
        [DataMember]
        public string SAPCode { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public string DeviceID { get; set; }
        [DataMember]
        public string OTPCount { get; set; }
        [DataMember]
        public string OTP { get; set; }


    }
    #endregion

    #region GetNotification

    [DataContract]
    public class Notification
    {
        //[DataMember]
        //public string BookingTruckNo { get; set; }
        //[DataMember]
        //public string ReceiptNo { get; set; }

        [DataMember]
        public string Customer_Id { get; set; }

        [DataMember]
        public string FromDate { get; set; }
        [DataMember]
        public string ToDate { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public List<NotificationList> notificationList { get; set; }
    }

    [DataContract]
    public class NotificationList
    {

        [DataMember]
        public string Customer_Id { get; set; }
        [DataMember]
        public string Notification { get; set; }
        [DataMember]
        public string NotificationDate { get; set; }

    }
    #endregion GetNotification



    #region Send Truck Number Update data contract
    [DataContract]
    public class TruckUpdate
    {

        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Endtime { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }

    }
    [DataContract]
    public class TruckUpdateRecive
    {
        [DataMember]
        public string BookingID { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public string TruckNo { get; set; }

    }
    #endregion
    //Bijoy
    #region Change truck 
    [DataContract]
    public class ReceivedTruckChage
    {
        [DataMember]
        public string BookingID { get; set; }
        [DataMember]
        public string ChangedTrukno { get; set; }
        [DataMember]
        public string UserID { get; set; }
    }


    [DataContract]
    public class TruckChangeUpdate
    {
        [DataMember]
        public string TrailID { get; set; }
        [DataMember]
        public string BookingID { get; set; }
        [DataMember]
        public string receivedOn { get; set; }
        [DataMember]
        public string ExistingTruckno { get; set; }
        [DataMember]
        public string ChangedTrukno { get; set; }
        [DataMember]
        public string company_name { get; set; }
        [DataMember]
        public string UserID { get; set; }
        public string approveReject_status_CA { get; set; }
        [DataMember]
        public string approveReject_status_TSL { get; set; }
        [DataMember]
        public string RequestedBy { get; set; }

        [DataMember]
        public string ReqestedOn { get; set; }

        public string CA_ApproveReject_By { get; set; }

        [DataMember]
        public string CA_ApproveRejectOn { get; set; }

        public string TSL_ApproveRejectBy { get; set; }

        [DataMember]
        public string TSL_ApproveRejectOn { get; set; }

        [DataMember]
        public string NoOfChange { get; set; }


        [DataMember]
        public string StatusCode { get; set; }

        [DataMember]
        public string Msg { get; set; }
        [DataMember]
        public string Role { get; set; }

        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public string DeviceID { get; set; }

    }
    //Bijoy
    public class TruckChangeList
    {
        [DataMember]
        public List<TruckChangeUpdate> TruckChange_List { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
    }
    //Bijoy
    public class RecivedTrukchageRequest
    {
        [DataMember]
        public string UserID { get; set; }
        [DataMember]
        public string Role { get; set; }
        [DataMember]
        public string CustID { get; set; }
        [DataMember]
        public string ProdId { get; set; }
    }

    //Bijoy
    public class RecivedTrukchageApproveRequest
    {
        [DataMember]
        public string BookingID { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string truckno { get; set; }
        [DataMember]
        public string RoleFlag { get; set; }
        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public string Reason { get; set; }

    }

    #endregion

    #region BookPIN Update
    [DataContract]
    public class BookPinUpdate
    {

        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string BookPinNo { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }

        [DataMember]
        public string rescount { get; set; }
    }
    [DataContract]
    public class BookPinRecive
    {
        [DataMember]
        public string BookingID { get; set; }
        [DataMember]
        public string BookPinNo { get; set; }



    }

    #endregion BookPINUpdate
    #region GetTruckBookingNo data contract
    [DataContract]
    public class TruckBookingNo
    {
        //[DataMember]
        //public string BookingTruckNo { get; set; }
        //[DataMember]
        //public string ReceiptNo { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
        [DataMember]
        public List<BookingTruck> TruckBookingNoList { get; set; }
    }

    [DataContract]
    public class BookingTruck
    {
        [DataMember]
        public string BookingTruckNo { get; set; }
        [DataMember]
        public string ReceiptNo { get; set; }
    }

    [DataContract]
    public class TruckBookingNoRecive
    {
        [DataMember]
        public string SAPCode { get; set; }
        [DataMember]
        public string FromDate { get; set; }
        [DataMember]
        public string ToDate { get; set; }
        [DataMember]
        public string SourceID { get; set; }
        [DataMember]
        public string LocationID { get; set; }
        [DataMember]
        public string ProductID { get; set; }

    }


    [DataContract]
    public class VTSDetails
    {

        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
        [DataMember]
        public List<VTS> VtsDetailsList { get; set; }
    }
    [DataContract]
    public class VTS
    {
        [DataMember]
        public string A_ReceiptNo { get; set; }
        [DataMember]
        public string B_TPEntryTime { get; set; }
        [DataMember]
        public string C_TPExitTime { get; set; }
        [DataMember]
        public string D_PlantEntryTime { get; set; }
        [DataMember]
        public string E_EntryTime { get; set; }
        [DataMember]
        public string F_ExitTime { get; set; }
        [DataMember]
        public string G_PlantExitTime { get; set; }
        [DataMember]
        public string H_InvoicePreparedTime { get; set; }
        [DataMember]
        public string I_InvoiceNo { get; set; }
        [DataMember]
        public string J_InvoiceQty { get; set; }

    }
    [DataContract]
    public class VTSRecive
    {
        [DataMember]
        public string SAPCode { get; set; }

        [DataMember]
        public string ReceiptNo { get; set; }

    }


    #endregion




    #region Srijan
    #region  CategoryID
    [DataContract]
    public class CategoryID
    {
        [DataMember]
        public string SAPCode { get; set; }
        [DataMember]
        public string CatID { get; set; }

    }
    [DataContract]
    public class CategoryIDReceive
    {
        [DataMember]
        public string SAPCode { get; set; }
        //[DataMember]
        //public int CatID { get; set; }
    }
    #endregion
    #endregion


    #region Suman

    #region InvoiceHistory
    public class InvoiceHistoryRcv
    {
        [DataMember]
        public string ToDate { get; set; }
        [DataMember]
        public string FromDate { get; set; }
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class InvoiceHistoryList
    {

        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
        [DataMember]
        public List<InvoiceHst> Invoicehistory { get; set; }
    }

    public class InvoiceHst
    {
        [DataMember]
        public string InvoiceDate { get; set; }
        [DataMember]
        public List<InvoiceHistory> InvoiceHstList { get; set; }
    }

    public class InvoiceHistory
    {
        [DataMember]
        public string InvoiceID { get; set; }
        [DataMember]
        public string InvoiceNo { get; set; }
        [DataMember]
        public string DO { get; set; }
        [DataMember]
        public string Cust_ID { get; set; }
        [DataMember]
        public string Prod_ID { get; set; }
        [DataMember]
        public string LiftedQuantity { get; set; }
        [DataMember]
        public string BillAmount { get; set; }
        [DataMember]
        public string TruckNo { get; set; }
        [DataMember]
        public string InvoiceDate { get; set; }
        [DataMember]
        public string CreatedDate { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }
    #endregion


    #region PaymentHistory
    public class PaymentHistoryRcv
    {
        [DataMember]
        public string ToDate { get; set; }
        [DataMember]
        public string FromDate { get; set; }
        [DataMember]
        public string CustomerID { get; set; }
    }


    public class PaymentHistoryList
    {
        [DataMember]
        public List<PaymentHst> Paymenthistory { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
    }

    public class PaymentHst
    {
        [DataMember]
        public string PaymentDate { get; set; }
        [DataMember]
        public List<PaymentHistory> PaymentHstList { get; set; }
    }

    public class PaymentHistory
    {
        [DataMember]
        public string MR_ID { get; set; }
        [DataMember]
        public string DO_Number { get; set; }
        [DataMember]
        public string MR_Number { get; set; }
        [DataMember]
        public string MR_Date { get; set; }
        [DataMember]
        public string IsActive { get; set; }
        [DataMember]
        public string Amount { get; set; }
        [DataMember]
        public string upload_dt { get; set; }
        [DataMember]
        public string upload_by { get; set; }
        [DataMember]
        public string SGST { get; set; }
        [DataMember]
        public string CGST { get; set; }
        [DataMember]
        public string IGST { get; set; }
        [DataMember]
        public string CESS { get; set; }
        [DataMember]
        public string TotalTax { get; set; }
    }
    #endregion


    #endregion


    #region Sayantan

    #region Refund Respone
    [DataContract]
    public class RecivedRefundRequest
    {
        [DataMember]
        public string RefundRequestID { get; set; }
        [DataMember]
        public string FromDate { get; set; }
        [DataMember]
        public string ToDate { get; set; }
        [DataMember]
        public string CustomerSAPCode { get; set; }

    }
    [DataContract]
    public class ResponseRefund
    {
        [DataMember]
        public string RefundRequestID { get; set; }
        [DataMember]
        public string DoNumber { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string RequestDate { get; set; }
        [DataMember]
        public string ReconciledFormDate { get; set; }
        [DataMember]
        public string ReconciledToDate { get; set; }
        [DataMember]
        public string RefundResponse { get; set; }
        [DataMember]
        public string RefundResponseDate { get; set; }
        [DataMember]
        public string RefundAmount { get; set; }
    }


    [DataContract]
    public class ResponseRefundSort
    {
        [DataMember]
        public string RequestDate { get; set; }
        [DataMember]
        public List<ResponseRefund> RefundRequestSortList { get; set; }
    }


    [DataContract]
    public class RefundResponseRequestList
    {
        [DataMember]
        public List<ResponseRefundSort> RefundRequest_List { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }

    }


    #endregion

    #region Sms

    [DataContract]
    public class ResendSmsData
    {
        [DataMember]
        public string Custid { get; set; }
        [DataMember]
        public string BkdId { get; set; }
    }
    [DataContract]
    public class SmsOrderDetails
    {

        [DataMember]
        public string CustId { get; set; }
        [DataMember]
        public string ReceiptNo { get; set; }
        [DataMember]
        public string Qty { get; set; }
        [DataMember]
        public string BookingNo { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public string TruckNo { get; set; }
        [DataMember]
        public string MonthName { get; set; }
        [DataMember]
        public string Quantity { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string LocName { get; set; }
        [DataMember]
        public string SourceName { get; set; }
        [DataMember]
        public string Do { get; set; }
        [DataMember]
        public Int32 SmsCount { get; set; }

    }
    [DataContract]

    public class ResendSmsStat
    {
        [DataMember]
        public SmsOrderDetails SmsOrderDetails { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
        [DataMember]
        public Int32 msgSmsCnt { get; set; }
    }


    public class SMSVariable
    {
        [DataMember]
        public string variable_id { get; set; }
        [DataMember]
        public string Descrip { get; set; }
    }
    public class SMSTemplate
    {
        [DataMember]
        public string templateId { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string bulkSMS { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string gatewayTemplateId { get; set; }
    }
    #endregion



    #endregion

    #region Debojyoti
    #region Customer Contact Link contract
    [DataContract]
    public class CustomerContactLink
    {
        [DataMember]
        public string Receipt_Number { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
    }
    [DataContract]
    public class CustomerContactLinkRecive
    {
        [DataMember]
        public string SAPCode { get; set; }
        [DataMember]
        public string Query { get; set; }

    }

    #endregion
    #region MobileVersion
    [DataContract]
    public class MobileVersionRecive
    {
        [DataMember]
        public string NewVersion { get; set; }
        [DataMember]
        public List<MobileVersion> mobileVersionList { get; set; }
    }
    [DataContract]
    public class MobileVersion
    {

        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string OldVersion { get; set; }

        [DataMember]
        public string NewVersion { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public List<MobileVersion> mobileVersionList { get; set; }
    }



    #endregion MobileVersion
    #region Booking History data Contract
    [DataContract]
    public class BookingHistoryStatus
    {
        [DataMember]
        public List<BookingHistoryReceive> BookingHistory { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
    }
    [DataContract]
    public class BookingHistoryReceive
    {
        [DataMember]
        public string BookingDate { get; set; }
        [DataMember]
        public List<BookingHistoryList> BookingHistoryList { get; set; }
    }
    [DataContract]
    public class BookingHistoryList
    {
        [DataMember]
        public string Quantity { get; set; }
        [DataMember]
        public string TruckNo { get; set; }
        [DataMember]
        public string BookingRequest_Time { get; set; }
        [DataMember]
        public string BookingConfirmation_Number { get; set; }
        [DataMember]
        public string Confirmed_Time { get; set; }
        [DataMember]
        public string app_rej_status { get; set; }
        [DataMember]
        public string BookingDate { get; set; }

        [DataMember]
        public string BookPinNo { get; set; }

        [DataMember]
        public string BookingID { get; set; }
    }
    [DataContract]
    public class BookingHistoryRequest
    {
        [DataMember]
        public string CustID { get; set; }
        [DataMember]
        public string ProductID { get; set; }
        [DataMember]
        public string LocationID { get; set; }
        [DataMember]
        public string SourceID { get; set; }
        [DataMember]
        public string FromDate { get; set; }
        [DataMember]
        public string ToDate { get; set; }
    }
    #endregion

    #region FEEDBACK COMMUNICATION data Contract
    [DataContract]
    public class FeedbackCommunicationStatus
    {
        [DataMember]
        public List<FeedbackCommunicationReceive> FeedbackCommunication { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
    }
    [DataContract]
    public class FeedbackCommunicationReceive
    {
        [DataMember]
        public string CreatedDate { get; set; }
        [DataMember]
        public List<FeedbackCommunicationList> FeedbackCommunicationList { get; set; }
    }
    [DataContract]
    public class FeedbackCommunicationList
    {
        [DataMember]
        public string CustomerID { get; set; }
        [DataMember]
        public string Receipt_Number { get; set; }
        [DataMember]
        public string ContactQuery { get; set; }
        [DataMember]
        public string CreatedDate { get; set; }
        [DataMember]
        public string Response { get; set; }
        [DataMember]
        public string ResponseDateTime { get; set; }
    }
    [DataContract]
    public class FeedbackCommunicationRequest
    {
        [DataMember]
        public string CustID { get; set; }
        [DataMember]
        public string FromDate { get; set; }
        [DataMember]
        public string ToDate { get; set; }
        [DataMember]
        public string Receipt_Number { get; set; }
    }
    #endregion

    #region ADD BACK
    [DataContract]
    public class AddBackReceive
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
    }
    [DataContract]
    public class AddBackRequest
    {
        [DataMember]
        public string BookingID { get; set; }
    }
    #endregion

    #region AppInfo
    [DataContract]
    public class CustomerAppInfoReceive
    {
        [DataMember]
        public bool InfoStatus { get; set; }
        [DataMember]
        public string AppInfoHtml { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
    }
    #endregion

    #endregion
    #region Survey
    [DataContract]
    public class ReceivedQueston
    {
        [DataMember]
        public string CustID { get; set; }

        [DataMember]
        public string LocationID { get; set; }
        [DataMember]
        public string ProdID { get; set; }

    }
    [DataContract]
    public class Questions
    {
        [DataMember]
        public string QuestionID { get; set; }
        [DataMember]
        public string SurveyID { get; set; }
        [DataMember]
        public string Question { get; set; }


    }

    public class QuestionList
    {
        [DataMember]
        public string SurveyID { get; set; }
        [DataMember]
        public string SurveyName { get; set; }

        [DataMember]
        public List<Questions> Question_List { get; set; }
        [DataMember]
        public string IsDone { get; set; }
        [DataMember]
        public string NoOfSkip { get; set; }

        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
    }

    public class ReceivedAnswer
    {
        [DataMember]
        public string SurveyID { get; set; }
        [DataMember]
        public string QuestionID { get; set; }

        [DataMember]
        public string CustId { get; set; }
        [DataMember]
        public string Rating { get; set; }
        [DataMember]
        public string NoOfSkip { get; set; }

    }

    public class UpdateAnswer
    {

        [DataMember]
        public string SurveyID { get; set; }
        [DataMember]
        public string QuestionID { get; set; }

        [DataMember]
        public string CustId { get; set; }
        [DataMember]
        public string Rating { get; set; }

        [DataMember]
        public string Createddate { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }


    }

    public class UpdateComplain
    {

        [DataMember]
        public string ComplainID { get; set; }
        [DataMember]
        public string ComplainDetails { get; set; }

        [DataMember]
        public string TiscoCustCode { get; set; }
        [DataMember]
        public string HandleBy { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string ComplainDate { get; set; }
        [DataMember]
        public string ComplainCloseDate { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }


    }
    public class ReceivedComplain
    {
        [DataMember]
        public string ComplainDetails { get; set; }

        [DataMember]
        public string CustID { get; set; }

    }

    public class UpdateReply
    {

        [DataMember]
        public string ReplyID { get; set; }
        [DataMember]
        public string ComplainID { get; set; }

        [DataMember]
        public string ReplyDetails { get; set; }
        [DataMember]
        public string RepliedBy { get; set; }

        [DataMember]
        public string ReplyDate { get; set; }
        [DataMember]
        public string Msg { get; set; }
        [DataMember]
        public string StatusCode { get; set; }

    }

    public class ReceivedReply
    {
        [DataMember]
        public string ComplainID { get; set; }

        [DataMember]
        public string ReplyDetails { get; set; }
        [DataMember]
        public string RepliedBy { get; set; }

    }

    public class ComplainList
    {
       
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
        [DataMember]
        public List<UpdateComplain>Complain_List{ get; set; }
    }

    public class RcvdComplain
    {
        [DataMember]
        public string CustID { get; set; }



    }
    public class ReplyList
    {

        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
        [DataMember]
        public List<UpdateReply> Reply_List { get; set; }
    }
    public class RcvdReply
    {
        [DataMember]
        public string ComplainID { get; set; }

    }

    public class RcvdQtyPrm
    {
        [DataMember]
        public string slid { get; set; }
        [DataMember]
        public string DOno { get; set; }
        [DataMember]
        public string Quantity { get; set; }
        public string TiscoSapCode { get; set; }
        [DataMember]
        public string IMEI_NO { get; set; }
    }

    public class UpdateQty
    {
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Msg { get; set; }
       
      
    }
}


#endregion

