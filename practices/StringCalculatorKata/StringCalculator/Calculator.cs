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
        else if (numbers.Length == 1)
        {
            // This, I think, can be safely removed. I don't understand the special case
            // for only single digit numbers. Why is "1" treated differently than "10"?
            // "else if" is always a minor code smell. If you can avoid it, do it. I think
            // you can.
            return convertToInteger(numbers);
        }
        else
        {
            var delimiters = getDelimiters(numbers);
            if (numbers.StartsWith("//"))
            {
                numbers = numbers[2].Equals('[') ?
                    numbers.Substring(numbers.IndexOf("\n") + 1) :
                    numbers.Substring(3);
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
        // C# allows you to declare the out var inline
        // int num = 0;
        if (int.TryParse(number, out int num))
        {
            return num > 1000 ? 0 : num;
        }
        else
        {
            throw new FormatException("Numbers is NAN!");
        }
    }

    // i like how you abstracted this.
    private string[] getDelimiters(string numbers)
    {
        var delimiters = new List<string> { ",", "\n" };
        if (numbers.StartsWith("//"))
        {
            // I'm not really getting what you are doing here, but looks good.
            if (numbers[2].Equals('['))
            {
                // to learn something cool, hover over that regex and read the link
                // suggesting a GeneratedRegexAttribute.
                var Matches = Regex.Matches(numbers, @"\[(.*?)\]");
                // consistency in var or not? minor. also "String" and "string" in C# are the same thing.
                // it is more idiomatic to use the lower-case version, again, minor.
                String customDelimiters = "";
                foreach (Match match in Matches)
                {
                    customDelimiters += (match.Groups[1].Value);
                }
                String[] strs = customDelimiters.Split(',');
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
