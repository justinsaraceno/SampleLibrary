using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    public interface IVehicle
    {
        int Year { get; set; }

        string Make { get; set; }

        string Model { get; set; }

        string VehicleIdentificationNumber { get; set; }

        FuelType FuelType { get; set; }

        EngineState EngineState { get; set; }

        RadioState RadioState { get; set; }

        void StartVehicle(Car car);

        void StopVehicle(Car car);
    }
}
