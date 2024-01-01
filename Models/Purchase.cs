using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PurchaseManagementSys.Models
{
    public class Purchase
    {
        [Key]
        public int pur_id { get; set; }
        public string pur_item { get; set; }
        public int pur_qty { get; set; }

        public DateTime pur_date { get; set; }
        public int pur_price { get; set; }
        public string pur_vendor { get; set; }
    }
}
