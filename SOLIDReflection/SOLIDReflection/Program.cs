using System;

namespace SOLIDReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Liskov substitution
            //Fruit orange = new Orange();
            #endregion

            #region Dependency Injection
            Service service = new Service();
            service.product.GetProductData();
            service.customer.GetCustomerData();
            #endregion
        }
    }

    #region SOLID
    #region Single representation
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Group Group { get; set; }

        public void Fullname()
        {
            Console.WriteLine($"{Name} {Surname}");
        }
    }

    class Group
    {
        public string Groupname { get; set; }
        public string GroupType { get; set; }
        public string GetGroupInfo()
        {
            return $"{Groupname} {GroupType}";
        }
    }
    #endregion

    #region Open/Close
    class Invoice
    {
        public virtual void GetPrice()
        {
            Console.WriteLine("Discount: 30%");
        }
    }

    class FinalInvoice : Invoice
    {
        public override void GetPrice()
        {
            Console.WriteLine("Discount: 50%");
        }
    }

    //class Invoice
    //{
    //    public void GetPrice(string type)
    //    {
    //        switch (type)
    //        {
    //            case "initial":
    //                Console.WriteLine("Discount: 30%");
    //                break;
    //            case "second":
    //                Console.WriteLine("Discount: 40%");
    //                break;
    //            case "final":
    //                Console.WriteLine("Discount: 50%");
    //                break;
    //        }
    //    }
    //}
    #endregion

    #region Liskov substitution
    abstract class Fruit
    {
        public abstract void GetTasty();
    }
    class Apple:Fruit
    {
        public override void GetTasty()
        {
            Console.WriteLine("As Apple");
        }
    }

    class Orange : Fruit
    {
        public override void GetTasty()
        {
            Console.WriteLine("As Orange");
        }
    }
    #endregion

    #region Interface segregation
    interface IDifference
    {
        int Difference(int n1, int n2);
    }

    interface IDivide
    {
        double Divide(double n1, double n2);
    }

    interface IMultiple
    {
        int Multiple(int n1, int n2);
    }

    interface ISum
    {
        int Sum(int n1, int n2);
    }

    class Test : ISum
    {
        public int Sum(int n1, int n2)
        {
            throw new NotImplementedException();
        }
    }

    class Calculate : ISum,IDifference,IMultiple,IDivide
    {
        public int Difference(int n1, int n2)
        {
            throw new NotImplementedException();
        }

        public double Divide(double n1, double n2)
        {
            throw new NotImplementedException();
        }

        public int Multiple(int n1, int n2)
        {
            throw new NotImplementedException();
        }

        public int Sum(int n1, int n2)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region Dependency injection
    interface IDatabase
    {
        void GetData(string s);
    }
    class Database : IDatabase
    {
        public void GetData(string s)
        {
            Console.WriteLine(s);
        }
    }

    class Service
    {
        public Product product;
        public Customer customer;
        public Service()
        {
            Database context = new Database();
            product = new Product(context);
            customer = new Customer(context);
        }
    }

    class Product
    {
        private readonly IDatabase _context;
        public Product(IDatabase context)
        {
            _context = context;
        }

        public void GetProductData()
        {
            _context.GetData("prodact data");
        }
    }

    class Customer
    {
        private readonly IDatabase _context;
        public Customer(IDatabase context)
        {
            _context = context;
        }

        public void GetCustomerData()
        {
            _context.GetData("customer data");
        }
    }
    #endregion
    #endregion
}
