using System;
using System.Collections.Generic;

namespace Assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1");
            BankAccount account = new BankAccount("Rohit Kumar", 1000m);
            account.DisplayBalance();

            account.Deposit(500m);
            account.Withdraw(200m);
            account.Withdraw(1500m);
            account.DisplayBalance();
            Console.ReadLine();

            Console.WriteLine("Question 2");
            StudentGradeCalculator studentGradeCalculator = new StudentGradeCalculator();
            studentGradeCalculator.CalculateGrade();
            Console.ReadLine();

            Console.WriteLine("Question 3");
            TemperatureConverter converter = new TemperatureConverter();
            converter.ConvertTemperature();
            Console.ReadLine();

            Console.WriteLine("Question 4");
            try
            {
                Employee emp = new Employee("John", 30, 50000m, "IT");
                emp.DisplayEmployeeInfo();
                Console.WriteLine($"Salary: {emp.GetSalary()}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();

            Console.WriteLine("Question 5");
            Calculator.PerformCalculation();
            Console.ReadLine();

            Console.WriteLine("Question 6");
            Book book = new Book("C# Programming", "John Doe", "123456", 3);

            try
            {
                book.IssueBook();
                book.IssueBook();
                book.IssueBook();
                book.IssueBook(); // Will throw an exception
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();

            Console.WriteLine("Question 7");
            try
            {
                Console.Write("Enter a positive integer: ");
                int num = Convert.ToInt32(Console.ReadLine());

                if (num < 0)
                    throw new ArgumentException("Number must be positive.");

                if (PrimeChecker.IsPrime(num))
                    Console.WriteLine($"{num} is a prime number.");
                else
                    Console.WriteLine($"{num} is not a prime number.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();

            Console.WriteLine("Question 8");
            Car car = new Car("Toyota", 100m);
            try
            {
                car.RentCar(5);
                car.ReturnCar();
                car.RentCar(3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();

            Console.WriteLine("Question 9");
            Order order = new Order(101, "Alice", 250m);
            order.DisplayOrder();
            order.UpdateStatus("Shipped");
            Console.ReadLine();

            Console.WriteLine("Question 10");
            MovieTicket ticket = new MovieTicket("Inception", "7:00 PM", 12, 150m);
            try
            {
                ticket.BookTicket();
                ticket.DisplayTicket();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }

    // Solution 1: Bank Account
    public class BankAccount
    {
        public string AccountHolder { get; private set; }
        private decimal Balance { get; set; }
        public BankAccount(string accountHolder, decimal initialBalance)
        {
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive");
                return;
            }

            Balance += amount;
            Console.WriteLine($"Deposit successful. Remaining balance: {Balance:C}");
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                return;
            }

            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds");
                return;
            }

            Balance -= amount;
            Console.WriteLine($"Withdrawal successful. Remaining balance: {Balance:C}");
        }
        public void DisplayBalance()
        {
            Console.WriteLine($"Account Holder: {AccountHolder}, Balance: {Balance:C}");
        }
    }

    // Solution 2: Student Grade Calculator
    class StudentGradeCalculator
    {
        public void CalculateGrade()
        {
            int[] marks = new int[5];
            int totalMarks = 0;
            double average;

            for (int i = 0; i < marks.Length; i++)
            {
                try
                {
                    Console.Write($"Enter marks for subject {i + 1} (0-100): ");
                    marks[i] = int.Parse(Console.ReadLine());

                    if (marks[i] < 0 || marks[i] > 100)
                    {
                        throw new ArgumentOutOfRangeException("Marks should be between 0 and 100.");
                    }

                    totalMarks += marks[i];
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input");
                    i--;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
            }
            average = totalMarks / (double)marks.Length;
            string grade;
            if (average >= 90)
            {
                grade = "A";
            }
            else if (average >= 80)
            {
                grade = "B";
            }
            else if (average >= 70)
            {
                grade = "C";
            }
            else if (average >= 60)
            {
                grade = "D";
            }
            else if (average >= 50)
            {
                grade = "E";
            }
            else
            {
                grade = "F";
            }

            Console.WriteLine($"Average Marks: {average:F2}");
            Console.WriteLine($"Grade: {grade}");
        }
    }

    // Solution 3: Temperature Converter
    class TemperatureConverter
    {
        public double Celsius { get; set; }
        public double Fahrenheit
        {
            get { return (Celsius * 9 / 5) + 32; }
            set { Celsius = (value - 32) * 5 / 9; }
        }

        public void ConvertTemperature()
        {
            Console.WriteLine("Temperature Conversion Program");
            bool continueConversion = true;

            while (continueConversion)
            {
                try
                {
                    Console.WriteLine("Select conversion type");
                    Console.WriteLine("1. Celsius to Fahrenheit");
                    Console.WriteLine("2. Fahrenheit to Celsius");
                    Console.Write("Enter (1 or 2): ");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        Console.Write("Enter temperature in Celsius: ");
                        Celsius = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Temperature in Fahrenheit: {Fahrenheit:F2}°F");
                    }
                    else if (choice == 2)
                    {
                        Console.Write("Enter temperature in Fahrenheit: ");
                        Fahrenheit = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Temperature in Celsius: {Celsius:F2}°C");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    }

                    Console.Write("Want more conversions (yes/no)? ");
                    string response = Console.ReadLine()?.ToLower();
                    if (response != "yes" && response != "y")
                    {
                        continueConversion = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input");
                }
            }

            Console.WriteLine("Thank you for using the Temperature Program.");
        }
    }

    // Solution 4: Employee
    class Employee
    {
        public string Name { get; set; }
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Age must be a positive number.");
                _age = value;
            }
        }
        private decimal Salary; // Private access modifier
        public string Department { get; set; }

        public Employee(string name, int age, decimal salary, string department)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Department = department;
        }

        public decimal GetSalary()
        {
            return Salary;
        }

        public void DisplayEmployeeInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Department: {Department}");
        }
    }

    // Solution 5: Calculator
    class Calculator
    {
        public static void PerformCalculation()
        {
            try
            {
                Console.Write("Enter the first number: ");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter an operator (+, -, *, /): ");
                char operation = Convert.ToChar(Console.ReadLine());

                Console.Write("Enter the second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                double result = 0;
                switch (operation)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                            Console.WriteLine("Division by zero is not allowed.");
                        return;
                    default:
                        Console.WriteLine("Invalid operator.");
                        return;
                }

                Console.WriteLine($"Result: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter valid numbers.");
            }
        }
    }

    // Solution 6: Book
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int CopiesAvailable { get; private set; }

        public Book(string title, string author, string isbn, int copiesAvailable)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            CopiesAvailable = copiesAvailable;
        }

        public void IssueBook()
        {
            if (CopiesAvailable <= 0)
                throw new Exception("No copies available to issue.");

            CopiesAvailable--;
            Console.WriteLine("Book issued successfully.");
        }

        public void ReturnBook()
        {
            CopiesAvailable++;
            Console.WriteLine("Book returned successfully.");
        }
    }

    // Solution 7: Prime Checker
    public class PrimeChecker
    {
        public static bool IsPrime(int num)
        {
            if (num <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    return false;
            }

            return true;
        }
    }

    // Solution 8: Car Rental
    class Car
    {
        public string Model { get; set; }
        public decimal RentalPricePerDay { get; set; }
        private bool IsAvailable { get; set; }

        public Car(string model, decimal rentalPricePerDay)
        {
            Model = model;
            RentalPricePerDay = rentalPricePerDay;
            IsAvailable = true;
        }

        public void RentCar(int numberOfDays)
        {
            if (!IsAvailable)
            {
                Console.WriteLine("Car is not available for rent.");
                return;
            }

            IsAvailable = false;
            decimal totalCost = numberOfDays * RentalPricePerDay;
            Console.WriteLine($"Car rented for {numberOfDays} days. Total cost: {totalCost:C}");
        }

        public void ReturnCar()
        {
            IsAvailable = true;
            Console.WriteLine("Car returned successfully.");
        }
    }

    // Solution 9: Order System
    class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public decimal OrderAmount { get; set; }
        public string Status { get; private set; }

        public Order(int orderId, string customerName, decimal orderAmount)
        {
            OrderId = orderId;
            CustomerName = customerName;
            OrderAmount = orderAmount;
            Status = "Pending";
        }

        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"Order status updated to {Status}");
        }

        public void DisplayOrder()
        {
            Console.WriteLine($"Order ID: {OrderId}, Customer Name: {CustomerName}, Order Amount: {OrderAmount:C}, Status: {Status}");
        }
    }

    // Solution 10: Movie Ticket Booking
    class MovieTicket
    {
        public string MovieName { get; set; }
        public string ShowTime { get; set; }
        public int Age { get; set; }
        public decimal TicketPrice { get; set; }

        public MovieTicket(string movieName, string showTime, int age, decimal ticketPrice)
        {
            MovieName = movieName;
            ShowTime = showTime;
            Age = age;
            TicketPrice = ticketPrice;
        }

        public void BookTicket()
        {
            if (Age <= 12)
            {
                decimal discountedPrice = TicketPrice * 0.5m;
                Console.WriteLine($"Ticket booked for {MovieName} at {ShowTime}. Discounted Price: {discountedPrice:C}");
            }
            else
            {
                Console.WriteLine($"Ticket booked for {MovieName} at {ShowTime}. Price: {TicketPrice:C}");
            }
        }

        public void DisplayTicket()
        {
            Console.WriteLine($"Movie: {MovieName}, Show Time: {ShowTime}, Age: {Age}, Price: {TicketPrice:C}");
        }
    }
}