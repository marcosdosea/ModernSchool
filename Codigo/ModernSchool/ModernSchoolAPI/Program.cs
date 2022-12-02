using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;

namespace ModernSchoolAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ModernSchoolContext>(
                            options => options.UseMySQL(builder.Configuration.GetConnectionString("ModernSchoolDatabase")));

            //builder.Services.AddTransient<IPeriodoService, PeriodoService>();
            //builder.Services.AddTransient<IComponenteService, ComponenteService>();
            //builder.Services.AddTransient<ICurriculoService, CurriculoService>();
            //builder.Services.AddTransient<IAvaliacaoService, AvaliacaoService>();
            //builder.Services.AddTransient<ICargoService, CargoService>();
            //builder.Services.AddTransient<IGovernoService, GovernoService>();
            //builder.Services.AddTransient<IPessoaService, PessoaService>();
            //builder.Services.AddTransient<ITurmaService, TurmaService>();
            //builder.Services.AddTransient<IUnidadeTematicaService, UnidadeTematicaService>();
            //builder.Services.AddTransient<IComunicacaoService, ComunicacaoService>();
            //builder.Services.AddTransient<IDiarioDeClasseService, DiarioDeClasseService>();
            //builder.Services.AddTransient<IEscolaService, EscolaService>();
            //builder.Services.AddTransient<IFrequenciaService, FrequenciaService>();
            //builder.Services.AddTransient<IGradeHorarioService, GradeHorarioService>();
            builder.Services.AddTransient<IAnoLetivoService, AnoLetivoService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }

}

