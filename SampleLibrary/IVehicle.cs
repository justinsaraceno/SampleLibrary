using System;
using System.Collections.Generic;

namespace SampleLibrary
{
    public interface IVehicle
    {
        int Year { get; set; }

        string Make { get; set; }

        string Model { get; set; }

        FuelType FuelType { get; set; }

        EngineState EngineState { get; set; }

        RadioState RadioState { get; set; }

        List<String> MessageLog { get; set; } 

        void StartVehicle(IVehicle vehicle);

        void StopVehicle(IVehicle vehicle);
    }
}
