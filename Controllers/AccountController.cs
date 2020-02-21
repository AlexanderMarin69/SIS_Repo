using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Authorization;
using vueproject.ViewModels;
using Microsoft.AspNetCore.Identity;
using vueproject.Models;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using vueproject.DB;
using Microsoft.EntityFrameworkCore;

namespace vueproject.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private vueprojectDatabaseContext ctx;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            vueprojectDatabaseContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            ctx = context;

        }

        [HttpGet]
        public IActionResult IsUserLoggedIn()
        {
            if (User.Identity.IsAuthenticated)
                return Ok();
            return Unauthorized();
        }

        //[HttpGet]
        //[Authorize(Roles = "ADMIN")]
        //public async Task<IActionResult> GetAllCustomerUsers()
        //{
        //    IList<ApplicationUser> users = await _userManager.GetUsersInRoleAsync("PLAYERS");
        //    return Ok(users);
        //}

        [HttpGet]
        public async Task<IActionResult> GetLoggedUser()
        {
            var usr = await _userManager.GetUserAsync(User);
            var user = ctx.ApplicationUsers.Where(x => x.UserId == usr.Id).FirstOrDefault();

            var vm = new UpdateUserViewModel();

            if (User.Identity.IsAuthenticated)
            {
                vm.FirstName = user.FirstName;
                vm.LastName = user.LastName;
                vm.CompanyName = user.CompanyName;
                vm.PaymentTerms = user.PaymentTerms;
                vm.InvoicecPastDuePercentageFee = user.InvoicecPastDuePercentageFee;
                vm.EmailAddress = user.EmailAddress;
                vm.InvoiceAddress = user.InvoiceAddress;
                vm.ZipCode = user.ZipCode;
                vm.City = user.City;
                vm.Country = user.Country;
                vm.PhoneNumber = user.PhoneNumber;
                vm.Fax = user.Fax;
                vm.PlusGiro = user.PlusGiro;
                vm.BankGiro = user.BankGiro;
                vm.OrgNr = user.OrgNr;
                vm.MomsRegNr = user.MomsRegNr;

                return Ok(vm);
            }
            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel vm)
        {
            var usr = await _userManager.GetUserAsync(User);
            var user = ctx.ApplicationUsers.Where(x => x.UserId == usr.Id).FirstOrDefault();


            if (User.Identity.IsAuthenticated)
            {
                user.FirstName = vm.FirstName;
                user.LastName = vm.LastName;
                user.CompanyName = vm.CompanyName;
                user.PaymentTerms = vm.PaymentTerms;
                user.InvoicecPastDuePercentageFee = vm.InvoicecPastDuePercentageFee;
                user.EmailAddress = vm.EmailAddress;
                user.InvoiceAddress = vm.InvoiceAddress;
                user.ZipCode = vm.ZipCode;
                user.City = vm.City;
                user.Country = vm.Country;
                user.PhoneNumber = vm.PhoneNumber;
                user.Fax = vm.Fax;
                user.PlusGiro = vm.PlusGiro;
                user.BankGiro = vm.BankGiro;
                user.OrgNr = vm.OrgNr;
                user.MomsRegNr = vm.MomsRegNr;
                
                ctx.ApplicationUsers.Update(user).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
                return Ok(user);
            }
            return Unauthorized();
        }

        //[HttpPost]
        //public async Task<IActionResult> ChangePassword(ChangePasswordViewModel vm)
        //{
        //    var usr = await _userManager.GetUserAsync(User);
        //    IdentityResult result = new IdentityResult();
        //    if (vm.NewPassword != null)
        //        result = await _userManager.ChangePasswordAsync(usr, vm.Password, vm.NewPassword);

        //    if (result.Succeeded)
        //        return Ok("Password changed");

        //    foreach (var error in result.Errors)
        //    {
        //        return BadRequest(error.Description);
        //    }

        //    return Ok();
        //}

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {

            //Username is the same as email
            var result = await _signInManager.PasswordSignInAsync(vm.Username,
            vm.Password, vm.RememberMe, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                ////If we have redirect url we return the user to where he was before trying to login
                //if (vm.RedirectUrl != null || !String.IsNullOrWhiteSpace(vm.RedirectUrl))
                //{
                //    return Ok(vm.RedirectUrl);
                //}
                ////Else we just return the "home" route
                //else
                //{
                return Ok("/");
                //}
            }

            if (result.IsLockedOut)
            {
                //Return a message to login view.
                return BadRequest("You are locked out. Please contact an administrator.");
            }
            else
            {
                //Change this to a proper statuscode.. perhaps 401
                return BadRequest("Invalid login attempt.");
            }
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel vm)
        {
            if (ModelState.IsValid)
            {


                //var customerId = await _customerService.Add(customer);



                //if (!string.IsNullOrEmpty(vm.DeliveryAddress))
                //{
                //    deliveryAddress = new DeliveryAddressViewModel
                //    {
                //        Address = vm.DeliveryAddress,
                //        City = vm.DeliveryCity,
                //        ZipCode = vm.DeliveryZipCode
                //    };

                //    deliveryAddressId = await _deliveryAddressService.Add(deliveryAddress, new Guid(user.Id));
                //}

                //Add things to user if not empty;) like when fill profile and things are optional

                //if (!string.IsNullOrEmpty(vm.InvoiceAddress))
                //{
                //    invoiceAddress = new InvoiceAddressViewModel
                //    {
                //        Address = vm.InvoiceAddress,
                //        City = vm.InvoiceCity,
                //        ZipCode = vm.InvoiceZipCode
                //    };

                //    invoiceAddressId = await _invoiceAddressService.Add(invoiceAddress, new Guid(user.Id));
                //}


                var user = new IdentityUser { UserName = vm.Email, Email = vm.Email };
                var result = await _userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    var NewApplicationUser = new ApplicationUser();
                    NewApplicationUser.EmailAddress = vm.Email;
                    NewApplicationUser.FirstName = vm.FirstName;
                    NewApplicationUser.LastName = vm.LastName;
                    NewApplicationUser.UserId = user.Id;
                    await ctx.ApplicationUsers.AddAsync(NewApplicationUser);
                    await ctx.SaveChangesAsync();

                    return Ok();
                }

                foreach (var error in result.Errors)
                {
                    return BadRequest(error.Description);
                }
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}