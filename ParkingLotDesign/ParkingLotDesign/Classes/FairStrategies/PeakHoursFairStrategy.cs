using ParkingLotDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotDesign.Classes.FairStrategies
{
    internal class PeakHoursFairStrategy : IFairStrategy
    {
        public decimal CalculateParkingCharges(decimal inputFair, Ticket ticket)
        {
            if(isPeakHours(ticket))
            {
                decimal price = inputFair + ticket.CalculateParkingDuration() * Constants.PEAK_HOURS_ADDITIONAL_RATE;
                return price;
            }

            return inputFair;
        }

        bool isPeakHours(Ticket ticket)
        {
            return ticket.EntryTime.Hour >= 7 && ticket.EntryTime.Hour <= 9;
        }
    }
}
