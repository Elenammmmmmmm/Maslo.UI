using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Domain.Entities
{
	public class Kros
	{
		[Key]
		public int KrosId { get; set; } // id блюда
		public string KrosName { get; set; } // название блюда
		public string Description { get; set; } // описание блюда

		public string? Image { get; set; } // имя файла изображения 

		// Навигационные свойства
		public int CategoryId { get; set; }
		public Category? Category { get; set; }
	}
}

