namespace PizzaPH.Data;

public class PizzaSpecial
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal BasePrice { get; set; }

    // 👉 New property
    public string ImagePath { get; set; } = "";
}
