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

            var Coca = new Bebida
            {
                Nombre = "Coca",
                Volumen = 19,
                Sabor = "Cola",
                Casa= "Cocacola Gt",
                Precio= 5
            };
            var Pepsi = new Bebida
            {
                Nombre = "Pepsi",
                Volumen = 19,
                Sabor = "Cola",
                Casa = "Cocacola Gt",
                Precio = 5
            };
            var Aqua = new Bebida
            {
                Nombre = "Aqua",
                Volumen = 19,
                Sabor = "Cola",
                Casa = "Cocacola Gt",
                Precio = 5
            };
            var SuperCola = new Bebida
            {
                Nombre = "SuperCola",
                Volumen = 19,
                Sabor = "Cola",
                Casa = "Cocacola Gt",
                Precio = 5
            };
            var Pepper = new Bebida
            {
                Nombre = "Pepper",
                Volumen = 19,
                Sabor = "Cola",
                Casa = "Cocacola Gt",
                Precio = 5
            };
            var Gatorade = new Bebida
            {
                Nombre = "Gatorade",
                Volumen = 19,
                Sabor = "Cola",
                Casa = "Cocacola Gt",
                Precio = 5
            };
            var Zone = new Bebida
            {
                Nombre = "Zone",
                Volumen = 19,
                Sabor = "Cola",
                Casa = "Cocacola Gt",
                Precio = 5
            };
            var Georgia = new Bebida
            {
                Nombre = "Georgia",
                Volumen = 19,
                Sabor = "Cola",
                Casa = "Cocacola Gt",
                Precio = 5
            }; 
            //partir
            var Minute_Maid = new Bebida
            {
                Nombre = "Minute_Maid",
                Volumen = 19,
                Sabor = "Cola",
                Casa = "Cocacola Gt",
                Precio = 5
            };
            var Aa = new Bebida
            {
                Nombre = "Aa",
                Volumen = 19,
                Sabor = "Cola",
                Casa = "Cocacola Gt",
                Precio = 5
            };
            #region Por Insertar

            //var Ab = new Bebida
            //{
            //    Nombre = "Ab",
            //    Volumen = 19,
            //    Sabor = "Cola",
            //    Casa = "Cocacola Gt",
            //    Precio = 5
            //};
            //var Glacéau = new Bebida
            //{
            //    Nombre = "Glacéau",
            //    Volumen = 19,
            //    Sabor = "Cola",
            //    Casa = "Cocacola Gt",
            //    Precio = 5
            //};
            //var Yoda = new Bebida
            //{
            //    Nombre = "Yoda",
            //    Volumen = 19,
            //    Sabor = "Cola",
            //    Casa = "Cocacola Gt",
            //    Precio = 5
            //};
            //var Tongo = new Bebida
            //{
            //    Nombre = "Tongo",
            //    Volumen = 19,
            //    Sabor = "Cola",
            //    Casa = "Cocacola Gt",
            //    Precio = 5
            //};
            //var SevenUp = new Bebida
            //{
            //    Nombre = "SevenUp",
            //    Volumen = 19,
            //    Sabor = "Cola",
            //    Casa = "Cocacola Gt",
            //    Precio = 5
            //};
            //var Niners = new Bebida
            //{
            //    Nombre = "Niners",
            //    Volumen = 19,
            //    Sabor = "Cola",
            //    Casa = "Cocacola Gt",
            //    Precio = 5
            //};
            //var Ac = new Bebida
            //{
            //    Nombre = "Ac",
            //    Volumen = 19,
            //    Sabor = "Cola",
            //    Casa = "Cocacola Gt",
            //    Precio = 5
            //};
            //var Af = new Bebida
            //{
            //    Nombre = "Af",
            //    Volumen = 19,
            //    Sabor = "Cola",
            //    Casa = "Cocacola Gt",
            //    Precio = 5
            //};
            //var Super = new Bebida
            //{
            //    Nombre = "Super",
            //    Volumen = 19,
            //    Sabor = "Cola",
            //    Casa = "Cocacola Gt",
            //    Precio = 5
            //};
            //var TeFrio = new Bebida
            //{
            //    Nombre = "TeFrio",
            //    Volumen = 19,
            //    Sabor = "Cola",
            //    Casa = "Cocacola Gt",
            //    Precio = 5
            //};
            //var Uva = new Bebida
            //{
            //    Nombre = "Uva",
            //    Volumen = 19,
            //    Sabor = "Cola",
            //    Casa = "Cocacola Gt",
            //    Precio = 5
            //};
            //var Sake = new Bebida
            //{
            //    Nombre = "Sake",
            //    Volumen = 19,
            //    Sabor = "Cola",
            //    Casa = "Cocacola Gt",
            //    Precio = 5
            //};
            #endregion

            metodosArbol.Insertar(Pepsi);
            metodosArbol.Insertar(Coca);
            metodosArbol.Insertar(Aqua);
            metodosArbol.Insertar(SuperCola);
            metodosArbol.Insertar(Pepper);
            metodosArbol.Insertar(Gatorade);
            metodosArbol.Insertar(Zone);
            metodosArbol.Insertar(Georgia);
            //parte
            metodosArbol.Insertar(Minute_Maid);
            metodosArbol.Insertar(Aa);
        }
    }
}
