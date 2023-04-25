using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Fuel_Data_Scraper.Models;

using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;


namespace Fuel_Data_Scraper.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


private static async Task<string> CallUrl(string fullUrl)
{
	HttpClient client = new HttpClient();
	var response = await client.GetStringAsync(fullUrl);
	return response;
}
    public IActionResult Index()
    {
        string url = "https://www.sapia.org.za/fuel-prices/";
        var response = CallUrl(url).Result;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
