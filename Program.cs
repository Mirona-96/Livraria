using Livraria.Models.Domain;
using Livraria.Repositories.Abstract;
using Livraria.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Livraria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add editoraServices to the container.
            builder.Services.AddControllersWithViews();

            //adciona conexao com a BD
            builder.Services.AddDbContext<LivrariaDbContext>(options =>
            options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Adiciona as interfaces com as implementacoes
            builder.Services.AddScoped<IGeneroServices,GeneroServices>();
            builder.Services.AddScoped<IAutorServices,AutorServices>();
            builder.Services.AddScoped<IEditoraServices,EditoraServices>();
            builder.Services.AddScoped<IBookServices,LivroServices>();

/*            builder.Services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
        .AddDataAnnotationsLocalization(options =>
        {
            options.DataAnnotationLocalizerProvider = (type, factory) =>
                factory.Create(typeof(SharedResources));
        })
        .AddMvcOptions(options =>
        {
            options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                _ => "O campo é obrigatório.");
        })
        .SetCompatibilityVersion(CompatibilityVersion.Latest);*/

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Livro}/{action=GetAll}/{id?}");

            app.Run();
        }
    }
}