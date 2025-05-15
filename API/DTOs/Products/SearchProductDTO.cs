using System;

namespace API.DTOs;

public class SearchProductDTO
{
    public string? Name { get; set; }
    public string? Sort { get; set; }
    public int PriceMin { get; set; }
}
