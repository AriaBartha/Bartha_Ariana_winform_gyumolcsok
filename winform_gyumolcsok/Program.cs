using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_gyumolcsok
{
    internal static class Program
    {
       
        public static GyumolcsAdatok nyitoForm = null;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            nyitoForm = new GyumolcsAdatok();
            Application.Run(nyitoForm);
        }
    }
}
