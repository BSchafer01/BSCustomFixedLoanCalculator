﻿using CalculatorLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FixedLoanCalculator.Models
{
    public class DisplayMonthlyResults : IMonthlyResults
    {
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public decimal InterestPayment { get; set; }
        [Required]
        public int Month { get; set; }
        [Required]
        public decimal PrincipalPayment { get; set; }
        [Required]
        public decimal TotalInterest { get; set; }
        [Required]
        public decimal TotalPaid { get; set; }
        [Required]
        public decimal TotalPayment { get; set; }
    }
}
