using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace TP1.Views
{
    public class CJson
    {

        public static List<string> GetProvincias()
        {
            Random rnd = new Random();
            var url = $" https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre ";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            List<string> Lista = new List<string>();

            try
            {

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader((strReader)))
                        {
                            try
                            {
                                string responseBody = objReader.ReadToEnd();
                                Root ListaProvincina = JsonSerializer.Deserialize<Root>(responseBody);
                                foreach (Provincia item in ListaProvincina.provincias)
                                {
                                    Lista.Add(item.nombre);
                                }

                                return Lista;
                            }
                            catch (Exception)
                            {
                                Lista.Add("Error Sistema");
                                return Lista;
                            }                            
                        }
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public class Parametros
        {
            public List<string> campos { get; set; }
        }

        public class Provincia
        {
            public string id { get; set; }
            public string nombre { get; set; }
        }

        public class Root
        {
            public int cantidad { get; set; }
            public int inicio { get; set; }
            public Parametros parametros { get; set; }
            public List<Provincia> provincias { get; set; }
            public int total { get; set; }
        }
    }
}
