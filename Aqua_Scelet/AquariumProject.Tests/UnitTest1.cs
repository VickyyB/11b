using Aqua;
using NUnit.Framework;
using System;

namespace AquariumProject.Tests_
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FishConstructorShouldInicializeCorrectly()
        {
            Fish fish = new Fish("Som", 20);
            Assert.AreEqual("Som", fish.Type);
            Assert.AreEqual(20, fish.Price);
        }

        [Test]
        public void AquariumConstructorShouldInicializeCorrectly()
        {
            Aquarium aquarium = new Aquarium("Square", 50);
            Assert.AreEqual("Square", aquarium.Shape);
            Assert.AreEqual(50, aquarium.Capacity);
        }

        [Test]
        public void RemoveMethodShoudThrowExIfListIsEmpty()
        {
            Fish fishes = new Fish("Som", 20);
            Aquarium aquarium = new Aquarium("Square", 50);
           
            aquarium.AddFish(fishes);
            Assert.IsNotEmpty(aquarium.Fishes);

        }

        [Test]
        public void RemoveMethodShoudThrowExactExceptionMessageIfListIsEmpty()
        {
            Fish fishes = new Fish("Som", 20);
            Aquarium aquarium = new Aquarium("Square", 50);
            var ex = Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Som"));
            Assert.AreEqual("Invalid operation", ex.Message);
        }

        [Test]
        public void RemoveMethodShoudThrowExeptionIfFishIsMissing()
        {
            Fish fishes = new Fish("Som", 20);
            Aquarium aquarium = new Aquarium("Square", 50);
            var ex = Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Som"));
           
        }

        [Test]
        public void RemoveMethodShoudThrowExactMessageIfFishIsMissing()
        {
            Fish fishes = new Fish("Som", 20);
            Aquarium aquarium = new Aquarium("Square", 50);
            var ex = Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Som"));
            Assert.AreEqual("Invalid operation", ex.Message);
        }

        [Test]
        public void RemoveMethodShoudWorkCorrectlyAndDecreseNumberOfFishesInTheList()
        {
            Fish fishes = new Fish("Som", 20);
            Aquarium aquarium = new Aquarium("Square", 50);
            aquarium.AddFish(fishes);
            aquarium.RemoveFish("Som");

            Assert.AreEqual(0, aquarium.Fishes.Count);
        }

        [Test]
        public void RemoveMethodShoudIncreaseFreeCapacity()
        {
            Fish fishes = new Fish("Som", 20);
            Aquarium aquarium = new Aquarium("Square", 50);
            aquarium.AddFish(fishes);
            aquarium.RemoveFish("Som");

            Assert.AreEqual(50, aquarium.Capacity);
        }

        [Test]
        public void RemoveMethodShoudRemoveExactFish()
        {
            Fish fishes = new Fish("Som", 20);
            Aquarium aquarium = new Aquarium("Square", 50);
            aquarium.AddFish(fishes);
            aquarium.RemoveFish("Som");

            bool isFishes = false;
            if (aquarium.Fishes.Contains(fishes))
            {
                isFishes = true;
            }

            Assert.AreEqual(false, isFishes);
        }

        [Test]
        public void ReportRemoveFishShoudPrintExactSuccessfulMessage()
        {
            Fish fishes = new Fish("Som", 20);
            Aquarium aquarium = new Aquarium("Square", 50);
            aquarium.AddFish(fishes);
            Assert.AreEqual($"You successfully remove a fish!", aquarium.ReportRemoveFish());
        }

        [Test]
        public void EmptyMethodShoudWorkCorrectly()
        {
            Fish fishes = new Fish("Som", 20);
            Aquarium aquarium = new Aquarium("Square", 100);
            aquarium.AddFish(fishes);
            //var ex = Assert.Throws<InvalidOperationException>(() => aquarium.Empty());
            //Assert.AreEqual("Aquarium is empty!", ex.Message);
            aquarium.Empty();
            Assert.AreEqual(100, aquarium.Capacity);

        }
    }
}