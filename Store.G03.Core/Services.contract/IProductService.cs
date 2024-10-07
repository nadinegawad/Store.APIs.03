using Store.G03.Core.Dtos.Products;
using Store.G03.Core.Entites;
using Store.G03.Core.Helper;
using Store.G03.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G03.Core.Services.contract
{
    public interface IProductService
    {
        Task<PaginationResponse<ProductDto>> GetAllProductsAsync(ProductSpecParams productSpecParams);
        Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync();
        Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync();
        Task<ProductDto> GetProductById(int id);
    }
}
