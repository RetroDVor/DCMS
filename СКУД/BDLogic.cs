using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.Common;
using System.Windows;

namespace СКУД
{
    public class BDLogic
    {
        OleDbConnection OleDbCn;
        OleDbCommand OleDbCmd;
        OleDbDataReader OleDbDReader;
        List<DbDataRecord> Strings;
        public void OpenConnection()
        {
            OleDbCn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\\СКУД.accdb");
            OleDbCn.Open();
            return;
        }
        public void CloseConnection()
        {
            OleDbCn.Close();
        }
        public void InsertCustomer(string Name_customer, string Address, string Phone, string Fax, string Email)
        {
            OleDbCmd.CommandText = "Insert into Customer (Name_customer, Address, Phone, Fax, Email) Values ('" + Name_customer + "','" + Address + "','" + Phone + "','" + Fax + "','" + Email + "')";
            OleDbCmd.ExecuteNonQuery();
            return;
        }
        public void InsertManufacturer(string Firm, string Address, string Phone)
        {
            OleDbCmd.CommandText = "Insert into Manufacturer (Firm, Address, Phone) Values ('" + Firm + "','" + Address + "','" + Phone + "')";
            OleDbCmd.ExecuteNonQuery();
            return;
        }
        public void InsertOrder(long Code_goods, long Code_customer, DateTime Date_order, DateTime Date_delivery, long Countd, string Method_of_payment, double Cost, double Discount)
        {
            OleDbCmd.CommandText = "Insert into Orders (Code_goods, Code_customer,Date_order, Date_delivery, Method_of_payment, Cost, Discount, Countd) Values ('" + Code_goods + "','" + Code_customer + "','" + Date_order + "','" + Date_delivery + "','" + Method_of_payment + "','" + Cost + "','" + Discount + "','" + Countd + "')";
            OleDbCmd.ExecuteNonQuery();
            return;
        }
        public void InsertGoods(long Code_manufacturer, long Code_power_tool, double Price)
        {
            OleDbCmd.CommandText = "Insert into Goods (Code_manufacturer, Code_power_tool, Price) Values ('" + Code_manufacturer + "','" + Code_power_tool + "','" + Price + "')";
            OleDbCmd.ExecuteNonQuery();
            return;
        }
        public void InsertPowerTool(string Type, string Model, string Characteristic, string Article)
        {
            OleDbCmd.CommandText = "Insert into Power_tool (Type, Model, Characteristic, Article) Values ('" + Type + "','" + Model + "','" + Characteristic + "','" + Article + "')";
            OleDbCmd.ExecuteNonQuery();
            return;
        }
        public void InsertAccount(string Type_account, string Username, string Pass)
        {
            OleDbCmd.CommandText = "Insert into Accounts (Type_account, Username, Pass) Values ('" + Type_account + "','" + Username + "','" + Pass + "')";
            OleDbCmd.ExecuteNonQuery();
            return;
        }
        public void DeleteRecord(int id, string TableName, string Key)
        {
            try
            {
                OleDbCmd.CommandText = "DELETE FROM " + TableName + " WHERE " + Key + "=" + id + "";
                OleDbCmd.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return;
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
    }
}
