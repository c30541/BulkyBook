using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var objFormDb = _db.Products.FirstOrDefault(s => s.Id == product.Id);
            if (objFormDb != null)
            {
                if (product.ImageUrl != null)
                    objFormDb.ImageUrl = product.ImageUrl;

                objFormDb.ISBN = product.ISBN;
                objFormDb.Price = product.Price;
                objFormDb.Price50 = product.Price50;
                objFormDb.ListPrice = product.ListPrice;
                objFormDb.Price100 = product.Price100;
                objFormDb.Title = product.Title;
                objFormDb.Description = product.Description;
                objFormDb.CategoryId = product.CategoryId;
                objFormDb.Author = product.Author;
                objFormDb.CoverTypeId = product.CoverTypeId;
            }
        }
    }
}
