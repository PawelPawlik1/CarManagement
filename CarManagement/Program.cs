using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManagement
{
    class Program
    {
        static private List<Car> cars = new List<Car>();
        static void Inicjalizacja()
        {
            cars.Add(new Car(cars, "Audi A4", 5000, "Undamaged"));
            cars.Add(new Car(cars,"Volkswagen Passat", 7000, "Undamaged"));
            cars.Add(new Car(cars,"Peugeot 307", 2500, "Damaged"));
            cars.Add(new Car(cars,"Alfa Romeo 159", 15000, "Undamaged"));
            cars.Add(new Car(cars,"BMW e36", 30000, "Monument"));
            cars.Add(new Car(cars,"Honda Accord", 3200, "Damaged"));
            cars.Add(new Car(cars,"Opel Omega", 4500, "Undamaged"));
        }

        static void ViewAllCars(List<Car> cars)
        {
            Console.WriteLine("| Id:               " + "| Brand:            " + "| Price:            " + "| About:     ");
            foreach (var item in cars)
            {
                String column = "|x                  ";
                int columnLength = column.Length;

                int i = column.Length;
                // Console.WriteLine($"{item.GetId()}     |      {item.GetBrand()}     |      {item.GetPrice()}     |      {item.GetAbout()}");

                String columnId = column.Replace("x", item.GetId().ToString()).Substring(0, columnLength);
                String columnBrand = column.Replace("x", item.GetBrand()).Substring(0, columnLength);
                String columnPrice = column.Replace("x", item.GetPrice().ToString()).Substring(0, columnLength);
                String columnAbout = column.Replace("x", item.GetAbout()).Substring(0, columnLength);
                Console.WriteLine(columnId + columnBrand + columnPrice + columnAbout);
            }
        }

        static List<Car> SortByName(List<Car> cars)
        {
            List<Car> sortedList = new List<Car>();

            var tempListSorted = from car in cars orderby car.GetBrand() ascending select car;

            foreach (Car car in tempListSorted)
            {
                sortedList.Add(car);
            }
            return sortedList;
        }

        static List<Car> SortByPrice(List<Car> cars)
        {
            List<Car> sortedList = new List<Car>();

            var tempListSorted = from car in cars orderby car.GetPrice() ascending select car;

            foreach (Car car in tempListSorted)
            {
                sortedList.Add(car);
            }
            return sortedList;
        }


        static List<Car> SortByHigherPrice(List<Car> cars)
        {
            List<Car> sortedList = new List<Car>();

            var tempListSorted = from car in cars orderby car.GetPrice() ascending select car;
            tempListSorted.Reverse();
            foreach (Car car in tempListSorted)
            {
                sortedList.Add(car);
            }
            sortedList.Reverse();
            return sortedList;
        }

        static void AddCar()
        {
            Console.WriteLine("What brand?");
            string newBrand = Console.ReadLine();

            Console.WriteLine("Price: ");
            int newPrice = int.Parse(Console.ReadLine());

            Console.WriteLine("What about?: ");
            string newAbout = Console.ReadLine();

            cars.Add(new Car(cars, newBrand, newPrice, newAbout));
            ViewAllCars(cars);
            viewMenu();
        }

        static void DeleteCar()
        {
            ViewAllCars(cars);
            Console.Write("\nEnter the ID you want to remove");
            
            int id = int.Parse(Console.ReadLine());

            var searchCar = from car in cars where car.GetId() == id select car;

            Car carToRemove = searchCar.Single();
            cars.Remove(carToRemove);

            ViewAllCars(cars);
            viewMenu();
        }

        static void EditCar()
        {
            Console.WriteLine("Enter the ID of the car to edit: ");
            int id = int.Parse(Console.ReadLine());

            Car searchCar = cars.Find(car => car.GetId() == id);
            Console.WriteLine($"You picked {searchCar.GetBrand()} to edit");

            Console.WriteLine("What do you want to edit?");
            Console.WriteLine("1 - brand  |  2 - price  | 3 = description");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter new brand: ");
                    string editedBrand = Console.ReadLine();
                    searchCar.SetBrand(editedBrand);
                    Console.Clear();
                    ViewAllCars(cars);
                    break;
                case "2":
                    Console.Write($"The old price is: {searchCar.GetPrice()} \nEnter new price: ");
                    int editedPrice = int.Parse(Console.ReadLine());
                    searchCar.SetPrice(editedPrice);
                    Console.Clear();
                    ViewAllCars(cars);
                    break;
                case "3":
                    Console.WriteLine("Enter new info: ");
                    string editedInfo = Console.ReadLine();
                    searchCar.SetAbout(editedInfo);
                    Console.Clear();
                    ViewAllCars(cars);
                    break;
            }
            
            viewMenu();
        }
        static void viewMenu()
        {
            Console.WriteLine("1   View all cars");
            Console.WriteLine("2   Sort by name");
            Console.WriteLine("3   Sort by price");
            Console.WriteLine("4   Sort by higher price");
            Console.WriteLine("5   Add a new car");
            Console.WriteLine("6   Delete car");
            Console.WriteLine("7   Edit car");
        }

        static void Main(string[] args)
        {
            Inicjalizacja();
            
            bool appExit = false;
            viewMenu();
            //string userInput = Console.ReadLine();
            while (!appExit)
            {
                ConsoleKeyInfo consolekeyinfo = Console.ReadKey();
                Console.WriteLine(consolekeyinfo.KeyChar);
                Console.Clear();
                viewMenu();
                switch (consolekeyinfo.Key)
                    
                {
                    case ConsoleKey.D1:
                        ViewAllCars(cars);
                        break;
                    case ConsoleKey.D2:
                        ViewAllCars(SortByName(cars));
                        break;
                    case ConsoleKey.D3:
                        ViewAllCars(SortByPrice(cars));
                        break;
                    case ConsoleKey.D4:
                        ViewAllCars(SortByHigherPrice(cars));
                        break;
                    case ConsoleKey.D5:
                        AddCar();
                        break;
                    case ConsoleKey.D6:
                        DeleteCar();
                        break;
                    case ConsoleKey.D7:
                        EditCar();
                        break;
                    default:
                        Console.WriteLine("Try again");
                        break;
                }
            }
        }
    }
}
