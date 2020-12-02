using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HondaWeb.Helper;
using HondaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace HondaWeb.Controllers
{
    public class PostsController : Controller
    {
        private static HttpClient client = new HttpClient();
        private readonly string uri = "https://localhost:44342/";
       
        public async Task<IActionResult> Index()
        {
            List<PostsViewModel> posts = new List<PostsViewModel>();
            
            HttpResponseMessage res = await client.GetAsync($"{uri}api/posts");
            if(res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                posts = JsonConvert.DeserializeObject<List<PostsViewModel>>(result);
            }
            ViewBag.Quantity = 0;
            return View(posts);
        }

        public async Task<IActionResult> PostDetail (int id)
        {
            var post = new PostsViewModel();
            HttpResponseMessage res = await client.GetAsync($"{uri}api/posts/{id}");
            if(res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                post = JsonConvert.DeserializeObject<PostsViewModel>(result);
            }
            return View(post);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await SetViewBagAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostsViewModel model)
        {
            var postTask = await client.PostAsJsonAsync($"{uri}api/posts", model);
            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var post = new PostsViewModel();
            HttpResponseMessage res = await client.GetAsync($"{uri}api/posts/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                post = JsonConvert.DeserializeObject<PostsViewModel>(result);
            }
            await SetViewBagAsync(post.PostTypeId);
            return View(post);
        }

        public async Task SetViewBagAsync(int? selectedID = null)
        {
            var listPostTypeID = new PostTypesController();
            var list = await GetPostTypeListAsync();
            ViewBag.PostTypeList = new SelectList(list, "PostTypeId", "PostTypeName", selectedID);
        }

        private async Task<List<PostTypesViewModel>> GetPostTypeListAsync()
        {
            List<PostTypesViewModel> posttypes = new List<PostTypesViewModel>();
            HttpResponseMessage res = await client.GetAsync($"{uri}api/posttypes");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                posttypes = JsonConvert.DeserializeObject<List<PostTypesViewModel>>(result);
            }

            return posttypes.ToList();
        }
    }
}
    