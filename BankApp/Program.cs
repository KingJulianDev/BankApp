using System;
using System.Collections.Generic;
using System.Linq;

    List<User> users = new List<User>
        {
            new User {Name = "Isabel", Password = 11111, BalanceUAH = 26075.98m, BalanceUSD = 2578.22m, ID = 1},
            new User {Name = "Mike", Password = 22222, BalanceUAH = 30551.54m, BalanceUSD = 1854.34m, ID = 2},
            new User {Name = "Jacqueline", Password = 333333, BalanceUAH = 91551.76m, BalanceUSD = 2314.05m, ID = 3},
            new User {Name = "Arthur", Password = 44444, BalanceUAH = 1765.59m, BalanceUSD = 5114.12m, ID = 4}
        };

    int attempts = 5;

    User currentUser;

    decimal uahToUsd = 0.024m;
    decimal usdToUah = 41.08m;

    while (attempts > 0)
    {
        Console.WriteLine("Введите имя пользователя.");
        string nameInput = Console.ReadLine();

        if (users.Any(user => user.Name == nameInput))
        {
            currentUser = users.Find(user => user.Name == nameInput);

            Console.WriteLine("Введите пароль.");

            int password = Convert.ToInt32(Console.ReadLine());

            if (password == currentUser.Password)
            {
                Console.WriteLine("С возвращением!");
                Console.WriteLine($"Ваш баланс: {currentUser.BalanceUAH} UAH и {currentUser.BalanceUSD} USD");
                break;
            }
            else
            {
                Console.WriteLine($"Неверный пароль! Осталось попыток: {attempts - 1}");
                attempts--;
            }
        }
        else
        {
            Console.WriteLine("Такого пользователя не существует!");
        }
    }

    if (attempts == 0)
    {
        Console.WriteLine("Отказано в доступе.");
        Environment.Exit(0);
    }

    Console.WriteLine("Введите номер нужной операции:");
    Console.WriteLine("1 - Поменять UAH на USD");
    Console.WriteLine("2 - Поменять USD на UAH");

    int operationNum = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Введите сумму для обмена.");

    decimal amountToConvert = Convert.ToDecimal(Console.ReadLine());

    if (operationNum == 1)
    {
        Console.WriteLine($"Введите 1, чтобы подтвердить обмен {amountToConvert} UAH на {amountToConvert * uahToUsd} USD.");
        Console.WriteLine("Введите 2, чтобы отклонить обмен.");
    }
    else if (operationNum == 2)
    {
        Console.WriteLine($"Введите 1, чтобы подтвердить обмен {amountToConvert} USD на {amountToConvert * usdToUah} UAH.");
        Console.WriteLine("Введите 2, чтобы отклонить обмен.");
    }
    else
    {
        Console.WriteLine("Введено неправильное значение!");
        Environment.Exit(0);
    }

    //void updateBalance()
    //{
    //    currentUser.BalanceUAH -= amountToConvert;
    //    currentUser.BalanceUSD += amountToConvert * uahToUsd;
    //};

public class User
{
    public string Name { get; set; }
    public int Password { get; set; }
    public decimal BalanceUAH { get; set; }
    public decimal BalanceUSD { get; set; }
    public int ID { get; set; }
}
