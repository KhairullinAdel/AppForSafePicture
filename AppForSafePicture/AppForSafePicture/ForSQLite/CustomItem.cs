using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppForSafePicture
{
    [Table("Items")]
    public class CustomItem
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [Unique]
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
