using System.Text.RegularExpressions;

public class Calculator
{
    public int Add(string numbers)
    {
        // there was no requirement to check for nulls, and it's ok that you added it, but 
        // you should have a test where you pass in a null to make sure this works.

        if (numbers == null || numbers.Length == 0)
        {
            return 0;
        }
<<<<<<< HEAD
=======
        else if (numbers.Length == 1)
        {
            // This, I think, can be safely removed. I don't understand the special case
            // for only single digit numbers. Why is "1" treated differently than "10"?
            // "else if" is always a minor code smell. If you can avoid it, do it. I think
            // you can.
            return convertToInteger(numbers);
        }
>>>>>>> 102f01342c94ba748bb6432ffa0e90f379d57047
        else
        {
            var delimiters = getDelimiters(numbers);
            if (numbers.StartsWith("//"))
            {
                numbers = numbers.Substring(numbers.IndexOf("\n") + 1);
            }
            string[] valueString = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var negativeNumbers = valueString.Select(convertToInteger).Where(x => x < 0).ToList();
            if (negativeNumbers.Count > 0)
            {
                throw new NegativeNumbersException("Negative number found: " + String.Join(", ", negativeNumbers));
            }
            else
            {
                return valueString.Select(convertToInteger).Sum();
            }
        }
    }

    private int convertToInteger(string number)
    {
<<<<<<< HEAD
=======
        // C# allows you to declare the out var inline
        // int num = 0;
>>>>>>> 102f01342c94ba748bb6432ffa0e90f379d57047
        if (int.TryParse(number, out int num))
        {
            return num > 1000 ? 0 : num;
        }
        else
        {
            throw new FormatException("Numbers is NAN!");
        }
    }

<<<<<<< HEAD

=======
    // i like how you abstracted this.
>>>>>>> 102f01342c94ba748bb6432ffa0e90f379d57047
    private string[] getDelimiters(string numbers)
    {
        var delimiters = new List<string> { ",", "\n" };
        if (numbers.StartsWith("//"))
        {
<<<<<<< HEAD
            //int lastIndex = numbers.IndexOf("\n") - 1;

=======
            // I'm not really getting what you are doing here, but looks good.
>>>>>>> 102f01342c94ba748bb6432ffa0e90f379d57047
            if (numbers[2].Equals('['))
            {
                // to learn something cool, hover over that regex and read the link
                // suggesting a GeneratedRegexAttribute.
                var Matches = Regex.Matches(numbers, @"\[(.*?)\]");
<<<<<<< HEAD
                string customDelimiters = "";
                foreach (Match Match in Matches)
=======
                // consistency in var or not? minor. also "String" and "string" in C# are the same thing.
                // it is more idiomatic to use the lower-case version, again, minor.
                String customDelimiters = "";
                foreach (Match match in Matches)
>>>>>>> 102f01342c94ba748bb6432ffa0e90f379d57047
                {
                    customDelimiters += (match.Groups[1].Value);
                }
                string[] strs = customDelimiters.Split(',');
                foreach (string str in strs)
                {
                    delimiters.Add(str.Trim());
                }
            }
            else
            {
                delimiters.Add(numbers[2] + "");
            }
        }
        return delimiters.ToArray();
    }

    public class NegativeNumbersException : FormatException
    {
        public NegativeNumbersException(String message) : base(message) { }
    }
}
