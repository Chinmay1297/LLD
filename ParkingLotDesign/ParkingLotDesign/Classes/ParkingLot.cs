using ParkingLotDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotDesign.Classes
{
    internal class ParkingLot
    {
        ParkingManager pm;
        FairCalculator fc;

        public ParkingLot()
        {
            pm = new ParkingManager();
            fc = new FairCalculator();
        }

        public Ticket? EnterVehicle(IVehicle vehicle)
        {
            IParkingSlot? availableSlot = pm.CheckAvailableSlot(vehicle.GetVehicleSize());
            if(availableSlot != null)
            {
                availableSlot = pm.AssignSlot(vehicle, availableSlot);
                return new Ticket(availableSlot, vehicle);
            }

            return null;
        }

        public decimal LeaveVehicle(Ticket ticket)
        {
            if(ticket!=null)
            {
                ticket.ExitTime = DateTime.Now;
                pm.ReleaseSlot(ticket.ParkingSlot);
                decimal parkedTime = ticket.CalculateParkingDuration();
                return fc.CalculateFair(ticket);
            }

            return 0m;
        }
    }
}
