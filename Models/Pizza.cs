using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace ContosoPizza.Models {
    public class PizzaContext : DbContext {
        public DbSet<Pizza> Pizzas {get; set;}
        public string DbPath {get; private set;}

        public PizzaContext(){
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}blogging.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
    public class Pizza {
        public int Id {get; set;}
        public string Name {get; set;}
        public bool IsGlutenFree {get; set;}
    }
}