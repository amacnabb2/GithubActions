// See https://aka.ms/new-console-template for more information

namespace GithubActionsLab;

public class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("The Quick Calculator");
		var loop = true;
		while (loop)
		{
			try
			{
				Func<string, string, double> operation;
				Console.WriteLine("1) Add (x+y)");
				Console.WriteLine("2) Subtract (x-y)");
				Console.WriteLine("3) Multiply (x*y)");
				Console.WriteLine("4) Divide (x/y)");
				Console.WriteLine("5) Power (x^y)");
				Console.WriteLine("6) Quit");
				var operationSelection = GetInput("Select your operation: ");
				switch (operationSelection)
				{
					case "1":
						operation = Add;
						break;
					case "2":
						operation = Subtract;
						break;
					case "3":
						operation = Multiply;
						break;
					case "4":
						operation = Divide;
						break;
					case "5":
						operation = Power;
						break;
					case "6":
						loop = false;
						continue;
					default:
						throw new ArgumentException("You did not select a valid option!");
				}

				var x = GetInput("Enter x: ");
				var y = GetInput("Enter y: ");
				var result = operation(x, y);
				Console.WriteLine($"Result: {result}");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}

	private static string GetInput(string prompt)
	{
		Console.Write(prompt);

		return Console.ReadLine()?.Trim() ?? throw new InvalidOperationException();
	}

	public static double Add(string x, string y)
	{
		return double.Parse(x) + double.Parse(y);
	}

	public static double Subtract(string x, string y)
	{
		return double.Parse(x) - double.Parse(y);
	}

	public static double Multiply(string x, string y)
	{
		return double.Parse(x) * double.Parse(y);
	}

	public static double Divide(string x, string y)
	{
		return double.Parse(x) / double.Parse(y);
	}

	// Implement this method following a similar pattern as above
	public static double Power(string x, string y)
{
    if (x == null || y == null)
        throw new ArgumentNullException();

    double baseVal = double.Parse(x);
    double exponent = double.Parse(y);

    // Handle exponent == 0
    if (exponent == 0) return 1;

    // Only integer exponents for simple manual calculation
    if (exponent % 1 != 0)
        throw new ArgumentException("Manual Power supports only integer exponents.");

    double result = 1;
    int exp = (int)exponent;

    bool negative = false;
    if (exp < 0)
    {
        negative = true;
        exp = -exp;
    }

    for (int i = 0; i < exp; i++)
        result *= baseVal;

    if (negative)
        result = 1 / result;

    return result;
}
}
