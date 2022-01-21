using DietForYou.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietForYou.Services
{
    public interface IHistoricoUsersDadosService
    {
         Task<IEnumerable<HistoricoUsersDados>> GetHistoricoUserDados();

         Task<HistoricoUsersDados> GetHistoricoUserDados(int id);

         Task InsertHistoricoUserDados(HistoricoUsersDados historicoUsersDados);

         Task UpdateHistoricoUserDados(HistoricoUsersDados historicoUsersDados);

         Task DeleteHistoricoUserDados(HistoricoUsersDados historicoUsersDados);

         Task CalculoTmb(HistoricoUsersDados historicoUsersDados);

    }
}
