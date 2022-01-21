using DietForYou.Data;
using DietForYou.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietForYou.Services
{
    public class HistoricoUsersDadosService : IHistoricoUsersDadosService
    {
        private readonly AppDbContext _context;

        public HistoricoUsersDadosService(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<HistoricoUsersDados>> GetHistoricoUserDados()
        {
            try
            {
                return await _context.HistoricoUsersDados.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<HistoricoUsersDados> GetHistoricoUserDados(int id)
        {
            var historicoUserDados = await _context.HistoricoUsersDados.FindAsync(id);
            return historicoUserDados;
        }

        public async Task InsertHistoricoUserDados(HistoricoUsersDados historicoUsersDados)
        {
            _context.HistoricoUsersDados.Add(historicoUsersDados);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHistoricoUserDados(HistoricoUsersDados historicoUsersDados)
        {
            _context.Entry(historicoUsersDados).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHistoricoUserDados(HistoricoUsersDados historicoUsersDados)
        {
            _context.HistoricoUsersDados.Remove(historicoUsersDados);
            await _context.SaveChangesAsync();
        }

        public async Task CalculoTmb(HistoricoUsersDados historicoUsersDados)
        {  
            //TMB Mulher = 655 + (9, 6 * P) + (1, 8 * A) – (4, 7 * I)
            //TMB Homem = 66 + (13, 7 * P) + (5 * A) – (6, 8 * I)
            try
            {
                if (historicoUsersDados.IdSexo == 1)
                {
                    historicoUsersDados.Tmb = 66 + (13.7 * historicoUsersDados.Peso) + (5 * historicoUsersDados.Altura) - (6.8 * historicoUsersDados.Idade);
                    _context.HistoricoUsersDados.Add(historicoUsersDados);
                    await _context.SaveChangesAsync();
                }
                else if (historicoUsersDados.IdSexo == 2)
                {
                    historicoUsersDados.Tmb = 655 + (9.6 * historicoUsersDados.Peso) + (1.8 * historicoUsersDados.Altura) - (4.7 * historicoUsersDados.Idade);
                    _context.HistoricoUsersDados.Add(historicoUsersDados);
                    await _context.SaveChangesAsync();
                }
            }
            catch 
            {
                throw;
            }
        }
    }
}
