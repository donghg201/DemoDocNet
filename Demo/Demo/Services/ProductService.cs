using Demo.Dto;
using Demo.Models;
using Demo.Uow.IUow;
using System.Collections.Generic;

namespace Demo.Services
{
    public class ProductService
    {
        private readonly IProductUow _uow;

        public ProductService(IProductUow uow)
        {
            this._uow = uow;
        }

        public void AddProduct(ProductDto product)
        {
            Product _product = new()
            {
                ProductCd = product.ProductCd,
                DateOffered = product.DateOffered,
                DateRetired = product.DateRetired,
                Name = product.Name,
                ProductTypeCd = product.ProductTypeCd,
            };
            this._uow.ProductRepository.Add(_product);
            this._uow.SaveChanges();
        }

        public List<Product> GetAllProduct()
        {
            return this._uow.ProductRepository.FetchAll();
        }

        public Product GetProductById(string id)
        {
            return this._uow.ProductRepository.FindById(id);
        }

        public void UpdateProduct(ProductDto product, string id)
        {

            Product _product = new()
            {
                DateOffered = product.DateOffered,
                DateRetired = product.DateRetired,
                Name = product.Name,
                ProductTypeCd = product.ProductTypeCd,
            };
            this._uow.ProductRepository.Update(_product, id);
            this._uow.SaveChanges();
        }

        public void RemoveProduct(string id)
        {
            this._uow.ProductRepository.Delete(id);
            this._uow.SaveChanges();
        }

        public ProductType GetProductTypeById(string id)
        {
            return this._uow.ProductTypeRepository.FindById(id);
        }
    }
}
