using System.ComponentModel.DataAnnotations.Schema;

namespace DIego.Models
{
	[Table("etiqueta")]
	public class Etiqueta
	{
		public string Codigo { get; set; }
		public int Quantidade { get; set; }
		public double Saldo { get; set; }

		//Foreign Key de produto
		public string ProdutoId { get; set; }
		//Produto refereciado por ProdutoID
		public Produto Produto { get; set; }

	}
}
