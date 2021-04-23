using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IFuelTypeService
    {
        Response Add(FuelType fuelType);
        Response Update(FuelType fuelType);
        Response Delete(int id);
        FuelType GetById(int id);
        List<FuelType> Get(FuelTypeFilter filter);
    }
}
