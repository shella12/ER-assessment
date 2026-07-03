using Microsoft.AspNetCore.Mvc;
using CrmScreening.Data;
using CrmScreening.Models;

namespace CrmScreening.Controllers;

public class CustomersController : Controller
{
    // Task 3 — list page. Passes a list of customers to the Razor view.
    public IActionResult Index()
    {
        return View(CustomerStore.All);
    }

    // Task 4 — show the Create form.
    [HttpGet]
    public IActionResult Create()
    {
        return View(new Customer());
    }

    // Task 4 — handle submission with validation.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Customer customer)
    {
        // Validate that Full Name is not empty; if invalid, redisplay the form
        // with an inline error message.
        if (string.IsNullOrWhiteSpace(customer.FullName))
        {
            ModelState.AddModelError(nameof(customer.FullName), "Full Name is required.");
        }

        if (!ModelState.IsValid)
        {
            return View(customer);
        }

        CustomerStore.Add(customer);
        return RedirectToAction(nameof(Index));
    }
}
