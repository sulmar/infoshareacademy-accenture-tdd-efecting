using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRY;

public class FinancialCalculator
{
    public double CalculateCompoundInterest(double principal, double rate, int years)
    {
        double compoundInterest = principal * Math.Pow(1 + rate, years) - principal;
        return compoundInterest;
    }

    public double CalculateSimpleInterest(double principal, double rate, int years)
    {
        double simpleInterest = principal * rate * years;
        return simpleInterest;
    }
}

