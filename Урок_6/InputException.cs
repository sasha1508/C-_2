using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_v02
{
    internal class InputException : Exception
    {
        public InputException ( string? message ) : base( message )
        {
        }

        public override string Message => base.Message;


        public override string ToString ( )
        {
            return base.ToString( );
        }
    }
}
