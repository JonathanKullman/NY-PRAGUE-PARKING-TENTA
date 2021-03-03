using System;
using System.Collections.Generic;
using System.Text;

namespace NY_PRAGUE_PARKING_TENTA
{
    class Vehicle // Classen innehåller all information om bilarna. Använder en constructor och properties för att sätta och hämta värden. har även fält som referarar till dessa.
    {
        private readonly string regNum;
        private DateTime arrivedTime;
        private TypeOfVehicle vehicleType;
       
        public enum TypeOfVehicle   // Enum som gör det väldigt lätt och smidigt för all kod att sätta typen av fordon på de olika parkeringsplatserna överallt i koden.
        {
            CAR, MOTORCYCLE, EMPTY
        }

        public Vehicle(TypeOfVehicle type, string regNum, DateTime arrival) // Constrctorn.
        {
            this.vehicleType = type;
            this.regNum = regNum;
            this.arrivedTime = arrival;
        }

        public string RegNum // Read-only propertie som hämtar regnummer.
        {
            get
            {
                return regNum;
            }
        }
        public DateTime ArrivedTime // Read-only propertie som hämtar ankommen tid.
        {
            get
            {
                return arrivedTime;
            }
        }
        public TypeOfVehicle VehicleType // Read-only propertie som hämtar fordonstyp.
        {
            get
            {
                return vehicleType;
            }
        }

        public override string ToString()
        {
            return arrivedTime.ToString() + "&" + vehicleType + "&" + regNum;
        }
    }
}
