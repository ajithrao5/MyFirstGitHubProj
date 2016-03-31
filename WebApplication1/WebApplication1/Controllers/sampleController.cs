using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class sampleController : Controller
    {
        // GET: sample
        public ActionResult Index()
        {
            List<sample> objlist = new List<sample>();
            sample s3 = new sample();
            DataSet ds2= s3.display();
            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                sample s4 = new sample();
                s4.id = Convert.ToInt32(dr[0]);
                s4.name = dr[1].ToString();
                s4.surname = dr[2].ToString();
                objlist.Add(s4);
               // objlist.Add(new sample() {name=dr[0].ToString(),surname=dr[1].ToString() } );
            }
            return View("success",objlist);
        }
        [HttpPost]
        public ActionResult create(FormCollection frm)
        {
            sample s2 = new sample();
            s2.id = Convert.ToInt32(frm["txtid"]);
            s2.name = frm["txtname"];
            s2.surname = frm["txtsname"];
            s2.insertvalues(s2);
            return RedirectToAction("index");
        }

        public ActionResult create()
        {
            return View();
        }
    }
}
