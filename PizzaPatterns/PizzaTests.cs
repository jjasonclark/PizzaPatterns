using System.Diagnostics;
using Xunit;

namespace PizzaPatterns
{
    public class PizzaTests
    {
        [Fact]
        public void Can_create_normal_pizza()
        {
            var watch = new Stopwatch();
            watch.Start();
            var builder = new PizzaBuilder(new LitePizzaPartFactory());
            builder.AddCrust();
            builder.AddCrust();
            builder.AddCrust();
            builder.AddSouce();
            builder.AddCheese();
            builder.AddCheese();

            var pizza = builder.GetPizza();

            watch.Stop();
            AssertPizzaPartsAreOfType(pizza, "Lite");
            System.Diagnostics.Debug.WriteLine("Got time of {0}", watch.Elapsed);
        }

        private static void AssertPizzaPartsAreOfType(Pizza pizza, string type)
        {
            Assert.Equal(pizza.Crust.Type, type);
            Assert.Equal(pizza.Cheese.Type, type);
            Assert.Equal(pizza.Sauce.Type, type);
        }
    }

    internal class PizzaBuilder
    {
        private readonly IPizzaPartFactory factory;
        private Crust crust;
        private Cheese cheese;
        private Sauce sauce;

        public PizzaBuilder(IPizzaPartFactory factory)
        {
            this.factory = factory;
        }

        public Pizza GetPizza()
        {
            return new Pizza(crust, cheese, sauce);
        }

        public void AddSouce()
        {
            sauce = factory.CreateSauce();
        }

        public void AddCheese()
        {
            cheese = factory.CreateCheese();
        }

        public void AddCrust()
        {
            crust = factory.CreateCrust();
        }
    }

    internal interface IPizzaPartFactory
    {
        Sauce CreateSauce();
        Cheese CreateCheese();
        Crust CreateCrust();
    }

    class LitePizzaPartFactory : IPizzaPartFactory
    {
        private Flyweight flyweight;

        public LitePizzaPartFactory()
        {
            flyweight = new Flyweight();
        }

        public Sauce CreateSauce()
        {
            return new Sauce { Type = "Lite" };
        }

        public Cheese CreateCheese()
        {
            return new Cheese { Type = "Lite" };
        }

        public Crust CreateCrust()
        {
            return new LiteCrust(flyweight) { Type = "Lite" };
        }
    }

    internal class NormalPizzaPartFactory : IPizzaPartFactory
    {
        public Sauce CreateSauce()
        {
            return new Sauce { Type = "Normal" };
        }

        public Cheese CreateCheese()
        {
            return new Cheese { Type = "Normal" };
        }

        public Crust CreateCrust()
        {
            return new Crust { Type = "Normal" };
        }
    }
}