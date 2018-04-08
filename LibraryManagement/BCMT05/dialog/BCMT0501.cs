using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.dialog;
using Common.exception;
using Common.define;
using Common.singleton;
using Common.db;

namespace BCMT05.dialog
{
    public partial class BCMT0501 : BaseForm
    {
        public BCMT0501()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OKボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if ( txtPass.Text.Equals(txtPassConfirm.Text) )
                {
                    if ( base.AskMessageBox(GlobalDefine.MESSAGE_PASSWORD_UPDATE) )
                    {
                        DBAdapter dba = SingletonObject.GetDbAdapter();
                        string query = string.Format("UPDATE SYSTEM_DEFINE_MASTER SET VALUE = '{0}' WHERE KEY = 'password'", txtPass.Text);
                        dba.nonExecSQL(query);
                        MessageBox.Show(GlobalDefine.MESSAGE_PASSWORD_CHANGE);
                        this.Close();
                    }
                }else
                {
                    throw new InputException(GlobalDefine.ERROR_CODE[8].message, GlobalDefine.ERROR_CODE[8].code);
                }

            }catch(InputException ex)
            {
                MessageBox.Show(ex.Message);
                txtPass.Clear();
                txtPassConfirm.Clear();
                txtPass.Focus();
            }
        }

        /// <summary>
        /// キャンセルボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
