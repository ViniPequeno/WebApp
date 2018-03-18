using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIego.Models;
using Microsoft.AspNetCore.Mvc;

namespace DIego.Controllers
{
	[Route("api/produto")]
	public class ProdutoController : Controller
	{
		private readonly Context _context;
		public ProdutoController(Context context)
		{
			_context = context;
		}

		[HttpGet]
		public IEnumerable<Produto> GetAll()
		{
			return _context.Produtos.ToList();
		}

		[HttpGet("{Id}", Name = "GetProduto")]
		public IActionResult GetByCodigo(string codigo)
		{
			var item = _context.Produtos.FirstOrDefault(t => t.Codigo == codigo);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody] Produto produto)
		{
			if (produto == null)
			{
				return BadRequest();
			}
			_context.Produtos.Add(produto);
			_context.SaveChanges();
			return CreatedAtRoute("GetProduto", new { id = produto.Codigo }, produto);
		}

		[HttpPut("{id}")]
		public IActionResult Update(string codigo, [FromBody] Produto produto) 
		{
			if (produto == null || produto.Codigo!=codigo)
			{
				return BadRequest();
			}

			var _produto = _context.Produtos.FirstOrDefault(t => t.Codigo == codigo);
			if (_produto==null)
			{
				return NotFound();
			}

			_produto.UM = produto.UM;
			_produto.Tipo = produto.Tipo;
			_produto.Descricao = produto.Descricao;

			_context.Produtos.Update(_produto);
			_context.SaveChanges();
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(string codigo)
		{
			var produto = _context.Produtos.FirstOrDefault(t => t.Codigo.Equals(codigo));
			if(produto == null)
			{
				return NotFound();
			}
			_context.Produtos.Remove(produto);
			_context.SaveChanges();
			return new ContentResult();
		}
    }
}