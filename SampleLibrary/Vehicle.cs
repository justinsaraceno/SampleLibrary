using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    public abstract class Vehicle : IVehicle
    {
        public int Year { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string VehicleIdentificationNumber { get; set; }

        public FuelType FuelType { get; set; }

        public EngineState EngineState { get; set; }

        public RadioState RadioState { get; set; }

        public virtual void StartVehicle(Car car)
        {
            car.EngineState = EngineState.Started;
        }

        public virtual void StopVehicle(Car car)
        {
            car.EngineState = EngineState.Stopped;
        }
    }
}
