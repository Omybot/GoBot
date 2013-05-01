namespace GoBot.IHM.Composants
{
    partial class TextBoxPlus
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BetterTextBox
            // 
            this.Enter += new System.EventHandler(this.BetterTextBox_Enter);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BetterTextBox_KeyPress);
            this.Leave += new System.EventHandler(this.BetterTextBox_Leave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
