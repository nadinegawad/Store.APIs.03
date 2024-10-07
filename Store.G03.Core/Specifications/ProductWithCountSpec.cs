using Store.G03.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G03.Core.Specifications
{
    public class ProductWithCountSpec :BaseSpecifications<Product,int>
    {
        public ProductWithCountSpec(ProductSpecParams productSpecParams) : base(
            P =>
              (string.IsNullOrEmpty(productSpecParams.Search) && (P.Name.ToLower().Contains(productSpecParams.Search)))
            &&
            (!productSpecParams.brandId.HasValue || productSpecParams.brandId == P.BrandId)
            &&
            (!productSpecParams.typeId.HasValue || productSpecParams.typeId == P.TypeId)
            )
        {
           
          
        }

    }
}
