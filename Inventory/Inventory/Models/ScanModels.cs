using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class ScanModels
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TrainId { get; set; }
        public string LineId { get; set; }
        public string UserId { get; set; }
    }
}