using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsingSQLite.Models
{
    public class FlowerType
    {
        [PrimaryKey, AutoIncrement]
        public int FlowerTypeID { get; set; }

        public string FlowerTypeName { get; set; }
    }
}
