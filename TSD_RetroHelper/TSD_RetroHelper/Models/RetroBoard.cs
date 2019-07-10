using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TSD_RetroHelper.Models
{
    public class RetroBoard
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<RetroItem> RetroItems { get; set; }

        [DataType(DataType.Date)]
        public DateTime RetroDate { get; set; } 

    }
}
