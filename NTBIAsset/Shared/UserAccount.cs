using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NTBIAsset.Shared
{
    public class UserAccount
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Active { get; set; } = true;

        public DateTime Date_Created { get; set; }

    }
}
