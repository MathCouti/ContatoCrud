using Microsoft.AspNetCore.Mvc;

namespace PraticaWeb
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _repositorio; 
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _repositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            var contatos = _repositorio.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato Cadastrado com sucesso";
                    return RedirectToAction(nameof(Index));  
                }
                    return View(contato);
            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro no cadastro";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id)
        {
            var contato = _repositorio.ListarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Editar", contato);
                }
                _repositorio.Atualizar(contato);
                TempData["MensagemSucesso"] = "Contato Atualizado com sucesos!";
                return RedirectToAction(nameof(Index));

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = "Não foi possivel atualizar o contato!";
                return RedirectToAction("Index");
            }
        }
        public IActionResult ApagarConfirmacao(int id) 
        {
            var contato = _repositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _repositorio.Apagar(id);
                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesos!";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possivel apagar o contato!";
                }
                return RedirectToAction(nameof(Index));
            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = "Não foi possivel apagar o contato!";
                return RedirectToAction("Index");
            }
        }
    }
}
