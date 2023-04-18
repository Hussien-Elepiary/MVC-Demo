using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository _departmentRepository;

        //when i make an opject of a controler the CLR will call the Ctor 

        //for this Ctor to work i have to Allow the Dependance injection like Shown in the StartUp.cs 
        public DepartmentController(IDepartmentRepository departmentRepository)//Ask the CLR to make|Create a class that implement the IDepartmentRepository 
        {
            _departmentRepository = departmentRepository; //initial it`s value to the _departmentRepository
        }

        // /Deparment/Index
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();
            // View have Four overloads 1.View() || 2.View(View Name) || 3.View(Model) || 4.View(viewName,Model)
            return View(departments);
        }

        #region Create
        // /Deparment/Create
        [HttpGet] //Default
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)//Server Side Validation (BackEnd Validation)
            {
                _departmentRepository.Add(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        } 
        #endregion

        #region Edit
        // /Deparment/Edit/:id
        [HttpGet] //Default
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }

        //[HttpPut] But Html Form Dose not Support Put
        [HttpPost]
        [ValidateAntiForgeryToken] // To Make sure that the Request is Coming From the Site 
        public IActionResult Edit([FromRoute]int id, Department department)
        {
            if (id != department.Id)
                return BadRequest();

            if (ModelState.IsValid)//Server Side Validation (BackEnd Validation)
            {
                try
                {
                    _departmentRepository.Update(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //1. log the Exception 
                    //2. User Friendly Message

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                
            }
            return View(department);
        }
        #endregion


        #region Delete
        // /Deparment/Delete
        public IActionResult Delete(int? id)
        {
           return Details(id,"Delete");
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int id, Department department)
        {
            if (id != department.Id)
                return BadRequest();

            if (ModelState.IsValid)//Server Side Validation (BackEnd Validation)
            {
                try
                {
                    _departmentRepository.Delete(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //1. log the Exception 
                    //2. User Friendly Message

                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(department);
        }
        #endregion

        #region Details
        // /Deparment/Details/:id
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id is null)
                return BadRequest("There is no id to Search For");
            var department = _departmentRepository.Get(id.Value);
            if (department is null)
                return NotFound();

            return View(viewName, department);
        } 
        #endregion
    }
}
