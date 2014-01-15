using System;
using System.Collections.Generic;

namespace SampleLibrary
{
    public class Car : Vehicle
    {
        public override void StartVehicle(IVehicle car)
        {
            if (car.FuelType == FuelType.Diesel)
            {
                base.WarmGlowplugs(car);
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


        //// reduce complexity
        //private void SetCarRadioState(IVehicle car)
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
