using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot
{
    public static class Synchronizer
    {
        private static Dictionary<Object, Semaphore> dico;

        static Synchronizer()
        {
            dico = new Dictionary<Object, Semaphore>();
        }

        public static void Lock(Object o)
        {
            if (!dico.ContainsKey(o))
                dico.Add(o, new Semaphore(1, 1));

            dico[o].WaitOne();
        }

        public static void Unlock(Object o)
        {
            if (!dico.ContainsKey(o))
                dico.Add(o, new Semaphore(0, 1));

            dico[o].Release();
        }
    }
}
