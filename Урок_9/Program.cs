namespace Convert_JSON_To_XML
{
    /*
     Напишите приложение конвертирующее произвольный JSON в XML. Используете JsonDocument
     */
    internal class Program
    {
        static void Main ( string[ ] args )
        {
            _ = new JSONtoXML( String.Join( " " , args ) );
        }
    }


}
