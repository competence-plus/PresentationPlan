using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Controls
{
    /// <summary>
    /// Logique d'interaction pour WPF_TextMessage.xaml
    /// </summary>
    public partial class WPF_TextMessage : UserControl
    {
        #region Events
        public event EventHandler UserTextChange;
        public event EventHandler MessageTextKeyDown;
        private bool isUserTextChangeEnable = true;
        public void onMessageTextKeyDown(object sender, EventArgs e)
        {
            if (MessageTextKeyDown != null)
                MessageTextKeyDown(sender, e);
        }
        public void onUserTextChange(object sender, EventArgs e)
        {
            if (isUserTextChangeEnable && UserTextChange != null)
                UserTextChange(sender, e);
        }
        #endregion

        #region Attributes
        private string OldTextMessage = "";
        #endregion

        public WPF_TextMessage()
        {
            InitializeComponent();

            // this.BorderThickness = new Thickness(3, 3, 3, 3);
            this.TextMessage.TextChanged += TextMessage_TextChanged;
            this.TextMessage.KeyDown += TextMessage_KeyDown;

            this.InitializeOldTextMessage();


        }

        private void TextMessage_KeyDown(object sender, KeyEventArgs e)
        {
            onMessageTextKeyDown(sender, e);
        }

        #region InitializeOldTextMessage
        private void InitializeOldTextMessage()
        {
            this.TextMessage.MouseEnter += TextMessage_GotFocus;

        }

        private void TextMessage_GotFocus(object sender, RoutedEventArgs e)
        {
            this.OldTextMessage = this.Text;
           
        }
        #endregion

        #region Properties
        public string Text
        {
            get
            {
                return new TextRange(this.TextMessage.Document.ContentStart, this.TextMessage.Document.ContentEnd).Text;
            }
            set
            {
                isUserTextChangeEnable = false;
                this.TextMessage.Document.Blocks.Clear();
                this.TextMessage.Document.Blocks.Add(new Paragraph(new Run(value)));
                isUserTextChangeEnable = true;
            }
        }
        #endregion

        private void TextMessage_TextChanged(object sender, TextChangedEventArgs e)
        {
            onUserTextChange(sender, e);
        }

    }
}
