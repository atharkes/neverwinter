using System;
using System.Windows.Forms;

namespace MastercraftWFA {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Database.StartDatabase("MCDatabase.sqlite");

            Application.Run(new Main() {
                Location = new System.Drawing.Point(350, 200),
                StartPosition = FormStartPosition.Manual
            });
        }
    }
}