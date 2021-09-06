using System;
using System.Collections.Generic;

namespace CAFavorCompositionOverInheritanceAfter
{
    class Program
    {
        static void Main(string[] args)
        {
            var choice = 0;
            var pizza = new Pizza();
            do
            {
                Console.Clear();
                choice = ReadChoice(choice);
                if (choice >= 1 && choice <= 6)
                {
                    ITopping topping = null;
                    switch (choice)
                    {
                        case 1:
                            topping = new Tomato();
                            break;
                        case 2:
                            topping = new Chicken();
                            break;
                        case 3: 
                            topping = new Cheese();
                            break;
                        case 4: 
                            topping = new BlackOlive();
                            break;
                        case 5: 
                            topping = new GreenPaper();
                            break;
                        case 6:
                            topping = new Solami();
                            break;
                        default:
                            break;
                    }
                    pizza.AddTopping(topping);
                    Console.WriteLine("Press any key to continue");
                }
                Console.ReadKey();
            } while (choice != 0);
            Console.WriteLine(pizza);
            Console.ReadKey();
        }

        private static int ReadChoice(int choice)
        {
            Console.WriteLine("Available Topping");
            Console.WriteLine("------------");
            Console.WriteLine("1. Tomato");
            Console.WriteLine("2. Chicken");
            Console.WriteLine("3. Cheese");
            Console.WriteLine("4. Black Olives");
            Console.WriteLine("5. Green Paper");
            Console.WriteLine("6. Solami");
            Console.WriteLine("select topping: ");
            if (int.TryParse(Console.ReadLine(), out int ch))
            {
                choice = ch;
            }

            return choice;
        }
    }

    class Pizza
    { 
        public virtual decimal Price => 10m;

        public List<ITopping> Toppings { get; private set; } = new List<ITopping>();

        public void AddTopping(ITopping topping) => Toppings.Add(topping);


        private decimal Calculate()
        {
            var total = Price;
            foreach (var item in Toppings)
            {
                total += item.Price;
            }
            return total;
        }
        public override string ToString()
        {
            var output = $"\n{nameof(Pizza)}";
            output += $"\n\tBase Price: ({Price.ToString("C")})";
            foreach (var topping in Toppings)
            {
                output += $"\n\t {topping.Title} ({topping.Price.ToString("C")})";
            }
            output += "\n-----------------------";
            output += $"\nTotal: {Calculate().ToString("C")}";
            return output;
        }
    }

    public interface ITopping
    {
        string Title { get; }
        decimal Price { get; }
    }

    public class Tomato : ITopping
    {
        public string Title => nameof(Tomato);

        public decimal Price => 3m;
    }
    public class Chicken : ITopping
    {
        public string Title => nameof(Chicken);

        public decimal Price => 6m;
    }

    public class Cheese : ITopping
    {
        public string Title => nameof(Cheese);

        public decimal Price => 4m;
    }

    public class BlackOlive : ITopping
    {
        public string Title => nameof(BlackOlive);

        public decimal Price => 2m;
    }

    public class GreenPaper : ITopping
    {
        public string Title => nameof(GreenPaper);

        public decimal Price => 2.5m;
    }

    public class Solami : ITopping
    {
        public string Title => nameof(GreenPaper);

        public decimal Price => 7.5m;
    }
}
