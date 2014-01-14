using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    public class Car : Vehicle
    {
        public int Year { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string VehicleIdentificationNumber { get; set; }

        public FuelType FuelType { get; set; }

        public EngineState EngineState { get; set; }

        public RadioState RadioState { get; set; }

        public override void StartVehicle(Car car)
        {
            if (car.FuelType == FuelType.Diesel)
            {
                this.WarmGlowplugs();
            }

            base.StartVehicle(car);
        }

        public override void StopVehicle(Car car)
        {
            switch (car.RadioState)
            {
                case RadioState.AM:
                case RadioState.FM:
                case RadioState.XM:
                    {
                        car.RadioState = RadioState.Off;
                        break;
                    }
                case RadioState.CD:
                    {
                        car.RadioState = RadioState.Bluetooth;
                        break;
                    }
                case RadioState.Bluetooth:
                    {
                        car.RadioState = RadioState.Auxilary;
                        break;
                    }
                case RadioState.Off:
                    {
                        car.RadioState = RadioState.XM;
                        break;
                    }
                case RadioState.Auxilary:
                    {
                        car.RadioState = RadioState.AM;
                        break;
                    } 
            }

            if (car.FuelType == FuelType.JetFuel)
            {
                this.CoolJets();
            }
            
            base.StopVehicle(car);
        }

        protected void WarmGlowplugs()
        {
            // simulate time for warming glowplugs
            System.Threading.Thread.Sleep(1000);
        }

        protected void CoolJets()
        {
            // simulate time for cooling jets
            System.Threading.Thread.Sleep(800);
        }

        protected void SetRadioState(Car car)
        {
            switch (car.RadioState)
            {
                case RadioState.AM:
                case RadioState.FM:
                case RadioState.XM:
                    {
                        car.RadioState = RadioState.Off;
                        break;
                    }
                case RadioState.CD:
                    {
                        car.RadioState = RadioState.Bluetooth;
                        break;
                    }
                case RadioState.Bluetooth:
                    {
                        car.RadioState = RadioState.Auxilary;
                        break;
                    }
                case RadioState.Off:
                    {
                        car.RadioState = RadioState.XM;
                        break;
                    }
                case RadioState.Auxilary:
                    {
                        car.RadioState = RadioState.AM;
                        break;
                    }
            }
        }
    }
}
