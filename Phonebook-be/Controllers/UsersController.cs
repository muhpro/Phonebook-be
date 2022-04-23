using Microsoft.AspNetCore.Mvc;
using Phonebook_be.Managers;
using Phonebook_be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Phonebook_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser user;

        public UsersController(IUser userInstance)
        {
            user = userInstance;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateUser([FromBody] Users newUser)
        {
            user.CreateUser(newUser.fullName, newUser.number);
            return Ok(newUser);
        }


        [HttpGet]
        [Route("users")]
        public ActionResult UserList()
        {
            var users = user.UserList();
            return Ok(users);
           
        }

        [HttpPost]
        [Route("delete/{id}")]
        public ActionResult DeleteUser(int id)
        {
            user.DeleteUser(id);
            return Ok("user deleted");
        }

        [HttpPost]
        [Route("updateprofile")]
        public ActionResult UpdateUser([FromBody] Users payload)
        {
            var requestingUser = user.GetUserById(payload.userID);
            if (requestingUser == null)
            {
                return BadRequest("This user does not exist");
            }
            user.UpdateUser(requestingUser, payload);
            return Ok(payload);

        }
    }
}
