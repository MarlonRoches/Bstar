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
        public int IdPAdre    { get; set; }
        public int Siguiente    { get; set; }
        public static int Grado{ get; set; }
        public static NodoStar Raiz { get; set; }
        //idpadre|grado|siguiente|tamañopadre|tamañohijo

        public ArbolStar(int _grado, string _path)
        {
           
            var file = new FileStream(_path, FileMode.OpenOrCreate);
            var lector = new StreamReader(file);
            var linea = lector.ReadLine();
                path = _path;
            if (linea==null)
            {//nuevo arbol
                LargoPadre = new NodoStar(_grado, false).WriteNodo().Length;
                LargoHijo = new NodoStar(_grado, true).WriteNodo().Length;
                IdPAdre = 1;
                Siguiente = IdPAdre + 1;
                Grado = _grado;
                Raiz = new NodoStar(Grado, false);
                lector.Close();
                var escritor = new StreamWriter(path);
                escritor.WriteLine($"{IdPAdre}|{Grado}|{Siguiente}|{LargoPadre}|{LargoHijo}");
            }
            else
            {//arbol cargado
                var aMetaData = linea.Split('|');
                //0raiz    
                IdPAdre = int.Parse(aMetaData[0]);
                //1grado
                Grado = int.Parse(aMetaData[1]);
                //2siguiente
                Siguiente = int.Parse(aMetaData[2]);
                //3largo padre
                LargoPadre = int.Parse(aMetaData[3]);
                //4largohijo
                LargoHijo = int.Parse(aMetaData[4]);
                
            }
        }
        public void Insertar( Bebida Nuevo)
        {
            var File = new FileStream(path,FileMode.Open);
            var lector = new StreamReader(File);
            var lol = lector.ReadLine();
            if (lol == null)
            {
                //escribir MetaData

                //nuevo arbol
                Raiz.id = IdPAdre;
                IdPAdre++;

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