using System;
using SpaceParkAPI;
using SpaceParkAPI.Controllers;
using SpaceParkAPI.Data;
using SpaceParkAPI.Models;

namespace SpaceParkConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            //Test comment

            StartMenu();
        }

        public static void StartMenu()
        {
            int selectedOption = ShowMenu("Welcome to the Space Park App! Please choose an option: ", new[] { "Start parking", "End parking", "See parking", "Admin", "Quit" });

            if(selectedOption == 0)
            {
                Console.WriteLine("Enter your name: ");
                string input = Console.ReadLine();



            }

            else if(selectedOption == 1)
            {

            }

            else if(selectedOption == 2)
            {

            }

            else if (selectedOption == 3)
            {

            }

            else if (selectedOption == 4)
            {

            }
        }

        public static int ShowMenu(string prompt, string[] options)
        {
            if (options == null || options.Length == 0)
            {
                throw new ArgumentException("Cannot show a menu for an empty array of options.");
            }

            Console.WriteLine(prompt);

            int selected = 0;

            // Hide the cursor that will blink after calling ReadKey.
            Console.CursorVisible = false;

            ConsoleKey? key = null;
            while (key != ConsoleKey.Enter)
            {
                // If this is not the first iteration, move the cursor to the first line of the menu.
                if (key != null)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = Console.CursorTop - options.Length;
                }

                // Print all the options, highlighting the selected one.
                for (int i = 0; i < options.Length; i++)
                {
                    var option = options[i];
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("- " + option);
                    Console.ResetColor();
                }

                // Read another key and adjust the selected value before looping to repeat all of this.
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow)
                {
                    selected = Math.Min(selected + 1, options.Length - 1);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    selected = Math.Max(selected - 1, 0);
                }
            }

            // Reset the cursor and return the selected option.
            Console.CursorVisible = true;
            return selected;
        }
    }
}
