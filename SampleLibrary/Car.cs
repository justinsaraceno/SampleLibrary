using System;
using System.Collections.Generic;

namespace SampleLibrary
{
    public class Car : Vehicle
    {
        public int Year { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public FuelType FuelType { get; set; }

        public EngineState EngineState { get; set; }

        public RadioState RadioState { get; set; }

        public List<String> MessageLog { get; set; }

        public override void StartVehicle(IVehicle car)
        {
            if (car.FuelType == FuelType.Diesel)
            {
                WarmGlowplugs(car);
            }

            base.StartVehicle(car);
        }

        public override void StopVehicle(IVehicle car)
        {
            switch (car.RadioState)
            {
                case RadioState.AM:
                case RadioState.FM:
                case RadioState.XM:
                case RadioState.CD:
                case RadioState.Off:
                    {
                        car.RadioState = RadioState.Off;
                        break;
                    }
                default:
                    {
                        car.RadioState = RadioState.Auxilary;
                        break;
                    }
            }

            car.MessageLog.Add("The car radio state was set.");

            if (car.FuelType == FuelType.JetFuel)
            {
                this.RunEngineCoolingProcess(car);
            }
            
            base.StopVehicle(car);
        }

        //private void SetCarRadioState(Car car)
        //{
        //    switch (car.RadioState)
        //    {
        //        case RadioState.AM:
        //        case RadioState.FM:
        //        case RadioState.XM:
        //        case RadioState.CD:
        //        case RadioState.Off:
        //            {
        //                car.RadioState = RadioState.Off;
        //                break;
        //            }
        //        default:
        //            {
        //                car.RadioState = RadioState.Auxilary;
        //                break;
        //            }
        //    }

        //    car.MessageLog.Add("The car radio state was set.");
        //}
    }
}
