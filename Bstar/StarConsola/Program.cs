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
            var Cocacola = new Bebida
            {
                Nombre ="Coca",
                Casa = "Cocacola Gt",
                Precio = 5,
                Sabor= "Cola",
                Volumen = 2
            };
            var nodo = new NodoStar(7, false);
            nodo.Padre = 0;
            nodo.id = 1;
            nodo.Datos[0] = Cocacola;
            var importe = nodo.WriteNodo();

        }
    }
}
