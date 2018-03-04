using DomainModel.Entities;
using DomainModel.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationJournal
{
    public interface IUserService
    {
        Employee SignIn(string login, string password);

        Employee TryAuthorizeFromRegister();
    }

    public class UserService : IUserService
    {
        IUserRepository _userRepos;
        public UserService(IUserRepository userRepos)
        {
            _userRepos = userRepos;
        }

        public Employee SignIn(string login, string password)
        {
            return _userRepos.SignIn(login, password);
        }

        public Employee TryAuthorizeFromRegister()
        {
            RegistryKey key = Registry.CurrentUser;
            RegistryKey regKeyJournal = key.CreateSubKey(@"Software\Журнал выданной информации"); ;

            string login = regKeyJournal.GetValue("Login")?.ToString() ?? "";
            string pass = regKeyJournal.GetValue("Password")?.ToString() ?? "";
            regKeyJournal.Close();

            return _userRepos.SignIn(login, pass);
        }
    }
}
