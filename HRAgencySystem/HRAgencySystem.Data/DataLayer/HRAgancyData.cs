using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using HRAgencySystem.Data.Repositories;
using HRAgencySystem.Models;

namespace HRAgencySystem.Data.DataLayer
{
    public class HRAgancyData : IHRAgancyData
    {
        private IHRAgancyDbContext context;
        private IDictionary<Type, object> repositories;

        public HRAgancyData(IHRAgancyDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Hall> Halls
        {
            get { return this.GetRepository<Hall>(); }
        }

        public IRepository<Item> Items
        {
            get { return this.GetRepository<Item>(); }
        }


        public IRepository<HallStatus> HallStatuses
        {
            get { return this.GetRepository<HallStatus>(); }
        }

        public IRepository<Reservation> Reservations
        {
            get { return this.GetRepository<Reservation>(); }
        }


        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);

                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
