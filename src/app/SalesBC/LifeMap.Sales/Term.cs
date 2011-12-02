namespace LifeMap.Sales
{
    public class Term
    {
        private Term()
        {
        }

        public Term(int durationInDays)
        {
            DurationInDays = durationInDays;
        }
        public int DurationInDays { get; private set; }
    }
}