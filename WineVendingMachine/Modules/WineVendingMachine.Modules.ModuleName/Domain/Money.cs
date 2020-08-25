using System;
using System.Collections.Generic;
using System.Text;

namespace WineVendingMachine.Modules.SellWine.Domain
{
    public sealed class Money : ValueObject<Money>
    {
        //Assumption - Wine prices are rounded to nearest 10 Rupee
        public int TenRupeeCount { get; set; }
        public int TwentyRupeeCount { get; set; }
        public int FiftyRupeeCount { get; set; }
        public int HundredRupeeCount { get; set; }
        public int FiveHundredRupeeCount { get; set; }
        public int ThousandRupeeCount { get; set; }

        public Money(
            int tenRupeeCount,
            int twentyRupeeCount,
            int fiftyRupeeCount,
            int hundredRupeeCount,
            int fivehundredRupeeCount,
            int thousandRupeeCount)
        {
            TenRupeeCount = tenRupeeCount;
            TwentyRupeeCount = twentyRupeeCount;
            FiftyRupeeCount = fiftyRupeeCount;
            HundredRupeeCount = hundredRupeeCount;
            FiveHundredRupeeCount = fivehundredRupeeCount;
            ThousandRupeeCount = thousandRupeeCount;
        }

        public decimal Amount =>
            TenRupeeCount * 10m +
            TwentyRupeeCount * 20 +
            FiftyRupeeCount * 50 +
            HundredRupeeCount * 100 +
            FiveHundredRupeeCount * 500 +
            ThousandRupeeCount * 1000;

        public static Money operator +(Money money1, Money money2)
        {
            Money sum = new Money(
                money1.TenRupeeCount + money2.TenRupeeCount,
                money1.TwentyRupeeCount + money2.TwentyRupeeCount,
                money1.FiftyRupeeCount + money2.FiftyRupeeCount,
                money1.HundredRupeeCount + money2.HundredRupeeCount,
                money1.FiveHundredRupeeCount + money2.FiveHundredRupeeCount,
                money1.ThousandRupeeCount + money2.ThousandRupeeCount);

            return sum;
        }

        public static Money operator -(Money money1, Money money2)
        {
            return new Money(
                money1.TenRupeeCount - money2.TenRupeeCount,
                money1.TwentyRupeeCount - money2.TwentyRupeeCount,
                money1.FiftyRupeeCount - money2.FiftyRupeeCount,
                money1.HundredRupeeCount - money2.HundredRupeeCount,
                money1.FiveHundredRupeeCount - money2.FiveHundredRupeeCount,
                money1.ThousandRupeeCount - money2.ThousandRupeeCount);
        }

        protected override bool EqualsCore(Money other)
        {
            return TenRupeeCount == other.TenRupeeCount
                && TwentyRupeeCount == other.TwentyRupeeCount
                && FiftyRupeeCount == other.FiftyRupeeCount
                && HundredRupeeCount == other.HundredRupeeCount
                && FiveHundredRupeeCount == other.FiveHundredRupeeCount
                && ThousandRupeeCount == other.ThousandRupeeCount;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = TenRupeeCount;
                hashCode = (hashCode * 397) ^ TwentyRupeeCount;
                hashCode = (hashCode * 397) ^ FiftyRupeeCount;
                hashCode = (hashCode * 397) ^ HundredRupeeCount;
                hashCode = (hashCode * 397) ^ FiveHundredRupeeCount;
                hashCode = (hashCode * 397) ^ ThousandRupeeCount;
                return hashCode;
            }
        }
    }
}
