using CalculatorLogic;
using CalculatorLogic.Models;
using FixedLoanCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedLoanCalculator.Components
{
    public partial class LoanCalculator
    {

        private DisplayLoanConditions loan = new DisplayLoanConditions();
        private List<DisplayMonthlyResults> results;

        private bool showTable = false;

        private void HandleValidSubmit()
        {
            results = new List<DisplayMonthlyResults>();
            List<IMonthlyResults> monthly = Methods.CalculateResults(loan);
            foreach (var m in monthly)
            {
                results.Add(new DisplayMonthlyResults
                {
                    Balance = m.Balance,
                    Month = m.Month,
                    TotalPayment = m.TotalPayment,
                    InterestPayment = m.InterestPayment,
                    PrincipalPayment = m.PrincipalPayment,
                    TotalInterest = m.TotalInterest,
                    TotalPaid = m.TotalPaid
                });
            }
            showTable = true;
            Console.WriteLine(loan.Balance + ": " + loan.Rate + " - " + loan.Term);
        }
    }
}
