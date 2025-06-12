using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace COALBPS_Service
{
    public class DAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);
        public DataTable Login(Login lg, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_Login", con);
                // adp.SelectCommand.CommandText = "SPAPP_Login";
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SAPCode", lg.SAPCode);
                adp.SelectCommand.Parameters.AddWithValue("MobileNo", lg.MobileNo);
                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        //*************************Arghya***********************//


        public DataTable Login1(loginWithPin lg, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_Login", con);
                // adp.SelectCommand.CommandText = "SPAPP_Login";
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SAPCode", lg.SAPCode);
                adp.SelectCommand.Parameters.AddWithValue("MobileNo", lg.MobileNo);
                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }




        public DataTable LoginWithPin(loginWithPin lg, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_LoginWithPin", con);
                // adp.SelectCommand.CommandText = "SPAPP_Login";
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SAPCode", lg.SAPCode);
                adp.SelectCommand.Parameters.AddWithValue("MobileNo", lg.MobileNo);
                adp.SelectCommand.Parameters.AddWithValue("PinNo", lg.PinNo);
                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }


        public DataTable ValidatePIN(loginWithPin or, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_PinValidate", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SAPCode", or.SAPCode);
                adp.SelectCommand.Parameters.AddWithValue("MobNo", or.MobileNo);
                adp.SelectCommand.Parameters.AddWithValue("DeviceId", or.DeviceID);

                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }


        public DataTable LoginCheckExistPIN(loginWithPin lg, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_ChechExistPin", con);
                // adp.SelectCommand.CommandText = "SPAPP_Login";
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SAPCode", lg.SAPCode);
                adp.SelectCommand.Parameters.AddWithValue("MobileNo", lg.MobileNo);
                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }


        public DataTable LoginCreatePIN(loginWithPin lg, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_CreatePin", con);
                // adp.SelectCommand.CommandText = "SPAPP_Login";
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SAPCode", lg.SAPCode);
                adp.SelectCommand.Parameters.AddWithValue("MobileNo", lg.MobileNo);
                adp.SelectCommand.Parameters.AddWithValue("PinNo", lg.PinNo);
                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }



        public DataTable GetNotification(Notification notify, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_CoalNotification", con);
                // adp.SelectCommand.CommandText = "SPAPP_Login";
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@id", notify.Customer_Id);
                adp.SelectCommand.Parameters.AddWithValue("@fromDate", notify.FromDate);
                adp.SelectCommand.Parameters.AddWithValue("@toDate", notify.ToDate);
                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }



        //*************************Arghya***********************//



        public DataTable ProductList(string SourceID, string LocID, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_Productslist", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SourceID", SourceID);
                adp.SelectCommand.Parameters.AddWithValue("LocID", LocID);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        public DataTable ProductPrice(string SourceID, string LocID, string ProdID, string CustID, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_ProductPricelist", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SourceID", SourceID);
                adp.SelectCommand.Parameters.AddWithValue("LocID", LocID);
                adp.SelectCommand.Parameters.AddWithValue("ProdID", ProdID);
                adp.SelectCommand.Parameters.AddWithValue("CustID", CustID);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        public DataTable SourceList(string CustID, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_Sourcelist", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("CustID", CustID);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        public DataTable LocationList(string CustID, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_Locationlist", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("Cust_ID", CustID);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        public DataTable DashBoard(DashboardRecive dbr, out string message)
        {
            DataTable dt = new DataTable();

            message = "";
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_LatestDashBoard", con);
                // adp.SelectCommand.CommandText = "SPAPP_Login";
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SourceID", dbr.SourceID);
                adp.SelectCommand.Parameters.AddWithValue("LocID", dbr.LocationID);
                adp.SelectCommand.Parameters.AddWithValue("ProdID", dbr.ProductID);
                adp.SelectCommand.Parameters.AddWithValue("CustID", dbr.SAPCode);
                //  adp.Fill(dt);

                DataSet dataSet = new DataSet();
                adp.Fill(dataSet);
                if (dataSet.Tables.Count > 0)
                    dt1 = dataSet.Tables[0];
                if (dataSet.Tables.Count > 1)
                    dt2 = dataSet.Tables[1];
            }
            catch (Exception ex)
            {
                dt1 = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt1;
        }


        public DataTable DashBoardStatus(DashboardRecive dbr, out string message)
        {
            DataTable dt = new DataTable();

            message = "";
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_LatestDashBoardStatus", con);
                // adp.SelectCommand.CommandText = "SPAPP_Login";
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SourceID", dbr.SourceID);
                adp.SelectCommand.Parameters.AddWithValue("LocID", dbr.LocationID);
                adp.SelectCommand.Parameters.AddWithValue("ProdID", dbr.ProductID);
                adp.SelectCommand.Parameters.AddWithValue("CustID", dbr.SAPCode);
                //  adp.Fill(dt);

                DataSet dataSet = new DataSet();
                adp.Fill(dataSet);
                if (dataSet.Tables.Count > 0)
                    dt1 = dataSet.Tables[0];
                if (dataSet.Tables.Count > 1)
                    dt2 = dataSet.Tables[1];
            }
            catch (Exception ex)
            {
                dt1 = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt1;
        }
        public DataTable DashBoardFooter(DashboardRecive dbr, out string message)
        {
            DataTable dt = new DataTable();

            message = "";
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_LatestDashBoard", con);
                // adp.SelectCommand.CommandText = "SPAPP_Login";
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SourceID", dbr.SourceID);
                adp.SelectCommand.Parameters.AddWithValue("LocID", dbr.LocationID);
                adp.SelectCommand.Parameters.AddWithValue("ProdID", dbr.ProductID);
                adp.SelectCommand.Parameters.AddWithValue("CustID", dbr.SAPCode);
                //  adp.Fill(dt);

                DataSet dataSet = new DataSet();
                adp.Fill(dataSet);
                if (dataSet.Tables.Count > 0)
                    dt1 = dataSet.Tables[0];
                if (dataSet.Tables.Count > 1)
                    dt2 = dataSet.Tables[1];

            }
            catch (Exception ex)
            {
                dt2 = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt2;
            }
            return dt2;
        }

        public DataTable GettruckBookingNo(TruckBookingNoRecive tbnor, out string message)
        {
            message = "";
            DataTable dt = new DataTable();

            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_GetBookingTruckNO", con);
                // adp.SelectCommand.CommandText = "SPAPP_Login";
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SAPCode", tbnor.SAPCode);
                adp.SelectCommand.Parameters.AddWithValue("FromDate", tbnor.FromDate);
                adp.SelectCommand.Parameters.AddWithValue("ToDate", tbnor.ToDate);
                adp.SelectCommand.Parameters.AddWithValue("SourceID", tbnor.SourceID);
                adp.SelectCommand.Parameters.AddWithValue("LocID", tbnor.LocationID);
                adp.SelectCommand.Parameters.AddWithValue("ProdID", tbnor.ProductID);

                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }
            return dt;
        }

        public DataTable GetVtsDetails(VTSRecive Vtsr, out string message)
        {
            DataTable dt = new DataTable();
            message = "";
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_GetVTSDetails", con);
                // adp.SelectCommand.CommandText = "SPAPP_Login";
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SAPCode", Vtsr.SAPCode);
                adp.SelectCommand.Parameters.AddWithValue("ReceiptNo", Vtsr.ReceiptNo);

                adp.Fill(dt);
                // DataSet dataSet = new DataSet();
                // adp.Fill(dataSet);
                //// if (dataSet.Tables.Count > 0)
                //     dt = dataSet.Tables[0];

            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }
            return dt;
        }

        public DataTable TruckList(string SAPCode, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_Trucklist", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SAPCode", SAPCode);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        //**********Arghya******************//
        public DataTable OutStationTruckList(out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_OutStationTrucklist", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;

                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        //***********Arghya****************//

        public DataTable StateList(out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_Statelist", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        public DataTable CategoryList(out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_Categorylist", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        //**************************Arghya**********************************//
        public DataTable DriverList(out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_Driverlist", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        //********************************Arghya*********************//

        public DataTable Booking(BookingRecive br, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                string receiptNo = "RCT/" + DateTime.Now.Year.ToString() + "-" + (DateTime.Now.Year + 1).ToString().Substring(2, 2) + "/";
                SqlDataAdapter adp = new SqlDataAdapter("SPCOAL_ValidateBookingForAPINew_V4", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("mobile", br.MobileNo);
                adp.SelectCommand.Parameters.AddWithValue("smsContent", "TSLCOAL BOOK " + br.DONumber + "," + br.TruckNo + "," + br.Quantity + "," + br.Driving_LicenseNo + "," + br.BookPinNo + "," + br.IMEI_NO);
                adp.SelectCommand.Parameters.AddWithValue("mobileoperator", "MOBILEAPP");
                adp.SelectCommand.Parameters.AddWithValue("ReceiptNo", receiptNo);
                adp.SelectCommand.Parameters.AddWithValue("IsReverseCamAvailable", br.IsReverseCamAvailable);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        public DataTable UpdateTruck(TruckUpdateRecive br, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter adp = new SqlDataAdapter("SPCOAL_UpdateTruckNo_2Tier", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("MobileNo", br.MobileNo);
                adp.SelectCommand.Parameters.AddWithValue("SMS", "TSLCOAL BLTD " + br.BookingID + "," + br.TruckNo);
                adp.SelectCommand.Parameters.AddWithValue("Receiver", "MOBILEAPP");
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        //Bijoy
        public DataTable ChageTruck(TruckChangeUpdate br, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter adp = new SqlDataAdapter("SP_ValidateAndUpdateFOrCA_TruckChange", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("slid", br.BookingID);
                adp.SelectCommand.Parameters.AddWithValue("TrukNo", br.ChangedTrukno);
                adp.SelectCommand.Parameters.AddWithValue("UserID", br.UserID);
                adp.SelectCommand.Parameters.AddWithValue("DeviceID", br.DeviceID);

                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        //Bijoy
        public DataTable ChageTruckList(string UserID, string Role, string CustID, string ProdId, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter adp = new SqlDataAdapter("SP_GetTruckChageListForApproval", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("UserID", UserID);
                adp.SelectCommand.Parameters.AddWithValue("RoleFlag", Role);
                adp.SelectCommand.Parameters.AddWithValue("CustID", CustID);
                adp.SelectCommand.Parameters.AddWithValue("ProdID", ProdId);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        //Bijoy
        public DataTable ApproveTrukChange(RecivedTrukchageApproveRequest br, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter adp = new SqlDataAdapter("SP_ApproveByCA_TSL", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("BookingID", br.BookingID);
                adp.SelectCommand.Parameters.AddWithValue("Status", br.Status);
                adp.SelectCommand.Parameters.AddWithValue("truckno", br.truckno);
                adp.SelectCommand.Parameters.AddWithValue("RoleFlag", br.RoleFlag);
                adp.SelectCommand.Parameters.AddWithValue("UserID", br.UserID);
                adp.SelectCommand.Parameters.AddWithValue("Reason", br.UserID);

                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        public DataTable UpdateBookPin(BookPinRecive br, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter adp = new SqlDataAdapter("SPCOAL_UpdateBookPinNo", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("BookPinNo", br.BookPinNo);
                adp.SelectCommand.Parameters.AddWithValue("BookingID", br.BookingID);

                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        public DataTable BookingStatus(BookingStatusRecive bsr, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                //SqlDataAdapter adp = new SqlDataAdapter("SPAPP_BookingStatus", con);
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_BookingStatus_V3", con);

                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SAPCode", bsr.SAPCode);
                adp.SelectCommand.Parameters.AddWithValue("ProductID", bsr.ProductID);
                adp.SelectCommand.Parameters.AddWithValue("SourceID", bsr.SourceID);
                adp.SelectCommand.Parameters.AddWithValue("LocID", bsr.LocationID);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        #region Booking Approve status
        public DataTable ReciveApproveBookingList(ApproveBookingListRecive cblr, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("upGetApprovedBookingStatus", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("CustID", cblr.SAPCode);
                adp.SelectCommand.Parameters.AddWithValue("ProdID", cblr.ProductID);
                adp.SelectCommand.Parameters.AddWithValue("LocID", cblr.LocationID);
                adp.SelectCommand.Parameters.AddWithValue("SourceID", cblr.SourceID);
                adp.SelectCommand.Parameters.AddWithValue("Status", "Approved");
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        #endregion

        #region Booking Confirm Status
        public DataTable ReciveConfirmBookingList(ApproveBookingListRecive cblr, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("GetBookingOrderIds", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("CustID", cblr.SAPCode);
                //adp.SelectCommand.Parameters.AddWithValue("ProdID", cblr.ProductID);
                //adp.SelectCommand.Parameters.AddWithValue("LocID", cblr.LocationID);
                //adp.SelectCommand.Parameters.AddWithValue("SourceID", cblr.SourceID);
                //adp.SelectCommand.Parameters.AddWithValue("Status", "Approved");
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        #endregion
        public DataTable ReciveCancelBookingList(CancelBookingListRecive cblr, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_BookingStatusList", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("CustID", cblr.SAPCode);
                adp.SelectCommand.Parameters.AddWithValue("ProdID", cblr.ProductID);
                adp.SelectCommand.Parameters.AddWithValue("LocID", cblr.LocationID);
                adp.SelectCommand.Parameters.AddWithValue("SourceID", cblr.SourceID);
                adp.SelectCommand.Parameters.AddWithValue("Status", "Cancel");
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        public int ReciveBookingData(CancelBookingRecive cbr, out string message)
        {
            message = "";
            int returnval;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SPAPP_CancelBooking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("SAPCode", cbr.SAPCode);
                cmd.Parameters.AddWithValue("DONO", cbr.DONumber);
                cmd.Parameters.AddWithValue("ReceiptNo", cbr.ReceiptNumber);
                returnval = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                returnval = 0;
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return returnval;
            }

            return returnval;
        }

        public int ReciveContactData(ContactLinkRecive clr, out string message)
        {
            message = "";
            int returnval;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SPAPP_CustomerContact", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("SAPCode", clr.SAPCode);
                cmd.Parameters.AddWithValue("DONO", clr.DONumber);
                cmd.Parameters.AddWithValue("ReceiptNo", clr.ReceiptNumber);
                cmd.Parameters.AddWithValue("Query", clr.Query);
                returnval = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                returnval = 0;
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return returnval;
            }

            return returnval;
        }

        public DataTable ReciveExtendBookingList(ExtendBookingListRecive cblr, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_BookingStatusList", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("CustID", cblr.SAPCode);
                adp.SelectCommand.Parameters.AddWithValue("ProdID", cblr.ProductID);
                adp.SelectCommand.Parameters.AddWithValue("LocID", cblr.LocationID);
                adp.SelectCommand.Parameters.AddWithValue("SourceID", cblr.SourceID);
                adp.SelectCommand.Parameters.AddWithValue("Status", "Extend");
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        public DataTable ReciveExtendBookingData(ExtendBookingRecive cbr, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_ExtendBooking", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SAPCode", cbr.SAPCode);
                adp.SelectCommand.Parameters.AddWithValue("DONO", cbr.DONumber);
                adp.SelectCommand.Parameters.AddWithValue("ReceiptNo", cbr.ReceiptNumber);
                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }


        public DataTable ReciveRefundRequestData(RefundRequestRecive rrr, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_RefundRequest", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SAPCode", rrr.SAPCode);
                adp.SelectCommand.Parameters.AddWithValue("DoNumber", rrr.DoNumber);
                adp.SelectCommand.Parameters.AddWithValue("CustomerName", rrr.CustomerName);
                adp.SelectCommand.Parameters.AddWithValue("BalanceAmount", rrr.BalanceAmount);
                adp.SelectCommand.Parameters.AddWithValue("RefundAmount", rrr.RefundAmount);
                adp.SelectCommand.Parameters.AddWithValue("ReconciledDate", string.IsNullOrWhiteSpace(rrr.ReconciledDate) ? "" : rrr.ReconciledDate);
                adp.SelectCommand.Parameters.AddWithValue("CustomerMobile", rrr.CustomerMobile);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        public DataTable ValidateOTP(OTPRecive or, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_OTPGenerationandValidate", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("SAPCode", or.SAPCode);
                adp.SelectCommand.Parameters.AddWithValue("MobNo", or.MobileNo);
                adp.SelectCommand.Parameters.AddWithValue("DeviceId", or.DeviceID);
                adp.SelectCommand.Parameters.AddWithValue("Count", Convert.ToInt32(or.OTPCount));
                adp.SelectCommand.Parameters.AddWithValue("OTPCode", string.IsNullOrWhiteSpace(or.OTP) ? "" : or.OTP);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        #region Srijan
        public DataTable getCatID(CategoryIDReceive catIDrec, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_getCategoryID", con);
                // adp.SelectCommand.CommandText = "SPAPP_Login";
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;

                adp.SelectCommand.Parameters.AddWithValue("SAPCode", catIDrec.SAPCode);
                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        #endregion

        #region  suman
        #region Invoice history
        public DataTable doInvoiceHistory(InvoiceHistoryRcv br, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter adp = new SqlDataAdapter("[SPCOAL_doInvoiceHistory]", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("CustomerID", br.CustomerID);
                adp.SelectCommand.Parameters.AddWithValue("Todate", br.ToDate);
                adp.SelectCommand.Parameters.AddWithValue("FromDate", br.FromDate);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        #endregion

        #region Payment history
        public DataTable doPaymentHistory(PaymentHistoryRcv br, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter adp = new SqlDataAdapter("[SPCOAL_doPaymentHistory]", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("CustomerID", br.CustomerID);
                adp.SelectCommand.Parameters.AddWithValue("Todate", br.ToDate);
                adp.SelectCommand.Parameters.AddWithValue("FromDate", br.FromDate);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        #endregion

        public DataTable CapacityList(CatStatTrucRecive cstr, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPCOAL_Capacitylist", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        #endregion

        #region Sayantan

        public DataTable ResponseRequestData(RecivedRefundRequest rrr, out string message)
        {
            string result = null;
            message = "";
            DataTable dt = new DataTable();
            try
            {


                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_GetRefundReponse", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("FromDt", rrr.FromDate);
                adp.SelectCommand.Parameters.AddWithValue("ToDt", rrr.ToDate);
                adp.SelectCommand.Parameters.AddWithValue("ReqId", rrr.RefundRequestID);
                adp.SelectCommand.Parameters.AddWithValue("CustId", rrr.CustomerSAPCode);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        public DataTable ResponseResendSmsData(ResendSmsData rsd, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_GetResendSmsDet", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("BkdId", rsd.BkdId);
                adp.SelectCommand.Parameters.AddWithValue("CustId", rsd.Custid);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }


        public DataTable GetSmsTemplate(string rrr, out string message)
        {
            string result = null;
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPCOAL_GetTemplateDetails", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("templateId", rrr);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        public DataTable GetSmsDescribe(string rrr, out string message)
        {
            string result = null;
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_GetResendSMSVariables", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }



        public DataTable GetSmsMonthName(out string message)
        {
            string result = null;
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SELECT DATENAME(MONTH, GETDATE())", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        public DataTable GetSmsCount(string ReceiptNo, out string message)
        {
            string result = null;
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPAPP_GetSmsCount", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("RectNo", ReceiptNo);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        public DataTable GetSmsQtyLimit(string doNo, out string message)
        {
            string result = null;
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SELECT dbo.fnGetCustomerCurrent_Quota(" + doNo + ")", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }


        public DataTable GetSmsVarList(string rrr, out string message)
        {
            string result = null;
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPCOAL_GetVariableList", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("templateId", rrr);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        #endregion

        #region Debojyoti
        public string ReciveCustomerContactData(CustomerContactLinkRecive clr, out string message)
        {
            message = "";
            //int returnval;
            string ReturnReceipt_Number;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SPAPP_CustomerContactData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("SAPCode", clr.SAPCode);
                cmd.Parameters.AddWithValue("Query", clr.Query);
                //returnval = cmd.ExecuteNonQuery();
                //ReturnReceipt_Number = JsonConvert.SerializeObject(cmd.ExecuteScalar());
                ReturnReceipt_Number = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                //returnval = 0;
                ReturnReceipt_Number = "0";
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return ReturnReceipt_Number;
            }
            //return returnval;
            return ReturnReceipt_Number;
        }
        public DataTable BookingHistory(BookingHistoryRequest bh, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SP_BookingHistory", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("CustID", bh.CustID);
                adp.SelectCommand.Parameters.AddWithValue("ProdID", bh.ProductID);
                adp.SelectCommand.Parameters.AddWithValue("SourceID", bh.SourceID);
                adp.SelectCommand.Parameters.AddWithValue("LocID", bh.LocationID);
                adp.SelectCommand.Parameters.AddWithValue("FromDate", bh.FromDate);
                adp.SelectCommand.Parameters.AddWithValue("ToDate", bh.ToDate);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }
            return dt;
        }

        public DataTable FeedbackCommunication(FeedbackCommunicationRequest fc, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("sp_FeedbackCommunication", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("CustID", fc.CustID);

                if (string.IsNullOrWhiteSpace(fc.FromDate))
                    adp.SelectCommand.Parameters.AddWithValue("FromDate", fc.FromDate).Value = DBNull.Value;
                else
                    adp.SelectCommand.Parameters.AddWithValue("FromDate", fc.FromDate);

                if (string.IsNullOrWhiteSpace(fc.ToDate))
                    adp.SelectCommand.Parameters.AddWithValue("ToDate", fc.ToDate).Value = DBNull.Value;
                else
                    adp.SelectCommand.Parameters.AddWithValue("ToDate", fc.ToDate);

                if (string.IsNullOrWhiteSpace(fc.Receipt_Number))
                    adp.SelectCommand.Parameters.AddWithValue("Receipt_Number", fc.Receipt_Number).Value = DBNull.Value;
                else
                    adp.SelectCommand.Parameters.AddWithValue("Receipt_Number", fc.Receipt_Number);

                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }
            return dt;
        }

        public string AddBack(AddBackRequest adb, out string message)
        {
            message = "";
            string ReturnMessage;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SPAPP_AddBack", con);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("BookingID", adb.BookingID);
                ReturnMessage = Convert.ToString(cmd.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                ReturnMessage = "0";
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return ReturnMessage;
            }
            return ReturnMessage;
        }

        public string AppInfo(out string message)
        {
            message = "";
            string ReturnHtml;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SPAPP_MobileAppInfo", con);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("BookingID", adb.BookingID);
                ReturnHtml = Convert.ToString(cmd.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                ReturnHtml = "0";
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return ReturnHtml;
            }
            return ReturnHtml;
        }
        #endregion

        #region MobileVersion

        public DataTable UpdateMobileVersion(MobileVersionRecive lg, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPCOAL_UpdateMobVersion", con);
                // adp.SelectCommand.CommandText = "SPAPP_Login";
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("mobNewVersion", lg.NewVersion);

                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        public DataTable GetMobileVersion(MobileVersion lg)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SPCOAL_GetMobVersion", con);
                // adp.SelectCommand.CommandText = "SPAPP_Login";
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;


                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                dt = new DataTable();
                //message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }



        #endregion MobileVersion

        #region Surevey
        public DataTable GetQuestions(ReceivedQueston rq, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            if (rq.LocationID == "null"|| rq.LocationID=="")
                rq.LocationID = null;
            try
            {
                
                SqlDataAdapter adp = new SqlDataAdapter("SP_GetQuestion", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("CustID", rq.CustID);
                adp.SelectCommand.Parameters.AddWithValue("LocationID", rq.LocationID);
                adp.SelectCommand.Parameters.AddWithValue("ProdID", rq.ProdID);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        public DataTable SubmitAswers(string SureyID, string QuestionID, string CustId, string Rating, string NoOfSkip, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter adp = new SqlDataAdapter("SP_SubmitAnswer", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@SurveyID", SureyID);
                adp.SelectCommand.Parameters.AddWithValue("@QuestionID", QuestionID);
                adp.SelectCommand.Parameters.AddWithValue("@CustId", CustId);
                adp.SelectCommand.Parameters.AddWithValue("@Rating", Rating);

                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        #endregion
        #region Complain
        public DataTable SaveComplain(string CustID, string ComplainDetails, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter adp = new SqlDataAdapter("SP_LodgeComplain", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@CustID", CustID);
                adp.SelectCommand.Parameters.AddWithValue("@CmplainDetails", ComplainDetails);


                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        public DataTable SaverReply(string ComplainID, string ReplyDetails, string ComplainDetails, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter adp = new SqlDataAdapter("SP_SubmitReply", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@ComplainID", ComplainID);
                adp.SelectCommand.Parameters.AddWithValue("@ReplyDetails", ReplyDetails);
                adp.SelectCommand.Parameters.AddWithValue("@RepliedBy", ComplainDetails);

                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        public DataTable GetComplain(string CustID, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter adp = new SqlDataAdapter("SP_GetComplainDetails", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@CustID", CustID);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        public DataTable GetReply(string ComplainID, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter adp = new SqlDataAdapter("SP_GetRelyDetailsByID", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("ComplainID", ComplainID);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        public DataTable Updateomplain(string ComplainID, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter adp = new SqlDataAdapter("SP_CloseUpdate", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@ComplainID", ComplainID);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }

        public DataTable UpdateQuantity(string slid, string Dono, string Qty, string TiscoSapCode, string imieno, out string message)
        {
            message = "";
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter adp = new SqlDataAdapter("SP_ChangeQty", con);
                adp.SelectCommand.CommandTimeout = 0;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@SlNo", slid);
                adp.SelectCommand.Parameters.AddWithValue("@DONo", Dono);
                adp.SelectCommand.Parameters.AddWithValue("@Quatity", Qty);
                adp.SelectCommand.Parameters.AddWithValue("@CustID", TiscoSapCode);
                adp.SelectCommand.Parameters.AddWithValue("@IMIE_NO", imieno);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                return dt;
            }

            return dt;
        }
        #endregion
    }
}