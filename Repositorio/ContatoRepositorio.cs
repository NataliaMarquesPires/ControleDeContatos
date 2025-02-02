using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio {
    public class ContatoRepositorio : IContatoRepositorio {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext) {
            _bancoContext = bancoContext;
        }

        /// <summary>
        /// Buscando tudo o que está no banco.
        /// </summary>
        /// <returns></returns>
        public List<ContatoModel> BuscarTodos() {
            return _bancoContext.Contatos.ToList(); 
        }

        /// <summary>
        /// Metodo para adiocionar um contato no banco.
        /// </summary>
        /// <param name="contato"></param>
        /// <returns></returns>
        public ContatoModel Adicionar(ContatoModel contato) {

            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

    }
}
