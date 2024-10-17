using System.Text.RegularExpressions;

public class Calculator
{
    public int Add(string numbers)
    {
        if (numbers == null || numbers.Length == 0)
        {
            return 0;
        }
        else if (numbers.Length == 1)
        {
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
        int num = 0;
        if (int.TryParse(number, out num))
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
            if (numbers[2].Equals('['))
            {
                var Matches = Regex.Matches(numbers, @"\[(.*?)\]");
                String customDelimiters = "";
                foreach (Match Match in Matches)
                {
                    customDelimiters += (Match.Groups[1].Value);
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
