using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IProductServiceWithDto : IServiceWithDto<Product, ProductDto>
    {
        Task<CustomReponseDto<List<ProductWithCategoryDto>>> GetProductWithCategory();
        Task<CustomReponseDto<NoContentDto>> UpdateAsync(ProductUpdateDto dto);
        Task<CustomReponseDto<ProductDto>> AddAsync(ProductCreateDto dto);
    }
}
