using Microsoft.AspNetCore.Mvc;
using WebMVC_SWD.Components.Accounts.Models;
using WebMVC_SWD.Components.Accounts.Services;

namespace WebMVC_SWD.Components.Accounts.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("Account/EditProfile/{id}")]
        public IActionResult EditProfile(int id)
        {
            var account = _accountService.GetAccountById(id);
            if (account == null)
            {
                ViewBag.ErrorMessage = "Account not found!";
                return RedirectToAction("Login", "Auth"); 
            }

            return View("EditProfile", account);
        }

        [HttpPost]
        [Route("Account/EditProfile/{id}")]
        public IActionResult EditProfile(int id, Account updatedAccount)
        {
            var result = _accountService.UpdateAccount(id, updatedAccount);

            if (!result)
            {
                ViewBag.ErrorMessage = "Update failed!";
                return View("EditProfile", updatedAccount);
            }

            ViewBag.SuccessMessage = "Profile updated successfully!";
            return View("EditProfile", updatedAccount);
        }

        [HttpGet]
        [Route("Account/List")]
        public IActionResult List()
        {
            var accounts = _accountService.GetAllAccounts();
            return View("ListAccounts", accounts); // Views/Account/ListAccounts.cshtml
        }

        [HttpPost]
        [Route("Account/ToggleDisable/{id}")]
        public IActionResult ToggleDisable(int id)
        {
            var result = _accountService.TryToggleAccountStatus(id);

            if (!result)
            {
                ViewBag.ErrorMessage = "Failed to disable account.";
            }
            else
            {
                ViewBag.SuccessMessage = "Account status updated successfully.";
            }

            var accounts = _accountService.GetAllAccounts();
            return View("ListAccounts", accounts);
        }

    }
}
