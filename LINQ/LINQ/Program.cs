using System;
using System.Collections.Generic;
using System.IO;
using LINQ.Classes;
using Newtonsoft.Json;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FeatureCollection list = ConvertJson();
        }

        static FeatureCollection ConvertJson()
        {
            string path = "../../../data.json";
            string text = "";

            //Access file and get contents
            using (StreamReader sr = File.OpenText(path))
            {
                text = sr.ReadToEnd();
            }

            //deserialize JSON and convert to FeatureCollection of features
            FeatureCollection featureCollection = JsonConvert.DeserializeObject<FeatureCollection>(text);
            Console.WriteLine("deserialized");
            return featureCollection;
        }
    }
}
