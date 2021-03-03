using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NY_PRAGUE_PARKING_TENTA
{
    class ReadAndWrite
    {
        public Vehicle[] ReadDataFromFile() // METOD SOM LÄSER INFON I FILEN.
        {
            if (!File.Exists("ParkingData.txt")) // Checkar om filen inte existerar.
            {
                throw new FileNotFoundException("The file 'ParkingData' was not found. Could not read...");
            }

            StreamReader read = new StreamReader("ParkingData.txt"); // Instans av Streamreader.
           
            Vehicle[] vehicles = new Vehicle[200]; // Instans av Vehicle[] arrayen som anser alla parkeringsplatser. (är egentligen 100 platser)

            string temporary = "";

            using (read) // Använder "using" för att automatiskt stänga länken mellan filen och programmet när det som händer i kodblocket är färdigt.
            {
                temporary = read.ReadLine();
                do
                {
                    for (int i = 0; i < vehicles.Length; i++)
                    {
                        vehicles[i] = GetVehicleFromFile(temporary);
                        temporary = read.ReadLine();
                    }

                } while (temporary != null); // Do - while loop som hämtar info från filen sålänge inte "linen" som läses in == null.
            }
            return vehicles;

        }

        public void WriteDataToFile(Vehicle[] parkingPlaces) // METOD SOM SKRIVER IN DATA I FILEN.
        {
            if (!File.Exists("ParkingData.txt")) // Checkar om filen existerar eller inte.
            {
                Console.WriteLine("The file 'ParkingData.txt' does not exist. To fix this, it will be created a new file now...");
            }
            StreamWriter sw = new StreamWriter("ParkingData.txt");
            using (sw)
            {
                foreach (Vehicle vehicle in parkingPlaces)
                {
                    sw.WriteLine(vehicle.ToString());
                }
                sw.Flush();
            }
        }

        private Vehicle GetVehicleFromFile(string readFile) // METOD SOM HÄMTAR DATAN FRÅM FILEN..
        {
            string[] temporarySplit = readFile.Split('&'); // Skapar en string array som splitar vid varje &-tecken, så att tid, typ av fordon m.m blir uppdelade i olika parametrar.
            DateTime temporaryDate = DateTime.Parse(temporarySplit[0]);
            Vehicle.TypeOfVehicle type;

            if (temporarySplit[1] == "CAR")
            {
                type = Vehicle.TypeOfVehicle.CAR;
            }
            else if (temporarySplit[1] == "MOTORCYCLE")
            {
                type = Vehicle.TypeOfVehicle.MOTORCYCLE;
            }
            else
            {
                type = Vehicle.TypeOfVehicle.EMPTY;
            }
            Vehicle temporaryVehicle = new Vehicle(type, temporarySplit[2], temporaryDate);
           
            return temporaryVehicle;

        }
    }
}
