using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Specialized;
using COALBPS_WebApplication.Helper;

namespace COALBPS_Service
{

    public class ServiceCOALBPS : IServiceCOALBPS
    {
        BAL ba = new BAL();

        #region Read Client Strem And Return Byte data
        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
        #endregion

        #region User Login method
        public CustomerDetails COALBPSLogin(Stream ReceiveData)
        {

            CustomerDetails cd = new CustomerDetails();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                Login lgn = new Login();
                lgn = JsonConvert.DeserializeObject<Login>(jsonstring);

                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(lgn.SAPCode))
                {
                    cd.Msg = "SAP Code Cannot be null or empty";
                    cd.StatusCode = "0";
                    return cd;
                }
                if (string.IsNullOrWhiteSpace(lgn.MobileNo))
                {
                    cd.Msg = "Mobile Number Cannot be null or empty";
                    cd.StatusCode = "0";
                    return cd;
                }

                #endregion

                #region Check Login Data from Data Base
                cd = ba.Login(lgn);
                #endregion



            }
            catch (Exception ex)
            {
                cd.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                cd.StatusCode = Message.ExceptionCode;
                return cd;
            }
            return cd;
        }
        #endregion
        #region Arghya2020

        //*************************Arghya***********************//
        #region UserLoginWithPin
        public CustomerDetails COALBPSLoginWithpin(Stream ReceiveData)
        {

            CustomerDetails cd = new CustomerDetails();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                loginWithPin lgnPin = new loginWithPin();
                lgnPin = JsonConvert.DeserializeObject<loginWithPin>(jsonstring);

                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(lgnPin.SAPCode))
                {
                    cd.Msg = "SAP Code Cannot be null or empty";
                    cd.StatusCode = "0";
                    return cd;
                }
                if (string.IsNullOrWhiteSpace(lgnPin.MobileNo))
                {
                    cd.Msg = "Mobile Number Cannot be null or empty";
                    cd.StatusCode = "0";
                    return cd;
                }

                if (string.IsNullOrWhiteSpace(lgnPin.PinNo))
                {
                    cd.Msg = "Pin Number Cannot be null or empty";
                    cd.StatusCode = "0";
                    return cd;
                }

                #endregion

                #region Check Login Data from Data Base
                cd = ba.LoginWithPin(lgnPin);

                #endregion



            }
            catch (Exception ex)
            {
                cd.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                cd.StatusCode = Message.ExceptionCode;
                return cd;
            }
            return cd;
        }
        #endregion UserLoginWithPin
        #region CheckExistPin
        public loginWithPin COALBPSLoginCheckExistPIN(Stream ReceiveData)
        {

            loginWithPin cd = new loginWithPin();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                loginWithPin lgnPin = new loginWithPin();
                lgnPin = JsonConvert.DeserializeObject<loginWithPin>(jsonstring);

                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(lgnPin.SAPCode))
                {
                    cd.Message = "SAP Code Cannot be null or empty";
                    cd.StatusCode = "0";
                    return cd;
                }
                if (string.IsNullOrWhiteSpace(lgnPin.MobileNo))
                {
                    cd.Message = "Mobile Number Cannot be null or empty";
                    cd.StatusCode = "0";
                    return cd;
                }

                //if (string.IsNullOrWhiteSpace(lgnPin.PinNo))
                //{
                //    cd.Msg = "Pin Number Cannot be null or empty";
                //    cd.StatusCode = "0";
                //    return cd;
                //}

                #endregion

                #region Check Login Data from Data Base
                cd = ba.LoginCheckExistPIN(lgnPin);

                #endregion



            }
            catch (Exception ex)
            {
                cd.Message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                cd.StatusCode = Message.ExceptionCode;
                return cd;
            }
            return cd;
        }


        #endregion

        #region CreateUpdatePIN
        public loginWithPin LoginCreatePIN(Stream ReceiveData)
        {

            loginWithPin cd = new loginWithPin();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                loginWithPin lgnPin = new loginWithPin();
                lgnPin = JsonConvert.DeserializeObject<loginWithPin>(jsonstring);

                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(lgnPin.SAPCode))
                {
                    cd.Message = "SAP Code Cannot be null or empty";
                    cd.StatusCode = "0";
                    return cd;
                }
                if (string.IsNullOrWhiteSpace(lgnPin.MobileNo))
                {
                    cd.Message = "Mobile Number Cannot be null or empty";
                    cd.StatusCode = "0";
                    return cd;
                }

                if (string.IsNullOrWhiteSpace(lgnPin.PinNo))
                {
                    cd.Message = "Pin Number Cannot be null or empty";
                    cd.StatusCode = "0";
                    return cd;
                }

                #endregion

                #region Check Login Data from Data Base
                cd = ba.LoginCreatePIN(lgnPin);

                #endregion



            }
            catch (Exception ex)
            {
                cd.Message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                cd.StatusCode = Message.ExceptionCode;
                return cd;
            }
            return cd;
        }
        #endregion
        #endregion Arghya2020
        //*************************Arghya***********************//

        //*****************Arghya 30-04-2021*************//
        #region Arghya 30-04-2021
        #region notification

        public Notification COALBPSAppShownotification(Stream ReceiveData)
        {
            Notification cd = new Notification();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                Notification notification = new Notification();
                notification = JsonConvert.DeserializeObject<Notification>(jsonstring);

                #region Checking Condition for Empty or Null Value

                // notification.Customer_Id = "172176";
                if (string.IsNullOrWhiteSpace(notification.Customer_Id))
                {
                    cd.Message = "Customer Id Cannot be null or empty";
                    cd.StatusCode = "0";
                    return cd;
                }

                //notification.FromDate = "2021-03-15";
                if (string.IsNullOrWhiteSpace(notification.FromDate))
                {
                    cd.Message = "From Date Cannot be null or empty";
                    cd.StatusCode = "0";
                    return cd;
                }
                // notification.ToDate = "2021-03-15";
                if (string.IsNullOrWhiteSpace(notification.ToDate))
                {
                    cd.Message = "To Date Cannot be null or empty";
                    cd.StatusCode = "0";
                    return cd;
                }




                #endregion

                #region Check Login Data from Data Base
                cd = ba.GetNotification(notification);

                #endregion



            }
            catch (Exception ex)
            {
                cd.Message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                cd.StatusCode = Message.ExceptionCode;
                return cd;
            }
            return cd;
        }
        #endregion notification
        #endregion Arghya 30-04-2021
        //*****************Arghya 30-04-2021*************//



        #region Source Location method
        public SourceLocationList COALBPSSourceLocation(Stream ReceiveData)
        {
            SourceLocationList pll = new SourceLocationList();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                RecivedTax rt = new RecivedTax();
                rt = JsonConvert.DeserializeObject<RecivedTax>(jsonstring);
                pll = ba.SourceLocation(rt);

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

        #region Product List method
        public ProductList COALBPSProdList(Stream ReceiveData)
        {
            ProductList pll = new ProductList();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                RecivedProductRequest rt = new RecivedProductRequest();
                rt = JsonConvert.DeserializeObject<RecivedProductRequest>(jsonstring);
                pll = ba.ProductList(rt);

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

        #region Product Price method
        public ProductPriceList COALBPSProdPrice(Stream ReceiveData)
        {
            ProductPriceList pll = new ProductPriceList();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                RecivedProductPriceRequest rt = new RecivedProductPriceRequest();
                rt = JsonConvert.DeserializeObject<RecivedProductPriceRequest>(jsonstring);
                pll = ba.ProductPrice(rt);

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

        #region User DashBoard method
        public Dashboard COALBPSDashBoard(Stream ReceiveData)
        {

            Dashboard db = new Dashboard();
            CategoryID cid = new CategoryID();
            DashboardRecive dbr = new DashboardRecive();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                CategoryIDReceive catIDrec = new CategoryIDReceive();
                catIDrec = JsonConvert.DeserializeObject<CategoryIDReceive>(jsonstring);

                cid = ba.CategoryId(catIDrec);
                // catIDrec = JsonConvert.DeserializeObject<CategoryIDReceive>(jsonstring);
                string a = cid.CatID;
                int i = Convert.ToInt32(a);
                //-----FOR INSTITUTIONAL uSER------
                if (i == 1)
                {
                    dbr = JsonConvert.DeserializeObject<DashboardRecive>(jsonstring);
                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(dbr.SAPCode))
                    {
                        db.Msg = "SAP Code Cannot be null or empty";
                        db.StatusCode = "0";
                        return db;
                    }
                    #endregion
                    #region Check Login Data from Data Base
                    db = ba.DashBoardData(dbr);
                    #endregion

                }
                //----- FOE NORMAL USER
                else
                {
                    db = ba.DashBoardData(dbr);

                    dbr = JsonConvert.DeserializeObject<DashboardRecive>(jsonstring);
                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(dbr.SAPCode))
                    {
                        db.Msg = "SAP Code Cannot be null or empty";
                        db.StatusCode = "0";
                        return db;
                    }
                    if (string.IsNullOrWhiteSpace(dbr.ProductID))
                    {
                        db.Msg = "Product Id Cannot be null or empty";
                        db.StatusCode = "0";
                        return db;
                    }
                    if (string.IsNullOrWhiteSpace(dbr.SourceID))
                    {
                        db.Msg = "Source Cannot be null or empty";
                        db.StatusCode = "0";
                        return db;
                    }
                    if (string.IsNullOrWhiteSpace(dbr.LocationID))
                    {
                        db.Msg = "Location Cannot be null or empty";
                        db.StatusCode = "0";
                        return db;
                    }

                    #endregion

                    #region Check Login Data from Data Base
                    db = ba.DashBoardData(dbr);
                    #endregion
                }

            }
            catch (Exception ex)
            {
                db.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                db.StatusCode = Message.ExceptionCode;
                return db;
            }
            return db;
        }


        public Dashboard COALBPSDashBoardStatus(Stream ReceiveData)
        {

            Dashboard db = new Dashboard();
            CategoryID cid = new CategoryID();
            DashboardRecive dbr = new DashboardRecive();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                CategoryIDReceive catIDrec = new CategoryIDReceive();
                catIDrec = JsonConvert.DeserializeObject<CategoryIDReceive>(jsonstring);

                cid = ba.CategoryId(catIDrec);
                // catIDrec = JsonConvert.DeserializeObject<CategoryIDReceive>(jsonstring);
                string a = cid.CatID;
                int i = Convert.ToInt32(a);
                //-----FOR INSTITUTIONAL uSER------
                if (i == 1)
                {
                    dbr = JsonConvert.DeserializeObject<DashboardRecive>(jsonstring);
                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(dbr.SAPCode))
                    {
                        db.Msg = "SAP Code Cannot be null or empty";
                        db.StatusCode = "0";
                        return db;
                    }
                    #endregion
                    #region Check Login Data from Data Base
                    db = ba.DashBoardStatusData(dbr);
                    #endregion

                }
                //----- FOE NORMAL USER
                else
                {
                    db = ba.DashBoardStatusData(dbr);

                    dbr = JsonConvert.DeserializeObject<DashboardRecive>(jsonstring);
                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(dbr.SAPCode))
                    {
                        db.Msg = "SAP Code Cannot be null or empty";
                        db.StatusCode = "0";
                        return db;
                    }
                    if (string.IsNullOrWhiteSpace(dbr.ProductID))
                    {
                        db.Msg = "Product Id Cannot be null or empty";
                        db.StatusCode = "0";
                        return db;
                    }
                    if (string.IsNullOrWhiteSpace(dbr.SourceID))
                    {
                        db.Msg = "Source Cannot be null or empty";
                        db.StatusCode = "0";
                        return db;
                    }
                    if (string.IsNullOrWhiteSpace(dbr.LocationID))
                    {
                        db.Msg = "Location Cannot be null or empty";
                        db.StatusCode = "0";
                        return db;
                    }

                    #endregion

                    #region Check Login Data from Data Base
                    db = ba.DashBoardStatusData(dbr);
                    #endregion
                }

            }
            catch (Exception ex)
            {
                db.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                db.StatusCode = Message.ExceptionCode;
                return db;
            }
            return db;
        }

        public Dashboard COALBPSDashBoardFooter(Stream ReceiveData)
        {

            Dashboard db = new Dashboard();
            CategoryID cid = new CategoryID();
            DashboardRecive dbr = new DashboardRecive();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                CategoryIDReceive catIDrec = new CategoryIDReceive();
                catIDrec = JsonConvert.DeserializeObject<CategoryIDReceive>(jsonstring);

                cid = ba.CategoryId(catIDrec);
                // catIDrec = JsonConvert.DeserializeObject<CategoryIDReceive>(jsonstring);
                string a = cid.CatID;
                int i = Convert.ToInt32(a);
                //------FOR INSTITUTIONAL USER---------
                if (i == 1)
                {
                    dbr = JsonConvert.DeserializeObject<DashboardRecive>(jsonstring);
                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(dbr.SAPCode))
                    {
                        db.Msg = "SAP Code Cannot be null or empty";
                        db.StatusCode = "0";
                        return db;
                    }
                    #endregion
                    #region Check Login Data from Data Base
                    db = ba.DashBoardDataFooter(dbr);
                    #endregion
                }
                //--------FOR NORMAL USER
                else
                {
                    db = ba.DashBoardData(dbr);

                    dbr = JsonConvert.DeserializeObject<DashboardRecive>(jsonstring);
                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(dbr.SAPCode))
                    {
                        db.Msg = "SAP Code Cannot be null or empty";
                        db.StatusCode = "0";
                        return db;
                    }
                    if (string.IsNullOrWhiteSpace(dbr.ProductID))
                    {
                        db.Msg = "Product Id Cannot be null or empty";
                        db.StatusCode = "0";
                        return db;
                    }
                    if (string.IsNullOrWhiteSpace(dbr.SourceID))
                    {
                        db.Msg = "Source Cannot be null or empty";
                        db.StatusCode = "0";
                        return db;
                    }
                    if (string.IsNullOrWhiteSpace(dbr.LocationID))
                    {
                        db.Msg = "Location Cannot be null or empty";
                        db.StatusCode = "0";
                        return db;
                    }
                    #endregion

                    #region Check Login Data from Data Base
                    db = ba.DashBoardData(dbr);
                    #endregion
                }

            }
            catch (Exception ex)
            {
                db.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                db.StatusCode = Message.ExceptionCode;
                return db;
            }
            return db;
        }
        #endregion

        #region Category, Truck and State list method
        public CatStatTruc COALBPSCatStatTruc(Stream ReceiveData)
        {

            CatStatTruc cst = new CatStatTruc();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                CatStatTrucRecive dbr = new CatStatTrucRecive();
                dbr = JsonConvert.DeserializeObject<CatStatTrucRecive>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(dbr.SAPCode))
                {
                    cst.Msg = "SAP Code Cannot be null or empty";
                    cst.StatusCode = "0";
                    return cst;
                }
                #endregion

                #region Check Login Data from Data Base
                cst = ba.CatStatTrucData(dbr);
                #endregion
            }
            catch (Exception ex)
            {
                cst.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                cst.StatusCode = Message.ExceptionCode;
                return cst;
            }
            return cst;
        }
        #endregion
        //********Arghya**************************//
        #region Arghya2020May
        #region OutStationCatStatTrucDriverList

        public CatStatTruc OutStationCOALBPSCatStatTruc(Stream ReceiveData)
        {

            CatStatTruc cst = new CatStatTruc();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                CatStatTrucRecive dbr = new CatStatTrucRecive();
                dbr = JsonConvert.DeserializeObject<CatStatTrucRecive>(jsonstring);
                #region Checking Condition for Empty or Null Value
                //if (string.IsNullOrWhiteSpace(dbr.SAPCode))
                //{
                //    cst.Msg = "SAP Code Cannot be null or empty";
                //    cst.StatusCode = "0";
                //    return cst;
                //}
                #endregion

                #region Check Login Data from Data Base
                cst = ba.OutStationCatStatTrucData(dbr);
                #endregion
            }
            catch (Exception ex)
            {
                cst.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                cst.StatusCode = Message.ExceptionCode;
                return cst;
            }
            return cst;
        }
        #endregion Arghya_OutStationCatStatTrucDriverList

        //**********Arghya********************// 
        #region Truck Booking No
        //-------Add by Srijan
        public TruckBookingNo COALBPSGetTruckBookingNo(Stream ReceiveData)
        {
            TruckBookingNo tbno = new TruckBookingNo();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                TruckBookingNoRecive tbnor = new TruckBookingNoRecive();
                tbnor = JsonConvert.DeserializeObject<TruckBookingNoRecive>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(tbnor.SAPCode))
                {
                    tbno.Msg = "SAP Code Cannot be null or empty";
                    tbno.StatusCode = "0";
                    return tbno;
                }
                if (string.IsNullOrWhiteSpace(tbnor.FromDate))
                {
                    tbno.Msg = "From Date Cannot be null or empty";
                    tbno.StatusCode = "0";
                    return tbno;
                }
                if (string.IsNullOrWhiteSpace(tbnor.ToDate))
                {
                    tbno.Msg = "To Date Cannot be null or empty";
                    tbno.StatusCode = "0";
                    return tbno;
                }
                #endregion

                #region Check Login Data from Data Base
                tbno = ba.truckBookingNoData(tbnor);
                #endregion
            }
            catch (Exception ex)
            {
                tbno.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                tbno.StatusCode = Message.ExceptionCode;
                return tbno;
            }
            return tbno;
        }

        #endregion Arghya2020May

        public VTSDetails COALBPSGetVtsDetails(Stream ReceiveData)
        {
            VTSDetails Vtsd = new VTSDetails();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                VTSRecive Vtsr = new VTSRecive();
                Vtsr = JsonConvert.DeserializeObject<VTSRecive>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(Vtsr.SAPCode))
                {
                    Vtsd.Msg = "SAP Code Cannot be null or empty";
                    Vtsd.StatusCode = "0";
                    return Vtsd;
                }
                if (string.IsNullOrWhiteSpace(Vtsr.ReceiptNo))
                {
                    Vtsd.Msg = "From Date Cannot be null or empty";
                    Vtsd.StatusCode = "0";
                    return Vtsd;
                }

                #endregion

                #region Check Login Data from Data Base
                Vtsd = ba.VtsDetailsData(Vtsr);
                #endregion
            }
            catch (Exception ex)
            {
                Vtsd.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                Vtsd.StatusCode = Message.ExceptionCode;
                return Vtsd;
            }
            return Vtsd;
        }


        #endregion

        #region Send Booking method
        public Booking COALBPSSendBooking(Stream ReceiveData)
        {
            Booking b = new Booking();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                BookingRecive br = new BookingRecive();
                br = JsonConvert.DeserializeObject<BookingRecive>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(br.DONumber))
                {
                    b.Msg = "DO Number Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.MobileNo))
                {
                    b.Msg = "Mobile Number Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.TruckNo))
                {
                    b.Msg = "Truck Number Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                //if (Convert.ToDecimal(br.Quantity) <= 0)
                //{
                //    b.Msg = "Quantity Cannot be null or empty";
                //    b.StatusCode = "0";
                //    return b;
                //}

                #endregion

                #region Check Login Data from Data Base
                b = ba.SendBookingData(br);
                #endregion
            }
            catch (Exception ex)
            {
                b.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                b.StatusCode = Message.ExceptionCode;
                return b;
            }

            return b;
        }
        #endregion

        #region Booking Status method
        public BookingStatus COALBPSBookingStatus(Stream ReceiveData)
        {
            BookingStatus bs = new BookingStatus();
            CategoryID cid = new CategoryID();
            BookingStatusRecive br = new BookingStatusRecive();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                CategoryIDReceive catIDrec = new CategoryIDReceive();
                catIDrec = JsonConvert.DeserializeObject<CategoryIDReceive>(jsonstring);
                cid = ba.CategoryId(catIDrec);
                string a = cid.CatID;
                int i = Convert.ToInt32(a);
                //---------FOR INSTITUTIONAL USER-------
                if (i == 1)
                {
                    br = JsonConvert.DeserializeObject<BookingStatusRecive>(jsonstring);

                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(br.SAPCode))
                    {
                        bs.Msg = "SAP Code Cannot be null or empty";
                        bs.StatusCode = "0";
                        return bs;
                    }
                    #endregion
                    #region Check Login Data from Data Base
                    bs = ba.ReciveBookingStatus(br);
                    #endregion
                }
                //------------FOR NORMAL USER-------------
                else
                {
                    br = JsonConvert.DeserializeObject<BookingStatusRecive>(jsonstring);
                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(br.SAPCode))
                    {
                        bs.Msg = "SAP Code Cannot be null or empty";
                        bs.StatusCode = "0";
                        return bs;
                    }
                    if (string.IsNullOrWhiteSpace(br.ProductID))
                    {
                        bs.Msg = "Product ID Cannot be null or empty";
                        bs.StatusCode = "0";
                        return bs;
                    }
                    #endregion

                    #region Check Login Data from Data Base
                    bs = ba.ReciveBookingStatus(br);
                    #endregion
                }
            }
            catch (Exception ex)
            {
                bs.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                bs.StatusCode = Message.ExceptionCode;
                return bs;
            }

            return bs;
        }
        #endregion

        #region Cancel Booking List method
        public CancelBookingList COALBPSBookingCancelList(Stream ReceiveData)
        {
            CancelBookingList cbl = new CancelBookingList();
            CategoryID cid = new CategoryID();
            CancelBookingListRecive cblr = new CancelBookingListRecive();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                CategoryIDReceive catIDrec = new CategoryIDReceive();
                catIDrec = JsonConvert.DeserializeObject<CategoryIDReceive>(jsonstring);
                cid = ba.CategoryId(catIDrec);
                string a = cid.CatID;
                int i = Convert.ToInt32(a);
                //------------FOR INSTITUTIONAL USER
                if (i == 1)
                {
                    cblr = JsonConvert.DeserializeObject<CancelBookingListRecive>(jsonstring);

                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(cblr.SAPCode))
                    {
                        cbl.Msg = "SAP Code Cannot be null or empty";
                        cbl.StatusCode = "0";
                        return cbl;
                    }
                    #endregion

                    #region Check Login Data from Data Base
                    cbl = ba.ReciveCancelBookingStatus(cblr);
                    #endregion

                }
                //--------FOR NORMAL USER-------
                else
                {
                    cblr = JsonConvert.DeserializeObject<CancelBookingListRecive>(jsonstring);
                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(cblr.SAPCode))
                    {
                        cbl.Msg = "SAP Code Cannot be null or empty";
                        cbl.StatusCode = "0";
                        return cbl;
                    }
                    if (string.IsNullOrWhiteSpace(cblr.ProductID))
                    {
                        cbl.Msg = "Product ID Cannot be null or empty";
                        cbl.StatusCode = "0";
                        return cbl;
                    }
                    #endregion

                    #region Check Login Data from Data Base
                    cbl = ba.ReciveCancelBookingStatus(cblr);
                    #endregion
                }
            }
            catch (Exception ex)
            {
                cbl.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                cbl.StatusCode = Message.ExceptionCode;
                return cbl;
            }

            return cbl;
        }
        #endregion

        #region Cancel Booking method
        public CancelBooking COALBPSBookingCancel(Stream ReceiveData)
        {
            CancelBooking cb = new CancelBooking();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                CancelBookingRecive cbr = new CancelBookingRecive();
                cbr = JsonConvert.DeserializeObject<CancelBookingRecive>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(cbr.SAPCode))
                {
                    cb.Msg = "SAP Code Cannot be null or empty";
                    cb.StatusCode = "0";
                    return cb;
                }
                if (string.IsNullOrWhiteSpace(cbr.DONumber))
                {
                    cb.Msg = "DO Number Cannot be null or empty";
                    cb.StatusCode = "0";
                    return cb;
                }
                if (string.IsNullOrWhiteSpace(cbr.ReceiptNumber))
                {
                    cb.Msg = "Receipt Number Cannot be null or empty";
                    cb.StatusCode = "0";
                    return cb;
                }
                #endregion

                #region Check Login Data from Data Base
                cb = ba.CancelBooking(cbr);
                #endregion
            }
            catch (Exception ex)
            {
                cb.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                cb.StatusCode = Message.ExceptionCode;
                return cb;
            }

            return cb;
        }
        #endregion

        #region Contact Link method
        public ContactLink COALBPSContactLink(Stream ReceiveData)
        {
            ContactLink cl = new ContactLink();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                ContactLinkRecive clr = new ContactLinkRecive();
                clr = JsonConvert.DeserializeObject<ContactLinkRecive>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(clr.SAPCode))
                {
                    cl.Msg = "SAP Code Cannot be null or empty";
                    cl.StatusCode = "0";
                    return cl;
                }
                if (string.IsNullOrWhiteSpace(clr.DONumber))
                {
                    cl.Msg = "DO Number Cannot be null or empty";
                    cl.StatusCode = "0";
                    return cl;
                }
                if (string.IsNullOrWhiteSpace(clr.ReceiptNumber))
                {
                    cl.Msg = "Receipt Number Cannot be null or empty";
                    cl.StatusCode = "0";
                    return cl;
                }
                if (string.IsNullOrWhiteSpace(clr.Query))
                {
                    cl.Msg = "Message Cannot be null or empty";
                    cl.StatusCode = "0";
                    return cl;
                }
                #endregion

                #region Check Login Data from Data Base
                cl = ba.ContactLinkData(clr);
                #endregion
            }
            catch (Exception ex)
            {
                cl.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                cl.StatusCode = Message.ExceptionCode;
                return cl;
            }

            return cl;
        }
        #endregion

        #region Extend Booking List method
        public ExtendBookingList COALBPSBookingExtendList(Stream ReceiveData)
        {
            ExtendBookingList cbl = new ExtendBookingList();
            CategoryID cid = new CategoryID();
            ExtendBookingListRecive cblr = new ExtendBookingListRecive();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                CategoryIDReceive catIDrec = new CategoryIDReceive();
                catIDrec = JsonConvert.DeserializeObject<CategoryIDReceive>(jsonstring);
                cid = ba.CategoryId(catIDrec);
                string a = cid.CatID;
                int i = Convert.ToInt32(a);
                //---------FOR INSTITUTIONAL USER--------
                if (i == 1)
                {
                    cblr = JsonConvert.DeserializeObject<ExtendBookingListRecive>(jsonstring);

                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(cblr.SAPCode))
                    {
                        cbl.Msg = "SAP Code Cannot be null or empty";
                        cbl.StatusCode = "0";
                        return cbl;
                    }
                    #endregion

                    #region Check Login Data from Data Base
                    cbl = ba.ReciveExtendBookingStatus(cblr);
                    #endregion
                }
                //--------------FOR NORMAL USER-------------
                else
                {
                    cblr = JsonConvert.DeserializeObject<ExtendBookingListRecive>(jsonstring);
                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(cblr.SAPCode))
                    {
                        cbl.Msg = "SAP Code Cannot be null or empty";
                        cbl.StatusCode = "0";
                        return cbl;
                    }
                    if (string.IsNullOrWhiteSpace(cblr.ProductID))
                    {
                        cbl.Msg = "Product ID Cannot be null or empty";
                        cbl.StatusCode = "0";
                        return cbl;
                    }
                    #endregion

                    #region Check Login Data from Data Base
                    cbl = ba.ReciveExtendBookingStatus(cblr);
                    #endregion

                }
            }
            catch (Exception ex)
            {
                cbl.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                cbl.StatusCode = Message.ExceptionCode;
                return cbl;
            }

            return cbl;
        }
        #endregion

        #region Extend Booking method
        public ExtendBooking COALBPSBookingExtend(Stream ReceiveData)
        {
            ExtendBooking cb = new ExtendBooking();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                ExtendBookingRecive cbr = new ExtendBookingRecive();
                cbr = JsonConvert.DeserializeObject<ExtendBookingRecive>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(cbr.SAPCode))
                {
                    cb.Msg = "SAP Code Cannot be null or empty";
                    cb.StatusCode = "0";
                    return cb;
                }
                if (string.IsNullOrWhiteSpace(cbr.DONumber))
                {
                    cb.Msg = "DO Number Cannot be null or empty";
                    cb.StatusCode = "0";
                    return cb;
                }
                if (string.IsNullOrWhiteSpace(cbr.ReceiptNumber))
                {
                    cb.Msg = "Receipt Number Cannot be null or empty";
                    cb.StatusCode = "0";
                    return cb;
                }
                #endregion

                #region Check Login Data from Data Base
                cb = ba.ExtendBooking(cbr);
                #endregion
            }
            catch (Exception ex)
            {
                cb.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                cb.StatusCode = Message.ExceptionCode;
                return cb;
            }

            return cb;
        }
        #endregion

        #region Approve Booking List
        public ApproveBookingStatus COALBPSApproveBookingStatus(Stream ReceiveData)
        {
            ApproveBookingStatus bs = new ApproveBookingStatus();
            CategoryID cid = new CategoryID();
            ApproveBookingListRecive bsr = new ApproveBookingListRecive();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                CategoryIDReceive catIDrec = new CategoryIDReceive();
                catIDrec = JsonConvert.DeserializeObject<CategoryIDReceive>(jsonstring);
                cid = ba.CategoryId(catIDrec);
                string a = cid.CatID;
                int i = Convert.ToInt32(a);
                //---------FOR INSTITUTIONAL USER-------
                if (i == 1)
                {
                    bsr = JsonConvert.DeserializeObject<ApproveBookingListRecive>(jsonstring);

                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(bsr.SAPCode))
                    {
                        bs.Msg = "SAP Code Cannot be null or empty";
                        bs.StatusCode = "0";
                        return bs;
                    }
                    #endregion
                    #region Check Login Data from Data Base
                    bs = ba.ReciveApproveBookingStatus(bsr);
                    #endregion
                }
                //------------FOR NORMAL USER-------------
                else
                {
                    bsr = JsonConvert.DeserializeObject<ApproveBookingListRecive>(jsonstring);
                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(bsr.SAPCode))
                    {
                        bs.Msg = "SAP Code Cannot be null or empty";
                        bs.StatusCode = "0";
                        return bs;
                    }
                    if (string.IsNullOrWhiteSpace(bsr.ProductID))
                    {
                        bs.Msg = "Product ID Cannot be null or empty";
                        bs.StatusCode = "0";
                        return bs;
                    }
                    #endregion

                    #region Check Login Data from Data Base
                    bs = ba.ReciveApproveBookingStatus(bsr);
                    #endregion
                }
            }
            catch (Exception ex)
            {
                bs.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                bs.StatusCode = Message.ExceptionCode;
                return bs;
            }

            return bs;
        }
        #endregion

        #region confirm Booking List
        public ApproveBookingStatus COALBPSConfirmBookingStatus(Stream ReceiveData)
        {
            ApproveBookingStatus bs = new ApproveBookingStatus();
            CategoryID cid = new CategoryID();
            ApproveBookingListRecive bsr = new ApproveBookingListRecive();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                CategoryIDReceive catIDrec = new CategoryIDReceive();
                catIDrec = JsonConvert.DeserializeObject<CategoryIDReceive>(jsonstring);
                cid = ba.CategoryId(catIDrec);
                string a = cid.CatID;
                int i = Convert.ToInt32(a);
                //---------FOR INSTITUTIONAL USER-------
                if (i == 1)
                {
                    bsr = JsonConvert.DeserializeObject<ApproveBookingListRecive>(jsonstring);

                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(bsr.SAPCode))
                    {
                        bs.Msg = "SAP Code Cannot be null or empty";
                        bs.StatusCode = "0";
                        return bs;
                    }
                    #endregion
                    #region Check Login Data from Data Base
                    bs = ba.ReciveConfirmBookingList(bsr);
                    #endregion
                }
                //------------FOR NORMAL USER-------------
                else
                {
                    bsr = JsonConvert.DeserializeObject<ApproveBookingListRecive>(jsonstring);
                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(bsr.SAPCode))
                    {
                        bs.Msg = "SAP Code Cannot be null or empty";
                        bs.StatusCode = "0";
                        return bs;
                    }
                    if (string.IsNullOrWhiteSpace(bsr.ProductID))
                    {
                        bs.Msg = "Product ID Cannot be null or empty";
                        bs.StatusCode = "0";
                        return bs;
                    }
                    #endregion

                    #region Check Login Data from Data Base
                    bs = ba.ReciveConfirmBookingList(bsr);
                    #endregion
                }
            }
            catch (Exception ex)
            {
                bs.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                bs.StatusCode = Message.ExceptionCode;
                return bs;
            }

            return bs;
        }
        #endregion

        //#region Customer Contact Link method
        //public CustomerContactLink COALBPSCustomerContactLink(Stream ReceiveData)
        //{
        //    CustomerContactLink cl = new CustomerContactLink();

        //    try
        //    {
        //        byte[] data = ReadToEnd(ReceiveData);
        //        string jsonstring = Encoding.UTF8.GetString(data);
        //        CustomerContactLinkRecive clr = new CustomerContactLinkRecive();
        //        clr = JsonConvert.DeserializeObject<CustomerContactLinkRecive>(jsonstring);
        //        #region Checking Condition for Empty or Null Value
        //        if (string.IsNullOrWhiteSpace(clr.SAPCode))
        //        {
        //            cl.Msg = "SAP Code Cannot be null or empty";
        //            cl.StatusCode = "0";
        //            return cl;
        //        }

        //        if (string.IsNullOrWhiteSpace(clr.Query))
        //        {
        //            cl.Msg = "Message Cannot be null or empty";
        //            cl.StatusCode = "0";
        //            return cl;
        //        }
        //        #endregion

        //        #region Check Login Data from Data Base
        //        cl = ba.CustomerContactLinkData(clr);
        //        #endregion
        //    }
        //    catch (Exception ex)
        //    {
        //        cl.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
        //        cl.StatusCode = Message.ExceptionCode;
        //        return cl;
        //    }

        //    return cl;
        //}
        //#endregion

        #region refund Request method
        public RefundRequest COALBPSRefundRequest(Stream ReceiveData)
        {
            RefundRequest rr = new RefundRequest();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                RefundRequestRecive rrr = new RefundRequestRecive();
                rrr = JsonConvert.DeserializeObject<RefundRequestRecive>(jsonstring);

                #region Check Login Data from Data Base
                rr = ba.RefundRequestData(rrr);
                #endregion
            }
            catch (Exception ex)
            {
                rr.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                rr.StatusCode = Message.ExceptionCode;
                return rr;
            }

            return rr;
        }
        #endregion

        #region OTP Request method
        public CustomerDetails COALBPSOTPRequest(Stream ReceiveData)
        {
            CustomerDetails rr = new CustomerDetails();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                OTPRecive rrr = new OTPRecive();
                rrr = JsonConvert.DeserializeObject<OTPRecive>(jsonstring);

                #region Check Login Data from Data Base
                rr = ba.GenerateOTPandValidate(rrr);
                #endregion
            }
            catch (Exception ex)
            {
                rr.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                rr.StatusCode = Message.ExceptionCode;
                return rr;
            }

            return rr;
        }
        #endregion

        #region Update Truck method
        public TruckUpdate COALBPSUpdateTruck(Stream ReceiveData)
        {
            TruckUpdate b = new TruckUpdate();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                TruckUpdateRecive br = new TruckUpdateRecive();
                br = JsonConvert.DeserializeObject<TruckUpdateRecive>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(br.BookingID))
                {
                    b.Msg = "Booking Number Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.MobileNo))
                {
                    b.Msg = "Mobile Number Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.TruckNo))
                {
                    b.Msg = "Truck Number Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }

                #endregion

                #region Check Login Data from Data Base
                b = ba.UpdateTruckData(br);
                #endregion
            }
            catch (Exception ex)
            {
                b.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                b.StatusCode = Message.ExceptionCode;
                return b;
            }

            return b;
        }
        #endregion

        #region  Truck Change
        //bijoy
        public TruckChangeUpdate COALBPSTruckChange(Stream ReceiveData)
        {
            TruckChangeUpdate b = new TruckChangeUpdate();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                TruckChangeUpdate br = new TruckChangeUpdate();
                br = JsonConvert.DeserializeObject<TruckChangeUpdate>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(br.BookingID))
                {
                    b.Msg = "Booking Number Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.ChangedTrukno))
                {
                    b.Msg = "Truk Number Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.UserID))
                {
                    b.Msg = "User Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.DeviceID))
                {
                    b.Msg = "Device ID Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                #endregion

                #region Check Login Data from Data Base
                b = ba.UpdateTruckChangData(br);
                #endregion
            }
            catch (Exception ex)
            {
                b.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                b.StatusCode = Message.ExceptionCode;
                return b;
            }

            return b;
        }


        public TruckChangeList COALBPSTruckChangeList(Stream ReceiveData)
        {
            TruckChangeList b = new TruckChangeList();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                RecivedTrukchageRequest br = new RecivedTrukchageRequest();
                br = JsonConvert.DeserializeObject<RecivedTrukchageRequest>(jsonstring);
                #region Checking Condition for Empty or Null Value

                if (string.IsNullOrWhiteSpace(br.UserID))
                {
                    b.Msg = "User Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.Role))
                {
                    b.Msg = "Role Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }

                #endregion

                b = ba.TruckChageList(br);

            }
            catch (Exception ex)
            {
                b.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                b.StatusCode = Message.ExceptionCode;
                return b;
            }

            return b;
        }

        public TruckChangeUpdate COALBPSApproveRejectTruckChange(Stream ReceiveData)
        {
            TruckChangeUpdate b = new TruckChangeUpdate();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                RecivedTrukchageApproveRequest br = new RecivedTrukchageApproveRequest();
                br = JsonConvert.DeserializeObject<RecivedTrukchageApproveRequest>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(br.BookingID))
                {
                    b.Msg = "Booking Number Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.Status))
                {
                    b.Msg = "User must aprove or reject";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.truckno))
                {
                    b.Msg = "Truck number cannot be empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.RoleFlag))
                {
                    b.Msg = "Role cannot be empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.UserID))
                {
                    b.Msg = "User Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }

                #endregion

                #region Check Login Data from Data Base
                b = ba.ApproveRejectTruckChange(br);
                #endregion
            }
            catch (Exception ex)
            {
                b.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                b.StatusCode = Message.ExceptionCode;
                return b;
            }

            return b;
        }
        #endregion


        #region Update BookPin
        public BookPinUpdate COALBPSUpdateBookPin(Stream ReceiveData)
        {
            BookPinUpdate b = new BookPinUpdate();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                BookPinRecive br = new BookPinRecive();
                br = JsonConvert.DeserializeObject<BookPinRecive>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(br.BookPinNo))
                {
                    b.Msg = "Booking PIN Number Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.BookingID))
                {
                    b.Msg = "Booking Number Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }


                #endregion

                #region Check Data from Data Base
                b = ba.UpdatePinData(br);
                #endregion
            }
            catch (Exception ex)
            {
                b.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                b.StatusCode = Message.ExceptionCode;
                return b;
            }

            return b;
        }
        #endregion BookPin




        #region Suman

        #region Invoice history
        public InvoiceHistoryList COALBPSInvoiceHistory(Stream ReceiveData)
        {
            InvoiceHistoryList invHst = new InvoiceHistoryList();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                InvoiceHistoryRcv br = new InvoiceHistoryRcv();
                br = JsonConvert.DeserializeObject<InvoiceHistoryRcv>(jsonstring);

                #region Checking Condition for Empty or Null Value

                DateTime Fromdt = new DateTime();
                DateTime Todt = new DateTime();
                bool ISTodt = true;
                bool ISFromdt = true;

                if (ISTodt = Utility.IsDate(br.ToDate))
                {
                    Todt = Utility.ConvertDate(br.ToDate);
                }

                if (ISFromdt = Utility.IsDate(br.FromDate))
                {
                    Fromdt = Utility.ConvertDate(br.FromDate);
                }

                if (string.IsNullOrWhiteSpace(br.ToDate))
                {
                    invHst.Msg = Message.InvoiceHistCheckToDateMsg;
                    invHst.StatusCode = Message.InvoiceHistCheckToDateCode;
                    return invHst;
                }
                else
                {
                    //if (Todt != Utility.ConvertDate(DateTime.Now.AddDays(-1).ToShortDateString()))
                    DateTime dt = Utility.ConvertDate(DateTime.Now.ToShortDateString());
                    if (Todt >= dt)
                    {
                        invHst.Msg = Message.InvoiceHistCheckYesDateMsg;
                        invHst.StatusCode = Message.InvoiceHistCheckYesDateCode;
                        return invHst;
                    }
                }

                if (string.IsNullOrWhiteSpace(br.FromDate))
                {
                    invHst.Msg = Message.InvoiceHistCheckFrmDateMsg;
                    invHst.StatusCode = Message.InvoiceHistCheckFrmDateCode;
                    return invHst;
                }
                if (string.IsNullOrWhiteSpace(br.CustomerID))
                {
                    invHst.Msg = Message.InvoiceHistCustIDMsg;
                    invHst.StatusCode = Message.InvoiceHistCustIDCode;
                    return invHst;
                }

                if (Todt != null && Fromdt != null)
                {
                    if (Todt < Fromdt)
                    {
                        invHst.Msg = Message.InvoiceHistValidDtRngMsg;
                        invHst.StatusCode = Message.InvoiceHistValidDtRngCode;
                        return invHst;
                    }

                    int dtrange = Utility.DayDateRange(br.FromDate, br.ToDate);
                    if (dtrange > 7)
                    {
                        invHst.Msg = Message.InvoiceHistDtRngMsg;
                        invHst.StatusCode = Message.InvoiceHistDtRngCode;
                        return invHst;
                    }
                }
                #endregion

                #region Check Login Data from Data Base
                invHst = ba.doInvoiceHistory(br);
                #endregion
            }
            catch (Exception ex)
            {
                invHst.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                invHst.StatusCode = Message.ExceptionCode;
                return invHst;
            }

            return invHst;
        }
        #endregion

        #region Payment history
        public PaymentHistoryList COALBPSPaymentHistory(Stream ReceiveData)
        {
            PaymentHistoryList PayHst = new PaymentHistoryList();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                PaymentHistoryRcv br = new PaymentHistoryRcv();
                br = JsonConvert.DeserializeObject<PaymentHistoryRcv>(jsonstring);

                #region Checking Condition for Empty or Null Value

                DateTime Fromdt = new DateTime();
                DateTime Todt = new DateTime();
                bool ISTodt = true;
                bool ISFromdt = true;

                if (ISTodt == Utility.IsDate(br.ToDate))
                {
                    Todt = Utility.ConvertDate(br.ToDate);
                }

                if (ISFromdt == Utility.IsDate(br.FromDate))
                {
                    Fromdt = Utility.ConvertDate(br.FromDate);
                }

                if (string.IsNullOrWhiteSpace(br.ToDate))
                {
                    PayHst.Msg = Message.InvoiceHistCheckToDateMsg;
                    PayHst.StatusCode = Message.InvoiceHistCheckToDateCode;
                    return PayHst;
                }
                else
                {
                    //if (Todt != Utility.ConvertDate(DateTime.Now.AddDays(-1).ToShortDateString()))

                    DateTime dt = Utility.ConvertDate(DateTime.Now.ToShortDateString());
                    if (Todt > dt)
                    {
                        PayHst.Msg = Message.InvoiceHistCheckYesDateMsg;
                        PayHst.StatusCode = Message.InvoiceHistCheckYesDateCode;
                        return PayHst;
                    }
                }

                if (string.IsNullOrWhiteSpace(br.FromDate))
                {
                    PayHst.Msg = Message.InvoiceHistCheckFrmDateMsg;
                    PayHst.StatusCode = Message.InvoiceHistCheckFrmDateCode;
                    return PayHst;
                }
                if (string.IsNullOrWhiteSpace(br.CustomerID))
                {
                    PayHst.Msg = Message.InvoiceHistCustIDMsg;
                    PayHst.StatusCode = Message.InvoiceHistCustIDCode;
                    return PayHst;
                }

                if (Todt != null && Fromdt != null)
                {
                    if (Todt < Fromdt)
                    {
                        PayHst.Msg = Message.InvoiceHistValidDtRngMsg;
                        PayHst.StatusCode = Message.InvoiceHistValidDtRngCode;
                        return PayHst;
                    }

                    int dtrange = Utility.DayDateRange(br.FromDate, br.ToDate);
                    if (dtrange > 7)
                    {
                        PayHst.Msg = Message.InvoiceHistDtRngMsg;
                        PayHst.StatusCode = Message.InvoiceHistDtRngCode;
                        return PayHst;
                    }
                }
                #endregion

                #region Check Login Data from Data Base
                PayHst = ba.doPaymentHistory(br);
                #endregion
            }
            catch (Exception ex)
            {
                PayHst.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                PayHst.StatusCode = Message.ExceptionCode;
                return PayHst;
            }

            return PayHst;
        }
        #endregion
        #endregion

        #region Sayantan

        public RefundResponseRequestList COALBPSResponseRequest(Stream ReceiveData)
        {
            RefundResponseRequestList rrl = new RefundResponseRequestList();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                RecivedRefundRequest rrr = new RecivedRefundRequest();
                rrr = JsonConvert.DeserializeObject<RecivedRefundRequest>(jsonstring);

                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(rrr.CustomerSAPCode))
                {
                    rrl.Msg = Message.ResponseCustIdErrorMsg;
                    rrl.StatusCode = Message.ResponseCustIdErrorCode;
                    return rrl;
                }
                if (!(string.IsNullOrWhiteSpace(rrr.FromDate) || string.IsNullOrWhiteSpace(rrr.ToDate)))
                {
                    if (Utility.IsValidDateRange(rrr.FromDate, rrr.ToDate) == false)
                    {
                        rrl.Msg = Message.ResponseDateRangeErrorMsg;
                        rrl.StatusCode = Message.ResponseDateRangeErrorCode;
                        return rrl;
                    }
                }
                if (!(string.IsNullOrWhiteSpace(rrr.RefundRequestID)))
                {
                    string strId = rrr.RefundRequestID.ToString();
                    if (strId.Split('/').Count() == 4)
                    {
                        int outresult;
                        if (Int32.TryParse(strId.Substring(strId.LastIndexOf('/') + 1), out outresult))
                        {
                            rrr.RefundRequestID = strId.Substring(strId.LastIndexOf('/') + 1);
                        }
                        else
                        {
                            rrl.Msg = Message.ResponseWrongResponseID;
                            rrl.StatusCode = Message.ResponseWrongResponseIDErrorCode;
                            return rrl;
                        }
                    }
                    else
                    {
                        rrl.Msg = Message.ResponseWrongResponseID;
                        rrl.StatusCode = Message.ResponseWrongResponseIDErrorCode;
                        return rrl;
                    }
                }


                #endregion

                #region Check Login Data from Data Base
                rrl = ba.ResponseData(rrr);
                #endregion
            }
            catch (Exception ex)
            {
                rrl.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                rrl.StatusCode = Message.ExceptionCode;
                return rrl;
            }

            return rrl;
        }


        public ResendSmsStat COALBPSResendSmsRequest(Stream ReceiveData)
        {
            ResendSmsStat rsl = new ResendSmsStat();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                ResendSmsData rsd = new ResendSmsData();
                rsd = JsonConvert.DeserializeObject<ResendSmsData>(jsonstring);

                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(rsd.Custid))
                {
                    rsl.Msg = Message.ResendSmsCustIdErrorMsg;
                    rsl.StatusCode = Message.ResendSmsCustIdErrorCode;
                    return rsl;
                }
                if (string.IsNullOrEmpty(rsd.BkdId))
                {
                    rsl.Msg = Message.ResendSmsBkdIdErrorMsg;
                    rsl.StatusCode = Message.ResendSmsBkdIdErrorCode;
                    return rsl;
                }

                #endregion

                #region Check Login Data from Data Base
                rsl = ba.ResponseSmsData(rsd);
                #endregion
            }
            catch (Exception ex)
            {
                rsl.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                rsl.StatusCode = Message.ExceptionCode;
                return rsl;
            }

            return rsl;
        }
        #endregion

        #region Debojyoti
        #region Customer Contact Link method
        public CustomerContactLink COALBPSCustomerContactLink(Stream ReceiveData)
        {
            CustomerContactLink cl = new CustomerContactLink();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                CustomerContactLinkRecive clr = new CustomerContactLinkRecive();
                clr = JsonConvert.DeserializeObject<CustomerContactLinkRecive>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(clr.SAPCode))
                {
                    cl.Msg = "SAP Code Cannot be null or empty";
                    cl.StatusCode = "0";
                    return cl;
                }

                if (string.IsNullOrWhiteSpace(clr.Query))
                {
                    cl.Msg = "Message Cannot be null or empty";
                    cl.StatusCode = "0";
                    return cl;
                }
                #endregion

                #region Check Login Data from Data Base
                cl = ba.CustomerContactLinkData(clr);
                #endregion
            }
            catch (Exception ex)
            {
                cl.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                cl.StatusCode = Message.ExceptionCode;
                return cl;
            }

            return cl;
        }
        #endregion

        #region COALBPS Booking History
        public BookingHistoryStatus COALBPSBookingHistory(Stream ReceiveData)
        {
            BookingHistoryStatus bhs = new BookingHistoryStatus();
            CategoryID cid = new CategoryID();
            BookingHistoryRequest bh = new BookingHistoryRequest();


            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                CategoryIDReceive catIDrec = new CategoryIDReceive();
                catIDrec = JsonConvert.DeserializeObject<CategoryIDReceive>(jsonstring);
                cid = ba.CategoryId(catIDrec);
                string a = cid.CatID;
                int i = Convert.ToInt32(a);
                //---------FOR INSTITUTIONAL USER--------------
                if (i == 1)
                {
                    bh = JsonConvert.DeserializeObject<BookingHistoryRequest>(jsonstring);

                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(bh.FromDate))
                    {
                        bhs.Msg = "From Date Cannot be null or empty";
                        bhs.StatusCode = "0";
                        return bhs;
                    }
                    if (string.IsNullOrWhiteSpace(bh.ToDate))
                    {
                        bhs.Msg = "To Date Cannot be null or empty";
                        bhs.StatusCode = "0";
                        return bhs;
                    }
                    if ((Convert.ToDateTime(bh.FromDate)) >= DateTime.Today)
                    {
                        bhs.Msg = "From date must be less than from today";
                        bhs.StatusCode = "0";
                        return bhs;
                    }

                    if ((Convert.ToDateTime(bh.ToDate)) >= DateTime.Today)
                    {
                        bhs.Msg = "To date must be less than from today";
                        bhs.StatusCode = "0";
                        return bhs;
                    }
                    if ((Convert.ToDateTime(bh.FromDate)) > (Convert.ToDateTime(bh.ToDate)))
                    {
                        bhs.Msg = "From date must be less than from ToDate";
                        bhs.StatusCode = "0";
                        return bhs;
                    }
                    var dayys = (Convert.ToDateTime(bh.ToDate) - Convert.ToDateTime(bh.FromDate)).TotalDays;
                    if (dayys > 6.0)
                    {
                        bhs.Msg = "Form date and To date difference not be more than 7 days";
                        bhs.StatusCode = "0";
                        return bhs;
                    }
                    #endregion
                    #region Check Login Data from Data Base
                    bhs = ba.BookingHistory(bh);
                    #endregion
                }
                //-----------FOR NORMAL USER----------
                else
                {
                    bh = JsonConvert.DeserializeObject<BookingHistoryRequest>(jsonstring);
                    #region Checking Condition for Empty or Null Value
                    if (string.IsNullOrWhiteSpace(bh.CustID))
                    {
                        bhs.Msg = "Customer Id Cannot be null or empty";
                        bhs.StatusCode = "0";
                        return bhs;
                    }
                    if (string.IsNullOrWhiteSpace(bh.ProductID))
                    {
                        bhs.Msg = "Product Id Cannot be null or empty";
                        bhs.StatusCode = "0";
                        return bhs;
                    }
                    if (string.IsNullOrWhiteSpace(bh.SourceID))
                    {
                        bhs.Msg = "Source Cannot be null or empty";
                        bhs.StatusCode = "0";
                        return bhs;
                    }
                    if (string.IsNullOrWhiteSpace(bh.LocationID))
                    {
                        bhs.Msg = "Location Cannot be null or empty";
                        bhs.StatusCode = "0";
                        return bhs;
                    }
                    if (string.IsNullOrWhiteSpace(bh.FromDate))
                    {
                        bhs.Msg = "From Date Cannot be null or empty";
                        bhs.StatusCode = "0";
                        return bhs;
                    }
                    if (string.IsNullOrWhiteSpace(bh.ToDate))
                    {
                        bhs.Msg = "To Date Cannot be null or empty";
                        bhs.StatusCode = "0";
                        return bhs;
                    }
                    if ((Convert.ToDateTime(bh.FromDate)) >= DateTime.Today)
                    {
                        bhs.Msg = "From date must be less than from today";
                        bhs.StatusCode = "0";
                        return bhs;
                    }
                    //bool isYesterday = DateTime.Today - Convert.ToDateTime(bh.ToDate).Date == TimeSpan.FromDays(1);
                    //if (!isYesterday)
                    //{
                    //    bhs.Msg = "To Date must be yesterday";
                    //    bhs.StatusCode = "0";
                    //    return bhs;
                    //}
                    if ((Convert.ToDateTime(bh.ToDate)) >= DateTime.Today)
                    {
                        bhs.Msg = "To date must be less than from today";
                        bhs.StatusCode = "0";
                        return bhs;
                    }
                    if ((Convert.ToDateTime(bh.FromDate)) > (Convert.ToDateTime(bh.ToDate)))
                    {
                        bhs.Msg = "From date must be less than from ToDate";
                        bhs.StatusCode = "0";
                        return bhs;
                    }
                    var dayys = (Convert.ToDateTime(bh.ToDate) - Convert.ToDateTime(bh.FromDate)).TotalDays;
                    if (dayys > 6.0)
                    {
                        bhs.Msg = "Form date and To date difference not be more than 7 days";
                        bhs.StatusCode = "0";
                        return bhs;
                    }
                    #endregion

                    #region Check Login Data from Data Base
                    bhs = ba.BookingHistory(bh);
                    #endregion
                }
            }
            catch (Exception ex)
            {
                bhs.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                bhs.StatusCode = Message.ExceptionCode;
                return bhs;
            }
            return bhs;
        }
        #endregion

        #region FEEDBACK COMMUNICATION
        public FeedbackCommunicationStatus COALBPSFeedbackCommunication(Stream ReceiveData)
        {
            FeedbackCommunicationStatus fcS = new FeedbackCommunicationStatus();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                FeedbackCommunicationRequest fc = new FeedbackCommunicationRequest();
                fc = JsonConvert.DeserializeObject<FeedbackCommunicationRequest>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(fc.CustID))
                {
                    fcS.Msg = "Customer Id Cannot be null or empty";
                    fcS.StatusCode = "0";
                    return fcS;
                }
                if ((string.IsNullOrWhiteSpace(fc.FromDate)) & (string.IsNullOrWhiteSpace(fc.ToDate)) & (string.IsNullOrWhiteSpace(fc.Receipt_Number)))
                {
                    fcS.Msg = "Enter From date and To Date or Receipt Number";
                    fcS.StatusCode = "0";
                    return fcS;
                }
                if ((string.IsNullOrWhiteSpace(fc.FromDate)) & (!string.IsNullOrWhiteSpace(fc.ToDate)))
                {
                    fcS.Msg = "From Date Cannot be null or empty";
                    fcS.StatusCode = "0";
                    return fcS;
                }
                if ((!string.IsNullOrWhiteSpace(fc.FromDate)) & (string.IsNullOrWhiteSpace(fc.ToDate)))
                {
                    fcS.Msg = "To Date Cannot be null or empty";
                    fcS.StatusCode = "0";
                    return fcS;
                }
                if (!string.IsNullOrWhiteSpace(fc.FromDate))
                {
                    if ((Convert.ToDateTime(fc.FromDate)) > DateTime.Today)
                    {
                        fcS.Msg = "From date must be less than from today";
                        fcS.StatusCode = "0";
                        return fcS;
                    }
                }
                if (!string.IsNullOrWhiteSpace(fc.ToDate))
                {
                    if ((Convert.ToDateTime(fc.ToDate)) > DateTime.Today)
                    {
                        fcS.Msg = "Todate not more than today's date.";
                        fcS.StatusCode = "0";
                        return fcS;
                    }
                }
                if (!string.IsNullOrWhiteSpace(fc.FromDate))
                {
                    if ((Convert.ToDateTime(fc.FromDate)) > (Convert.ToDateTime(fc.ToDate)))
                    {
                        fcS.Msg = "From date must be less than or equal from ToDate";
                        fcS.StatusCode = "0";
                        return fcS;
                    }
                }
                if (!(string.IsNullOrWhiteSpace(fc.Receipt_Number)))
                {
                    string strId = fc.Receipt_Number.ToString();
                    if (strId.Split('/').Count() == 4)
                    {
                        int outresult;
                        if (Int32.TryParse(strId.Substring(strId.LastIndexOf('/') + 1), out outresult))
                        {
                            //rrr.RefundRequestID = strId.Substring(strId.LastIndexOf('/') + 1);
                        }
                        else
                        {
                            fcS.Msg = Message.FeedbackWrongResponseID;
                            fcS.StatusCode = Message.FeedbackWrongResponseIDErrorCode;
                            return fcS;
                        }
                    }
                    else
                    {
                        fcS.Msg = Message.FeedbackWrongResponseID;
                        fcS.StatusCode = Message.FeedbackWrongResponseIDErrorCode;
                        return fcS;
                    }
                }
                //if ((!string.IsNullOrWhiteSpace(fc.FromDate)) & (!string.IsNullOrWhiteSpace(fc.ToDate)))
                //{
                //    var dayys = (Convert.ToDateTime(fc.ToDate) - Convert.ToDateTime(fc.FromDate)).TotalDays;
                //    if (dayys > 6.0)
                //    {
                //        fcS.Msg = "Form date and To date difference not be more than 7 days";
                //        fcS.StatusCode = "0";
                //        return fcS;
                //    }
                //}
                #endregion

                #region Check Login Data from Data Base
                fcS = ba.FeedbackCommunication(fc);
                #endregion
            }
            catch (Exception ex)
            {
                fcS.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                fcS.StatusCode = Message.ExceptionCode;
                return fcS;
            }
            return fcS;
        }
        #endregion

        #region ADD BACK
        public AddBackReceive COALBPSAddBack(Stream ReceiveData)
        {
            AddBackReceive adbr = new AddBackReceive();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                AddBackRequest adb = new AddBackRequest();
                adb = JsonConvert.DeserializeObject<AddBackRequest>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(adb.BookingID))
                {
                    adbr.Msg = "Booking Id Cannot be null or empty";
                    adbr.StatusCode = "0";
                    return adbr;
                }
                #endregion

                #region Check Login Data from Data Base
                adbr = ba.AddBack(adb);
                #endregion
            }
            catch (Exception ex)
            {
                adbr.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                adbr.StatusCode = Message.ExceptionCode;
                return adbr;
            }
            return adbr;
        }
        #endregion

        #region AppInfo
        public CustomerAppInfoReceive COALBPSAppInfo()
        {
            CustomerAppInfoReceive air = new CustomerAppInfoReceive();
            try
            {
                air = ba.AppInfo();
            }
            catch (Exception ex)
            {
                air.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                air.StatusCode = Message.ExceptionCode;
                return air;
            }
            return air;
        }
        #endregion
        #endregion

        #region MobileVersion

        public MobileVersion COALBPSGetMobileVersion(Stream ReceiveData)
        {

            MobileVersion cd = new MobileVersion();
            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                MobileVersion lgnPin = new MobileVersion();
                lgnPin = JsonConvert.DeserializeObject<MobileVersion>(jsonstring);


                //if (string.IsNullOrWhiteSpace(lgnPin.PinNo))
                //{
                //    cd.Msg = "Pin Number Cannot be null or empty";
                //    cd.StatusCode = "0";
                //    return cd;
                //}

                #endregion

        #region Check Login Data from Data Base
                cd = ba.Getmobileversion(lgnPin);

                #endregion



            }
            catch (Exception ex)
            {
                cd.Message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                cd.StatusCode = Message.ExceptionCode;
                return cd;
            }
            return cd;
        }

        public MobileVersion COALBPSUpdateMobileVersion(Stream ReceiveData)
        {


            MobileVersion b = new MobileVersion();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                MobileVersionRecive br = new MobileVersionRecive();
                br = JsonConvert.DeserializeObject<MobileVersionRecive>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(br.NewVersion))
                {
                    b.Message = "Mobile Version Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }



                #endregion

                #region Check Data from Data Base
                b = ba.UpdateMobileVersion(br);



            }
            catch (Exception ex)
            {
                b.Message = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                b.StatusCode = Message.ExceptionCode;
                return b;
            }

            return b;
        }
        #endregion MobileVersion

        #region Survey
        public QuestionList COALBPSQuestionList(Stream ReceiveData)
        {
            QuestionList b = new QuestionList();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                ReceivedQueston br = new ReceivedQueston();
                br = JsonConvert.DeserializeObject<ReceivedQueston>(jsonstring);
                #region Checking Condition for Empty or Null Value

                if (string.IsNullOrWhiteSpace(br.CustID))
                {
                    b.Msg = "Customer ID Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
   
                #endregion

                b = ba.QuestonList(br);

            }
            catch (Exception ex)
            {
                b.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                b.StatusCode = Message.ExceptionCode;
                return b;
            }

            return b;
        }

        public UpdateAnswer COALBPSSubmitAnswer(Stream ReceiveData)
        {
            UpdateAnswer b = new UpdateAnswer();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                ReceivedAnswer br = new ReceivedAnswer();
                br = JsonConvert.DeserializeObject<ReceivedAnswer>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(br.SurveyID))
                {
                    b.Msg = "Survey ID Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.CustId))
                {
                    b.Msg = "Customer ID Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
               
                #endregion

                #region Check Login Data from Data Base
                b = ba.UpdateAnswer(br);
                #endregion
            }
            catch (Exception ex)
            {
                b.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                b.StatusCode = Message.ExceptionCode;
                return b;
            }

            return b;
        }
        #endregion
        #region Complain
        public UpdateComplain COALBPSLodgeComplain(Stream ReceiveData)
        {
            UpdateComplain b = new UpdateComplain();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                ReceivedComplain br = new ReceivedComplain();
                br = JsonConvert.DeserializeObject<ReceivedComplain>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(br.ComplainDetails))
                {
                    b.Msg = "Complain Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.CustID))
                {
                    b.Msg = "Customer Code Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
               

                #endregion

                #region Check Login Data from Data Base
                b = ba.LodgeComplain(br);
                #endregion
            }
            catch (Exception ex)
            {
                b.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                b.StatusCode = Message.ExceptionCode;
                return b;
            }

            return b;
        }

        public UpdateReply COALBPSSubmitReply(Stream ReceiveData)
        {
            UpdateReply b = new UpdateReply();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                ReceivedReply br = new ReceivedReply();
                br = JsonConvert.DeserializeObject<ReceivedReply>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(br.ComplainID))
                {
                    b.Msg = "Complain ID Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.ReplyDetails))
                {
                    b.Msg = "Reply Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.RepliedBy))
                {
                    b.Msg = "Replyid Persion ID cannot be null";
                    b.StatusCode = "0";
                    return b;
                }

                #endregion

                #region Check Login Data from Data Base
                b = ba.SubmitReply(br);
                #endregion
            }
            catch (Exception ex)
            {
                b.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                b.StatusCode = Message.ExceptionCode;
                return b;
            }

            return b;
        }

        public ComplainList COALBPSComplainList(Stream ReceiveData)
        {
            ComplainList b = new ComplainList();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                RcvdComplain br = new RcvdComplain();
                br = JsonConvert.DeserializeObject<RcvdComplain>(jsonstring);
                #region Checking Condition for Empty or Null Value

                if (string.IsNullOrWhiteSpace(br.CustID))
                {
                    b.Msg = "Customer ID Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                #endregion
                b = ba.GetComplains(br);

            }
            catch (Exception ex)
            {
                b.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                b.StatusCode = Message.ExceptionCode;
                return b;
            }

            return b;
        }

        public ReplyList COALBPSReplyList(Stream ReceiveData)
        {
            ReplyList b = new ReplyList();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                RcvdReply br = new RcvdReply();
                br = JsonConvert.DeserializeObject<RcvdReply>(jsonstring);
                #region Checking Condition for Empty or Null Value

                if (string.IsNullOrWhiteSpace(br.ComplainID))
                {
                    b.Msg = "Complain ID Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }

                #endregion

                b = ba.ReplyList(br);

            }
            catch (Exception ex)
            {
                b.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                b.StatusCode = Message.ExceptionCode;
                return b;
            }

            return b;
        }

        public UpdateComplain COALBPSCloseComplain(Stream ReceiveData)
        {
            UpdateComplain b = new UpdateComplain();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                RcvdReply br = new RcvdReply();
                br = JsonConvert.DeserializeObject<RcvdReply>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(br.ComplainID))
                {
                    b.Msg = "Complain ID Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                
                #endregion

                #region Check Login Data from Data Base
                b = ba.CloseComplain(br);
                #endregion
            }
            catch (Exception ex)
            {
                b.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                b.StatusCode = Message.ExceptionCode;
                return b;
            }

            return b;
        }

        public UpdateQty COALBPSChangeQty(Stream ReceiveData)
        {
            UpdateQty b = new UpdateQty();

            try
            {
                byte[] data = ReadToEnd(ReceiveData);
                string jsonstring = Encoding.UTF8.GetString(data);
                RcvdQtyPrm br = new RcvdQtyPrm();
                br = JsonConvert.DeserializeObject<RcvdQtyPrm>(jsonstring);
                #region Checking Condition for Empty or Null Value
                if (string.IsNullOrWhiteSpace(br.DOno))
                {
                    b.Msg = "DO No Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.Quantity))
                {
                    b.Msg = "Quantity Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                if (string.IsNullOrWhiteSpace(br.IMEI_NO))
                {
                    b.Msg = "IMEI_NO Cannot be null or empty";
                    b.StatusCode = "0";
                    return b;
                }
                

                #endregion

                #region Check Login Data from Data Base
                b = ba.ChangeQuantity(br);
                #endregion
            }
            catch (Exception ex)
            {
                b.Msg = "Error Message: " + ex.Message.ToString() + " Inner Exception: " + Convert.ToString(ex.InnerException).ToString();
                b.StatusCode = Message.ExceptionCode;
                return b;
            }

            return b;
        }
        #endregion
    }
}

