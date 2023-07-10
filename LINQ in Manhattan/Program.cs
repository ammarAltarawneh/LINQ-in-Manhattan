using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using LINQ;
using Newtonsoft.Json;

internal class Program
{
    private static void Main(string[] args)
    {

        // Reading the JSON file
        
        string json = File.ReadAllText("../../../data.json");

        // Deserialize the JSON data
        JsonModel.Root myDeserializedClass = JsonConvert.DeserializeObject<JsonModel.Root>(json);






        // Output all of the neighborhoods in this data list(Final Total: 147 neighborhoods)

        Console.WriteLine("All of the neighborhoods in this data list : ");
       var neighborhoods = from feature in myDeserializedClass.features
                            select feature.properties.neighborhood;



        int count = 1;
        foreach (var neighborhood in neighborhoods)
        {
            Console.WriteLine(count + " " + neighborhood);
            count++;
        }
        Console.WriteLine();




        // Filter out all the neighborhoods that do not have any names(Final Total: 143)

        Console.WriteLine("All of the neighborhoods that do not have any names : ");
        var nullNeighborhoods = from feature in myDeserializedClass.features
                                where string.IsNullOrWhiteSpace(feature.properties.neighborhood)
                                select feature.properties.neighborhood;



        int count2 = 1;
        foreach (var neighborhood in nullNeighborhoods)
        {
            Console.WriteLine(count2 + " " + neighborhood);
            count2++;
        }


        Console.WriteLine();


        // Remove the duplicates(Final Total: 39 neighborhoods)
        Console.WriteLine("All of the neighborhoods without duplicates : ");

        var neighborhoodsDistinct = (from feature in myDeserializedClass.features
                             select feature.properties.neighborhood).Distinct();



        int count3 = 1;
        foreach (var neighborhood in neighborhoodsDistinct)
        {
            Console.WriteLine(count3 + " " + neighborhood);
            count3++;
        }

        Console.WriteLine();



        //Rewrite the queries from above and consolidate all into one single query.
        Console.WriteLine("All of the queries from above in one single query : ");

        var singleQuery = (from feature in myDeserializedClass.features
                             where !string.IsNullOrWhiteSpace(feature.properties.neighborhood)
                             select feature.properties.neighborhood).Distinct();



        int count4 = 1;
        foreach (var neighborhood in singleQuery)
        {
            Console.WriteLine(count4 + " " + neighborhood);
            count4++;
        }
        Console.WriteLine();







        //Rewrite at least one of these questions only using the opposing method
        //(example: Use LINQ Query statements instead of LINQ method calls and vice versa.)

        Console.WriteLine("All of the neighborhoods using LINQ method calls : ");

        var neighborhoodsMethod = myDeserializedClass.features
        .Select(feature => feature.properties.neighborhood);
   

        int count5 = 1;
        foreach (var neighborhood in neighborhoods)
        {
            Console.WriteLine(count5 + " " + neighborhood);
            count5++;
        }
        Console.WriteLine();















    }
}