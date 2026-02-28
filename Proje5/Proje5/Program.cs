using System;
using System.Collections.Generic;
using System.Linq;

class User
{
    public string Username { get; set; }
    public string Password { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}

class Program
{
    static List<User> users = new List<User>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- Kullanıcı Sistemi ---");
            Console.WriteLine("1- Kayıt Ol");
            Console.WriteLine("2- Giriş Yap");
            Console.WriteLine("3- Kullanıcıları Listele");
            Console.WriteLine("4- Çıkış");
            Console.Write("Seçiminiz: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Register();
                    break;
                case "2":
                    Login();
                    break;
                case "3":
                    ListUsers();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
    }

    static void Register()
    {
        Console.Write("Kullanıcı adı: ");
        string username = Console.ReadLine();

        if (users.Any(u => u.Username == username))
        {
            Console.WriteLine("Bu kullanıcı adı zaten mevcut.");
            return;
        }

        Console.Write("Şifre: ");
        string password = Console.ReadLine();

        users.Add(new User(username, password));
        Console.WriteLine("Kayıt başarılı.");
    }

    static void Login()
    {
        Console.Write("Kullanıcı adı: ");
        string username = Console.ReadLine();

        Console.Write("Şifre: ");
        string password = Console.ReadLine();

        var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
            Console.WriteLine("Giriş başarılı.");
        else
            Console.WriteLine("Hatalı kullanıcı adı veya şifre.");
    }

    static void ListUsers()
    {
        foreach (var user in users)
        {
            Console.WriteLine("Kullanıcı: " + user.Username);
        }
    }
}