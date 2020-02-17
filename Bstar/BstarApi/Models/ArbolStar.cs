using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace BstarApi.Models
{
    public class ArbolStar
    {
        static bool primeraSeparecion = false;
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
                escritor.WriteLine($"{(IdPAdre).ToString().PadLeft(3,'0')}" +
                    $"|{Grado.ToString().PadLeft(3, '0')}|{Siguiente.ToString().PadLeft(3, '0')}" +
                    $"|{LargoPadre.ToString().PadLeft(3, '0')}|{LargoHijo.ToString().PadLeft(3, '0')}|");
                escritor.WriteLine(Raiz.WriteNodo());
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
            if (IdPAdre ==1 && !primeraSeparecion) // aun no se parte
            {
                var linea = lector.ReadLine();
                linea = lector.ReadLine();
                FILE.Close();
               Raiz =  Raiz.ReadNodo(linea);
                var contador = 0;
                for (int i = 0; i <= Raiz.Datos.Length; i++)
                {
                    if (i == Raiz.Datos.Length)
                    {

                        PrimeraSeparacion(Raiz, Nuevo);
                        break;
                    }
                    //insertando en la raiz
                    if (Raiz.Datos[i] == null)
                    {
                        Raiz.Datos[contador] = Nuevo;
                        SortDatos(Raiz.Datos);

                        var escritor = new StreamWriter(path);
                        escritor.WriteLine($"{(IdPAdre).ToString().PadLeft(3, '0')}" +
                         $"|{Grado.ToString().PadLeft(3, '0')}|{Siguiente.ToString().PadLeft(3, '0')}" +
                         $"|{LargoPadre.ToString().PadLeft(3, '0')}|{LargoHijo.ToString().PadLeft(3, '0')}");
                        escritor.WriteLine(Raiz.WriteNodo());
                        escritor.Close();
                        break;
                    }
                    else
                    {
                        contador++;
                    }
                }
            }
            else
            {

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
        public void SortDatos(Bebida[] A_Arreglar)
        {
            var lista = new List<Bebida>();
            foreach (var item in A_Arreglar)
            {
                if (item != null)
                {
                    lista.Add(item);
                }
            }
            lista = lista.OrderBy(o => o.Nombre).ToList();
            var contador = 0;
            foreach (var item in lista)
            {
                A_Arreglar[contador] = item;
                contador++;
            }
        }
        public void Navegar()
        {

        }
       public void PrimeraSeparacion(NodoStar Actual, Bebida Nuevo)
       {
            var lista = new List<Bebida>();
            foreach (var item in Actual.Datos)
            {
                lista.Add(item);
            }
            lista.Add(Nuevo);

            // escribir en el archivo todos los nodos disponibles del padre e hijos
            var hijo1 = new NodoStar(Grado, true)
            {
                Grado = Grado
            };
            hijo1.id = IdPAdre;
            var indice =0;

            for (int i = 0; i < lista.Count / 2; i++)
            {
                hijo1.Datos[indice] =lista[i];
                indice++;
            }


            indice =0;
            var hijo2 = new NodoStar(Grado, true);

            hijo2.id = Siguiente;
            Siguiente++;
            for (int i = (lista.Count / 2) +1; i < lista.Count; i++)
            {
                hijo2.Datos[indice] = lista[i];
                indice++;
            }
            var raiznueva = new NodoStar(Grado, false)
            {
                id = Siguiente
            };
            raiznueva.Datos[0] = lista[lista.Count / 2];
            IdPAdre = Siguiente;
            raiznueva.Hijos[0] = hijo1.id;
            raiznueva.Hijos[1] = hijo2.id;
            hijo1.Padre = raiznueva.id;
            hijo2.Padre = raiznueva.id;
            Siguiente++;


            var escritor = new StreamWriter(path);
            //metadata
            escritor.WriteLine($"{(IdPAdre).ToString().PadLeft(3, '0')}" +
            $"|{Grado.ToString().PadLeft(3, '0')}|{Siguiente.ToString().PadLeft(3, '0')}" +
            $"|{LargoPadre.ToString().PadLeft(3, '0')}|{LargoHijo.ToString().PadLeft(3, '0')}|");
            // nodos
            escritor.WriteLine(hijo1.WriteNodo());
            escritor.WriteLine(hijo2.WriteNodo());
            escritor.WriteLine(raiznueva.WriteNodo());
            escritor.Close();


        }
        public int SeekPadre()
        {
            return 0;
        }
    }
}