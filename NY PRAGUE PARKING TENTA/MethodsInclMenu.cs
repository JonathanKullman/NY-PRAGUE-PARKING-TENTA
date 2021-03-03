using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace NY_PRAGUE_PARKING_TENTA
{
    class MethodsInclMenu
    {
        public Vehicle[] parkingPlaces = new Vehicle[200]; //Skapar en array av classen "Vehicle" som anser platserna i parkeringshuset. 
                                                           // Anledningen till att jag skapat 200 platser är för att det kan få plats upp till 200 motorcyklar eftersom det kan stå 2 st på samma plats.
                                                           //Men själva parkeringshuset innehar endast 100 parkeringsplatser.



        //-----------------------------///////////_____METODER NEDAN____\\\\\\\\\\---------------------------------------------

        public void MainMenu()//DENNA METOD INNEHÅLLER TRY-CATCHEN, VISUELLA MENYN OCH SWITCHCASE FÖR MENYVAL.
        {
            string input;//Variabel som ska lagra användarens val i menyn.

            bool exitProgram = false; // Bool som styr do-while loopen i menyn. Om användaren väljer exit sätter jag exitProgram till "true".

            ReadAndWrite readMe = new ReadAndWrite(); // skapar en ny instans av classen "ReadAndWrite".
            try
            {
                parkingPlaces = readMe.ReadDataFromFile(); // Testar om programmet kan läsa tidigare fil för att hämta data.

                string add = "..........";

                Console.SetCursorPosition(43, 7);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("SEARCHING FOR FILE \n\t\t\t\t\t       ");

                for (int i = 0; i < add.Length; i++)
                {
                    Console.Write(add[i]);
                    Thread.Sleep(350);
                }

                Console.Clear();
                Console.SetCursorPosition(47, 10);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("FILE FOUND!");
                Thread.Sleep(70);
                Console.Clear();
                Console.SetCursorPosition(47, 10);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("FILE FOUND!");
                Thread.Sleep(150);
                Console.Clear();
                Console.SetCursorPosition(47, 10);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("FILE FOUND!");
                Thread.Sleep(150);
                Console.Clear();
                Console.SetCursorPosition(47, 10);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("FILE FOUND!");
                Thread.Sleep(150);
                Console.Clear();
                Console.SetCursorPosition(47, 10);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("FILE FOUND!");
                Thread.Sleep(150);
                Console.Clear();
                Console.SetCursorPosition(47, 10);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("FILE FOUND!");
                Thread.Sleep(150);
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

            }

            catch (FileNotFoundException ex) // I Denna Catch fångar vi ett exception om programmet inte kan allokera filen.
                                             //Därefter skapar vi en ny fil, helt tom.
            {
                string add = "..........";

                Console.SetCursorPosition(43, 7);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("SEARCHING FOR FILE \n\t\t\t\t\t\t");

                for (int i = 0; i < add.Length; i++)
                {
                    Console.Write(add[i]);
                    Thread.Sleep(400);
                }

                Console.Clear();
                Console.SetCursorPosition(27, 8);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(ex.Message);
                Console.SetCursorPosition(19, 10);
                Console.WriteLine("   Since the file Couldn't be found, you'll have to create a new one. ");
                Console.SetCursorPosition(42, 13);
                Console.WriteLine(" Press ENTER to do so...");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("\n\t\t\t\t\t\t ");
                Console.ReadLine();

                FileStream ts = File.Create("ParkingData.txt"); // Här skapar jag en ny fil, då programmet ej kunde hitta någon.
                ts.Close();

                for (int i = 0; i < parkingPlaces.Length; i++) //Går igenom alla element (parkeringsplatser) och "fyller" dem med "EMPTY". 
                {
                    parkingPlaces[i] = new Vehicle(Vehicle.TypeOfVehicle.EMPTY, "EMPTY", DateTime.MinValue);
                }

                readMe.WriteDataToFile(parkingPlaces); //Med hjälp av denna kod så skriver vi sedan in denna information i filen.
                Console.Clear();
                Console.SetCursorPosition(23, 8);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("A new file has now been created, named 'ParkingData.txt'");
                Console.SetCursorPosition(5, 11);
                Console.WriteLine("If there were any parked cars, they will all be gone now along with it's associated information.");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();

            }

            do
            {

                //-----------HÄR BÖRJAR DEN VISUELLA DELEN AV MENYN---------------
                Console.Clear();
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.SetCursorPosition(36, 1);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\t\t\t  ______________________________________________");
                Console.WriteLine("\t\t\t |                                              |");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\t\t\t |      ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\u2193 ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\u2193 ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\u2193 ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("CHOOSE AN OPTION BELOW ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\u2193 ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\u2193 ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\u2193");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("      |");
                Console.WriteLine("\n\t\t\t |______________________________________________|");
                Console.WriteLine("\t\t\t |                                              |");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t |  (1)  -  Search for a vehicle.               |");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t |                                              |");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\t\t\t |  (2)  -  Check a specific parking spot.      |");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t |                                              |");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\t |  (3)  -  Check in a vehicle.                 |");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t |                                              |");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t\t |  (4) - Check out a vehicle.                  |");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t |                                              |");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\t\t\t |  (5) - Move vehicle to another parking spot. |");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t |                                              |");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t\t |  (6)  -  Display all parking spots.          |");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t |                                              |");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\t\t\t |  (7)  -  Optimize the whole parkinghouse.    |");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t |                                              |");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\t |  (8) - Optimize all the motorcycle parkings. |");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t |                                              |");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t |  (9) - ERASE ALL DATA.                       |");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t |                                              |");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t\t |  (10) - Add 5 cars & 5 motorcycles.          |");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t |                                              |");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\t\t\t |  (11)  -  EXIT PROGRAM.                      |");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t |                                              |");
                Console.WriteLine("\t\t\t |______________________________________________|");
                Console.Write("\n\t\t\t\t         ");

                Console.SetCursorPosition(48, 30);

                input = Console.ReadLine();


                //NEDAN, SWITCHCASE SOM REFERERAR TILL DE OLIKA METODERNA BEROENDE PÅ ANVÄNDARENS VAL.
                switch (input)
                {
                    case "1":
                        SearchForDesiredVehicle();
                        break;
                    case "2":
                        SearchParkingSpot();
                        break;
                    case "3":
                        CheckInVehicle();
                        break;
                    case "4":
                        RemoveDesiredVehicle();
                        break;
                    case "5":
                        MoveDesiredVehicle();
                        break;
                    case "6":
                        ViewAllParkings();
                        break;
                    case "7":
                        OptimizationOfParkHouse();
                        break;
                    case "8":
                        OptimizationOfBikes();
                        break;
                    case "9":
                        EraseAllData();
                        break;
                    case "10":
                        AddExampleVehicles();
                        break;
                    case "11":
                        Console.Clear();
                        Console.SetCursorPosition(36, 10);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("Are you sure you want to EXIT? ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Yes ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("or ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("No");
                        Console.Write("\n\n\t\t\t\t\t\t\t");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.BackgroundColor = ConsoleColor.Black;
                        string exit = Console.ReadLine().ToLower();

                        if (exit == "yes")
                        {
                            exitProgram = true;
                            continue;

                        }
                        else if (exit == "no")
                        {

                            break;
                        }

                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(36, 10);
                            Console.WriteLine("\t     You have entered an invalid answer.");
                            Console.Write("\t\t\t\t\t     Press ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("ENTER ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("to get back to the Menu...");
                            Console.ReadLine();
                        }
                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(36, 10);
                        Console.WriteLine("\t     You have entered an invalid answer.");
                        Console.Write("\t\t\t\t\t    Press ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("ENTER ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("to get back to the Menu...");
                        Console.ReadLine();
                        break;
                }

            } while (exitProgram == false);
        }

        private string RetrieveReg() // DENNA METOD ANROPAS NÄR REGNUMMER SKA SLÅS IN. DET STRINGWASHAS ÄVEN HÄR, DVS TAR BORT EVENTUELLA FORMATFEL

        {
            string licenseNumb;

            do //Skapar här en do-while loop som ställer villkoret att regnummret måste vara under 10 bokstäver/siffror långt och minst en bokstav/siffra. 
            {

                Console.Clear();
                Console.SetCursorPosition(32, 10);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Enter the licenseplate for your vehicle:");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("\n\t\t\t\t\t\t");
                licenseNumb = Console.ReadLine().ToUpper();
                Console.ResetColor();

            } while (licenseNumb == "" || licenseNumb.Length > 10);

            licenseNumb = Regex.Replace(licenseNumb, @"[^\w]", ""); //Använder Regex för att "tvätta" regnumret från white-spaces och andra tecken än bokstäver och siffror.
            Console.Clear();

            return licenseNumb;

        }

        private void CheckInVehicle()
        {
            Console.Clear();

            string takenReg = "";
            bool parkingAvailable = false;
            DateTime timeNow = DateTime.Now; // sätter timeNow till den nuvarande tiden.

            string tempReg = RetrieveReg();

            Vehicle.TypeOfVehicle tempType = RetreiveTypeOfVehicle(); 

            for (int i = 0; i < parkingPlaces.Length; i++) // Checkar igenom alla parkeringplatser.
            {
                if (parkingPlaces[i].RegNum == tempReg) // Om regnumret som skrivits in redan finns i parkeringshuset skrivs följande ut..
                {
                    takenReg = parkingPlaces[i].RegNum;
                    Console.SetCursorPosition(14, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The registrationnumber to the associated car you have put in, is already parked here.");
                    Console.SetCursorPosition(36, 11);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Press ENTER to get back to the menu.");
                    Console.ResetColor();
                    Console.ReadLine();
                    parkingAvailable = true;
                    break;
                }
            }

            if (tempType == Vehicle.TypeOfVehicle.CAR && tempReg != takenReg) // om regnummret inte finns i p-huset och typen man valt är en bil..
            {
                for (int i = 0; i < 100; i++)
                {
                    if (parkingPlaces[i].VehicleType == Vehicle.TypeOfVehicle.EMPTY)
                    {
                        parkingPlaces[i] = new Vehicle(Vehicle.TypeOfVehicle.EMPTY, "EMPTY", DateTime.MinValue);
                        parkingPlaces[i] = (new Vehicle(tempType, tempReg, timeNow));
                        Console.SetCursorPosition(36, 8);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Car |{parkingPlaces[i].RegNum}| got assigned to spot {i + 1}.");
                        Console.SetCursorPosition(33, 11);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("Press ENTER to return to the main menu.");
                        Console.ResetColor();
                        Console.ReadLine();
                        parkingAvailable = true;
                        break;
                    }
                }
            }
            else if (tempType == Vehicle.TypeOfVehicle.MOTORCYCLE && tempReg != takenReg)  // om regnummret inte finns i p-huset och typen man valt är en bil..
            {
                for (int i = 0; i < 100; i++)
                {
                    if (parkingPlaces[i].VehicleType == Vehicle.TypeOfVehicle.EMPTY)
                    {
                        parkingPlaces[i] = new Vehicle(Vehicle.TypeOfVehicle.EMPTY, "EMPTY", DateTime.MinValue);
                        parkingPlaces[i] = new Vehicle(tempType, tempReg, timeNow);
                        Console.SetCursorPosition(35, 8);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Motorcycle |{parkingPlaces[i].RegNum}| got assigned to spot {i + 1}");
                        Console.SetCursorPosition(35, 11);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("Press ENTER to return to the main menu.");
                        Console.ResetColor();
                        Console.ReadLine();
                        parkingAvailable = true;
                        break;
                    }
                    if (parkingPlaces[i].VehicleType == Vehicle.TypeOfVehicle.MOTORCYCLE) //om regnummret inte finns i p-huset och typen man valt är en bil..
                    {
                        if (parkingPlaces[i + 100].VehicleType == Vehicle.TypeOfVehicle.EMPTY) // Om det på samma plats alltså (i + 100), inte står en till mc, alltså 2 på p-platsen (i).
                                                                                               // Så lägger vi in mc:n på denna platsen så att vi fyller den med 2 st.
                        {
                            parkingPlaces[i + 100] = new Vehicle(Vehicle.TypeOfVehicle.EMPTY, "EMPTY", DateTime.MinValue);
                            parkingPlaces[i + 100] = new Vehicle(tempType, tempReg, timeNow);
                            Console.SetCursorPosition(16, 8);
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine($"Motorcycle |{parkingPlaces[i + 100].RegNum}| got assigned to spot {i + 1}. " +
                                $"This spot also holds the motorcycle |{parkingPlaces[i].RegNum}|");
                            Console.SetCursorPosition(35, 11);
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Press ENTER to return to the main menu.");
                            Console.ResetColor();
                            Console.ReadLine();
                            parkingAvailable = true;
                            break;

                        }
                    }
                }
            }
            if (parkingAvailable == false) // Om parkeringarna är fulla så skrivs följande ut.
            {
                Console.SetCursorPosition(25, 11);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"Unfortunately there is no place left for your ({tempType.ToString().ToLower()}) to be parked at.");
            }


            else // Här skickar vi in infon i filen.
            {
                ReadAndWrite rw = new ReadAndWrite();
                try
                {
                    rw.WriteDataToFile(parkingPlaces);
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        } // METOD SOM CHECKAR IN FORDON.

        private void MoveDesiredVehicle()
        {
            Console.Clear();

            string licensePlate = RetrieveReg(); // hämtar regnummer från användaren.

            int parkSpot = SearchForASpot(licensePlate);

            if (parkSpot < 0)
            {
                Console.SetCursorPosition(29, 8);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"UNABLE TO FIND A VEHICLE WITH LICENSE |{licensePlate}|");
                Console.ResetColor();
            }
            else
            {
                int moveToSpot = RetrieveParkingSpot();


                if (parkingPlaces[parkSpot].VehicleType == Vehicle.TypeOfVehicle.MOTORCYCLE && 
                    parkingPlaces[moveToSpot].VehicleType == Vehicle.TypeOfVehicle.MOTORCYCLE && //Om angivet regnr är en mc, och där det endast står EN mc på platsen man vill flytta till
                    parkingPlaces[moveToSpot + 100].VehicleType == Vehicle.TypeOfVehicle.EMPTY) 
                {
                    Vehicle temp = parkingPlaces[moveToSpot + 100];
                    parkingPlaces[moveToSpot + 100] = parkingPlaces[parkSpot]; 
                    parkingPlaces[parkSpot] = temp;
                    
                    if (parkSpot < 100) 
                    {
                        if (parkingPlaces[parkSpot + 100].VehicleType == Vehicle.TypeOfVehicle.MOTORCYCLE) 
                        {
                            temp = parkingPlaces[parkSpot + 100];
                            parkingPlaces[parkSpot + 100] = parkingPlaces[parkSpot];
                            parkingPlaces[parkSpot] = temp;
                        }
                    }

                    Console.SetCursorPosition(10, 8);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"The MC with license |{parkingPlaces[moveToSpot + 100].RegNum}| " +
                        $"was driven to parkingspot {moveToSpot + 1}, " +
                        $"where the MC |{parkingPlaces[moveToSpot].RegNum}| also is parked");
                }

                else if (parkingPlaces[moveToSpot].VehicleType == Vehicle.TypeOfVehicle.EMPTY)
                {
                    Vehicle temp = parkingPlaces[moveToSpot];
                    parkingPlaces[moveToSpot] = parkingPlaces[parkSpot];
                    parkingPlaces[parkSpot] = temp;

                    if (parkSpot < 100)
                    {
                        if (parkingPlaces[parkSpot + 100].VehicleType == Vehicle.TypeOfVehicle.MOTORCYCLE)
                        {
                            temp = parkingPlaces[parkSpot + 100];
                            parkingPlaces[parkSpot + 100] = parkingPlaces[parkSpot];
                            parkingPlaces[parkSpot] = temp;
                        }
                    }

                    Console.SetCursorPosition(19, 8);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"The ({parkingPlaces[moveToSpot].VehicleType.ToString().ToLower()}) " +
                        $"with the license |{parkingPlaces[moveToSpot].RegNum}| " +
                        $"was driven to parkingspot {moveToSpot + 1}");
                }
                else
                {
                    Console.SetCursorPosition(24, 8);                   
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Sorry, but the parkingspot {moveToSpot + 1} is already taken by: |{parkingPlaces[moveToSpot].RegNum}|");
                }

            }
            ReadAndWrite rw = new ReadAndWrite();
            try
            {
                rw.WriteDataToFile(parkingPlaces);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.SetCursorPosition(35, 12);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Press ENTER to return to the menu.");
            Console.ReadLine();
        }// METOD SOM FLYTTAR ANGIVEN BIL ELLER MC TILL ANGIVEN PLATS.

        private void RemoveDesiredVehicle()
        {
            Console.Clear();
            string licensePlate = RetrieveReg();
            int indexPos = SearchForASpot(licensePlate);

           
            if (indexPos >= 0 && indexPos < 100)
            {
                TimeSpan span = DateTime.Now - parkingPlaces[indexPos].ArrivedTime; // beräknar den aktuella tiden bilen/mc:n stått parkerad och lagrar i "span".
                int fee = PriceCalculator(parkingPlaces[indexPos]); // Hämtar avgiftsdatan från indexpositionen som slagits in.



                //---------Snyggar till utskriften till konsollen------------
                Console.SetCursorPosition(48, 1);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"| CHECKED OUT |");
                Console.SetCursorPosition(36, 3);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"THANK YOU FOR CHOOSING OUR PARKINGLOT!");
                Console.SetCursorPosition(38, 6);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("____________INFORMATION____________");
                Console.ResetColor();
                Console.SetCursorPosition(45, 8);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Licenseplate: {parkingPlaces[indexPos].RegNum}");
                Console.SetCursorPosition(44, 10);
                Console.WriteLine($"Type of vehicle: {parkingPlaces[indexPos].VehicleType.ToString().ToLower()}");
                Console.SetCursorPosition(46, 12);
                Console.WriteLine($"Parking-position: {indexPos + 1}");
                Console.SetCursorPosition(38, 14);
                Console.WriteLine($"Checked in at: {parkingPlaces[indexPos].ArrivedTime}");
                Console.SetCursorPosition(34, 16);
                Console.WriteLine($"Total time parked: {span.TotalHours:0,0} hours and {span.Minutes} minutes");
                Console.SetCursorPosition(42, 18);
                Console.WriteLine($"The total fee is: {fee:C}");
   

                if (parkingPlaces[indexPos].VehicleType == Vehicle.TypeOfVehicle.MOTORCYCLE // om där är 2 motorcyklar på samma plats, flyttas den som ligger på indexpos i + 100
                    && parkingPlaces[indexPos + 100].VehicleType == Vehicle.TypeOfVehicle.MOTORCYCLE) // till i.
                {
                    parkingPlaces[indexPos] = parkingPlaces[indexPos + 100];
                    parkingPlaces[indexPos + 100] = new Vehicle(Vehicle.TypeOfVehicle.EMPTY, "EMPTY", DateTime.MinValue);
                }
                else
                {
                    parkingPlaces[indexPos] = new Vehicle(Vehicle.TypeOfVehicle.EMPTY, "EMPTY", DateTime.MinValue);
                }
            }
            else if (indexPos >= 100)
            {
                TimeSpan span = DateTime.Now - parkingPlaces[indexPos].ArrivedTime;
                int fee = PriceCalculator(parkingPlaces[indexPos]); // Hämtar avgiftsdatan från indexpositionen som slagits in.


                //---------Snyggar till utskriften till konsollen------------
                Console.SetCursorPosition(48, 1);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"| CHECKED OUT |");
                Console.SetCursorPosition(36, 3);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"THANK YOU FOR CHOOSING OUR PARKINGLOT!");
                Console.SetCursorPosition(38, 6);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("____________INFORMATION____________");
                Console.ResetColor();
                Console.SetCursorPosition(45, 8);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Licenseplate: {parkingPlaces[indexPos].RegNum}");
                Console.SetCursorPosition(42, 10);
                Console.WriteLine($"Type of vehicle: {parkingPlaces[indexPos].VehicleType.ToString().ToLower()}");
                Console.SetCursorPosition(45, 12);
                Console.WriteLine($"Parking-position: {indexPos + 1}");
                Console.SetCursorPosition(38, 14);
                Console.WriteLine($"Checked in at: {parkingPlaces[indexPos].ArrivedTime}");
                Console.SetCursorPosition(34, 16);
                Console.WriteLine($"Total time parked: {span.TotalHours:0,0} hours and {span.Minutes} minutes");
                Console.SetCursorPosition(42, 18);
                Console.WriteLine($"The total fee is: {fee:C}");


                parkingPlaces[indexPos] = new Vehicle(Vehicle.TypeOfVehicle.EMPTY, "EMPTY", DateTime.MinValue);
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(26, 10);
                Console.WriteLine($"THERE IS NO VEHICLE WITH LICENSE |({licensePlate})| PARKED IN HERE.");
            }

            ReadAndWrite rw = new ReadAndWrite();
            try
            {
                rw.WriteDataToFile(parkingPlaces);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(39, 18);
            Console.WriteLine("Press ENTER to return to the menu.");
            Console.ReadLine();
        }   // METOD SOM CHECKAR UT FORDON.

        private void SearchForDesiredVehicle()
        {
            Console.Clear();
            string regNum = RetrieveReg();
            int indexOf = SearchForASpot(regNum);
            if (indexOf < 0)
            {
                Console.SetCursorPosition(26, 8);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"Vehicle with licenseplate |{regNum}| can not be found..");
                Console.ResetColor();
                Console.SetCursorPosition(32, 10);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Press ENTER to return to the main menu.");
                Console.ResetColor();
                Console.ReadLine();
            }
            else
            {
                RetreiveAndPrintSearch(indexOf);
            }

        }  // METOD SOM SÖKER EFTER EN SPECIFIK BIL ELLER MC I PARKERINGSHUSET.

        private int RetrieveParkingSpot()
        {
            bool validInput = false; // Variabel (bool) som kontrollerar do-while loopen.
            string userInput; // string-variabel som lagrar användarens input.
            int validUserInput; // int variabel som lagrar användarens input efter att den testats och genomgått villkoren.

            do // Skapar en do-while loop som kommer loopa om sålänge som ett ogiltigt svar angivits utifrån villkoren som följer.
            {
                validInput = true;

                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(38, 10);
                Console.WriteLine("Enter parkingspot number: ");
                Console.ResetColor();
                Console.Write("\n\t\t\t\t\t\t  ");

                userInput = "";

                while (userInput.Length < 1) // skapar en while-loop som kommer låta användaren skriva in nytt nummer på direkten
                                             // om värdet är mindre än 1.
                {
                    userInput = Console.ReadLine();
                }

                bool CheckIfValid = int.TryParse(userInput, out validUserInput); // TryParsar userinput, om det går,
                                                                                 // lägger vi in värdet i validUserInput samt som "true" i boolen.


                if (!CheckIfValid) // Om boolen är = false, är inputen från användaren fel. Och allt kommer loopas om.
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(39, 8);
                    Console.WriteLine("INVALID INPUT, TRY AGAIN.");
                    Console.ResetColor();
                    Console.Write("\n\t\t\t\t\t\t");
                    validInput = false;
                }

                if (CheckIfValid == true && validUserInput < 1 || validUserInput > 100) // Om boolen däremot är true, men inputen är mindre än 1 eller större än 100,
                                                                // Skrivs följande kod ut. Allt loopas sedan om igen.
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(32, 8);
                    Console.WriteLine("TO BIG NUMBER, ONLY NUMBERS BETWEEN 1-100.");
                    Console.ResetColor();
                    Console.Write("\n\t\t\t\t\t\t");
                    validInput = false;
                }
            } while (!validInput);
            Console.Clear();

            return validUserInput - 1; // här returnar vi värdet, dvs parkeringsplatsen, men minusar med 1 eftersom vi vill komma åt själva indexet.




        }  // METOD SOM FRÅGAR EFTER PARKINGSPLATS, RETURNAR SEDAN PLATSEN TILL ANROPANDE METOD.

        private int SearchForASpot(string licensePlate) // METOD SOM SÖKER IGENOM ALLA PARKERINGSPLATSER/REGNUMMER 
        {
            for (int i = 0; i < 200; i++)
            {
                if (parkingPlaces[i].RegNum == licensePlate)
                {
                    return i;
                }
            }
            return -1;
        }

        private int PriceCalculator(Vehicle vehicle)
        {
            TimeSpan timeATM = DateTime.Now - vehicle.ArrivedTime; // Beräknar den totala tiden som vald bil/mc har stått i parkeringshuset.

            int feeATM = 0;
            int hours = 0;

            if (timeATM.TotalMinutes < 5) // Här sätter jag villkoret att sålänge som bilen/mc:n stått här mindre än 5 minuter, så är priset 0 kr.
            {
                feeATM = 0;
            }
            else if (timeATM.TotalMinutes < 125)// direkt efter 5 minuter ökar priset från 0kr. till 40kr respektive 20kr beroende på fordonstyp. 
                                                // Detta är 2 timmars avgift, men anges som startavgift.
            {
                if (vehicle.VehicleType == Vehicle.TypeOfVehicle.CAR)
                {
                    feeATM = 40;
                }
                else if (vehicle.VehicleType == Vehicle.TypeOfVehicle.MOTORCYCLE)
                {
                    feeATM = 20;
                }
            }
            else if (timeATM.TotalMinutes > 125) //Efter 2 timmar + 5 minuter startar prisökningen per antal påbörjade timmar.            
            {
               

                if ((timeATM.TotalMinutes - 5) % 60 == 0) // Checkar om tiden == exakt "#" antal timmar. isåfall lägger vi inte på avgift för nästa timme.
                {
                    hours = (int)(timeATM.TotalMinutes - 5) / 60;
                }
                else if ((timeATM.TotalMinutes - 5) % 60 != 0) // Om tiden inte ligger exakt på "#" antal timmar, så plussas nästa timmes avgift på.
                {
                    hours = (int)(timeATM.TotalMinutes - 5) / 60;
                    hours++;
                }
                if (vehicle.VehicleType == Vehicle.TypeOfVehicle.CAR)
                {
                    feeATM = hours * 20; // adderar avgift per timme för bil.
                }
                else if (vehicle.VehicleType == Vehicle.TypeOfVehicle.MOTORCYCLE)
                {
                    feeATM = hours * 10; // adderar avgift per timme för motorcykel.
                }
            }
            return feeATM;

        } // METOD SOM KALKYLERAR AVGIFTEN FÖR ALLA INDIVIDUELLA FORDON.

        private void SearchParkingSpot()
        {
            Console.Clear();
            Console.SetCursorPosition(44, 8);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("SEARCH ENGINE");
            Console.WriteLine();
            int parkingSpot = RetrieveParkingSpot();
            RetreiveAndPrintSearch(parkingSpot);

        }   // SÖKMOTOR SOM REFERAR TILL ANDRA METODER.

        private void OptimizationOfBikes()
        {
            string dots = ".....";

            //---------Snyggar till utskriften till konsollen------------
            Console.Clear();
            Console.SetCursorPosition(50, 10);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("OPTIMIZING");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\t\t\t\t\t\t    ");

            for (int i = 0; i < dots.Length; i++) // Använder en for-loop för att skriva ut punkter med tidsmellanrum, endast för snygg och relevant utskrift.
            {
                Console.Write(dots[i]);
                Thread.Sleep(800);
            }

            //---------Snyggar till utskriften till konsollen------------
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();
            Console.SetCursorPosition(40, 8);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"OPTIMIZATION WAS SUCCESSFULL");
            Console.SetCursorPosition(37, 10);
            Console.WriteLine("Press ENTER to see what happend...");
            Console.ReadLine();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();

            int printY = 8; // deklararerar en variabel för att styra cursorpositionen i y led i utskriften nedan.

            for (int i = 0; i < 100; i++)
            {
                if (parkingPlaces[i].VehicleType == Vehicle.TypeOfVehicle.MOTORCYCLE //Checkar igenom alla parkeringsplatser om där står endast 1 motorcykel.
                    && parkingPlaces[i + 100].VehicleType == Vehicle.TypeOfVehicle.EMPTY)
                {
                    for (int j = i + 1; j < 100; j++) // Om där står en motorcykel, letar vi igenom alla de återstående platserna efter endast 1 motorcykel 
                                                      //  räknat nerifrån, med start + 1(index) från platsen vi hittat första motorcykeln.
                                                      // 
                    {
                        if (parkingPlaces[j].VehicleType == Vehicle.TypeOfVehicle.MOTORCYCLE && parkingPlaces[j + 100].VehicleType == Vehicle.TypeOfVehicle.EMPTY)
                        {
                            Vehicle temp = parkingPlaces[i + 100];
                            parkingPlaces[i + 100] = parkingPlaces[j];
                            parkingPlaces[j] = temp;
                            Console.SetCursorPosition(3, printY);
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine($"The MC with licenseplate: {parkingPlaces[i + 100].RegNum} " +
                                          $"was driven from parkingspot {j + 1} and reallocated to parkingspot {i + 1}.");
                            Console.ResetColor();
                            printY += 2;

                            break;
                        }
                    }
                }
            }
            ReadAndWrite rw = new ReadAndWrite();
            try
            {
                rw.WriteDataToFile(parkingPlaces);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }  // METOD SOM OPTIMERAR PLATSERNA FÖR ENDAST MOTORCYKLARNA I PARKERINGSHUSET.

        private void ViewAllParkings()
        {

            //---------Snyggar till utskriften till konsollen------------
            Console.Clear();
            Console.SetCursorPosition(48, 0);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("OVERVIEW");
            Console.ResetColor();
            Console.SetCursorPosition(24, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("| ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("CARS = DarkCyan ");  
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("| ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("MOTORCYCLES = Magenta ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("| ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("EMPTY = Green ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|");
            Console.WriteLine("\n__________________________________________________________________________________________________________");

            Console.ResetColor();

            int parkPlaceAdd = 0; // variabel som används som index för parkeringsplatserna.
            int parkPlace = 1; //variabel för position i parkeringshuset.
            int yAxis = 5; // Variabel för y-positionen.
            int xAxis = 2; // Variabel för x-positionen.

            for (int x = 0; x < 5; x++) // Skapar en nestan for-loop som skapar en lista med 5 collumner med 20 platser i y led. Skriver ut.
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.WriteLine();

                    if (parkingPlaces[parkPlaceAdd].VehicleType == Vehicle.TypeOfVehicle.CAR)
                    {
                        Console.SetCursorPosition(xAxis, yAxis);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(parkPlace + ":");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("|" + parkingPlaces[parkPlaceAdd].RegNum + "|");
                        Console.ResetColor();
                        

                    }

                    else if (parkingPlaces[parkPlaceAdd].VehicleType == Vehicle.TypeOfVehicle.MOTORCYCLE)
                    {
                        if (parkingPlaces[parkPlaceAdd + 100].VehicleType == Vehicle.TypeOfVehicle.MOTORCYCLE)
                        {
                            Console.SetCursorPosition(xAxis, yAxis);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(parkPlace + ":");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("|" + parkingPlaces[parkPlaceAdd].RegNum + "|+|" + parkingPlaces[parkPlaceAdd + 100].RegNum + "|");
                            Console.ResetColor();
                            
                        }
                        else
                        {
                            Console.SetCursorPosition(xAxis, yAxis);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(parkPlace + ":");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("|" + parkingPlaces[parkPlaceAdd].RegNum + "|");
                            Console.ResetColor();
                           
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(xAxis, yAxis);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(parkPlace + ":");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("EMPTY");
                        Console.ResetColor();
                        
                    }

                    yAxis+=2;
                    parkPlaceAdd++;
                    parkPlace++;

                }
                
                yAxis = 5;
                xAxis = xAxis + 21;

                //---------Snyggar till utskriften till konsollen------------
                Console.WriteLine("\n__________________________________________________________________________________________________________");
                Console.SetCursorPosition(33, 46);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("PRESS ENTER TO RETURN TO THE MENU");
                Console.ResetColor();

            }

            Console.ReadLine();
        }  // METOD SOM SKRIVER UT EN LISTA PÅ ALLA PARKERINGAR I PARKERINGSHUSET.

        private void OptimizationOfParkHouse()
        {
            string dots = ".....";

            //---------Snyggar till utskriften till konsollen------------
            Console.Clear();
            Console.SetCursorPosition(50, 10);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("OPTIMIZING");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\t\t\t\t\t\t    ");

            for (int i = 0; i < dots.Length; i++) // Använder en for-loop för att skriva ut punkter med tidsmellanrum, endast för snygg och relevant utskrift.
            {
                Console.Write(dots[i]);
                Thread.Sleep(800);
            }

            //---------Snyggar till utskriften till konsollen------------
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();
            Console.SetCursorPosition(40, 8);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"OPTIMIZATION WAS SUCCESSFULL");
            Console.SetCursorPosition(37, 10);
            Console.WriteLine("Press ENTER to see what happend...");
            Console.ReadLine();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();

            int printY = 8; // deklararerar en variabel för att styra cursorpositionen i y led i utskriften nedan.

            for (int i = 0; i < 100; i++)
            {
                if (parkingPlaces[i].VehicleType == Vehicle.TypeOfVehicle.EMPTY) // OM parkeringsplats är EMPTY, sker följande..
                {
                    for (int j = 99; j > i; j--)
                    {
                        if (parkingPlaces[j].VehicleType == Vehicle.TypeOfVehicle.CAR) //om parkeringen innehåller en bil.
                        {
                            Vehicle temporaryCar = parkingPlaces[i];
                            parkingPlaces[i] = parkingPlaces[j];
                            parkingPlaces[j] = temporaryCar;
                            Console.SetCursorPosition(3, printY);
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine($"The CAR with licenseplate: {parkingPlaces[i].RegNum} " +
                                              $"was driven from parkingspot {j + 1} and reallocated to parkingspot {i + 1}.");
                            Console.ResetColor();
                            printY += 2;
                            break;
                        }
                        else if (parkingPlaces[j].VehicleType == Vehicle.TypeOfVehicle.MOTORCYCLE) //om parkeringen innehåller en MC.
                        {
                            if (parkingPlaces[j + 100].VehicleType == Vehicle.TypeOfVehicle.MOTORCYCLE) // och om parkeringen innehåller två MC.
                            {
                                Vehicle temporaryMC = parkingPlaces[i];
                                parkingPlaces[i] = parkingPlaces[j];
                                parkingPlaces[i + 100] = parkingPlaces[j + 100];
                                parkingPlaces[j] = temporaryMC;
                                parkingPlaces[j + 100] = temporaryMC;
                                Console.SetCursorPosition(3, printY);
                                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine($"The MC with licenseplate: {parkingPlaces[i].RegNum} " +
                                    $"and {parkingPlaces[i + 100].RegNum}" +
                                    $" was driven from parkingspot {j + 1} and reallocated to parkingspot {i + 1}.");
                                Console.ResetColor();
                                printY += 2;
                                break;
                            }
                            else // Om parkeringen innehåller endast en MC.
                            {
                                Vehicle temp = parkingPlaces[i];
                                parkingPlaces[i] = parkingPlaces[j];
                                parkingPlaces[j] = temp;
                                Console.SetCursorPosition(3, printY);
                                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine($"The MC with licenseplate: {parkingPlaces[i].RegNum} " +
                                              $"was driven from parkingspot {j + 1} and reallocated to parkingspot {i + 1}.");
                                Console.ResetColor();
                                printY += 2;
                                break;
                            }
                        }
                    }
                }
            }
            ReadAndWrite rw = new ReadAndWrite();
            try
            {
                rw.WriteDataToFile(parkingPlaces);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        } // METOD SOM OPTIMERAR HELA PARKERINGSHUSET.

        private Vehicle.TypeOfVehicle RetreiveTypeOfVehicle()
        {
            while (true)
            {
                //---------Snyggar till utskriften till konsollen------------
                Console.Clear();
                Console.SetCursorPosition(40, 8);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("VEHICLETYPE? MC/CAR? ");
                Console.ResetColor();
                Console.Write("\n\t\t\t\t\t\t  ");
                Console.ResetColor();
                string answer = Console.ReadLine().ToUpper();
                Console.Clear();
                Console.WriteLine();

                if (answer == "CAR")
                {
                    return Vehicle.TypeOfVehicle.CAR;
                }
                else if (answer == "MC")
                {
                    return Vehicle.TypeOfVehicle.MOTORCYCLE;
                }
                else
                {
                    //---------Snyggar till utskriften till konsollen------------
                    Console.Clear();
                    Console.SetCursorPosition(28, 8);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Please try again, you have entered an invalid answer.");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
        }   // METOD SOM FRÅGAR OCH HÄMTAR INFO OM VILKEN FORDONSTYP FORDONET HAR.

        private void RetreiveAndPrintSearch(int askedIndexPosition)
        {
            if (parkingPlaces[askedIndexPosition].VehicleType == Vehicle.TypeOfVehicle.EMPTY) // Här kollar vi om parkeringsplatsen användaren slått in har ett fordon på sig.
                                                                                              // skrivs isåfall ut att platsen är tom.
            {
                //---------Snyggar till utskriften till konsollen------------
                Console.SetCursorPosition(34, 8);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("THERE IS NO VEHICLE ON THAT PARKINGSPOT");

                //---------Snyggar till utskriften till konsollen------------
                Console.SetCursorPosition(36, 10);
                Console.WriteLine("Press ENTER to get back to menu...");               
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                
            }


            else if (askedIndexPosition < 100) // Om platsen däremot har ett fordon på sig, och platsen är mellan 1-100 så körs följande kod.
                                               //  - Det koden ska göra är att beräkna och hämta prisinfon som det kostat att stå här än så länge.
                                               //  - Hämta den totala tiden fordonet stått på parkeringen samt när fordonet checkades in. 
                                               // Om det även skulle vara så att det står två fordon (motorcyklar) på samma plats, så ska infon om båda skrivas ut. 
            {

                int fee = PriceCalculator(parkingPlaces[askedIndexPosition]); //Deklarerar en variabel som lagrar priset, efter att ha hämtat det från metoden som beräknar.

                TimeSpan span = DateTime.Now - parkingPlaces[askedIndexPosition].ArrivedTime; //Deklarerar en variabel "totalTimeParked" genom "TimeSpan".
                                                                                              //Variabeln lagrar den totala tiden fordonet stått i parkeringshuset.


                //---------------------------------Skriver ut all info till användare------------------------------------
                //--------Regnummer, fordonstyp, parkeringsplats, incheckningstidpunkt, parkerad tid och kostnad---------
                //---------Snyggar till utskriften till konsollen------------
                Console.Clear();
                Console.SetCursorPosition(38, 6);
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("____________INFORMATION____________");
                Console.ResetColor();
                Console.SetCursorPosition(45, 8);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Licenseplate: {parkingPlaces[askedIndexPosition].RegNum}");
                Console.SetCursorPosition(42, 10);
                Console.WriteLine($"Type of vehicle: {parkingPlaces[askedIndexPosition].VehicleType.ToString().ToLower()}");
                Console.SetCursorPosition(46, 12);
                Console.WriteLine($"Parking-position: {askedIndexPosition + 1}");
                Console.SetCursorPosition(38, 14);
                Console.WriteLine($"Checked in at: {parkingPlaces[askedIndexPosition].ArrivedTime}");
                Console.SetCursorPosition(34, 16);
                Console.WriteLine($"Total time parked: {span.TotalHours:0,0} hours and {span.Minutes} minutes");
                Console.SetCursorPosition(38, 18);
                Console.WriteLine($"The fee at this moment is: {fee:C}");



                if (parkingPlaces[askedIndexPosition + 100].VehicleType == Vehicle.TypeOfVehicle.MOTORCYCLE)
                // Checkar om det en motorcykel till på samma plats. Isåfall skrivs dennas info också ut!
                {

                    fee = PriceCalculator(parkingPlaces[askedIndexPosition]); // Beräknar priset för parkerad tid.
                    span = DateTime.Now - parkingPlaces[askedIndexPosition].ArrivedTime; // Återställer tiden för att få exakta tiden parkerad.


                    //---------------------------------Skriver ut all info till användare------------------------------------
                    //--------Regnummer, fordonstyp, parkeringsplats, incheckningstidpunkt, parkerad tid och kostnad---------
                    //---------Snyggar till utskriften till konsollen------------
                    Console.SetCursorPosition(35, 20);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("___THIS MOTORCYCLE IS ALSO PARKED HERE___");
                    Console.ResetColor();
                    Console.SetCursorPosition(45, 22);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Licenseplate: {parkingPlaces[askedIndexPosition].RegNum}");
                    Console.SetCursorPosition(42, 24);
                    Console.WriteLine($"Type of vehicle: {parkingPlaces[askedIndexPosition].VehicleType.ToString().ToLower()}");
                    Console.SetCursorPosition(46, 26);
                    Console.WriteLine($"Parking-position: {askedIndexPosition + 1}");
                    Console.SetCursorPosition(38, 28);
                    Console.WriteLine($"Checked in at: {parkingPlaces[askedIndexPosition].ArrivedTime}");
                    Console.SetCursorPosition(34, 30);
                    Console.WriteLine($"Total time parked: {span.TotalHours:0,0} hours and {span.Minutes} minutes");
                    Console.SetCursorPosition(38, 32);
                    Console.WriteLine($"The fee at this moment is: {fee:C}");
                }
            }
            Console.ReadLine();
        }   // METOD SOM SKRIVER UT ALL INFO OM EN SPECIFIK PARKERINGSPLATS.

        private void EraseAllData()
        {
            Console.Clear();
            string erase = ".....";
            string create = ".....";
            string fileName = "ParkingData.txt";
            try
            {
                if (File.Exists(fileName)) //Checkar om filen existerar, isåfall raderas filen och skapar en ny längre ner i if-satsen.
                {
                    //---------Snyggar till utskriften till konsollen------------
                    Console.SetCursorPosition(40, 8);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine($"The file: {fileName}, was found!");

                    Console.SetCursorPosition(43, 10);
                    Console.WriteLine("Press ENTER to start erasing...");
                    Console.ReadLine();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Clear();

                    File.Delete(fileName); // Här raderar vi den befintliga filen.

                    //---------Snyggar till utskriften till konsollen------------
                    Console.SetCursorPosition(50, 10);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("ERASING ALL DATA");

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("\t\t\t\t\t\t       ");

                    for (int i = 0; i < erase.Length; i++) // Använder en for-loop för att skriva ut punkter med tidsmellanrum, endast för snygg och relevant utskrift.
                    {
                        Console.Write(erase[i]);
                        Thread.Sleep(800);
                    }

                    //---------Snyggar till utskriften till konsollen------------
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Clear();
                    Console.SetCursorPosition(35, 8);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"The file: {fileName} was successfully erased.");
                    Console.SetCursorPosition(37, 10);
                    Console.WriteLine("Press ENTER to replace it with a new file...");
                    Console.ReadLine();

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Clear();
                }

                using (FileStream newFile = File.Create(fileName)) // Här skapar vi en ny tom fil som tar den raderades plats.
                {
                    //---------Snyggar till utskriften till konsollen------------
                    Console.SetCursorPosition(46, 10);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("CREATING NEW (EMPTY) FILE");

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("\t\t\t\t\t\t        ");

                    for (int i = 0; i < create.Length; i++)
                    {
                        Console.Write(create[i]);
                        Thread.Sleep(800);
                    }

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Clear();

                    //---------Snyggar till utskriften till konsollen------------
                    Console.SetCursorPosition(37, 8);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("SUCCESS! The new (EMPTY) file has been created!");

                    Console.SetCursorPosition(41, 10);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Press ENTER to get back to the menu...");
                    Console.ReadLine();

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }

                for (int i = 0; i < parkingPlaces.Length; i++) //Går igenom alla element (parkeringsplatser) och "fyller" dem med "EMPTY". 
                {
                    parkingPlaces[i] = new Vehicle(Vehicle.TypeOfVehicle.EMPTY, "EMPTY", DateTime.MinValue);
                }

                ReadAndWrite rw = new ReadAndWrite(); //Skapar en instans av classen "ReadAndWrite" för att kunna nå kodblocket som implementerar info till filen.
                rw.WriteDataToFile(parkingPlaces); //Med hjälp av denna kod så skriver vi sedan in informationen i filen.

            }
            catch (Exception e) // här ligger en catch som tar emot eventuellt fel som uppstår, exempelvis om filen inte hittas.
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Something went wrong! The system was unable to erase any data.");
            }
        } // METOD SOM RADERAR FILEN OCH ERSÄTTER DEN MED EN TOM. (ANVÄNDARVAL). 

        private void AddExampleVehicles()
        {
            ReadAndWrite write = new ReadAndWrite(); // skapar en instans av klassen ReadAndWrite som sköter filhanteringen. Detta görs för att senare kunna lagra fordonen i filen.

            parkingPlaces[2] = new Vehicle(Vehicle.TypeOfVehicle.CAR, "CAR111", DateTime.Now);//------------------------------------------
            parkingPlaces[5] = new Vehicle(Vehicle.TypeOfVehicle.CAR, "CAR222", DateTime.Now);//-------------------------------------------
            parkingPlaces[9] = new Vehicle(Vehicle.TypeOfVehicle.CAR, "CAR333", DateTime.Now);//------------Lägger till bilar--------------
            parkingPlaces[24] = new Vehicle(Vehicle.TypeOfVehicle.CAR, "CAR444", DateTime.Now);//------------------------------------------
            parkingPlaces[53] = new Vehicle(Vehicle.TypeOfVehicle.CAR, "CAR555", DateTime.Now);//------------------------------------------

            parkingPlaces[4] = new Vehicle(Vehicle.TypeOfVehicle.MOTORCYCLE, "MTC111", DateTime.Now);//------------------------------------------
            parkingPlaces[7] = new Vehicle(Vehicle.TypeOfVehicle.MOTORCYCLE, "MTC222", DateTime.Now);//------------------------------------------
            parkingPlaces[15] = new Vehicle(Vehicle.TypeOfVehicle.MOTORCYCLE, "MTC333", DateTime.Now);//-------Lägger till motorcycklar----------
            parkingPlaces[47] = new Vehicle(Vehicle.TypeOfVehicle.MOTORCYCLE, "MTC444", DateTime.Now);//------------------------------------------
            parkingPlaces[81] = new Vehicle(Vehicle.TypeOfVehicle.MOTORCYCLE, "MTC555", DateTime.Now);//------------------------------------------

            write.WriteDataToFile(parkingPlaces); // Skickar in infon om fordonen ovan till metoden som skriver in infon i filen. 


            //---------Snyggar till utskriften till konsollen------------
            Console.Clear();
            Console.SetCursorPosition(40, 7);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("ADD EXAMPLE VEHICLES HERE");
            Console.SetCursorPosition(46, 9);
            Console.WriteLine(" PRESS ENTER ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\t\t\t\t\t\t    ");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;


            string add = "..........";

            //---------Snyggar till utskriften till konsollen------------
            Console.SetCursorPosition(45, 13);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("ADDING VEHICLES\n\t\t\t\t\t\t");

            for (int i = 0; i < add.Length; i++)
            {
                Console.Write(add[i]);
                Thread.Sleep(400);
            }

            //---------Snyggar till utskriften till konsollen------------
            Console.SetCursorPosition(38, 17);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("VEHICLES SUCCESSFULLY ADDED!");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();

        } // METOD SOM LÄGGER TILL 5 ST FÖRBESTÄMDA BILAR SAMT MOTORCYKLAR (ANVÄNDARVAL). 
    }
}