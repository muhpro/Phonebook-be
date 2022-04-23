using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook_be.Models
{
    [TableName("Users")]
    [PrimaryKey("userID")]
    public class Users
    {
        public int userID { get; set; }
        public string fullName { get; set; }
        public string number { get; set; }
    }
}
