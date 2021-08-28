using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dal;
using Bal;
using System.Data.SqlClient;
using HumanResource.Models;


namespace HumanResource.Controllers
{
    public class PayRollController : Controller
    {
        DALPayRoll dalpay = new DALPayRoll();
        public ActionResult Show_PayRoll()
        {
   
            return View();
        }
        [HttpPost]
        public ActionResult Show_PayRoll(int id)
        {
            DataSet ds = dalpay.Show_PayRoll( );
            ViewBag.ab = ds.Tables[0];
            return View();
        }


        // GET: PayRoll
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add_PayRoll()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_PayRoll(PayRoll form)
        {
            Bal.PayRoll payroll = new Bal.PayRoll();
            payroll.ID=Convert.ToInt32(form.ID) ;

            payroll.BasicPay = Convert.ToDecimal(form.BasicPay);
            payroll.Allowances = Convert.ToDecimal(form.Allowances);
            payroll.Deductions = Convert.ToDecimal(form.Deductions);
            payroll.GrossPay = Convert.ToDecimal(form.GrossPay);
            payroll.NetPay = Convert.ToDecimal(form.NetPay);
            dalpay.Add_PayRoll(payroll);
            TempData["Message"] = "Data id Inserted";
            return RedirectToAction("Show_PayRoll");
        }
       
           
        
        public ActionResult Update_PayRoll(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update_PayRoll(int id,PayRoll form)
        {
            Bal.PayRoll payroll = new Bal.PayRoll();
            payroll.ID = id;
            payroll.BasicPay = Convert.ToDecimal(form.BasicPay);
            payroll.Allowances = Convert.ToDecimal(form.Allowances);
            payroll.Deductions = Convert.ToDecimal(form.Deductions);
            payroll.GrossPay = Convert.ToDecimal(form.GrossPay);
            payroll.NetPay = Convert.ToDecimal(form.NetPay);
            dalpay.Update_PayRoll(payroll);
            TempData["message"] = "data is updated";
            return RedirectToAction("Show_PayRoll");
        }
        public ActionResult Delete_PayRoll(int id) {
            dalpay.Delete_PayRoll(id);
            TempData["message"] = "data deleted";
            return RedirectToAction("Show_PayRoll");
        }
    }
}