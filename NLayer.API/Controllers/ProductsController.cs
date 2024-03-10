using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private IProductService _productService;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("GetProductsWithCategory")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productService.GetProductsWithCategory());
        }


        [HttpGet("All")]
        public async Task<IActionResult> All()
        {
            var products = await _productService.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            //return Ok(CustomReponseDto<List<ProductDto>>.Success(200, productsDtos));

            return CreateActionResult(CustomReponseDto<List<ProductDto>>.Success(200, productsDtos));
        }

        // GET /api/products/5
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDto>(product);
            //return Ok(CustomReponseDto<List<ProductDto>>.Success(200, productsDtos));

            return CreateActionResult(CustomReponseDto<ProductDto>.Success(200, productsDto));
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            //return Ok(CustomReponseDto<List<ProductDto>>.Success(200, productsDtos));

            return CreateActionResult(CustomReponseDto<ProductDto>.Success(201, productsDto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productDto));

            return CreateActionResult(CustomReponseDto<NoContentDto>.Success(204));
        }


        // DELETE api/products/5
        [HttpGet("Remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                CreateActionResult(CustomReponseDto<NoContentDto>.Fail(404, "Bu id'ye sahip utun bulunamadi."));

            await _productService.RemoveAsync(product);

            return CreateActionResult(CustomReponseDto<NoContentDto>.Success(204));
        }
    }
}
