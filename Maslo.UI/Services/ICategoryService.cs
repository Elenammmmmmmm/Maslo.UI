using KR.Domain.Entities;
using KR.Domain.Models;

namespace Maslo.UI.Services
{
	public interface ICategoryService
	{
		/// <summary>
		/// Получение списка всех категорий
		/// </summary>
		/// <returns></returns>
		public Task<ResponseData<List<Category>>> GetCategoryListAsync();
	}
}
