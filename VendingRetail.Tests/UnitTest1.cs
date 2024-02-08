using NUnit.Framework;
using System.Xml.Linq;

namespace VendingRetail.Tests
{
    public class Tests
    {
        
        [Test]
        public void ConstructorWork()
        {
            CoffeeMat coffeeMat = new CoffeeMat(100,20);

            Assert.IsNotNull(coffeeMat);

            Assert.AreEqual(100,coffeeMat.WaterCapacity);
            Assert.AreEqual(20, coffeeMat.ButtonsCount);
            Assert.AreEqual(0, coffeeMat.Income);

        }

        [Test]
        public void FillWaterTankWork()
        {
            CoffeeMat coffeeMat = new CoffeeMat(100, 20);

            string result = coffeeMat.FillWaterTank();

            string expected = $"Water tank is filled with 100ml";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FillWaterTankWork2()
        {
            CoffeeMat coffeeMat = new CoffeeMat(100, 20);

            coffeeMat.FillWaterTank();

            string result = coffeeMat.FillWaterTank();

            string expected = $"Water tank is already full!";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AddDrinkWork()
        {
            CoffeeMat coffeeMat = new CoffeeMat(100, 20);

            bool result = coffeeMat.AddDrink("az", 10);

            Assert.IsTrue(result);      
        }

        [Test]
        public void AddDrinkWork2()
        {
            CoffeeMat coffeeMat = new CoffeeMat(100, 1);
            coffeeMat.AddDrink("Toi", 10);

            bool result = coffeeMat.AddDrink("az", 10);

            Assert.IsFalse(result);
        }

        [Test]
        public void AddDrinkWork3()
        {
            CoffeeMat coffeeMat = new CoffeeMat(100,20);
            coffeeMat.AddDrink("az", 10);

            bool result = coffeeMat.AddDrink("az", 10);

            Assert.IsFalse(result);
        }


        [Test]
        public void BuyDrinkWork()
        {
            CoffeeMat coffeeMat = new CoffeeMat(100, 20);
            coffeeMat.AddDrink("az", 10);
            coffeeMat.FillWaterTank();

            string result = coffeeMat.BuyDrink("az");

            string expected = $"Your bill is 10.00$";
            
            Assert.AreEqual(expected, result);
            Assert.AreEqual(10, coffeeMat.Income);

            string filled = coffeeMat.FillWaterTank();
            string expected2 = $"Water tank is filled with 80ml";
            Assert.AreEqual (expected2, filled);
        }

        [Test]
        public void BuyDrinkWork2()
        {
            CoffeeMat coffeeMat = new CoffeeMat(100, 20);
            coffeeMat.AddDrink("az", 10);
            
            string result = coffeeMat.BuyDrink("az");

            string expected = $"CoffeeMat is out of water!";

            Assert.AreEqual(expected, result);

        }

        [Test]
        public void BuyDrinkWork3()
        {
            CoffeeMat coffeeMat = new CoffeeMat(100, 20);
            coffeeMat.AddDrink("az", 10);
            coffeeMat.FillWaterTank();


            string result = coffeeMat.BuyDrink("toi");

            string expected = $"toi is not available!";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CollectIncome()
        {
            CoffeeMat coffeeMat = new CoffeeMat(100, 20);
            coffeeMat.AddDrink("az", 10);
            coffeeMat.FillWaterTank();
            coffeeMat.BuyDrink("az");


            double result = coffeeMat.CollectIncome();

            Assert.AreEqual(10, result);
            Assert.AreEqual(0,coffeeMat.Income);       
        }
    }
}