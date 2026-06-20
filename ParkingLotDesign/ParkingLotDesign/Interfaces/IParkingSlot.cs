using ParkingLotDesign.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotDesign.Interfaces
{
    internal interface IParkingSlot
    {
        EVehicleSize GetParkingSlotSize();
        Guid GetParkingSlotNo();
        bool IsAvailable();
        IParkingSlot ParkVehicle(IVehicle vehicle);
        void UnParkVehicle();
    }
}
