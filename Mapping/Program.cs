using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Mapping.Model;
using System.Data.Entity;
using Mapping.Service;
using DevExpress.XtraSplashScreen;

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
            DataSource.SelectedItem = new Item();
            DataSource.SelectedPlace = new Place();
        }

        
    }
}
