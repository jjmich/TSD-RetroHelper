using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TSD_RetroHelper.Models
{
    public class RetroBoard
    {
        public int ID { get; set; }
        public string Name { get; set; }

        List<RetroItem> WentWell { get; set; }
        List<RetroItem> ToImprove { get; set; }
        List<RetroItem> ActionItems { get; set; }

        [DataType(DataType.Date)]
        public DateTime RetroDate { get; set; } 

    }
}
