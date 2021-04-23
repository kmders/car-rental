using Application.Infrastructure.Persistence;
using Application.Services.Common;
using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Concrete
{
    public class ColorTypeService : BaseService, IColorTypeService
    {
        public ColorTypeService(ICarRentalDbContext context) : base(context)
        {

        }

        public Response Add(ColorType colorType)
        {
            var checkResponse = CheckToAddOrUpdate(colorType);
            if (!checkResponse.IsSuccess)
                return checkResponse;

            Context.ColorType.Add(colorType);
            Context.SaveChanges();

            return Response.Success("Renk başarıyla kaydedildi");
        }
        private Response CheckToAddOrUpdate(ColorType colorType)
        {
            int sameNumberOfRecords = (from b in Context.ColorType
                                       where b.Name == colorType.Name && b.Id != colorType.Id
                                       select b
                                       ).Count();
            if (sameNumberOfRecords > 0)
            {
                return Response.Fail($"{colorType.Name} renk sistemde zaten kayıtlıdır.");
            }
            return Response.Success();
        }
        public Response Update(ColorType colorType)
        {
            var checkResponse = CheckToAddOrUpdate(colorType);
            if (!checkResponse.IsSuccess)
                return checkResponse;

            var colorTypeToUpdate = GetById(colorType.Id);
            colorTypeToUpdate.Name = colorType.Name;
            Context.SaveChanges();

            return Response.Success("Renk başarıyla güncellendi");
        }
        public Response Delete(int id)
        {
            var colorTypeToDelete = GetById(id);
            Context.ColorType.Remove(colorTypeToDelete);
            Context.SaveChanges();

            return Response.Success("Renk başarıyla silindi");
        }

        public ColorType GetById(int id)
        {
            return Context.ColorType.Where(v => v.Id == id).SingleOrDefault();
        }
        public List<ColorType> Get(ColorTypeFilter filter)
        {
            var items = (from v in Context.ColorType
                         where v.Name.StartsWith(filter.Name)
                         orderby v.Name
                         select v).ToList();
            return items;
        }
    }
}
