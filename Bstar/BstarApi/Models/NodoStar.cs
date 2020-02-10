using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BstarApi.Models
{
    public class NodoStar
    {


        int id { get; set; }
        int Padre { get; set; }
        int[] Hijos { get; set; }
        Bebida[] Datos { get; set; }
        bool esHoja { get; set; }

        public NodoStar(int _grado, bool Tipo)
        {
            if (Tipo)
            {//si es hoja
                Datos = new Bebida[_grado - 1];
                Hijos = new int[_grado];
                esHoja = Tipo;
            }
            else
            { // es la raix
                Datos = new Bebida[(4 / 3) * _grado - 1];
                Hijos = new int[((4 / 3) * _grado - 1) + 1];
                esHoja = Tipo;

            }

        }

        public string WriteNodo()
        {
            var devolver = string.Empty;
            devolver += $"{id.ToString().PadLeft(5)}|";
            devolver += $"{Padre.ToString().PadLeft(5)}|";
            for (int i = 0; i < Hijos.Length; i++)
            {
                devolver += $"{Hijos[i].ToString().PadLeft(10)}|";

            }

            for (int i = 0; i < Datos.Length; i++)
            {
                devolver += $"{JsonConvert.SerializeObject(Datos[i]).PadLeft(10)}|";

            }
            return devolver;
        }
    }
}