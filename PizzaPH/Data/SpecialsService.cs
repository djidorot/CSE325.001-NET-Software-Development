using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaPH.Data;

public class SpecialsService
{
    public Task<List<PizzaSpecial>> GetSpecialsAsync() =>
        Task.FromResult(new List<PizzaSpecial>
        {
            new() { Name = "Classic Pepperoni", Description = "Pepperoni + mozzarella", BasePrice = 320m },
            new() { Name = "Hawaiian", Description = "Ham + pineapple", BasePrice = 350m },
            new() { Name = "All-Meat", Description = "Sausage, bacon, ham", BasePrice = 420m },
        });
}
