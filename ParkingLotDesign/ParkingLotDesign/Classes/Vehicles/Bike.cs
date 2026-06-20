using ParkingLotDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotDesign.Classes.Vehicles
{
    internal class Bike : IVehicle
    {
        private EVehicleSize size = EVehicleSize.Small;
        string LicensePlateNo;

        public Bike(string License)
        {
            LicensePlateNo = License;
        }
        public string GetVehicleLicense()
        {
            return LicensePlateNo;
        }

        public EVehicleSize GetVehicleSize()
        {
            return size;
        }
    }
}
