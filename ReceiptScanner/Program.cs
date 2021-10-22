
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReceiptScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceRecipe serviceRecipe = new ServiceRecipe();

            List<Recipe> recipes = serviceRecipe.Recipes("https://interview-task-api.mca.dev/qr-scanner-codes/alpha-qr-gFpwhsQ8fkY1");
           

            serviceRecipe.Print(recipes);

           

            Console.ReadLine();
        }

       
    }
}
