using MKIPizza.Models;

namespace MKIPizza.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int nextId = 11;

    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza
            {
                Id = 1,
                Name = "Classic Italian",
                IsGlutenFree = false
            },
            new Pizza
            {
                Id = 2,
                Name = "Veggie",
                IsGlutenFree = true
            },
            new Pizza
            {
                Id = 3,
                Name = "Pepperoni",
                IsGlutenFree = false
            },
            new Pizza
            {
                Id = 4,
                Name = "Margherita",
                IsGlutenFree = false
            },
            new Pizza
            {
                Id = 5,
                Name = "BBQ Chicken",
                IsGlutenFree = false
            },
            new Pizza
            {
                Id = 6,
                Name = "Hawaiian",
                IsGlutenFree = false
            },
            new Pizza
            {
                Id = 7,
                Name = "Mushroom and Olive",
                IsGlutenFree = true
            },
            new Pizza
            {
                Id = 8,
                Name = "Spinach and Feta",
                IsGlutenFree = true
            },
            new Pizza
            {
                Id = 9,
                Name = "Meat Lovers",
                IsGlutenFree = false
            },
            new Pizza
            {
                Id = 10,
                Name = "Supreme",
                IsGlutenFree = false
            }
        };
    }

    public static List<Pizza> GetAll() => Pizzas;

    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(pizza => pizza.Id == id);

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null)
            return;
        Pizzas.Remove(pizza);
    }

    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(pizza => pizza.Id == pizza.Id);
        if (index == -1)
            return;
        Pizzas[index] = pizza;
    }
}
