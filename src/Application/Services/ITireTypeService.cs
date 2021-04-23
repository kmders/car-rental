using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Services
{
    public interface ITireTypeService
    {
        Response Add(TireType tireType);
        Response Update(TireType tireType);
        Response Delete(int id);
        TireType GetById(int id);
        List<TireType> Get(TireTypeFilter filter);
    }
}
