using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleLibrary;

namespace SampleLibraryTests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void StartVehicle_NonDieselCar_ShouldStartVehicle()  // Positive test
        {
            // Arrange
            var car = new Car
                          {
                              FuelType = FuelType.Hybrid,
                              EngineState = EngineState.Stopped,
                              MessageLog = new List<string>()
                          };

            // Act
            car.StartVehicle(car);

            // Assert
            car.EngineState.Should().Be(EngineState.Started);
            car.MessageLog.Count.Should().Be(1);
        }

        [TestMethod]
        public void StartVehicle_DieselCar_ShouldStartVehicleAndWarmGlowPlugs()  // Test override fuel type logic
        {
            // Arrange
            var car = new Car
            {
                FuelType = FuelType.Diesel,
                EngineState = EngineState.Stopped,
                MessageLog = new List<string>(),
                Make = "BMW"
            };

            // Act
            car.StartVehicle(car);

            // Assert
            car.EngineState.Should().Be(EngineState.Started);
            car.MessageLog.Count.Should().Be(2);
            car.MessageLog.Should().Contain(m => m == "Warming glow-plugs.");
        }

        [TestMethod]
        public void StopVehicle_WithStartedEngine_ShouldStopVehicle()  // Positive test
        {
            // Arrange
            var car = new Car
                          {
                              EngineState = EngineState.Started,
                              FuelType = FuelType.Electirc,
                              RadioState = RadioState.Off,
                              MessageLog = new List<string>()
                          };

            // Act
            car.StopVehicle(car);

            // Assert
            car.EngineState.Should().Be(EngineState.Stopped);
        }

        [TestMethod]
        public void StopVehicle_UsingJetFuel_ShouldRunEngineCoolingProcess()  // Test override fult type logic
        {
            // Arrange
            var car = new Car
            {
                EngineState = EngineState.Started,
                FuelType = FuelType.JetFuel,
                RadioState = RadioState.Off,
                MessageLog = new List<string>()
            };

            // Act
            car.StopVehicle(car);

            // Assert
            car.EngineState.Should().Be(EngineState.Stopped);
            car.MessageLog.Should().Contain("Cooling engine.");
        }

        [TestMethod]
        public void StopVehicle_WithRadioSateFM_ShouldSetRadioStateToOff()  // Test override radio logic
        {
            // Arrange
            var car = new Car
            {
                EngineState = EngineState.Started,
                FuelType = FuelType.Hybrid,
                RadioState = RadioState.FM,
                MessageLog = new List<string>()
            };

            // Act
            car.StopVehicle(car);

            // Assert
            car.EngineState.Should().Be(EngineState.Stopped);
            car.RadioState.Should().Be(RadioState.Off);
        }
    }
}
