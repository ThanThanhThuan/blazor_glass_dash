using System.Text.Json.Serialization;

namespace BlazorDashboard.Models
{
    public record StatItem(int Id, string Label, string Value, string Change, string ChangeType, string IconColor, string IconPath);
    public record ChartItem(string Label, string Height, string ColorClass);
    public record ActivityItem(int Id, string Name, string Action, string Time, string Avatar, string Color);
    public record ProjectProgressItem(string Label, int Value, string Color);
    public record PageAnalyticsItem(int Rank, string Path, string Views, string Color);
    public record BrowserStatItem(string Label, int Value, string Color);
    public record UserItem(
    int Id,
    string Name,
    string Email,
    string Role,
    string Status,
    string StatusText,
    string Joined,
    string Active,
    string Initials,
    string Gradient
);
    public class BillingRecord
    {
        [JsonPropertyName("id")]
        public object? Id { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; } = "";

        [JsonPropertyName("desc")]
        public string Desc { get; set; } = "";

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = "";

        [JsonPropertyName("sub_table")]
        public string Sub_Table { get; set; } = "billing";
    }
    public class BillingResponse
    {
        [JsonPropertyName("data")]
        public List<BillingRecord> Data { get; set; } = new();
    }
}
