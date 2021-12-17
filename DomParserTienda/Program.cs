using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Xml;

namespace DomParserTienda
{
    class Program
    {
        static void Main(string[] args) //Metodo principal
        {
            UsandoXmlDom(obtenerPath("tienda.xml")); //Enfoque dom sobre el archivo xml especificado
            Console.Read();
        }
        //Metodo para obtener la ruta donde se encuentra el archivo xml generado de manera estatica
        public static string obtenerPath(string recurso)
        {
            var directorioSalida = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var rutaCombinada = Path.Combine(directorioSalida, recurso);
            string rutaRecurso = new Uri(rutaCombinada).LocalPath;
            return rutaRecurso;
        }
        //Metodo con el enfoque dom para obtener la informacion del archivo xml
        public static void UsandoXmlDom(string ruta)
        {
            XmlDocument documentoTienda = new XmlDocument();
            documentoTienda.Load(ruta);
            Console.WriteLine($"Nombre del elemento raíz: {documentoTienda.DocumentElement.Name}");
            foreach (XmlNode nodo in documentoTienda.DocumentElement)
            {
                Console.WriteLine($"Nombre del elemento actual = {nodo.Name}");
                XmlElement elemento = (XmlElement) nodo;
                Console.WriteLine($"Id: {elemento.Attributes["proid"].Value}");
                Console.WriteLine($"Nombre: {elemento.ChildNodes[0].InnerText}");
                Console.WriteLine($"Stock: {elemento.ChildNodes[1].InnerText}");
                Console.WriteLine($"Precio: {elemento.ChildNodes[2].InnerText}");
            }
        }
    }
}
