using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_WebApi_Edu.Models.Domain
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string? PublicId { get; set; }

        //Navigation Properties
        public int UserID { get; set; }
        public User User { get; set; }
    }
}