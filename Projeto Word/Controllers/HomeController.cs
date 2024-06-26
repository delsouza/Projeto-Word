using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business;
using Infra.Context;
using Models;
using System.Diagnostics;
using Business.Interface;

namespace Projeto_Word.Controllers
{

    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDocumentoBusiness _documentoBusiness;

        public HomeController(IUnitOfWork unitOfWork, IDocumentoBusiness documentoBusiness)
        {
            _unitOfWork = unitOfWork;
            _documentoBusiness = documentoBusiness;
        }

        public IActionResult Index()
        {
            var documentos = _documentoBusiness.ListarDocumento();
            return View(documentos);
        }

        public IActionResult CriarDocumento()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarDocumento(WordViewModel documentoRecebido)
        {
            if (ModelState.IsValid)
            {
                _documentoBusiness.CriarDocumento(documentoRecebido); 
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(documentoRecebido);
            }
        }

        public IActionResult EditarDocument(int id)
        {
            var documento =  _documentoBusiness.ObterDocumentoPorId(id);
            return View(documento);
        }

        [HttpPost]
        public IActionResult EditarDocument(WordViewModel documentoEditado, int id)
        {
            if (ModelState.IsValid)
            {
                var documento =  _documentoBusiness.ObterDocumentoPorId(id);

                documento.Titulo = documentoEditado.Titulo;
                documento.Conteudo = documentoEditado.Conteudo;
                documento.DataAlteracao = DateTime.Now;

                _documentoBusiness.EditarDocumento(documento);
                _unitOfWork.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(documentoEditado);
            }
        }

        public IActionResult RemoverDocumento(int id)
        {
            var documento =  _documentoBusiness.ObterDocumentoPorId(id);

            _documentoBusiness.ExcluirDocumento(documento);
            _unitOfWork.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}