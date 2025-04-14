using AppLojaVirtual.Data;
using AppLojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppLojaVirtual.Controllers
{
    //[Authorize]
    [Route("meus-produtos")]
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //[AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return _context.Produto != null ?
                View(await _context.Produto.ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Produto'  is null.");
        }

        [Route("detalhes/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            if (_context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [Route("novo")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Preco,QuantidadeEstoque,Categoria,ImagemUrl")] Produto produto, IFormFile imagem)
        {
            if (ModelState.IsValid)
            {
                if (imagem != null && imagem.Length > 0)
                {
                    var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens");
                    if (!Directory.Exists(caminhoPasta))
                        Directory.CreateDirectory(caminhoPasta);

                    var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(imagem.FileName);
                    var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                    using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                    {
                        await imagem.CopyToAsync(stream);
                    }

                    produto.ImagemUrl = "/imagens/" + nomeArquivo;
                }

                _context.Add(produto);
                await _context.SaveChangesAsync();

                TempData["Sucesso"] = "Produto cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }

        [Route("editar/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            if (_context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost("editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Nome,Descricao,Preco,QuantidadeEstoque,Categoria,ImagemUrl")] Produto produto, IFormFile? imagem)
        {
            if (id != produto.Id)
                return NotFound();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState)
                {
                    foreach (var error in modelState.Value.Errors)
                    {
                        Console.WriteLine($"Erro no campo {modelState.Key}: {error.ErrorMessage}");
                    }
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var produtoExistente = await _context.Produto.FindAsync(id);

                    if (produtoExistente == null)
                        return NotFound();

                    // Atualiza os campos básicos
                    produtoExistente.Nome = produto.Nome;
                    produtoExistente.Descricao = produto.Descricao;
                    produtoExistente.Preco = produto.Preco;
                    produtoExistente.QuantidadeEstoque = produto.QuantidadeEstoque;
                    produtoExistente.Categoria = produto.Categoria;

                    // Se houver uma nova imagem, substitui a anterior
                    if (imagem != null && imagem.Length > 0)
                    {
                        var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens");
                        if (!Directory.Exists(caminhoPasta))
                            Directory.CreateDirectory(caminhoPasta);

                        var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(imagem.FileName);
                        var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                        using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                        {
                            await imagem.CopyToAsync(stream);
                        }

                        produtoExistente.ImagemUrl = "/imagens/" + nomeArquivo;
                    }

                    await _context.SaveChangesAsync();

                    TempData["Sucesso"] = "Produto editado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
                        return NotFound();
                    else
                        throw;
                }
            }

            // Retorna o produto já existente com ImagemUrl preservado, caso haja erro de validação
            var produtoComImagem = await _context.Produto.FindAsync(id);
            return View(produtoComImagem);
        }

        [Route("Excluir/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost("Excluir/{id:int}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produto == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Produto'  is null.");
            }
            var produto = await _context.Produto.FindAsync(id);
            if (produto != null)
            {
                _context.Produto.Remove(produto);

                TempData["Sucesso"] = "Produto excluído com sucesso!";
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int? id)
        {
            return _context.Produto.Any(e => e.Id == id);
        }
    }
}
