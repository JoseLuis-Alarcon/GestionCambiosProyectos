//Crear configuración
using ArquitecturaLimpia.Dominio.Entidades;
using ArquitecturaLimpia.Infraestructura;
using ArquitecturaLimpiaApp.Dominio.Entidades;
using ArquitecturaLimpiaAPP.Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var configuracion = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var opciones = new DbContextOptionsBuilder<AppDbContext>();
opciones.UseSqlServer(configuracion.GetConnectionString("ConexionDB"));

using (var contexto = new AppDbContext(opciones.Options))
{
    //Conexión a la Base de Datos
    await contexto.Database.EnsureCreatedAsync();

    using (var unidadDeTrabajo = new UnidadDeTrabajo(contexto))
    {
        //Insertar Rol
        Console.WriteLine("Ingrese los datos del rol: ");
        var rol = new Rol
        {
            Nombre = ObtenerEntradaTeclado("Nombre: "),
            Descripcion = ObtenerEntradaTeclado("Descripción")
        };
        unidadDeTrabajo.Roles.CrearAsync(rol);
        unidadDeTrabajo.GrabarCambiosAsync();
        Console.WriteLine("Rol grabado correctamente");

        //Listar los roles
        var roles = await unidadDeTrabajo.Roles.ObtenerTodosAsync();
        Console.WriteLine("Lista de roles existentes:");
        foreach(var e_rol  in roles)
        {
            Console.WriteLine($"{rol.Nombre} - {rol.Descripcion}");
        }

        //


        /*
              Console.WriteLine("Ingrese los datos del usuario:");

               var usuario = new Usuario
               {
                   Nombre = ObtenerEntradaTeclado("Nombre"),
                   CorreoElectronico = ObtenerEntradaTeclado("Correo Electronico"),
                   Contraseña = ObtenerEntradaTeclado("Contraseña")
               };

               await unidadDeTrabajo.Usuarios.CrearAsync(usuario);
               await unidadDeTrabajo.GrabarCambiosAsync();
               Console.WriteLine("Usuario grabado correctamente en la Base de Datos");

               //Listar usuarios registrados
               var usuarios = await unidadDeTrabajo.Usuarios.ObtenerTodosAsync();
               Console.WriteLine("Lista de usuarios:");
               foreach (var ousuario in usuarios)
               {
                   Console.WriteLine($"ID:{ousuario.Id}, Nombre:{ousuario.Nombre}, Email:{ousuario.CorreoElectronico}");
               }

               //Eliminar un usuario
               Console.WriteLine("Ingrese el ID del usuario a eliminar:");
               if (int.TryParse(Console.ReadLine(), out int usuarioId))
               {
                   await unidadDeTrabajo.Usuarios.EliminarAsync(usuarioId);
                   await unidadDeTrabajo.GrabarCambiosAsync();
                   Console.WriteLine("Usuario eliminado correctamente:");

               }
          */
    }
}
string ObtenerEntradaTeclado(string mensaje)
{
    Console.Write($"{mensaje}: ");
    return Console.ReadLine();
}




