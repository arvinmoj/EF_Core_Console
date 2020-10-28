using System;
using System.Linq;

namespace Entity
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("1. Add User");
            System.Console.WriteLine("2. Remove User");
            System.Console.WriteLine("3. Find User");
            System.Console.WriteLine("4. Show All");

            System.Console.Write("Enter Option: ");
            int CheckOption = Convert.ToInt16(Console.ReadLine());

            switch (CheckOption)
            {
                case 1:
                    {
                        System.Console.Write("Enter FullName: ");
                        string Fullname = Console.ReadLine();

                        System.Console.Write("Enter Username: ");
                        string Username = Console.ReadLine();

                        System.Console.Write("Enter Password: ");
                        string Password = Console.ReadLine();

                        Data.DatabaseContext database = new Data.DatabaseContext();

                        Models.User u1 = new Models.User()
                        {
                            FullName = Fullname,
                            Username = Username,
                            Password = Password,
                        };

                        database.Users.Add(u1);
                        database.SaveChanges();
                    }
                    break;

                case 2:
                    {
                        Data.DatabaseContext database = new Data.DatabaseContext();
                        System.Console.Write("Enter Username or Fullname: ");

                        string username = Console.ReadLine(); ;

                        var UserList = database.Users.Where(u => u.Username == username || u.FullName == username).First();
                        database.Users.Remove(UserList);
                        database.SaveChanges();

                    }
                    break;

                case 3:
                    {
                        Data.DatabaseContext database = new Data.DatabaseContext();
                        System.Console.Write("Enter Username or Fullname: ");

                        string username = Console.ReadLine(); ;

                        var FindUsername = database.Users.Where(u => u.Username == username || u.FullName == username).Any();

                        if (FindUsername == true)
                        {
                            var UserList = database.Users.Where(u => u.Username == username || u.FullName == username).ToList();

                            foreach (var item in UserList)
                            {
                                System.Console.WriteLine($"FullName: {item.FullName} Username: {item.Username} Password: {item.Password}");
                            }
                        }

                        else
                        {
                            System.Console.WriteLine(" Not Find !");
                        }
                    }
                    break;

                case 4:
                    {
                        Data.DatabaseContext database = new Data.DatabaseContext();
                        var ShowAll = database.Users.ToList();

                        foreach (var item in ShowAll)
                        {
                            System.Console.WriteLine($"FullName: {item.FullName} Username: {item.Username} Password: {item.Password}");
                        }
                    }
                    break;
            }
        }
    }
}
