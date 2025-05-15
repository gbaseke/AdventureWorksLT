namespace API.DTOs;

public class CreateProductDTO
{
    public int ProductID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? ProductNumber { get; set; } = string.Empty;
    public string? Color { get; set; } = string.Empty;
    public decimal StandardCost { get; set; }
    public decimal ListPrice { get; set; }
    public string? Size { get; set; } = string.Empty;
    public decimal? Weight { get; set; }
    public DateTime SellStartDate { get; set; }
    public DateTime? SellEndDate { get; set; }
    public DateTime? DiscontinuedDate { get; set; }
}
