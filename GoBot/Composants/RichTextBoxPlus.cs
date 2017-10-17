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

        /// <summary>
        /// Ajoute une ligne de teste dans le couleur spécifiée. L'heure peut etre auomatiquement ajoutée en début de ligne.
        /// </summary>
        /// <param name="text">Texte à ajouter</param>
        /// <param name="color">Couleur du texte à ajouter</param>
        /// <param name="withDate">Si vrain la date est ajoutée au début de la ligne</param>
        public void AddLine(String text, Color color, bool withDate = true)
        {
            text = withDate ? DateTime.Now.ToLongTimeString() + " > " + text + Environment.NewLine : text + Environment.NewLine;
            SuspendLayout();

            SelectionStart = TextLength;
            SelectedText = text;

            SelectionStart = TextLength - text.Length + 1;
            SelectionLength = text.Length;
            SelectionColor = color;

            ResumeLayout();

            Select(TextLength, 0);

            SelectionStart = TextLength;
            ScrollToCaret();
        }
    }
}
