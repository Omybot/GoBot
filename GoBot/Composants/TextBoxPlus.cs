using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Composants
{
    public partial class TextBoxPlus : TextBox
    {
        // Fonctionnalités supplémentaires :
        //      - Texte par défaut affiché en gris si aucun texte, disparition au focus
        //              DefaultText = "Exemple";
        //      - Mode erreur pour afficher le TextBox en rouge clair et police rouge. Disparition au focus.
        //              ErrorMode = true;
        //      - Mode numérique : n'accepte que les entiers
        //              TextMode = TextModeEnum.Numeric;
        //      - Mode décimal : n'accepte que les nombres décimaux
        //              TextMode = TextModeEnum.Decimal;

        private String defaultText = "";
        private bool errorMode = false;
        public TextModeEnum textMode = TextModeEnum.Text;

        public enum TextModeEnum
        {
            Text,
            Numeric,
            Decimal
        }

        public TextModeEnum TextMode
        {
            get
            {
                return textMode;
            }
            set
            {
                textMode = value;
            }
        }

        public String DefaultText 
        {
            get
            {
                return defaultText;
            }
            set
            {
                defaultText = value;
                if (Text == "")
                {
                    Text = defaultText;
                    ForeColor = Color.LightGray;
                }
            }
        }

        public TextBoxPlus()
        {
            InitializeComponent();
        }

        public bool ErrorMode
        {
            get 
            { 
                return errorMode; 
            }
            set
            {
                errorMode = value;

                if (errorMode)
                {
                    ForeColor = Color.Red;
                    BackColor = Color.Salmon;
                }
                else
                {
                    BackColor = Color.White;
                    if (Text == DefaultText)
                        ForeColor = Color.LightGray;
                    else
                        ForeColor = Color.Black;
                }
            }
        }

        private void BetterTextBox_Enter(object sender, EventArgs e)
        {
            ErrorMode = false;
            if (Text == DefaultText)
            {
                ForeColor = Color.Black;
                Text = "";
            }
        }

        private void BetterTextBox_Leave(object sender, EventArgs e)
        {
            if (Text == "")
            {
                ForeColor = Color.LightGray;
                Text = DefaultText;
            }
        }

        private void BetterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si la caractère tapé est numérique
            if (char.IsNumber(e.KeyChar))
                if (e.KeyChar == '²')
                    e.Handled = true; // Si c'est un '²', on gère l'evenement.
                else
                    return;

            // Si le caractère tapé est un caractère de "controle" (Enter, backspace, ...), on laisse passer
            else if (char.IsControl(e.KeyChar) || (e.KeyChar == '.' && this.TextMode != TextModeEnum.Numeric))
                e.Handled = false;

            else
                e.Handled = true; 
        }
    }
}
