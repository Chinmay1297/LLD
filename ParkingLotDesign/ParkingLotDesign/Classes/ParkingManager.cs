using ParkingLotDesign.Interfaces;
using ParkingLotDesign.Classes.ParkingSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotDesign.Classes
{
    internal class ParkingManager
    {
        Dictionary<EVehicleSize, List<IParkingSlot>> ParkingSlots = new();
        public ParkingManager()
        {
            InitializeParkingSlots();
        }

        private void InitializeParkingSlots()
        {
            // Create Small slots (RegularSlot)
            ParkingSlots[EVehicleSize.Small] = new List<IParkingSlot>();
            for (int i = 0; i < Constants.NO_OF_SMALL_SLOTS; i++)
            {
                ParkingSlots[EVehicleSize.Small].Add(new RegularSlot());
            }

            // Create Medium slots (MediumSlot)
            ParkingSlots[EVehicleSize.Medium] = new List<IParkingSlot>();
            for (int i = 0; i < Constants.NO_OF_MEDIUM_SLOTS; i++)
            {
                ParkingSlots[EVehicleSize.Medium].Add(new MediumSlot());
            }

            // Create Large slots (LargeSlot)
            ParkingSlots[EVehicleSize.Large] = new List<IParkingSlot>();
            for (int i = 0; i < Constants.NO_OF_LARGE_SLOTS; i++)
            {
                ParkingSlots[EVehicleSize.Large].Add(new LargeSlot());
            }
        }
        public IParkingSlot CheckAvailableSlot()
        {
            foreach(IParkingSlot slot in ParkingSlots[EVehicleSize.Small])
            {
                if(slot.IsAvailable())
                {
                    return slot;
                }
            }

            foreach (IParkingSlot slot in ParkingSlots[EVehicleSize.Medium])
            {
                if (slot.IsAvailable())
                {
                    return slot;
                }
            }

            foreach (IParkingSlot slot in ParkingSlots[EVehicleSize.Large])
            {
                if (slot.IsAvailable())
                {
                    return slot;
                }
            }

            Console.WriteLine("Parking Space is full, please come after some time");
            throw new Exception("Parking Space is full, please come after some time");
        }

        public IParkingSlot AssignSlot(IVehicle vehicle, IParkingSlot parkingSlot)
        {
            return parkingSlot.ParkVehicle(vehicle);
        }

        public void ReleaseSlot(IParkingSlot parkingSlotToBeReleased)
        {
            parkingSlotToBeReleased.UnParkVehicle();
        }
    }
}
