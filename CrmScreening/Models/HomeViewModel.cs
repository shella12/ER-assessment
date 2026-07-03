namespace CrmScreening.Models;

// Backs the Home page which showcases Task 1 (summaries) and Task 2 (LINQ results).
public class HomeViewModel
{
    // Task 1 — two hardcoded customers shown via their GetSummary() string.
    public List<Customer> SummaryCustomers { get; set; } = new();

    // Task 2 — LINQ query results.
    public List<Customer> ActiveSortedByName { get; set; } = new();
    public Customer? FirstGmailCustomer { get; set; }
    public int CreatedThisYearCount { get; set; }
    public int CurrentYear { get; set; }
}
