using Application.Infrastructure.Persistence;
using Application.Services.Common;
using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Concrete
{
    public class TireTypeService : BaseService, ITireTypeService
    {
        public TireTypeService(ICarRentalDbContext context) : base(context)
        {

        }

        public Response Add(TireType tireType)
        {
            var checkResponse = CheckToAddOrUpdate(tireType);
            if (!checkResponse.IsSuccess)
                return checkResponse;

            Context.TireType.Add(tireType);
            Context.SaveChanges();

            return Response.Success("Lastik türü başarıyla kaydedildi");
        }
        private Response CheckToAddOrUpdate(TireType tireType)
        {
            int sameNumberOfRecords = (from b in Context.TireType
                                       where b.Name == tireType.Name && b.Id != tireType.Id
                                       select b
                                       ).Count();
            if (sameNumberOfRecords > 0)
            {
                return Response.Fail($"{tireType.Name} lastik türü sistemde zaten kayıtlıdır.");
            }
            return Response.Success();
        }
        public Response Update(TireType tireType)
        {
            var checkResponse = CheckToAddOrUpdate(tireType);
            if (!checkResponse.IsSuccess)
                return checkResponse;

            var tireTypeToUpdate = GetById(tireType.Id);
            tireTypeToUpdate.Name = tireType.Name;
            Context.SaveChanges();

            return Response.Success("Lastik türü başarıyla güncellendi");
        }
        public Response Delete(int id)
        {
            var tireTypeToDelete = GetById(id);
            Context.TireType.Remove(tireTypeToDelete);
            Context.SaveChanges();

            return Response.Success("Lastik türü başarıyla silindi");
        }

        public TireType GetById(int id)
        {
            return Context.TireType.Where(v => v.Id == id).SingleOrDefault();
        }
        public List<TireType> Get(TireTypeFilter filter)
        {
            var items = (from v in Context.TireType
                         where v.Name.StartsWith(filter.Name)
                         orderby v.Name
                         select v).ToList();
            return items;
        }
    }
}
