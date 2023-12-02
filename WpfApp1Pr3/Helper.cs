using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1Pr3
{
    public class Helper
    {
        private static Entities s_firstDBEntities;
        public static Entities GetContext()
        {
            if (s_firstDBEntities == null)
            {
                s_firstDBEntities = new Entities();



            }
            return s_firstDBEntities;
        }

        public static void CreateUsers(Workers workers, Users users)
        {
            GetContext();
            s_firstDBEntities.Workers.Add(workers);
            s_firstDBEntities.SaveChanges();


            s_firstDBEntities.Users.Add(users);

            s_firstDBEntities.SaveChanges();

        }
        public void UpdateUsers(Users users, Workers workers)
        {
            s_firstDBEntities.Entry(users).State = System.Data.Entity.EntityState.Modified;
            s_firstDBEntities.Entry(workers).State = System.Data.Entity.EntityState.Modified;
            s_firstDBEntities.SaveChanges();




        }
        public static void RemoveUsers(int idUsers, int idWorkers)
        {
            var users = s_firstDBEntities.Users.Find(idUsers);
            var workers = s_firstDBEntities.Workers.Find(idWorkers);
            s_firstDBEntities.Users.Remove(users);
            s_firstDBEntities.Workers.Remove(workers);
            s_firstDBEntities.SaveChanges();


        }

        public void FiltrUsers()
        {
            var users = s_firstDBEntities.Workers.Where(x => x.FirstName.StartsWith("М") || x.FirstName.StartsWith("А"));
        }
        public void SortUsers()
        {
            var users = s_firstDBEntities.Workers.OrderBy(x => x.FirstName);

        }

    }
}
