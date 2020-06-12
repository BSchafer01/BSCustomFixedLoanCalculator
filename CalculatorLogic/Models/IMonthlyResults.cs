namespace CalculatorLogic.Models
{
    public interface IMonthlyResults
    {
        decimal Balance { get; set; }
        decimal InterestPayment { get; set; }
        int Month { get; set; }
        decimal PrincipalPayment { get; set; }
        decimal TotalInterest { get; set; }
        decimal TotalPaid { get; set; }
        decimal TotalPayment { get; set; }
    }
}