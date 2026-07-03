using CrmScreening.Models;

namespace CrmScreening.Data;

// Shared in-memory data source used across the tasks (no database required).
// The list is mutable so the Create form (Task 4) can add new customers at runtime.
public static class CustomerStore
{
    private static readonly List<Customer> _customers;

    static CustomerStore()
    {
        var thisYear = DateTime.Now.Year;

        _customers = new List<Customer>
        {
            new() { Id = 1, FullName = "Ayesha Khan",   Email = "ayesha.khan@gmail.com",  Phone = "0300-1234567", CreatedAt = new DateTime(thisYear, 2, 14), IsActive = true  },
            new() { Id = 2, FullName = "Bilal Ahmed",   Email = "bilal.ahmed@yahoo.com",  Phone = "0301-2345678", CreatedAt = new DateTime(2021, 6, 9),      IsActive = true  },
            new() { Id = 3, FullName = "Sara Ali",      Email = "sara.ali@gmail.com",     Phone = "0302-3456789", CreatedAt = new DateTime(thisYear, 4, 22), IsActive = false },
            new() { Id = 4, FullName = "Danish Iqbal",  Email = "danish.iqbal@outlook.com", Phone = "0303-4567890", CreatedAt = new DateTime(2022, 11, 3),   IsActive = true  },
            new() { Id = 5, FullName = "Fatima Noor",   Email = "fatima.noor@hotmail.com", Phone = "0304-5678901", CreatedAt = new DateTime(thisYear, 1, 5),  IsActive = false },
            new() { Id = 6, FullName = "Usman Tariq",   Email = "usman.tariq@gmail.com",  Phone = "0305-6789012", CreatedAt = new DateTime(2020, 8, 18),     IsActive = true  },
        };
    }

    // Live view of all customers.
    public static IReadOnlyList<Customer> All => _customers;

    // Next sequential Id for a newly created customer.
    public static int NextId => _customers.Count == 0 ? 1 : _customers.Max(c => c.Id) + 1;

    public static void Add(Customer customer)
    {
        customer.Id = NextId;
        customer.CreatedAt = DateTime.Now;
        _customers.Add(customer);
    }
}
