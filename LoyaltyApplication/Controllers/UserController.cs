using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LoyaltyApplication.Models;
using System.ComponentModel.DataAnnotations;
using LoyaltyApplication.Core;

namespace LoyaltyApplication.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {

        private readonly UserCore core;

        public UserController(UserCore core) {
            this.core = core;
        }

        [HttpGet]
        public IEnumerable<User> GetAll() {
            return core.GetAll();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(long id) {
            try {
                return new ObjectResult(core.GetById(id));
            } catch (ArgumentException e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody][Required]User user) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            user = core.Create(user);
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }
    }
}
