using System;
using System.Collections.Generic;

namespace Benner.entities
{
	public class Network
	{
		private int elements;
		private List<Tuple<int, int>> connections; // Field to store the connections

		public Network(int elements) // Constructor
		{
			if (elements <= 0)
			{
				throw new ArgumentException("Write a positive integer number!");
			}
			this.elements = elements;
			this.connections = new List<Tuple<int, int>>(); // Initialize the connections list
		}

		public void Connect(int num1, int num2) // First Method
		{
			if (num1 < 1 || num1 > elements || num2 < 1 || num2 > elements)
			{
				throw new ArgumentException("Elements must be within the range of 1 to " + elements + ".");
			}

			// Check if the connection already exists
			foreach (var connection in connections)
			{
				if ((connection.Item1 == num1 && connection.Item2 == num2) || (connection.Item1 == num2 && connection.Item2 == num1))
				{
					throw new ArgumentException("Connection already exists.");
				}
			}


			// Adding the connection to the connections list
			connections.Add(new Tuple<int, int>(num1, num2));
		}

		public bool Query(int num1, int num2) // Second Method
		{
			if (num1 < 1 || num1 > elements || num2 < 1 || num2 > elements)
			{
				throw new ArgumentException("Elements must be within the range of 1 to " + elements + ".");
			}

			//Checking for direct connections
			foreach (var connection in connections)
			{
				if ((connection.Item1 == num1 && connection.Item2 == num2) || (connection.Item1 == num2 && connection.Item2 == num1))
				{
					return true;
				}
			}
			//Checking for indirect connections
			foreach (var connection in connections)
			{
				if (connection.Item1 == num1)
				{
					if (Query(connection.Item2, num2))
					{
						return true;
					}
				}
				else if (connection.Item2 == num1)
				{
					if (Query(connection.Item1, num2))
					{
						return true;
					}
				}

			}
			return false;

		}
	}
}
