using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }        
        
        public IActionResult Upsert(int? id)
        {
            Company company = new Company();
            if (id == null)
                return View(company);

            company = _unitOfWork.Company.Get(id.GetValueOrDefault());
            if (company == null)
                return NotFound();
            
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company Company)
        {
            if (ModelState.IsValid)
            {
                if (Company.Id == 0)
                    _unitOfWork.Company.Add(Company);
                else
                    _unitOfWork.Company.Update(Company);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(Company);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allobj = _unitOfWork.Company.GetAll();

            return Json(new { data = allobj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFormDb = _unitOfWork.Company.Get(id);
            if (objFormDb == null)
                return Json(new { success = false, Message = "Error while deleting" });
            _unitOfWork.Company.Remove(objFormDb);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete Successful" });
        }

        #endregion
    }
}
