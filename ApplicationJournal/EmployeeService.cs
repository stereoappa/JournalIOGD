using DomainModel;
using DomainModel.Entities;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJournal
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees(bool includingDismissed = false);
        void Save(Employee employee);
        Sign GetEmployeeSign(Employee employee);
        void SetEmployeeSign(Employee employee, Bitmap sign);

        IEnumerable<Sign> GetSigns();

        Sign GetActiveSign();
        void SetActiveSign(Sign sign);
    }

    public class EmployeeService : IEmployeeService
    {
        ISignRepository _signRepository;
        IEmployeeRepository _employeeRepository;
        public EmployeeService(ISignRepository signRepository, IEmployeeRepository employeeRepository)
        {
            _signRepository = signRepository;
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetEmployees(bool includingDismissed = false)
        {
            return _employeeRepository.GetAll(includingDismissed);
        }

        #region Подписи
        public Sign GetEmployeeSign(Employee employee)
        {
            return _signRepository.GetByEmployeeId(employee.IdEmployee);
        }

        public void SetActiveSign(Sign sign)
        {
            _signRepository.Save(sign);
        }

        public Sign GetActiveSign()
        {
            return _signRepository.GetActiveSign();
        }

        public IEnumerable<Sign> GetSigns()
        {
            return _signRepository.GetAll();
        }

        public void SetEmployeeSign(Employee employee, Bitmap sign)
        {
            ImageConverter converter = new ImageConverter();
            _signRepository.SetEmployeeSign(employee.IdEmployee, (byte[])converter.ConvertTo(sign, typeof(byte[])));
        }

        public void Save(Employee employee)
        {
            _employeeRepository.Save(employee);
        }

        #endregion
    }
}
