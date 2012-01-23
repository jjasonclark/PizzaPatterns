using Xunit;

namespace PizzaPatterns
{
    public class PizzaTests
    {
        [Fact]
        public void Can_create_pizza_the_hard_way()
        {
            var crust = new Crust { Type = "Normal" };
            var cheese = new Cheese { Type = "Normal" };
            var sauce = new Sauce { Type = "Normal" };

            var pizza = new Pizza(crust, cheese, sauce);

            AssertPizzaPartsAreOfType(pizza, "Normal");
        }

        private static void AssertPizzaPartsAreOfType(Pizza pizza, string type)
        {
            Assert.Equal(pizza.Crust.Type, type);
            Assert.Equal(pizza.Cheese.Type, type);
            Assert.Equal(pizza.Sauce.Type, type);
        }
    }
}