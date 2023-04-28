using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10061605_POE_Part1_recipeApp
{   
    class Recipe
    {
        // Properties
        private int numIngredients;
        private Ingredient[] ingredients;
        private int numSteps;
        private string[] steps;

        // Constructor
        public Recipe()
        {
            numIngredients = 0;
            ingredients = new Ingredient[0];
            numSteps = 0;
            steps = new string[0];
        }

        // Method to add an ingredient
        public void AddIngredient(string name, double quantity, string unit)
        {
            Array.Resize(ref ingredients, numIngredients + 1); //use of ref to allow step incrementing
            ingredients[numIngredients] = new Ingredient(name, quantity, unit);
            numIngredients++;
        }

        // Method to add a step
        public void AddStep(string step)
        {
            Array.Resize(ref steps, numSteps + 1);
            steps[numSteps] = step;
            numSteps++;
        }

        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine("- {0} {1} of {2}", ingredients[i].Quantity, ingredients[i].Unit, ingredients[i].Name);
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, steps[i]);
            }
        }

        // Method to scale the quantities by a factor
        public void ScaleQuantities(double factor)
        {
            for (int i = 0; i < numIngredients; i++)
            {
                ingredients[i].Quantity *= factor;
                ingredients[i].Factor *= factor;
            }
        }

        // Method to reset the quantities to the original values
        public void ResetQuantities()
        {
            for (int i = 0; i < numIngredients; i++)
            {
                ingredients[i].Quantity /= ingredients[i].Factor;
                ingredients[i].Factor = 1;
            }
        }

        // Method to clear all data
        public void ClearData()
        {
            numIngredients = 0;
            ingredients = new Ingredient[0];
            numSteps = 0;
            steps = new string[0];
        }

        // Method to prompt the user for input and add ingredients and steps to the recipe
        public void GetDetails()
        {
            Console.WriteLine("Please enter the recipe details:");

            // Prompt for ingredients
            Console.Write("How many ingredients does the recipe have? ");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("Enter the name of ingredient {0}: ", i + 1);
                string name = Console.ReadLine();

                Console.Write("Enter the quantity of {0}: ", name);
                double quantity = double.Parse(Console.ReadLine());

                Console.Write("Enter the unit measure for {0}: ", name);
                string unit = Console.ReadLine();

                AddIngredient(name, quantity, unit);
            }

            // Prompt for steps
            Console.Write("How many steps does the recipe have? ");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write("Enter step {0}: ", i + 1);
                string step = Console.ReadLine();

                AddStep(step);
            }
        }

        // Method to display the recipe
        public void Display()
        {
            DisplayRecipe();
        }

        // Method to prompt the user for a scaling factor and adjust the quantities of the ingredients
        public void Scale()
        {
            Console.Write("Enter the scaling factor: ");
            double factor = double.Parse(Console.ReadLine());

            ScaleQuantities(factor);
        }

    }

    class Ingredient
    {
        // Properties
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Factor { get; set; }

        // Constructor
        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Factor = 1;
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to RecipeApp!");
            Console.WriteLine("----------------------");

            Recipe recipe = new Recipe();

            //Use of a switch case is best as it will act like a option activator for the code. It will call the necessary methods for the action required by the user.

            while (true)
            {
                Console.WriteLine("What would you like to do? Please select an option.");

                Console.WriteLine("Enter only the number. ");
                Console.WriteLine("__________________ O P T I O N S _____________________________");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit");
                Console.WriteLine("______________________________________________________________");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        recipe.GetDetails();
                        break;
                    case "2":
                        recipe.Display();
                        break;
                    case "3":
                        recipe.Scale();
                        break;
                    case "4":
                        recipe.ResetQuantities();
                        break;
                    case "5":
                        recipe = new Recipe();
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
