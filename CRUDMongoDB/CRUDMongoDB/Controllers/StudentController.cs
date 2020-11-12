using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDMongoDB.Models;
using CRUDMongoDB.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CRUDMongoDB.Core;
namespace CRUDMongoDB.Controllers
{
    public class StudentController : Controller
    {
        private IStudent StudentService;
        public StudentController(IStudent StudentService)
        {
            this.StudentService = StudentService;
        }
        public async Task<IActionResult>  Index()
        {
            //var gridmodel = await StudentService.GetList();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create(Student model)
        {
            model = model == null ? new Student() : model;
            return View(await Task.FromResult(model));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student model, bool SaveAndCountinue = false)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var obj = new Student()
            {
                Id = model.Id,
                FullName = model.FullName,
                Age = model.Age,
                DateCreate = model.DateCreate,
                IsDelete = model.IsDelete

            };
            // thuc hientheem mới
            var result = await StudentService.Create(obj);
            if (result.isSuccess)
            {
                if (SaveAndCountinue)
                {
                    TempData["Success"] = "Thêm mới thành công";
                    return RedirectToAction("Create");
                }

                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
            
        }
    }
}
