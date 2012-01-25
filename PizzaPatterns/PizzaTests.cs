using Xunit;

namespace PizzaPatterns
{
    public class PizzaTests
    {
        [Fact]
        public void Can_create_normal_pizza()
        {
            var pizza = CreatePizza(new LitePizzaPartFactory());

            AssertPizzaPartsAreOfType(pizza, "Normal");
        }

        private static Pizza CreatePizza(IPizzaPartFactory factory)
        {
            var builder = new PizzaBuilder(factory);
            builder.AddCrust();
            builder.AddCheese();
            builder.AddSouce();


            return builder.GetPizza();
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
            return new Crust { Type = "Lite" };
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