using System;
using NUnit.Framework;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void ValidateConstructorOfCar()
            {
                Car car = new Car("Audi", 2);
                Assert.AreEqual("Audi", car.CarModel);
                Assert.AreEqual(2, car.NumberOfIssues);
                Assert.IsFalse(car.IsFixed);
            }
            [Test]
            public void ValidateConstructor()
            {
                Garage garage = new Garage("MyGarage", 2);
                Assert.AreEqual("MyGarage", garage.Name);
            }

            [Test]
            public void ValidateGarageMechanicAvailable()
            {
                Garage garage = new Garage("MyGarage", 2);
                Assert.AreEqual(2, garage.MechanicsAvailable);
                
            }

            [Test]
            public void ValidateNameProperty_ThrowsExceptionWithNullValue()
            {
                Assert.Throws<ArgumentNullException>(() => new Garage(null, 2), "Invalid garage name.");
            }

            [Test]
            public void ValidateNameProperty_ThrowsExceptionWithEmpty()
            {
                Assert.Throws<ArgumentNullException>(() => new Garage("", 2), "Invalid garage name.");
            }

            [Test]
            public void ValidateMechanicsProperty_ThrowExceptionWithZero()
            {
                Assert.Throws<ArgumentException>(() => new Garage("MyGarage", 0),
                    "At least one mechanic must work in the garage.");
            }

            [Test]
            public void ValidateMechanicsProperty_ThrowExceptionWithNegativeValue()
            {
                Assert.Throws<ArgumentException>(() => new Garage("MyGarage", -1),
                    "At least one mechanic must work in the garage.");
            }

            [Test]
            public void ValidateAddCarMethod_AddCorrectlyCarToTheCollection()
            {
                Car car = new Car("Audi", 2);
                Garage garage = new Garage("MyGarage", 2);
                garage.AddCar(car);
                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void ValidateAddCarMethod_ThrowExceptionWithNotEnoughCapacity()
            {
                Car car = new Car("Audi", 1);
                Car car1 = new Car("VW", 1);
                Garage garage = new Garage("MyGarage", 1);
                garage.AddCar(car);
                Assert.Throws<InvalidOperationException>(() => garage.AddCar(car1), "No mechanic available.");
            }

            [Test]
            public void ValidateFixMethod_FixCorrectlyCar()
            {
                Car car = new Car("Audi", 1);
                Garage garage = new Garage("MyGarage", 1);
                garage.AddCar(car);
                var fixedCar = garage.FixCar("Audi");
                Assert.IsTrue(car.IsFixed);
                Assert.AreSame(car, fixedCar);
            }

            [Test]
            public void ValidateFixMethod_ThrowExceptionWithInvalidCar()
            {
                Garage garage = new Garage("MyGarage", 2);
                Assert.Throws<InvalidOperationException>(() => garage.FixCar("Audi"), "The car Audi doesn't exist.");
            }

            [Test]
            public void ValidateRemoveMethod_RemoveCorrectlyFixedCars()
            {
                Car car = new Car("Audi", 2);
                Car car1 = new Car("VW", 2);
                Garage garage = new Garage("MyGarage", 2);
                garage.AddCar(car);
                garage.AddCar(car1);
                garage.FixCar("Audi");
                garage.RemoveFixedCar();
                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void ValidateRemoveMethod_ThrowExceptionWithNoCarsToRemove()
            {
                Car car = new Car("Audi", 2);
                Car car1 = new Car("VW", 2);
                Garage garage = new Garage("MyGarage", 2);
                garage.AddCar(car);
                garage.AddCar(car1);
                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar(), "No fixed cars available.");
            }

            [Test]
            public void ValidateReport_ReturnCorrectlyInfo()
            {
                Car car = new Car("Audi", 2);
                Car car1 = new Car("VW", 2);
                Garage garage = new Garage("MyGarage", 2);
                garage.AddCar(car);
                garage.AddCar(car1);
                var report = garage.Report();
                Assert.AreEqual("There are 2 which are not fixed: Audi, VW.", report);
            }
        }
    }
}