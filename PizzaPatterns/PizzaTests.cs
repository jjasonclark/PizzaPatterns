using Xunit;

namespace PizzaPatterns
{
    public class PizzaTests
    {
        [Fact]
        public void Can_create_normal_pizza()
        {
            var pizza = CreatePizza(new NormalPizzaPartFactory());

            AssertPizzaPartsAreOfType(pizza, "Normal");
        }

        private static Pizza CreatePizza(NormalPizzaPartFactory factory)
        {
            var crust = factory.CreateCrust();
            var cheese = factory.CreateCheese();
            var sauce = factory.CreateSauce();

            return new Pizza(crust, cheese, sauce);
        }

        private static void AssertPizzaPartsAreOfType(Pizza pizza, string type)
        {
            Assert.Equal(pizza.Crust.Type, type);
            Assert.Equal(pizza.Cheese.Type, type);
            Assert.Equal(pizza.Sauce.Type, type);
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