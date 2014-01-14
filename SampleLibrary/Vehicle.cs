using System;
using System.Collections.Generic;

namespace SampleLibrary
{
    public class Vehicle : IVehicle
    {
        public int Year { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public FuelType FuelType { get; set; }

        public EngineState EngineState { get; set; }

        public RadioState RadioState { get; set; }

        public List<String> MessageLog { get; set; }

        public virtual void StartVehicle(IVehicle vehicle)
        {
            if (vehicle.EngineState == EngineState.Stopped)
            {
                vehicle.EngineState = EngineState.Started;
                vehicle.MessageLog.Add("Started the vehicle.");
            }
        }

        public virtual void StopVehicle(IVehicle vehicle)
        {
            if (vehicle.EngineState == EngineState.Started)
            {
                vehicle.EngineState = EngineState.Stopped;
                vehicle.MessageLog.Add("Stopped the vehicle.");
            }
        }

        internal void WarmGlowplugs(IVehicle vehicle)
        {
            if (vehicle.FuelType == FuelType.Diesel)
            {
                vehicle.MessageLog.Add("Warming glow-plugs.");
            }
            else
            {
                throw new NotSupportedException("Can not warm glow-plugs unless the vehicle has a diesel engine.");
            }
        }

        internal void RunEngineCoolingProcess(IVehicle vehicle)
        {
            vehicle.MessageLog.Add("Cooling engine.");
        }
    }
}
