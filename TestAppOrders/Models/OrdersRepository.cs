﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace TestAppOrders.Models
{
    public class OrdersRepository : IRepository
    {
        private OrderContext context = new OrderContext();

        public async void Save(Order order)
        {
            if (order == null)
            {
                throw new NullReferenceException();
            }
            context.Orders.Add(order);
            await context.SaveChangesAsync();
        }

        public IEnumerable<Order> List()
        {
            return context.Orders.ToList();
        }

        public async Task<Order> Get(int id)
        {
            var order = await context.Orders.FindAsync(id);
            return order;
        }

        public void Edit(Order order)
        {
            context.Entry(order).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Create(Order order)
        {
            var context = new OrderContext();
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = context.Orders.Find(id);
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public void RemoveData()
        {
            var orders = context.Orders;
            context.Orders.RemoveRange(orders);
            context.SaveChanges();
        }

        public void CreateTestData()
        {
            List<Order> orders = new List<Order>();
            orders.Add(new Order() {Id=1, Number = "1", CreateDate = new DateTime(2017, 10 , 03  ), EndDate = new DateTime(2017,12 , 04  ), Manager = Manager.Ivanov, Annotation = "Annotation for FIRST order" });
            orders.Add(new Order() {Id=2, Number = "2", CreateDate = new DateTime(2017, 11 , 11  ), EndDate = new DateTime(2017,11 , 12  ), Manager = Manager.Petrov, Annotation = "Annotation for SECOND order" });
            orders.Add(new Order() {Id=3, Number = "3", CreateDate = new DateTime(2017, 01 , 07  ), EndDate = new DateTime(2017,01 , 11  ), Manager = Manager.Sidorov, Annotation = "Annotation for THIRD order" });
            orders.Add(new Order() {Id=4, Number = "4", CreateDate = new DateTime(2017, 09 , 01  ), EndDate = new DateTime(2017,12 , 11  ), Manager = Manager.Ivanov, Annotation = "Annotation for FOURTH order" });
            orders.Add(new Order() {Id=5, Number = "5", CreateDate = new DateTime(2017, 02 , 03  ), EndDate = new DateTime(2017,03 , 04  ), Manager = Manager.Petrov, Annotation = "Annotation for FIFTH order" });
            orders.Add(new Order() {Id=6, Number = "6", CreateDate = new DateTime(2017, 11 , 08  ), EndDate = new DateTime(2017,12 , 11  ), Manager = Manager.Sidorov, Annotation = "Annotation for SIXTH order" });
            orders.Add(new Order() {Id=7, Number = "7", CreateDate = new DateTime(2017, 11 , 08  ), EndDate = new DateTime(2017,12 , 10  ), Manager = Manager.Ivanov, Annotation = "Annotation for SEVENTH order" });
            orders.Add(new Order() {Id=8, Number = "8", CreateDate = new DateTime(2017, 03 , 08  ), EndDate = new DateTime(2017,12 , 09  ), Manager = Manager.Petrov, Annotation = "Annotation for EIGHTS order" });
            orders.Add(new Order() {Id=9, Number = "9", CreateDate = new DateTime(2017, 10 , 03  ), EndDate = new DateTime(2017,11 , 05  ), Manager = Manager.Sidorov, Annotation = "Annotation for NINTH order" });
            orders.Add(new Order() {Id=10, Number = "10", CreateDate = new DateTime(2017, 03, 07  ), EndDate = new DateTime(2017,04 , 07  ), Manager = Manager.Ivanov, Annotation = "Annotation for TENTH order" });

            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
    }
}