using EntityLibray.Modal;
using System.Text.Json;

namespace APILearn.Service
{
    public class CustomerService
    {
        private readonly string _filePath = "Data/Customer.json";

        public List<Customer> GetAll()
        {
            if (!File.Exists(_filePath))
                return new List<Customer>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Customer>>(json) ?? new List<Customer>();
        }


        public Customer? GetById(int id)
        {
            return GetAll().FirstOrDefault(e => e.id == id);
        }

        public void Add(Customer Inputcustomer)
        {
            var cust = GetAll();

            cust.Add(Inputcustomer);
            SaveAll(cust);
        }

        private void SaveAll(List<Customer> customer)
        {
            var json = JsonSerializer.Serialize(customer, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
