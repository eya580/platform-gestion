using System;
using System.Windows.Forms;
using (SqlConnection conn = Database.GetConnection())
{
    conn.Open();
}
namespace GestionPrets
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
