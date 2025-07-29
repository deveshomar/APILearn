using EntityLibray.Modal;
using System.Text.Json;

namespace APILearn.Service
{
    public class EmployeeService
    {
        private readonly string _filePath = "Data/employees.json";

        public List<Employee> GetAll()
        {
            if (!File.Exists(_filePath))
                return new List<Employee>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Employee>>(json) ?? new List<Employee>();
        }

        public Employee? GetById(int id)
        {
            return GetAll().FirstOrDefault(e => e.Id == id);
        }

        public void Add(Employee Inputemployee)
        {
            var employees = GetAll();
           
            employees.Add(Inputemployee);
            SaveAll(employees);
        }

        public bool Update(Employee updatedEmployee)
        {
            var employees = GetAll();
            var index = employees.FindIndex(e => e.Id == updatedEmployee.Id);
            if (index == -1)
                return false;

            employees[index] = updatedEmployee;
            SaveAll(employees);
            return true;
        }

        public bool Delete(int id)
        {
            var employees = GetAll();
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return false;

            employees.Remove(employee);
            SaveAll(employees);
            return true;
        }

        private void SaveAll(List<Employee> employees)
        {
            var json = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
