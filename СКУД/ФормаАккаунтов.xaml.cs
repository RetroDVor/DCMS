using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
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
    class Account
    {
        public int id { get; set; }
        public string typeOfAccount { get; set; }
        public string name { get; set; }
        public string password { get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для ФормаАккаунтов.xaml
    /// </summary>
    public partial class ФормаАккаунтов : Window
    {
        НачальнаяФорма startform;
        BDLogic Logic;
        List<DbDataRecord> Strings;
        string rights;

        public OleDbCommand OleDbCmd { get; private set; }
        public object OleDbDReader { get; private set; }
        public object OleDbCn { get; private set; }

        public ФормаАккаунтов(НачальнаяФорма loginform, BDLogic Logic, string rights)
        {
            InitializeComponent();
            this.startform = loginform;
            this.Logic = Logic;
            this.rights = rights;
            List<DbDataRecord> strings = Logic.GetTable("Accounts");
            DataGridФормаАккаунтов.ItemsSource = strings;
            /*if (rights == "Только просмотр")
            {
                Insert.Enabled = false;
                Delete.Enabled = false;
            }
            */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Account ТекущийСотрудник;
            int i;
            OpenConnection();
            List<DbDataRecord> records = GetTable("Customer");
            List<Account> customers = new List<Account>();
            for (i = 0; i < records.Count; i++)
            {
                ТекущийСотрудник = new Account();
                ТекущийСотрудник.id = records[i].GetInt32(0);
                ТекущийСотрудник.name = records[i].GetString(1);
                customers.Add(ТекущийСотрудник);
            }

            DataGridФормаАккаунтов.ItemsSource = customers;
        }
            public List<DbDataRecord> GetTable(string TableName)
            {

            OleDbCmd = new OleDbCommand("Select * From " + TableName, OleDbCn);
            OleDbDReader = OleDbCmd.ExecuteReader();
            Strings = new List<DbDataRecord>();
            foreach (System.Data.Common.DbDataRecord rec in OleDbDReader)
            {
                Strings.Add(rec);
            }
            OleDbDReader.Close();
            return Strings;
        }
        public void OpenConnection()
        {
            OleDbCn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\\Instruments.accdb");
            OleDbCn.Open();
            return;
        }


    }


}


