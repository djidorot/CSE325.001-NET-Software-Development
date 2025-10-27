using PizzaApi.Models;

namespace PizzaApi.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int nextId = 3;
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Margherita", IsGlutenFree = false, Price = 8.50m },
            new Pizza { Id = 2, Name = "Pepperoni",  IsGlutenFree = false, Price = 9.75m }
        };
    }

    public static List<Pizza> GetAll() => Pizzas;
    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);
    public static Pizza Create(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
        return pizza;
    }
    public static void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null) return;
        Pizzas.Remove(pizza);
    }
    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1) return;
        Pizzas[index] = pizza;
    }
}
