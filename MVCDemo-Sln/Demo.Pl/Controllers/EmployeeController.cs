﻿using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly IEmployeeRepository _employeeRepository;
        //private IDepartmentRepository _departmentRepository;

        //when i make an opject of a controler the CLR will call the Ctor 

        //for this Ctor to work i have to Allow the Dependance injection like Shown in the StartUp.cs 
        public EmployeeController(IUnitOfWork unitOfWork /*IEmployeeRepository employeeRepository/*, IDepartmentRepository departmentRepository*/, IMapper mapper)//Ask the CLR to make|Create a class that implement the IEmployeeRepository 
        {
            /*_employeeRepository = employeeRepository;*/ //initial it`s value to the _EmployeeRepository
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_departmentRepository = departmentRepository;
        }

        // /Deparment/Index
        public IActionResult Index(string SearchValue)
        {
            IEnumerable<Employee> Employees;
            if (string.IsNullOrEmpty(SearchValue))
                Employees = _unitOfWork.EmployeeRepository.GetAll();
            else
                Employees = _unitOfWork.EmployeeRepository.GetEmployeesByName(SearchValue);

            var mappedEmp = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(Employees);

            // View have Four overloads 1.View() || 2.View(View Name) || 3.View(Model) || 4.View(viewName,Model)
            return View(mappedEmp);
        }

        #region Create
        // /Deparment/Create
        [HttpGet] //Default
        public IActionResult Create()
        {
            //ViewBag.Departments = _departmentRepository.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)//Server Side Validation (BackEnd Validation)
            {
                var mappedEmp = _mapper.Map<EmployeeViewModel,Employee>(employeeVM);

                _unitOfWork.EmployeeRepository.Add(mappedEmp);
                _unitOfWork.Completed();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeVM);
        }
        #endregion

        #region Edit
        // /Deparment/Edit/:id
        [HttpGet] //Default
        public IActionResult Edit(int? id)
        {
            //ViewBag.Departments = _departmentRepository.GetAll();
            return Details(id, "Edit");
        }

        //[HttpPut] But Html Form Dose not Support Put
        [HttpPost]
        [ValidateAntiForgeryToken] // To Make sure that the Request is Coming From the Site 
        public IActionResult Edit([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();

            if (ModelState.IsValid)//Server Side Validation (BackEnd Validation)
            {
                try
                {
                    var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);

                    _unitOfWork.EmployeeRepository.Update(mappedEmp);
                    _unitOfWork.Completed();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //1. log the Exception 
                    //2. User Friendly Message

                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(employeeVM);
        }
        #endregion


        #region Delete
        // /Deparment/Delete
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();

            if (ModelState.IsValid)//Server Side Validation (BackEnd Validation)
            {
                try
                {
                    var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);

                    _unitOfWork.EmployeeRepository.Delete(mappedEmp);
                    _unitOfWork.Completed();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //1. log the Exception 
                    //2. User Friendly Message

                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(employeeVM);
        }
        #endregion

        #region Details
        // /Deparment/Details/:id
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id is null)
                return BadRequest("There is no id to Search For");
            var Employee = _unitOfWork.EmployeeRepository.Get(id.Value);
            if (Employee is null)
                return NotFound();

            var mappedEmp = _mapper.Map<Employee, EmployeeViewModel>(Employee);

            return View(viewName, mappedEmp);
        }
        #endregion
    }
}
