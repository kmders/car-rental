using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IVehicleClassTypeService
    {
        Response Add(VehicleClassType vehicleClassType);
        Response Update(VehicleClassType vehicleClassType);
        Response Delete(int id);
        VehicleClassType GetById(int id);
        List<VehicleClassType> Get(VehicleClassTypeFilter filter);
    }
}
