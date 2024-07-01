using KR.Domain.Entities;
using KR.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Maslo.UI.Services
{
	public class MemoryProductService : IProductService
	{
		List<Kros> _kroses;
		List<Category> _categories;
		IConfiguration _config;

        //Внедрите в конструктор класса MemoryProductService объект IConfiguration:
        public MemoryProductService(ICategoryService categoryService, [FromServices] IConfiguration config)
		{
            _config = config;
            _categories = categoryService.GetCategoryListAsync().Result.Data;
			SetupData();
		}

		/// <summary>
		/// Инициализация списков
		/// </summary>
		private void SetupData()
		{
				_kroses = new List<Kros>
				{
						new Kros 
						{   KrosId = 1,
							KrosName="Кросс дет1мал",
							Description="Красно-синие, унисекс",
							Image="Images/кроссовки дет/Кросс дет1 мал.jpg",
							CategoryId= _categories.Find(c=>c.NormalizedName.Equals("child")).Id
						},

						new Kros
                        {   KrosId = 2,
							KrosName="Кросс дет2дев",
							Description="Розово-фиолетовые, унисекс",
							Image="Images/кроссовки дет/Кросс дет2 дев.jpg",
							CategoryId= _categories.Find(c=>c.NormalizedName.Equals("child")).Id
						},

						new Kros
                        {   KrosId = 3,
							KrosName="Кросс дет3бег",
							Description="Беговые, унисекс",
							Image="Images/кроссовки дет/Кросс дет3 бег.jpg",
							CategoryId= _categories.Find(c=>c.NormalizedName.Equals("child")).Id
						},

						new Kros
                        {   KrosId = 4,
							KrosName="Кросс жен1",
							Description="Светлые, для фитнеса",
							Image="Images/кроссовки жен/Кросс жен1.jpg",
							CategoryId= _categories.Find(c=>c.NormalizedName.Equals("woman")).Id
						},

						new Kros
                        {   KrosId = 5,
							KrosName="Кросс жен2",
							Description="Темные, для фитнеса",
							Image="Images/кроссовки жен/Кросс жен2.jpg",
							CategoryId= _categories.Find(c=>c.NormalizedName.Equals("woman")).Id
						},

						new Kros
                        {   KrosId = 6,
							KrosName="Кросс жен3бег",
							Description="Беговые, амортизируемые",
							Image="Images/кроссовки жен/Кросс жен3бег.jpg",
							CategoryId= _categories.Find(c=>c.NormalizedName.Equals("woman")).Id
						},

						new Kros
                        {   KrosId = 7,
							KrosName="Кросс муж1",
							Description="Светлые, для фитнеса",
							Image="Images/кроссовки муж/Кросс муж1.jpg",
							CategoryId= _categories.Find(c=>c.NormalizedName.Equals("man")).Id
						},

						new Kros
                        {   KrosId = 8,
							KrosName="Кросс жен2",
							Description="Темные, для фитнеса",
							Image="Images/кроссовки муж/Кросс муж2.jpg",
							CategoryId= _categories.Find(c=>c.NormalizedName.Equals("man")).Id
						},

						new Kros
                        {   KrosId = 9,
							KrosName="Кросс муж3бег",
							Description="Беговые, амортизируемые",
							Image="Images/кроссовки муж/Кросс муж3бег.jpg",
							CategoryId= _categories.Find(c=>c.NormalizedName.Equals("man")).Id
						},
				};
		}



        Task<ResponseData<ListModel<Kros>>> IProductService.GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
        {


            // Создать объект результата
            var result = new ResponseData<ListModel<Kros>>();

            // Id категории для фильрации
            int? categoryId = null;

            // если требуется фильтрация, то найти Id категории
            // с заданным categoryNormalizedName
            if (categoryNormalizedName != null)
                categoryId = _categories
                .Find(c =>
                c.NormalizedName.Equals(categoryNormalizedName))
                ?.Id;

            // Выбрать объекты, отфильтрованные по Id категории,
            // если этот Id имеется
            var data = _kroses
            .Where(d => categoryId == null || d.CategoryId.Equals(categoryId))?
            .ToList();

            // получить размер страницы из конфигурации
            int pageSize = _config.GetSection("ItemsPerPage").Get<int>();


            // получить общее количество страниц
            int totalPages = (int)Math.Ceiling(data.Count / (double)pageSize);

            // получить данные страницы
            var listData = new ListModel<Kros>()
            {
                Items = data.Skip((pageNo - 1) *
            pageSize).Take(pageSize).ToList(),
                CurrentPage = pageNo,
                TotalPages = totalPages
            };

            // поместить ранные в объект результата
            result.Data = listData;



            // Если список пустой
            if (data.Count == 0)
            {
                result.Success = false;
                result.ErrorMessage = "Нет объектов в выбраннной категории";
            }
            // Вернуть результат
            return Task.FromResult(result);

        }



        public Task<ResponseData<Kros>> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(int id, Kros product, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<Kros>> CreateProductAsync(Kros product, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }


    }
}
