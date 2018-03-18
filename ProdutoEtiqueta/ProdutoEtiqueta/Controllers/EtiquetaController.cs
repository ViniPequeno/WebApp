using DIego.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DIego.Controllers
{
	[Route("api/etiqueta")]
	public class EtiquetaController : Controller
	{
		private readonly Context _context;

		public EtiquetaController(Context context)
		{
			_context = context;
		}

		[HttpGet]
		public IEnumerable<Etiqueta> GetAll()
		{
			return _context.Etiquetas.ToList();
		}

		[HttpGet("{Id}", Name = "GetEtiqueta")]
		public IActionResult GetByCodigo(string codigo)
		{
			var item = _context.Etiquetas.FirstOrDefault(t => t.Codigo == codigo);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody] Etiqueta etiqueta)
		{
			if (etiqueta == null)
			{
				return BadRequest();
			}
			
			_context.Etiquetas.Add(etiqueta);
			_context.SaveChanges();
			return CreatedAtRoute("GetEtiqueta", new { id = etiqueta.Codigo }, etiqueta);

			
		}

		[HttpPut("{id}")]
		public IActionResult Update(string codigo, [FromBody] Etiqueta etiqueta)
		{
			if (etiqueta == null || etiqueta.Codigo != codigo)
			{
				return BadRequest();
			}

			var _etiqueta = _context.Etiquetas.FirstOrDefault(t => t.Codigo == codigo);
			if (_etiqueta == null)
			{
				return NotFound();
			}
			_etiqueta.Quantidade = etiqueta.Quantidade;
			_etiqueta.Saldo = etiqueta.Saldo;
			_context.Etiquetas.Update(_etiqueta);
			_context.SaveChanges();
			return new NoContentResult();
			
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(string codigo)
		{
			var etiqueta = _context.Etiquetas.FirstOrDefault(t => t.Codigo.Equals(codigo));
			if (etiqueta == null)
			{
				return NotFound();
			}
			_context.Etiquetas.Remove(etiqueta);
			_context.SaveChanges();
			return new ContentResult();
		}
	}
}