namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");
            if (line == null)
            {
                return null;
            }


            //DONE// Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            //DONE// If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                //DONE// Log that and return null
                logger.LogError("Incorrect Input Info");
                //DONE// Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }
            
            //DONE// grab the latitude from your array at index 0
            var lat = double.Parse(cells[0]);
            //DONE// grab the longitude from your array at index 1
            var longi = double.Parse(cells[1]);
            //DONE// grab the name from your array at index 2
            var name = cells[2];
            //DONE// Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            //DONE// You'll need to create a TacoBell class
            //DONE// that conforms to ITrackable

            //DONE// Then, you'll need an instance of the TacoBell class
            //DONE// With the name and point set correctly
            var p = new Point()
            {
              Latitude = lat,
              Longitude = longi
            };

            var tacoBell = new TacoBells();
            tacoBell.lat = lat;
            tacoBell.longi = longi;
            tacoBell.Name = name;
            //var tacoBell = new TacoBells(name, lat, longi);
            //DONE// Then, return the instance of your TacoBell clas
            //DONE// Since it conforms to ITrackable

           
            return tacoBell;
            
        }
    }
}