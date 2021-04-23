using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Services
{
    public interface ITransmissionTypeService
    {
        Response Add(TransmissionType transmissionType);
        Response Update(TransmissionType transmissionType);
        Response Delete(int id);
        TransmissionType GetById(int id);
        List<TransmissionType> Get(TransmissionTypeFilter filter);
    }
}
