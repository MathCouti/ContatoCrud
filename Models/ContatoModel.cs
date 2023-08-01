using System.ComponentModel.DataAnnotations;

namespace PraticaWeb
{
    public class ContatoModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O email é obrigatório!")]
        [EmailAddress(ErrorMessage = "Email invalido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O celular é obrigatório!")]
        [Phone(ErrorMessage = "Celular invalido!")]
        public string Celular { get; set; }
    }
}
