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
using Mapping.Helper;

namespace Mapping.View
{
    public partial class SaveBaseDataWaitForm : WaitForm
    {
        public SaveBaseDataWaitForm()
        {
            InitializeComponent();
         
        }
        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.Caption.Text = caption;
        }
        //public override void SetDescription(string description)
        //{
        //    base.SetDescription(description);
        //    this.label1.Text = description;
        //}
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
            var command = (WaitFormCommand)cmd;
            switch (command)
            {
                case WaitFormCommand.SetProgress:
                    var pos = (int)arg;
                    progressBarControl1.Position = pos;
                    break;
                case WaitFormCommand.SetInstitution:
                    Institution.Text = arg.ToString();
                    break;
                case WaitFormCommand.SetCaption:
                    Caption.Text= arg.ToString();
                    break;
            }
        }

        #endregion

        public enum WaitFormCommand
        {
            SetProgress,
            SetInstitution,
            SetCaption,
            SetCompleted
        }
    }
}