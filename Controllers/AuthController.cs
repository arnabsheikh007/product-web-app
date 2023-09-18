using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using product_web_app.Models;
using product_web_app.Models.JsonWebTocken;
using product_web_app.Services;

namespace product_web_app.Controllers
{
    public class AuthController : Controller
    {
        private readonly ISessionControl _sessionControl;

        public AuthController(ISessionControl sessionControl)
        {
            _sessionControl = sessionControl;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://stg-zero.propertyproplus.com.au/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Abp.TenantId","10");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = client.PostAsJsonAsync("https://stg-zero.propertyproplus.com.au/api/TokenAuth/Authenticate", user).Result;


                if(res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;

                    JsonWebTocken _jwt = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonWebTocken>(result);

                    _sessionControl.SetJWT(_jwt);

                    ViewBag.msg = "Loggin Successfull";
                    return View("Index");
                }
            }
            ViewBag.msg = "Log in Failed";
            return View();
        }

    }
}
