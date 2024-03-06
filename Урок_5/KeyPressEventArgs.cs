using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_v02
{
    /// <summary>
    /// Данный класс используется для передачи данных о нажатой клавише
    /// </summary>
    internal class KeyPressEventArgs:EventArgs
    {
        public ConsoleKeyInfo KeyInfo { get; }
        public KeyPressEventArgs ( ConsoleKeyInfo keyInfo )
        {
            KeyInfo = keyInfo;
        }
    }
}
