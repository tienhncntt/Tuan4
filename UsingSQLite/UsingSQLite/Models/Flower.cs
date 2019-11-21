using SQLite;

namespace UsingSQLite.Models
{
    public class Flower
    {
        [PrimaryKey, AutoIncrement]
        public int FlowerID { get; set; }

        public int FlowerTypeID { get; set; }

        public string FlowerName { get; set; }

        public string FlowerImage { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }
    }
}
