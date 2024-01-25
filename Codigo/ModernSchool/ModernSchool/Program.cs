using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;
using Microsoft.AspNetCore.Identity;
using ModernSchoolWEB.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using ModernSchoolWEB.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using ModernSchoolWEB.Service;

namespace ModernSchoolWEB
{
    public class Program
    {
        public static async Task Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ModernSchoolContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("ModernSchoolDatabase")));
            builder.Services.AddDbContext<IdentityContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("ModernSchoolDatabase")));

            builder.Services.AddIdentity<UsuarioIdentity, IdentityRole>(options =>
            {
                // SignIn settings
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;

                // Default User settings.
                options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

                // Default Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            }).AddEntityFrameworkStores<IdentityContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.Cookie.Name = "YourAppCookieName";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Identity/Account/Login";
                // ReturnUrlParameter requires 
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });


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
            builder.Services.AddTransient<IDiarioDeClasseService, DiarioDeClasseService>();
            builder.Services.AddTransient<IEscolaService, EscolaService>();
            //builder.Services.AddTransient<IFrequenciaService, FrequenciaService>();
            builder.Services.AddTransient<IGradeHorarioService, GradeHorarioService>();
            //builder.Services.AddTransient<IHabilidadeService, HabilidadeService>();
            //builder.Services.AddTransient<IObjetoDeConhecimentoService, ObjetoDeConhecimentoService>();
            builder.Services.AddTransient<IGovernoServidorService, GovernoServidorService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddTransient<IAlunoAvaliacaoService, AlunoAvaliacaoService>();
            builder.Services.AddTransient<IFrequenciaAlunoService, FrequenciaAlunoService>();
            
            
            builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
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
            await CriarPerfilUsuarioAsync(app);
            app.UseAuthentication(); ;

            app.UseAuthorization();

            //app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();


            async Task CriarPerfilUsuarioAsync(WebApplication app)
            {
                var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

                using (var scope = scopedFactory.CreateScope())
                {
                    var service = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();
                    await service.SeedRolesAsync();
                    await service.SeedUsersAsync();
                }
            }
        }


    }
}
