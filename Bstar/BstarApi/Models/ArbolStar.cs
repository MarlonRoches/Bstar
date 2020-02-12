using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace BstarApi.Models
{
    public class ArbolStar
    {
        static string path { get; set; }
        public int LargoPadre  { get; set; }
        public int LargoHijo   { get; set; }
        public int idActual    { get; set; }
        public static int Grado{ get; set; }
        public static NodoStar Raiz { get; set; }


        public ArbolStar(int _grado, string _path, int idActual)
        {
            path = _path;
            LargoPadre = new NodoStar(_grado, false).WriteNodo().Length;
            LargoHijo = new NodoStar(_grado, true).WriteNodo().Length;
            Grado = _grado;
        }
        public void Insertar( Bebida Nuevo)
        {
            var File = new FileStream($"{path}\\Arbol.txt", FileMode.OpenOrCreate);
            var lector = new StreamReader(File);
            var lol = lector.ReadLine();
            if (lol == null)
            {
                //escribir MetaData

                //nuevo arbol
                Raiz.id = idActual;
                idActual++;

            }
            else
            {
                //Ya tiene

            }
        }

        public int Indice(NodoStar Actual, Bebida Nuevo)
        {
            var iActualndice = 0;
            var listacomparar = new List<Bebida>();
            foreach (var item in Actual.Datos)
            {
                if (item != null)
                {
                    listacomparar.Add(item);
                }
            }


            for (iActualndice = 0; iActualndice <= listacomparar.Count; iActualndice++)
            {
                if (iActualndice == listacomparar.Count)
                {

                    break;

                }
                else if (String.Compare(Nuevo.Nombre, listacomparar[iActualndice].Nombre) == -1)
                {

                    break;
                }
            }

            return iActualndice;

        }

        public void Navegar()
        {

        }
    }
}