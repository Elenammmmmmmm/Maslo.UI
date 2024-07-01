using KR.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maslo.API.Data;

	public static class DbInitializer
{
	public static async Task SeedData(WebApplication app)
{
        // Uri проекта
        var uri = "https://localhost:7002/";
        // Получение контекста БД
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        //Выполнение миграций
        await context.Database.MigrateAsync();

        // Заполнение данными
        if (!context.Categories.Any() && !context.Kros.Any())
		{
			var _categories = new Category[]
			{
				new Category {GroupName="детские",NormalizedName="child"},
				new Category {GroupName="женские",NormalizedName="woman"},
				new Category {GroupName="мужские",NormalizedName="man"},

			};
			await context.Categories.AddRangeAsync(_categories);
			await context.SaveChangesAsync();


			var kroses = new List<Kros>
			{
				
                    new Kros
                        {   
                            KrosName="Кросс дет1мал",
                            Description="Красно-синие, унисекс",
                            Image=uri +"Images/кроссовки дет/Кросс дет1 мал.jpg",
                            Category= _categories.FirstOrDefault(c=>c.NormalizedName.Equals("child"))
                        },

                        new Kros
                        {  
                            KrosName="Кросс дет2дев",
                            Description="Розово-фиолетовые, унисекс",
                            Image=uri +"Images/кроссовки дет/Кросс дет2 дев.jpg",
                            Category= _categories.FirstOrDefault(c=>c.NormalizedName.Equals("child"))
                        },

                        new Kros
                        {   
                            KrosName="Кросс дет3бег",
                            Description="Беговые, унисекс",
                            Image=uri +"Images/кроссовки дет/Кросс дет3 бег.jpg",
                            Category= _categories.FirstOrDefault(c=>c.NormalizedName.Equals("child"))
                        },

                        new Kros
                        {   
                            KrosName="Кросс жен1",
                            Description="Светлые, для фитнеса",
                            Image=uri + "Images/кроссовки жен/Кросс жен1.jpg",
                            Category= _categories.FirstOrDefault(c=>c.NormalizedName.Equals("woman"))
                        },

                        new Kros
                        {   
                            KrosName="Кросс жен2",
                            Description="Темные, для фитнеса",
                            Image=uri + "Images/кроссовки жен/Кросс жен2.jpg",
                            Category= _categories.FirstOrDefault(c=>c.NormalizedName.Equals("woman"))
                        },

                        new Kros
                        {   
                            KrosName="Кросс жен3бег",
                            Description="Беговые, амортизируемые",
                            Image=uri + "Images/кроссовки жен/Кросс жен3бег.jpg",
                            Category= _categories.FirstOrDefault(c=>c.NormalizedName.Equals("woman"))
                        },

                        new Kros
                        {   
                            KrosName="Кросс муж1",
                            Description="Светлые, для фитнеса",
                            Image=uri + "Images/кроссовки муж/Кросс муж1.jpg",
                            Category= _categories.FirstOrDefault(c=>c.NormalizedName.Equals("man"))
                        },

                        new Kros
                        {   
                            KrosName="Кросс жен2",
                            Description="Темные, для фитнеса",
                            Image=uri + "Images/кроссовки муж/Кросс муж2.jpg",
                            Category= _categories.FirstOrDefault(c=>c.NormalizedName.Equals("man"))
                        },

                        new Kros
                        {  
                            KrosName="Кросс муж3бег",
                            Description="Беговые, амортизируемые",
                            Image=uri + "Images/кроссовки муж/Кросс муж3бег.jpg",
                            Category= _categories.FirstOrDefault(c=>c.NormalizedName.Equals("man"))
                        },
            };
			await context.Kros.AddRangeAsync(kroses);
			await context.SaveChangesAsync();
		}
	}

}

