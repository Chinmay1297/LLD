using ParkingLotDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotDesign.Classes.FairStrategies
{
    internal class RegularFairStrategy : IFairStrategy
    {
        public decimal CalculateParkingCharges(decimal inputFair, Ticket ticket)
        {
            decimal parkingDuration = ticket.CalculateParkingDuration();
            var price = parkingDuration * Constants.REGULAR_PRICING_MULTIPLIER;
            return price;
        }
    }
}
