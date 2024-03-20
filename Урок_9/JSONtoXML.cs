using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Convert_JSON_To_XML
{
    internal class JSONtoXML
    {

        public JSONtoXML ( string json )
        {
            var doc = new XmlDocument( );
            var rootNode = doc.AppendChild( doc.CreateElement( "Person" ) );
            if ( rootNode != null )
            {   
                JsonDocument jsonDoc = JsonDocument.Parse( json );
                
                ConvertJsonToXml( jsonDoc.RootElement , rootNode );
            }
            //форматированный вывод в консоль
            XmlWriterSettings settings = new( )
            {
                Indent = true , 
                IndentChars = "\t" 
            };
            using XmlWriter writer = XmlWriter.Create( Console.Out , settings );
            doc.Save( writer );
        }


        /// <summary>
        /// Конвертация JSON элементов в XML
        /// </summary>
        private void ConvertJsonToXml ( JsonElement jsonElement , XmlNode xmlNode )
        {
            switch ( jsonElement.ValueKind )
            {   // Если это объект JSON, обходим его свойства
                case JsonValueKind.Object:
                foreach ( var property in jsonElement.EnumerateObject( ) )
                {
                    var newElement = xmlNode.OwnerDocument?.CreateElement( property.Name );
                    if ( newElement != null )
                    {
                        xmlNode.AppendChild( newElement );
                        ConvertJsonToXml( property.Value , newElement );
                    }
                }
                break;
                // Если это массив JSON, обходим его элементы
                case JsonValueKind.Array:
                foreach ( var value in jsonElement.EnumerateArray( ) )
                {
                    ConvertJsonToXml( value , xmlNode );
                }
                break;
                // Для примитивных значений JSON, добавляем их как текстовый узел в XML
                default:
                var textNode = xmlNode.OwnerDocument?.CreateTextNode( jsonElement.ToString( ) );
                if ( textNode != null )
                    xmlNode.AppendChild( textNode );
                break;
            }
        }
    }
}
