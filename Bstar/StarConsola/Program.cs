using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BstarApi.Models;
using BstarApi.Data;
namespace StarConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            var metodosArbol = new ArbolStar();

            var Cocacola = new Bebida
            {
                Nombre ="Coca",
                Casa = "Cocacola Gt",
                Precio = 5,
                Sabor= "Cola",
                Volumen = 2
            };
            metodosArbol.Insertar(Cocacola);
        }
    }
}
