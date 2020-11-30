using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using HondaAPI.Models;
using HondaAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HondaAPI.Controllers
{
    [ApiController]
    public class PostTypesController : ControllerBase
    {
        EntityDataContext _context = new EntityDataContext();

        [Route("api/posttypes")]
        [HttpGet]
        public ActionResult<IEnumerable<PostType>> GetProducts()
        {
            return _context.PostTypes.ToList();
        }

        [Route("api/posttypes")]
        [HttpPost]
        public void CreateNewPost([FromBody] PostType postType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(postType);
                    _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
        }

        [Route("api/posttypes/posttypeid={id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int? id ,[FromBody] PostType postType)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }
                else
                {
                    var postTypeToUpdate = _context.PostTypes.FirstOrDefault(p=>p.PostTypeId == id);
                    if (postTypeToUpdate == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        postTypeToUpdate.PostTypeName = postType.PostTypeName;
                        _context.Entry(postTypeToUpdate).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        return new ObjectResult(postTypeToUpdate);
                    }
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
