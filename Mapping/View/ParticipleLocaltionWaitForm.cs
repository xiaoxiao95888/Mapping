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
    public partial class ParticipleLocaltionWaitForm : WaitForm
    {
        public ParticipleLocaltionWaitForm()
        {
            InitializeComponent();
        }

        #region Overrides

        //public override void SetCaption(string caption)
        //{
        //    base.SetCaption(caption);
        //    this.Localtion_Caption.Text = caption;
        //}
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
                case WaitFormCommand.SetLocaltionCaption:
                    Localtion_Caption.Text = arg.ToString();
                    break;
                case WaitFormCommand.SetLocaltionProgress:
                    Localtion_progressBarControl.Position = (int)arg;
                    break;
                case WaitFormCommand.SetLocaltionTotal:
                    Localtion_Total.Text= arg.ToString();
                    break;
                case WaitFormCommand.SetLocaltionCurrent:
                    Localtion_Current.Text = arg.ToString();
                    break;
                case WaitFormCommand.SetLocaltionSucceed:
                    Localtion_Succeed.Text = arg.ToString();
                    break;
                case WaitFormCommand.SetParticipleCaption:
                    Participle_Caption.Text = arg.ToString();
                    break;
                case WaitFormCommand.SetParticipleProgress:
                    Participle_progressBarControl.Position = (int)arg;
                    break;
                case WaitFormCommand.SetParticipleTotal:
                    Participle_Total.Text = arg.ToString();
                    break;
                case WaitFormCommand.SetParticipleCurrent:
                    Participle_Current.Text = arg.ToString();
                    break;
                case WaitFormCommand.SetParticipleSucceed:
                    Participle_Succeed.Text = arg.ToString();
                    break;
            }
        }

        #endregion

        public enum WaitFormCommand
        {
            SetParticipleCaption,
            SetParticipleProgress,
            SetParticipleTotal,
            SetParticipleCurrent,
            SetParticipleSucceed,

            SetLocaltionCaption,
            SetLocaltionProgress,
            SetLocaltionTotal,
            SetLocaltionCurrent,
            SetLocaltionSucceed
        }
    }
}