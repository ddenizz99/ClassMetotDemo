using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerTracking
{
    class CustomerManager
    {
        private List<Customer> _customers;
        public CustomerManager(List<Customer> customers)
        {
            _customers = customers;
        }

        public Customer Add(Customer customer)
        {
            if (GetRow(customer.Identity) == null)
            {
                _customers.Add(customer);
                GetRow(customer.Identity).ID = (_customers.IndexOf(customer) + 1);
                return GetRow(customer.Identity);
            }
            else
            {
                return null;
            }
        }

        public bool Remove(string identity)
        {
            if (GetRow(identity) != null)
            {
                _customers.RemoveAll(c => c.Identity.Contains(identity));
                return true;
            }
            else
            {
                return false;
            }
        }

        public Customer Update(string identity, string name)
        {
            if (GetRow(identity) != null)
            {
                GetRow(identity).Name = name;
                return GetRow(identity);
            }
            else
            {
                return null;
            }
        }

        public Customer GetRow(string identity)
        {
            return _customers.FirstOrDefault(c => c.Identity.Contains(identity));
        }
        public List<Customer> GetAll()
        {
            return _customers;
        }

        public void GetAllList()
        {
            if (GetAll().Count != 0)
            {
                foreach (Customer customer in GetAll())
                {
                    Console.WriteLine(" Müşteri Bilgileri -> ID : {0}, TC : {1}, Ad Soyad : {2}, Kayıt Tarihi : {3}", customer.ID, customer.Identity, customer.Name, customer.DateOfRegistration);
                }
            }
            else
            {
                Console.WriteLine("Sistemde kayıtlı müşteri bulunmamaktadır");
            }
            
        }

    }
}
