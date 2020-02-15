using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BstarApi.Models;
using BstarApi.Data;
using System.IO;

namespace StarConsola
{
    class Program
    {
        static void Main(string[] args)
        {

            var metodosArbol = new ArbolStar(7, $"{Directory.GetCurrentDirectory()}\\Arbol.txt");

            var Cocacola = new Bebida
            {
                Nombre = "Pepsi",
                Casa = "Pepsi Gt",
                Precio = 16,
                Sabor = "Uwu",
                Volumen = 5
            };

            metodosArbol.Insertar(Cocacola);
        }
    }
}
