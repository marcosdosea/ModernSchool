using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ModernSchoolContext>(
    options => options.UseMySQL(builder.Configuration.GetConnectionString("ModernSchoolDatabase")));

builder.Services.AddTransient<IPeriodoService, PeriodoService>();
//Observacao: só tirar o comentario do que vai implementar
//builder.Services.AddTransient<IDiarioDeClasseService, DiarioDeClasseService>();
//builder.Services.AddTransient<IComunicacaoService, ComunicacaoService>();
//builder.Services.AddTransient<IComponenteService, ComponenteService>();
//builder.Services.AddTransient<IAutenticarService, AutenticarService>();
//builder.Services.AddTransient<IPresencaService, PresencaService>();
//builder.Services.AddTransient<IGradeHorarioService, GradeHorarioService>();
//builder.Services.AddTransient<IEscolaService, EscolaService>();
//builder.Services.AddTransient<IPrefeituraService, PrefeituraService>();
//builder.Services.AddTransient<IServidorService, ServidorService>();
//builder.Services.AddTransient<ICurriculoService, CurriculoService>();
//builder.Services.AddTransient<IProfessorService, ProfessorService>();*/

//TODO: Organize essa bagunça


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Add services to the container.
builder.Services.AddControllersWithViews();

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
