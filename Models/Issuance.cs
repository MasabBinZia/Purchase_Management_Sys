using System.ComponentModel.DataAnnotations;

namespace PurchaseManagementSys.Models
{
    public class Issuance
    {
        [Key]
        public int issuance_id { get; set; }
        public DateTime iss_date { get; set; }
        public string emp_name { get; set; }
        public int qnty { get; set; }
    }
}
