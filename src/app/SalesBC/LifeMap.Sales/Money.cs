namespace LifeMap.Sales
{
    public class Money
    {
        private double _amount;

        public Money(double amount)
        {
            _amount = amount;
        }

        public static implicit operator double(Money money)
        {
            return money._amount;
        }

        public static implicit operator Money(double amount)
        {
            return new Money(amount);
        }
    }
}