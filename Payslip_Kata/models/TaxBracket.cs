namespace Payslip_Kata.models
{
    public class TaxBracket
    {
        public TaxBracket(int lowerLimit, int upperLimit, int baseAmount, double rateInCents, int threshold)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
            BaseAmount = baseAmount;
            RateInCents = rateInCents;
            Threshold = threshold;
        }
        
        public int LowerLimit { get; }
        public int UpperLimit { get; }
        public int BaseAmount { get; }
        public double RateInCents { get; }
        public int Threshold { get; }
    }
}