using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot
{
    public static class Util
    {
        public static dynamic ToRealType(Object o)
        {
            Type type = o.GetType();
            dynamic pp = Convert.ChangeType(o, type);
            return pp;
        }
    }
}
