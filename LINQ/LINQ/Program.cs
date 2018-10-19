using System;
using System.Collections.Generic;
using System.IO;
using LINQ.Classes;
using Newtonsoft.Json;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("QUERIES!\n\n");
            List<Feature> list = GetListOfFeatures();

            Console.WriteLine("Query #1: All Feature Neighborhoods");
            PrintAllNeighborhoods(list);
            Console.WriteLine("\n================================\n");

            Console.WriteLine("Query #2: Non-empty Feature Neighborhoods");
            PrintAllNamedNeighborhoods(list);
            Console.WriteLine("\n================================\n");

            Console.WriteLine("Queries #3 & #4: Unique, Non-empty Feature Neighborhoods");
            PrintAllUniqueNamedNeighborhoods(list);
            Console.WriteLine("\n================================\n");

            Console.WriteLine("Query #5: REFACTORED Unique, Non-empty Feature Neighborhoods");
            RefactoredPrintAllUniqueNamedNeighborhoods(list);
        }

        /// <summary>
        /// Returns a list of Feature objects from data.json
        /// </summary>
        /// <returns>List of features</returns>
        static List<Feature> GetListOfFeatures()
        {
            string path = "../../../data.json";
            string text = "";

            //Access file and get contents
            using (StreamReader sr = File.OpenText(path))
            {
                text = sr.ReadToEnd();
            }

            //deserialize JSON and convert to FeatureCollection
            FeatureCollection featureCollection = JsonConvert.DeserializeObject<FeatureCollection>(text);
            return featureCollection.Features;
        }


        /// <summary>
        /// Query # 1 - Get and display ALL neighborhoods from each feature in data.json
        /// </summary>
        /// <param name="list">List of Features</param>
        static void PrintAllNeighborhoods(List<Feature> list)
        {
            var allHoods = list.Select(x => x.Properties.Neighborhood);
            foreach (string name in allHoods)
            {
                if (name == "")
                {
                    Console.WriteLine("[empty name],");
                }
                else Console.WriteLine($"{name}");
            }
        }


        /// <summary>
        /// Query # 2 - Selects and prints all named neighborhoods from features in data.json
        /// </summary>
        /// <param name="list">List of features</param>
        static void PrintAllNamedNeighborhoods(List<Feature> list)
        {
            var allNamedHoods = list.Where(x => x.Properties.Neighborhood != "")
                                    .Select(x => x.Properties.Neighborhood);
            foreach (string name in allNamedHoods)
            {
                Console.WriteLine(name);
            }
        }


        /// <summary>
        /// Queries #3 & #4 - Selects and prints all uniqued, named neighborhoods, building off of 
        /// queries #1 and #2.
        /// </summary>
        /// <param name="list">List of Features</param>
        static void PrintAllUniqueNamedNeighborhoods(List<Feature> list)
        {
            var allNamedHoods = list.Where(x => x.Properties.Neighborhood != "")
                        .Select(x => x.Properties.Neighborhood)
                        .Distinct();
            foreach (string name in allNamedHoods)
            {
                Console.WriteLine(name);
            }
        }


        /// <summary>
        /// Refactors query #3 to use a ye olde linq instead of lambda functions
        /// </summary>
        /// <param name="list">List of Features</param>
        static void RefactoredPrintAllUniqueNamedNeighborhoods(List<Feature> list)
        {
            var allUniqueNamedHoods = (from item in list
                                 where item.Properties.Neighborhood != ""
                                 select item.Properties.Neighborhood).Distinct();

            foreach (string name in allUniqueNamedHoods)
            {
                Console.WriteLine(name);
            }
        }
    }
}
