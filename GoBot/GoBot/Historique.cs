using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Actions;
using System.Threading;

namespace GoBot
{
    public enum TypeLog
    {
        Action,
        Strat,
        PathFinding
    }

    public class HistoLigne : IComparable
    {
        public String Message { get; set; }
        public DateTime Heure { get; set; }
        public TypeLog Type {get;set;}

        public HistoLigne(DateTime heure, String message, TypeLog type = TypeLog.Strat)
        {
            Message = message;
            Heure = heure;
            Type = type;
        }

        public int CompareTo(object obj)
        {
            return Heure.CompareTo(((HistoLigne)obj).Heure);
        }
    }

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

        public delegate void DelegateAction(IAction action);
        public event DelegateAction NouvelleAction;
        public delegate void DelegateLog(HistoLigne ligne);
        public event DelegateLog NouveauLog;

        public Historique()
        {
            actions = new List<IAction>();
            HistoriqueLignes = new List<HistoLigne>();
        }

        public void AjouterAction(IAction action)
        {
            Actions.Add(action);
            Log(action.ToString(), TypeLog.Action);

            while (Actions.Count > NBACTIONSMAX)
                Actions.RemoveAt(0);

            if (NouvelleAction != null)
                NouvelleAction(action);
        }

        public void Log(String message, TypeLog type = TypeLog.Strat)
        {
            HistoLigne ligne = new HistoLigne(DateTime.Now, message, type);
            HistoriqueLignes.Add(ligne);
            if (NouveauLog != null)
                NouveauLog(ligne);
        }

        public List<HistoLigne> HistoriqueLignes { get; set; }
    }
}
