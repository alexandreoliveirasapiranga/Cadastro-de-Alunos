using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_de_Alunos
{
    class sisDBADM
    {
        private const string _strCon = @"Data Source=DESKTOP-CPISHFM;Initial Catalog=crude_alunos;Integrated Security=True";
        private string vsql = "";
        SqlConnection objCon = null;
        private bool conectar()
        {
            objCon = new SqlConnection(_strCon);
            try
            {
                objCon.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool desconectar()
        {
            if (objCon.State != ConnectionState.Closed)
            {
                objCon.Close();
                objCon.Dispose();
                return true;
            }
            else
            {
                objCon.Dispose();
                return false;
            }
        }
        public bool Insert(ArrayList p_arrInsert)
        {
            vsql = "INSERT INTO crudedb ([nome],[idade],[endereco],[telefone],[email],[cidade],[uf],[nome_pai],[nome_mae])" +
            "VALUES (@nome,@idade,@endereco,@telefone,@email,@cidade,@uf,@nome_pai,@nome_mae)";
            SqlCommand objcmd = null;
            if (this.conectar())
            {
                try
                {
                    objcmd = new SqlCommand(vsql, objCon);
                    objcmd.Parameters.Add(new SqlParameter("@nome", p_arrInsert[0]));
                    objcmd.Parameters.Add(new SqlParameter("@idade", p_arrInsert[1]));
                    objcmd.Parameters.Add(new SqlParameter("@endereco", p_arrInsert[2]));
                    objcmd.Parameters.Add(new SqlParameter("@telefone", p_arrInsert[3]));
                    objcmd.Parameters.Add(new SqlParameter("@email", p_arrInsert[4]));
                    objcmd.Parameters.Add(new SqlParameter("@cidade", p_arrInsert[5]));
                    objcmd.Parameters.Add(new SqlParameter("@uf", p_arrInsert[6]));
                    objcmd.Parameters.Add(new SqlParameter("@nome_pai", p_arrInsert[7]));
                    objcmd.Parameters.Add(new SqlParameter("@nome_mae", p_arrInsert[8]));
                    objcmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException sqlerr)
                {
                    throw sqlerr;
                }
                finally
                {
                    this.desconectar();
                }
            }
            else
            {
                return false;
            }
        }
        public bool update(ArrayList p_arruUpdate)
        {
            vsql = "UPDATE crudedb SET nome = @nome, idade = @idade, endereco = @endereco,telefone = @telefone, email = @email, cidade = @cidade, uf = @uf, nome_pai = @nome_pai, nome_mae = @nome_mae WHERE id_aluno=@id_aluno";
            SqlCommand objcmd = null;
            if (this.conectar())
            {
                try
                {
                    objcmd = new SqlCommand(vsql, objCon);
                    objcmd.Parameters.Add(new SqlParameter("@id_aluno", p_arruUpdate[0]));
                    objcmd.Parameters.Add(new SqlParameter("@nome", p_arruUpdate[1]));
                    objcmd.Parameters.Add(new SqlParameter("@idade", p_arruUpdate[2]));
                    objcmd.Parameters.Add(new SqlParameter("@endereco", p_arruUpdate[3]));
                    objcmd.Parameters.Add(new SqlParameter("@telefone", p_arruUpdate[4]));
                    objcmd.Parameters.Add(new SqlParameter("@email", p_arruUpdate[5]));
                    objcmd.Parameters.Add(new SqlParameter("@cidade", p_arruUpdate[6]));
                    objcmd.Parameters.Add(new SqlParameter("@uf", p_arruUpdate[7]));
                    objcmd.Parameters.Add(new SqlParameter("@nome_pai", p_arruUpdate[8]));
                    objcmd.Parameters.Add(new SqlParameter("@nome_mae", p_arruUpdate[9]));
                    objcmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException sqlerr)
                {
                    throw sqlerr;
                }
                finally
                {
                    this.desconectar();
                }
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id_aluno)
        {
            vsql = "DELETE FROM crudedb WHERE id_aluno = @id_aluno";
            SqlCommand objcmd = null;
            if (this.conectar())
            {
                try
                {
                    objcmd = new SqlCommand(vsql, objCon);
                    objcmd.Parameters.AddWithValue("@id_aluno", id_aluno);
                    objcmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException sqlerr)
                {
                    throw sqlerr;
                }
                finally
                {
                    this.desconectar();
                }
            }
            else
            {
                return false;
            }
        }
        public DataTable listarGrid()
        {
            vsql = "SELECT [id_aluno] As CODIGO,[nome],[idade],[endereco],[telefone],[email], [nome_pai],[nome_mae] FROM crudedb";
            SqlCommand objcmd = null;
            if (this.conectar())
            {
                try
                {
                    objcmd = new SqlCommand(vsql, objCon);
                    SqlDataAdapter adp = new SqlDataAdapter(objcmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    return dt;
                }
                catch (SqlException sqlerr)
                {
                    throw sqlerr;
                }
                finally
                {
                    this.desconectar();
                }
            }
            else
            {
                return null;
            }
        }
        public DataTable Pesquisar(String sql, string param)
        {
            this.vsql = sql;
            SqlCommand objcmd = null;
            if (this.conectar())
            {
                try
                {
                    objcmd = new SqlCommand(vsql, objCon);
                    objcmd.Parameters.Add(new SqlParameter("@VALOR", param));
                    SqlDataAdapter adp = new SqlDataAdapter(objcmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    return dt;
                }
                catch (SqlException sqlerr)
                {
                    throw sqlerr;
                }
                finally
                {
                    this.desconectar();
                }
            }
            else
            {
                return null;
            }
        }
        public List<string> listaUF()
        {
            vsql = "SELECT uf FROM estado";
            SqlCommand objcmd = null;
            List<string> uf = new List<string>();
            if (this.conectar())
            {
                try
                {
                    objcmd = new SqlCommand(vsql, objCon);
                    objcmd.ExecuteNonQuery();
                    SqlDataReader dr = objcmd.ExecuteReader();
                    while (dr.Read())
                    {
                        uf.Add(dr["uf"].ToString());
                    }
                    return uf;
                }
                catch (SqlException sqlerr)
                {
                    throw sqlerr;
                }
                finally
                {
                    this.desconectar();
                }
            }
            else
            {
                return null;
            }
        }
        public List<string> listaCidade(string uf)
        {
            vsql = "SELECT nome FROM cidade WHERE uf= @uf";
            SqlCommand objcmd = null;
            List<string> cidade = new List<string>();
            if (this.conectar())
            {
                try
                {
                    objcmd = new SqlCommand(vsql, objCon);
                    objcmd.Parameters.AddWithValue("@uf", uf);
                    SqlDataReader dr = objcmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cidade.Add(dr["nome"].ToString());
                    }
                    return cidade;
                }
                catch (SqlException sqlerr)
                {
                    throw sqlerr;
                }
                finally
                {
                    this.desconectar();
                }
            }
            else
            {
                return null;
            }
        }
    }
}
