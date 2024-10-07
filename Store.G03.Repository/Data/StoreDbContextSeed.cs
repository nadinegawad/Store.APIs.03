using Store.G03.Core.Entites;
using Store.G03.Repository.Data.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.G03.Repository.Data
{
    public class StoreDbContextSeed
    {
        public static async Task SeedAsync(StoreDbContext _context)
        {
            if (_context.ProductBrands.Count() == 0)
            {
                var BrandData = File.ReadAllText(@"..\Store.G03.Repository\Data\DataSeed\brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandData);

                if (brands is not null && brands.Count() > 0)
                {
                    await _context.ProductBrands.AddRangeAsync(brands);
                }
            }
            if (_context.ProductType.Count() == 0)
            {
                var TypeData = File.ReadAllText(@"..\Store.G03.Repository\Data\DataSeed\types.json");
                var Types = JsonSerializer.Deserialize<List<ProductType>>(TypeData);

                if (Types is not null && Types.Count() > 0)
                {
                    await _context.ProductType.AddRangeAsync(Types);
                }
            }
            if (_context.Products.Count() == 0)
            {
                var ProductData = File.ReadAllText(@"..\Store.G03.Repository\Data\DataSeed\types.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(ProductData);

                if (Products is not null && Products.Count() > 0)
                {
                    await _context.Products.AddRangeAsync(Products);

                }
            }
            await _context.SaveChangesAsync();
        }




























    }
}
