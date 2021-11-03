using System;
using System.IO;
using System.Xml;

namespace Tarea1
{
    class Program
    {
        private static StreamWriter file = new System.IO.StreamWriter(@"D:\Users\Alonso\Desktop\Clase\Uni\4o Curso - 2021-22\1er Cuatri\SEW\Lab\Lab 02\Práctica 2\Ejercicio 2\Tarea 1\index.html");


        static void Main(string[] args)
        {
//            int counter = 0;
            file.WriteLine("<!DOCTYPE HTML>");
            file.WriteLine("<html lang=\"es\">");
            file.WriteLine("<head>");
            file.WriteLine("<meta charset=\"UTF-8\">");
            file.WriteLine("<title>Árbol genealógico</title>");
            file.WriteLine("<meta name=\"description\" content=\"Web diseñada para mostrar mi árbol genealógico.\">");
            file.WriteLine("<meta name=\"author\" content=\"Alonso Gago Suárez\">");
            file.WriteLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"estilo.css\" />");
            file.WriteLine("</head>");
            file.WriteLine("<body>");

            String nombreArchivoXML = @"D:\Users\Alonso\Desktop\Clase\Uni\4o Curso - 2021-22\1er Cuatri\SEW\Lab\Lab 02\Práctica 2\Ejercicio 2\Tarea 1\personas.xml";

            // XmlReader
            XmlReader lector = XmlReader.Create(nombreArchivoXML);

            while (lector.Read())
            {
                switch (lector.NodeType)
                {
                    case XmlNodeType.Element:
                        if (lector.Name.Equals("personas"))
                        {
                            toH1(lector.Name.ToUpper());
                        }
                        else if (lector.Name.Equals("persona"))
                        {
                            while (lector.MoveToNextAttribute())
                            {
                                if (lector.Name.Equals("nombre"))
                                {
                                    file.WriteLine("<h2>" + lector.Value + " ");
                                }
                                else if (lector.Name.Equals("apellidos"))
                                {
                                    file.WriteLine(lector.Value + "</h2>");
                                }
                                else if (lector.Name.Equals("fecha_nacimiento"))
                                {
                                    file.WriteLine("<p>Fecha de nacimiento:" + lector.Value + "</p>");
                                }
                            }
                        }
                        else if (lector.Name.Equals("lugar_nacimiento"))
                        {
                            //lector.MoveToNextAttribute();
                            file.Write("<p>Lugar de nacimiento:  " + lector.Value);
                        }
                        else if (lector.Name.Equals("coordenadas_nacimiento"))
                        {
                            file.WriteLine("<p>Coordenadas de nacimiento: </p>");
                            file.WriteLine("<ul>");
                        }
                        else if (lector.Name.Equals("fecha_fallecimiento"))
                        {
                            file.Write("<p>Fecha de fallecimiento: " + lector.Value);
                        }
                        else if (lector.Name.Equals("lugar_fallecimiento"))
                        {
                            file.Write("<p>Lugar de fallecimiento: " + lector.Value);
                        }
                        else if (lector.Name.Equals("coordenadas_fallecimiento"))
                        {
                            file.WriteLine("<p>Coordenadas de fallecimiento: </p>");
                            file.WriteLine("<ul>");
                        }
                        else if (lector.Name.Equals("imagen"))
                        {
                            lector.MoveToNextAttribute();
                            file.Write("<img src=\"" + lector.Value + "\" alt=\">");
                        }
                        else if (lector.Name.Equals("video"))
                        {
                            lector.MoveToNextAttribute();
                            file.Write("<p>Enlace a video: <a href=\"" + lector.Value + "\">");
                        }
                        else if (lector.Name.Equals("comentarios"))
                        {
                            file.Write("<p>Comentarios: " + lector.Value);
                        }
                        else if (lector.Name.Equals("longitud_n") || lector.Name.Equals("longitud_f"))
                        {
                            file.Write("<li>Longitud: ");
                        }
                        else if (lector.Name.Equals("latitud_n") || lector.Name.Equals("latitud_f"))
                        {
                            file.Write("<li>Latitud: ");
                        }
                        else if (lector.Name.Equals("altitud_n") || lector.Name.Equals("altitud_f"))
                        {
                            file.Write("<li>Altitud: ");
                        }                        
                        break;
                    case XmlNodeType.EndElement:
                        if (lector.Name.Equals("lugar_nacimiento") || lector.Name.Equals("fecha_fallecimiento") || lector.Name.Equals("lugar_fallecimiento") || lector.Name.Equals("comentarios"))
                        {
                            file.WriteLine("</p>");
                        }
                        else if (lector.Name.Equals("coordenadas_nacimiento") || lector.Name.Equals("coordenadas_fallecimiento"))
                        {
                            file.WriteLine("</ul>");
                        }
                        else if (lector.Name.Equals("imagen"))
                        {
                            file.WriteLine(lector.Value + "\">");
                        }
                        else if (lector.Name.Equals("video"))
                        {
                            file.WriteLine(lector.Value + "</a></p>");
                        }
                        else if (lector.Name.Equals("longitud_n") || lector.Name.Equals("longitud_f"))
                        {
                            file.Write("</li>");
                        }
                        else if (lector.Name.Equals("latitud_n") || lector.Name.Equals("latitud_f"))
                        {
                            file.Write("</li>");
                        }
                        else if (lector.Name.Equals("altitud_n") || lector.Name.Equals("altitud_f"))
                        {
                            file.Write("</li>");
                        }
                        break;
                    case XmlNodeType.Text:
                        file.Write(lector.Value);
                        break;
                }
            }
            file.WriteLine("</body>");
            file.WriteLine("</html>");
            file.Close();

        }

        private static void toP(string name, String value)
        {
            file.WriteLine("<h1>" + name + ": " + value + "</h1>");
        }

        public static void toH1(String text)
        {
            file.WriteLine("<h1>" + text + "</h1>");
        }


    }
}
