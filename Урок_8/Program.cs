//Объедините две предыдущих работы (практические работы 2 и 3):
//поиск файла и поиск текста в файле написав утилиту которая ищет файлы определенного расширения с указанным текстом.
//Рекурсивно.

//Пример вызова утилиты: utility.exe txt текст.


namespace Searching
{
    internal class Program
    {
        static void Main ( string[ ] args )
        {
            try
            {
                if ( args.Length > 2 )
                {
                    //директория запуска приложения
                    var path = args[ 0 ];
                    //заданное расширение
                    var ext = args[ 1 ];
                    //коррекция введеного расширения
                    if ( !ext.StartsWith( '.' ) )
                        ext = $".{args[ 1 ]}";
                    //в тексте могут быть пробелы и следовательно он займет несколько
                    //ячеек в массиве args. Соединяем все последующие элементы в одну строку.
                    var text = String.Join( ' ' , args , 2 , args.Length - 2 );
                    Search( path , ext , text );
                } else
                {
                    Console.WriteLine( "Неверные параметры..." );
                    return;
                }
                Console.WriteLine( "Программа успешно завершена." );

            } catch ( IOException e )
            {
                Console.WriteLine( $"Фатальная ошибка при работе с файлами/директориями : " +
                    $"\n{e.Message}\n\n Программа закрыта." );
            } catch ( Exception e )
            {
                Console.WriteLine( $"Фатальная ошибка. Программа закрыта. :\n{e.Message}" );
            }

        }

        private static void Search ( string path , string extension , string text )
        {
            text = text.Trim( ).ToLower( );
            //все файлы имеющие заданное расширение
            var files = Directory.GetFiles( path ).Where( x => new FileInfo( x ).Extension == extension );
            if ( files?.Count( ) > 0 )
            {//поиск искомого текста в файлах
                foreach ( var file in files )
                {
                    //если нет доступа к файлу, перейдем к следующему
                    try
                    {
                        using ( var read = new StreamReader( file ) )
                        {
                            while ( !read.EndOfStream )
                            {
                                string? line = read.ReadLine( )?.Trim( ).ToLower( );
                                if ( line != null && ( line.Contains( text ) || line.Equals( text ) ) )
                                {
                                    Console.WriteLine( file );
                                    break;
                                }
                            }
                        }
                    } catch ( UnauthorizedAccessException e )
                    {
                        Console.WriteLine( $"Не могу получить доступ к {file}" );
                    }
                }
            }
            if ( Directory.GetDirectories( path ).Length > 0 )
            {//перебор директорий
                foreach ( var dir in Directory.GetDirectories( path ) )
                {
                    //если нет доступа к директории, перейдем к следующей
                    try
                    {
                        Search( Path.Combine( path , dir ) , extension , text );

                    } catch ( UnauthorizedAccessException )
                    {
                        Console.WriteLine( $"Не могу получить доступ к {dir}" );
                    }
                }
            }

        }
    }
}
