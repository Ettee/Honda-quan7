using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HondaAPI.Models;
using HondaAPI.ViewModels;
using IdentityServer3.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HondaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        EntityDataContext _context = new EntityDataContext();
        [HttpGet]
        public IEnumerable<PostsViewModel> GetAll()
        {
            var posts = _context.Posts.Select(p => new PostsViewModel() 
            {
                Title = p.Title,
                Content = p.Content,
                CreatedDate = p.CreatedDate,
                ModifiedDate = p.ModifiedDate,
                Description = p.Description,
                IsHotNews = p.IsHotNews
            }).ToList();
            return posts;
        }

        [HttpPost]
        public void CreateNewPost([FromBody] Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(post);
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
    }
}
