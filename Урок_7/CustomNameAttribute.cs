using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection07_Reflection
{
    // атрибут может применяться к свойствам и полям
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field )]
    public class CustomNameAttribute:Attribute
    {
        public string Name { get; private set; }
        public CustomNameAttribute ( string name )
        {
            Name = name;
        }
    }
}
