using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EntityGenerator
{
    public partial class CForm : Form
    {
        public CForm()
        {
            InitializeComponent();
            this.tbServer.Text = "127.0.0.1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbStyle style = DbStyle.Mysql;
            string sport = "0";
            string server = "127.0.0.1";
            string suser = "root";
            switch (cbDB.SelectedIndex)
            {
                case 0:
                    {
                        style = DbStyle.Mysql;
                        if (string.IsNullOrEmpty(tbPort.Text))
                        {
                            sport = "3306";
                        } else
                        {
                            sport = tbPort.Text.Trim();
                        }
                        if (!string.IsNullOrEmpty(tbServer.Text))
                        {
                            server = tbServer.Text.Trim();
                        }
                        break;
                    }
                case 1:
                    {
                        style = DbStyle.SqlServer;
                        break;
                    }
                case 2:
                    {
                        style = DbStyle.Oracle;
                        break;
                    }
                default:
                    {
                        style = DbStyle.Mysql;
                        break;
                    }
            }
            string sconn = string.Format("Data Source = '{0}'; User Id = '{1}'; Password ='{2}' ; Port='{3}'; charset = 'utf8'; pooling = true",
                server, suser, tbPwd.Text,sport);
            GForm gf =  new GForm(sconn,style);
            gf.Show();
            this.Hide();
        }

        private void cbDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbDB.SelectedIndex;
            switch (idx)
            {
                case 0:
                    {
                        tbUserName.Text = "root";
                        tbPort.Text = "3306";
                        break;
                    }
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
