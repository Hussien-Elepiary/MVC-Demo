﻿using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        //private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //when i make an opject of a controler the CLR will call the Ctor 

        //for this Ctor to work i have to Allow the Dependance injection like Shown in the StartUp.cs 
        public DepartmentController(/*IDepartmentRepository departmentRepository*/ IUnitOfWork unitOfWork , IMapper mapper)//Ask the CLR to make|Create a class that implement the IDepartmentRepository 
        {
            /*_departmentRepository = departmentRepository;*/ //initial it`s value to the _departmentRepository
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // /Deparment/Index
        public IActionResult Index()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            // View have Four overloads 1.View() || 2.View(View Name) || 3.View(Model) || 4.View(viewName,Model)

            var mappedEmp = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>(departments);


            return View(mappedEmp);
        }

        #region Create
        // /Deparment/Create
        [HttpGet] //Default
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentViewModel departmentVM)
        {
            if (ModelState.IsValid)//Server Side Validation (BackEnd Validation)
            {
                var mappedDept = _mapper.Map<DepartmentViewModel, Department>(departmentVM);
                _unitOfWork.DepartmentRepository.Add(mappedDept);
                _unitOfWork.Completed();
                return RedirectToAction(nameof(Index));
            }
            return View(departmentVM);
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
        public IActionResult Edit([FromRoute]int id, DepartmentViewModel departmentVM)
        {
            if (id != departmentVM.Id)
                return BadRequest();

            if (ModelState.IsValid)//Server Side Validation (BackEnd Validation)
            {
                try
                {
                    var mappedDept = _mapper.Map<DepartmentViewModel, Department>(departmentVM);
                    _unitOfWork.DepartmentRepository.Update(mappedDept);
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
            return View(departmentVM);
        }
        #endregion


        #region Delete
        // /Deparment/Delete
        public IActionResult Delete(int? id)
        {
           return Details(id,"Delete");
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int id, DepartmentViewModel departmentVM)
        {
            if (id != departmentVM.Id)
                return BadRequest();

            if (ModelState.IsValid)//Server Side Validation (BackEnd Validation)
            {
                try
                {
                    var mappedDept = _mapper.Map<DepartmentViewModel, Department>(departmentVM);
                    _unitOfWork.DepartmentRepository.Delete(mappedDept);
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
            return View(departmentVM);
        }
        #endregion

        #region Details
        // /Deparment/Details/:id
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id is null)
                return BadRequest("There is no id to Search For");
            var department = _unitOfWork.DepartmentRepository.Get(id.Value);
            if (department is null)
                return NotFound();

            var mappedDept = _mapper.Map<Department, DepartmentViewModel>(department);

            return View(viewName, mappedDept);
        } 
        #endregion
    }
}