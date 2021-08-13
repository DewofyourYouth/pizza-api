using ContosoPizza.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContosoPizza.Services
{
    public static class PizzaService
    {
        private static List<Pizza> GetPizzas()
        {
            using (var context = new PizzaContext())
            {
                return context.Pizzas.ToList();
            }
        }

        static List<Pizza> Pizzas { get; }

        static PizzaService()
        {
            Pizzas = GetPizzas();
        }

        public static List<Pizza> GetAll() => Pizzas;

        public static Pizza Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

        public static void Add(Pizza pizza)
        {
            var db = new PizzaContext();
            db.Add(pizza);
            db.SaveChanges();
            Pizzas.Add(pizza);
        }


        public static void Delete(int id)
        {
            // TODO: This needs to be updated to use the DB
            var pizza = Get(id);
            if (pizza is null)
                return;

            Pizzas.Remove(pizza);
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