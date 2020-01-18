using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_VAGAS
{
    public partial class gbCadastro : Form
    {
        public gbCadastro()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Vagas i = new Vagas(txtNome.Text, txtEmail.Text, txtCPF.Text, txtSenha.Text, txtCargo.Text, txtTipoCargo.Text, txtEmpresa.Text, txtLocal.Text, txtSalario.Text, 1);
            txtID.Text = i.inserir().ToString();
        }
    }
}
