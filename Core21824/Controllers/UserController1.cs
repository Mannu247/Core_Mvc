using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core21824.Models;

namespace Core21824.Controllers
{
    public class UserController1 : Controller
    {
        public readonly DatabaseContext _db;
        public UserController1(DatabaseContext context)
        {
            _db = context;
        }
        public IActionResult AddEmployee(int id=0)
        {
            ViewBag.BT = "Submit Data";
            tbluser obj = new tbluser();
            if(id > 0)
            {
                var data = (from a in _db.tblusers where a.uid == id select a).ToList();
                obj.uid = data[0].uid;
                obj.name = data[0].name;
                obj.age = data[0].age;
                ViewBag.MJ = "Update Data";
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult AddEmployee(tbluser _us)
        {
            if(_us.uid > 0)
            {
                _db.Entry(_us).State = EntityState.Modified;
            }
            else
            {
                _db.tblusers.Add(_us);
            }
            _db.SaveChanges();
            return RedirectToAction("ShowEmployee");
        }
        public IActionResult DeleteEmployee(int id=0)
        {
            var data = _db.tblusers.Find(id);
            _db.tblusers.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("ShowEmployee");
        }
        public IActionResult ShowEmployee()
        {
            var data = _db.tblusers.ToList();
            return View(data);
        }
    }
}
