using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Composants
{
    public partial class RichTextBoxPlus : RichTextBox
    {
        public RichTextBoxPlus()
        {
            InitializeComponent();
        }

        public RichTextBoxPlus(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void AjouterLigne(String texte, Color couleur, bool afficheHeure = true)
        {
            texte = afficheHeure ? DateTime.Now.ToLongTimeString() + " > " + texte + Environment.NewLine : texte + Environment.NewLine;
            SuspendLayout();

            SelectionStart = TextLength;
            SelectedText = texte;

            SelectionStart = TextLength - texte.Length + 1;
            SelectionLength = texte.Length;
            SelectionColor = couleur;

            ResumeLayout();

            Select(TextLength, 0);

            SelectionStart = TextLength;
            ScrollToCaret();
        }
    }
}
