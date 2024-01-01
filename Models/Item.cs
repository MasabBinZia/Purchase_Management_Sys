using System.ComponentModel.DataAnnotations;

namespace PurchaseManagementSys.Models
{
    public class Item
    {
        [Key]
        public int item_id { get; set; }
        public string item_name { get; set; }
        public string item_status { get; set; }
    }
}
