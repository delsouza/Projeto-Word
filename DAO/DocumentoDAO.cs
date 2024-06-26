using Microsoft.EntityFrameworkCore;
using Infra.Context;
using Models;
using DAO.Interface;

namespace DAO
{
    //public class DocumentoDAO : IDocumentoDAO<WordViewModel>

    public class DocumentoDAO : BaseDAO<WordViewModel>, IDocumentoDAO
    {
        private readonly ApplicationDbContext _db;

        public DocumentoDAO(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

    }
}
