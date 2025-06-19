namespace KE03_INTDEV_SE_2_Base.Models
{
    public class DashboardViewModel
    {
        public List<MonthCount> OrdersPerMonth { get; set; } = new();
        public List<MonthCount> CustomersPerMonth { get; set; } = new();
        public decimal TotalRevenue { get; set; }
        public List<DataAccessLayer.Models.Product> LowStockProducts { get; set; } = new();
    }

    public class MonthCount
    {
        public string Month { get; set; } = "";
        public int Count { get; set; }
    }
}