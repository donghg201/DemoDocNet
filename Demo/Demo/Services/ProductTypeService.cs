using Demo.Dto;
using Demo.Models;
using Demo.Uow.IUow;
using System.Collections.Generic;

namespace Demo.Services
{
    public class ProductTypeService
    {
        private readonly IProductTypeUow _uow;

        public ProductTypeService(IProductTypeUow uow)
        {
            this._uow = uow;
        }

        public void AddProductType(ProductTypeDto productType)
        {
            ProductType _productType = new()
            {
                ProductTypeCd = productType.ProductTypeCd,
                Name = productType.Name,
            };
            this._uow.ProductTypeRepository.Add(_productType);
            this._uow.SaveChanges();
        }

        public List<ProductType> GetAllProductType()
        {
            return this._uow.ProductTypeRepository.FetchAll();
        }

        public ProductType GetProductTypeById(string id)
        {
            var productType = this._uow.ProductTypeRepository.FindById(id);
            if (productType == null)
            {
                return null;
            }
            return productType;
        }

        public void UpdateProductType(ProductTypeDto productType, string id)
        {

            ProductType _productType = new()
            {
                Name = productType.Name,
            };
            this._uow.ProductTypeRepository.Update(_productType, id);
            this._uow.SaveChanges();
        }

        public void RemoveProductType(string id)
        {
            this._uow.ProductTypeRepository.Delete(id);
            this._uow.SaveChanges();
        }
    }
}
