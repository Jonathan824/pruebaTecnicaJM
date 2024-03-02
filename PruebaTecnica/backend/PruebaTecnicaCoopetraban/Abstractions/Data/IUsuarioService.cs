// PruebaTecnica.Abstractions/Services/IUsuarioService.cs
using System.Collections.Generic;
using PruebaTecnica.Models;

namespace PruebaTecnica.Abstractions.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> ObtenerTodosUsuarios();
        Usuario ObtenerUsuarioPorId(int id);
        void AgregarUsuario(Usuario usuario);
        void ActualizarUsuario(Usuario usuario);
        void EliminarUsuario(int id);
    }
}
