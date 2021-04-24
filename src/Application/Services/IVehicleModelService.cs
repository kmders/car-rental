using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IVehicleModelService
    {
        Response Add(VehicleModel vehicleModel);
        Response Update(VehicleModel vehicleModel);
        Response Delete(int id);
        VehicleModel GetById(int id);
        List<VehicleModelDTO> Get(VehicleModelFilter filter);
        VehicleModelDTO GetDetail(int id);
    }
}
