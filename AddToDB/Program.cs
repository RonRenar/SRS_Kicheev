using AddToDB.Model;
using HashPasswords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddToDB
{
    class Program
    {
        static void Main(string[] args)
        {
            AtelieBaseEntities entities = new AtelieBaseEntities();
            
            Workers workers = new Workers();
            Users users = new Users();
            Console.WriteLine("Введите имя пользователя");
            workers.FirstName  = Console.ReadLine();
            Console.WriteLine("Введите имя Фамилию пользователя");
            workers.LastName  = Console.ReadLine();
            Console.WriteLine("Тип активности");
            workers.ActivityTypeID  = Convert.ToInt32(Console.ReadLine());
            entities.Workers.Add(workers);
            entities.SaveChanges();
            Console.WriteLine("Введите логин пользователя");
            users.Login = Console.ReadLine();
            Console.WriteLine("Введите пароль пользователя");
            string k4 = Console.ReadLine();

           users.Password = Hash.Hashing(k4);
            users.WorkerId = workers.id;
            entities.Users.Add(users);
            entities.SaveChanges();
            
            Console.ReadLine();

        }
    }
}
