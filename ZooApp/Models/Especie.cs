using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZooApp
{
    public class Especie
    {
        public long idEspecie { get; set; }
        public int idClasificacion { get; set; }
        public Clasificacion clasificacion { get; set; }
        public TipoAnimal tipoAnimal { get; set; }
        public string nombre { get; set; }
        public short nPatas { get; set; }
        public bool esMascota { get; set; }
    }
}