using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AlunosBase.Domain.DTOs
{
    [Table("turmaa")]
    public class AlunosBaseADTOs
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public decimal matematica { get; set; }
        public decimal geografia { get; set; }
        public decimal portugues { get; set; }
        public decimal ingles { get; set; }
        public decimal historia { get; set; }
        public decimal ciencias { get; set; }
        public decimal educacaofisica { get; set; }
        public decimal mediatotal { get; set; }
    }
}
