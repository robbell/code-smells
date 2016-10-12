namespace FeatureEnvy
{
    public class InsuranceQuote
    {
        private readonly Motorist motorist;

        public InsuranceQuote(Motorist motorist)
        {
            this.motorist = motorist;
        }

        public RiskFactor CalculateMotoristRisk()
        {
            return motorist.CalculateRiskFactor();
        }

        public double CalculateInsurancePremium(double insuranceValue)
        {
            var riskFactor = CalculateMotoristRisk();

            switch (riskFactor)
            {
                case RiskFactor.LOW_RISK:
                    return insuranceValue * 0.02;
                case RiskFactor.MODERATE_RISK:
                    return insuranceValue * 0.04;
                default:
                    return insuranceValue * 0.06;
            }
        }
    }
}