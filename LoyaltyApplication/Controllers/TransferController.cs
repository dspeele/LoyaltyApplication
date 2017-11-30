using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LoyaltyApplication.Models;
using System.ComponentModel.DataAnnotations;
using LoyaltyApplication.Core;

namespace LoyaltyApplication.Controllers
{
    [Route("transfer")]
    public class TransferController : Controller
    {

        private readonly TransferCore core;

        public TransferController(TransferCore core) {
            this.core = core;
        }

        [HttpGet]
        public IEnumerable<Transfer> GetAll([FromQuery]string userId) {
            return core.GetAll(userId);
        }

        [HttpGet("{id}", Name = "GetTransfer")]
        public IActionResult GetById(long id) {
            try {
                return new ObjectResult(core.GetById(id));
            } catch (ArgumentException e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody][Required]Transfer transfer) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            try {
                transfer = core.Create(transfer);
                return CreatedAtRoute("GetTransfer", new { id = transfer.Id }, transfer);
            } catch (ArgumentException e) {
                return BadRequest(e.Message);
            }  
        }
    }
}
