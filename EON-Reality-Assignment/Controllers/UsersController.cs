using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EON_Reality_Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EON_Reality_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly RegisteredUserContext _dbContext;
        public UsersController(RegisteredUserContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/Users
        [HttpGet]
        public IList<RegisteredUsers> Get()
        {
            var registeredUser = _dbContext.tblRegisteredUsers.
                OrderByDescending(c => c.ID).ToList();
            IList<RegisteredUsers> userlst = registeredUser;
            foreach (RegisteredUsers user in userlst)
            {
                var selectedDays = _dbContext.tblUserSelectedDays.Where(
                    d => d.UserID == user.ID).ToList();
                foreach (UserSelectedDays days in selectedDays)
                {
                    user.SelectedDays += "Day " + days.SelectedDay + ", ";
                }
                if (user.SelectedDays.Trim().Length > 0)
                {
                    user.SelectedDays = user.SelectedDays.Substring(0, user.SelectedDays.Length - 2);
                }
            }
            return userlst;
        }

         

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
         
    }
}
