using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using System.Data;
using BindCountry_Project.Models;
namespace BindCountry_Project.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult BindState()
        {
            Dictionary<string, string> Dic = new Dictionary<string, string>();
            StringBuilder sb = new StringBuilder();

            Dic["Message"] = "";
            Dic["GridState"] = "";
            try
            {
                DataTable dt = CommonMethod.ExecuteQuery("USP_BindState");
                if (dt.Rows.Count > 0)
                {
                    sb.Append("<option value=''>--Select--</option>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append("<option value='" + dt.Rows[i]["Statecode"] + "'>" + dt.Rows[i]["Statename"] + "</option>");
                    }
                    Dic["Grridview"] = sb.ToString();
                }
            }
            catch (Exception ex)
            {
                Dic["Message"] = ex.Message;
            }
            return Json(Dic);
        }

        // Bind CityMaster 
        public JsonResult BindCityMaster(string Statecode)
        {
            Dictionary<string, string> Dic = new Dictionary<string, string>();
            StringBuilder sb = new StringBuilder();

            try
            {
                string[,] Param = new string[,]
                {
                    { "@Statecode",Statecode}
                };

                DataTable dt = CommonMethod.ExecuteQuery("USP_BindCity", Param);
                if(dt.Rows.Count>0)
                {
                    sb.Append("<option value=''>--Select--</option>");
                    for (int i=0;i<dt.Rows.Count;i++)
                    {
                        sb.Append("<option value='" + dt.Rows[i]["Statecode"].ToString() + "'>" + dt.Rows[i]["Cityname"].ToString() + "</option>");
                    }
                    Dic["GridCity"] = sb.ToString();
                }
            }
            catch(Exception ex)
            {
                Dic["Message"] = ex.Message;
            }
            return Json(Dic);
        }
        public ActionResult Registration()
        {
            return View();
        }

        public JsonResult ShowRegistrationData()
        {
            Dictionary<string, string> Dic = new Dictionary<string, string>();
            try
            {
                DataTable dt = CommonMethod.ExecuteQuery("USP_ShowStudentdata");
                if(dt.Rows.Count>0)
                {
                    Dic["Gridview"] = CommonMethod.BindGridview(dt);
                }
            }

            catch(Exception ex)
            {
                Dic["Message"] = ex.Message;
            }
            return Json(Dic);
        }
        public JsonResult InsertUpdateRegistration(string ID ,string Name ,string Statename ,string Cityname ,string Regdate)
        {
            Dictionary<string, string> Dic = new Dictionary<string, string>();
            try
            {
                string[,] Param = new string[,]
                {
                    {"@ID",ID },
                    {"@Name",Name },
                    {"@Statename",Statename },
                    {"@Cityname",Cityname },
                    {"@Regdate",Regdate },
                };
                DataTable dt = CommonMethod.ExecuteQuery("Usp_InsertUpdateRegistration",Param);
                if (dt.Rows.Count > 0)
                {
                    Dic["Message"] = dt.Rows[0]["Msg"].ToString();
                }
            }

            catch (Exception ex)
            {
                Dic["Message"] = ex.Message;
            }
            return Json(Dic);
        }

    }

}
