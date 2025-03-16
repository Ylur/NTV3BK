// WeatherData.cs
namespace Verkefni1
    public class WeatherData
    {
        private double temperature;
        private int humidity;
        private char scale; // 'C' or 'F'

        public double Temperature
        {
            get { return temperature; }
            set
            {
                if (scale == 'C')
                {
                    // Valid Celsius range -60 to +60
                    if (value < -60 || value > 60)
                    {
                        Console.WriteLine("Unrealistic Celsius temperature reading. Possible sensor error.");
                    }
                    else
                    {
                        temperature = value;
                    }
                }
                else if (scale == 'F')
                {
                    // Valid Fahrenheit range -76 to +140
                    if (value < -76 || value > 140)
                    {
                        Console.WriteLine("Unrealistic Fahrenheit temperature reading. Possible sensor error.");
                    }
                    else
                    {
                        temperature = value;
                    }
                }
                else
                {
                    Console.WriteLine("Scale not set correctly. Must be 'C' or 'F'.");
                }
            }
        }

        public int Humidity
        {
            get { return humidity; }
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("Humidity must be between 0% and 100%.");
                }
                else
                {
                    humidity = value;
                }
            }
        }

        public char Scale
        {
            get { return scale; }
            set
            {
                if (value == 'C' || value == 'F')
                {
                    scale = value;
                }
                else
                {
                    Console.WriteLine("Invalid scale value. Must be 'C' or 'F'.");
                }
            }
        }

        public void Convert()
        {
            if (scale == 'C')
            {
                // Celsius to Fahrenheit
                temperature = (temperature * 9 / 5) + 32;
                scale = 'F';
            }
            else if (scale == 'F')
            {
                // Fahrenheit to Celsius
                temperature = (temperature - 32) * 5 / 9;
                scale = 'C';
            }
            else
            {
                Console.WriteLine("Scale not set correctly. Cannot convert.");
            }
        }
    }
}
