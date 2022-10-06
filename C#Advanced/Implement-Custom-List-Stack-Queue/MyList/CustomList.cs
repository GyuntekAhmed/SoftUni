using System;
using System.Collections.Generic;
using System.Text;

namespace MyList
{
    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public CustomList()
        {
            items = new int[InitialCapacity];
        }

        public int Count { get; private set; }
    }
}
