﻿using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")] // Attribute Routing
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public AccountController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpPost] // sending the data
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestModel model)
        {
            var user = await _userService.RegisterUser(model);
            return Ok(user); // Ok from controllerbase
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound("No user found");
            }

            var user = await _userService.Login(model);

            if (user == null)
            {
                throw new Exception("Invalid login");
                //throw new Exception("Invalid Login");
            }

            // store some information in the Cookies, Authentication cookie.. Claims
            // 
            var claims = new List<Claim>
            {
                new Claim(type:ClaimTypes.Email, value:user.Email),
                new Claim(type:ClaimTypes.GivenName, value:user.FirstName),
                new Claim(type:ClaimTypes.Surname, value:user.LastName),
                new Claim(type:ClaimTypes.NameIdentifier, value:user.Id.ToString())
            };
            // Identity class .. and Principle
            // go to an bar => check your identity => Driver License
            // go to Airport => check passport
            // Create a movie => claim with role value as Admin

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // create the cookies
            // HttpContext

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            
            return Ok(user);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                NotFound($"Account dosen't exist for id: {id}");
            }
            return Ok(user);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var users = await _userService.GetAllUsers();
            if (!users.Any())
            {
                NotFound("No users exist");
            }
            return Ok(users);
        }
    }
}
