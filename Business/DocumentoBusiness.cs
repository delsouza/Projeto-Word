using Business.Interface;
using DAO;
using Models;
using DAO.Interface;
using Microsoft.EntityFrameworkCore;


namespace Business
{
    public class DocumentoBusiness : IDocumentoBusiness
    {
        private readonly IDocumentoDAO _documentoDAO;
       
        public DocumentoBusiness(IDocumentoDAO documentoDAO)
        {
            _documentoDAO = documentoDAO;
        }

        public void CriarDocumento(WordViewModel word)
        {
            _documentoDAO.Criar(word);
        }

        public void EditarDocumento(WordViewModel word)
        {
            _documentoDAO.Editar(word);
        }

        public void ExcluirDocumento(WordViewModel word)
        {
            _documentoDAO.Excluir(word);
        }

        public List<WordViewModel> ListarDocumento()
        {
            return _documentoDAO.Listar().ToList();
        }

        public WordViewModel ObterDocumentoPorId(int id)
        {
            var documento =  _documentoDAO.ListarPor(x => x.Id == id).FirstOrDefault();

            return documento;
        }
    }
}
