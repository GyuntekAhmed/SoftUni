using System;
using System.Collections.Generic;
using System.Text;

namespace Touple
{
    public class Tuple<TFirst, TSecond>
    {
        public Tuple(TFirst firstelement, TSecond secondelement)
        {
            FirstElement = firstelement;
            Secondelement = secondelement;
        }

        public TFirst FirstElement { get; private set; }

        public TSecond Secondelement { get; private set; }

        public override string ToString()
        {
            return $"{FirstElement} -> {Secondelement}";
        }
    }
}
