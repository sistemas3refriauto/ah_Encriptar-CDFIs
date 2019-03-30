using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net;

namespace refriauto
{

    public partial class agregar : Form
    {
        MySqlCommand Query = new MySqlCommand();
        public MySqlConnection conexion;
        MySqlDataReader consultar;
        public String variable;

        public agregar()
        {
            InitializeComponent();
        }

        string sFileName = "";
        string xfolio = "";
        string xreceptor_nombre = "";
        string xreceptor_rfc = "";
        string xfecha = "";
        string xtotal = "";
        string xtipo = "";
        int count = 0;
        int count_error = 0;
        string xerrores = "Sin errores";
        string errorFileName = "";
        string xserver = "";
        string xuser = "";
        string xpassword = "";
        string archivo = "F0000103921.xml";
        
          //const string document = @"\"{archivo}\"" ;
        static string uploads = Path.Combine(Environment.CurrentDirectory, "Subidas");
        static string downloads = Path.Combine(Environment.CurrentDirectory, "Descargas");


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu fm = new menu();
            this.Hide();
            fm.ShowDialog();
            this.Close();
        }

        private void tb_nombre_TextChanged(object sender, EventArgs e)
        {
        }

        private void tb_folio_TextChanged(object sender, EventArgs e)
        {

        }

        private void insertar_datos(int folio, string fecha, double total, string rfc, string nombre, string sucursal, string tipo)
        {
            String insercion = $"insert into facturas_ah (folio, fecha, total, receptor_rfc, receptor_nombre, sucursal, tipo) values ({folio},\"{fecha}\", {total},\"{rfc}\",\"{nombre}\",\"{sucursal}\",\"{tipo}\");";
            Query.CommandText = insercion;
            Query.Connection = conexion;
            consultar = Query.ExecuteReader();
        }

        private void bt_agregar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Insertar los datos en la tabla?", "Insertar datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    variable = ";server=shared109.accountservergroup.com;user id=cmiranda_tests;database=cmiranda_tests;password=nothingIsImpossible_";
                    conexion = new MySqlConnection(variable);
                    conexion.Open();
                    insertar_datos(Convert.ToInt32(xfolio),xfecha, Convert.ToDouble(xtotal), xreceptor_rfc, xreceptor_nombre, Sucursal.Text, xtipo);
                    MessageBox.Show("Se han insertado los datos correctamente", "Datos insertados");
                    conexion.Close();
                }
                catch (MySqlException er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void bt_leer_Click(object sender, EventArgs e)
        {


        }
       
        private void bt_examinar_Click_1(object sender, EventArgs e)
        {
            dgv_errores.ColumnCount = 0;
            dgv_errores.ColumnCount = 1;
            dgv_errores.Columns[0].Name = "Errores";
            if (Sucursal.Text == "Sucursal")
            {
                MessageBox.Show("Debe seleccionar una sucursal", "Seleccionar Sucursal");

            }
            else{
            lb_estado.ForeColor = Color.Gray;
            lb_estado.Text = "Procesando...";
            lb_exito.Text = "Facturas capturadas con éxito: --";
            lb_error.Text = "Error en -- facturas";
            errorFileName = "";
            xerrores = "Errores:";
            count = 0;
            count_error = 0;
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Archivos Xml (*.xml*)|*.xml*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;
                                    
            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                lb_exito.Text = "Facturas capturadas con éxito: --";
                lb_error.Text = "Error en -- facturas";


                foreach (String cadena in choofdlog.FileNames)
                {
                    //FileInfo file = FileInfo(f);
                    FileInfo file = new FileInfo(cadena);
                    sFileName = file.FullName;
                    //sFileName = choofdlog.FileName;
                    //LEER XML
                    try
                    {
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.Load(sFileName);

                        XmlNodeList xcomprobante = xDoc.GetElementsByTagName("cfdi:Comprobante");
                        //XmlNodeList xLista = ((XmlElement)xcomprobante[0]).GetElementsByTagName("cfdi:Comprobante");

                        foreach (XmlElement nodo in xcomprobante)
                        {
                            xfolio = nodo.GetAttribute("Folio");
                            xfecha = nodo.GetAttribute("Fecha");
                            xtotal = nodo.GetAttribute("Total");
                            xtipo = nodo.GetAttribute("TipoDeComprobante");
                            xreceptor_nombre = nodo.InnerText;

                        }

                        XmlNodeList xreceptor = xDoc.GetElementsByTagName("cfdi:Receptor");
                        //XmlNodeList xLista = ((XmlElement)xcomprobante[0]).GetElementsByTagName("cfdi:Comprobante");

                        foreach (XmlElement nodo in xreceptor)
                        {
                            xreceptor_rfc = nodo.GetAttribute("Rfc");
                            xreceptor_nombre = nodo.GetAttribute("Nombre");
                        }
                       /* lb_estado.Text = "Proceso finalizado.";
                        lb_estado.ForeColor = Color.Green;*/

                        try
                        {
                            variable = ";server=shared109.accountservergroup.com;user id=cmiranda_tests;database=cmiranda_tests;password=nothingIsImpossible_";
                            conexion = new MySqlConnection(variable);
                            conexion.Open();
                            insertar_datos(Convert.ToInt32(xfolio), xfecha, Convert.ToDouble(xtotal), xreceptor_rfc, xreceptor_nombre, Sucursal.Text, xtipo);
                            conexion.Close();
                            count = count + 1;
                        }
                        catch (MySqlException er)
                        {
                                //Mensaje de error
                              //  MessageBox.Show(er.Message);
                          /*  lb_estado.Text = "Error al insertar datos";
                            lb_estado.ForeColor = Color.Red;*/
                            count_error = count_error + 1;
                            errorFileName = errorFileName + "\n" + file.Name;
                                dgv_errores.Rows.Add(file.Name);
                            }
                    }
                    catch (Exception)
                    {
                       /* lb_estado.Text = "Error al leer el archivo";
                        lb_estado.ForeColor = Color.Red;*/
                        count_error = count_error + 1;
                        errorFileName = errorFileName + "\n" + file.Name;
                            dgv_errores.Rows.Add(file.Name);

                        }
                    }
                           
            }else{
                lb_estado.Text = "Esperando archivos";

            }
            lb_exito.Text = "Facturas capturadas con éxito: " + count;
            lb_error.Text = "Error en " + count_error + " facturas";
                if (count_error == 0)
                {
                    dgv_errores.Rows.Add("Sin errores");
                }
            }
            lb_estado.Text = "Proceso finalizado.";
            lb_estado.ForeColor = Color.Green;
            }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lb_detalles_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error al procesar las siguientes facturas:\n" + errorFileName , "Detalles");
            //Errores fm = new Errores();
            //fm.ShowDialog();
        }

        private void Sucursal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void agregar_Load(object sender, EventArgs e)
        {
            if (Sucursal.Items.Count > 0)
                Sucursal.SelectedIndex = 0;
        }



        //BORRAR






        private void bt_ftp_Click(object sender, EventArgs e)
        {
            if (Sucursal.Text == "Sucursal")
            {
                MessageBox.Show("Debe seleccionar una sucursal", "Seleccionar Sucursal");

            }
            else
            {
                xserver = tb_server.Text;
                xuser = tb_user.Text;
                xpassword = tb_password.Text;

                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://home663278740.1and1-data.host/");
                ftpRequest.Credentials = new NetworkCredential("u87802191-ahlex_test", "Q1w2e3r4_");
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());

                List<string> directories = new List<string>();

                int i = 0;
                string line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    directories.Add(line);
                    line = streamReader.ReadLine();
                    if (i<2)
                    {

                    }
                    else
                    {
                        MessageBox.Show(directories[i], "Lista");
                    }
                    
                    i++;
                }
                

                streamReader.Close();

                /*FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://home663278740.1and1-data.host/F0000103935.xml");
                request.Credentials = new NetworkCredential("u87802191-ahlex_test", "Q1w2e3r4_");
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                // hacer algo con el stream
                MessageBox.Show( Convert.ToString(response), "mensaje");

                stream.Dispose();
                response.Dispose();
                */


                /* WebRequest request = FtpWebRequest.Create(url);
                 using (WebResponse response = request.GetResponse())
                 {
                     Stream responseStream = response.GetResponseStream();
                     Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                     using (var reader = new StreamReader(responseStream, encode))
                     {
                         List<string> listA = new List<string>();
                         while (!reader.EndOfStream)
                         {
                             var line = reader.ReadLine();
                             var values = line.Split(';');
                             listA.Add(values[0]);
                         }
                     }
                 }*/

                /* System.Net.FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://home663278740.1and1-data.host");
                 request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                 request.Credentials = new NetworkCredential("u87802191-ahlex_test", "Q1w2e3r4_");
                 FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                 Stream responseStream = response.GetResponseStream();
                 StreamReader reader = new StreamReader(responseStream);
                 Console.WriteLine(reader.ReadToEnd());
                 //string ylista = reader.ReadToEnd();
                // MessageBox.Show(ylista , "Ficheros");
                // Console.WriteLine("Directory List Complete, status { 0} ", response.StatusDescription);
                 Console.ReadLine();
                 reader.Close();
                 response.Close(); */





            }
        }

        private void lb_exito_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            dgv_errores.DataSource = null; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgv_errores.ColumnCount = 1;
            dgv_errores.Columns[0].Name = "Errores";
        }
        

        private void button1_Click_3(object sender, EventArgs e)
        {

            if (Sucursal.Text == "Sucursal")
            {
                MessageBox.Show("Debe seleccionar una sucursal", "Seleccionar Sucursal");
            }
            else
            {
                xserver = tb_server.Text;
                xuser = tb_user.Text;
                xpassword = tb_password.Text;

                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://home663278740.1and1-data.host/" + "F0000103921.xml");
                ftpRequest.Credentials = new NetworkCredential("u87802191-ahlex_test", "Q1w2e3r4_");
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpRequest.Credentials = ftpRequest.Credentials;


                using (MemoryStream stream = new MemoryStream())
                {
                    ((FtpWebResponse)ftpRequest.GetResponse()).GetResponseStream().CopyTo(stream);
                    File.WriteAllBytes(Path.Combine(downloads, archivo), stream.ToArray());
                }


               // streamReader.Close();

             //   DownloadFile();
            }



        }
        
        }
}
