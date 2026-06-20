using ParkingLotDesign.Classes.FairStrategies;
using ParkingLotDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotDesign.Classes
{
    internal class FairCalculator
    {
        List<IFairStrategy> FairStrategies;
        decimal price = 0m;
        public FairCalculator()
        {
            FairStrategies = new List<IFairStrategy> { new RegularFairStrategy(), new PeakHoursFairStrategy()};
        }

        public decimal CalculateFair(Ticket ticket)
        {
            foreach(IFairStrategy strategy in FairStrategies)
            {
                price = strategy.CalculateParkingCharges(price, ticket);
            }

            return price;
        }
    }
}
