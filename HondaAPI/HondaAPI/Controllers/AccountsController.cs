using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HondaAPI.Models;
using HondaAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HondaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        EntityDataContext _context = new EntityDataContext();
        
        [HttpGet]
        public IEnumerable<AccountsViewModel> GetAll()
        {
            var acc = _context.Accounts.Select(p => new AccountsViewModel()
            {
                UserName = p.UserName,
                Pass = p.Pass
            }).ToList();
            return acc;
        }

        //[HttpPost]
        //public IActionResult CheckLogin([FromBody] string userName, string passWord)
        //{
        //    var check = _context.Accounts.Where(p => p.UserName == userName && p.Pass == passWord).ToList().Count;
        //    if (check == 1)
        //    {
        //        return Ok();
        //    }
        //    else
        //        return NotFound();
        //}
    }
}
