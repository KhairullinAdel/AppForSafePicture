using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppForSafePicture
{
    [Table("CustomObjects")]
    public class CustomObject
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
