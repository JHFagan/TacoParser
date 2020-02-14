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
            //DONE// DON'T FORGET TO LOG YOUR STEPS

            logger.LogInfo("Log initialized");

            //DONE// use File.ReadAllLines(path) to grab all the lines from your csv file
            var lines = File.ReadAllLines(csvPath);

            //DONE// Log and error if you get 0 lines and a warning if you get 1 line
            logger.LogInfo($"Lines: {lines[0]}");

            //DONE// Create a new instance of your TacoParser class
            var parser = new TacoParser();

            //DONE// Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();
            double metresToMiles = 0.00062137;

            // Now, here's the new code

            //DONE// Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            TacoBells bell1 = null;
            TacoBells bell2 = null;
            //DONE// Create a `double` variable to store the distance
            double distance = 0;
            
            //DONE// Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
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

            // Create a new corA Coordinate with your locA's lat and long
            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
            // Create a new Coordinate with your locB's lat and long
            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.

            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops
        }
    }
}