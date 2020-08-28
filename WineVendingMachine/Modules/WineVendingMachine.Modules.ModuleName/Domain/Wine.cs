using System;
using System.Collections.Generic;
using System.Text;
using WineVendingMachine.Core.Framework;

namespace WineVendingMachine.Modules.SellWine.Domain
{
    public class Wine : Entity
    {
        public virtual string Name { get; }

        protected Wine()
        {

        }

        private Wine(long id, string name)
            : this()
        {
            Id = id;
            Name = name;
        }
    }
}
