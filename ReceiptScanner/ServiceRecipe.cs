using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReceiptScanner
{
    public class ServiceRecipe
    {
        public  void Print(List<Recipe> recipes)
        {
            var listDomestic = recipes.Where(x => x.Domestic == true).OrderBy(x => x.Name).ToList();

            Console.WriteLine(".Domestic");

            PrintRecipes(listDomestic);

            var listImported = recipes.Where(x => x.Domestic == false).OrderBy(x => x.Name).ToList();

            Console.WriteLine(".Imported");

            PrintRecipes(listImported);

            decimal domesticSum = listDomestic.Sum(x => x.Price);
            decimal domesticCount = listDomestic.Count;
            decimal importedSum = listImported.Sum(x => x.Price);
            decimal importedCount = listImported.Count;
            Console.WriteLine($"Domestic cost: ${domesticSum}");
            Console.WriteLine($"Imported cost: ${importedSum}");
            Console.WriteLine($"Domestic count: {domesticCount}");
            Console.WriteLine($"Imported count: {importedCount}");


        }

        public  void PrintRecipe(Recipe recipe)
        {
            Console.WriteLine($"...{recipe.Name}");
            Console.WriteLine($"   Price: ${recipe.Price}");
            Console.WriteLine($"   {recipe.Description.Substring(0, 10)}...");
            if (recipe.Weight == 0)
            {
                Console.WriteLine("   Weight: N/A");
            }
            else
            {
                Console.WriteLine($"   Weight: {recipe.Weight}g");
            }
        }

        public  List<Recipe> Recipes(string recipes)
        {
            WebClient webClient = new WebClient();

            string json = webClient.DownloadString(recipes);

            List<Recipe> listRecipes = JsonSerializer.Deserialize<List<Recipe>>(json);

            return listRecipes;
        }

        public void PrintRecipes(List<Recipe> recipes)
        {
            foreach (var recipe in recipes)
            {
                PrintRecipe(recipe);
            }
        }
    }
}
