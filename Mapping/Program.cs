using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using Mapping.Model;

namespace Mapping
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Init();
            Application.Run(new MainForm());
        }

        static void Init()
        {
            DataSource.DataSource1 = new BindingList<Item>();
            DataSource.DataSource2=new BindingList<Item>();
        }
    }
}
