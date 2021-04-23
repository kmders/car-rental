using Application.Infrastructure.Persistence;
using Application.Services.Common;
using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Concrete
{
    public class VehicleClassTypeService : BaseService, IVehicleClassTypeService
    {
        public VehicleClassTypeService(ICarRentalDbContext context) : base(context)
        {

        }

        public Response Add(VehicleClassType vehicleClassType)
        {
            var checkResponse = CheckToAddOrUpdate(vehicleClassType);
            if (!checkResponse.IsSuccess)
                return checkResponse;

            Context.VehicleClassType.Add(vehicleClassType);
            Context.SaveChanges();

            return Response.Success("Araç sınıfı başarıyla kaydedildi");
        }
        private Response CheckToAddOrUpdate(VehicleClassType vehicleClassType)
        {
            int sameNumberOfRecords = (from b in Context.VehicleClassType
                                       where b.Name == vehicleClassType.Name && b.Id != vehicleClassType.Id
                                       select b
                                       ).Count();
            if (sameNumberOfRecords > 0)
            {
                return Response.Fail($"{vehicleClassType.Name} araç sınıfı sistemde zaten kayıtlıdır.");
            }
            return Response.Success();
        }
        public Response Update(VehicleClassType vehicleClassType)
        {
            var checkResponse = CheckToAddOrUpdate(vehicleClassType);
            if (!checkResponse.IsSuccess)
                return checkResponse;

            var vehicleClassTypeToUpdate = GetById(vehicleClassType.Id);
            vehicleClassTypeToUpdate.Name = vehicleClassType.Name;
            Context.SaveChanges();

            return Response.Success("Araç sınıfı başarıyla güncellendi");
        }
        public Response Delete(int id)
        {
            var vehicleClassTypeToDelete = GetById(id);
            Context.VehicleClassType.Remove(vehicleClassTypeToDelete);
            Context.SaveChanges();

            return Response.Success("Araç sınıfı başarıyla silindi");
        }

        public VehicleClassType GetById(int id)
        {
            return Context.VehicleClassType.Where(v => v.Id == id).SingleOrDefault();
        }
        public List<VehicleClassType> Get(VehicleClassTypeFilter filter)
        {
            var items = (from v in Context.VehicleClassType
                         where v.Name.StartsWith(filter.Name)
                         orderby v.Name
                         select v).ToList();
            return items;
        }
    }
}
