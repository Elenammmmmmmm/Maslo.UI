using KR.Domain.Entities;
using KR.Domain.Models;

namespace Maslo.UI.Services
{
	public class MemoryCategoryService : ICategoryService
	{
		public Task<ResponseData<List<Category>>>GetCategoryListAsync()
		{
			{
				var categories = new List<Category>
				{
					new Category {Id=1, GroupName="детские",NormalizedName="child"},
					new Category {Id=2, GroupName="женские",NormalizedName="woman"},
					new Category {Id=3, GroupName="мужские",NormalizedName="man"},
				};

				var result = new ResponseData<List<Category>>();
				result.Data = categories;
				return Task.FromResult(result);
			}
		}
	}
}

