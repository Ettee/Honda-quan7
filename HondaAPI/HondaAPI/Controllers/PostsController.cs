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
    [ApiController]
    public class PostsController : ControllerBase
    {
        EntityDataContext _context = new EntityDataContext();

        [Route("api/posts")]
        [HttpGet]
        public IEnumerable<PostsViewModel> GetAll()
        {
            var posts = _context.Posts.AsNoTracking().Join(_context.PostTypes, p=>p.PostTypeId, t => t.PostTypeId, (p,t) => new PostsViewModel()
            {
                PostId = p.PostId,
                Title = p.Title,
                Content = p.Content,
                CreatedDate = p.CreatedDate,
                ModifiedDate = p.ModifiedDate,
                Description = p.Description,
                IsHotNews = p.IsHotNews,
                PostTypeId = p.PostTypeId,
                PostTypeName = t.PostTypeName
            }).ToList();
            return posts;
        }

        [Route("api/posts/{id}")]
        [HttpGet]
        public PostsViewModel GetDetail(int id)
        {
            var post = _context.Posts.Join(_context.PostTypes, p => p.PostTypeId, t => t.PostTypeId, (p, t) => new PostsViewModel()
            {
                PostId = p.PostId,
                Title = p.Title,
                Content = p.Content,
                CreatedDate = p.CreatedDate,
                ModifiedDate = p.ModifiedDate,
                Description = p.Description,
                IsHotNews = p.IsHotNews,
                PostTypeId = p.PostTypeId,
                PostTypeName = t.PostTypeName
            }).Where(p=>p.PostId == id).SingleOrDefault();
            return post;
        }

        [Route("api/posts")]
        [HttpPost]
        public ActionResult CreateNewPost([FromBody] Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    post.CreatedDate = DateTime.Now;
                    post.Status = 1;
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
            return Ok();
        }
    }
}
