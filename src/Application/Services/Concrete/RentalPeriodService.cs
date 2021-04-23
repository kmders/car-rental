using Application.Infrastructure.Persistence;
using Application.Services.Common;
using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Concrete
{
    public class RentalPeriodService : BaseService, IRentalPeriodService
    {
        public RentalPeriodService(ICarRentalDbContext context) : base(context)
        {

        }

        public Response Add(RentalPeriod rentalPeriod)
        {
            var checkResponse = CheckToAddOrUpdate(rentalPeriod);
            if (!checkResponse.IsSuccess)
                return checkResponse;

            Context.RentalPeriod.Add(rentalPeriod);
            Context.SaveChanges();

            return Response.Success("Kiralama periyodu başarıyla kaydedildi");
        }
        private Response CheckToAddOrUpdate(RentalPeriod rentalPeriod)
        {
            int sameNumberOfRecords = (from b in Context.RentalPeriod
                                       where b.Name == rentalPeriod.Name && b.Id != rentalPeriod.Id
                                       select b
                                       ).Count();
            if (sameNumberOfRecords > 0)
            {
                return Response.Fail($"{rentalPeriod.Name} kiralama periyodu sistemde zaten kayıtlıdır.");
            }
            return Response.Success();
        }
        public Response Update(RentalPeriod rentalPeriod)
        {
            var checkResponse = CheckToAddOrUpdate(rentalPeriod);
            if (!checkResponse.IsSuccess)
                return checkResponse;

            var rentalPeriodToUpdate = GetById(rentalPeriod.Id);
            rentalPeriodToUpdate.Name = rentalPeriod.Name;
            Context.SaveChanges();

            return Response.Success("Kiralama periyodu başarıyla güncellendi");
        }
        public Response Delete(int id)
        {
            var rentalPeriodToDelete = GetById(id);
            Context.RentalPeriod.Remove(rentalPeriodToDelete);
            Context.SaveChanges();

            return Response.Success("Kiralama periyodu başarıyla silindi");
        }

        public RentalPeriod GetById(int id)
        {
            return Context.RentalPeriod.Where(v => v.Id == id).SingleOrDefault();
        }
        public List<RentalPeriod> Get(RentalPeriodFilter filter)
        {
            var items = (from v in Context.RentalPeriod
                         where v.Name.StartsWith(filter.Name)
                         orderby v.Name
                         select v).ToList();
            return items;
        }
    }
}
