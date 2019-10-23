using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EON_Reality_Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EON_Reality_Assignment.Controllers
{
    public class RegisterController : Controller
    {
        private readonly RegisteredUserContext _dbContext;

        public RegisterController(RegisteredUserContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult Index()
        {
            List<SelectedDay> selectedDays = new List<SelectedDay>();
            for (int i = 1; i <= 3; i++)
            {
                selectedDays.Add(new SelectedDay { Id = i, Name = "Date " + i, Selected = false });
            }

            var model = new RegisteredUserModel();
            model.SelectedDays = selectedDays;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegisteredUserModel model)
        {
            try
            {
                if (ModelState.IsValid && CheckModelValidate(model))
                {
                    var registeredUser = ConverToRegisteredUser(model);
                    _dbContext.tblRegisteredUsers.Add(registeredUser);
                    await _dbContext.SaveChangesAsync();
                    foreach(var item in model.SelectedDays)
                    {
                        if (item.Selected)
                        {
                            var userSelectedDay = new UserSelectedDays
                            {
                                UserID = registeredUser.ID,
                                SelectedDay = item.Id
                            };
                            _dbContext.tblUserSelectedDays.Add(userSelectedDay);
                            await _dbContext.SaveChangesAsync();
                        }
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            List<SelectedDay> selectedDays = new List<SelectedDay>();
            for (int i = 1; i <= 3; i++)
            {
                selectedDays.Add(new SelectedDay { Id = i, Name = "Date " + i, Selected = false });
            }
            model.SelectedDays = selectedDays;
            return View(model);
        }

        private bool CheckModelValidate(RegisteredUserModel model)
        {
            var countSelected = 0;
            foreach (var item in model.SelectedDays)
            {
                if (item.Selected)
                {
                    countSelected++;
                }
            }

            if(countSelected == 0)
            {
                ModelState.AddModelError("", "The Selected Days field is required.");
                return false;
            }

            if(model.RegisterDate < new  DateTime(2019,01,01) || model.RegisterDate < new DateTime(2019, 06, 30))
            {
                ModelState.AddModelError("", "Date is not in given range.");
            }

            return true;
        }

        protected RegisteredUsers ConverToRegisteredUser(RegisteredUserModel model)
        {
            RegisteredUsers registeredUsers = new RegisteredUsers();
            registeredUsers.UserName = model.UserName?.Trim();
            registeredUsers.EmailAddress = model.EmailAddress?.Trim();
            registeredUsers.Gender = model.Gender;
            registeredUsers.RegisterDate = model.RegisterDate;
            registeredUsers.AdditionalRequest = model.AdditionalRequest?.Trim();

            return registeredUsers;
        }
    }
}