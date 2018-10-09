using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace podbor_odejdi
{
    public class Footbolka
    {
        public int id=0, pop, min_t, max_t;
        public string nazvanie, kartinka;
        public int get_min_temp()
        {
            return min_t;
        }
    }
    public class Shtani
    {
        public int id, pop, min_t, max_t;
        public string nazvanie, kartinka;
    }
    public class Obuv
    {
        public int id, pop, min_t, max_t;
        public string nazvanie, kartinka;
    }
}
