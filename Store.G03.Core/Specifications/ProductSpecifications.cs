using Store.G03.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G03.Core.Specifications
{
    public class ProductSpecifications : BaseSpecifications<Product, int>
    {
        public ProductSpecifications(int id) : base(P => P.Id == id)
        {
            ApplyIncludes();
        }
        public ProductSpecifications(ProductSpecParams productSpecParams) :base(
            P =>
            (string.IsNullOrEmpty(productSpecParams.Search)&&(P.Name.ToLower().Contains(productSpecParams.Search)))
            &&
            (!productSpecParams.brandId.HasValue || productSpecParams.brandId == P.BrandId)
            &&
            (!productSpecParams.typeId.HasValue || productSpecParams.typeId == P.TypeId)
            )
        {
            if (!string.IsNullOrEmpty(productSpecParams.sort))
            {
                switch (productSpecParams.sort)
                {
                    case "PriceAsc":
                        AddOrderby(P => P.Price); break;
                    case "PriceDesc":
                        AddOrderbyDesc(P => P.Price); break;
                    default:
                        AddOrderby(P => P.Name); break;
                }

            }
            else
            {
                AddOrderby(P => P.Name);
            }
            ApplyIncludes();
            ApplyPagination(productSpecParams.pageSize * (productSpecParams.pageIndex - 1), productSpecParams.pageSize);
        }
       
        private void ApplyIncludes()
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Type);
        }
    }
}
