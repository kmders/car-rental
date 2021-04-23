using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IColorTypeService
    {
        Response Add(ColorType colorType);
        Response Update(ColorType colorType);
        Response Delete(int id);
        ColorType GetById(int id);
        List<ColorType> Get(ColorTypeFilter filter);
    }
}
