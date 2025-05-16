namespace my_aspnet_app.Models;

public class RouletteBet
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public decimal BetAmount { get; set; }
    public string BetColor { get; set; } = string.Empty; // Например, "red", "black", "green"
    public DateTime BetTime { get; set; }
}

public class RouletteResult
{
    public int Id { get; set; }
    public string WinningColor { get; set; } = string.Empty;
    public DateTime ResultTime { get; set; }
}

public class Case
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Item> Items { get; set; } = new();
}

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Rarity { get; set; } = string.Empty; // Например, "common", "rare", "epic", "legendary"
    public string ImageUrl { get; set; } = string.Empty;
}