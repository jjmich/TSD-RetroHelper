using System.ComponentModel.DataAnnotations.Schema;

namespace TSD_RetroHelper.Models
{
    public class RetroItem
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        
        public int RetroBoardRefId { get; set; }

        [ForeignKey("RetroBoardRefId")]
        public RetroBoard RetroBoard { get; set; }

        public int ColumnId { get; set; }
    }
}
