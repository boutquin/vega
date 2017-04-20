namespace Vega.Model.Create
{
    using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string EMail { get; set; }
    }
}