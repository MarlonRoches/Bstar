using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace BstarApi.Models
{
    public class ArbolStar
    {
        static string path = Directory.GetCurrentDirectory();
        public int LargoPadre = 0;
        public int LargoHijo = 0;
        public int idActual = 1;
        public static NodoStar Raiz = new NodoStar(7, false);
        public void Insertar( Bebida Nuevo)
        {
            var File = new FileStream($"{path}\\Arbol.txt", FileMode.OpenOrCreate);
            var lector = new StreamReader(File);
            var lol = lector.ReadLine();
            if (lol == null)
            {
                //nuevo arbol
                //escribir MetaData
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