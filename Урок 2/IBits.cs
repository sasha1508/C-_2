using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Урок_2
{
    internal interface IBits
    {
        public bool GetBits(int num);

        public void SetBits(int num, bool value);
    }
}
