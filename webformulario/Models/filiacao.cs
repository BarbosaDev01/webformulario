using System.ComponentModel.DataAnnotations;

namespace webformulario.Models
{
    public class filiacao
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public int Telefone { get; set; }
        [Required]
        public string Vitalicio { get; set; }
        [Required]
        public string Anual { get; set; }
    }
}
