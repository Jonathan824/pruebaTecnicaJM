// PruebaTecnica.Services/Services/UsuarioService.cs
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;
using PruebaTecnica.Services.Data;

namespace Services.Services
{
    public class UsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Usuario> ObtenerTodosUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario ObtenerUsuarioPorId(int usuarioId)
        {
            return _context.Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId);
        }

        public void AgregarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void EliminarUsuario(int usuarioId)
        {
            var usuario = _context.Usuarios.Find(usuarioId);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }
    }
}
