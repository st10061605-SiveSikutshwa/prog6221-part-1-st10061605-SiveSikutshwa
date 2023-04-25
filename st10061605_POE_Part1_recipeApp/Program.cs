using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10061605_POE_Part1_recipeApp
{   
    class Recipe
    {
        //declarations
        private int numIngredients;
        private string[] ingredients; //storing these in a array
        private double[] quantiites;
        private string[] units;
        private int numSteps;
        private string[] theSteps;

        public Recipe()
        {
            //intializing the variables
            numIngredients = 0;
            ingredients = new string[0];
            quantiites = new double[0];
            units = new string[0];
            numSteps = 0;
            theSteps = new string[0];
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
