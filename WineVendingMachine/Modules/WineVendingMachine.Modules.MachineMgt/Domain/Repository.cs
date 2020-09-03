﻿using NHibernate;
using WineVendingMachine.Core.Framework;

namespace WineVendingMachine.Modules.MachineMgt.Domain
{
    public abstract class Repository<T>
        where T : AggregateRoot
    {
        public T GetById(long id)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Get<T>(id);
            }
        }

        public void Save(T aggregateRoot)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(aggregateRoot);
                transaction.Commit();
            }
        }
    }
}
