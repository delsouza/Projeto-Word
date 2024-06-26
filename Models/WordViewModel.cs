using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class WordViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o titulo!")]
        public string Titulo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o conteúdo!")]
        public string Conteudo { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;
    }
}
