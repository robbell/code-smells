namespace FeatureEnvy
{
    using System;

    public class Motorist
    {
        private DateTime dateOfBirth;

        public Motorist(DateTime dateOfBirth, int pointsOnLicense)
        {
            this.PointsOnLicense = pointsOnLicense;
            this.dateOfBirth = dateOfBirth;
        }

        public int PointsOnLicense { get; private set; }

        public int Age
        {
            get
            {
                var now = DateTime.Now;
                var ageYr = now.Year - dateOfBirth.Year;
                var ageMo = now.Month - dateOfBirth.Month;
                return adustYearsDownIfNegativeMonthDifference(ageYr, ageMo);
            }
        }

        private int adustYearsDownIfNegativeMonthDifference(int ageYr, int ageMo)
        {
            if (ageMo < 0)
            {
                ageYr--;
            }
            return ageYr;
        }

        public RiskFactor CalculateRiskFactor()
        {
            if (PointsOnLicense > 3 || Age < 25)
            {
                return RiskFactor.HIGH_RISK;
            }

            if (PointsOnLicense > 0)
            {
                return RiskFactor.MODERATE_RISK;
            }

            return RiskFactor.LOW_RISK;
        }
    }
}