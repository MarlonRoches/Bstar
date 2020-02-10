using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BstarApi.Models;
using BstarApi.Data;
namespace BstarApi.Data
{
    public class Singleton
    {

        private static Singleton _instance = null;
        public static Singleton Instance
        {
            get
            {
                if (_instance == null) _instance = new Singleton();
                return _instance;
            }
        }
        NodoStar Raiz = new NodoStar(7, false);



    }
}