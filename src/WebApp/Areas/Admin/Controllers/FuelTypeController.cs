﻿using Application.Services;
using Domain.Constants;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = AuthenticationConstants.AuthenticationScheme,
               Roles = AuthenticationConstants.OperationClaims.AdminStr)]
    public class FuelTypeController : Controller
    {
        private IFuelTypeService FuelTypeService { get; }

        public FuelTypeController(IFuelTypeService fuelTypeService)
        {
            FuelTypeService = fuelTypeService;
        }

        // GET: FuelTypeController
        public ActionResult Index()
        {
            FuelTypeFilter filter = new FuelTypeFilter();
            var items = FuelTypeService.Get(filter);
            return View(items);
        }

        // GET: FuelTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FuelTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FuelType fuelType)
        {
            try
            {
                var response = FuelTypeService.Add(fuelType);
                ViewBag.Response = response;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: FuelTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = FuelTypeService.GetById(id);
            return View(item);
        }

        // POST: FuelTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FuelType fuelType)
        {
            try
            {
                var response = FuelTypeService.Update(fuelType);
                ViewBag.Response = response;
                return View(fuelType);
            }
            catch
            {
                return View();
            }
        }

        // GET: FuelTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = FuelTypeService.GetById(id);
            return View(item);
        }

        // POST: FuelTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                FuelTypeService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
