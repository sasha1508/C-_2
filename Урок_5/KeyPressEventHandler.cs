using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_v02
{
    /// <summary>
    /// Данный класс контролирует ввод и оповещает о 
    /// введенном символе подписанные на него классы
    /// </summary>
    internal class KeyPressEventHandler
    {
        /// <summary>
        /// событие на базе стандартного делегата EventHandler
        /// </summary>
        public event EventHandler<KeyPressEventArgs>? KeyPressed;

        internal void WaitingForInput ( )
        {
            Console.WriteLine( "Вводите выражение как обычно.\n" +
                "'ESC' - выход из программы\n" +
                "'DELETE' - предыдущий результат\n" +
                "'Backspace' - удаление введенного символа\n"+
                "'=' - получение результата\n" +
                "Поддерживаются : ' + '  ' - ' ' * ' ' / ' \n"+
                "Только два операнда\n");
            bool exit = false;
            while ( !exit )
            {
                var keyInfo = Console.ReadKey( true );
                exit = keyInfo.Key == ConsoleKey.Escape;
                OnKeyPressed( new KeyPressEventArgs( keyInfo ) );
            }
            Console.WriteLine( "Программа завершена." );
        }

        protected virtual void OnKeyPressed ( KeyPressEventArgs e )
        {
            KeyPressed?.Invoke( this , e );
        }

    }
}
