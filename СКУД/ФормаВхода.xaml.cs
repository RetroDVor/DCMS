using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ФормаВхода : Window
    {
        private BDLogic Logic;
        public ФормаВхода()
        {
            InitializeComponent();
            Logic = new BDLogic();
            Logic.OpenConnection();
        }

        private void ButtonВход_Click(object sender, RoutedEventArgs e)
        {
            List<DbDataRecord> strings = Logic.GetTable("Accounts");
            string rights = "";
            string str;
            for (int i = 0; i < strings.Count; i++)
            {
                DbDataRecord rec = strings[i];
                str = "";
                if (!rec.IsDBNull(2))
                    str = rec.GetString(2);
                if (TextboxИмя.Text == str)
                {
                    if (!rec.IsDBNull(3))
                    {
                        if (TextboxПароль.Text == rec.GetString(3))
                        {
                            rights = rec.GetString(1);
                            this.Visibility = Visibility.Hidden;
                            НачальнаяФорма startform = new НачальнаяФорма(this, Logic, rights);
                            startform.Visibility = Visibility.Visible;
                            return;

                        }
                    }
                }
            }
        }
    }
}
