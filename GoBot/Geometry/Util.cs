using System;

namespace Geometry
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
