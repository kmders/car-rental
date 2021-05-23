using Domain.DTOs;
using Domain.Entities;

namespace Application.Services
{
    public interface IUserService
    {
        Response<User> Add(User user);
        User GetByEMail(string eMail);
    }
}
