# CRM Screening — ASP.NET Core MVC

Solution to the CRM Developer screening tasks (see [`ScreeningTasks.md`](ScreeningTasks.md)).
A single **ASP.NET Core MVC** application (.NET 8) using **in-memory data** throughout — no database required.

## Run it

```bash
cd CrmScreening
dotnet run
```

Then open the URL shown in the console (e.g. `https://localhost:xxxx`).

## Where each task lives

| Task | Description | Key files |
|------|-------------|-----------|
| **1** | `Customer` model with properties + `GetSummary()`; two hardcoded customers shown on Home | `Models/Customer.cs`, `Controllers/HomeController.cs`, `Views/Home/Index.cshtml` |
| **2** | LINQ: active customers sorted by name; first Gmail customer; count created this year | `Controllers/HomeController.cs`, `Views/Home/Index.cshtml` |
| **3** | Customers list page — Bootstrap 5 table + nav link | `Controllers/CustomersController.cs`, `Views/Customers/Index.cshtml`, `Views/Shared/_Layout.cshtml` |
| **4** | Create form with validation (Full Name required) → redirect to list | `Controllers/CustomersController.cs`, `Views/Customers/Create.cshtml` |
| **5** | Real-time notifications across browser tabs via SignalR | `Hubs/NotificationHub.cs`, `Program.cs`, `Views/Home/Notifications.cshtml` |

Shared in-memory data lives in `Data/CustomerStore.cs`.

## Verifying Task 5 (SignalR)

1. Run the app and open **Notifications** in two browser tabs.
2. Type a message in one tab and click **Send**.
3. The message appears instantly in both tabs — no page refresh.

## Requirements

- .NET 8 SDK
