using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotDesign.Interfaces
{
    internal interface IVehicle
    {
        EVehicleSize GetVehicleSize();
        string GetVehicleLicense();
    }
}
