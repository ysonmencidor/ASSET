﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NTBIAsset.Server.Data;
using NTBIAsset.Shared;

namespace NTBIAsset.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UserAccountsController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost("loginuser")]
        public async Task<ActionResult<UserAccount>> LoginUser(UserAccount account)
        {
            UserAccount loggedInUser = await _context.userAccounts.Where(x => x.Username == account.Username && x.Password == account.Password).FirstOrDefaultAsync();
            
            if (loggedInUser != null)
            {
                if(loggedInUser.Active == true)
                {
                    //create a claims
                    var claimUsername = new Claim(ClaimTypes.Name, loggedInUser.Username);
                    var claimId = new Claim(ClaimTypes.NameIdentifier, Convert.ToString(loggedInUser.Id));
                    //create claimsIdentity
                    var claimsIdentity = new ClaimsIdentity(new[] { claimUsername, claimId }, "serverAuth");
                    //create claimPrinciple
                    var claimPrinciple = new ClaimsPrincipal(claimsIdentity);
                    //Sign in
                    await HttpContext.SignInAsync(claimPrinciple);
                }
            }
            return await Task.FromResult(loggedInUser);
        }

        [HttpGet("getcurrentuser")]
        public async Task<ActionResult<UserAccount>> GetCurrentUser()
        {
            UserAccount currentuser = new UserAccount();
            if (User.Identity.IsAuthenticated)
            {
                currentuser.Username = User.FindFirstValue(ClaimTypes.Name);
            }
            return await Task.FromResult(currentuser);
        }
        [HttpGet("logoutuser")]
        public async Task<ActionResult<String>> LogOutUser()
        {
            await HttpContext.SignOutAsync();
            return "Success";
        }

        // GET: api/UserAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAccount>>> GetuserAccounts()
        {
            return await _context.userAccounts.ToListAsync();
        }

        // GET: api/UserAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAccount>> GetUserAccount(int id)
        {
            var userAccount = await _context.userAccounts.FindAsync(id);

            if (userAccount == null)
            {
                return NotFound();
            }

            return userAccount;
        }

        // PUT: api/UserAccounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAccount(int id, UserAccount userAccount)
        {
            if (id != userAccount.Id)
            {
                return BadRequest();
            }

            _context.Entry(userAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserAccounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserAccount>> PostUserAccount(UserAccount userAccount)
        {
            _context.userAccounts.Add(userAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserAccount", new { id = userAccount.Id }, userAccount);
        }

        // DELETE: api/UserAccounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserAccount>> DeleteUserAccount(int id)
        {
            var userAccount = await _context.userAccounts.FindAsync(id);
            if (userAccount == null)
            {
                return NotFound();
            }

            _context.userAccounts.Remove(userAccount);
            await _context.SaveChangesAsync();

            return userAccount;
        }

        private bool UserAccountExists(int id)
        {
            return _context.userAccounts.Any(e => e.Id == id);
        }
    }
}
