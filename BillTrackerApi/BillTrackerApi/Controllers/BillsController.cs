using BillTrackerApi.Data;
using BillTrackerApi.Data.Models;
using BillTrackerApi.Models.Bills;
using BillTrackerApi.Services.Bills;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BillTrackerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IBillService billService;

        public BillsController(ApplicationDbContext context, IBillService billService)
        {
            this.context = context;
            this.billService = billService;
        }

        [HttpGet]
        public IEnumerable<Bill> GetAllBills()
        {
            var bills = billService.GetAllBills();

            return bills;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Bill> GetBillById(int id) 
        {
            var bill = billService.GetBillById(id);

            if (bill == null)
            {
                return NotFound();
            }

            return bill;
        }

        [HttpPost]
        public ActionResult InsertBill(InsertBillModel bill)
        {
            var currBill = new Bill
            {
                IsPaid = bill.IsPaid,
                Anount = bill.Anount,
                Company = bill.Company,
                Deadline = bill.Deadline
            };

            context.Bills.Add(currBill);
            context.SaveChanges();

            return CreatedAtAction("Get", new {id = currBill.Id }, currBill );
        }

        [HttpPut]
        public ActionResult EditBill(EditBillModel bill)
        {
            var IsEdited = billService.EditBill(bill);

            if (IsEdited)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteBill(int id)
        {
            var currBill = billService.GetBillById(id);

            if (currBill == null)
            {
                return NotFound();
            }

            billService.DeleteBill(currBill);

            return NoContent();
        }
    }
}
