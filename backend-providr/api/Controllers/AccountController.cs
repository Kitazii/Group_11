using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Business;
using api.Dtos.Customer;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        [HttpPost("registerCustomer")]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerDto registerDto)
        {
            try{
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var appUser = new Customer
                {
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
                    Email = registerDto.Email
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
    }
}