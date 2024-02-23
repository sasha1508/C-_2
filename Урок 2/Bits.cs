using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Урок_2
{
    internal class Bits : IBits
    {
        private readonly int size = 0;

        bool IBits.GetBits(int index)
        {
            return this[index];
        }

        void IBits.SetBits(int index, bool value)
        {
            this[index] = value;
        }

        public long Value { get; private set; } = 0;

        public Bits(long value)
        {
            Value = value;
            size = sizeof(long);
        }

        //Создаём неявное преобразование из long в Bits и обратно:
        public static implicit operator long(Bits b) => (long)b.Value;
        public static implicit operator Bits(long b) => new Bits(b);

        //Создаём неявное преобразование из int в Bits и обратно:
        public static implicit operator int(Bits b) => (int)b.Value;
        public static implicit operator Bits(int b) => new Bits(b);

        //Создаём неявное преобразование из byte в Bits и обратно:
        public static implicit operator byte(Bits b) => (byte)b.Value;
        public static implicit operator Bits(byte b) => new Bits(b);
        
        public bool this[int index]
        {
            get
            {
                if (index > size - 1 || index < 0) return false;
                return ((Value >> index) & 1) == 1;
            }
            set {
                if (index > size - 1 || index < 0) return;
                if (value == true) Value = (long)(Value | 1 << index);
                else
                {
                    var mask = (long)(1 << index);
                    mask = ~mask;
                    Value &= (long)(Value & mask);
                    /*
                    mask = (long)(0xffffffffffffffff ^ mask); */
                }
            }
        }
    }
}
