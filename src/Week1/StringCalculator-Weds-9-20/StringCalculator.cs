
namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        (char[] delimiters, numbers) = GetDelimiters(numbers);
        return numbers.Split(delimiters.ToArray()).Select(num => num == "" ? 0 : int.Parse(num)).Sum();
    }

    private (char[] delimiters, string numsWithoutUserDelim) GetDelimiters(string numbers)
    {
        string numsWithoutUserDelim = numbers;
        List<char> delimiters = new List<char>
        {
            '\n',
            ','
        };

        if (numbers.StartsWith("//"))
        {
            delimiters.Add(numbers[2]);
            numsWithoutUserDelim = numbers.Substring(4);
        }

        return (delimiters.ToArray(), numsWithoutUserDelim);
    }
}
