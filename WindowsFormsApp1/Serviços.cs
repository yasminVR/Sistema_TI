using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Serviços : Form
    {
        string servidor;
        MySqlConnection conexao;
        MySqlCommand comando;
        string idREGISTRO;
        string op = "";

        public Serviços()
        {
            InitializeComponent();

            servidor = "Server=localhost;Database=yasmin_servico_ti;Uid=root;Pwd=";
            conexao = new MySqlConnection(servidor);
            comando = conexao.CreateCommand();

            ATUALIZAR_CADASTRO();
        }
        private void LIMPAR_Cadastro()
        {
            textBoxNOME.Clear();
            textBoxSOBRENOME.Clear();
            textBoxEMAIL.Clear();
            textBoxTELEFONE.Clear();
            textBoxCELULAR.Clear();
            textBoxOBSERVACOES.Clear();
            textBoxQUEIXA.Clear();
            textBoxQUEIXA.Clear();
            textBoxVALOR.Clear();
            radioButtonATIVO.Checked = false;
            radioButtonANDAMENTO.Checked = false;
            radioButtonCONCLUIDO.Checked = false;
            radioButtonCANCELADO.Checked = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void ATUALIZAR_CADASTRO()
        {
            try
            {
                conexao.Open();
                comando.CommandText = "SELECT * FROM tbl_cadastro;";
                MySqlDataAdapter adaptadorCADASTRO = new MySqlDataAdapter(comando);
                DataTable tabelaCADASTRO = new DataTable();
                adaptadorCADASTRO.Fill(tabelaCADASTRO);
                dataGridViewCADASTROS.DataSource = tabelaCADASTRO;
            }
            catch (Exception erro_mysql)
            {
                MessageBox.Show(erro_mysql.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void buttonCADASTRAR_Click(object sender, EventArgs e)
        {
            labelNOME.ForeColor = Color.Black;

            if (radioButtonATIVO.Checked)
            {
                op = "ATIVO";
            }
            if (radioButtonANDAMENTO.Checked)
            {
                op = "ANDAMENTO";
            }
            MessageBox.Show(op);

            if (radioButtonCONCLUIDO.Checked)
            {
                op = "CONCLUÍDO";
            }
            if (radioButtonCANCELADO.Checked)
            {
                op = "CANCELADO";
            }
            MessageBox.Show(op);

            try
            {
                if (textBoxNOME.Text != "" && textBoxTELEFONE.Text != "")
                {
                    conexao.Open();
                    dateTimePickerENTRADA.CustomFormat = "yyyy-MM-dd";
                    dateTimePickerENTRADA.Format = DateTimePickerFormat.Custom;
                    comando.CommandText = "INSERT INTO tbl_cadastro(nome, sobrenome, email, telefone, celular, data_entrada, status, observacoes, caracteristicas_equipamento, queixa_cliente, valor_total) VALUES ('"+textBoxNOME.Text+"', '"+textBoxSOBRENOME.Text+"', '"+textBoxEMAIL.Text+"', '"+textBoxTELEFONE.Text+"', '"+textBoxCELULAR.Text+"', '"+dateTimePickerENTRADA.Text+"', '"+op+"', '"+textBoxOBSERVACOES.Text+"', '"+textBoxCARACTERISTICA.Text+"', '"+textBoxQUEIXA.Text+"', '"+textBoxVALOR.Text+"');";
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com SUCESSO!");
                    LIMPAR_Cadastro();
                }
                else
                {
                    MessageBox.Show("Nome e/ou Telefone estão em BRANCO! Por favor preencha!");

                    if (textBoxNOME.Text == "")
                    {
                        textBoxNOME.Focus();
                        labelNOME.ForeColor = Color.Red;
                    }
                    else
                    {
                        textBoxTELEFONE.Focus();
                        labelTELEFONE.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception erro_mysql)
            {
                //MessageBox.Show(erro_mysql.Message);
                MessageBox.Show("Erro de Sistema. Solicite ajuda!");
            }
            finally
            {
                conexao.Close();
            }
            ATUALIZAR_CADASTRO();
        }

        private void buttonALTERAR_Click(object sender, EventArgs e)
        {
            if (radioButtonATIVO.Checked)
            {
                op = "ATIVO";
            }
            if (radioButtonANDAMENTO.Checked)
            {
                op = "ANDAMENTO";
            }
            if (radioButtonCONCLUIDO.Checked)
            {
                op = "CONCLUÍDO";
            }
            if (radioButtonCANCELADO.Checked)
            {
                op = "CANCELADO";
            }

            try
            {
                conexao.Open();
                comando.CommandText = "UPDATE tbl_cadastro SET nome = '"+textBoxNOME.Text+"', sobrenome = '"+textBoxSOBRENOME.Text+"', email = '"+textBoxEMAIL.Text+"', telefone = '"+textBoxTELEFONE.Text+"', celular = '"+textBoxCELULAR.Text+ "', data_entrada = '"+dateTimePickerENTRADA.Text+"', status = '"+op+"', observacoes  = '"+textBoxOBSERVACOES.Text+"', caracteristicas_equipamento = '"+textBoxCARACTERISTICA.Text+ "', queixa_cliente = '"+textBoxQUEIXA.Text+ "', valor_total = "+textBoxVALOR.Text.Replace(",",".")+"  WHERE id = "+idREGISTRO+";";
                int resultado = comando.ExecuteNonQuery();
                if (resultado > 0)
                {
                    MessageBox.Show("Cadastro(s) atualizado(s) com sucesso! - " + resultado + " registros atualizados...");
                }
                else
                {
                    MessageBox.Show("Cadastro não encontrado!");
                }
            }
            catch (Exception erro_mysql)
            {
                //MessageBox.Show(erro_mysql.Message);
                MessageBox.Show("Erro de Sistema. Solicite ajuda!");
            }
            finally
            {
                conexao.Close();
            }
            ATUALIZAR_CADASTRO();
            LIMPAR_Cadastro();
        }

        private void buttonEXCLUIR_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente EXCLUIR este cadastro?", "Atenção!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    conexao.Open();

                    comando.CommandText = "DELETE FROM tbl_cadastro WHERE id = "+idREGISTRO+";";
                    int resultado = comando.ExecuteNonQuery();
                    if (resultado > 0)
                    {
                        MessageBox.Show("Cadastros(s) removido(s) com sucesso! - " + resultado + " cadastros removidos...");
                    }
                    else
                    {
                        MessageBox.Show("Cadastro não encontrado!");
                    }
                }
                catch (Exception erro_mysql)
                {
                    // Mensagem de erro - MySQL
                    // MessageBox.Show(erro_mysql.Message);

                    // Mensagem de erro - USUÁRIO
                    MessageBox.Show("Erro de Sistema. Solicite ajuda!");
                }
                finally
                {
                    conexao.Close();
                }
                ATUALIZAR_CADASTRO();
            }
            else
            {
                // MessageBox.Show("NÃO");
            }
            LIMPAR_Cadastro();
        }

        private void dataGridViewCADASTROS_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridViewCADASTROS.CurrentRow.Cells[7].Value.ToString()  == "ATIVO")
            {
                radioButtonATIVO.Checked = true;
            }
            if (dataGridViewCADASTROS.CurrentRow.Cells[7].Value.ToString() == "ANDAMENTO")
            {
                radioButtonATIVO.Checked = true;
            }
            if (dataGridViewCADASTROS.CurrentRow.Cells[7].Value.ToString() == "CONCLUÍDO")
            {
                radioButtonATIVO.Checked = true;
            }
            if (dataGridViewCADASTROS.CurrentRow.Cells[7].Value.ToString() == "CANCELADO")
            {
                radioButtonATIVO.Checked = true;
            }

            idREGISTRO = dataGridViewCADASTROS.CurrentRow.Cells[0].Value.ToString();

            textBoxNOME.Text = dataGridViewCADASTROS.CurrentRow.Cells[1].Value.ToString();
            textBoxSOBRENOME.Text = dataGridViewCADASTROS.CurrentRow.Cells[2].Value.ToString();
            textBoxEMAIL.Text = dataGridViewCADASTROS.CurrentRow.Cells[3].Value.ToString();
            textBoxTELEFONE.Text = dataGridViewCADASTROS.CurrentRow.Cells[4].Value.ToString();
            textBoxCELULAR.Text = dataGridViewCADASTROS.CurrentRow.Cells[5].Value.ToString();
            dateTimePickerENTRADA.Text = dataGridViewCADASTROS.CurrentRow.Cells[6].Value.ToString();
            textBoxOBSERVACOES.Text = dataGridViewCADASTROS.CurrentRow.Cells[8].Value.ToString();
            textBoxCARACTERISTICA.Text = dataGridViewCADASTROS.CurrentRow.Cells[9].Value.ToString();
            textBoxQUEIXA.Text = dataGridViewCADASTROS.CurrentRow.Cells[10].Value.ToString();
            textBoxVALOR.Text = dataGridViewCADASTROS.CurrentRow.Cells[11].Value.ToString();
        }
    }   
}