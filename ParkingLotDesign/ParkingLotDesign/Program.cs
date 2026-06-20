using ParkingLotDesign.Classes;
using ParkingLotDesign.Classes.Vehicles;
using ParkingLotDesign.Interfaces;

namespace ParkingLotDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = new ParkingLot();
            Dictionary<string, Ticket> vehicles = new();
            Dictionary<EVehicleSize, int> countOfVehiclesPerType = new() { { EVehicleSize.Small ,0}, { EVehicleSize.Medium, 0 }, { EVehicleSize.Large, 0 } };
            Console.WriteLine($"Welcome to the Parking Lot (Total no of Slots: {Constants.NO_OF_SMALL_SLOTS + Constants.NO_OF_MEDIUM_SLOTS + Constants.NO_OF_LARGE_SLOTS})");
            while(true)
            {
                //Console.Clear();
                
                Console.WriteLine($"{EVehicleSize.Small.ToString()} - {countOfVehiclesPerType[EVehicleSize.Small]}");
                Console.WriteLine($"{EVehicleSize.Medium.ToString()} - {countOfVehiclesPerType[EVehicleSize.Medium]}");
                Console.WriteLine($"{EVehicleSize.Large.ToString()} - {countOfVehiclesPerType[EVehicleSize.Large]}");
                Console.WriteLine("\nSelect 1 to Enter a Vehicle, 2 to Exit a Vehicle: ");
                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        EnterVehicle(parkingLot, vehicles, countOfVehiclesPerType);
                        break;
                    case "2":
                        ExitVehicle(parkingLot, vehicles, countOfVehiclesPerType);
                        break;
                    default:
                        Console.WriteLine("Wrong selection, please enter 1 or 2");
                        break;
                }
            }
        }

        static  void EnterVehicle(ParkingLot parkingLot, Dictionary<string, Ticket> vehicles, Dictionary<EVehicleSize, int> countOfVehiclesPerType)
        {
            Console.WriteLine("Select type of Vehicle (1-Small, 2-Medium, 3-Large)");
            string? vehicleType = Console.ReadLine();
            string licenseNo;
            Ticket? ticket = null;
            IVehicle? vehicle = null;
            switch (vehicleType)
            {
                case "1":
                    Console.WriteLine("Enter license plate number: ");
                    licenseNo = Console.ReadLine();
                    vehicle = new Bike(licenseNo);
                    if (vehicles.ContainsKey(licenseNo))
                    {
                        Console.WriteLine("Vehicle already exists");
                        break;
                    }
                    ticket = parkingLot.EnterVehicle(vehicle);
                    if(ticket == null)
                    {
                        Console.WriteLine("Cannot add the vehicle right now");
                        break;
                    }
                    vehicles[licenseNo] = ticket;
                    countOfVehiclesPerType[ticket.ParkingSlot.GetParkingSlotSize()]++;
                    break;
                case "2":
                    Console.WriteLine("Enter license plate number: ");
                    licenseNo = Console.ReadLine();
                    if (vehicles.ContainsKey(licenseNo))
                    {
                        Console.WriteLine("Vehicle already exists");
                        break;
                    }
                    vehicle = new Car(licenseNo);
                    ticket = parkingLot.EnterVehicle(vehicle);
                    if (ticket == null)
                    {
                        Console.WriteLine("Cannot add the vehicle right now");
                        break;
                    }
                    vehicles[licenseNo] = ticket;
                    countOfVehiclesPerType[ticket.ParkingSlot.GetParkingSlotSize()]++;
                    break;
                case "3":
                    Console.WriteLine("Enter license plate number: ");
                    licenseNo = Console.ReadLine();
                    if(vehicles.ContainsKey(licenseNo))
                    {
                        Console.WriteLine("Vehicle already exists");
                        break;
                    }
                    vehicle = new Bus(licenseNo);
                    ticket = parkingLot.EnterVehicle(vehicle);
                    if (ticket == null)
                    {
                        Console.WriteLine("Cannot add the vehicle right now");
                        break;
                    }
                    vehicles[licenseNo] = ticket;
                    countOfVehiclesPerType[ticket.ParkingSlot.GetParkingSlotSize()]++;
                    break;
                default:
                    Console.WriteLine("Invalid vehicle type selected -> Please select either of these (1,2,3)");
                    break;
            }
            if (ticket != null)
            {
                Console.WriteLine($"Vehicle with License No {vehicle.GetVehicleLicense()} entered into Slot {ticket.ParkingSlot.GetParkingSlotNo()} ({ticket.ParkingSlot.GetParkingSlotSize().ToString()}) at Time {ticket.EntryTime} \n");
            }
        }

        static void ExitVehicle(ParkingLot parkingLot, Dictionary<string, Ticket> vehicles, Dictionary<EVehicleSize, int> countOfVehiclesPerType)
        {
            Console.WriteLine("Please enter vehicle's license plate number");
            string licenseNo = Console.ReadLine();
            Ticket ticket = null;
            if (vehicles.TryGetValue(licenseNo, out ticket))
            {
                countOfVehiclesPerType[ticket.Vehicle.GetVehicleSize()]--;
                Console.WriteLine($"Vehicle with License No {ticket.Vehicle.GetVehicleLicense()} with Slot {ticket.ParkingSlot.GetParkingSlotNo()} ({ticket.ParkingSlot.GetParkingSlotSize().ToString()}) entered to the Lot at Time {ticket.EntryTime} and exited the Lot at Time {DateTime.Now} \n");
                vehicles.Remove(licenseNo);
                decimal fair = parkingLot.LeaveVehicle(ticket);
                Console.WriteLine($"Please pay Rupees {fair}");
            }
            else
            {
                Console.WriteLine($"Cannot find a vehicle with license no: {licenseNo}");
            }

        }

    }
}
