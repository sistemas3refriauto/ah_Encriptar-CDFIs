using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace refriauto
{
    public partial class Validar : Form
    {
        MySqlCommand Query = new MySqlCommand();
        public MySqlConnection conexion;
        MySqlDataReader consultar;
        public String server;
        DataSet ds;


        public Validar()
        {
            InitializeComponent();
        }
        int xfaltantes = 0;
        int valor_agregar = 0;
        string sucursal = "";
        string tipo = "";

        private void insertar_datos(int valor_agregar)
        {
           // String insercion = $"insert into facturas_ah (folio, fecha, total, receptor_rfc, receptor_nombre, sucursal, tipo) values ({folio},\"{fecha}\", {total},\"{rfc}\",\"{nombre}\",\"{sucursal}\",\"{tipo}\");";
      //      String query = $"SELECT folio FROM cmiranda_tests.facturas_ah where (sucursal = 'chihuahua') AND(folio BETWEEN 104200 AND 1042016) ORDER BY folio ASC ;" ;
            String insercion = $"INSERT INTO cmiranda_tests.secuencia(folio_completo) VALUES({valor_agregar});";
            Query.CommandText = insercion;
            Query.Connection = conexion;
            consultar = Query.ExecuteReader();
        }

        private void limpiar_tabla()
        {
            String clean = $"TRUNCATE `cmiranda_tests`.`secuencia`;";
            Query.CommandText = clean;
            Query.Connection = conexion;
            consultar = Query.ExecuteReader();
        }
        private void conectar()
        {
            server = ";server=shared109.accountservergroup.com;user id=cmiranda_tests;database=cmiranda_tests;password=nothingIsImpossible_";
            conexion = new MySqlConnection(server);

        }

        //Crear una vista con los requisitos de la validación
        private void crear_vista(string sucursal, string tipo)
        {
            String clean = $"DROP VIEW `cmiranda_tests`.`consulta`; CREATE VIEW `consulta` AS SELECT* FROM cmiranda_tests.facturas_ah where (facturas_ah.sucursal = \"{sucursal}\" AND facturas_ah.tipo = \"{tipo}\");";
            Query.CommandText = clean;
            Query.Connection = conexion;
            consultar = Query.ExecuteReader();
        }
        
        private void count_faltantes()
        {
            String clean = $"SELECT COUNT(folio_faltante) FROM cmiranda_tests.faltantes;";
            Query.CommandText = clean;
            Query.Connection = conexion;
            consultar = Query.ExecuteReader();
        }

        private void vista_faltantes()
        {
            String clean = $"DROP VIEW faltantes; CREATE VIEW faltantes as SELECT folio_completo AS folio_faltante FROM consulta consulta right JOIN secuencia secuencia ON(consulta.folio = secuencia.folio_completo) WHERE(consulta.folio IS null);";
            Query.CommandText = clean;
            Query.Connection = conexion;
            consultar = Query.ExecuteReader();
        }

        

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu fm = new menu();
            this.Hide();
            fm.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                     {
                         e.Handled = false;
                     }
                else if (Char.IsControl(e.KeyChar))
                     {
                         e.Handled = false;
                     }
                 else if (Char.IsSeparator(e.KeyChar))
                     {
                         e.Handled = true;
                     }
                else
       {
                       e.Handled = true;
                    }
        }

        private void Sucursal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime tiempo1 = DateTime.Now;
            //Aviso de proceso
            dgv_faltantes.DataSource = null;
            lb_faltantes.Visible = false;
            lb_tiempo.Text = "Tiempo de ejecución";

            //Asegura al programa que se selecciona una sucursal
            if (cb_sucursal.Text == "Sucursal")
            {
                MessageBox.Show("Debe seleccionar una sucursal", "Seleccionar Sucursal");
            }
            else
            {

                //Modificar campos vacíos en los valores de rango
                if (tb_inicial.Text == "")
                {
                    tb_inicial.Text = "1";
                }
                if (tb_final.Text == "")
                {
                    tb_final.Text = "0";
                }

                sucursal = cb_sucursal.Text;
                if (cb_tipo.Text == "I - Factura")
                {
                    tipo = "I";
                }
                if (cb_tipo.Text == "E - Nota de crédito")
                {
                    tipo = "E";
                }
                if (cb_tipo.Text == "P - Comprobante de pago")
                {
                    tipo = "P";
                }

                //Llamar al metodo drop_vista
                /*try
                {
                    conectar();
                    conexion.Open();
                    drop_vista();
                    conexion.Close();

                }
                catch (MySqlException er)
                {
                    MessageBox.Show(er.Message);
                }*/

                //Llamar al metodo crear vista
                try
                {
                    conectar();
                    conexion.Open();
                    crear_vista(sucursal, tipo);
                    conexion.Close();

                }
                catch (MySqlException er)
                {
                    MessageBox.Show(er.Message);
                }

                //  Crear una secuencia de numeros con los valores esperados

                int min, max = 0;
                min = Convert.ToInt32(tb_inicial.Text);
                max = Convert.ToInt32(tb_final.Text);
                int valor = max - (min-1);
              //  xsecuencia = new int[valor + 2];
             //   xexisten = new int[valor + 2];

                if (min < max)
                {
                    //Limpiar tabla
                    try
                    {
                        conectar();
                        conexion.Open();
                        limpiar_tabla();
                        conexion.Close();

                    }
                    catch (MySqlException er)
                    {
                        MessageBox.Show(er.Message);
                    }

                    //Comenzar ciclo para secuencia

                    conectar();
                    int i = 1;
                    while (min <= max)
                    {
                     //   xsecuencia[i] = min + 1;
                     //   prueba = prueba + "" + xsecuencia[i] + "\n";
                     //   i++;
                        

                        valor_agregar = min;
                        //Crear una tabla con la secuencia creada
                        try
                        {

                            conexion.Open();
                            insertar_datos(min);
                            conexion.Close();
                            pb_progreso.Value = (i * 100) / valor;
                            min++;
                            i++;
                        }
                        catch (MySqlException er)
                        {
                            MessageBox.Show(er.Message);
                        }
                        
                    }

                    //Llamar metodo crear vista_resultados
                    //Limpiar tabla
                    try
                    {
                        conectar();
                        conexion.Open();
                        vista_faltantes();
                        conexion.Close();

                    }
                    catch (MySqlException er)
                    {
                        MessageBox.Show(er.Message);
                    }

                //    MessageBox.Show(prueba, "Mensaje");
                    try
                    {
                        //conectar();
                        server = ";server=shared109.accountservergroup.com;user id=cmiranda_tests;database=cmiranda_tests;password=nothingIsImpossible_";
                        conexion = new MySqlConnection(server);
                        conexion.Open();
                        //     count_faltantes();
                        //       newProdID = (Int32)cmd.ExecuteScalar();

                        String clean = $"SELECT COUNT(folio_faltante) FROM cmiranda_tests.faltantes;";
                        Query.CommandText = clean;
                        Query.Connection = conexion;
                       // consultar = Query.ExecuteReader();
                        xfaltantes = Convert.ToInt32(Query.ExecuteScalar());
                        conexion.Close();


                    }
                    catch (MySqlException er)
                    {
                        MessageBox.Show(er.Message);
                    }

                }
                else
                {
                    MessageBox.Show("Ingrese valores correctos para el folio", "Valores incorrectos");
                }
                
                //Resultados
                if (xfaltantes == 0)
                {
                    lb_faltantes.Text = "No hay faltantes";
                    lb_faltantes.ForeColor = Color.Green;
                    lb_faltantes.Visible = true;
                }
                else
                {
                    lb_faltantes.Text = "" + xfaltantes + " folios no encontrados.";
                    lb_faltantes.ForeColor = Color.Red;
                    lb_faltantes.Visible = true;

                    try
                    {
                        conectar();
                        conexion.Open();
                        MySqlCommand mostrar = new MySqlCommand("SELECT folio_faltante AS 'Folios_Faltantes' FROM cmiranda_tests.faltantes;", conexion);

                        MySqlDataAdapter m_datos = new MySqlDataAdapter(mostrar);
                        ds = new DataSet();
                        m_datos.Fill(ds);

                        dgv_faltantes.DataSource = ds.Tables[0];
                        conexion.Close();
                    }
                    catch (MySqlException er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
            }
            DateTime tiempo2 = DateTime.Now;
            TimeSpan total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
            lb_tiempo.Text=("Tiempo de ejecución: " + total.ToString().Substring(total.ToString().Length -16,13));
        }

        private void bt_ver_folios_Click(object sender, EventArgs e)
        {
            
        }

        private void Validar_Load(object sender, EventArgs e)
        {
            if (cb_sucursal.Items.Count > 0)
                cb_sucursal.SelectedIndex = 0;
            if (cb_tipo.Items.Count > 0)
                cb_tipo.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            



            /*  int[] valor;
              valor = new int[15];
              try
              {
                  //conectar();
                  server = ";server=shared109.accountservergroup.com;user id=cmiranda_tests;database=cmiranda_tests;password=nothingIsImpossible_";
                  conexion = new MySqlConnection(server);
                  conexion.Open();
                  //     count_faltantes();
                  //       newProdID = (Int32)cmd.ExecuteScalar();

                  String clean = $"SELECT * FROM cmiranda_tests.faltantes;";
                  Query.CommandText = clean;
                  Query.Connection = conexion;
                  //consultar = Query.ExecuteReader();
                  valor[3] = Convert.ToInt32(Query.ExecuteScalar());
                  // ReadSingleRow((IDataRecord)reader);
                 // valor[3] = Convert.ToInt32(SqlDataReader());
                  SqlLiteDataReader reader = new SQLiteDataAdapter(Query);
                  conexion.Close();

              }
              catch (MySqlException er)
              {
                  MessageBox.Show(er.Message);
              }
              MessageBox.Show("" + valor[3],"mensaje");          */
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            dgv_faltantes.ColumnCount = 1;
            dgv_faltantes.Columns[0].Name = "Errores";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgv_faltantes.ColumnCount = 0;

        }
    }
}
