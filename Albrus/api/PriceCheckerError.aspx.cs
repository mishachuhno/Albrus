using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Albrus.api
{
    public partial class PriceCheckerError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static object GetAllDevice()
        {
            object rezult = null;
            using (DataClasses2DataContext DCDC = new DataClasses2DataContext())
            {
                rezult = (from res in DCDC.Devices select res).ToList();
            }
            return rezult;
        }
        [WebMethod]
        public static object GetAllLogs(string ipDevice, string dataStart, string dataEnd)
        {
            object rezult = null;
            using (DataClasses2DataContext DCDC = new DataClasses2DataContext())
            {
                rezult = (from res in DCDC.DeviceLogs where res.ipAdress == ipDevice select res).ToList();
            }
            return rezult;
        }
        [WebMethod]
        public static string NewDeviceMessage(string ipAdress, string idDevice, string dataLog, string logMessage)
        {
            using (DataClasses2DataContext DCDC = new DataClasses2DataContext())
            {
                DeviceLog devError = new DeviceLog();
                devError.ipAdress = ipAdress;
                devError.idDevice = idDevice;
                devError.dataLog = Convert.ToDateTime(dataLog);
                devError.logMessage = logMessage;
                DCDC.DeviceLogs.InsertOnSubmit(devError);

                DCDC.SubmitChanges();

                return "ok";
            }
            return "error";
        }
    }
}