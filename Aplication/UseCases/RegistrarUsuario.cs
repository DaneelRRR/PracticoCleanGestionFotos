using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Aplication.UseCases
{
    public class RegistrarUsuario
    {
        private readonly IUsuario _usuarioRepositorie;

        public RegistrarUsuario(IUsuario usuarioRepositorie)
        {
            _usuarioRepositorie = usuarioRepositorie;
        }

        public async Task EjecutarAsync(Usuario usuario)
        {
            ValidarUsuario(usuario);
            await _usuarioRepositorie.Crear(usuario);
        }

        public void ValidarUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new ArgumentException("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(usuario.Email) || !usuario.Email.Contains("@"))
                throw new ArgumentException("Debe ingresar un email válido.");

            if (string.IsNullOrWhiteSpace(usuario.Password) || usuario.Password.Length < 4)
                throw new ArgumentException("La contraseña debe tener al menos 4 caracteres.");
        }
    }
}
