using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models
{
    public class RefreshToken
    {
        [Key]
        public int RefreshTokenID { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsRevoked { get; set; } = false;

        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
