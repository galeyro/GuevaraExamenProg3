using GuevaraExamenProg3.Interfaces;
using GuevaraExamenProg3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuevaraExamenProg3.Models;

namespace GuevaraExamenProg3.Services
{
    public class RecetaService : IRecetaService
    {
        //conectar sqlite
        private readonly string _dbPath = Path.Combine(FileSystem.AppDataDirectory, "recetas.db3");
        private readonly string _logPath = Path.Combine(FileSystem.AppDataDirectory, "Logs_Guevara.txt");
        private SQLiteAsyncConnection _connection;

        //iniciar connection
        private async Task InitAsync()
        {
            if (_connection != null) { return; }

            _connection = new SQLiteAsyncConnection(_dbPath);
            await _connection.CreateTableAsync<Receta>();
        }

        //obtener logs async
        public async Task<List<string>> GetLogsAsync()
        {
            if (File.Exists(_logPath))
            {
                return new List<string>(await File.ReadAllLinesAsync(_logPath));
            }
            return new List<string>();
        }
        
        //obtener recetas async
        public async Task<List<Receta>> GetRecetasAsync()
        {
            await InitAsync();

            return await _connection.Table<Receta>().ToListAsync();
        }

        //guardar recetas async
        public async Task<bool> GuardarRecetaAsync(Receta receta)
        {
            //regla
            if (receta.TiempoPreparacionMinutos>180 && !receta.EsVegetariana)
            {
                return false;
            }

            await _connection.InsertAsync(receta);

            string log = $"Se incluyo el registro {receta.Nombre} el {DateTime.Now:dd/MM/yyyy hh:mm}\n";

            await File.AppendAllTextAsync(_logPath, log);

            return true;
        }
    }
}
