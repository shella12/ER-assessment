using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CrmScreening.Data;
using CrmScreening.Models;

namespace CrmScreening.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Task 1 — two hardcoded customers displayed via GetSummary().
        var hardcoded = new List<Customer>
        {
            new() { Id = 101, FullName = "John Smith",   Email = "john.smith@gmail.com",     Phone = "0311-1112223", CreatedAt = new DateTime(2023, 3, 15), IsActive = true  },
            new() { Id = 102, FullName = "Maria Garcia", Email = "maria.garcia@outlook.com", Phone = "0322-4445556", CreatedAt = new DateTime(2024, 9, 1),  IsActive = false },
        };

        // Task 2 — LINQ queries over a list of at least 5 customers.
        var customers = CustomerStore.All;
        var currentYear = DateTime.Now.Year;

        var model = new HomeViewModel
        {
            SummaryCustomers = hardcoded,

            // 1) Active customers sorted alphabetically by full name.
            ActiveSortedByName = customers
                .Where(c => c.IsActive)
                .OrderBy(c => c.FullName)
                .ToList(),

            // 2) The first customer with a Gmail address (null if none).
            FirstGmailCustomer = customers
                .FirstOrDefault(c => c.Email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase)),

            // 3) A count of customers created in the current year.
            CreatedThisYearCount = customers.Count(c => c.CreatedAt.Year == currentYear),

            CurrentYear = currentYear,
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // Task 5 — real-time notifications page.
    public IActionResult Notifications()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
