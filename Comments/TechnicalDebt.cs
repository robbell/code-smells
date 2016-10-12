namespace Comments
{
    using System;
    using System.Collections.Generic;

    public class TechnicalDebt
    {
        private const int MaximumEffortManHours = 1000;
        private readonly IList<Issue> issues = new List<Issue>();

        public float TotalHours { get; private set; }

        public Issue LastIssue
        {
            get
            {
                return issues[(issues.Count - 1)];
            }
        }

        public string LastIssueDate { get; private set; }
            
        public void Fixed(float amount)
        {
            TotalHours -= amount;
        }

        public void Register(float estimatedManHours, string description)
        {
            CheckEffortDoesNotExceedMaximum(estimatedManHours);

            AddEstimatedHoursToTotal(estimatedManHours);

            AddIssue(estimatedManHours, description);

            UpdateLastIssueDate();
        }

        private void AddIssue(float estimatedManHours, string description)
        {
            issues.Add(new Issue(estimatedManHours, description));
        }

        private void UpdateLastIssueDate()
        {
            var now = DateTime.Now;
            LastIssueDate = now.Date + "/" + now.Month + "/" + now.Year;
        }

        private void AddEstimatedHoursToTotal(float estimatedManHours)
        {
            TotalHours += estimatedManHours;
        }

        private static void CheckEffortDoesNotExceedMaximum(float effortManHours)
        {
            if (effortManHours > MaximumEffortManHours)
            {
                throw new ArgumentException($"Cannot register tech debt where effort is bigger than {MaximumEffortManHours} man hours to fix");
            }
        }
    }
}