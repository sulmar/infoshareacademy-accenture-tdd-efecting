using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple
{
    class FakeCustomerRepository : ICustomerRepository
    {
        public void AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }

    class DbCustomerRepository : ICustomerRepository
    {
        public void AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }

    class DbVehicleRepository : IVehicleRepository
    {
        public void AddVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Vehicle FindByRoute(Route route)
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

  

    interface ICustomerRepository
    {
        Customer GetCustomer(int id);
        void AddCustomer(Customer customer);
    }

    interface IVehicleRepository : IQueryVehicleRepository, IUpdateVehicleRepository
    {
              
    }

    interface IQueryVehicleRepository
    {
        Vehicle GetVehicle(int id);
        Vehicle GetVehicleByPlate(string plate);
        Vehicle FindByRoute(Route route);
    }

    interface IUpdateVehicleRepository
    {
        void AddVehicle(Vehicle vehicle);
    }

    interface IRouteRepository
    {
        Route GetRoute(int id);
        void AddRoute(Route route);
        Route FindByVehicle(Vehicle vehicle);
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
