using Microsoft.AspNetCore.Mvc;
using product_web_app.Models.JsonWebTocken;
using product_web_app.Models;
using product_web_app.Services;
using Newtonsoft.Json;

namespace product_web_app.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISessionControl _sessionControl;

        public ProductController(ISessionControl sessionControl)
        {
            _sessionControl = sessionControl;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAll()
        {
            if( _sessionControl.IsLoggedIn() == false )
            {
                ViewBag.msg = "You Must Log In First";
                return View("Index");
            }
            string accessTocken = _sessionControl.GetAccessTocken();
            List<Product> products = new List<Product>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://stg-zero.propertyproplus.com.au/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessTocken );
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("https://stg-zero.propertyproplus.com.au/api/services/app/ProductSync/GetAllproduct");


                if (res != null)
                {
                    var result = res.Content.ReadAsStringAsync().Result;

                    products = JsonConvert.DeserializeObject<List<Product>>(result);

                }
            }
            return View(products);
        }

        [HttpGet]
        public  IActionResult Create()
        {
            if (_sessionControl.IsLoggedIn() == false)
            {
                ViewBag.msg = "You Must Log In First";
                return View("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel product)
        {
            string accessTocken = _sessionControl.GetAccessTocken();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://stg-zero.propertyproplus.com.au/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessTocken);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.PostAsJsonAsync("https://stg-zero.propertyproplus.com.au/api/services/app/ProductSync/CreateOrEdit", product);


                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;

                    Product prod = JsonConvert.DeserializeObject<Product>(result);

                    ViewBag.Content = prod.Name + " Created Successfully";

                }
            }
            return View();
        }

        public IActionResult Edit(int Id)
        {
            if (_sessionControl.IsLoggedIn() == false)
            {
                ViewBag.msg = "You Must Log In First";
                return View("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            string accessTocken = _sessionControl.GetAccessTocken();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://stg-zero.propertyproplus.com.au/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessTocken);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.PostAsJsonAsync("https://stg-zero.propertyproplus.com.au/api/services/app/ProductSync/CreateOrEdit", product);


                if (res != null)
                {
                    ViewBag.Content = "Edited Successfully";

                }
            }
            return View();
        }

    }
}
