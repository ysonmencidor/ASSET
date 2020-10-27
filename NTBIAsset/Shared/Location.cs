using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NTBIAsset.Shared
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public bool Active { get; set; } = true;

        public Location()
        {

        }
        public Location(int id,string name, bool active = true)
        {
            this.Id = id;
            this.Name = name;
            this.Active = active;
        }
    }
}
