using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IServiceWithDto<Entity, Dto> where Entity : BaseEntity where Dto : class
    {
        Task<CustomReponseDto<Dto>> GetByIdAsync(int id);

        // productRepository.GetAll(x=>x.id>5).ToList();
        Task<CustomReponseDto<IEnumerable<Dto>>> GetAllAsync();

        // productRepository.GetAll(x=>x.id>5).OrderBy.ToList();
        Task<CustomReponseDto<IEnumerable<Dto>>> Where(Expression<Func<Entity, bool>> expression);

        Task<CustomReponseDto<bool>> AnyAsync(Expression<Func<Entity, bool>> expression);

        Task<CustomReponseDto<IEnumerable<Dto>>> AddRangeAsync(IEnumerable<Dto> dtos);

        Task<CustomReponseDto<Dto>> AddAsync(Dto dto);

        Task<CustomReponseDto<NoContentDto>> UpdateAsync(Dto dto);

        Task<CustomReponseDto<NoContentDto>> RemoveAsync(int id);

        Task<CustomReponseDto<NoContentDto>> RemoveRangeAsync(IEnumerable<int> ids);
    }
}
