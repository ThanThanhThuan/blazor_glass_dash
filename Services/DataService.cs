using BlazorDashboard.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization; // Add this for NumberHandling

namespace BlazorDashboard.Services;

public class DataService
{
    private readonly HttpClient _http;
    private readonly IConfiguration _config;
    private readonly string _baseUrl = "https://api.nocodebackend.com";

    public DataService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _config = config;
    }
  
    // --- 1. DASHBOARD CONSTANTS ---
    public readonly List<StatItem> DashboardStats = new()
    {
        new(1, "Total Revenue", "$84,254", "+12.5%", "positive", "cyan",
            "<line x1='12' y1='1' x2='12' y2='23' /><path d='M17 5H9.5a3.5 3.5 0 0 0 0 7h5a3.5 3.5 0 0 1 0 7H6' />"),
        new(2, "Active Users", "24,521", "+8.2%", "positive", "magenta",
            "<path d='M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2' /><circle cx='9' cy='7' r='4' /><path d='M23 21v-2a4 4 0 0 0-3-3.87' /><path d='M16 3.13a4 4 0 0 1 0 7.75' />"),
        new(3, "Total Orders", "8,461", "-3.1%", "negative", "purple",
            "<circle cx='9' cy='21' r='1' /><circle cx='20' cy='21' r='1' /><path d='M1 1h4l2.68 13.39a2 2 0 0 0 2 1.61h9.72a2 2 0 0 0 2-1.61L23 6H6' />"),
        new( 4, "Conversion Rate", "3.24%","+2.4%", "positive", "success","<polyline points = '22 12 18 12 15 21 9 3 6 12 2 12' />")
    };

    public readonly List<ChartItem> RevenueChartData = new()
    {
        new("Jan", "120px", "bar-emerald"),
        new("Feb", "160px", "bar-gold"),
        new("Mar", "90px", "bar-coral"),
        new("Apr", "140px", "bar-teal"),
        new("May", "180px", "bar-amber"),
        new("Jun", "130px", "bar-emerald")
    };

    public readonly List<ActivityItem> RecentActivity = new()
    {
        new(1, "John Doe", "purchased Premium Plan", "2 mins ago", "JD", "linear-gradient(135deg, var(--emerald-light), var(--emerald))"),
        new(2, "Anna Smith", "submitted a ticket", "15 mins ago", "AS", "linear-gradient(135deg, var(--gold), var(--amber))")
    };

    public readonly List<ProjectProgressItem> ProjectProgress = new()
    {
        new("UI Design", 85, "cyan"),
        new("Backend API", 62, "magenta"),
        new("Testing", 45, "purple")
    };

    public readonly List<StatItem> AnalyticsStats = new()
{
    new(1, "Page Views", "1,284,521", "+24.5%", "positive", "cyan", "<path d='M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z'/><circle cx='12' cy='12' r='3'/>"),
    new(2, "Unique Visitors", "452,892", "+18.3%", "positive", "magenta", "<path d='M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2'/><circle cx='12' cy='7' r='4'/>"),
    new(3, "Bounce Rate", "32.8%", "+5.2%", "negative", "purple", "<polyline points='22 7 13.5 15.5 8.5 10.5 2 17'/><polyline points='16 7 22 7 22 13'/>"),
    new(4, "Avg. Session", "4:32", "+12.1%", "positive", "success", "<circle cx='12' cy='12' r='10'/><polyline points='12 6 12 12 16 14'/>")
};

    public readonly List<ChartItem> TrafficChartData = Enumerable.Range(1, 30).Select(i =>
        new ChartItem(i.ToString(), $"{new Random().Next(50, 200)}px", i % 2 == 0 ? "bar-emerald" : "bar-gold")).ToList();

    public readonly List<PageAnalyticsItem> TopPages = new()
{
    new(1, "/dashboard", "45,234 views", "emerald"),
    new(2, "/products", "32,891 views", "gold"),
    new(3, "/pricing", "28,456 views", "coral")
};

    public readonly List<BrowserStatItem> BrowserStats = new()
{
    new("Chrome", 64, "cyan"),
    new("Safari", 22, "magenta"),
    new("Firefox", 8, "purple")
};

    public readonly List<BrowserStatItem> CountryStats = new()
{
    new("🇺🇸 United States", 38, "cyan"),
    new("🇬🇧 United Kingdom", 18, "magenta"),
    new("🇩🇪 Germany", 12, "purple")
};

    public readonly List<StatItem> UserStats = new()
{
    new(1, "Total Users", "24,521", "+8.2%", "positive", "cyan", "<path d='M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2'/><circle cx='9' cy='7' r='4'/><path d='M23 21v-2a4 4 0 0 0-3-3.87'/><path d='M16 3.13a4 4 0 0 1 0 7.75'/>"),
    new(2, "Active Now", "1,234", "+12.5%", "positive", "magenta", "<circle cx='12' cy='12' r='10'/><path d='M12 6v6l4 2'/>"),
    new(3, "New Today", "156", "-3.1%", "negative", "purple", "<path d='M16 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2'/><circle cx='8.5' cy='7' r='4'/><line x1='20' y1='8' x2='20' y2='14'/><line x1='23' y1='11' x2='17' y2='11'/>"),
    new(4, "Premium Users", "4,892", "+18.7%", "positive", "success", "<polygon points='12 2 15.09 8.26 22 9.27 17 14.14 18.18 21.02 12 17.77 5.82 21.02 7 14.14 2 9.27 8.91 8.26 12 2'/>")
};

    public readonly List<UserItem> UsersList = new()
{
    new(1, "John Doe", "john@example.com", "Administrator", "completed", "Active", "Jan 15, 2024", "2 mins ago", "JD", "linear-gradient(135deg, var(--emerald-light), var(--emerald))"),
    new(2, "Anna Smith", "anna@example.com", "Editor", "completed", "Active", "Feb 22, 2024", "15 mins ago", "AS", "linear-gradient(135deg, var(--gold), var(--amber))"),
    new(3, "Mike Johnson", "mike@example.com", "User", "pending", "Away", "Mar 10, 2024", "2 hours ago", "MJ", "linear-gradient(135deg, var(--success), var(--emerald))"),
    new(4, "Emily White", "emily@example.com", "Moderator", "completed", "Active", "Apr 5, 2024", "30 mins ago", "EW", "linear-gradient(135deg, var(--coral), var(--gold))")
};
    // --- 2. LIVE BILLING DATA ---
    // 1. Fixed Mock Records (Design-only)
    private static readonly List<BillingRecord> _mockRecords = new()
    {
        new() { Id = "m1", Date = "2025-01-01 10:00:00", Desc = "Enterprise Plan (Fixed Mock)", Amount = 199.00, Status = "Paid" },
        new() { Id = "m2", Date = "2024-12-15 09:30:00", Desc = "Pro Plan (Fixed Mock)", Amount = 29.00, Status = "Paid" },
        new() { Id = "m3", Date = "2024-11-01 14:20:00", Desc = "Starter Plan (Fixed Mock)", Amount = 9.00, Status = "Paid" }
    };

    // The list used by UI (Settings.razor uses this)
    public List<BillingRecord> BillingHistory { get; private set; } = new(_mockRecords);

   
    private void SetHeaders() =>
        _http.DefaultRequestHeaders.Authorization = new("Bearer", _config["VITE_API_TOKEN"]);

    public async Task FetchBillingHistory()
    {
        SetHeaders();
        var url = $"{_baseUrl}/read/{_config["VITE_TABLE_NAME"]}?Instance={_config["VITE_INSTANCE_ID"]}&sub_table=billing";

        try
        {
            var response = await _http.GetAsync(url);
            var jsonString = await response.Content.ReadAsStringAsync();

            // Configure options to handle "29.00" (string) -> 29.0 (double)
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString
            };

            // Deserialize using the wrapper
            var apiResult = JsonSerializer.Deserialize<BillingResponse>(jsonString, options);
            var dbRecords = apiResult?.Data ?? new List<BillingRecord>();

            // Merge and Sort
            BillingHistory = dbRecords
                .Concat(_mockRecords)
                .OrderByDescending(x => DateTime.TryParse(x.Date, out var d) ? d : DateTime.MinValue)
                .ToList();

            Console.WriteLine($"Success! Loaded {dbRecords.Count} records from DB.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fetch Error: {ex.Message}");
            BillingHistory = _mockRecords.OrderByDescending(x => x.Date).ToList();
        }
    }

    // CRUD Methods (Only target the Database)
    public async Task<bool> CreateBilling(BillingRecord record)
    {
        SetHeaders();
        var url = $"{_baseUrl}/create/{_config["VITE_TABLE_NAME"]}?Instance={_config["VITE_INSTANCE_ID"]}";
        var response = await _http.PostAsJsonAsync(url, record);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateBilling(object id, BillingRecord record)
    {
        SetHeaders();
        var url = $"{_baseUrl}/update/{_config["VITE_TABLE_NAME"]}/{id}?Instance={_config["VITE_INSTANCE_ID"]}";
        var response = await _http.PutAsJsonAsync(url, record);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteBilling(object id)
    {
        SetHeaders();
        var url = $"{_baseUrl}/delete/{_config["VITE_TABLE_NAME"]}/{id}?Instance={_config["VITE_INSTANCE_ID"]}";
        var response = await _http.DeleteAsync(url);
        return response.IsSuccessStatusCode;
    }
}