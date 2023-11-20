using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
                _products = new List<Product> { 
                new Product{CategoryID=1,ProductID=1,ProductName="Glass",UnitPrice=15,UnitsInStock=15},
                new Product{CategoryID=2,ProductID=2,ProductName="Knife",UnitPrice=500,UnitsInStock=3},
                new Product{CategoryID=3,ProductID=3,ProductName="Bord",UnitPrice=60,UnitsInStock=5},

                };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryID == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void UpDate(Product product)
        {
            Product productToUpdate=_products.SingleOrDefault(p=>p.ProductID== product.ProductID);
            productToUpdate.ProductName= product.ProductName;
            productToUpdate.UnitPrice= product.UnitPrice;
            productToUpdate.ProductID= product.ProductID;
            productToUpdate.CategoryID= product.CategoryID;
        }
    }
}
