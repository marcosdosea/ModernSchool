using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;

namespace ModernSchoolWEB
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ModernSchoolContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("ModernSchoolDatabase")));
            builder.Services.AddTransient<IPeriodoService, PeriodoService>();
            builder.Services.AddTransient<IComponenteService, ComponenteService>();
            builder.Services.AddTransient<ICurriculoService, CurriculoService>();
            builder.Services.AddTransient<IAvaliacaoService, AvaliacaoService>();
            builder.Services.AddTransient<ICargoService, CargoService>();
            builder.Services.AddTransient<IGovernoService, GovernoService>();
            builder.Services.AddTransient<IPessoaService, PessoaService>();
            builder.Services.AddTransient<ITurmaService, TurmaService>();
            builder.Services.AddTransient<IUnidadeTematicaService, UnidadeTematicaService>();
            builder.Services.AddTransient<IAnoLetivoService, AnoLetivoService>();
            builder.Services.AddTransient<IComunicacaoService, ComunicacaoService>();
            //builder.Services.AddTransient<IDiarioDeClasseService, DiarioDeClasseService>();
            builder.Services.AddTransient<IEscolaService, EscolaService>();
            //builder.Services.AddTransient<IFrequenciaService, FrequenciaService>();
            //builder.Services.AddTransient<IGradeHorarioService, GradeHorarioService>();
            //builder.Services.AddTransient<IHabilidadeService, HabilidadeService>();
            //builder.Services.AddTransient<IObjetoDeConhecimentoService, ObjetoDeConhecimentoService>();
            builder.Services.AddTransient<IGovernoServidorService, GovernoServidorService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
