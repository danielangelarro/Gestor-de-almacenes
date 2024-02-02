using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Entities;
using GestorDeAlmacenes.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorDeAlmacenes.Infrastructure.Repositories
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly GestorDeAlmacenesDBContext _context;
        private readonly DateTimeProvider _dateTimeProvider;

        public MovimientoRepository(GestorDeAlmacenesDBContext context)
        {
            _context = context;
            _dateTimeProvider = new DateTimeProvider();
        }

        #region Entradas

        public async Task AddEntradaAsync(Movimientos entrada)
        {
            entrada.Tipo = "entrada";

            if (await _context.Movimientos.Where(u => 
                u.ID_Producto == entrada.ID_Producto && u.ID_Usuario == entrada.ID_Usuario && u.ID_Proveedor == entrada.ID_Proveedor &&
                u.Fecha == entrada.Fecha && u.Fecha_Caducidad == entrada.Fecha_Caducidad
                ).FirstOrDefaultAsync() is Movimientos entrada_exist)
            {
                entrada_exist.Cantidad += entrada.Cantidad;
                
                _context.Movimientos.Update(entrada_exist);
            }
            else
            {
                await _context.Movimientos.AddAsync(entrada);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntradaAsync(Movimientos entrada)
        {
            _context.Movimientos.Remove(entrada);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Movimientos>> GetAllEntradasAsync()
        {
            return await _context.Movimientos.Where(e => e.Tipo == "entrada").ToListAsync();
        }

        public async Task<Movimientos?> GetEntradaByIdAsync(Guid id)
        {
            if (await _context.Movimientos.FindAsync(id) is Movimientos entrada && entrada.Tipo == "entrada")
            {
                return entrada;
            }

            return null;
        }

        public async Task UpdateEntradaAsync(Movimientos entrada)
        {
            entrada.Tipo = "entrada";

            _context.Movimientos.Update(entrada);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Salida
        
        public async Task AddSalidaAsync(Movimientos salida)
        {
            salida.Tipo = "salida";

            await _context.Movimientos.AddAsync(salida);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSalidaAsync(Movimientos salida)
        {
            _context.Movimientos.Remove(salida);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Movimientos>> GetAllSalidasAsync()
        {
            return await _context.Movimientos.Where(e => e.Tipo == "salida").ToListAsync();
        }

        public async Task<Movimientos> GetSalidaByIdAsync(Guid id)
        {
            if (await _context.Movimientos.FindAsync(id) is Movimientos salida && salida.Tipo == "salida")
            {
                return salida;
            }

            return null;
        }

        public async Task UpdateSalidaAsync(Movimientos salida)
        {
            salida.Tipo = "salida";

            _context.Movimientos.Update(salida);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Merma

        public async Task AddMermaAsync(Movimientos merma)
        {
            merma.Tipo = "merma";

            await _context.Movimientos.AddAsync(merma);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMermaAsync(Movimientos merma)
        {
            _context.Movimientos.Remove(merma);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Movimientos>> GetAllMermasAsync()
        {
            return await _context.Movimientos.Where(e => e.Tipo == "merma").ToListAsync();
        }

        public async Task<Movimientos> GetMermaByIdAsync(Guid id)
        {
            if (await _context.Movimientos.FindAsync(id) is Movimientos merma && merma.Tipo == "merma")
            {
                return merma;
            }

            return null;
        }

        public async Task UpdateMermaAsync(Movimientos merma)
        {
            merma.Tipo = "merma";

            _context.Movimientos.Update(merma);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Reportes

        public async Task<ICollection<Movimientos>> GetAllAsync()
        {
            return await _context.Movimientos.ToListAsync();
        }

        public async Task<ICollection<float>> GetAllGananciasMensualAsync()
        {
            var gananciasMensuales = new List<float>();
            var anio_actual = _dateTimeProvider.UtcNow.Year;
            
            for (int i = 1; i <= 12; i++)
            {
                var gananciasDelMes = await _context.Movimientos
                    .Where(m => m.Fecha.Year == anio_actual && m.Fecha.Month == i)
                    .SumAsync(m => m.Tipo == "salida" ? m.Precio_Unidad * m.Cantidad : -m.Precio_Unidad * m.Cantidad);
            
                gananciasMensuales.Add(gananciasDelMes);
            }

            return gananciasMensuales;
        }
        
        public async Task<ICollection<int>> GetAllEntradasMensualAsync()
        {
            var salidasMensuales = new List<int>();
            var anio_actual = _dateTimeProvider.UtcNow.Year;
            
            for (int i = 1; i <= 12; i++)
            {
                var salidasDelMes = await _context.Movimientos
                    .Where(m => m.Fecha.Year == anio_actual && m.Fecha.Month == i && m.Tipo == "entrada")
                    .CountAsync();
            
                salidasMensuales.Add(salidasDelMes);
            }

            return salidasMensuales;
        }

        public async Task<ICollection<int>> GetAllSalidasMensualAsync()
        {
            var salidasMensuales = new List<int>();
            var anio_actual = _dateTimeProvider.UtcNow.Year;
            
            for (int i = 1; i <= 12; i++)
            {
                var salidasDelMes = await _context.Movimientos
                    .Where(m => m.Fecha.Year == anio_actual && m.Fecha.Month == i && m.Tipo == "salida")
                    .CountAsync();
            
                salidasMensuales.Add(salidasDelMes);
            }

            return salidasMensuales;
        }

        public async Task<float> GetGananciaSemanal()
        {
            // Obtenemos la fecha actual
            var hoy = _dateTimeProvider.UtcNow;

            // Creamos una cultura que comienza la semana en domingo
            var cultureInfo = new System.Globalization.CultureInfo("es-ES");
            cultureInfo.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Sunday;

            // Obtenemos el número de semana actual
            var calendar = cultureInfo.Calendar;
            var semanaActual = calendar.GetWeekOfYear(hoy, cultureInfo.DateTimeFormat.CalendarWeekRule, DayOfWeek.Sunday);

            // Traemos los datos a la memoria
            var movimientos = await _context.Movimientos.ToListAsync();

            // Calculamos el gasto semanal
            var gastoSemanal = movimientos
                .Where(m => calendar.GetWeekOfYear(m.Fecha, cultureInfo.DateTimeFormat.CalendarWeekRule, DayOfWeek.Sunday) == semanaActual && m.Tipo == "salida")
                .Sum(m => m.Precio_Unidad * m.Cantidad);

            return gastoSemanal;
        }

        public async Task<float> GetGananciaMensual()
        {
            var inicioMes = new DateTime(_dateTimeProvider.UtcNow.Year, _dateTimeProvider.UtcNow.Month, 1);
            
            var ganancia = await _context.Movimientos
                .Where(m => m.Fecha >= inicioMes)
                .SumAsync(m => m.Tipo == "salida" ? m.Precio_Unidad * m.Cantidad : -m.Precio_Unidad * m.Cantidad);
            
            return ganancia;
        }

        public async Task<float> GetGananciaAnual()
        {
            var inicioAnio = new DateTime(_dateTimeProvider.UtcNow.Year, 1, 1);
            
            var ganancia = await _context.Movimientos
                .Where(m => m.Fecha >= inicioAnio)
                .SumAsync(m => m.Tipo == "salida" ? m.Precio_Unidad * m.Cantidad : -m.Precio_Unidad * m.Cantidad);
            
            return ganancia;
        }

        public async Task<int> GetEntradaMensual()
        {
            var inicioMes = new DateTime(_dateTimeProvider.UtcNow.Year, _dateTimeProvider.UtcNow.Month, 1);
            
            var entradas = await _context.Movimientos
                .Where(m => m.Fecha >= inicioMes && m.Tipo == "entrada")
                .CountAsync();
            
            return entradas;
        }

        public async Task<int> GetSalidaMensual()
        {
            var inicioMes = new DateTime(_dateTimeProvider.UtcNow.Year, _dateTimeProvider.UtcNow.Month, 1);
            
            var salidas = await _context.Movimientos
                .Where(m => m.Fecha >= inicioMes && m.Tipo == "salida")
                .CountAsync();
            
            return salidas;
        }

        public async Task<float> GetGananciaLastSemanal()
        {
            // Obtenemos la fecha actual
            var hoy = _dateTimeProvider.UtcNow;

            // Creamos una cultura que comienza la semana en domingo
            var cultureInfo = new System.Globalization.CultureInfo("es-ES");
            cultureInfo.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Sunday;

            // Obtenemos el número de semana actual
            var calendar = cultureInfo.Calendar;
            var semanaActual = calendar.GetWeekOfYear(hoy, cultureInfo.DateTimeFormat.CalendarWeekRule, DayOfWeek.Sunday);

            // Traemos los datos a la memoria
            var movimientos = await _context.Movimientos.ToListAsync();

            // Calculamos el gasto semanal
            var gastoSemanal = movimientos
                .Where(m => calendar.GetWeekOfYear(m.Fecha, cultureInfo.DateTimeFormat.CalendarWeekRule, DayOfWeek.Sunday) == semanaActual - 1 && m.Tipo == "salida")
                .Sum(m => m.Precio_Unidad * m.Cantidad);

            return gastoSemanal;
        }

        public async Task<float> GetGananciaLastMensual()
        {
            var inicioMes = new DateTime(_dateTimeProvider.UtcNow.Year, (((_dateTimeProvider.UtcNow.Month + 11)  - 1) % 12) + 1, 1);
            
            var salidas = await _context.Movimientos
                .Where(m => m.Fecha >= inicioMes && m.Tipo == "salida")
                .CountAsync();
            
            return salidas;
        }

        public async Task<int> GetEntradaLastMensual()
        {
            var inicioMes = new DateTime(_dateTimeProvider.UtcNow.Year, (((_dateTimeProvider.UtcNow.Month + 11)  - 1) % 12) + 1, 1);
            
            var entradas = await _context.Movimientos
                .Where(m => m.Fecha >= inicioMes && m.Tipo == "entrada")
                .CountAsync();
            
            return entradas;
        }

        public async Task<int> GetSalidaLastMensual()
        {
            var inicioMes = new DateTime(_dateTimeProvider.UtcNow.Year, (((_dateTimeProvider.UtcNow.Month + 11)  - 1) % 12) + 1, 1);
            
            var salidas = await _context.Movimientos
                .Where(m => m.Fecha >= inicioMes && m.Tipo == "salida")
                .CountAsync();
            
            return salidas;
        }

        #endregion

    }
}
