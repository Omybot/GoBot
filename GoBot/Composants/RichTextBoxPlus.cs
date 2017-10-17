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
