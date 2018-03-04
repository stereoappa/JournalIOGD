using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Repositories
{
    public interface IUserRepository
    {
        Employee SignIn(string login, string password);
    }
}
