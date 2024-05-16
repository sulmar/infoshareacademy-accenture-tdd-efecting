using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple
{    

    class DbRepository : IRepository
    {
        public void AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void AddRoute(Route route)
        {
            throw new NotImplementedException();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Route GetRoute(int id)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicleByPlate(string plate)
        {
            throw new NotImplementedException();
        }
    }

    interface IRepository
    {
        Customer GetCustomer(int id);
        void AddCustomer(Customer customer);

        Vehicle GetVehicle(int id);       
        void AddVehicle(Vehicle vehicle);

        Route GetRoute(int id);
        void AddRoute(Route route);
        Vehicle GetVehicleByPlate(string plate);
    }

    class Customer { }

    class Vehicle { }

    class Route { }

    class RouteDetail { }

    class Order { }

    class OrderDetail { }

    class Invoice { }

    class InvoiceDetail { }
}
