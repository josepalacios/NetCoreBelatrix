﻿using Belatrix.WebApi.Repository.Postgresql;
using GenFu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Tests.Builder.Data
{
    public partial class BelatrixDbContextBuilder: IDisposable
    {
        public BelatrixDbContextBuilder AddTenCustomers()
        {
            AddCustomers(_context,10);
            return this;
        }
        private void AddCustomers(BelatrixDbContext context, int quantity)
        {
            var customerList = A.ListOf<Models.Customer>(quantity);

            for (int i = 1; i < quantity; i++)
            {
                customerList[i - 1].Id = i;
            }
            context.Customer.AddRange(customerList);
            context.SaveChanges();
        }
    }
}
