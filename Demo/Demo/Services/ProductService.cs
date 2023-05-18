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

        public List<ProductDto> GetAllProduct()
        {
            List<ProductDto> result = new();
            var productList = this._uow.ProductRepository.FetchAll();
            foreach(Product product in productList)
            {
                ProductDto productDto = new()
                {
                    Name = product.Name,
                    ProductCd = product.ProductCd,
                    DateOffered = product.DateOffered,
                    DateRetired = product.DateRetired,
                    ProductTypeCd = product.ProductTypeCd,
                };
                result.Add(productDto);
            }

            return result;
        }

        public ProductDto GetProductById(string id)
        {
            var product =  this._uow.ProductRepository.FindById(id);
            if(product == null)
            {
                return null;
            }
            ProductDto productDto = new()
            {
                Name = product.Name,
                ProductCd = product.ProductCd,
                DateOffered = product.DateOffered,
                DateRetired = product.DateRetired,
                ProductTypeCd = product.ProductTypeCd,
            };
            return productDto;
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
