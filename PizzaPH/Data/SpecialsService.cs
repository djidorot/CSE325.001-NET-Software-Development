using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaPH.Data;

public class SpecialsService
{
    public Task<List<PizzaSpecial>> GetSpecialsAsync() =>
        Task.FromResult(new List<PizzaSpecial>
        {
            new() { Name = "Classic Pepperoni", Description = "Pepperoni + mozzarella", BasePrice = 320m, ImagePath = "images/pepperoni.png" },
            new() { Name = "Hawaiian", Description = "Ham + pineapple", BasePrice = 350m, ImagePath = "images/hawaiian.png" },
            new() { Name = "All-Meat", Description = "Sausage, bacon, ham", BasePrice = 420m, ImagePath = "images/allmeat.png" },
        });
}
