using System;
using System.Collections.Generic;
using System.Linq;
using Exp.Aspform.Form.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exp.Aspform.Form.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private static readonly List<CustomerViewModel> SingletonDataStore = new() 
        {
            new CustomerViewModel()
            {
                Id = 1,
                Number = 1001,
                Name = "Alfred",
                Sex = Sex.Male,
                RegisteredAt = new DateTime(2001, 01, 01),
            },
            new CustomerViewModel()
            {
                Id = 2,
                Number = 1002,
                Name = "Berta",
                Sex = Sex.Female,
                RegisteredAt = new DateTime(2002, 02, 02),
            },
            new CustomerViewModel()
            {
                Id = 3,
                Number = 1003,
                Name = "Colina",
                Sex = Sex.Unknown,
                RegisteredAt = new DateTime(2003, 03, 03),
            },
        };

        // List / Index

        [HttpGet("")]
        public ActionResult<IEnumerable<CustomerViewModel>> Get()
        {
            return View("list", SingletonDataStore);
        }

        // Create

        [HttpGet("create")]
        public ActionResult<CustomerViewModel> Create()
        {
            var viewModel = new CustomerViewModel();
            return View(viewModel);
        }

        [HttpPost("create")]
        public ActionResult<CustomerViewModel> CreatePostback(CustomerViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Create), viewModel);
            }

            var maxId = SingletonDataStore.Max(o => o.Id);
            viewModel.Id = maxId + 1;
            SingletonDataStore.Add(viewModel);

            return RedirectToAction("");
        }

        // Read

        [HttpGet("{id}")]
        public ActionResult<CustomerViewModel> Get(int id)
        {
            var customer = SingletonDataStore.FirstOrDefault(o => o.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View("read", customer);
        }

        // Update

        [HttpGet("update/{id}")]
        public ActionResult<CustomerViewModel> Update(int id)
        {
            var viewModel = SingletonDataStore.FirstOrDefault(o => o.Id == id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View("update", viewModel);
        }

        [HttpPost("update/{id}")]
        public ActionResult<CustomerViewModel> UpdatePostback(int id, CustomerViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Update), viewModel);
            }

            var existingCustomer = SingletonDataStore.FirstOrDefault(o => o.Id == id);

            if (existingCustomer == null)
            {
                return NotFound();
            }

            existingCustomer.Name = viewModel.Name;
            existingCustomer.Number = viewModel.Number;
            existingCustomer.RegisteredAt = viewModel.RegisteredAt;
            existingCustomer.Sex = viewModel.Sex;

            return RedirectToAction("");
        }

        // Delete

        [HttpGet("delete/{id}")]
        public ActionResult<CustomerViewModel> Delete(int id)
        {
            var viewModel = SingletonDataStore.FirstOrDefault(o => o.Id == id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View("delete", viewModel);
        }

        [HttpPost("delete/{id}")]
        public ActionResult<CustomerViewModel> DeletePostback(int id)
        {
            var customer = SingletonDataStore.FirstOrDefault(o => o.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            SingletonDataStore.Remove(customer);

            return RedirectToAction("");
        }
    }
}