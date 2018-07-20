using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TodoApp
{
    public class TodoItem
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public string ToDo { get; set; }
        public string Prioridad { get; set; }
        public DateTime FechaFin { get; set; } //Aqui uniremos date y time
        public bool Eliminado { get; set; }

        public TodoItem()
        {

        }

        public TodoItem(string todo,String prioridad,DateTime fechafin,bool eliminado)
        {
            ToDo = todo;
            Prioridad = prioridad;
            FechaFin = fechafin;
            Eliminado = eliminado;
        }
    }
}
