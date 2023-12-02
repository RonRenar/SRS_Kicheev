using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AddToDB.Model
{
   public class Helper
    {
        private static Model.AtelieBaseEntities s_firstDBEntities;
        public static Model.AtelieBaseEntities GetContext()
        {
            if (s_firstDBEntities == null) 
            { 
            s_firstDBEntities = new Model.AtelieBaseEntities();

            
            
            }
            return s_firstDBEntities;
        }

        public  static void CreateUsers(Model.Workers workers, Model.Users users) 
        {
            GetContext();
            s_firstDBEntities.Workers.Add(workers);
            s_firstDBEntities.SaveChanges();
           
          
            s_firstDBEntities.Users.Add(users);
            
            s_firstDBEntities.SaveChanges();
       
        }
        public void UpdateUsers(Model.Users users, Model.Workers workers) 
        { 
            s_firstDBEntities.Entry(users).State = System.Data.Entity.EntityState.Modified;
            s_firstDBEntities.Entry(workers).State = System.Data.Entity.EntityState.Modified;
            s_firstDBEntities.SaveChanges();
        
        
        
        
        }
        public static void RemoveUsers(int idUsers,int idWorkers)
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
