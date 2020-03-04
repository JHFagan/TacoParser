using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();
            double metresToMiles = 0.00062137;

            TacoBells bell1 = null;
            TacoBells bell2 = null;
            double distance = 0;
            
            for (int i = 0; i < locations.Length; i++ )
            {
                TacoBells locA = (TacoBells)locations[i];
                GeoCoordinate corA = new GeoCoordinate(locA.lat, locA.longi);

                for (int j = 0; j < locations.Length; j++)
                {
                    TacoBells locB = (TacoBells)locations[j];
                    GeoCoordinate corB = new GeoCoordinate(locB.lat, locB.longi);
                    double tempDist = corB.GetDistanceTo(corA);
                    
                    if (distance < tempDist)
                    {
                        distance = tempDist;
                        bell1 = locA;
                        bell2 = locB;                     
                    }                   
                }         
            }
            Console.WriteLine($"The two TacoBells furthest from eachother are {bell1.Name} and {bell2.Name}." + 
                $"The distance between the two is {Math.Round((distance*metresToMiles),2)} miles.");

        }
    }
}