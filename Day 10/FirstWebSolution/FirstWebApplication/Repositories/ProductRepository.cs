﻿using FirstWebApplication.Interfaces;
using FirstWebApplication.Models;

namespace FirstWebApplication.Repositories
{
    public class ProductRepository : IRepository<int, Product>
    {
        static Dictionary<int, Product> products = new Dictionary<int, Product>() {
            {1,
                 new Product{
                        Id = 1,
                        Name="Pencil",
                        Price = 12.4f,
                        Quantity = 5,
                        Discount=5,
                        Description = "Used for writing and drawing",
                        Picture = "~/Images/Pencil.png",
                        Rating=3
                    }
            },
            {2,
                 new Product{
                        Id = 2,
                        Name="Pen",
                        Price = 30.75f,
                        Quantity = 3,
                        Discount=5,
                        Description = "Used for writing notes",
                        Picture = "~/Images/Pen.jpg",
                        Rating=4
                    }
            }
        };
        /// <summary>
        /// Adds the given product to the dictionary 
        /// </summary>
        /// <param name="product">Product object that has to be added</param>
        /// <returns>The product that has been added</returns>
        public Product Add(Product product)
        {
            int id = GetTheNextId();
            try
            {
                product.Id = id;
                products.Add(product.Id, product);
                return product;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("The product Id already exists");
                Console.WriteLine(e.Message);
            }
            return null;

        }

        private int GetTheNextId()
        {
            if (products.Count == 0)
                return 1;
            int id = products.Keys.Max();
            return ++id;
        }

        /// <summary>
        /// Deletes the product from teh dictionary using the id as key
        /// </summary>
        /// <param name="id">The Id of the product to be deleted</param>
        /// <returns>The deleted product</returns>
        public Product Delete(int id)
        {
            var product = products[id];
            products.Remove(id);
            return product;
        }

        public IList<Product> GetAll()
        {
            var productList = products.Values.ToList();
            return productList;
        }

        public Product Get(int id)
        {
            if (products.ContainsKey(id))
                return products[id];
            return null;
        }

        public Product Update(Product product)
        {
            products[product.Id] = product;
            return products[product.Id];
        }
    }
}