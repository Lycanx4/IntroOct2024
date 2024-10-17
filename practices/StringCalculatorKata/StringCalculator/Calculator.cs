using System.Text.RegularExpressions;

public class Calculator
{
    public int Add(string numbers)
    {
        int num = 0;
        if (numbers == null || numbers.Length == 0)
        {
            return num;
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
            var negativeNumbers = new List<int>();
            foreach (string value in valueString)
            {
                int numValue = convertToInteger(value);
                if (numValue < 0)
                {
                    negativeNumbers.Add(numValue);
                }
                num += convertToInteger(value);
            }
            if (negativeNumbers.Count > 0)
            {
                throw new NegativeNumbersException("Negative number Found: " + String.Join(", ", negativeNumbers));
            }
        }
        return num;
    }

    private int convertToInteger(string numbers)
    {
        int num = 0;
        if (int.TryParse(numbers, out num))
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
