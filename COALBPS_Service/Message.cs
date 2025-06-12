using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COALBPS_Service
{
    public class Message
    {

        #region Generic Success Message
        public static string SuccessMsg = "Success";
        public static string SuccesCode = "001";
        #endregion

        #region Generic Exception Code
        public static string ExceptionCode = "000";
        #endregion


        #region login Error
        public static string LoginErrorMsg = "Galat Cust Id or Mobile Number!!";
       // public static string LoginErrorPINMsg = "Galat Cust ID/ Mobile No/ PIN. Kripya sahi jankari dalein!";
        public static string LoginErrorPINMsg = "Galat PIN. Kripya sahi jankari dalein!";
        public static string LoginErrorCode = "002";
        public static string LoginPinErrorCode = "005";
        public static string ExistPinErrorCode = "007";
        public static string PINExistSuccessMsg = "PIN pahale se maujood";
        public static string PINCreatedMsg = "PIN created Successfully!";
        public static string PINUpdateMsg = "PIN Updated Successfully!";
        public static string PINUpdateCode = "009";



        #endregion

        #region Location and Product Error
        public static string ProductErrorMsg = "Product table contains null value!!";
        public static string ProductErrorCode = "003";
        public static string LocationErrorMsg = "Location table contains null value!!";
        public static string locationErrorCode = "004";
        #endregion

        #region Dash Board Error
        public static string DashBoardErrorMsg = "Dash Board SP Return Null value!!";
        public static string DashBoardErrorCode = "005";
        #endregion

        #region Truck, State and Category Error
        public static string TruckErrorMsg = "Truck SP return null value!!";
        public static string TruckErrorCode = "006";
        public static string SateErrorMsg = "State(Reference Table) table contains null value!!";
        public static string StateErrorCode = "007";
        public static string CategoryErrorMsg = "Category(KYCcategory Table) table contains null value!!";
        public static string CategoryErrorCode = "008";
        public static string CapacityErrorMsg = "Capacity(Table) table contains null value!!";
        public static string CapacityErrorCode = "032";

        public static string DriverErrorMsg = "Driver(Table) table contains null value!!";
        public static string DriverErrorCode = "033";
        //Bijoy
        public static string TruckhangeErrorMessage = "This number cannot be changed!";


        #endregion

        #region Send Booking Error
        public static string BookingErrorMsg = "Booking SP Return Null value!!";
        public static string BookingErrorCode = "009";
        #endregion

        #region Cancel Booking Error
        public static string CancelBookingErrorMsg = "Some Internal problem!!";
        public static string CancelBookingErrorCode = "010";
        #endregion

        #region BookingPinUpdate Arghya 31-05-2022
        public static string BookingPINUpdateMsg = "Booking Pin Updated Successfully!!";
        public static string BookingPINUpdateCode = "099";

        public static string BookingPINExistMsg = "Can't Update Booking Pin !!";
        public static string BookingPinExistCode = "091";

        public static string BookingPinErrorMsg = "Booking SP Return Null value!!";
        public static string BookingPinErrorCode = "034";
        #endregion

        #region MobileVersionUpdate
        public static string MobileVersionUpdateMsg = "Mobile Version Updated Successfully!!";
        public static string MobileVersionUpdateCode = "M99";

        public static string MobileVersionErrorMsg = "Mobile Version Return Null value!!";
        public static string MobileVersionErrorCode = "M34";
        #endregion MobileVersionUpdate

        #region Extend Booking Error
        public static string ExtendBookingErrorMsg = "Some Internal problem!!";
        public static string ExtendBookingErrorCode = "016";
        public static string ExtendBookingTruckEnggCode = "017";
        #endregion

        #region OTP Error
        public static string OTPErrorMsg = "Some Internal problem!!";
        public static string OTPErrorCode = "011";
        public static string OTPInvalidMsg = "OTP does not matched!!";
        public static string OTPInvalidCode = "012";
        public static string OTPTimeOutMsg = "Please regenrate OTP !!";
        public static string OTPTimeOutCode = "013";
        public static string OTPSuccessMsg = "OTP Send Successfully !!";
        public static string OTPCountMsg = "OTP Count can't be null or empty!!";
        public static string OTPCountCode = "014";
        public static string OTPMsg = "OTP can't be null or empty!!";
        public static string OTPCode = "015";

        #endregion

        #region notificationShow
        public static string notificationShowErrorMsg = "There is no notification!!";
        public static string notificationShowCode = "033";
        #endregion notificationShow

        #region Suman
        #region Invoice History
        public static string InvoiceHistErrorMsg = "Invoice SP Return Null value!!";
        public static string InvoiceHistErrorCode = "018";
        public static string InvoiceHistCheckToDateMsg = "To Date Cannot be null or empty";
        public static string InvoiceHistCheckToDateCode = "019";
        public static string InvoiceHistCheckYesDateMsg = "To Date has to be less than today.";
        public static string InvoiceHistCheckYesDateCode = "020";
        public static string InvoiceHistCheckFrmDateMsg = "From Date Cannot be null or empty";
        public static string InvoiceHistCheckFrmDateCode = "021";
        public static string InvoiceHistCustIDMsg = "Customer ID Cannot be null or empty";
        public static string InvoiceHistCustIDCode = "022";
        public static string InvoiceHistValidDtRngMsg = "From date cannot be before To date";
        public static string InvoiceHistValidDtRngCode = "023";
        public static string InvoiceHistDtRngMsg = "Date range has to be within 7 days .";
        public static string InvoiceHistDtRngCode = "024";
        #endregion

        #region Payment History
        public static string PaymentHistErrorMsg = "Payment SP Return Null value!!";
        public static string PaymentHistErrorCode = "025";
        public static string PaymentHistCheckToDateMsg = "To Date Cannot be null or empty";
        public static string PaymentHistCheckToDateCode = "026";
        public static string PaymentHistCheckYesDateMsg = "To Date has to be less than today.";
        public static string PaymentHistCheckYesDateCode = "027";
        public static string PaymentHistCheckFrmDateMsg = "From Date Cannot be null or empty";
        public static string PaymentHistCheckFrmDateCode = "028";
        public static string PaymentHistCustIDMsg = "Customer ID Cannot be null or empty";
        public static string PaymentHistCustIDCode = "029";
        public static string PaymentHistValidDtRngMsg = "From date cannot be before To date";
        public static string PaymentHistValidDtRngCode = "030";
        public static string PaymentHistDtRngMsg = "Date range has to be within 7 days .";
        public static string PaymentHistDtRngCode = "031";
        #endregion
        #endregion

        #region sayantan
        public static string ResponseErrorMsg = "Some Internal problem!!";
        public static string ResponseErrorCode = "201";
        public static string ResponseCustIdErrorMsg = "Please Insert Customer Id";
        public static string ResponseCustIdErrorCode = "202";
        public static string ResponseDateRangeErrorMsg = "Please Insert Valid Date Range";
        public static string ResponseDateRangeErrorCode = "203";
        public static string ResponseWrongResponseID = "Please Insert Valid Reference Number";
        public static string ResponseWrongResponseIDErrorCode = "206";
        public static string ResendSmsCustIdErrorMsg = "Please Insert Customer Id";
        public static string ResendSmsCustIdErrorCode = "204";
        public static string ResendSmsBkdIdErrorMsg = "Please Insert Booking Id";
        public static string ResendSmsBkdIdErrorCode = "205";

        #endregion

        #region Debojyoti
            #region Booking History Error
            public static string BookingHistoryErrorMsg = "Booking History SP Returns Null value!!";
            public static string BookingHistoryErrorCode = "101";
            #endregion

            #region FEEDBACK CONFIRMATION NUMBER
            public static string FeedbackConfirmationErrorMsg = "Feedback Confirmation SP Returns Null value!!";
            public static string FeedbackConfirmationErrorCode = "102";
            public static string FeedbackWrongResponseID = "Please Insert Valid Reference Number";
            public static string FeedbackWrongResponseIDErrorCode = "104";
            #endregion

            #region ADD BACK
            public static string AddBackErrorMsg = "Add Back SP Returns Null value!!";
            public static string AddBackErrorCode = "103";
            #endregion

            #region App Info
            public static string AppInfoErrorMsg = "App Info SP Returns Null value!!";
            public static string AppInfoErrorCode = "105";
            #endregion
        #endregion
    }
}