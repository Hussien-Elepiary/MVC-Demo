using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        //when i make an opject of a controler the CLR will call the Ctor 

        //for this Ctor to work i have to Allow the Dependance injection like Shown in the StartUp.cs 
        public EmployeeController(IEmployeeRepository employeeRepository)//Ask the CLR to make|Create a class that implement the IEmployeeRepository 
        {
            _employeeRepository = employeeRepository; //initial it`s value to the _EmployeeRepository
        }

        // /Deparment/Index
        public IActionResult Index()
        {
            var Employees = _employeeRepository.GetAll();
            // View have Four overloads 1.View() || 2.View(View Name) || 3.View(Model) || 4.View(viewName,Model)
            return View(Employees);
        }

        #region Create
        // /Deparment/Create
        [HttpGet] //Default
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)//Server Side Validation (BackEnd Validation)
            {
                _employeeRepository.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
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
        public IActionResult Edit([FromRoute] int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();

            if (ModelState.IsValid)//Server Side Validation (BackEnd Validation)
            {
                try
                {
                    _employeeRepository.Update(employee);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //1. log the Exception 
                    //2. User Friendly Message

                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(employee);
        }
        #endregion


        #region Delete
        // /Deparment/Delete
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();

            if (ModelState.IsValid)//Server Side Validation (BackEnd Validation)
            {
                try
                {
                    _employeeRepository.Delete(employee);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //1. log the Exception 
                    //2. User Friendly Message

                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(employee);
        }
        #endregion

        #region Details
        // /Deparment/Details/:id
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id is null)
                return BadRequest("There is no id to Search For");
            var Employee = _employeeRepository.Get(id.Value);
            if (Employee is null)
                return NotFound();

            return View(viewName, Employee);
        }
        #endregion
    }
}
