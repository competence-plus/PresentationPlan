using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationPlan
{
    public partial class Form1 : GApp.Win.UI.Forms.GEmptyForm
    {
        public Form1()
        {
            InitializeComponent();

            this.InitializePosition();
            this.InitializeNavigator();
            this.InitializeTextMessage();
        }


        private void InitializeTextMessage()
        {
            // on over
            this.textMessage.MouseEnter += TextMessage_MouseEnter;
            this.bindingNavigator1.MouseLeave += bindingNavigator_MouseLeave;

            this.textMessage.BackColor = Color.White;
        }

        #region TextMessage on over
        private void bindingNavigator_MouseLeave(object sender, EventArgs e)
        {
            this.bindingNavigator1.Visible = false;
        }

        private void TextMessage_MouseEnter(object sender, EventArgs e)
        {
            this.bindingNavigator1.Visible = true;
        }
        #endregion

        private void InitializeNavigator()
        {
            this.bindingNavigator1.Visible = false;
        }

        private void InitializePosition()
        {
            int margin = 10;
            this.WindowState = FormWindowState.Normal;

            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.TopMost = true;

            this.Location = new Point(margin, workingArea.Bottom - this.Height - margin);
            this.Width = workingArea.Width - margin * 2;


            // Transparant
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;


        }

    }
}
