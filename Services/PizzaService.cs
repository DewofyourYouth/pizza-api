using ContosoPizza.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContosoPizza.Services
{
    public static class PizzaService
    {
        private static PizzaContext context = new PizzaContext();

        private static List<Pizza> GetPizzas()
        {

            return context.Pizzas.ToList();

        }

        static List<Pizza> Pizzas { get; }

        static PizzaService()
        {
            Pizzas = GetPizzas();
        }

        public static List<Pizza> GetAll() => context.Pizzas.ToList();

        public static Pizza Get(int id)
        {
            var pizza = context.Pizzas.Single(p => p.Id == id);
            return pizza;
        }
        public static void Add(Pizza pizza)
        {
            context.Add(pizza);
            context.SaveChanges();
            Pizzas.Add(pizza);
        }


        public static void Delete(int id)
        {
            // TODO: This needs to be updated to use the DB
            var context = new PizzaContext();
            var pizza = Get(id);
            if (pizza is null)
                return;

            context.Remove(pizza);
            context.SaveChanges();

        }

        public static void Update(Pizza pizza)
        {
            // TODO: This needs to be updated to work with DB
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index == -1)
                return;

            Pizzas[index] = pizza;
        }
    }
}