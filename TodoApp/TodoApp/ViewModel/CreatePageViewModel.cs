using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.ViewModel
{
    public class CreatePageViewModel
    {
        public void AddTask(string todo, string prioridad,
            DateTime fechaFin, int hours, int minutes, int seconds, int updateId,
            bool completado)
        {
            var newTask = new TodoItem()
            {
                Id = updateId,
                ToDo = todo,
                Prioridad = prioridad,
                FechaFin = GetFechaFin(fechaFin, hours, minutes, seconds),
                Eliminado = completado
            };

            App.Database.Save(newTask);
        }
        private DateTime GetFechaFin(DateTime fecha, int hours, int minutes, int seconds)
        {
            return new DateTime(fecha.Year,
                fecha.Month,
                fecha.Day,
                hours,
                minutes,
                seconds);
        }
    }
}
