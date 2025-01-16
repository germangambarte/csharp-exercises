using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace exercise_02;

public class BillingsManager
{
    public decimal[,] Billings;

    public BillingsManager(decimal[,] billing)
    {
        if (billing != null)
        {
            Billings = billing;
        }
        else
        {
            Billings = new decimal[5, 7];
        }
    }

    public decimal GetBill(int day, int brand)
    {
        if (day is < 1 or > 5)
        {
            throw new ArgumentException("Día ingresado no válido");
        }

        if (brand is < 1 or > 7)
        {
            throw new ArgumentException("Sucursal ingresada no válida");
        }

        return Billings[brand - 1, day - 1];
    }

    public decimal AddBilling(int day, int brand, decimal bill)
    {
        if (day is < 1 or > 5)
        {
            throw new ArgumentException("Día ingresado no válido");
        }

        if (brand is < 1 or > 7)
        {
            throw new ArgumentException("Sucursal ingresada no válida");
        }

        if (bill < 0)
        {
            throw new ArgumentException("El importe debe ser mayor a {0:C}");
        }

        Billings[brand - 1, day - 1] += bill;
        return Billings[brand - 1, day - 1];
    }

    public decimal GetBillingByBrand(int brand)
    {
        if (brand is < 1 or > 7)
        {
            throw new ArgumentException("Sucursal ingresada no válida");
        }

        decimal sum = 0;

        for (var i = 0; i <= Billings.GetUpperBound(1); i++)
        {
            sum += Billings[brand - 1, i];
        }

        return sum;
    }

    public (decimal, int) GetMaxBillingByDay(int day)
    {
        if (day is < 1 or > 7)
        {
            throw new ArgumentException("Día ingresado no válido");
        }

        var max = decimal.MinValue;
        var maxBrand = 0;
        for (var i = 0; i <= Billings.GetUpperBound(0); i++)
        {
            var bill = Billings[i, day - 1];
            if (bill <= max) continue;
            max = bill;
            maxBrand = i;
        }

        return (max, maxBrand);
    }

    public (decimal, int) GetMinBillingForWeek()
    {
        var minBill = decimal.MaxValue;
        var minBrand = 0;
        for (var i = 0; i <= Billings.GetUpperBound(0); i++)
        {
            for (var j = 0; j <= Billings.GetUpperBound(1); j++)
            {
                var bill = Billings[i, j];
                if (minBill <= bill) continue;
                minBill = bill;
                minBrand = j;
            }
        }

        return (minBill, minBrand);
    }

    public decimal GetTotalBilling()
    {
        decimal total = 0;
        for (var i = 0; i <= Billings.GetUpperBound(0); i++)
        {
            for (var j = 0; j <= Billings.GetUpperBound(1); j++)
            {
                total += Billings[i, j];
            }
        }

        return total;
    }
}