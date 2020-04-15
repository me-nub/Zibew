using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NonProfitCRM.Data;
using NonProfitCRM.Models;
using NonProfitCRM.Services;

namespace NonProfitCRM.Controllers
{
    public class VolunteersController : Controller
    {


        private readonly UnitOfWork _unitOfWork;
        private readonly ICommonServices _commonServices;
        private readonly IImageService _imageService;
        private readonly string orgId;


        public VolunteersController(IImageService imageService)
        {
            _unitOfWork = new UnitOfWork();
            _commonServices = new CommonServices();
            this._imageService = imageService;
            orgId = "cac8a4ec-edd5-4554-8c91-24574282b9c1";
        }
        // GET: Volunteers/Index
        public async Task<IActionResult> Index()
        {
            var volunteers = await _unitOfWork.VolunteersRepository.GetManyAsync(c => c.OrgId == orgId);
            var volunteersList = new List<Volunteers>();

            foreach (var volunteer in volunteers)
            {
                volunteer.AddressCountry = _unitOfWork.CountryRepository.GetByID(Convert.ToInt32(volunteer.AddressCountry))?.Name;
                
               // volunteer.AddressState = _unitOfWork.StateRepository.GetByID(Convert.ToInt32(volunteer.AddressState))?.Name;
                volunteersList.Add(volunteer);
            }

            return View(volunteersList.OrderByDescending(v => v.Id));
        }
       
        
        // GET: Volunteers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var volunteers = await _unitOfWork.VolunteersRepository.GetByIDAsync(id);
            if (volunteers == null)
            {
                return NotFound();
            }

            return View(volunteers);
        }

        // GET: Volunteers/Create
        public IActionResult Create()
        {

            
            var country = _commonServices.GetCountries();
            ViewBag.AddressCountry = new SelectList(country, "Id", "Name");
           // var states = _commonServices.GetStates(CountryId);
            //ViewBag.AddressState = new SelectList(state, "Id", "Name");
            var phoneisd = _commonServices.GetPhoneCode();
            ViewBag.PhoneCode = new SelectList(phoneisd, "Id", "PhoneCode");
                                        
           
            return View();
        }
      

        public IActionResult State(int CountryId)
        {
            var states = _commonServices.GetStates(CountryId);
         
            return Json(states);
        }

        
        // POST: Volunteers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrgId,Name,PhoneCode,PhoneNumber,Age,Email,InstagramProfile,FacebookProfile,TwitterProfile,AddressLine1,AddressLine2,AddressStreet,AddressCity,AddressState,AddressCountry,AddressZipcode,Gender,ImageFile,ImagePath")] Volunteers volunteers)
        {
            var country = _unitOfWork.CountryRepository.GetByID(Convert.ToInt32(volunteers.AddressCountry));

            var states = _unitOfWork.StateRepository.GetByID(Convert.ToInt32(volunteers.AddressState));
            
            volunteers.PhoneCode = country.PhoneCode.ToString();
            volunteers.PhoneNumber = volunteers.PhoneCode.ToString() + volunteers.PhoneNumber;
           
            if (ModelState.IsValid)
            {
                  volunteers.OrgId = orgId;
                volunteers.ImagePath = await _imageService.ImageUpload(volunteers.ImageFile, "Banners");
                
                _unitOfWork.VolunteersRepository.Insert(volunteers);
                await _unitOfWork.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            //ViewData["ContactTypeId"] = new SelectList(_unitOfWork.ContactTypeRepository.GetAll(), "Id", "Name", volunteers.VolunteersTypeId);
            ViewData["AddressCountry"] = new SelectList(_commonServices.GetCountries(), "Id", "Name", volunteers.AddressCountry);
           // ViewData["AddressState"] = new SelectList(_commonServices.GetStates(), "Id", "Name", volunteers.AddressState);
            ViewData["PhoneCode"] = new SelectList(_commonServices.GetPhoneCode(), "Id", "PhoneCode", volunteers.PhoneCode);
            return View(volunteers);
        }


        // GET: Volunteers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            
            var volunteers = await _unitOfWork.VolunteersRepository.GetByIDAsync(id);
            var phoneNumber = volunteers.PhoneNumber;
            var phoneCode = volunteers.PhoneCode;
            volunteers.PhoneNumber = phoneNumber.Substring((phoneNumber.Length - 10));
            //volunteers.ImagePath = await _imageService.ImageUpload(volunteers.ImageFile, "Banners");
            //volunteers.PhoneCode = volunteers.AddressCountry;
            //volunteers.PhoneNumber = volunteers.PhoneCode.ToString() + volunteers.PhoneNumber;


            var country = _commonServices.GetCountries();
            
            //volunteers.AddressCountry = volunteers.AddressState
            ViewBag.AddressCountry = new SelectList(country, "Id", "Name", volunteers.AddressCountry);
            //int x = Int32.TryParse(AddressCountry.ToString);
            int x = Convert.ToInt32(volunteers.AddressCountry);
            var state = _commonServices.GetStates(x);
            ViewBag.AddressState = new SelectList(state,"Id","Name", volunteers.AddressState);
            var phoneisd = _commonServices.GetPhoneCode();
            ViewBag.PhoneCode = new SelectList(phoneisd, "Id", "PhoneCode", volunteers.AddressCountry);

            if (volunteers == null)
            {
                return NotFound();
            }

            //ViewData["VolunteersTypeId"] = new SelectList(_unitOfWork.VolunteersTypeRepository.GetAll(), "Id", "Name", volunteers.VolunteersTypeId);
            return View(volunteers);

        }


        // POST: Volunteers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrgId,Name,PhoneCode,PhoneNumber,Age,Email,InstagramProfile,FacebookProfile,TwitterProfile,AddressLine1,AddressLine2,AddressStreet,AddressCity,AddressState,AddressCountry,AddressZipcode,Gender,ImageFile,ImagePath")] Volunteers volunteers)

        {

            var country = _unitOfWork.CountryRepository.GetByID(Convert.ToInt32(volunteers.AddressCountry));


            var state = _unitOfWork.StateRepository.GetByID(Convert.ToInt32(volunteers.AddressState));
            volunteers.PhoneCode = country.PhoneCode.ToString();
            volunteers.PhoneNumber = volunteers.PhoneCode.ToString() + volunteers.PhoneNumber;

            if (id != volunteers.Id)
            {   
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   // volunteers.ImagePath = await _imageService.ImageUpload(volunteers.ImageFile, "Banners");
                    volunteers.OrgId = orgId;
                  //volunteers.ImagePath = await _imageService.ImageUpload(volunteers.ImageFile, "Banners");
                  volunteers.ImagePath = await _imageService.ImageUpload(volunteers.ImageFile, "Banners");
                    _unitOfWork.VolunteersRepository.Update(volunteers);
                    await _unitOfWork.SaveAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolunteersExists(volunteers.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            // ViewData["VolunteersTypeId"] = new SelectList(_unitOfWork.VolunteersTypeRepository.GetAll(), "Id", "Name", volunteers.VolunteersTypeId);
            ViewData["AddressCountry"] = new SelectList(_commonServices.GetCountries(), "Id", "Name", volunteers.AddressCountry);
            //int n = Convert.ToInt32(volunteers.AddressState);
           //ViewData["AddressState"] = new SelectList(_commonServices.GetStates(n), "Id", "Name", volunteers.AddressState);
            ViewData["PhoneCode"] = new SelectList(_commonServices.GetPhoneCode(), "Id", "PhoneCode", volunteers.PhoneCode);
            return View(volunteers);
        }

        // GET: Volunteers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteers = await _unitOfWork.VolunteersRepository.GetByIDAsync(id);
            if (volunteers == null)
            {
                return NotFound();
            }

            return View(volunteers);
        }

        // POST: Volunteers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var volunteers = await _unitOfWork.VolunteersRepository.GetByIDAsync(id);
            _unitOfWork.VolunteersRepository.Delete(volunteers);
            await _unitOfWork.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool VolunteersExists(int id)
        {
            var volunteers = _unitOfWork.VolunteersRepository.GetByID(id);
            if (volunteers == null)
            {
                return false;
            }
            return true;
        }

    }
}