using ParkingLotDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotDesign.Classes
{
    internal class Ticket
    {
        public Guid TicketId;
        public IParkingSlot ParkingSlot;
        public IVehicle Vehicle;
        public DateTime EntryTime;
        public DateTime ExitTime;
        public Ticket(IParkingSlot parkingSlot, IVehicle vehicle)
        {
            TicketId = Guid.NewGuid();
            ParkingSlot = parkingSlot;
            Vehicle = vehicle;
            EntryTime = DateTime.Now;
        }
        public decimal CalculateParkingDuration()
        {
            return (decimal)(ExitTime - EntryTime).TotalHours;
        }

    }
}
