using ELibrary.Model.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ELibrary.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:1748/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync("api/library/tags");


            if (response.IsSuccessStatusCode)
            {
                var rspString = await response.Content.ReadAsStringAsync();             
                var tags = JsonConvert.DeserializeObject<IEnumerable<TagAssociationModel>>(rspString);

                return View(tags);
            }
            else
            {
                return View();
            }

            
        }
    }
}