using System;
using System.Drawing;
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

        public TextModeEnum TextMode { get; set; } = TextModeEnum.Text;

        public enum TextModeEnum
        {
            Text,
            Numeric,
            Decimal
        }

        /// <summary>
        /// Texte affiché par défaut si aucun autre texte n'est saisi
        /// </summary>
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

        /// <summary>
        /// Obtient ou définit si le mode erreur est activé
        /// </summary>
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

        private void TextBoxPlus_Enter(object sender, EventArgs e)
        {
            ErrorMode = false;
            if (Text == DefaultText)
            {
                ForeColor = Color.Black;
                Text = "";
            }
        }

        private void TextBoxPlus_Leave(object sender, EventArgs e)
        {
            if (Text == "")
            {
                ForeColor = Color.LightGray;
                Text = DefaultText;
            }
        }

        private void TextBoxPlus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TextMode == TextModeEnum.Text)
                return;

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
