using CalculatorLogic;
using CalculatorLogic.Models;
using FixedLoanCalculator.Models;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedLoanCalculator.Components
{
    public partial class LoanCalculator
    {

        private DisplayLoanConditions loan = new DisplayLoanConditions() { Balance = 10000, Rate = 15.9, Term = 36, AdditionalPrincipal = 200};
        private List<DisplayMonthlyResults> results;

        private bool showTable = false;

        private async Task HandleValidSubmit()
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
                    TotalPaid = m.TotalPaid,
                    AdditionalTotalPrincipal = m.AdditionalTotalPrincipal,
                    AdditionalInterest = m.AdditionalInterest,
                    AdditionalBalance = m.AdditionalBalance,
                    AdditionalPrincipal = m.AdditionalPrincipal,
                    AdditionalTotalInterest = m.AdditionalTotalInterest
                });
            }
            showTable = true;
            await GenerateChartBlazor();
            Console.WriteLine(loan.Balance + ": " + loan.Rate + " - " + loan.Term);
        }

        private async Task GenerateChartBlazor()
        {
            await jsRunTime.InvokeVoidAsync("GenerateLineGraph", results);
        }
    }
}
