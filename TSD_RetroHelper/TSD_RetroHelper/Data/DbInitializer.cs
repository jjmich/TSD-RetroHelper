using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSD_RetroHelper.Models;

namespace TSD_RetroHelper.Data
{
    public class DbInitializer
    {
        public static void Initialize(TSD_RetroHelperContext context)
        {
            //if (context.RetroBoard.Any())
            //{
            //    return;   // DB has been seeded
            //}
            var items = new RetroItem[]
            {
                new RetroItem { Id = 2345, Rating = 10, Name = "FirstItem", Comment = "Empty", RetroBoardRefId = 1234, ColumnId = 1 },
                new RetroItem { Id = 2346, Rating = 5, Name = "SecondItem", Comment = "Empty", RetroBoardRefId = 1234, ColumnId = 2 },
                new RetroItem { Id = 2347, Rating = 7, Name = "ThirdItem", Comment = "Empty", RetroBoardRefId = 1234, ColumnId = 3 }
            };
            foreach (var item in items)
            {
                context.RetroItem.Add(item);
            }
            context.SaveChanges();

            //var ColgateRetroItemsList = new List<RetroItem> { 1, 2, 3 };

            var boards = new RetroBoard[]
            {
                new RetroBoard{ RetroDate=DateTime.Parse("2005-09-01"), Name="TestTeam", ID=1234, RetroItems = items}
            };
            foreach (var board in boards)
            {
                context.RetroBoard.Add(board);
            }
            context.SaveChanges();
        }
    }
}
