using System;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void ValidateConstructor_CarAmount()
        {
            Car car = new Car("Audi", "A4", 5.5, 55);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void ValidateCarMakeProperty()
        {
            Car car = new Car("Audi", "A4", 5.5, 55);
            Assert.AreEqual("Audi", car.Make);
        }

        [Test]
        public void ValidateCarMakePropertyThrowExceptionWithNull()
        {
            Assert.Throws<ArgumentException>((() => new Car(null, "A4", 5.5, 55)));
        }

        [Test]
        public void ValidateCarMakePropertyThrowExceptionWithEmpty()
        {
            Assert.Throws<ArgumentException>((() => new Car("", "A4", 5.5, 55)));
        }


        [Test]
        public void ValidateCarModelProperty()
        {
            Car car = new Car("Audi", "A4", 5.5, 55);
            Assert.AreEqual("A4", car.Model);
        }

        [Test]
        public void ValidateCarModelPropertyThrowExceptionWithNull()
        {
            Assert.Throws<ArgumentException>((() => new Car("Audi", null, 5.5, 55)));
        }

        [Test]
        public void ValidateCarModelPropertyThrowExceptionWithEmpty()
        {
            Assert.Throws<ArgumentException>((() => new Car("Audi", "", 5.5, 55)));
        }

        [Test]
        public void ValidateCarFuelConsumptionProperty()
        {
            Car car = new Car("Audi", "A4", 5.5, 55);
            Assert.AreEqual(5.5, car.FuelConsumption);
        }

        [Test]
        public void ValidateCarFuelConsumptionProperty_ThrowsExceptionWithLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new Car("Audi", "A4", -1, 55));
        }

        [Test]
        public void ValidateCarFuelConsumptionProperty_EqualToZero()
        {

            Assert.Throws<ArgumentException>(() => new Car("Audi", "A4", 0, 55));
        }

        [Test]
        public void ValidateCarFuelCapacityProperty()
        {
            Car car = new Car("Audi", "A4", 5.5, 55);
            Assert.AreEqual(55, car.FuelCapacity);
        }

        [Test]
        public void ValidateCarFuelCapacityProperty_WithZero()
        {
            Assert.Throws<ArgumentException>(() => new Car("Audi", "A4", 5.5, 0));
        }

        [Test]
        public void ValidateRefuelMethod_ReturnCorrectly()
        {
            Car car = new Car("Audi", "A4", 5.5, 55);
            car.Refuel(20);
            Assert.AreEqual(20, car.FuelAmount);
        }

        [Test]
        public void ValidateRefuelMethod_ThrowExceptionWithZero()
        {
            Car car = new Car("Audi", "A4", 5.5, 55);
            Assert.Throws<ArgumentException>(() => car.Refuel(0));
        }

        [Test]
        public void ValidateRefuelMethod_ThrowExceptionWithLessThanZero()
        {
            Car car = new Car("Audi", "A4", 5.5, 55);
            Assert.Throws<ArgumentException>(() => car.Refuel(-1));
        }

        [Test]
        public void ValidateRefuelMethod_SetCorrectlyFuelAmountWithOverLoadFuel()
        {
            Car car = new Car("Audi", "A4", 5.5, 55);
            car.Refuel(56);
            Assert.AreEqual(55, car.FuelAmount);
        }

        [Test]
        public void ValidateDriveMethodDecreaseCorrectlyFuelAmount()
        {
            Car car = new Car("Audi", "A4", 5.5, 55);
            car.Refuel(55);
            car.Drive(500);
            Assert.AreEqual(27.5, car.FuelAmount);
        }

        [Test]
        public void ValidateDriveMethod_ThrowExceptionWithNotEnoughFuelAmount()
        {
            Car car = new Car("Audi", "A4", 5.5, 55);


            Assert.Throws<InvalidOperationException>(() => car.Drive(500));
        }
    }
}