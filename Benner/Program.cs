using System;
using System.Threading;
using Benner.entities;

class Program
{
	static void Main()
	{
		Console.WriteLine("*** Welcome to the Benner's Exercise ***\n");

		int n;
		do
		{
			Console.WriteLine("Enter the number of elements:");
		} while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

		Network elements = new Network(n);

		ClearConsoleAndWait("Creating all the elements...");
		ClearConsole();

		Console.WriteLine("\nType the numbers to connect:");
		int num1 = ReadIntegerInput("Number 1: ");
		int num2 = ReadIntegerInput("Number 2: ");

		elements.Connect(num1, num2);

		ClearConsoleAndWait("Connecting the elements...");

		Console.WriteLine("\nType the elements to check if they're connected:");
		int qnum1 = ReadIntegerInput("Number 1: ");
		int qnum2 = ReadIntegerInput("Number 2: ");

		bool isConnected = elements.Query(qnum1, qnum2);

		ClearConsole();
		Console.WriteLine("Query Result:");
		Console.WriteLine($"Elements {qnum1} and {qnum2} are {(isConnected ? "connected" : "not connected")}");

		Console.ReadLine();
	}

	//Methods bellow.
	static int ReadIntegerInput(string message)
	{
		int input;
		bool isValidInput = false;
		do
		{
			Console.Write(message);
			isValidInput = int.TryParse(Console.ReadLine(), out input);
		} while (!isValidInput);

		return input;
	}

	static void ClearConsoleAndWait(string message)
	{
		ClearConsole();
		Console.WriteLine("*** Welcome to the Benner's Exercise ***");
		Console.WriteLine(message);
		Thread.Sleep(2000);
	}

	static void ClearConsole()
	{
		Console.Clear();
	}
}
