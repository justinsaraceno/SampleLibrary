using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleLibrary;

namespace SampleLibraryTests
{
    [TestClass]
    public class VehicleTests
    {
        [TestMethod]
        public void StartVehicle_StoppedVehicle_ShouldChangeEngineStateToStarted() // Positive test
        {
            // Arrange
            var vehicle = new Vehicle
                              {
                                  EngineState = EngineState.Stopped,
                                  MessageLog = new List<string>()
                              };

            // Act
            vehicle.StartVehicle(vehicle);

            // Assert
            vehicle.EngineState.Should().Be(EngineState.Started);
            vehicle.MessageLog.Count.Should().BeGreaterOrEqualTo(1);
            vehicle.MessageLog.Should().Contain(m => m == "Started the vehicle.");
        }

        [TestMethod]
        public void StartVehicle_StartedVehicle_ShouldNotChangeEngineState() // Negative test
        {
            // Arrange
            var vehicle = new Vehicle
            {
                EngineState = EngineState.Started,
                MessageLog = new List<string>()
            };

            // Act
            vehicle.StartVehicle(vehicle);

            // Assert
            vehicle.EngineState.Should().Be(EngineState.Started);
            vehicle.MessageLog.Count.Should().Be(0);
        }

        [TestMethod]
        public void StopVehicle_StartedVehicle_ShouldChangeEngineStateToStopped()  // Positive test
        {
            // Arrange
            var vehicle = new Vehicle
            {
                EngineState = EngineState.Started,
                MessageLog = new List<string>()
            };

            // Act
            vehicle.StopVehicle(vehicle);

            // Assert
            vehicle.EngineState.Should().Be(EngineState.Stopped);
            vehicle.MessageLog.Count.Should().BeGreaterOrEqualTo(1);
            vehicle.MessageLog.Should().Contain(m => m == "Stopped the vehicle.");
        }

        [TestMethod]
        public void StopVehicle_StoppedVehicle_ShouldNotChangeEngineState()  // Negative test
        {
            // Arrange
            var vehicle = new Vehicle
            {
                EngineState = EngineState.Stopped,
                MessageLog = new List<string>()
            };

            // Act
            vehicle.StopVehicle(vehicle);

            // Assert
            vehicle.EngineState.Should().Be(EngineState.Stopped);
            vehicle.MessageLog.Count.Should().BeGreaterOrEqualTo(0);
        }

        //[TestMethod]
        //public void WarmGlowplugs_DieselVehicle_ShouldAddMessageLogString()  // Positive test of internal method
        //{
        //    // Arrange
        //    var vehicle = new Vehicle { FuelType = FuelType.Diesel, MessageLog = new List<string>() };

        //    // Act
        //    vehicle.WarmGlowplugs(vehicle);

        //    // Assert
        //    vehicle.MessageLog.Count.Should().Be(1);
        //    vehicle.MessageLog.Should().Contain(m => m == "Warming glow-plugs.");
        //}

        //[TestMethod]
        //public void WarmGlowplugs_NonDieselVehicle_ShouldThrowNotSupportedException()  // Asserting exception
        //{
        //    // Arrange
        //    var vehicle = new Vehicle { FuelType = FuelType.CompressedNaturalGas, MessageLog = new List<string>() };

        //    // Act
        //    Action act = () => vehicle.WarmGlowplugs(vehicle);

        //    // Assert
        //    act.ShouldThrow<NotSupportedException>("Can not warm glow-plugs unless the vehicle has a diesel engine.");
        //    vehicle.MessageLog.Count.Should().Be(0);

        //}

        //[TestMethod]
        //public void RunEngineCoolingProcess_Vehicle_ShouldAddMessageLogString()  // 
        //{
        //    // Arrange
        //    var vehicle = new Vehicle { MessageLog = new List<string>() };

        //    // Act
        //    vehicle.RunEngineCoolingProcess(vehicle);

        //    // Assert
        //    vehicle.MessageLog.Count.Should().Be(1);
        //    vehicle.MessageLog.Should().Contain(m => m == "Cooling engine.");
        //}
    }
}
