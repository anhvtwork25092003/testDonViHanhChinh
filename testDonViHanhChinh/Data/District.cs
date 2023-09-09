using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace testDonViHanhChinh.Data
{
    public class District
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Province")]
        public int ProvinceId { get; set; }

        public virtual Province Province { get; set; }

        public virtual List<Ward> Wards { get; set; }
    }
}
