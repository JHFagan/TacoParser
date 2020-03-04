namespace LoggingKata
{
  
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

            if (cells.Length < 3)
            {
                logger.LogError("Incorrect Input Info");
                return null;
            }

            var lat = double.Parse(cells[0]);
            var longi = double.Parse(cells[1]);
            var name = cells[2];

            var p = new Point()
            {
              Latitude = lat,
              Longitude = longi
            };

            var tacoBell = new TacoBells();
            tacoBell.lat = lat;
            tacoBell.longi = longi;
            tacoBell.Name = name;
 
            return tacoBell;
            
        }
    }
}