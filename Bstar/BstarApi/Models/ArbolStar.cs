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
                Raiz.id = IdPAdre;
                Raiz.Grado = _grado;
                Raiz.esHoja = false;
                escritor.Write($"{(IdPAdre).ToString().PadLeft(3,'0')}" +
                    $"|{Grado.ToString().PadLeft(3, '0')}|{Siguiente.ToString().PadLeft(3, '0')}" +
                    $"|{LargoPadre.ToString().PadLeft(3, '0')}|{LargoHijo.ToString().PadLeft(3, '0')}|"+
                    (Raiz.WriteNodo()));
                escritor.Close();
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
                Raiz = new NodoStar(_grado, false);
            }
            file.Close();
        }
        public void Insertar( Bebida Nuevo)
        {
            var FILE = new FileStream(path,FileMode.Open);
            var lector = new StreamReader(FILE);
            if (IdPAdre ==1)
            {
                var linea = lector.ReadLine().Remove(0,20);

               Raiz =  Raiz.ReadNodo(linea);
                var contador = 0;
                foreach (var item in Raiz.Datos)
                {
                    //insertando en la raiz
                    if (item == null)
                    {
                        Raiz.Datos[contador] = Nuevo;
                        FILE.Close();

                        var escritor = new StreamWriter(path);
                        escritor.Write($"{(IdPAdre).ToString().PadLeft(3, '0')}" +
                    $"|{Grado.ToString().PadLeft(3, '0')}|{Siguiente.ToString().PadLeft(3, '0')}" +
                    $"|{LargoPadre.ToString().PadLeft(3, '0')}|{LargoHijo.ToString().PadLeft(3, '0')}|" +
                    (Raiz.WriteNodo()));
                        escritor.Close();
                        break;
                    }
                    else
                    {
                        contador++;
                    }

                }
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