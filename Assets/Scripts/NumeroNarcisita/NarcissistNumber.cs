using System;
using System.Collections.Generic;

public class Kata
{
    int P = 0;
    int val = 0;
    int sum = 0;

    public static bool Narcissistic(int no)
    {
        Kata obj = new Kata();

        return obj.Process(no);
    }

    int DigitCount(int n)
    {
        if (n == 0)
        {
            return 0;
        }

        return 1 + DigitCount(n / 10);
    }

    bool Process(int n)
    {
        P = DigitCount(n);
        val = n;

        while (val > 0)
        {
            sum += (int)Math.Pow(val % 10, P);
            val /= 10;
        }

        return (n == sum);
    }
}
