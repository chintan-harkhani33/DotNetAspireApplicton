using DotNet_aspire_app.ApiService.model;
using Microsoft.EntityFrameworkCore;

namespace DotNet_aspire_app.ApiService.service
{
    public class EmployeeService
    {
        private readonly AspireDBcontext _context;
        
         public EmployeeService(AspireDBcontext context)
        {
            _context = context;
        }

         public async Task<EmployeeModel> AddEmployee (EmployeeModel employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee;
        }
        public async Task<List<EmployeeModel>> GetAllemployee()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<bool> DeleteEmp(int id)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(emp => emp.Id == id);
            if(emp == null)
            {
                return false;
            }
             _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<EmployeeModel> UpdateEmployeeId (int id ,EmployeeModel employee)
        {
           var empId  = await _context.Employees.FirstOrDefaultAsync (emp => emp.Id == id);

            if (empId == null)
            {
                throw new Exception("Employee not found.");
            }

            empId.FullName = employee.FullName;
            empId.Position = employee.Position;
            empId.Salary = employee.Salary;

            await _context.SaveChangesAsync();

            return empId;
        }
    }
}
