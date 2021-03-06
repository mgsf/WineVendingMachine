﻿using WineVendingMachine.Modules.SellWine.Domain;
using FluentAssertions;
using Xunit;
using static WineVendingMachine.Modules.SellWine.Domain.Money;
using System;

namespace WineVendingMachine.Modules.SellWine.Tests.Domain
{
    public class VendingMachineFixture
    {
        [Fact]
        public void Inserted_money_goes_to_money_in_transaction()
        {
            var vendingMachine = new VendingMachine();

            vendingMachine.InsertMoney(TenRupee);
            vendingMachine.InsertMoney(FiftyRupee);

            vendingMachine.MoneyInTransaction.Should().Be(60.00m);
        }

        [Fact]
        public void Cannot_insert_more_than_one_note_at_a_time()
        {
            var vendingMachine = new VendingMachine();
            var FortyRupees = TwentyRupee + TwentyRupee;

            Action action = () => vendingMachine.InsertMoney(FortyRupees);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Return_money_empties_moneyintransaction()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.InsertMoney(TenRupee);
            vendingMachine.InsertMoney(FiftyRupee);

            vendingMachine.ReturnMoney();

            vendingMachine.MoneyInTransaction.Should().Be(0.00m);
        }
    }
}
