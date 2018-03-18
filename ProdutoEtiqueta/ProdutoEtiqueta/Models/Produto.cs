using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace DIego.Models
{
	[Table("produto")]
	public class Produto
	{
		public string Codigo { get; set; }
		public string UM { get; set; }
		public string Tipo { get; set; }
		public string Descricao { get; set; }

		//Foreign Key de etiquetas
		public  ICollection<Etiqueta> Etiquetas { get; set; }
	}
}
