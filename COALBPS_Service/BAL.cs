using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Hosting;
using System.Net.Mail;
using System.Net;
using System.ServiceModel;
using System.Configuration;
using System.Text;
using System.Collections.Specialized;
using System.Reflection;

namespace COALBPS_Service
{
    public class BAL
    {
        DAL da = new DAL();
        string message;
        public CategoryID CategoryId(CategoryIDReceive CatIDr)
        {
            CategoryID Catid = new CategoryID();
            try
            {
                DataTable dt = da.getCatID(CatIDr, out message);
                if (dt.Rows.Count > 0)
                {
                    Catid = Utils.ConvertDataTableToClassObject<CategoryID>(dt);
                    //Catid.Msg = Message.SuccessMsg;
                    //Catid.StatusCode = Message.SuccesCode;
                }
                else
                {
                    //    Catid.Msg = Message.DashBoardErrorMsg;
                    //    Catid.StatusCode = Message.DashBoardErrorCode;
                }
            }
            catch (Exception ex)
            {
                //Catid.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                //Catid.StatusCode = Message.ExceptionCode;
                return Catid;
            }
            return (Catid);
        }
        public CustomerDetails Login(Login lg)
        {
            CustomerDetails cd = new CustomerDetails();
            try
            {
                DataTable dt = da.Login(lg, out message);

                if (dt != null)
                {

                    if (dt.Rows.Count > 0)
                    {
                        cd = Utils.ConvertDataTableToClassObject<CustomerDetails>(dt);
                        cd.Msg = Message.SuccessMsg;
                        cd.StatusCode = Message.SuccesCode;
                    }
                    else
                    {
                        cd.Msg = Message.LoginErrorMsg;
                        cd.StatusCode = Message.LoginErrorCode;
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        cd.Msg = message;
                        cd.StatusCode = Message.ExceptionCode;

                    }
                    else
                    {
                        cd.Msg = Message.LoginErrorMsg;
                        cd.StatusCode = Message.LoginErrorCode;
                    }
                }
            }
            catch (Exception ex)
            {
                cd.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                cd.StatusCode = Message.ExceptionCode;
                return cd;
            }
            return cd;
        }

        //*************************Arghya***********************//
        #region Arghya2020
        public CustomerDetails LoginWithPin(loginWithPin lg)
        {
            CustomerDetails cd = new CustomerDetails();
            try
            {
                // loginWithPin cd1 = new loginWithPin();


                DataTable dt2 = da.Login1(lg, out message);

                if (dt2 != null)
                {
                    if (dt2.Rows.Count > 0)
                    {
                        cd = Utils.ConvertDataTableToClassObject<CustomerDetails>(dt2);
                        cd.Msg = Message.SuccessMsg;
                        cd.StatusCode = Message.SuccesCode;
                    }
                    else
                    {
                        cd.Msg = Message.LoginErrorMsg;
                        cd.StatusCode = Message.LoginErrorCode;
                    }
                }



                if (cd.StatusCode == "001")
                {


                    DataTable dt1 = da.LoginCheckExistPIN(lg, out message);


                    //**********Arghya*Pin Exist Check*********************//


                    if (dt1 != null)
                    {
                        if (dt1.Rows.Count > 0)
                        {
                            cd = Utils.ConvertDataTableToClassObject<CustomerDetails>(dt1);
                            cd.Msg = Message.SuccessMsg;

                            cd.cust_mobile1 = lg.MobileNo;
                            cd.mj_cust_code = lg.SAPCode;
                            string a = cd.rescount;
                            if (a == "1")
                            {


                                DataTable dt = da.LoginWithPin(lg, out message);
                                if (dt.Rows.Count > 0)
                                {
                                    da.ValidatePIN(lg, out message);
                                }

                                if (dt != null)
                                {
                                    if (dt.Rows.Count > 0)
                                    {
                                        cd = Utils.ConvertDataTableToClassObject<CustomerDetails>(dt);
                                        cd.Msg = Message.SuccessMsg;
                                        cd.StatusCode = Message.SuccesCode;
                                    }
                                    else
                                    {
                                        cd.Msg = Message.LoginErrorPINMsg;
                                        cd.StatusCode = Message.LoginPinErrorCode;
                                    }
                                }
                                else
                                {
                                    if (!string.IsNullOrWhiteSpace(message))
                                    {
                                        cd.Msg = message;
                                        cd.StatusCode = Message.ExceptionCode;

                                    }
                                    else
                                    {
                                        cd.Msg = Message.LoginErrorPINMsg;
                                        cd.StatusCode = Message.LoginPinErrorCode;
                                    }

                                }
                            }
                            else
                            {
                                cd.Msg = "Kripya naya PIN generate karein.";
                                cd.StatusCode = Message.ExistPinErrorCode;
                            }
                        }
                        //*************Arghya*PinExistCheck**********************//
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        cd.Msg = message;
                        cd.StatusCode = Message.ExceptionCode;

                    }
                    else
                    {
                        cd.Msg = Message.LoginErrorMsg;
                        cd.StatusCode = Message.LoginErrorCode;
                    }
                }
            }

            catch (Exception ex)
            {
                cd.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                cd.StatusCode = Message.ExceptionCode;
                return cd;
            }
            return cd;
        }



        public loginWithPin LoginCheckExistPIN(loginWithPin lg)
        {
            loginWithPin cd = new loginWithPin();
            CustomerDetails cd1 = new CustomerDetails();

            try
            {

                DataTable dt1 = da.Login1(lg, out message);

                if (dt1 != null)
                {
                    if (dt1.Rows.Count > 0)
                    {
                        cd1 = Utils.ConvertDataTableToClassObject<CustomerDetails>(dt1);
                        cd1.Msg = Message.SuccessMsg;
                        cd1.StatusCode = Message.SuccesCode;
                    }
                    else
                    {
                        cd1.Msg = Message.LoginErrorMsg;
                        cd1.StatusCode = Message.LoginErrorCode;
                    }
                }



                if (cd1.StatusCode == "001")
                {



                    DataTable dt = da.LoginCheckExistPIN(lg, out message);


                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            cd = Utils.ConvertDataTableToClassObject<loginWithPin>(dt);
                            cd.Message = Message.SuccessMsg;

                            cd.MobileNo = lg.MobileNo;
                            cd.SAPCode = lg.SAPCode;
                            string a = cd.rescount;
                            if (a == "1")
                            {
                                cd.Message = Message.PINExistSuccessMsg;
                                cd.StatusCode = Message.SuccesCode;
                            }
                            else
                            {
                                cd.Message = "Kripya naya PIN generate karein.";
                                cd.StatusCode = Message.ExistPinErrorCode;
                            }
                        }

                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        cd.Message = message;
                        cd.StatusCode = Message.ExceptionCode;

                    }
                    else
                    {
                        cd.Message = Message.LoginErrorMsg;
                        cd.StatusCode = Message.LoginErrorCode;
                    }
                }
            }
            catch (Exception ex)
            {
                cd.Message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                cd.StatusCode = Message.ExceptionCode;
                return cd;
            }
            return cd;
        }


        public loginWithPin LoginCreatePIN(loginWithPin lg)
        {
            loginWithPin cd = new loginWithPin();
            try
            {
                DataTable dt = da.LoginCreatePIN(lg, out message);


                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        cd = Utils.ConvertDataTableToClassObject<loginWithPin>(dt);
                        cd.Message = Message.SuccessMsg;

                        cd.MobileNo = lg.MobileNo;
                        cd.SAPCode = lg.SAPCode;
                        string a = cd.rescount;
                        if (a == "1")
                        {
                            cd.Message = Message.PINCreatedMsg;
                            cd.StatusCode = Message.SuccesCode;
                        }
                        if (a == "2")
                        {
                            cd.Message = Message.PINUpdateMsg;
                            cd.StatusCode = Message.PINUpdateCode;
                        }
                        //else
                        //{
                        //    cd.Message = "Please create PIN!";
                        //    cd.StatusCode = Message.ExistPinErrorCode;
                        //}
                    }

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        cd.Message = message;
                        cd.StatusCode = Message.ExceptionCode;

                    }
                    else
                    {
                        cd.Message = Message.ExistPinErrorCode;
                        cd.StatusCode = Message.ExistPinErrorCode;
                    }
                }
            }
            catch (Exception ex)
            {
                cd.Message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                cd.StatusCode = Message.ExceptionCode;
                return cd;
            }
            return cd;
        }

        #endregion Arghya2020






        #region notification Arghya30-04-2021
        public Notification GetNotification(Notification lg)
        {
            Notification cd = new Notification();
            try
            {
                DataTable dt = da.GetNotification(lg, out message);


                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        cd.notificationList = Utils.ConvertDataTableToClassObjectList<NotificationList>(dt);

                        cd.Message = Message.SuccessMsg;
                        cd.StatusCode = Message.SuccesCode;


                    }

                    else
                    {
                        cd.Message = Message.notificationShowErrorMsg;
                        cd.StatusCode = Message.notificationShowCode;
                    }

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        cd.Message = message;
                        cd.StatusCode = Message.ExceptionCode;

                    }
                    else
                    {
                        cd.Message = Message.ExistPinErrorCode;
                        cd.StatusCode = Message.ExistPinErrorCode;
                    }
                }
            }
            catch (Exception ex)
            {
                cd.Message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                cd.StatusCode = Message.ExceptionCode;
                return cd;
            }
            return cd;
        }

        #endregion notification Arghya30-04-2021



        //**********************Arghya************************//





        public SourceLocationList SourceLocation(RecivedTax rt)
        {
            SourceLocationList pll = new SourceLocationList();
            try
            {

                //DataTable dtProduct = da.ProductList(rt.TaxId,rt.SAPCode,out message);
                DataTable dtSource = da.SourceList(rt.SAPCode, out message);
                DataTable dtLocation = da.LocationList(rt.SAPCode, out message);
                if (dtSource != null)
                {


                    pll.SourceList = Utils.ConvertDataTableToClassObjectList<Source>(dtSource);
                    pll.Msg = Message.SuccessMsg;
                    pll.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        pll.Msg = message;
                        pll.StatusCode = Message.ExceptionCode;
                        return pll;
                    }
                    else
                    {
                        pll.Msg = Message.ProductErrorMsg;
                        pll.StatusCode = Message.ProductErrorCode;
                        return pll;
                    }

                }
                if (dtLocation != null)
                {


                    pll.LocationList = Utils.ConvertDataTableToClassObjectList<Location>(dtLocation);
                    pll.Msg = Message.SuccessMsg;
                    pll.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        pll.Msg = message;
                        pll.StatusCode = Message.ExceptionCode;
                        return pll;
                    }
                    else
                    {
                        pll.Msg = Message.LocationErrorMsg;
                        pll.StatusCode = Message.LoginErrorCode;
                        return pll;
                    }

                }


            }
            catch (Exception ex)
            {
                pll.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                pll.StatusCode = Message.ExceptionCode;
                return pll;
            }

            return pll;
        }

        public ProductList ProductList(RecivedProductRequest rt)
        {
            ProductList pll = new ProductList();
            try
            {

                DataTable dtProduct = da.ProductList(rt.SourceID, rt.LocationID, out message);

                if (dtProduct != null)
                {


                    pll.Product_List = Utils.ConvertDataTableToClassObjectList<Product>(dtProduct);
                    pll.Msg = Message.SuccessMsg;
                    pll.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        pll.Msg = message;
                        pll.StatusCode = Message.ExceptionCode;
                        return pll;
                    }
                    else
                    {
                        pll.Msg = Message.ProductErrorMsg;
                        pll.StatusCode = Message.ProductErrorCode;
                        return pll;
                    }

                }


            }
            catch (Exception ex)
            {
                pll.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                pll.StatusCode = Message.ExceptionCode;
                return pll;
            }

            return pll;
        }
        public ProductPriceList ProductPrice(RecivedProductPriceRequest rt)
        {
            ProductPriceList pll = new ProductPriceList();
            try
            {

                DataTable dtProduct = da.ProductPrice(rt.SourceID, rt.LocationID, rt.ProductID, rt.CustID, out message);

                if (dtProduct != null)
                {


                    pll.ProductPrice_List = Utils.ConvertDataTableToClassObject<ProductPrice>(dtProduct);
                    pll.Msg = Message.SuccessMsg;
                    pll.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        pll.Msg = message;
                        pll.StatusCode = Message.ExceptionCode;
                        return pll;
                    }
                    else
                    {
                        pll.Msg = Message.ProductErrorMsg;
                        pll.StatusCode = Message.ProductErrorCode;
                        return pll;
                    }

                }


            }
            catch (Exception ex)
            {
                pll.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                pll.StatusCode = Message.ExceptionCode;
                return pll;
            }

            return pll;
        }

        public Dashboard DashBoardData(DashboardRecive dbr)
        {
            Dashboard db = new Dashboard();
            try
            {

                DataTable dt = da.DashBoard(dbr, out message);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        db = Utils.ConvertDataTableToClassObject<Dashboard>(dt);
                        db.Msg = Message.SuccessMsg;
                        db.StatusCode = Message.SuccesCode;
                    }
                    else
                    {
                        db.Msg = Message.DashBoardErrorMsg;
                        db.StatusCode = Message.DashBoardErrorCode;
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        db.Msg = message;
                        db.StatusCode = Message.ExceptionCode;

                    }
                    else
                    {
                        db.Msg = Message.DashBoardErrorMsg;
                        db.StatusCode = Message.DashBoardErrorCode;
                    }

                }


            }
            catch (Exception ex)
            {
                db.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                db.StatusCode = Message.ExceptionCode;
                return db;
            }

            return db;
        }

        //New DashBoard
        public Dashboard DashBoardStatusData(DashboardRecive dbr)
        {
            Dashboard db = new Dashboard();
            try
            {

                DataTable dt = da.DashBoardStatus(dbr, out message);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        db = Utils.ConvertDataTableToClassObject<Dashboard>(dt);
                        db.Msg = Message.SuccessMsg;
                        db.StatusCode = Message.SuccesCode;
                    }
                    else
                    {
                        db.Msg = Message.DashBoardErrorMsg;
                        db.StatusCode = Message.DashBoardErrorCode;
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        db.Msg = message;
                        db.StatusCode = Message.ExceptionCode;

                    }
                    else
                    {
                        db.Msg = Message.DashBoardErrorMsg;
                        db.StatusCode = Message.DashBoardErrorCode;
                    }

                }


            }
            catch (Exception ex)
            {
                db.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                db.StatusCode = Message.ExceptionCode;
                return db;
            }

            return db;
        }
        public Dashboard DashBoardDataFooter(DashboardRecive dbr)
        {
            Dashboard db = new Dashboard();
            // DataTable dt = da.DashBoardFooter(dbr, out message);
            try
            {
                DataTable dt = da.DashBoardFooter(dbr, out message);

                if (dt != null)
                {
                    db.DashboardList = Utils.ConvertDataTableToClassObjectList<Dashboard>(dt);
                    //cst.Msg = Message.SuccessMsg;
                    //cst.StatusCode = Message.SuccesCode;
                }
            }
            catch (Exception ex)
            {
                db.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                db.StatusCode = Message.ExceptionCode;
                return db;
            }
            return db;
        }

        #region Arghya truck
        public TruckBookingNo truckBookingNoData(TruckBookingNoRecive tbnor)
        {
            TruckBookingNo tbno = new TruckBookingNo();

            try
            {
                DataTable dt = da.GettruckBookingNo(tbnor, out message);
                if (dt != null)
                {
                    tbno.TruckBookingNoList = Utils.ConvertDataTableToClassObjectList<BookingTruck>(dt);
                    tbno.Msg = Message.SuccessMsg;
                    tbno.StatusCode = Message.SuccesCode;
                }

            }
            catch (Exception ex)
            {
                tbno.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                tbno.StatusCode = Message.ExceptionCode;
                return tbno;
            }

            return tbno;
        }



        public VTSDetails VtsDetailsData(VTSRecive Vtsr)
        {
            VTSDetails Vtsd = new VTSDetails();

            try
            {
                DataTable dt = da.GetVtsDetails(Vtsr, out message);
                if (dt != null)
                {
                    Vtsd.VtsDetailsList = Utils.ConvertDataTableToClassObjectList<VTS>(dt);
                    Vtsd.Msg = Message.SuccessMsg;
                    Vtsd.StatusCode = Message.SuccesCode;
                }

            }
            catch (Exception ex)
            {
                Vtsd.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                Vtsd.StatusCode = Message.ExceptionCode;
                return Vtsd;
            }

            return Vtsd;
        }



        #endregion

        //public CatStatTruc CatStatTrucData(CatStatTrucRecive cstr)
        //{
        //    CatStatTruc cst = new CatStatTruc();
        //    string[] capacitylist = new string[] {"10","16","21","25","28"};
        //    try
        //    {
        //        DataTable dtState = da.StateList(out message);
        //        DataTable dtCategory = da.CategoryList(out message);
        //        DataTable dtTruck = da.TruckList(cstr.SAPCode, out message);
        //        if (dtState != null)
        //        {


        //            cst.StateList = Utils.ConvertDataTableToClassObjectList<State>(dtState);
        //            cst.Msg = Message.SuccessMsg;
        //            cst.StatusCode = Message.SuccesCode;

        //        }
        //        else
        //        {
        //            if (!string.IsNullOrWhiteSpace(message))
        //            {
        //                cst.Msg = message;
        //                cst.StatusCode = Message.ExceptionCode;
        //                return cst;
        //            }
        //            else
        //            {
        //                cst.Msg = Message.SateErrorMsg;
        //                cst.StatusCode = Message.StateErrorCode;
        //                return cst;
        //            }

        //        }
        //        if (dtCategory != null)
        //        {


        //            cst.CategoryList = Utils.ConvertDataTableToClassObjectList<Category>(dtCategory);
        //            cst.Msg = Message.SuccessMsg;
        //            cst.StatusCode = Message.SuccesCode;

        //        }
        //        else
        //        {
        //            if (!string.IsNullOrWhiteSpace(message))
        //            {
        //                cst.Msg = message;
        //                cst.StatusCode = Message.ExceptionCode;
        //                return cst;
        //            }
        //            else
        //            {
        //                cst.Msg = Message.CategoryErrorMsg;
        //                cst.StatusCode = Message.CategoryErrorCode;
        //                return cst;
        //            }

        //        }
        //        if (dtTruck != null)
        //        {


        //            cst.TruckList = Utils.ConvertDataTableToClassObjectList<Truck>(dtTruck);
        //            cst.Msg = Message.SuccessMsg;
        //            cst.StatusCode = Message.SuccesCode;

        //        }
        //        else
        //        {
        //            if (!string.IsNullOrWhiteSpace(message))
        //            {
        //                cst.Msg = message;
        //                cst.StatusCode = Message.ExceptionCode;
        //                return cst;
        //            }
        //            else
        //            {
        //                cst.Msg = Message.TruckErrorMsg;
        //                cst.StatusCode = Message.TruckErrorCode;
        //                return cst;
        //            }

        //        }
        //        List<Capacity> lc = new List<Capacity>();
        //        for (int i = 0; i < capacitylist.Count(); i++)
        //        {
        //            Capacity c = new Capacity();
        //            c.Id = Convert.ToString((i + 1));
        //            c.CapacityQty = capacitylist[i];
        //            lc.Add(c);
        //        }
        //        cst.CapacityList = lc;

        //    }
        //    catch(Exception ex)
        //    {
        //        cst.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
        //        cst.StatusCode = Message.ExceptionCode;
        //        return cst;
        //    }

        //    return cst;
        //}

        public Booking SendBookingData(BookingRecive br)
        {
            Booking db = new Booking();
            try
            {
                DataTable dtBooking = da.Booking(br, out message);

                if (dtBooking != null)
                {
                    if (dtBooking.Rows.Count > 0)
                    {
                        db = Utils.ConvertDataTableToClassObject<Booking>(dtBooking);
                        db.Msg = Message.SuccessMsg;
                        db.StatusCode = Message.SuccesCode;
                    }
                    else
                    {
                        db.Msg = Message.BookingErrorMsg;
                        db.StatusCode = Message.BookingErrorCode;
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        db.Msg = message;
                        db.StatusCode = Message.ExceptionCode;
                    }
                    else
                    {
                        db.Msg = Message.BookingErrorMsg;
                        db.StatusCode = Message.BookingErrorCode;
                    }
                }
            }
            catch (Exception ex)
            {
                db.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                db.StatusCode = Message.ExceptionCode;
                return db;
            }
            return db;
        }

        public TruckUpdate UpdateTruckData(TruckUpdateRecive br)
        {
            TruckUpdate db = new TruckUpdate();
            try
            {

                DataTable dtBooking = da.UpdateTruck(br, out message);

                if (dtBooking != null)
                {
                    if (dtBooking.Rows.Count > 0)
                    {

                        db = Utils.ConvertDataTableToClassObject<TruckUpdate>(dtBooking);
                        db.Msg = Message.SuccessMsg;
                        db.StatusCode = Message.SuccesCode;
                    }
                    else
                    {
                        db.Msg = Message.BookingErrorMsg;
                        db.StatusCode = Message.BookingErrorCode;
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        db.Msg = message;
                        db.StatusCode = Message.ExceptionCode;

                    }
                    else
                    {
                        db.Msg = Message.BookingErrorMsg;
                        db.StatusCode = Message.BookingErrorCode;
                    }

                }


            }
            catch (Exception ex)
            {
                db.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                db.StatusCode = Message.ExceptionCode;
                return db;
            }

            return db;
        }

        //Bijoy
        public TruckChangeUpdate UpdateTruckChangData(TruckChangeUpdate br)
        {
            TruckChangeUpdate db = new TruckChangeUpdate();
            try
            {

                DataTable dtTruck = da.ChageTruck(br, out message);

                if (dtTruck != null)
                {
                    if (dtTruck.Rows.Count > 0)
                    {

                        db = Utils.ConvertDataTableToClassObject<TruckChangeUpdate>(dtTruck);
                        if (db.StatusCode == "001")
                            db.Msg = Message.SuccessMsg;
                        else
                            db.Msg = Message.TruckhangeErrorMessage;

                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(message))
                        {
                            db.Msg = message;
                            db.StatusCode = Message.ExceptionCode;

                        }
                        else
                        {
                            db.Msg = Message.BookingErrorMsg;
                            db.StatusCode = Message.BookingErrorCode;
                        }

                    }


                }
            }
            catch (Exception ex)
            {
                db.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                db.StatusCode = Message.ExceptionCode;
                return db;
            }

            return db;
        }

        public TruckChangeList TruckChageList(RecivedTrukchageRequest rt)
        {
            TruckChangeList pll = new TruckChangeList();
            try
            {

                DataTable dtTruck = da.ChageTruckList(rt.UserID, rt.Role, rt.CustID, rt.ProdId, out message);

                if (dtTruck != null)
                {

                    pll.TruckChange_List = Utils.ConvertDataTableToClassObjectList<TruckChangeUpdate>(dtTruck);
                    pll.Msg = Message.SuccessMsg;
                    pll.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        pll.Msg = message;
                        pll.StatusCode = Message.ExceptionCode;
                        return pll;
                    }
                    else
                    {
                        pll.Msg = Message.ProductErrorMsg;
                        pll.StatusCode = Message.ProductErrorCode;
                        return pll;
                    }

                }


            }
            catch (Exception ex)
            {
                pll.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                pll.StatusCode = Message.ExceptionCode;
                return pll;
            }

            return pll;
        }

        public TruckChangeUpdate ApproveRejectTruckChange(RecivedTrukchageApproveRequest br)
        {
            TruckChangeUpdate db = new TruckChangeUpdate();
            try
            {

                DataTable dtTruck = da.ApproveTrukChange(br, out message);

                if (dtTruck != null)
                {
                    if (dtTruck.Rows.Count > 0)
                    {

                        db = Utils.ConvertDataTableToClassObject<TruckChangeUpdate>(dtTruck);
                        if (db.StatusCode == "001")
                            db.Msg = Message.SuccessMsg;
                        else
                            db.Msg = Message.TruckhangeErrorMessage;

                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(message))
                        {
                            db.Msg = message;
                            db.StatusCode = Message.ExceptionCode;

                        }
                        else
                        {
                            db.Msg = Message.BookingErrorMsg;
                            db.StatusCode = Message.BookingErrorCode;
                        }

                    }


                }
            }
            catch (Exception ex)
            {
                db.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                db.StatusCode = Message.ExceptionCode;
                return db;
            }

            return db;
        }


        public BookPinUpdate UpdatePinData(BookPinRecive br)
        {
            BookPinUpdate db = new BookPinUpdate();
            try
            {

                DataTable dtBooking = da.UpdateBookPin(br, out message);

                if (dtBooking != null)
                {
                    if (dtBooking.Rows.Count > 0)
                    {

                        db = Utils.ConvertDataTableToClassObject<BookPinUpdate>(dtBooking);


                        db.Msg = Message.SuccessMsg;
                        db.StatusCode = Message.SuccesCode;




                        string a = db.rescount;
                        if (a == "1")
                        {
                            db.Message = Message.BookingPINUpdateMsg;
                            db.StatusCode = Message.BookingPINUpdateCode;
                            db.BookPinNo = br.BookPinNo;
                        }
                        if (a == "2")
                        {
                            db.Message = Message.BookingPINExistMsg;
                            db.StatusCode = Message.BookingPinExistCode;
                            db.BookPinNo = br.BookPinNo;
                        }

                    }

                    else
                    {
                        db.Message = "Please create PIN!";
                        db.StatusCode = Message.ExistPinErrorCode;
                    }


                }


                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        db.Msg = message;
                        db.StatusCode = Message.ExceptionCode;

                    }
                    else
                    {
                        db.Msg = Message.BookingPinErrorMsg;
                        db.StatusCode = Message.BookingPinErrorCode;
                    }

                }


            }
            catch (Exception ex)
            {
                db.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                db.StatusCode = Message.ExceptionCode;
                return db;
            }

            return db;
        }



        public BookingStatus ReciveBookingStatus(BookingStatusRecive bsr)
        {
            BookingStatus bs = new BookingStatus();

            List<Status> _statuslist = new List<Status>();
            try
            {
                DataTable dtBookingStatus = new DataTable();
                dtBookingStatus = da.BookingStatus(bsr, out message);
                if (dtBookingStatus.Rows.Count > 0)
                {
                    DataTable dt1 = dtBookingStatus.AsEnumerable()
                                    .GroupBy(r => new { Col1 = r["BookingDate"] })
                                    .Select(g => g.OrderBy(r => r["BookingDate"]).First())
                                    .CopyToDataTable();

                    foreach (DataRow dr in dt1.Rows)
                    {
                        DataTable dt2 = dtBookingStatus.Select("BookingDate='" + dr["BookingDate"] + "'").CopyToDataTable();
                        Status st = new Status();
                        st.BookingDate = Convert.ToString(dr["BookingDate"]);
                        st.BookingDetailsList = Utils.ConvertDataTableToClassObjectList<BookingDetails>(dt2);
                        _statuslist.Add(st);

                    }
                }

                bs.StatusList = _statuslist;
                bs.Msg = Message.SuccessMsg;
                bs.StatusCode = Message.SuccesCode;

            }
            catch (Exception ex)
            {
                bs.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                bs.StatusCode = Message.ExceptionCode;
                return bs;
            }
            return bs;
        }

        public ApproveBookingStatus ReciveApproveBookingStatus(ApproveBookingListRecive bsr)
        {
            ApproveBookingStatus bs = new ApproveBookingStatus();

            List<Status> _statuslist = new List<Status>();
            try
            {
                DataTable dtBookingStatus = new DataTable();
                dtBookingStatus = da.ReciveApproveBookingList(bsr, out message);
                if (dtBookingStatus.Rows.Count > 0)
                {
                    DataTable dt1 = dtBookingStatus.AsEnumerable()
                    .GroupBy(r => new { Col1 = r["BookingDate"] })
                    .SelectMany(g => g)
                    .CopyToDataTable();

                    foreach (DataRow dr in dt1.Rows)
                    {
                        // var Data= dtBookingStatus.Select()
                        //DataTable dt2 = dtBookingStatus.Select("BookingDate='" + dr["BookingDate"] + "'").CopyToDataTable();
                        Status st = new Status();
                        st.BookingDate = Convert.ToString(dr["BookingDate"]);
                        st.TruckNo = Convert.ToString(dr["TruckNo"]);
                        st.BookingNo = Convert.ToString(dr["BookingNo"]);
                        st.ApprovalDate = Convert.ToString(dr["ApprovalDate"]);
                        st.Changed_Trukno = Convert.ToString(dr["Changed_Trukno"]);
                        st.Quantity = Convert.ToString(dr["Quantity"]);
                        st.noOfChange= Convert.ToString(dr["NoOfChange"]);
                        st.TruckChangeRequestStatus = Convert.ToString(dr["app_rej_status_TSL"]);
                        _statuslist.Add(st);

                    }
                }

                bs.ApproveStatusList = _statuslist;
                bs.Msg = Message.SuccessMsg;
                bs.StatusCode = Message.SuccesCode;

            }
            catch (Exception ex)
            {
                bs.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                bs.StatusCode = Message.ExceptionCode;
                return bs;
            }
            return bs;
        }

        public ApproveBookingStatus ReciveConfirmBookingList(ApproveBookingListRecive bsr)
        {
            ApproveBookingStatus bs = new ApproveBookingStatus();

            List<Status> _statuslist = new List<Status>();
            try
            {
                DataTable dtBookingStatus = new DataTable();
                dtBookingStatus = da.ReciveConfirmBookingList(bsr, out message);
                if (dtBookingStatus.Rows.Count > 0)
                {
                    DataTable dt1 = dtBookingStatus.AsEnumerable()
                    .GroupBy(r => new { Col1 = r["BookingDate"] })
                    .SelectMany(g => g)
                    .CopyToDataTable();

                    foreach (DataRow dr in dt1.Rows)
                    {
                        // var Data= dtBookingStatus.Select()
                        //DataTable dt2 = dtBookingStatus.Select("BookingDate='" + dr["BookingDate"] + "'").CopyToDataTable();
                        Status st = new Status();
                        st.BookingDate = Convert.ToString(dr["BookingDate"]);
                        st.TruckNo = Convert.ToString(dr["TruckNo"]);
                        st.BookingNo = Convert.ToString(dr["BookingNo"]);
                        st.ApprovalDate = Convert.ToString(dr["ApprovalDate"]);
                        st.Changed_Trukno = Convert.ToString(dr["Changed_Trukno"]);
                        st.Quantity = Convert.ToString(dr["Quantity"]);
                        st.noOfChange = Convert.ToString(dr["NoOfChange"]);
                        st.TruckChangeRequestStatus = Convert.ToString(dr["app_rej_status_TSL"]);
                        _statuslist.Add(st);

                    }
                }

                bs.ApproveStatusList = _statuslist;
                bs.Msg = Message.SuccessMsg;
                bs.StatusCode = Message.SuccesCode;

            }
            catch (Exception ex)
            {
                bs.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                bs.StatusCode = Message.ExceptionCode;
                return bs;
            }
            return bs;
        }
        public CancelBookingList ReciveCancelBookingStatus(CancelBookingListRecive cblr)
        {
            CancelBookingList cbl = new CancelBookingList();
            try
            {
                DataTable dtBookingCancelList = da.ReciveCancelBookingList(cblr, out message);
                if (dtBookingCancelList.Rows.Count > 0)
                {
                    cbl.StatusList = Utils.ConvertDataTableToClassObjectList<BookingDetails>(dtBookingCancelList);
                }
                else
                {
                    cbl.StatusList = new List<BookingDetails>();
                }
                cbl.Msg = Message.SuccessMsg;
                cbl.StatusCode = Message.SuccesCode;
            }
            catch (Exception ex)
            {
                cbl.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                cbl.StatusCode = Message.ExceptionCode;
                return cbl;
            }
            return cbl;
        }

        public CancelBooking CancelBooking(CancelBookingRecive cbr)
        {
            CancelBooking cb = new CancelBooking();
            try
            {
                int Cancelrequest = da.ReciveBookingData(cbr, out message);
                if (Cancelrequest == -1)
                {
                    cb.Msg = Message.SuccessMsg;
                    cb.StatusCode = Message.SuccesCode;
                }
                else
                {
                    cb.Msg = Message.CancelBookingErrorMsg;
                    cb.StatusCode = Message.CancelBookingErrorCode;
                }
            }
            catch (Exception ex)
            {
                cb.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                cb.StatusCode = Message.ExceptionCode;
                return cb;
            }
            return cb;
        }


        public ContactLink ContactLinkData(ContactLinkRecive clr)
        {
            ContactLink cl = new ContactLink();
            try
            {
                int Cancelrequest = da.ReciveContactData(clr, out message);
                if (Cancelrequest == 1)
                {
                    cl.Msg = Message.SuccessMsg;
                    cl.StatusCode = Message.SuccesCode;
                }
                else
                {
                    cl.Msg = Message.CancelBookingErrorMsg;
                    cl.StatusCode = Message.CancelBookingErrorCode;
                }
            }
            catch (Exception ex)
            {
                cl.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                cl.StatusCode = Message.ExceptionCode;
                return cl;
            }
            return cl;
        }

        public ExtendBookingList ReciveExtendBookingStatus(ExtendBookingListRecive cblr)
        {
            ExtendBookingList cbl = new ExtendBookingList();
            try
            {
                DataTable dtBookingCancelList = da.ReciveExtendBookingList(cblr, out message);
                if (dtBookingCancelList.Rows.Count > 0)
                {
                    cbl.StatusList = Utils.ConvertDataTableToClassObjectList<BookingDetails>(dtBookingCancelList);
                }
                else
                {
                    cbl.StatusList = new List<BookingDetails>();
                }
                cbl.Msg = Message.SuccessMsg;
                cbl.StatusCode = Message.SuccesCode;
            }
            catch (Exception ex)
            {
                cbl.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                cbl.StatusCode = Message.ExceptionCode;
                return cbl;
            }
            return cbl;
        }

        public ExtendBooking ExtendBooking(ExtendBookingRecive cbr)
        {
            ExtendBooking cb = new ExtendBooking();
            try
            {
                DataTable dtextendBooking = da.ReciveExtendBookingData(cbr, out message);
                if (dtextendBooking.Rows.Count > 0)
                {
                    if (Convert.ToString(dtextendBooking.Rows[0][0]) == "SUCCESS")
                    {
                        cb.Msg = Message.SuccessMsg;
                        cb.StatusCode = Message.SuccesCode;
                    }
                    else
                    {
                        cb.Msg = Convert.ToString(dtextendBooking.Rows[0][0]);
                        cb.StatusCode = Message.ExtendBookingTruckEnggCode;
                    }
                }
                else
                {
                    cb.Msg = Message.ExtendBookingErrorMsg;
                    cb.StatusCode = Message.ExtendBookingErrorCode;
                }
            }
            catch (Exception ex)
            {
                cb.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                cb.StatusCode = Message.ExceptionCode;
                return cb;
            }
            return cb;
        }

        //public CustomerContactLink CustomerContactLinkData(CustomerContactLinkRecive clr)
        //{
        //    CustomerContactLink cl = new CustomerContactLink();
        //    try
        //    {
        //        int Cancelrequest = da.ReciveCustomerContactData(clr, out message);
        //        if (Cancelrequest == 1)
        //        {
        //            cl.Msg = Message.SuccessMsg;
        //            cl.StatusCode = Message.SuccesCode;
        //        }
        //        else
        //        {
        //            cl.Msg = Message.CancelBookingErrorMsg;
        //            cl.StatusCode = Message.CancelBookingErrorCode;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        cl.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
        //        cl.StatusCode = Message.ExceptionCode;
        //        return cl;
        //    }
        //    return cl;
        //}

        public RefundRequest RefundRequestData(RefundRequestRecive rrr)
        {
            RefundRequest rr = new RefundRequest();
            try
            {
                // string mailbody = PopulateBody(rrr.RefundAmount, rrr.DoNumber, rrr.SAPCode, rrr.CustomerName, rrr.BalanceAmount, "", rrr.ReconciledDate, "Acc Holder Name", "Acc Number", "IFSC Code", "Bank Name Address");
                //// string mailmsg = MailSendGen("HRIS@mjunction.in", "souvik.paul@beas.co.in", "", mailbody, "Refund of balance advance amount of Rs. " + rrr.RefundAmount + "/-");
                // string mailmsg = sendingmail_function("Refund of balance advance amount of Rs. " + rrr.RefundAmount + "/-", mailbody, "souvik.paul@beas.co.in");
                DataTable dtCancelrequest = da.ReciveRefundRequestData(rrr, out message);
                if (dtCancelrequest.Rows.Count >= 0)
                {
                    rr.Msg = Message.SuccessMsg;
                    rr.StatusCode = Message.SuccesCode;
                    rr.ReceiptNumber = Convert.ToString(dtCancelrequest.Rows[0][0]);
                    //string mailbody = PopulateBody(rrr.RefundAmount, rrr.DoNumber, rrr.SAPCode, rrr.CustomerName, rrr.BalanceAmount, "", rrr.ReconciledDate, "Acc Holder Name", "Acc Number", "IFSC Code", "Bank Name Address");
                    //string mailmsg = MailSendGen("navin.bhargava@mjunction.in", "souvik.paul@beas.co.in", "asis@beas.co.in", mailbody, "Refund of balance advance amount of Rs. " + rrr.RefundAmount + "/-");
                    //if (mailmsg == "Success")
                    //{
                    //    rr.MailStatus = "M001";
                    //    rr.MailMessage = "Success";
                    //}
                    //else
                    //{
                    //    rr.MailStatus = "M002";
                    //    rr.MailMessage = mailmsg;
                    //}
                }
                else
                {
                    rr.Msg = Message.CancelBookingErrorMsg;
                    rr.StatusCode = Message.CancelBookingErrorCode;
                }
            }
            catch (Exception ex)
            {
                rr.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                rr.StatusCode = Message.ExceptionCode;
                return rr;
            }
            return rr;
        }

        public CustomerDetails GenerateOTPandValidate(OTPRecive or)
        {
            CustomerDetails cd = new CustomerDetails();
            Login lg = new Login();
            lg.MobileNo = or.MobileNo;
            lg.SAPCode = or.SAPCode;
            try
            {

                DataTable dt = da.Login(lg, out message);
                DataTable dtOTPValidation = new DataTable();

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(or.OTPCount))
                        {
                            if (Convert.ToInt32(or.OTPCount) > 1)
                            {
                                string OTP = generateOTP();
                                string xml = genaretXML(or.MobileNo, OTP);
                                string msg = sendSMS(xml);
                                if (msg == "Success")
                                {
                                    or.OTP = OTP;
                                    dtOTPValidation = da.ValidateOTP(or, out message);
                                    if (dtOTPValidation.Rows.Count > 0)
                                    {
                                        if (Convert.ToString(dtOTPValidation.Rows[0][0]) == "3")
                                        {
                                            cd.Msg = Message.OTPSuccessMsg;
                                            cd.StatusCode = Message.SuccesCode;
                                        }
                                    }
                                    else
                                    {
                                        cd.Msg = Message.OTPErrorMsg;
                                        cd.StatusCode = Message.OTPErrorCode;
                                    }
                                }
                                else
                                {
                                    cd.Msg = msg;
                                    cd.StatusCode = Message.OTPErrorCode;
                                }
                            }
                            else if (or.OTPCount == "1")
                            {
                                if (!string.IsNullOrWhiteSpace(or.OTP))
                                {
                                    dtOTPValidation = da.ValidateOTP(or, out message);
                                    if (dtOTPValidation.Rows.Count > 0)
                                    {
                                        if (Convert.ToString(dtOTPValidation.Rows[0][0]) == "2")
                                        {
                                            cd = Utils.ConvertDataTableToClassObject<CustomerDetails>(dt);
                                            cd.Msg = Message.SuccessMsg;
                                            cd.StatusCode = Message.SuccesCode;
                                        }
                                        else if (Convert.ToString(dtOTPValidation.Rows[0][0]) == "1")
                                        {
                                            cd.Msg = Message.OTPTimeOutMsg;
                                            cd.StatusCode = Message.OTPTimeOutCode;
                                        }
                                        else if (Convert.ToString(dtOTPValidation.Rows[0][0]) == "4")
                                        {
                                            cd.Msg = Message.OTPInvalidMsg;
                                            cd.StatusCode = Message.OTPInvalidCode;
                                        }
                                        else
                                        {
                                            cd.Msg = Message.OTPErrorMsg;
                                            cd.StatusCode = Message.OTPErrorCode;
                                        }
                                    }
                                    else
                                    {
                                        cd.Msg = Message.OTPErrorMsg;
                                        cd.StatusCode = Message.OTPErrorCode;
                                    }

                                }
                                else
                                {
                                    cd.Msg = Message.OTPMsg;
                                    cd.StatusCode = Message.OTPCode;
                                }
                            }
                            else if (or.OTPCount == "0")
                            {
                                string OTP = generateOTP();
                                string xml = genaretXML(or.MobileNo, OTP);
                                string msg = sendSMS(xml);
                                if (msg == "Success")
                                {
                                    or.OTP = OTP;
                                    dtOTPValidation = da.ValidateOTP(or, out message);
                                    if (dtOTPValidation.Rows.Count > 0)
                                    {
                                        if (Convert.ToString(dtOTPValidation.Rows[0][0]) == "3")
                                        {
                                            cd.Msg = Message.OTPSuccessMsg;
                                            cd.StatusCode = Message.SuccesCode;
                                        }
                                    }
                                    else
                                    {
                                        cd.Msg = Message.OTPErrorMsg;
                                        cd.StatusCode = Message.OTPErrorCode;
                                    }
                                }
                                else
                                {
                                    cd.Msg = msg;
                                    cd.StatusCode = Message.OTPErrorCode;
                                }
                            }
                        }
                        else
                        {
                            cd.Msg = Message.OTPCountMsg;
                            cd.StatusCode = Message.OTPCountCode;
                        }

                    }
                    else
                    {
                        cd.Msg = Message.LoginErrorMsg;
                        cd.StatusCode = Message.LoginErrorCode;
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        cd.Msg = message;
                        cd.StatusCode = Message.ExceptionCode;

                    }
                    else
                    {
                        cd.Msg = Message.LoginErrorMsg;
                        cd.StatusCode = Message.LoginErrorCode;
                    }

                }


            }
            catch (Exception ex)
            {
                cd.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                cd.StatusCode = Message.ExceptionCode;
                return cd;
            }

            return cd;
        }

        #region Mail sending part
        public string MailSendGen(string mailFrom, string MailTo, string ccMail, string mailBody, string subject)
        {

            String MailStatus = "";

            try
            {

                if (!String.IsNullOrEmpty(MailTo))
                {

                    var mto = MailTo.Split(',');

                    var mcc = ccMail.Split(',');

                    MailMessage objMM = new MailMessage();

                    SmtpClient smtpmail = new SmtpClient();

                    MailAddress FromMailAddress = new MailAddress(mailFrom);

                    //MailAddress ToMailAddress = new MailAddress(MailTo);

                    for (int i = 0; i <= mto.Length - 1; i++)
                    {

                        if (mto[i] != "")
                        {

                            MailAddress ToMailAddress = new MailAddress(mto[i]);

                            objMM.To.Add(ToMailAddress);

                        }

                    }

                    for (int j = 0; j <= mcc.Length - 1; j++)
                    {

                        if (mcc[j] != "")
                        {

                            MailAddress ccMailAddress = new MailAddress(mcc[j]);

                            objMM.CC.Add(ccMailAddress);

                        }

                    }
                    objMM.From = FromMailAddress;

                    objMM.Priority = MailPriority.Normal;

                    objMM.Subject = subject;

                    objMM.IsBodyHtml = true;

                    objMM.Body = mailBody;

                    smtpmail.Host = "172.16.1.152"; //"10.0.0.2"

                    smtpmail.UseDefaultCredentials = false;

                    smtpmail.Port = 25;

                    smtpmail.Send(objMM);

                    MailStatus = "Success";
                }





            }

            catch (Exception ex)
            {
                MailStatus = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
            }
            return MailStatus;

        }

        public string sendingmail_function(string mailsub, string mailbody, string mailto)
        {
            string error = "";
            try
            {
                string frommailaddress = "souvik2201.ssd@gmail.com";
                string frommailpassword = "cateatrat";
                using (MailMessage mm = new MailMessage(frommailaddress, mailto))
                {
                    mm.Subject = mailsub;
                    mm.Body = mailbody;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(frommailaddress, frommailpassword);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    error = "Success";
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
                error = ex.ToString();
            }
            return error;
        }

        private string PopulateBody(string refund_amount, string order_no, string customer_code, string customer_name, string advanced_amount, string reconcilation_fromdate, string reconcilation_todate, string account_holdername, string account_number, string ifsc_code, string bank_name_address)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HostingEnvironment.MapPath("~/mailtemp.htm")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{{refund_amount}}", refund_amount);
            body = body.Replace("{{order_no}}", order_no);
            body = body.Replace("{{customer_code}}", customer_code);
            body = body.Replace("{{customer_name}}", customer_name);
            body = body.Replace("{{advanced_amount}}", advanced_amount);
            body = body.Replace("{{reconcilation_fromdate}}", reconcilation_fromdate);
            body = body.Replace("{{reconcilation_todate}}", reconcilation_todate);
            body = body.Replace("{{account_holdername}}", account_holdername);
            body = body.Replace("{{account_number}}", account_number);
            body = body.Replace("{{ifsc_code}}", ifsc_code);
            body = body.Replace("{{bank_name_address}}", bank_name_address);
            return body;
        }
        #endregion

        #region OTP Generation and SMS send
        public string genaretXML(string mob, string OTP)
        {
            var xml = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><OUTBOUNDMSG><IP>172.16.1.179</IP><TID>T_505</TID><MSG></MSG><MSGDETAILS><ROW REGID=\"" + mob + "\"><VARS><VAR>" + mob + "</VAR><VAR>" + OTP + "</VAR></VARS></ROW></MSGDETAILS></OUTBOUNDMSG> ";

            return xml;
        }
        public virtual String sendSMS(String xmlString)
        {
            string ret = "";
            try
            {
                string URLAuth = ConfigurationManager.AppSettings["MsgGateway"];
                WebClient webClient = new WebClient();
                String userName = ConfigurationManager.AppSettings["MsgGatewayUserID"];
                String passWord = ConfigurationManager.AppSettings["MsgGatewayPassword"];
                string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + ":" + passWord));
                webClient.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;
                webClient.Headers[HttpRequestHeader.ContentType] = ConfigurationManager.AppSettings["APIContentType"];

                WebProxy proxy = new WebProxy();
                proxy.Address = new Uri("http://172.16.1.95:8080");
                proxy.Credentials = new NetworkCredential("asis.munshi", "pass#123");  //These can be replaced by user input, if wanted.
                proxy.UseDefaultCredentials = false;
                proxy.BypassProxyOnLocal = false;

                webClient.Proxy = proxy;

                //add form values
                NameValueCollection formData = new NameValueCollection();
                formData["name"] = xmlString;
                byte[] responseBytes = webClient.UploadValues(URLAuth, ConfigurationManager.AppSettings["Method"], formData);
                string resultAuthTicket = Encoding.UTF8.GetString(responseBytes);
                webClient.Dispose();
                ret = "Success";

            }
            catch (Exception ex)
            {
                ret = "Message: " + ex.Message + " Inner Exception: " + Convert.ToString(ex.InnerException);
            }

            return ret;
        }

        public string generateOTP()
        {
            string otp = string.Empty;

            int d = Convert.ToInt32(DateTime.Now.ToString("ddMMyyyy"));
            int t = Convert.ToInt32(DateTime.Now.ToString("hhmmssff"));

            otp = Convert.ToString(d + t);
            if (otp.Length < 8)
            {
                int l = 8 - otp.Length;
                Random rn = new Random();
                otp = Convert.ToString(rn.Next(Convert.ToInt32(Math.Pow(10, l - 1)), Convert.ToInt32(Math.Pow(10, l)))) + otp;
            }
            return otp;
        }
        #endregion

        #region suman

        #region Invoice history
        public InvoiceHistoryList doInvoiceHistory(InvoiceHistoryRcv br)
        {
            InvoiceHistoryList db = new InvoiceHistoryList();
            List<InvoiceHst> _statuslist = new List<InvoiceHst>();
            try
            {
                DataTable dtInvoiceHist = da.doInvoiceHistory(br, out message);

                if (dtInvoiceHist != null && dtInvoiceHist.Rows.Count > 0)
                {
                    if (dtInvoiceHist.Rows.Count > 0)
                    {
                        DataTable dt1 = dtInvoiceHist.AsEnumerable()
                                    .GroupBy(r => new { Col1 = r["InvoiceDate"] })
                                    .Select(g => g.OrderBy(r => r["InvoiceDate"]).First())
                                    .CopyToDataTable();


                        foreach (DataRow dr in dt1.Rows)
                        {
                            DataTable dt2 = dtInvoiceHist.Select("InvoiceDate='" + dr["InvoiceDate"] + "'").CopyToDataTable();
                            InvoiceHst st = new InvoiceHst();
                            st.InvoiceDate = Convert.ToString(dr["InvoiceDate"]);
                            st.InvoiceHstList = Utils.ConvertDataTableToClassObjectList<InvoiceHistory>(dt2);
                            _statuslist.Add(st);
                        }
                        db.Invoicehistory = _statuslist;
                        db.Msg = Message.SuccessMsg;
                        db.StatusCode = Message.SuccesCode;
                    }
                    else
                    {
                        db.Msg = Message.InvoiceHistErrorMsg;
                        db.StatusCode = Message.SuccesCode;
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        db.Invoicehistory = _statuslist;
                        db.Msg = message;
                        db.StatusCode = Message.ExceptionCode;
                    }
                    else
                    {
                        db.Invoicehistory = _statuslist;
                        db.Msg = Message.SuccessMsg;
                        db.StatusCode = Message.SuccesCode;
                    }

                }


            }
            catch (Exception ex)
            {
                db.Invoicehistory = _statuslist;
                db.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                db.StatusCode = Message.ExceptionCode;
                return db;
            }

            return db;
        }
        #endregion

        #region Payment history
        public PaymentHistoryList doPaymentHistory(PaymentHistoryRcv br)
        {
            PaymentHistoryList db = new PaymentHistoryList();
            List<PaymentHst> _statuslist = new List<PaymentHst>();
            try
            {
                DataTable dtPaymentHist = da.doPaymentHistory(br, out message);

                if (dtPaymentHist != null)
                {
                    if (dtPaymentHist.Rows.Count > 0)
                    {
                        DataTable dt1 = dtPaymentHist.AsEnumerable()
                                   .GroupBy(r => new { Col1 = r["MR_Date"] })
                                   .Select(g => g.OrderBy(r => r["MR_Date"]).First())
                                   .CopyToDataTable();

                        foreach (DataRow dr in dt1.Rows)
                        {
                            DataTable dt2 = dtPaymentHist.Select("MR_Date='" + dr["MR_Date"] + "'").CopyToDataTable();
                            PaymentHst st = new PaymentHst();
                            st.PaymentDate = Convert.ToString(dr["MR_Date"]);
                            st.PaymentHstList = Utils.ConvertDataTableToClassObjectList<PaymentHistory>(dt2);
                            _statuslist.Add(st);
                        }
                        db.Paymenthistory = _statuslist;
                        db.Msg = Message.SuccessMsg;
                        db.StatusCode = Message.SuccesCode;
                    }
                    else
                    {
                        db.Paymenthistory = _statuslist;
                        db.Msg = Message.SuccessMsg;
                        db.StatusCode = Message.SuccesCode;
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        db.Paymenthistory = _statuslist;
                        db.Msg = message;
                        db.StatusCode = Message.ExceptionCode;
                    }
                    else
                    {
                        db.Paymenthistory = _statuslist;
                        db.Msg = Message.SuccessMsg;
                        db.StatusCode = Message.SuccesCode;
                    }
                }
            }
            catch (Exception ex)
            {
                db.Paymenthistory = _statuslist;
                db.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                db.StatusCode = Message.ExceptionCode;
                return db;
            }

            return db;
        }
        #endregion

        public CatStatTruc CatStatTrucData(CatStatTrucRecive cstr)
        {
            CatStatTruc cst = new CatStatTruc();

            try
            {
                DataTable dtState = da.StateList(out message);
                DataTable dtCategory = da.CategoryList(out message);
                DataTable dtTruck = da.TruckList(cstr.SAPCode, out message);
                DataTable capacitylist = da.CapacityList(cstr, out message);
                //*************************Arghya**************************************************//
                DataTable Driverlst = da.DriverList(out message);
                //*************************Arghya**************************************************//

                if (dtState != null)
                {
                    cst.StateList = Utils.ConvertDataTableToClassObjectList<State>(dtState);
                    cst.Msg = Message.SuccessMsg;
                    cst.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        cst.Msg = message;
                        cst.StatusCode = Message.ExceptionCode;
                        return cst;
                    }
                    else
                    {
                        cst.Msg = Message.SateErrorMsg;
                        cst.StatusCode = Message.StateErrorCode;
                        return cst;
                    }

                }
                if (dtCategory != null)
                {


                    cst.CategoryList = Utils.ConvertDataTableToClassObjectList<Category>(dtCategory);
                    cst.Msg = Message.SuccessMsg;
                    cst.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        cst.Msg = message;
                        cst.StatusCode = Message.ExceptionCode;
                        return cst;
                    }
                    else
                    {
                        cst.Msg = Message.CategoryErrorMsg;
                        cst.StatusCode = Message.CategoryErrorCode;
                        return cst;
                    }

                }
                if (dtTruck != null)
                {
                    cst.TruckList = Utils.ConvertDataTableToClassObjectList<Truck>(dtTruck);
                    cst.Msg = Message.SuccessMsg;
                    cst.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        cst.Msg = message;
                        cst.StatusCode = Message.ExceptionCode;
                        return cst;
                    }
                    else
                    {
                        cst.Msg = Message.TruckErrorMsg;
                        cst.StatusCode = Message.TruckErrorCode;
                        return cst;
                    }

                }

                if (capacitylist != null)
                {
                    cst.CapacityList = Utils.ConvertDataTableToClassObjectList<Capacity>(capacitylist);
                    cst.Msg = Message.SuccessMsg;
                    cst.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        cst.Msg = message;
                        cst.StatusCode = Message.ExceptionCode;
                        return cst;
                    }
                    else
                    {
                        cst.Msg = Message.CapacityErrorMsg;
                        cst.StatusCode = Message.CapacityErrorCode;
                        return cst;
                    }

                }


                //**************************Arghya******************************//

                if (Driverlst != null)
                {
                    cst.DriverList = Utils.ConvertDataTableToClassObjectList<DriverList>(Driverlst);
                    cst.Msg = Message.SuccessMsg;
                    cst.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        cst.Msg = message;
                        cst.StatusCode = Message.ExceptionCode;
                        return cst;
                    }
                    else
                    {
                        cst.Msg = Message.DriverErrorMsg;
                        cst.StatusCode = Message.DriverErrorCode;
                        return cst;
                    }

                }

                //************************Arghya*******************************//



            }
            catch (Exception ex)
            {
                cst.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                cst.StatusCode = Message.ExceptionCode;
                return cst;
            }

            return cst;
        }

        #endregion
        //************Arghya**********************************************//
        #region ArghyaOutStationCatStatTrucDriverList

        public CatStatTruc OutStationCatStatTrucData(CatStatTrucRecive cstr)
        {
            CatStatTruc cst = new CatStatTruc();

            try
            {
                DataTable dtState = da.StateList(out message);
                DataTable dtCategory = da.CategoryList(out message);
                DataTable dtTruck = da.OutStationTruckList(out message);
                DataTable capacitylist = da.CapacityList(cstr, out message);
                //*************************Arghya**************************************************//
                DataTable Driverlst = da.DriverList(out message);
                //*************************Arghya**************************************************//

                if (dtState != null)
                {
                    cst.StateList = Utils.ConvertDataTableToClassObjectList<State>(dtState);
                    cst.Msg = Message.SuccessMsg;
                    cst.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        cst.Msg = message;
                        cst.StatusCode = Message.ExceptionCode;
                        return cst;
                    }
                    else
                    {
                        cst.Msg = Message.SateErrorMsg;
                        cst.StatusCode = Message.StateErrorCode;
                        return cst;
                    }

                }
                if (dtCategory != null)
                {


                    cst.CategoryList = Utils.ConvertDataTableToClassObjectList<Category>(dtCategory);
                    cst.Msg = Message.SuccessMsg;
                    cst.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        cst.Msg = message;
                        cst.StatusCode = Message.ExceptionCode;
                        return cst;
                    }
                    else
                    {
                        cst.Msg = Message.CategoryErrorMsg;
                        cst.StatusCode = Message.CategoryErrorCode;
                        return cst;
                    }

                }
                if (dtTruck != null)
                {
                    cst.TruckList = Utils.ConvertDataTableToClassObjectList<Truck>(dtTruck);
                    cst.Msg = Message.SuccessMsg;
                    cst.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        cst.Msg = message;
                        cst.StatusCode = Message.ExceptionCode;
                        return cst;
                    }
                    else
                    {
                        cst.Msg = Message.TruckErrorMsg;
                        cst.StatusCode = Message.TruckErrorCode;
                        return cst;
                    }

                }

                if (capacitylist != null)
                {
                    cst.CapacityList = Utils.ConvertDataTableToClassObjectList<Capacity>(capacitylist);
                    cst.Msg = Message.SuccessMsg;
                    cst.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        cst.Msg = message;
                        cst.StatusCode = Message.ExceptionCode;
                        return cst;
                    }
                    else
                    {
                        cst.Msg = Message.CapacityErrorMsg;
                        cst.StatusCode = Message.CapacityErrorCode;
                        return cst;
                    }

                }


                //**************************Arghya******************************//

                if (Driverlst != null)
                {
                    cst.DriverList = Utils.ConvertDataTableToClassObjectList<DriverList>(Driverlst);
                    cst.Msg = Message.SuccessMsg;
                    cst.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        cst.Msg = message;
                        cst.StatusCode = Message.ExceptionCode;
                        return cst;
                    }
                    else
                    {
                        cst.Msg = Message.DriverErrorMsg;
                        cst.StatusCode = Message.DriverErrorCode;
                        return cst;
                    }

                }

                //************************Arghya*******************************//



            }
            catch (Exception ex)
            {
                cst.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                cst.StatusCode = Message.ExceptionCode;
                return cst;
            }

            return cst;
        }
        #endregion ArghyaOutStationCatStatTrucList

        //*****************Arghya*************************************//

        #region Sayantan
        public RefundResponseRequestList ResponseData(RecivedRefundRequest rrr)
        {
            RefundResponseRequestList rrl = new RefundResponseRequestList();
            List<ResponseRefundSort> lstResponseRefund = new List<ResponseRefundSort>();
            try
            {

                DataTable dtReqres = da.ResponseRequestData(rrr, out message);
                if (dtReqres != null && dtReqres.Rows.Count > 0)
                {

                    DataTable dt1 = dtReqres.AsEnumerable()
                                 .GroupBy(r => new { Col1 = r["RequestDate"] })
                                 .Select(g => g.OrderBy(r => r["RequestDate"]).First())
                                 .CopyToDataTable();
                    foreach (DataRow dr in dt1.Rows)
                    {
                        DataTable dt2 = dtReqres.Select("RequestDate='" + dr["RequestDate"] + "'").CopyToDataTable();
                        ResponseRefundSort st = new ResponseRefundSort();
                        st.RequestDate = Convert.ToString(dr["RequestDate"]);
                        st.RefundRequestSortList = Utils.ConvertDataTableToClassObjectList<ResponseRefund>(dt2);
                        lstResponseRefund.Add(st);
                    }

                    rrl.RefundRequest_List = lstResponseRefund;
                    rrl.Msg = Message.SuccessMsg;
                    rrl.StatusCode = Message.SuccesCode;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        rrl.RefundRequest_List = new List<ResponseRefundSort>();
                        rrl.Msg = message;
                        rrl.StatusCode = Message.ExceptionCode;
                        return rrl;
                    }
                    else
                    {
                        rrl.RefundRequest_List = new List<ResponseRefundSort>();
                        rrl.Msg = Message.SuccessMsg;
                        rrl.StatusCode = Message.SuccesCode;
                        return rrl;
                    }
                }
            }
            catch (Exception ex)
            {
                rrl.RefundRequest_List = new List<ResponseRefundSort>();
                rrl.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                rrl.StatusCode = Message.ExceptionCode;
                return rrl;
            }

            return rrl;
        }

        #region Sms
        public ResendSmsStat ResponseSmsData(ResendSmsData rsd)
        {
            ResendSmsStat rsl = new ResendSmsStat();
            try
            {
                DataTable dtReqres = da.ResponseResendSmsData(rsd, out message);
                if (dtReqres != null)
                {
                    rsl.SmsOrderDetails = Utils.ConvertDataTableToClassObject<SmsOrderDetails>(dtReqres);
                    CreateSendSMS(rsl.SmsOrderDetails);

                    DataTable dtSmsCount = da.GetSmsCount(rsl.SmsOrderDetails.ReceiptNo.ToString(), out message); // update and get sms count
                    rsl.msgSmsCnt = Convert.ToInt32(dtSmsCount.Rows[0][0]);
                    rsl.Msg = Message.SuccessMsg;
                    rsl.StatusCode = Message.SuccesCode;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        rsl.Msg = message;
                        rsl.StatusCode = Message.ExceptionCode;
                        return rsl;
                    }
                    else
                    {
                        rsl.Msg = Message.ResponseErrorMsg;
                        rsl.StatusCode = Message.ResponseErrorCode;
                        return rsl;
                    }
                }
            }
            catch (Exception ex)
            {
                rsl.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                rsl.StatusCode = Message.ExceptionCode;
                return rsl;
            }

            return rsl;
        }
        public void CreateSendSMS(SmsOrderDetails _OrderDetails)
        {
            try
            {
                IList<SmsOrderDetails> SMSlist = new List<SmsOrderDetails>();
                SMSTemplate smsTemplate = new SMSTemplate();
                smsTemplate.templateId = "63";

                DataTable dtsmsTemplate = da.GetSmsTemplate(smsTemplate.templateId, out message);
                smsTemplate = Utils.ConvertDataTableToClassObject<SMSTemplate>(dtsmsTemplate);

                DataTable dtsmsVariable = da.GetSmsDescribe(smsTemplate.templateId, out message);
                IList<SMSVariable> smsVariableList = Utils.ConvertDataTableToClassObjectList<SMSVariable>(dtsmsVariable);


                DataTable dtMonthName = da.GetSmsMonthName(out message);
                _OrderDetails.MonthName = Convert.ToString(dtMonthName.Rows[0][0]);

                DataTable dtQuantity = da.GetSmsQtyLimit(_OrderDetails.Do, out message);
                _OrderDetails.Quantity = Convert.ToString(dtQuantity.Rows[0][0]);


                SMSlist.Add(_OrderDetails);
                buildXML(SMSlist, smsVariableList, Convert.ToString(smsTemplate.gatewayTemplateId));
            }
            catch (Exception ex)
            {
                //SMSlist.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                //SMSlist.StatusCode = Message.ExceptionCode;
                //return SMSlist;
            }
        }
        public void buildXML(IList<SmsOrderDetails> smsList, IList<SMSVariable> Variable, string SMSTemplateID)
        {
            Object outObject = null;
            int rowId = 1;
            string s;
            StringBuilder xmlBuilder = new StringBuilder();
            xmlBuilder.Append("<?xml version='1.0' encoding='UTF-8' standalone='yes'?><OUTBOUNDMSG>");
            xmlBuilder.Append("<IP>").Append(ConfigurationManager.AppSettings["ServerIP"]).Append("</IP>");
            xmlBuilder.Append("<TID>").Append(SMSTemplateID).Append("</TID>");
            xmlBuilder.Append("<MSG></MSG>");
            xmlBuilder.Append("<MSGDETAILS>");
            foreach (SmsOrderDetails sms in smsList)
            {
                xmlBuilder.Append("<ROW REGID='").Append(sms.MobileNo).Append("'>");
                xmlBuilder.Append("<VARS>");
                foreach (SMSVariable smsVariable in Variable)
                {
                    xmlBuilder.Append("<").Append("VAR").Append(">");
                    outObject = sms;
                    s = InvokeStringMethod(outObject, smsVariable.Descrip);
                    xmlBuilder.Append(s);

                    xmlBuilder.Append("</").Append("VAR").Append(">");
                }
                xmlBuilder.Append("</VARS>");
                xmlBuilder.Append("</ROW>");
                rowId++;
            }
            xmlBuilder.Append("</MSGDETAILS>");
            xmlBuilder.Append("</OUTBOUNDMSG>");
            sendSMS(xmlBuilder.ToString());
        }
        public string InvokeStringMethod(object typeName, string methodName)
        {
            Type type = typeName.GetType();
            PropertyInfo info = type.GetProperty(methodName);
            string colValue = info.GetValue(typeName, null).ToString();

            return colValue;
        }

        #endregion

        #endregion

        #region Debojyoti
        public CustomerContactLink CustomerContactLinkData(CustomerContactLinkRecive clr)
        {
            CustomerContactLink cl = new CustomerContactLink();
            try
            {
                //int Cancelrequest = da.ReciveCustomerContactData(clr, out message);
                string ReturnReceipt_Number = da.ReciveCustomerContactData(clr, out message);
                //if (Cancelrequest == 1)
                if (ReturnReceipt_Number != "0")
                {
                    cl.Receipt_Number = ReturnReceipt_Number;
                    cl.Msg = Message.SuccessMsg;
                    cl.StatusCode = Message.SuccesCode;
                }
                else
                {
                    cl.Msg = Message.CancelBookingErrorMsg;
                    cl.StatusCode = Message.CancelBookingErrorCode;
                }
            }
            catch (Exception ex)
            {
                cl.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                cl.StatusCode = Message.ExceptionCode;
                return cl;
            }
            return cl;
        }
        public BookingHistoryStatus BookingHistory(BookingHistoryRequest bh)
        {
            BookingHistoryStatus bhs = new BookingHistoryStatus();
            List<BookingHistoryReceive> _statuslist = new List<BookingHistoryReceive>();
            try
            {
                DataTable dtBookingHistoryStatus = new DataTable();
                dtBookingHistoryStatus = da.BookingHistory(bh, out message);
                if (dtBookingHistoryStatus != null && dtBookingHistoryStatus.Rows.Count > 0)
                {
                    DataTable dt1 = dtBookingHistoryStatus.AsEnumerable()
                                    .GroupBy(r => new { Col4 = r["BookingDate"] })
                                    .Select(g => g.OrderBy(r => r["BookingDate"]).First())
                                    .CopyToDataTable();

                    foreach (DataRow dr in dt1.Rows)
                    {
                        DataTable dt2 = dtBookingHistoryStatus.Select("BookingDate='" + dr["BookingDate"] + "'").CopyToDataTable();
                        BookingHistoryReceive bhr = new BookingHistoryReceive();
                        bhr.BookingDate = Convert.ToString(dr["BookingDate"]);
                        bhr.BookingHistoryList = Utils.ConvertDataTableToClassObjectList<BookingHistoryList>(dt2);
                        _statuslist.Add(bhr);
                    }
                }
                bhs.BookingHistory = _statuslist;
                bhs.Msg = Message.SuccessMsg;
                bhs.StatusCode = Message.SuccesCode;
            }
            catch (Exception ex)
            {
                bhs.BookingHistory = _statuslist;
                bhs.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                bhs.StatusCode = Message.ExceptionCode;
                return bhs;
            }
            return bhs;
        }

        public FeedbackCommunicationStatus FeedbackCommunication(FeedbackCommunicationRequest fc)
        {
            FeedbackCommunicationStatus fcs = new FeedbackCommunicationStatus();
            List<FeedbackCommunicationReceive> _statuslist = new List<FeedbackCommunicationReceive>();
            try
            {
                DataTable dtFeedbackCommunicationStatus = new DataTable();
                dtFeedbackCommunicationStatus = da.FeedbackCommunication(fc, out message);
                if (dtFeedbackCommunicationStatus != null && dtFeedbackCommunicationStatus.Rows.Count > 0)
                {
                    DataTable dt1 = dtFeedbackCommunicationStatus.AsEnumerable()
                                    .GroupBy(r => new { Col4 = r["CreatedDate"] })
                                    .Select(g => g.OrderBy(r => r["CreatedDate"]).First())
                                    .CopyToDataTable();

                    foreach (DataRow dr in dt1.Rows)
                    {
                        DataTable dt2 = dtFeedbackCommunicationStatus.Select("CreatedDate='" + dr["CreatedDate"] + "'").CopyToDataTable();
                        FeedbackCommunicationReceive fcr = new FeedbackCommunicationReceive();
                        fcr.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                        fcr.FeedbackCommunicationList = Utils.ConvertDataTableToClassObjectList<FeedbackCommunicationList>(dt2);
                        _statuslist.Add(fcr);
                    }
                }
                fcs.FeedbackCommunication = _statuslist;
                fcs.Msg = Message.SuccessMsg;
                fcs.StatusCode = Message.SuccesCode;
            }
            catch (Exception ex)
            {
                fcs.FeedbackCommunication = _statuslist;
                fcs.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                fcs.StatusCode = Message.ExceptionCode;
                return fcs;
            }
            return fcs;
        }

        public AddBackReceive AddBack(AddBackRequest adb)
        {
            AddBackReceive adbr = new AddBackReceive();
            try
            {
                string ReturnMessage = da.AddBack(adb, out message);
                if (ReturnMessage != "0")
                {
                    adbr.Message = ReturnMessage;
                    adbr.Msg = Message.SuccessMsg;
                    adbr.StatusCode = Message.SuccesCode;
                }
                else
                {
                    adbr.Message = message;
                    adbr.Msg = Message.AddBackErrorMsg;
                    adbr.StatusCode = Message.AddBackErrorCode;
                }
            }
            catch (Exception ex)
            {
                adbr.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                adbr.StatusCode = Message.ExceptionCode;
                return adbr;
            }
            return adbr;
        }

        public CustomerAppInfoReceive AppInfo()
        {
            CustomerAppInfoReceive cair = new CustomerAppInfoReceive();
            try
            {
                string ReturnHtml = da.AppInfo(out message);
                if (ReturnHtml != "0")
                {
                    if (!string.IsNullOrWhiteSpace(ReturnHtml))
                    {
                        cair.InfoStatus = true;
                        cair.AppInfoHtml = ReturnHtml;
                        cair.Msg = Message.SuccessMsg;
                        cair.StatusCode = Message.SuccesCode;
                    }
                    else
                    {
                        cair.InfoStatus = false;
                        cair.AppInfoHtml = ReturnHtml;
                        cair.Msg = Message.SuccessMsg;
                        cair.StatusCode = Message.SuccesCode;
                    }
                }
                else
                {
                    cair.InfoStatus = false;
                    cair.AppInfoHtml = message;
                    cair.Msg = Message.AppInfoErrorMsg;
                    cair.StatusCode = Message.AppInfoErrorCode;
                }
            }
            catch (Exception ex)
            {
                cair.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                cair.StatusCode = Message.ExceptionCode;
                return cair;
            }
            return cair;
        }
        #endregion

        #region MobileVersion
        public MobileVersion UpdateMobileVersion(MobileVersionRecive br)
        {
            MobileVersion db = new MobileVersion();
            try
            {

                DataTable dtBooking = da.UpdateMobileVersion(br, out message);

                if (dtBooking != null)
                {
                    if (dtBooking.Rows.Count > 0)
                    {

                        db = Utils.ConvertDataTableToClassObject<MobileVersion>(dtBooking);


                        db.Message = Message.SuccessMsg;
                        db.StatusCode = Message.SuccesCode;





                        if (db.Status == "Success")
                        {
                            db.Message = Message.MobileVersionUpdateMsg;
                            db.StatusCode = Message.MobileVersionUpdateCode;
                            //db.NewVersion = br.NewVersion;
                            //db.OldVersion = br.OldVersion;
                        }


                    }

                    else
                    {
                        db.Message = "Please create Version!";
                        db.StatusCode = Message.MobileVersionErrorMsg;
                    }


                }


                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        db.Message = message;
                        db.StatusCode = Message.ExceptionCode;

                    }
                    else
                    {
                        db.Message = Message.MobileVersionErrorMsg;
                        db.StatusCode = Message.BookingPinErrorCode;
                    }

                }


            }
            catch (Exception ex)
            {
                db.Message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                db.StatusCode = Message.ExceptionCode;
                return db;
            }

            return db;
        }
        //public MobileVersion UpdateMobileVersion(MobileVersionRecive lg)
        //{
        //    MobileVersion cd = new MobileVersion();
        //    try
        //    {
        //        DataTable dt = da.UpdateMobileVersion(lg, out message);


        //        if (dt != null)
        //        {
        //            if (dt.Rows.Count > 0)
        //            {
        //                cd = Utils.ConvertDataTableToClassObject<MobileVersion>(dt);
        //                cd.Message = Message.SuccessMsg;
        //                //cd.OldVersion = lg.OldVersion;
        //                //cd.NewVersion = lg.NewVersion;
        //               // cd.Status = lg.Status;
        //                if (cd.Status == "Success")
        //                {
        //                    cd.Message = Message.MobileVersionUpdateMsg;
        //                    cd.StatusCode = Message.SuccesCode;
        //                }

        //            }

        //        }
        //        else
        //        {
        //            if (!string.IsNullOrWhiteSpace(message))
        //            {
        //                cd.Message = message;
        //                cd.StatusCode = Message.ExceptionCode;

        //            }
        //            else
        //            {
        //                cd.Message = Message.MobileVersionErrorMsg;
        //                cd.StatusCode = Message.MobileVersionErrorCode;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        cd.Message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
        //        cd.StatusCode = Message.ExceptionCode;
        //        return cd;
        //    }
        //    return cd;
        //}

        public MobileVersion Getmobileversion(MobileVersion lg)
        {
            MobileVersion cd = new MobileVersion();


            try
            {

                DataTable dt1 = da.GetMobileVersion(lg);

                if (dt1 != null)
                {
                    if (dt1.Rows.Count > 0)
                    {
                        cd = Utils.ConvertDataTableToClassObject<MobileVersion>(dt1);
                        cd.Message = Message.SuccessMsg;
                        cd.StatusCode = Message.SuccesCode;

                        // ImportPart pTbl = new ImportPart();
                        // pTbl.PartID = Convert.ToInt32(objresult.Rows[i]["PartID"]);
                        cd.OldVersion = Convert.ToString(dt1.Rows[0]["OldVersion"]);

                    }
                    else
                    {
                        cd.Message = Message.LoginErrorMsg;
                        cd.StatusCode = Message.LoginErrorCode;
                    }
                }




            }
            catch (Exception ex)
            {
                cd.Message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                cd.StatusCode = Message.ExceptionCode;
                return cd;
            }
            return cd;
        }


        #endregion mobileVersion
        #region Survey
        public QuestionList QuestonList(ReceivedQueston rq)
        {
            QuestionList pll = new QuestionList();
            try
            {

                DataTable dtQuestion = da.GetQuestions(rq, out message);

                if (dtQuestion.Rows.Count>0)
                {

                    pll.Question_List = Utils.ConvertDataTableToClassObjectList<Questions>(dtQuestion);
                    pll.SurveyID = dtQuestion.Rows[0]["SurveyID"].ToString();
                    pll.SurveyName = dtQuestion.Rows[0]["Survey_Description"].ToString();
                    pll.IsDone = dtQuestion.Rows[0]["IsDone"].ToString();
                    pll.NoOfSkip = dtQuestion.Rows[0]["NoOfSkip"].ToString();
                    pll.Msg = Message.SuccessMsg;
                    pll.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        pll.Msg = message;
                        pll.StatusCode = Message.ExceptionCode;
                        return pll;
                    }
                    else
                    {
                        pll.Msg = Message.ProductErrorMsg;
                        pll.StatusCode = Message.ProductErrorCode;
                        return pll;
                    }

                }


            }
            catch (Exception ex)
            {
                pll.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                pll.StatusCode = Message.ExceptionCode;
                return pll;
            }

            return pll;
        }

        public UpdateAnswer UpdateAnswer(ReceivedAnswer ra)
        {
            UpdateAnswer pll = new UpdateAnswer();
            try
            {

                DataTable dtnswer = da.SubmitAswers(ra.SurveyID, ra.QuestionID, ra.CustId, ra.Rating, ra.NoOfSkip, out message);

                if (dtnswer != null)
                {

                    pll = Utils.ConvertDataTableToClassObject<UpdateAnswer>(dtnswer);


                    pll.Msg = Message.SuccessMsg;
                    pll.StatusCode = Message.SuccesCode;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        pll.Msg = message;
                        pll.StatusCode = Message.ExceptionCode;
                        return pll;
                    }
                    else
                    {
                        pll.Msg = Message.ProductErrorMsg;
                        pll.StatusCode = Message.ProductErrorCode;
                        return pll;
                    }

                }


            }
            catch (Exception ex)
            {
                pll.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                pll.StatusCode = Message.ExceptionCode;
                return pll;
            }

            return pll;
        }
        #endregion

        #region Complain
        public UpdateComplain LodgeComplain(ReceivedComplain rc)
        {
            UpdateComplain pll = new UpdateComplain();
            try
            {

                DataTable dtComplane = da.SaveComplain(rc.CustID,rc.ComplainDetails, out message);

                if (dtComplane != null)
                {

                    pll = Utils.ConvertDataTableToClassObject<UpdateComplain>(dtComplane);


                    pll.Msg = Message.SuccessMsg;
                    pll.StatusCode = Message.SuccesCode;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        pll.Msg = message;
                        pll.StatusCode = Message.ExceptionCode;
                        return pll;
                    }
                    else
                    {
                        pll.Msg = Message.ProductErrorMsg;
                        pll.StatusCode = Message.ProductErrorCode;
                        return pll;
                    }

                }


            }
            catch (Exception ex)
            {
                pll.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                pll.StatusCode = Message.ExceptionCode;
                return pll;
            }

            return pll;
        }

        public UpdateReply SubmitReply(ReceivedReply rr)
        {
            UpdateReply pll = new UpdateReply();
            try
            {

                DataTable dtReply = da.SaverReply(rr.ComplainID,rr.ReplyDetails,rr.RepliedBy, out message);

                if (dtReply != null)
                {

                    pll = Utils.ConvertDataTableToClassObject<UpdateReply>(dtReply);


                    pll.Msg = Message.SuccessMsg;
                    pll.StatusCode = Message.SuccesCode;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        pll.Msg = message;
                        pll.StatusCode = Message.ExceptionCode;
                        return pll;
                    }
                    else
                    {
                        pll.Msg = Message.ProductErrorMsg;
                        pll.StatusCode = Message.ProductErrorCode;
                        return pll;
                    }

                }


            }
            catch (Exception ex)
            {
                pll.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                pll.StatusCode = Message.ExceptionCode;
                return pll;
            }

            return pll;
        }
        public ComplainList GetComplains(RcvdComplain rc)
        {
            ComplainList pll = new ComplainList();
            try
            {

                DataTable dtComplain = da.GetComplain(rc.CustID,out message);

                if (dtComplain != null)
                {

                    pll.Complain_List = Utils.ConvertDataTableToClassObjectList<UpdateComplain>(dtComplain);
                   
                    pll.Msg = Message.SuccessMsg;
                    pll.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        pll.Msg = message;
                        pll.StatusCode = Message.ExceptionCode;
                        return pll;
                    }
                    else
                    {
                        pll.Msg = Message.ProductErrorMsg;
                        pll.StatusCode = Message.ProductErrorCode;
                        return pll;
                    }

                }


            }
            catch (Exception ex)
            {
                pll.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                pll.StatusCode = Message.ExceptionCode;
                return pll;
            }

            return pll;
        }

        public ReplyList ReplyList(RcvdReply rr)
        {
            ReplyList pll = new ReplyList();
            try
            {

                DataTable dtReply = da.GetReply(rr.ComplainID, out message);

                if (dtReply != null)
                {

                    pll.Reply_List = Utils.ConvertDataTableToClassObjectList<UpdateReply>(dtReply);
                    pll.Msg = Message.SuccessMsg;
                    pll.StatusCode = Message.SuccesCode;

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        pll.Msg = message;
                        pll.StatusCode = Message.ExceptionCode;
                        return pll;
                    }
                    else
                    {
                        pll.Msg = Message.ProductErrorMsg;
                        pll.StatusCode = Message.ProductErrorCode;
                        return pll;
                    }

                }


            }
            catch (Exception ex)
            {
                pll.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                pll.StatusCode = Message.ExceptionCode;
                return pll;
            }

            return pll;
        }

        public UpdateComplain CloseComplain(RcvdReply rc)
        {
            UpdateComplain pll = new UpdateComplain();
            try
            {

                DataTable dtComplaine = da.Updateomplain(rc.ComplainID, out message);

                if (dtComplaine != null)
                {

                    pll = Utils.ConvertDataTableToClassObject<UpdateComplain>(dtComplaine);


                    pll.Msg = Message.SuccessMsg;
                    pll.StatusCode = Message.SuccesCode;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        pll.Msg = message;
                        pll.StatusCode = Message.ExceptionCode;
                        return pll;
                    }
                    else
                    {
                        pll.Msg = Message.ProductErrorMsg;
                        pll.StatusCode = Message.ProductErrorCode;
                        return pll;
                    }

                }


            }
            catch (Exception ex)
            {
                pll.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                pll.StatusCode = Message.ExceptionCode;
                return pll;
            }

            return pll;
        }

        public UpdateQty ChangeQuantity(RcvdQtyPrm rc)
        {
            UpdateQty pll = new UpdateQty();
            try
            {

                DataTable dtQty = da.UpdateQuantity(rc.slid,rc.DOno,rc.Quantity,rc.TiscoSapCode,rc.IMEI_NO, out message);

                if (dtQty != null)
                {

                    pll = Utils.ConvertDataTableToClassObject<UpdateQty>(dtQty);


                    
                    pll.StatusCode = dtQty.Rows[0]["StatusCode"].ToString();
                    if (pll.StatusCode == "001")
                        pll.Msg = "Quantity updated sucessfully";
                    else
                        pll.Msg = "Quantity cannot be updated due to insuficient balance!";
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        pll.Msg = message;
                        pll.StatusCode = Message.ExceptionCode;
                        return pll;
                    }
                    else
                    {
                        pll.Msg = Message.ProductErrorMsg;
                        pll.StatusCode = Message.ProductErrorCode;
                        return pll;
                    }

                }


            }
            catch (Exception ex)
            {
                pll.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException);
                pll.StatusCode = Message.ExceptionCode;
                return pll;
            }

            return pll;
        }
        #endregion
    }
}