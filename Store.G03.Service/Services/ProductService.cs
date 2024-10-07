using AutoMapper;
using Store.G03.Core;
using Store.G03.Core.Dtos.Products;
using Store.G03.Core.Entites;
using Store.G03.Core.Helper;
using Store.G03.Core.Services.contract;
using Store.G03.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G03.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWorkcs _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWorkcs unitOfWorkcs, IMapper mapper)
        {
            _unitOfWork = unitOfWorkcs;
            _mapper = mapper;
        } 
        public async Task<PaginationResponse<ProductDto>> GetAllProductsAsync(ProductSpecParams productSpecParams)
        {
            var spec = new ProductSpecifications(productSpecParams);
            var products= await _unitOfWork.Repository<Product, int>().GetWithSpecAsync(spec);
            var mappedProducts = _mapper.Map<IEnumerable<ProductDto>>(products);
            var countSpec = new ProductWithCountSpec(productSpecParams);
            var count =await _unitOfWork.Repository<Product, int>().GetCountAsync(countSpec);
            return new PaginationResponse<ProductDto>(productSpecParams.pageSize,productSpecParams.pageIndex, count, mappedProducts);

        }
        public async Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync()
        {
            return _mapper.Map<IEnumerable<TypeBrandDto>>(await _unitOfWork.Repository<ProductType, int>().GetAllAsync());
        }
        public async Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync();
            var mappedBrands = _mapper.Map<IEnumerable<TypeBrandDto>>(brands);
            return mappedBrands;
        }


        public async Task<ProductDto> GetProductById(int id)
        {
            var spec = new ProductSpecifications(id);
            var product = await _unitOfWork.Repository<Product, int>().GetWithSpecAsync(spec);
            var mappedproduct = _mapper.Map<ProductDto>(product);
            return mappedproduct;
        }
    }
}
