using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPIWebLookup {
    class Program {

        [STAThread]
        static void Main(string[] args) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please select Excel file containing NPI data";
            ofd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            if (ofd.ShowDialog() != DialogResult.OK) {
                return;
            }

            Console.WriteLine(ofd.FileName);
            Console.ReadKey();

        }
    }
}
