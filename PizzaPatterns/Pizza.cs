using System;

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

    public class LiteCrust : Crust
    {
        private readonly Flyweight flyweight;

        public MemoryHog MemoryHog
        {
            get { return flyweight.MemoryHog; }
            set { flyweight.MemoryHog = value; }
        }

        public LiteCrust(Flyweight flyweight)
        {
            this.flyweight = flyweight;
        }
    }

    public class Flyweight
    {
        public MemoryHog MemoryHog { get; set; }

        public Flyweight()
        {
            MemoryHog = new MemoryHog();
        }
    }

    public class MemoryHog
    {
        public MemoryHog()
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
        }
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
