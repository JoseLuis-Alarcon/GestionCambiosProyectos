using ArquitecturaLimpia.Dominio.Entidades;
using ArquitecturaLimpia.Dominio.Interfaces;
using ArquitecturaLimpiaApp.Dominio.Entidades;
using ArquitecturaLimpiaApp.Dominio.Interfaces;
using ArquitecturaLimpiaAPP.Infraestructura.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquitecturaLimpia.Infraestructura.Repositorios
{
    public class UsuarioRolRepositorio : IUsuarioRol
    {
        private readonly AppDbContext _appdbContext;

        public Task<UsuarioRol> CrearAsync(UsuarioRol rol)
        {
            throw new NotImplementedException();
        }

        public Task ActualizarAsync(UsuarioRol usuariorol)
        {
            throw new NotImplementedException();
        }

        public Task EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioRol> ListaPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioRol>> ObtenerTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
