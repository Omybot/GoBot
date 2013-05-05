using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Actions;
using System.Threading;

namespace GoBot
{
    public class Historique
    {
        int NBACTIONSMAX = 10;
        private List<IAction> actions;
        public List<IAction> Actions
        {
            get
            {
                return actions;
            }
        }

        public delegate void delegateAction(IAction action);
        public event delegateAction NouvelleAction;

        public Historique()
        {
            actions = new List<IAction>();
        }

        Thread th;
        public void AjouterActionThread(IAction action)
        {
            //th = new Thread(AjouterAction);
            //th.Start(action);
            AjouterAction(action);
        }

        public void AjouterAction(Object o)
        {
            IAction action = (IAction)o;
            AjouterAction(action);
        }

        public void AjouterAction(IAction action)
        {
            Actions.Add(action);

            while (Actions.Count > NBACTIONSMAX)
                Actions.RemoveAt(0);

            if(NouvelleAction != null)
                NouvelleAction(action);
        }
    }
}
