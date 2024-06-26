using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IDocumentoBusiness
    {
        public void CriarDocumento(WordViewModel word);
        public void EditarDocumento(WordViewModel word);
        public void ExcluirDocumento(WordViewModel word);
        public List<WordViewModel> ListarDocumento();
        public WordViewModel ObterDocumentoPorId(int id);
    }
}
