using API.db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<simple_crudContext>(opt =>
{
    string connectionString = builder.Configuration.GetConnectionString("tarefasConnection");
    var serverVersion = ServerVersion.AutoDetect(connectionString);
    opt.UseMySql(connectionString, serverVersion);
});

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("api/simple_crud", (
    [FromServices] simple_crudContext _db,
    [FromQuery] string? nome
) => {
    var query = _db.Usuario.AsQueryable<Usuario>();

    if (!String.IsNullOrEmpty(nome))
    {
        query = query.Where(u => u.NmUsuario.Contains(nome));
    }

    var usuarios = query.ToList<Usuario>();

    return Results.Ok(usuarios);
});

app.MapGet("/api/simple_crud/{id}", (
    [FromServices] simple_crudContext _db,
    [FromRoute] int id
) => {
    var usuario = _db.Usuario.Find(id);

    if (usuario == null) return Results.NotFound();

    return Results.Ok(usuario);
});

app.MapPost("/api/usuarios", (
    [FromServices] simple_crudContext _db,
    [FromBody] Usuario novoUsuario
) => {
    if (String.IsNullOrEmpty(novoUsuario.NmUsuario) ||
        String.IsNullOrEmpty(novoUsuario.NrCpf) ||
        String.IsNullOrEmpty(novoUsuario.NrTelefone))
    {
        return Results.BadRequest(new { 
            mensagem = "Não é possível adicionar um novo usuário com dados faltantes."
        });
    }

    var usuario = new Usuario
    {
        NmUsuario = novoUsuario.NmUsuario,
        NrCpf = novoUsuario.NrCpf,
        NrTelefone = novoUsuario.NrTelefone
    };

    _db.Usuario.Add(usuario);
    _db.SaveChanges();

    var usuarioUrl = $"/api/usuario/{usuario.IdUsuario}";

    return Results.Created(usuarioUrl, usuario);
});

app.MapPut("/api/usuarios/{id}", (
    [FromServices] simple_crudContext _db,
    [FromRoute] int id,
    [FromBody] Usuario usuarioAlterado
) => {
    if (usuarioAlterado.IdUsuario != id)
    {
        return Results.BadRequest(new { mensagem = "Id inconsistente." });
    }

    if (String.IsNullOrEmpty(usuarioAlterado.NmUsuario) ||
        String.IsNullOrEmpty(usuarioAlterado.NrCpf) ||
        String.IsNullOrEmpty(usuarioAlterado.NrTelefone))
    {
        return Results.BadRequest(new { mensagem = "Não é possível atualizar um novo usuário com dados faltantes." });
    }

    var usuario = _db.Usuario.Find(id);

    if (usuario == null)
    {
        return Results.NotFound();
    }

    usuario.NmUsuario = usuarioAlterado.NmUsuario;
    usuario.NrCpf = usuarioAlterado.NrCpf;
    usuario.NrTelefone = usuarioAlterado.NrTelefone;

    _db.SaveChanges();

    return Results.Ok(usuario);
});

app.MapDelete("/api/usuarios/{id}", (
    [FromServices] simple_crudContext _db,
    [FromRoute] int id
) => {
    var usuario = _db.Usuario.Find(id);

    if (usuario == null)
    {
        return Results.NotFound();
    }

    _db.Usuario.Remove(usuario);
    _db.SaveChanges();

    return Results.Ok();
});

app.Run();
