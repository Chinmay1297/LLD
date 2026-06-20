using ParkingLotDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotDesign.Classes.ParkingSlots
{
    internal class MediumSlot : IParkingSlot
    {
        private readonly Guid SlotNo = Guid.Empty;
        IVehicle? vehicle = null;

        public MediumSlot()
        {
            SlotNo = Guid.NewGuid();
        }
        public Guid GetParkingSlotNo()
        {
            return SlotNo;
        }

        public EVehicleSize GetParkingSlotSize()
        {
            return vehicle.GetVehicleSize();
        }

        public bool IsAvailable()
        {
            return vehicle != null ? true : false;
        }

        public IParkingSlot ParkVehicle(IVehicle vehicleToPark)
        {
            vehicle = vehicleToPark;        //Assign the vehicle to the slot object
            return this;
        }

        public void UnParkVehicle()
        {
            vehicle = null;
        }
    }
}
