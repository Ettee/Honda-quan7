using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HondaWeb.Helper;
using HondaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HondaWeb.Controllers
{
    public class PostTypesController : Controller
    {
        private static HttpClient client = new HttpClient();

        private readonly string uri = "https://localhost:44342/";
        public async Task<IActionResult> Index()
        {
            List<PostTypesViewModel> posttypes = new List<PostTypesViewModel>();
            HttpResponseMessage res = await client.GetAsync($"{uri}api/posttypes");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                posttypes = JsonConvert.DeserializeObject<List<PostTypesViewModel>>(result);
            }
            ViewBag.Quantity = 0;
            return View(posttypes);
        }

        [HttpGet]
        public IActionResult Create()
        {       
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostTypesViewModel model)
        {
            var postTask = await client.PostAsJsonAsync($"{uri}api/posttypes", model);
            if(postTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var postType = new PostTypesViewModel();
            HttpResponseMessage res = await client.GetAsync($"{uri}api/posttypes/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                postType = JsonConvert.DeserializeObject<PostTypesViewModel>(result);
            }
            return View(postType);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostTypesViewModel model)
        {
            var postTask = await client.PostAsJsonAsync($"{uri}api/posttypes/posttypeid={model.PostTypeId}", model);
            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
