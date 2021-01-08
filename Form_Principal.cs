using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cadastro_de_Alunos
{
    public partial class Form_Principal : Form
    {
        public Form_Principal()
        {
            InitializeComponent();
        }

                    

        private void cbCad_uf_SelectedIndexChanged(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();
            cbCad_cidade.DataSource = obj.listaCidade(cbCad_uf.Text);
            cbCad_cidade.DisplayMember = "nome";
        }


        private void toolStripButton4_Click(object sender, EventArgs e)
        {
           
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime dataHora = DateTime.Now;
            lbDateTimeH.Text = "Data de hoje : " + dataHora.ToShortDateString() + " " + "Hora: " + dataHora.ToLongTimeString();
        }

        private void tabPage6_Enter(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();
            dgEdtar.DataSource = obj.listarGrid();
        }

        private void tabPage7_Enter(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();
            dgExclui.DataSource = obj.listarGrid();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        //este método abaixo é do botão insert
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();
            ArrayList arr = new ArrayList();
            //([NOME],[IDADE],[ENDERECO],[TELEFONE],[EMAIL],[CIDADE],[UF],[NOME_PAI],[NOME_MAE])
            try
            {
                arr.Add(tbAdd_nome.Text); 
                arr.Add(tbAdd_idade.Text);
                arr.Add(tbAdd_endereco.Text);
                arr.Add(tbAdd_telefone.Text);
                arr.Add(tbAdd_email.Text);
                arr.Add(cbAdd_cidade.Text);
                arr.Add(cbAdd_UF.Text);
                arr.Add(tbAdd_pai.Text);
                arr.Add(tbAdd_mae.Text);
                if (obj.Insert(arr))
                {
                    MessageBox.Show("Cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro + "Erro ocorrido");
            }
            //testeDBinsert();
        }
        
        //Método atualizar --update
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();
            ArrayList arr = new ArrayList();

            arr.Add(tbAdd_codigo.Text);
            arr.Add(tbAddNome.Text);
            arr.Add(tbAddIdade.Text);
            arr.Add(tbAddEndereco.Text);
            arr.Add(tbAdd_telefone.Text);
            arr.Add(cbAddUF.Text);
            arr.Add(cbAddCidade.Text);
            arr.Add(tbAddEmail.Text);
            arr.Add(tbAddPai.Text);
            arr.Add(tbAddMae.Text);

            if (obj.update(arr))
            {
                MessageBox.Show("Atualizado");
                tabPage6_Enter(e, e);
            }
            else
            {
                MessageBox.Show("não Atualizado");
            }
        }

        //Botão Excluir registro
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();

            int codAluno = Convert.ToInt16(tb_excluir.Text);
            if (obj.Delete(codAluno))
            {
                MessageBox.Show("Apagado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabPage7_Enter(e, e);
            }
            else
            {
                MessageBox.Show("Erro ao apagar!", "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Botão pesquisar aluno
        private void btPesquisa_Click_1(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();
            string sql;
            if (rbNome.Checked)
            {
                sql = "SELECT [nome] As nome,[idade] As idade,[endereco] As endereco,[telefone] As telefone,[email] As Email FROM crudedb WHERE nome LIKE @VALOR";
                dgPesquisa.DataSource = obj.Pesquisar(sql, "%" + tbVPesquisa.Text + "%");
            }
            else
            {
                sql = "SELECT [nome] As nome,[idade] As idade,[endereco] As endereco,[telefone] As telefone,[email] As Email FROM crudedb WHERE id_aluno = @VALOR";
                dgPesquisa.DataSource = obj.Pesquisar(sql, tbVPesquisa.Text);
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //botao pesquisar 
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();
            string sql;
            if (rbNome.Checked)
            {
                sql = "SELECT [nome] As nome,[idade] As idade,[endereco] As endereco,[telefone] As telefone,[email] As email FROM crudedb WHERE nome LIKE @VALOR";
                dgPesquisa.DataSource = obj.Pesquisar(sql, "%" + tbVPesquisa.Text + "%");
            }
            else
            {
                sql = "SELECT [nome] As nome,[idade] As idade,[endereco] As endereco,[telefone] As telefone,[email] As email FROM crudedb WHERE nome LIKE @VALOR";
                dgPesquisa.DataSource = obj.Pesquisar(sql, tbVPesquisa.Text);
            }
        }

        private void Form_Principal_Load_1(object sender, EventArgs e)
        {
            timer2_Tick(e,e);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
    