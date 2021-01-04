using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_de_Alunos
{
    public partial class Formulario_Login : Form
    {
        SqlConnection sqlCoon = null;
                                
        private string strCoon = @"Data Source=DESKTOP-CPISHFM;Initial Catalog=crude_alunos;Integrated Security=True";
        private string _sql = string.Empty;
        public bool logado = false;

        public Formulario_Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
                    
        public void logar()
        {
            sqlCoon = new SqlConnection(strCoon);
            string usu, pwd;
            try
            {
                usu = tb_usuario.Text;
                pwd = tb_senha.Text;
                _sql = "SELECT COUNT(id_usuario) FROM login_aluno WHERE @nome = nome AND @senha = senha ";
                SqlCommand cmd = new SqlCommand(_sql, sqlCoon);
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = usu;
                cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = pwd;
                sqlCoon.Open();
                int v = (int)cmd.ExecuteScalar();
                if (v > 0)
                {
                    logado = true;
                    MessageBox.Show("logado com sucesso");
                    
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Erro ao logar");
                    logado = false;
                }
            }
            catch
            {
            }
        }

        //botão logar
        private void btn_logar_Click(object sender, EventArgs e)
        {
            logar();
        }

        //botão sair       
        private void btn_sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
    

