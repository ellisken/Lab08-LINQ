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
            Console.WriteLine("Hello World!");
            IEnumerable<Feature> list = GetListOfFeatures();

            //Query #1 - Get all neighborhoods
            var allHoods = list.Select(x => x.Properties.Neighborhood);


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
    }
}
