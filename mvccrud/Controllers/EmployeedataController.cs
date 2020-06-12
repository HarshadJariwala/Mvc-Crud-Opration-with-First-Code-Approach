using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvccrud.Models;
using System.Data.Entity;
using System.IO;
using System.Dynamic;

namespace mvccrud.Controllers
{
    public class EmployeedataController : Controller
    {

        DetailsContext dc = new DetailsContext();

        [HttpGet]
        public ActionResult Insertemp()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Insertemp(Employee emp)
        {
            dynamic result = new ExpandoObject();
            if (emp.Empid == 0)
            {
                var duplicate = dc.employees.Where(c => c.Email == emp.Email).ToList();

                if (duplicate.Count != 0)
                {
                    TempData["msg"] = "<script>alert('Already Exits!!!');</script>";
                    result.Message = "already exits";
                }
                else
                {
                    emp.Create_date = DateTime.Now;
                    dc.employees.Add(emp);
                    dc.SaveChanges();
                    TempData["msg"] = "<script>alert('Insert successfully');</script>";
                    result.Message = "successfully insert";
                }

            }
            else
            {
                emp.Create_date = DateTime.Now;// dbEmployee.Create_date;
                dc.Entry(emp).State = EntityState.Modified;
                dc.SaveChanges();
                TempData["msg"] = "<script>alert('Update successfully');</script>";
                result.Message = "successfully Updated";

            }

           
            //result.Message = string.Empty;
            result.Id = emp.Empid;

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult displayemp()
        {
            var qry = dc.employees.ToList();
            return View(qry);
        }

        [HttpGet]
        public string Deleteemp(int id)
        {
            var qry = dc.employees.Find(id);
            dc.employees.Remove(qry);
            dc.SaveChanges();
            TempData["msg"] = "<script>alert('Delete successfully');</script>";
            return "delete successfully";
        }

        [HttpGet]
        public JsonResult Editemp(int id)
        {
            var qry = dc.employees.Find(id);
            return Json(qry, JsonRequestBehavior.AllowGet);
        }


        public JsonResult getstate(int id)
        {
            var qry = dc.States.Where(c => c.Country_id == id).ToList();
            return Json(qry, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getcity(int id)
        {
            var qry = dc.Citys.Where(c => c.State_id == id).ToList();
            return Json(qry, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getcountry()
        {
            var qry = dc.Countrys.ToList();
            List<SelectListItem> mylist = new List<SelectListItem>();
            foreach (var item in qry)
            {
                SelectListItem obj = new SelectListItem();
                obj.Text = item.Country_name;
                obj.Value = item.Country_id.ToString();
                mylist.Add(obj);
            }

            return Json(mylist, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("Employeedata/UploadFiles/{id}")]
        public ActionResult UploadFiles(int id)
        {
            
            string path = Server.MapPath("~/Uploads/");
            HttpFileCollectionBase files = Request.Files;
            if (files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    file.SaveAs(path + file.FileName);
                }
                var qry = dc.employees.Find(id);
                qry.Photo = path;
                dc.SaveChanges();

            }
            
            return Json(files.Count + " Files Uploaded!");
        }

        //public ActionResult GetImage(int id)
        //{
        //    var photo = dc.employees.Find(id).Photo;

        //    return File(photo, "image/jpg/jpej");
        //}
    }
}