using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models {
    public class ContatoModel {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o E-mail do contato")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Celular do contato")]
        [Phone(ErrorMessage = "O celular informado não é valido!")]
        public string Celular { get; set; }
    }
}
