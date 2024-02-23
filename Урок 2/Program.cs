// Реализуйте операторы неявного приведения из long,int,byt в Bits.

using System;
using Урок_2;

Bits bits = new(2);
bits[2] = true;

byte num = bits;

Console.WriteLine(num);

Bits bits2 = num;

Console.WriteLine(bits2);
