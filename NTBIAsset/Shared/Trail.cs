using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace NTBIAsset.Shared
{
    public class Trail
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string User { get; set; }

        public DateTime Date_Action { get; set; }

        public UserAction Action { get; set; }

    }
    public enum UserAction
    {
        Create = 0,
        Update = 1,
        Modify = 2,
        Delete = 3
    }
}
