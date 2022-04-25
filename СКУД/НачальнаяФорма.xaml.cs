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
using System.Windows.Shapes;

namespace СКУД
{
    /// <summary>
    /// Логика взаимодействия для НачальнаяФорма.xaml
    /// </summary>
    public partial class НачальнаяФорма : Window
    {
       
        ФормаВхода loginform;
        BDLogic Logic;
        string rights;
        public НачальнаяФорма(ФормаВхода loginform, BDLogic Logic, string rights)
        {
            InitializeComponent();
            this.loginform = loginform;
            this.Logic = Logic;
            this.rights = rights;
            if (rights != "Администратор")
            {
                ButtonРедактироватьУчётныеЗаписи.IsEnabled = false; 
            }
              
        }

        private void ButtonРедактироватьУчётныеЗаписи_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            ФормаАккаунтов accoutsform = new ФормаАккаунтов(this, Logic, rights);
            accoutsform.Visibility = Visibility.Visible;

        }
    }
}
