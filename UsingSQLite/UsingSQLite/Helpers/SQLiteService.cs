using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using UsingSQLite.Models;

namespace UsingSQLite.Helpers
{
    public class SQLiteService
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        #region Contructor

        public SQLiteService(string dbPath)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "database.db")))
                {
                    connection.CreateTable<FlowerType>();
                    connection.CreateTable<Flower>();
                }
            }
            catch
            {

            }
        }


        #endregion

        #region Get

        public List<FlowerType> GetFlowerType()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "database.db")))
                {
                    return connection.Table<FlowerType>().ToList();
                }
            }
            catch
            {
                return null;
            }
        }


        #endregion

        #region GetByID

        public FlowerType GetFlowerTypeByID(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "database.db")))
                {
                    return connection.Table<FlowerType>().Where(i => i.FlowerTypeID == id).FirstOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }


        #endregion

        #region Insert

        public bool InsertFlowerType(FlowerType obj)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "database.db")))
                {
                    connection.Insert(obj);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        #endregion

        #region Update

        public bool UpdateFlowerType(FlowerType obj)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "database.db")))
                {
                    connection.Update(obj);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        #endregion

        #region Get

        public List<Flower> GetFlower()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "database.db")))
                {
                    return connection.Table<Flower>().ToList();
                }
            }
            catch
            {
                return null;
            }
        }


        #endregion

        #region GetByID

        public Flower GetFlowerByID(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "database.db")))
                {
                    return connection.Table<Flower>().Where(i => i.FlowerTypeID == id).FirstOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }


        #endregion

        #region Insert

        public bool InsertFlower(Flower obj)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "database.db")))
                {
                    connection.Insert(obj);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        #endregion

        #region Update

        public bool UpdateFlower(Flower obj)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "database.db")))
                {
                    connection.Update(obj);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        #endregion

        #region Delete

        public bool Delete(object obj)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "database.db")))
                {
                    connection.Delete(obj);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        #endregion
    }
}
