using System;
using System.Linq;

public static class Bob
{
    private const char SpaceChar = ' ';
    private const string WhiteSpaceChars = " \n\r\t";
    private const string NumericChars = "0123456789";
    private const string NonAlphaNumericChars = ",_-^*@#$%()[]!?:";

    public static string Response(string statement)
    {
        var input = Bob.NormalizeStatement(statement);

        if (Bob.IsAddressing(input))
        {
            return "Fine. Be that way!";
        }

        if (Bob.IsYelling(input))
        {
            return "Whoa, chill out!";
        }

        if (Bob.IsQuestioning(input))
        {
            return "Sure.";
        }

        return "Whatever.";
    }

    private static string NormalizeStatement(string statement) {
        return statement.Trim(SpaceChar);
    }

	private static bool IsAddressing(string input)
	{
		var temp = input.StringByRemovingChars(WhiteSpaceChars);
        return (temp == "");
	}

	private static bool IsYelling(string input)
	{
        var temp = input.StringByRemovingChars(WhiteSpaceChars + NonAlphaNumericChars + NumericChars);
        return (temp == temp.ToUpper()) && (temp != "");
    }

    private static bool IsQuestioning(string input) {
        return input.EndsWith("?");
    }
}

public static class StringExtensions
{
	public static string StringByRemovingChars(this String str, String charSet)
	{
		var s = from c in str where charSet.Contains(c) == false select c;
		return new string(s.ToArray());
	}
}