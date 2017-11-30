using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LoyaltyApplication.Models
{
    public class User
    {
        public long Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [DefaultValue(0)]
        public long Points { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastModifiedTime { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
