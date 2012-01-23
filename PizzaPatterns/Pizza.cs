namespace PizzaPatterns
{
    public class Pizza
    {
        public Crust Crust { get; private set; }
        public Cheese Cheese { get; private set; }
        public Sauce Sauce { get; private set; }

        public Pizza(Crust crust, Cheese cheese, Sauce sauce)
        {
            Crust = crust;
            Cheese = cheese;
            Sauce = sauce;
        }
    }

    public class Crust
    {
        public string Type { get; set; }
    }

    public class Cheese
    {
        public string Type { get; set; }
    }

    public class Sauce
    {
        public string Type { get; set; }
    }
}
