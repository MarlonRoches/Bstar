using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BstarApi.Data;
using BstarApi.Models;
namespace BstarApi.Models
{
    public class NodoStar
    {

        public int Grado { get;set;}
        public int id { get; set; }
        public int Padre { get; set; }
        public int[] Hijos { get; set; }
        public Bebida[] Datos { get; set; }
        public bool esHoja { get; set; }

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
            devolver += $"{id.ToString().PadLeft(3, '0')}|";
            devolver += $"{Padre.ToString().PadLeft(3, '0')}|";
            for (int i = 0; i < Hijos.Length; i++)
            {
                devolver += $"{Hijos[i].ToString().PadLeft(5, '0')}|";

            }

            for (int i = 0; i < Datos.Length; i++)
            {
                devolver += $"{JsonConvert.SerializeObject(Datos[i]).PadLeft(100,'0')}|";

            }
            return devolver;
        }
        public NodoStar ReadNodo(string json)
        {
            var splited = json.Split('|');
            var devolver = new NodoStar(Singleton.Instance.Raiz.Grado,false);
            devolver.id = int.Parse(splited[0]);

            return null;
        }
    }
}