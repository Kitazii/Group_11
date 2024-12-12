using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Dtos.Business;
using api.Dtos.Customer;
using api.Interfaces;
using api.Models;
using api.Repository;
using api.Respository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    // Deals with user access
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICustomerRepository _customerRepo;
        private readonly IBusinessRepository _businessRepo;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signinManager, ICustomerRepository customerRepo, IBusinessRepository businessRepo)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signinManager;
            _businessRepo = businessRepo;
            _customerRepo = customerRepo;
        }

        [HttpPost("registerCustomer")]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerDto registerDto)
        {
            try{
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var appUser = new Customer
                {
                    Forename = registerDto.Forename,
                    Surname = registerDto.Surname,
                    Street = registerDto.Street,
                    City = registerDto.City,
                    Postcode = registerDto.Postcode,
                    PhoneNumber = registerDto.PhoneNumber,
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "Customer");
                    if(roleResult.Succeeded)
                    {
                        return Ok(
                            new CustomerDto
                            {
                                Forename = appUser.Forename,
                                Surname = appUser.Surname,
                                Street = appUser.Street,
                                City = appUser.City,
                                Postcode = appUser.Postcode,
                                PhoneNumber = appUser.PhoneNumber,
                                Username = appUser.UserName,
                                Email = appUser.Email,
                                Token =_tokenService.CreateToken(appUser)
                            }
                        );
                    }
                    //otherwise role was not added
                    return StatusCode(500, roleResult.Errors);
                }
            //otherwise user was not created
            return StatusCode(500, createdUser.Errors);
            } catch (Exception e)
            {
                //for any other error exceptions
                return StatusCode(500, e);
            }
        }

        [HttpPost("registerBusiness")]
        public async Task<IActionResult> RegisterBusiness([FromBody] RegisterBusinessDto registerDto)
        {
            try{
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var appUser = new Business
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                    Name = registerDto.Name,
                    Street = registerDto.Street,
                    City = registerDto.City,
                    Postcode = registerDto.Postcode,
                    PhoneNumber = registerDto.PhoneNumber
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "Business");
                    if(roleResult.Succeeded)
                    {
                        return Ok(
                            new BusinessDto
                            {
                                Username = appUser.UserName,
                                Email = appUser.Email,
                                Name = appUser.Name,
                                Street = appUser.Street,
                                City = appUser.City,
                                Postcode = appUser.Postcode,
                                PhoneNumber = appUser.PhoneNumber,
                                Token =_tokenService.CreateToken(appUser)
                            }
                        );
                    }
                    //otherwise role was not added
                    return StatusCode(500, roleResult.Errors);
                }
            //otherwise user was not created
            return StatusCode(500, createdUser.Errors);
            } catch (Exception e)
            {
                //for any other error exceptions
                return StatusCode(500, e);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (user == null) return Unauthorized("Invalid username!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if(!result.Succeeded) return Unauthorized("Username not found and/or password inccorect");

            if (user is Customer)
            {
                var customer = await _customerRepo.GetByIdAsync(user.Id);
                return Ok(
                new CustomerDto
                {
                    Username = customer.UserName,
                    Email = customer.Email,
                    Forename = customer.Forename,
                    Surname = customer.Surname,
                    PhoneNumber = customer.PhoneNumber,
                    Street = customer.Street,
                    City = customer.City,
                    Postcode = customer.Postcode,
                    Token =_tokenService.CreateToken(customer)
                }
                );
            }
            
            var business = await _businessRepo.GetByIdAsync(user.Id);

            return Ok(
                new BusinessDto
                {
                    Username = business.UserName,
                    Email = business.Email,
                    Name = business.Name,
                    PhoneNumber = business.PhoneNumber,
                    Street = business.Street,
                    City = business.City,
                    Postcode = business.Postcode,
                    Token =_tokenService.CreateToken(business)
                }
                );
            
        }

        
    }
}