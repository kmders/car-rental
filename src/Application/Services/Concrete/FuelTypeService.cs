using Application.Infrastructure.Persistence;
using Application.Services.Common;
using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Concrete
{
    public class FuelTypeService : BaseService, IFuelTypeService
    {
        public FuelTypeService(ICarRentalDbContext context) : base(context)
        {

        }

        public Response Add(FuelType fuelType)
        {
            var checkResponse = CheckToAddOrUpdate(fuelType);
            if (!checkResponse.IsSuccess)
                return checkResponse;

            Context.FuelType.Add(fuelType);
            Context.SaveChanges();

            return Response.Success("Yakıt türü başarıyla kaydedildi");
        }
        private Response CheckToAddOrUpdate(FuelType fuelType)
        {
            int sameNumberOfRecords = (from b in Context.FuelType
                                       where b.Name == fuelType.Name && b.Id != fuelType.Id
                                       select b
                                       ).Count();
            if (sameNumberOfRecords > 0)
            {
                return Response.Fail($"{fuelType.Name} yakıt türü sistemde zaten kayıtlıdır.");
            }
            return Response.Success();
        }
        public Response Update(FuelType fuelType)
        {
            var checkResponse = CheckToAddOrUpdate(fuelType);
            if (!checkResponse.IsSuccess)
                return checkResponse;

            var fuelTypeToUpdate = GetById(fuelType.Id);
            fuelTypeToUpdate.Name = fuelType.Name;
            Context.SaveChanges();

            return Response.Success("Yakıt türü başarıyla güncellendi");
        }
        public Response Delete(int id)
        {
            var fuelTypeToDelete = GetById(id);
            Context.FuelType.Remove(fuelTypeToDelete);
            Context.SaveChanges();

            return Response.Success("Yakıt türü başarıyla silindi");
        }

        public FuelType GetById(int id)
        {
            return Context.FuelType.Where(v => v.Id == id).SingleOrDefault();
        }
        public List<FuelType> Get(FuelTypeFilter filter)
        {
            var items = (from v in Context.FuelType
                         where v.Name.StartsWith(filter.Name)
                         orderby v.Name
                         select v).ToList();
            return items;
        }
    }
}
