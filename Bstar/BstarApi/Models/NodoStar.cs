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

                var grado = Convert.ToInt32(1.33333 * (double)(_grado-1));
                Datos = new Bebida[grado];
                Hijos = new int[grado + 1];
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
        public NodoStar ReadNodo(string NodoSerializado)
        {
            //es sensible al tipo de json que le envie
            var devolver = new NodoStar(7, false);
            var splited = NodoSerializado.Split('|');
            //padre o no
            if (int.Parse(splited[1]) == 0)
            { // es raiz
            devolver = new NodoStar(7,false);
            }
            else
            {//es hoja
            devolver = new NodoStar(7,true);
            }
            //poner id
            devolver.id = int.Parse(splited[0]);
            
                //poner Datos
                var contador = 2;
                for (int i = 0; i < devolver.Hijos.Length; i++)
                {
                    devolver.Hijos[i] = int.Parse(splited[contador]);
                    contador++;
                }
                //poner hijos
                for (int i = 0; i < devolver.Datos.Length; i++)
                {
                    var des = splited[contador].Replace("0", "");
                    devolver.Datos[i] = JsonConvert.DeserializeObject<Bebida>(des);
                    contador++;
                }
            return devolver;
        }
    }
}