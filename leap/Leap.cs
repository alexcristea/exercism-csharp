using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        var exception = (year % 100 == 0) ? 100 : 1;
        return year % (4 * exception) == 0;
    }
}