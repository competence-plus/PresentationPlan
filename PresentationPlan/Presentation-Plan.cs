using PresentationPlan.Properties;
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
    public partial class PresentationPlan : GApp.Win.UI.Forms.GEmptyForm
    {
        bool isNewMessage = false;

        public PresentationPlan()
        {
            InitializeComponent();

            this.InitializePosition();
            this.InitializeNavigator();
            this.InitializeTextMessage();
            this.InitializeTimer();
        }

        #region Position
        private void InitializePosition()
        {
            int margin = 10;
            int height = 110;
            this.WindowState = FormWindowState.Normal;


            Rectangle workingArea = Screen.GetWorkingArea(this);

            // to Params
            this.TopMost = true;


            this.Height = height;
            this.Location = new Point(margin, workingArea.Bottom - this.Height - margin);
            this.Width = workingArea.Width - margin * 2;



            // Transparant
            //this.BackColor = Color.LimeGreen;
            //this.TransparencyKey = Color.LimeGreen;

            // Move
           

        }
        #endregion

        #region Navigation
        private void InitializeNavigator()
        {
            this.bindingNavigator1.Visible = false;
        }



        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_mask_Click(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.TopMost = false;
                this.toolStripButton_mask.Image = Resources.ic_radio_button_unchecked_black_24dp_1x;
            }
            else
            {
                this.TopMost = true;
                this.toolStripButton_mask.Image = Resources.ic_radio_button_checked_black_24dp_1x;
            }
        }
        #endregion

      

        #region InitializeTextMessage
        private void InitializeTextMessage()
        {

            this.wpF_TextMessage.MessageTextKeyDown += WpF_TextMessage_MessageTextKeyDown;

            // on over
            this.MouseEnter += TextMessage_MouseEnter;
            this.bindingNavigator1.MouseLeave += bindingNavigator_MouseLeave;

            this.wpF_TextMessage.BorderBrush = System.Windows.Media.Brushes.Gray;


        }

        private void WpF_TextMessage_MessageTextKeyDown(object sender, EventArgs e)
        {
            if (isNewMessage)
            {
                this.wpF_TextMessage.Text = "";
            }
            this.timer1.Stop();
            this.timer1.Start();
            this.isNewMessage = false;
        }

        private void bindingNavigator_MouseLeave(object sender, EventArgs e)
        {
            this.bindingNavigator1.Visible = false;
        }

        private void TextMessage_MouseEnter(object sender, EventArgs e)
        {
            this.bindingNavigator1.Visible = true;
        }
        #endregion

        #region Initialize Timer
        private void InitializeTimer()
        {
           // this.timer1.Enabled = false;
           // this.timer1.Interval = 120000;
           //  this.timer1.Tick += Timer1_Tick;

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.isNewMessage = true;
        }
        #endregion


    }
}
