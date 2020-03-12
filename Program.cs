using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace Teste_XSLT
{
    class Program
    {
        static void Main(string[] args)
        {
            var html = TransformXMLToHTML(File.ReadAllText(@"xmls\dados.xml"), File.ReadAllText(@"xmls\estilos.xml"));
            string destino = @"xmls\resultado.html";
            File.WriteAllText(destino, html);
            System.Diagnostics.Process.Start(destino);
        }

        public static string TransformXMLToHTML(string inputXml, string xsltString)
        {
            XslCompiledTransform transform = new XslCompiledTransform();
            using (XmlReader reader = XmlReader.Create(new StringReader(xsltString)))
                transform.Load(reader);

            StringWriter results = new StringWriter();
            using (XmlReader reader = XmlReader.Create(new StringReader(inputXml)))
                transform.Transform(reader, null, results);
            
            return results.ToString();
        }
    }
}
