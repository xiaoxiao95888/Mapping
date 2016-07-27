using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraWaitForm;

namespace Mapping.View
{
    public partial class ParticipleWaitForm : WaitForm
    {
        public ParticipleWaitForm()
        {
            InitializeComponent();
        }

        #region Overrides

        //public override void SetCaption(string caption)
        //{
        //    base.SetCaption(caption);
        //    this.progressPanel1.Caption = caption;
        //}
        //public override void SetDescription(string description)
        //{
        //    base.SetDescription(description);
        //    this.progressPanel1.Description = description;
        //}
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
            WaitFormCommand command = (WaitFormCommand)cmd;
            if (command == WaitFormCommand.SetProgress1)
            {
                int pos = (int)arg;
                progressBarControl1.Position = pos;
            }
            if (command == WaitFormCommand.SetProgress1)
            {
                int pos = (int)arg;
                progressBarControl1.Position = pos;
            }
            if (command == WaitFormCommand.SetProgressMax)
            {
                int pos = (int)arg;
                progressBarControl1.Properties.Maximum = pos;
            }
        }

        #endregion

        public enum WaitFormCommand
        {
            SetProgress1,
            SetProgressMax,
            Command2,
            Command3
        }
    }
}