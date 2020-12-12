using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Accounts.Web.Models;
using Accounts.Web.Repository;

namespace Accounts.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public HomeController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var accountsList = await _accountRepository.GetAccountsAsync();
            return View(accountsList);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(AccountModel model)
        {
            if (ModelState.IsValid)
            {
                model.OpeningDate = DateTime.Now; // To set the time also
                await _accountRepository.CreateAccountAsync(model);
                ModelState.Clear();
                ViewBag.success = true;
                return View();
            }

            return View(model);
        }

        [HttpGet("edit")]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _accountRepository.GetAccountByIdAsync(id);
            
            return View(result);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(int id, AccountModel model)
        {
            if (ModelState.IsValid)
            {
                model.OpeningDate = DateTime.Now; // To set the time also
                var edited = await _accountRepository.EditAccountAsync(id, model);

                if (edited > 0)
                {
                    ViewBag.edited = true;
                    return View();
                }
                
            }

            return View(model);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _accountRepository.DeleteAccountAsync(id);
            return RedirectToAction("Edit");
        }
    }
}
