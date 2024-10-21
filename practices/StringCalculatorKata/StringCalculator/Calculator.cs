using System.Text.RegularExpressions;

public class Calculator
{
    public int Add(string numbers)
    {
        if (numbers == null || numbers.Length == 0)
        {
            return 0;
        }
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
        if (int.TryParse(number, out int num))
        {
            return num > 1000 ? 0 : num;
        }
        else
        {
            throw new FormatException("Numbers is NAN!");
        }
    }


    private string[] getDelimiters(string numbers)
    {
        var delimiters = new List<string> { ",", "\n" };
        if (numbers.StartsWith("//"))
        {
            //int lastIndex = numbers.IndexOf("\n") - 1;

            if (numbers[2].Equals('['))
            {
                var Matches = Regex.Matches(numbers, @"\[(.*?)\]");
                string customDelimiters = "";
                foreach (Match Match in Matches)
                {
                    customDelimiters += (Match.Groups[1].Value);
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
