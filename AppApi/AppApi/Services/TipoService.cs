using AppApi.Context;
using AppApi.Models;
using AppApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppApi.Services
{
    public class TipoService : IGenericService<Tipo>
    {
        private readonly AppApiContext _context;

        public TipoService(AppApiContext context)
        {
            _context = context;
        }

        public async Task<Tipo?> Buscar(int id)
        {
            try
            {
                var tipo = await _context.Tipos.SingleOrDefaultAsync(t => id == t.Idtipo);
                return tipo;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IQueryable<Tipo>> Consultar()
        {
            return _context.Tipos;
        }

        public async Task<bool> Editar(Tipo entity, int id)
        {
            try
            {
                var tipo = await _context.Tipos.SingleOrDefaultAsync(t => id == t.Idtipo);

                if (tipo == null)
                    return false;

                if (entity.Idtipo != id)
                    return false;

                _context.Entry(tipo).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var tipo = await _context.Tipos.SingleOrDefaultAsync(t => id == t.Idtipo);

                if (tipo == null)
                    return false;

                _context.Tipos.Remove(tipo);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Registrar(Tipo entity)
        {
            try
            {
                await _context.Tipos.AddAsync(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
