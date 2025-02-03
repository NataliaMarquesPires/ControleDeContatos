using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio {
    public class ContatoRepositorio : IContatoRepositorio {
        private readonly BancoContext _context;
        public ContatoRepositorio(BancoContext bancoContext) {
            this._context = bancoContext;
        }

        /// <summary>
        /// Metodo para listar um contato por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ContatoModel ListarPorId(int id) {
            return _context.Contatos.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Buscando tudo o que está no banco.
        /// </summary>
        /// <returns></returns>
        public List<ContatoModel> BuscarTodos() {
            return _context.Contatos.ToList();
        }

        /// <summary>
        /// Metodo para adiocionar um contato no banco.
        /// </summary>
        /// <param name="contato"></param>
        /// <returns></returns>
        public ContatoModel Adicionar(ContatoModel contato) {

            _context.Contatos.Add(contato);
            _context.SaveChanges();

            return contato;
        }

        /// <summary>
        /// Metodo para atualizar um contato no banco.
        /// </summary>
        /// <param name="contato"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ContatoModel Atualizar(ContatoModel contato) {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null)
                throw new Exception("Contato não encontrado");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _context.Contatos.Update(contatoDB);
            _context.SaveChanges();

            return contatoDB;
        }

        /// <summary>
        /// Metodo para apagar um contato no banco.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Apagar(int id) {
            ContatoModel contatoDB = ListarPorId(id);

            if (contatoDB == null)
                throw new Exception("Contato não encontrado");

            _context.Contatos.Remove(contatoDB);
            _context.SaveChanges();

            return true;
        }
    }
}
