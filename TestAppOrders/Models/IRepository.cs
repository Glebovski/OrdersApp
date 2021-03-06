﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppOrders.Models
{
    public interface IRepository
    {
        void Save(Order o);
        IEnumerable<Order> List();
        Task<Order> Get(int id);
        void Edit(Order order);
        void Create(Order order);
        void Delete(int id);
        void RemoveData();
        void CreateTestData();
    }
}
