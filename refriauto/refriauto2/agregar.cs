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
using System.Text.RegularExpressions;
using System.Security.Cryptography;

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

        string carpeta = "";
        string archivo_local = "";
        string sFileName = "";
        string xfolio = "";
        string xreceptor_nombre = "";
        string xreceptor_rfc = "";
        string xfecha = "";
        string xtotal = "";
        string xmoneda = "";
        string xtipo = "";
        int count = 0;
        int count_error = 0;
        string errorFileName = "";
        string xserver = "";
        string xuser = "";
        string xpassword = "";
        string archivo = "";
        string file_download = "";
        public static bool bool_detener = false;
        int contador_ftp = 1;
        int porcentaje = 1;
        int count_reales = 0;
        string carpeta_name = "";
        string ytipo = "";

        int afolio = 0;
        string afecha = "";
        string areceptor_rfc = "";
        string asucursal = "";
        string filename = "";
        string filename2 = "";
        string terminacion_archivo = "";

        //const string document = @"\"{archivo}\"" ;
        static string uploads = Path.Combine(Environment.CurrentDirectory, "Subidas");
        static string downloads = Path.Combine(Environment.CurrentDirectory, "Descargas");


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private string generarClaveSHA1(string cadena)
        {

            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();

            result = sha.ComputeHash(data);


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {

                // Convertimos los valores en hexadecimal
                // cuando tiene una cifra hay que rellenarlo con cero
                // para que siempre ocupen dos dígitos.
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }

            //Devolvemos la cadena con el hash en mayúsculas para que quede más chuli :)
            return sb.ToString().ToUpper();
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
        private void actualizar_moneda(int folio, string sucursal, string moneda, string rfc)
        {
            String insercion = $"UPDATE facturas_ah SET moneda = '{moneda}' WHERE folio = '{folio}' and sucursal = '{sucursal}' and receptor_rfc = '{rfc}';";
            Query.CommandText = insercion;
            Query.Connection = conexion;
            consultar = Query.ExecuteReader();
        }



        

        private void agregar_archivos(string archivo)
        {
            int folio_xml = 0;
            if (Sucursal.Text == "Sucursal")
            {
                MessageBox.Show("Debe seleccionar una sucursal", "Seleccionar Sucursal");

            }
            else
            {
                lb_estado.ForeColor = Color.Gray;
                lb_estado.Text = "Procesando...";
                lb_exito.Text = "Facturas capturadas con éxito: --";
                lb_error.Text = "Error en -- facturas";
                errorFileName = "";

                lb_exito.Text = "Facturas capturadas con éxito: --";
                lb_error.Text = "Error en -- facturas";



                //LEER XML
            //    MessageBox.Show("vamo a leerlo");
                try
                {
          //          MessageBox.Show("voy a leer el xml");
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(@carpeta + "/" + archivo);

                    XmlNodeList xcomprobante = xDoc.GetElementsByTagName("cfdi:Comprobante");
                    //XmlNodeList xLista = ((XmlElement)xcomprobante[0]).GetElementsByTagName("cfdi:Comprobante");

                    foreach (XmlElement nodo in xcomprobante)
                    {
                        xfolio = nodo.GetAttribute("Folio");
                        xfecha = nodo.GetAttribute("Fecha").Replace("T", " ");
                        xtotal = nodo.GetAttribute("Total");
                        xmoneda = nodo.GetAttribute("Moneda");
                        xtipo = nodo.GetAttribute("TipoDeComprobante");
                     //   MessageBox.Show(xtipo);
                        xreceptor_nombre = nodo.InnerText;
                 //       MessageBox.Show("ya leí " + xfolio + xfecha + xtotal + xmoneda + xtipo );

                    }

                    XmlNodeList xreceptor = xDoc.GetElementsByTagName("cfdi:Receptor");
                    //XmlNodeList xLista = ((XmlElement)xcomprobante[0]).GetElementsByTagName("cfdi:Comprobante");

                    foreach (XmlElement nodo in xreceptor)
                    {
                        xreceptor_rfc = nodo.GetAttribute("Rfc");
                        xreceptor_nombre = nodo.GetAttribute("Nombre");
            //            MessageBox.Show("ya leí otras" + xreceptor_rfc + xreceptor_nombre);

                    }
                    /* lb_estado.Text = "Proceso finalizado.";
                     lb_estado.ForeColor = Color.Green;*/

                    /*
                     *
                     *
                     *  try
                      {
                          variable = ";server=shared109.accountservergroup.com;user id=cmiranda_tests;database=cmiranda_tests;password=,,k!uFCP_BVGnh";
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
                    /*
                     *
                     *
                     *      count_error = count_error + 1;
                          errorFileName = errorFileName + "\n" + archivo;
                          dgv_errores.Rows.Add(archivo);
                      }*/

                    folio_xml = Convert.ToInt32(xfolio);
                    MySqlCommand Query = new MySqlCommand();
                    MySqlConnection Conexion;
                    MySqlDataReader consultar;
                    string sql = ";server=shared109.accountservergroup.com;user id=cmiranda_tests;database=cmiranda_tests;password=,,k!uFCP_BVGnh";
                    try
                    {
                        Conexion = new MySqlConnection();
                        Conexion.ConnectionString = sql;
                        Conexion.Open();
                        Query.CommandText = "SELECT * FROM cmiranda_tests.facturas_ah where folio = '" + folio_xml + "' AND sucursal = '" + Sucursal.Text + "' AND tipo  = '"+xtipo+"';"; /*CAMBIAR TIPO*/
                        Query.Connection = Conexion;
                        consultar = Query.ExecuteReader();
                        while (consultar.Read())
                        {
                            afolio = consultar.GetInt32(0);
                            DateTime afecha = Convert.ToDateTime(consultar.GetString(1));
                           // MessageBox.Show(""+rfecha);
                            areceptor_rfc = consultar.GetString(4);
                            asucursal = consultar.GetString(7);
                            //   MessageBox.Show("Cliente:\n" + folio);
                        //    MessageBox.Show("" + areceptor_rfc);
                        //    MessageBox.Show("" + archivo);

                            // MessageBox.Show(archivo,"Archivo");
                            //     download();
                            //  MessageBox.Show(""+afecha);
                            Directory.CreateDirectory(@"Descargas/" + generarClaveSHA1(xreceptor_rfc));
                            string fecha = Convert.ToDateTime(afecha).ToString("yyyy-MM-dd HH:mm:ss");
                          //  MessageBox.Show(fecha);
                            // MessageBox.Show(fecha.ToString("yyyy-MM-dd") + " " + Convert.ToString(afecha).Substring(11, 8));
                           // string rfecha = fecha.ToString("yyyy-MM-dd") + " " + Convert.ToString(afecha).Substring(11, 8);
                            filename = "" + afolio + "" + Convert.ToDateTime(afecha).ToString("yyyy-MM-dd HH:mm:ss") + "" + areceptor_rfc + "" + Sucursal.Text;
                            textBox1.Text = filename;
                         //   MessageBox.Show(filename);
                            File.Move(@carpeta + "/" + archivo, @"Descargas/" + generarClaveSHA1(xreceptor_rfc) + "/" + generarClaveSHA1(filename) + ".xml");
                           // count_reales++;
                        }
                        Conexion.Close();
                    }


                    catch (MySqlException e)
                    {
                        MessageBox.Show(e.Message);
                    }


                    try
                    {
                        variable = ";server=shared109.accountservergroup.com;user id=cmiranda_tests;database=cmiranda_tests;password=,,k!uFCP_BVGnh";
                        conexion = new MySqlConnection(variable);
                        conexion.Open();
                        actualizar_moneda(afolio, Sucursal.Text, xmoneda, xreceptor_rfc);
                        conexion.Close();
                        count = count + 1;
                    }
                    catch (MySqlException er)
                    {
                    }





                    //    File.Move(@"Descargas/"+ carpeta_name + "/"+archivo, @"Descargas/" + generarClaveSHA1(xreceptor_rfc) + "/" + generarClaveSHA1(xfolio+xfecha+xreceptor_rfc+Sucursal)+".pdf");

                }
                catch (Exception)
                {
                    /* lb_estado.Text = "Error al leer el archivo";
                     lb_estado.ForeColor = Color.Red;*/
                    count_error = count_error + 1;
                    errorFileName = errorFileName + "\n" + archivo;
                    dgv_errores.Rows.Add(archivo);

                }
            }


            lb_estado.Text = "Esperando archivos";

            lb_exito.Text = "Facturas capturadas con éxito: " + count;
            lb_error.Text = "Error en " + count_error + " facturas";            
        }
        private void bt_agregar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Insertar los datos en la tabla?", "Insertar datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    variable = ";server=shared109.accountservergroup.com;user id=cmiranda_tests;database=cmiranda_tests;password=,,k!uFCP_BVGnh";
                    conexion = new MySqlConnection(variable);
                    conexion.Open();
                    insertar_datos(Convert.ToInt32(xfolio), xfecha, Convert.ToDouble(xtotal), xreceptor_rfc, xreceptor_nombre, Sucursal.Text, xtipo);
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
        private void proceso()
        {


            FtpWebResponse response = null;
            try
            {

                xserver = tb_server.Text;
                xuser = tb_user.Text;
                xpassword = tb_password.Text;




                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(xserver);
                ftpRequest.Credentials = new NetworkCredential(xuser, xpassword);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                response = (FtpWebResponse)ftpRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());

                List<string> directories = new List<string>();

               // contador_archivos();

                int i = 0;
                string line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    directories.Add(line);
                    line = streamReader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }
                    file_download = line;
                    seleccionar_facturas(file_download);


                    Application.DoEvents();
                    if (bool_detener == true)
                    {
                        bool_detener = false;
                        break;
                    }
                    i++;
                }

                streamReader.Close();
            }
            catch (WebException er)
            {
                MessageBox.Show(er.Message);
            }
        }
        private void contar_archivos()
        {
            FtpWebResponse response = null;
            try
            {
                xserver = tb_server.Text;
                xuser = tb_user.Text;
                xpassword = tb_password.Text;

                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(xserver);
                ftpRequest.Credentials = new NetworkCredential(xuser, xpassword);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                response = (FtpWebResponse)ftpRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());

                List<string> directories = new List<string>();
                
                string line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    directories.Add(line);
                    line = streamReader.ReadLine();
                    string factura_pdf = "([Ff]+(000)+([0-9]{7})+(\\.[Pp][Dd][Ff]))";
                    string factura = "([Ff]+(000)+([0-9]{7})+(\\.[Xx][Mm][Ll]))";
                    string nota_credito = "([NC]+(000)+([0-9]{7})+(\\.xml))";
                    string nota_credito_pdf = "([NC]+(000)+([0-9]{7})+(\\.pdf))";
                    string comp_pago = "([REP]+(000)+([0-9]{7})+(\\.xml))";
                    string comp_pago_pdf = "([REP]+(000)+([0-9]{7})+(\\.pdf))";
                    if (Regex.IsMatch(line, factura_pdf) || Regex.IsMatch(line, nota_credito) || Regex.IsMatch(line, comp_pago) || Regex.IsMatch(line, factura_pdf) || Regex.IsMatch(line, nota_credito_pdf) || Regex.IsMatch(line, comp_pago_pdf))
                    {
                        contador_ftp++;
                    }

                                     
                }


                streamReader.Close();
            }
            catch (WebException er)
            {
                MessageBox.Show(er.Message);
            }
        }


        private void bt_examinar_Click_1(object sender, EventArgs e)
        {
            DateTime tiempo1 = DateTime.Now;
            lb_tiempo.Text = "Tiempo de ejecución";
            count_reales = 0;
            bt_detener.Visible = true;
            dgv_errores.ColumnCount = 0;
            dgv_errores.ColumnCount = 1;
            dgv_errores.Columns[0].Name = "Errores";
            if (Sucursal.Text == "Sucursal")
            {
                MessageBox.Show("Debe seleccionar una sucursal", "Seleccionar Sucursal");

            }
            else
            {
                lb_estado.ForeColor = Color.Gray;
                lb_estado.Text = "Procesando...";
                lb_exito.Text = "Facturas capturadas con éxito: --";
                lb_error.Text = "Error en -- facturas";
                errorFileName = "";
                count = 0;
                count_error = 0;
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = true;

                if (choofdlog.ShowDialog() == DialogResult.OK)
                {
                    lb_exito.Text = "Facturas capturadas con éxito: --";
                    lb_error.Text = "Error en -- facturas";

                 //   MessageBox.Show(""+choofdlog.SafeFileNames.Length);

                    foreach (String cadena in choofdlog.FileNames)
                    {
                        //FileInfo file = FileInfo(f);
                        FileInfo file = new FileInfo(cadena);
                        //string dir = OpenFileDialog.FileName();
                        carpeta = Path.GetDirectoryName(choofdlog.FileName);
                       // MessageBox.Show(carpeta);
                        sFileName = file.Name;
                   //     MessageBox.Show(file.Name);
                        archivo_local = sFileName;
                        // MessageBox.Show(archivo_local);
                        terminacion_archivo = archivo_local.Substring((archivo_local.Length) - 4, 4);

                        seleccionar_facturas2(Convert.ToString(archivo_local));
                        //sFileName = choofdlog.FileName;
                        //LEER XML
                        /* try
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
                              lb_estado.ForeColor = Color.Green;

                             try
                             {
                                 variable = ";server=shared109.accountservergroup.com;user id=cmiranda_tests;database=cmiranda_tests;password=,,k!uFCP_BVGnh";
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
                                   lb_estado.ForeColor = Color.Red;
                                 count_error = count_error + 1;
                                 errorFileName = errorFileName + "\n" + file.Name;
                                 dgv_errores.Rows.Add(file.Name);
                             }
                         }
                         catch (Exception)
                         {
                             /* lb_estado.Text = "Error al leer el archivo";
                              lb_estado.ForeColor = Color.Red;
                             count_error = count_error + 1;
                             errorFileName = errorFileName + "\n" + file.Name;
                             dgv_errores.Rows.Add(file.Name);

                         }  */
                        /* count_reales++;
                         porcentaje = (count_reales * 100) / choofdlog.SafeFileNames.Length;
                         pb_proceso.Value = porcentaje;
                         lb_poncentaje.Text = count_reales + " de " + choofdlog.SafeFileNames.Length;
                         Application.DoEvents();
                         if (bool_detener == true)
                         {
                             bool_detener = false;
                             break;
                         }*/
                    }

                }
                else
                {
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
            bt_detener.Visible = false;
            DateTime tiempo2 = DateTime.Now;
            TimeSpan total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
            lb_tiempo.Text = ("Tiempo de ejecución: " + total.ToString().Substring(total.ToString().Length - 16, 13));
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
            MessageBox.Show("Error al procesar las siguientes facturas:\n" + errorFileName, "Detalles");
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
            if (cb_ftp.Items.Count > 0)
                cb_ftp.SelectedIndex = 0;
        }        
           
        //Descargar archivos FTP
        private void download()
        {
           FtpWebResponse response = null;
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(xserver + file_download);
                ftpRequest.Credentials = new NetworkCredential(xuser, xpassword);
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpRequest.Credentials = ftpRequest.Credentials;
                using (MemoryStream stream = new MemoryStream())

                {
                    ((FtpWebResponse)ftpRequest.GetResponse()).GetResponseStream().CopyTo(stream);
                    File.WriteAllBytes(Path.Combine(downloads + "/" + carpeta_name, file_download), stream.ToArray());
                    stream.Close();
                }                
            }
            catch (WebException er)
            {
                MessageBox.Show(er.Message);
            }

        }






        private void bt_ftp_Click(object sender, EventArgs e)
        {
            DateTime tiempo1 = DateTime.Now;
            lb_tiempo.Text = "Tiempo de ejecución";
            dgv_errores.ColumnCount = 0;
            dgv_errores.ColumnCount = 1;
            dgv_errores.Columns[0].Name = "Errores";
            carpeta_name = Sucursal.Text;
            bt_detener.Visible = true;
            Directory.CreateDirectory(@"Descargas/"+carpeta_name);
            count = 0;
            count_error = 0;
            lb_estado.Text = "Procesando...";
            lb_estado.ForeColor = Color.Gray;
            contador_ftp = 1;
            count_reales = 0;
            porcentaje = 0;

            if (Sucursal.Text == "Sucursal")
            {
                MessageBox.Show("Debe seleccionar una sucursal", "Seleccionar Sucursal");
                lb_estado.Text = "Proceso terminado.";
                lb_estado.ForeColor = Color.Green;
            }
            else
            {
            
            if (tb_server.Text == "" | tb_user.Text == "" | tb_password.Text == "" )
            {
                MessageBox.Show("Faltan valores para la conexión FTP... \n\n" + "Servidor= "+tb_server.Text+"\n"
                    +"Usuario= "+tb_user.Text+"\nContraseña= "+tb_password.Text,"Datos incompletos");
                    lb_estado.Text = "Proceso terminado.";
                    lb_estado.ForeColor = Color.Green;
                }
                else
            {
                    if (tb_server.Text.Substring(0, 6) != "ftp://")
                    {
                        tb_server.Text = "ftp://" + tb_server.Text;
                    }
                    if (tb_server.Text.Substring(tb_server.Text.Length - 1, 1) != "/" )
                    {
                        tb_server.Text = tb_server.Text + "/";
                    }

                    if (Sucursal.Text != cb_ftp.Text)
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Está seguro de que quiere agregar datos a la sucursal: \n" + Sucursal.Text + "\n\nDesde el FTP:\n" + cb_ftp.Text + "?", "Alerta", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            proceso();
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                        }
                    }
                    else
                    {
                        proceso();
                    }
                                       

                lb_estado.Text = "Proceso finalizado.";
            }
            if (count_error == 0)
            {
                dgv_errores.Rows.Add("Sin errores");
            }
            lb_estado.Text = "Proceso finalizado.";
            lb_estado.ForeColor = Color.Green;
            System.IO.Directory.Delete(@"Descargas/"+ carpeta_name, true);

            }
            bt_detener.Visible = false;
            porcentaje = 0;
            DateTime tiempo2 = DateTime.Now;
            TimeSpan total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
            lb_tiempo.Text = ("Tiempo de ejecución: " + total.ToString().Substring(total.ToString().Length - 16, 13));
        }

        private void lb_exito_Click(object sender, EventArgs e)
        {

        }

        public void seleccionar_facturas2(string archivo)
        {
         //   MessageBox.Show(""+folio_pdf);
            int folio_pdf = 0;
            lb_estado.Text = "Procesando...";
            lb_estado.ForeColor = Color.Gray;
            string factura_pdf = "([Ff]+(000)+([0-9]{7})+(\\.[Pp][Dd][Ff]))";
            string factura = "([Ff]+(000)+([0-9]{7})+(\\.[Xx][Mm][Ll]))";
            string nota_credito = "([NC]+(000)+([0-9]{7})+(\\.[Xx][Mm][Ll]))";
            string nota_credito_pdf = "([NC]+(000)+([0-9]{7})+(\\.[Pp][Dd][Ff]))";
            string comp_pago = "([REP]+(000)+([0-9]{7})+(\\.[Xx][Mm][Ll]))";
            string comp_pago_pdf = "([REP]+(000)+([0-9]{7})+(\\.[Pp][Dd][Ff]))";
            /*  string[] names = { "F000010388e3.xml", "F0000103921.xml",
                           "F0000103935.xml", "F0000104200,xml" };
              foreach (string named in names)*/
    //        MessageBox.Show(terminacion_archivo);
            if (terminacion_archivo == ".xml")
            {
                // MessageBox.Show(archivo,"Archivo");
                //download();
          //   MessageBox.Show("es  xml");

                agregar_archivos(archivo);
                count_reales++;
            }
            if (Regex.IsMatch(archivo, factura_pdf) || Regex.IsMatch(archivo, nota_credito_pdf) || Regex.IsMatch(archivo, comp_pago_pdf) || terminacion_archivo == ".pdf")
            {
                //     MessageBox.Show(archivo.Substring(3, 10));

                if (archivo.Substring(0, 1) == "F")
                {
                    folio_pdf = Convert.ToInt32(archivo.Substring(1, 10));
                    ytipo = "I";
                }
                if (archivo.Substring(0, 1) == "R")
                {
                    folio_pdf = Convert.ToInt32(archivo.Substring(3, 10));
                    ytipo = "P";
                }
                if (archivo.Substring(0, 1) == "N")
                {
                    folio_pdf = Convert.ToInt32(archivo.Substring(2, 10));
                    ytipo = "E";
                }
        //        MessageBox.Show("" + folio_pdf);

                //      MessageBox.Show(""+folio_pdf);
                // MessageBox.Show( "" + folio_pdf);

                MySqlCommand Query = new MySqlCommand();
                MySqlConnection Conexion;
                MySqlDataReader consultar;
                string sql = ";server=shared109.accountservergroup.com;user id=cmiranda_tests;database=cmiranda_tests;password=,,k!uFCP_BVGnh";
                try
                {
                    Conexion = new MySqlConnection();
                    Conexion.ConnectionString = sql;
                    Conexion.Open();
                    Query.CommandText = "SELECT * FROM cmiranda_tests.facturas_ah where folio = '" + folio_pdf + "' AND sucursal = '" + Sucursal.Text + "' and tipo = '"+ytipo+"';"; /*CAMBIAR TIPO*/
                    Query.Connection = Conexion;
                    consultar = Query.ExecuteReader();
                    while (consultar.Read())
                    {
                        afolio = consultar.GetInt32(0);
                        afecha = consultar.GetString(1);

                        //MessageBox.Show("" + afecha);
                        areceptor_rfc = consultar.GetString(4);
                        asucursal = consultar.GetString(7);


               //         MessageBox.Show(areceptor_rfc +" - " +afecha);
                        // MessageBox.Show(archivo,"Archivo");
                        // download();

                        if (areceptor_rfc != null)
                        {
                            Directory.CreateDirectory(@"Descargas/" + generarClaveSHA1(areceptor_rfc));
                            DateTime fecha = Convert.ToDateTime(afecha);
                            // MessageBox.Show(fecha.ToString("yyyy-MM-dd") + " " + Convert.ToString(afecha).Substring(11, 8));
                            string rfecha = fecha.ToString("yyyy-MM-dd") + " " + Convert.ToString(afecha).Substring(11, 8);
                            // MessageBox.Show(rfecha);
                            filename2 = ("" + afolio + "" + Convert.ToDateTime(afecha).ToString("yyyy-MM-dd HH:mm:ss") + "" + areceptor_rfc + "" + asucursal);
                    //        MessageBox.Show(filename2);
                            textBox2.Text = filename2;
                            File.Move(@carpeta + "/" + archivo, @"Descargas/" + generarClaveSHA1(areceptor_rfc) + "/" + generarClaveSHA1(filename2) + ".pdf");
                        }

                        count_reales++;
                    }
                    Conexion.Close();
                }
                catch (MySqlException e)
                {
                    MessageBox.Show(e.Message);
                }

            }

            porcentaje = (count_reales * 100) / contador_ftp;
         //   pb_proceso.Value = porcentaje;
            lb_poncentaje.Text = count_reales + " de " + contador_ftp;
        }

        //SELECCIONAR SOLO FACTURAS
        public void seleccionar_facturas(string archivo)
        {
            int folio_pdf = 0;
            lb_estado.Text = "Procesando...";
            lb_estado.ForeColor = Color.Gray;
            string factura_pdf = "([Ff]+(000)+([0-9]{7})+(\\.[Pp][Dd][Ff]))";
            string factura = "([Ff]+(000)+([0-9]{7})+(\\.[Xx][Mm][Ll]))";
            string nota_credito = "([NC]+(000)+([0-9]{7})+(\\.xml))";
            string nota_credito_pdf = "([NC]+(000)+([0-9]{7})+(\\.[Pp][Dd][Ff]))";
            string comp_pago = "([REP]+(000)+([0-9]{7})+(\\.xml))";
            string comp_pago_pdf = "([REP]+(000)+([0-9]{7})+(\\.[Pp][Dd][Ff]))";
            /*  string[] names = { "F000010388e3.xml", "F0000103921.xml",
                           "F0000103935.xml", "F0000104200,xml" };
              foreach (string named in names)*/

            if (Regex.IsMatch(archivo, factura)|| Regex.IsMatch(archivo, nota_credito) || Regex.IsMatch(archivo,comp_pago))
            {
          //       MessageBox.Show(archivo,"Archivo");
                download();
                agregar_archivos(archivo);
                count_reales++;
            }
            if (Regex.IsMatch(archivo, factura_pdf) || Regex.IsMatch(archivo, nota_credito_pdf) || Regex.IsMatch(archivo, comp_pago_pdf))
            {
                MessageBox.Show(""+archivo);
                folio_pdf = Convert.ToInt32(archivo.Substring(2,10));
               // MessageBox.Show( "" + folio_pdf);
               
                    MySqlCommand Query = new MySqlCommand();
                    MySqlConnection Conexion;
                    MySqlDataReader consultar;
                    string sql = ";server=shared109.accountservergroup.com;user id=cmiranda_tests;database=cmiranda_tests;password=,,k!uFCP_BVGnh";
                    try
                    {
                        Conexion = new MySqlConnection();
                        Conexion.ConnectionString = sql;
                        Conexion.Open();
                        Query.CommandText = "SELECT * FROM cmiranda_tests.facturas_ah where folio = '"+folio_pdf+"' AND sucursal = '"+ Sucursal.Text +"';";
                        Query.Connection = Conexion;
                        consultar = Query.ExecuteReader();
                        while (consultar.Read())
                        {
                            afolio = consultar.GetInt32(0);
                            afecha = consultar.GetString(1);

                        //MessageBox.Show("" + afecha);
                        areceptor_rfc = consultar.GetString(4);
                            asucursal = consultar.GetString(7);


                        // MessageBox.Show(archivo,"Archivo");
                              download();
          //              MessageBox.Show(""+areceptor_rfc);

                        if (areceptor_rfc != null)
                        {
                            Directory.CreateDirectory(@"Descargas/" + generarClaveSHA1(areceptor_rfc));
                            DateTime fecha = Convert.ToDateTime(afecha);
                            // MessageBox.Show(fecha.ToString("yyyy-MM-dd") + " " + Convert.ToString(afecha).Substring(11, 8));
                            string rfecha = fecha.ToString("yyyy-MM-dd") + " " + Convert.ToString(afecha).Substring(11, 8);
                           // MessageBox.Show(rfecha);
                            filename2 = ("" + afolio + "" + Convert.ToDateTime(afecha).ToString("yyyy-MM-dd HH:mm:ss") + "" + areceptor_rfc + "" + asucursal);
                            textBox2.Text = filename2;
                      //      MessageBox.Show(filename2);
                            File.Move(@"Descargas/" + carpeta_name + "/" + archivo, @"Descargas/" + generarClaveSHA1(areceptor_rfc) + "/" + generarClaveSHA1(filename2) + ".pdf");
                        }

                        count_reales++;
                    }
                        Conexion.Close();
                    }
                    catch (MySqlException e)
                    {
                        MessageBox.Show(e.Message);
                    }
              
            }

            porcentaje = (count_reales * 100) / contador_ftp;
//            pb_proceso.Value = porcentaje;
            lb_poncentaje.Text = count_reales + " de " + contador_ftp;
        }

        private void bt_detener_Click(object sender, EventArgs e)
        {
            bool_detener = true;
        }

        private void cb_ftp_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cb_ftp.Text == "Seleccionar FTP")
            {
                tb_server.Enabled = true;
                tb_user.Enabled = true;
                tb_password.Enabled = true;
            }
            else
            {
                tb_server.Enabled = false;
                tb_user.Enabled = false;
                tb_password.Enabled = false;

                if (cb_ftp.Text == "Prueba")
                {
                    tb_server.Text = "x";
                    tb_user.Text ="x";
                    tb_password.Text = "x";
                }
                if (cb_ftp.Text == "Caborca")
                {
                    tb_server.Text = "refriautocaborca.ddns.net/facturas/";
                    tb_user.Text = "RefriautoCabFact";
                    tb_password.Text = "FTPf4ct.";
                }
                if (cb_ftp.Text == "Cd. Obregon")
                {
                    tb_server.Text = "refriautoobregon.ddns.net/facturas/";
                    tb_user.Text = "RefriautoObgFact";
                    tb_password.Text = "FTPf4ct.";
                }
                if (cb_ftp.Text == "Chihuahua")
                {
                    tb_server.Text = "refriautochihuahua.ddns.net/facturas/";
                    tb_user.Text = "RefriautoChiFact";
                    tb_password.Text = "FTPf4ct.";
                }
                if (cb_ftp.Text == "Coatzacoalcos")
                {
                    tb_server.Text = "";
                    tb_user.Text = "";
                    tb_password.Text = "FTPf4ct.";
                }
                if (cb_ftp.Text == "Comalcalco")
                {
                    tb_server.Text = "refriautocomal.ddns.net/facturas/";
                    tb_user.Text = "RefriautoComFact";
                    tb_password.Text = "FTPf4ct.";
                }
                if (cb_ftp.Text == "Guadalajara")
                {
                    tb_server.Text = "refriautogdl.ddns.net/facturas/";
                    tb_user.Text = "RefriautoGdlFact";
                    tb_password.Text = "FTPf4ct.";
                }
                if (cb_ftp.Text == "Hermosillo ( Bodega )")
                {
                    tb_server.Text = "192.168.10.5:41421/facturas/";
                    tb_user.Text = "Facturas";
                    tb_password.Text = "FTPf4ct.";
                }
                if (cb_ftp.Text == "Hermosillo ( Gaspar Luken )")
                {
                    tb_server.Text = "servergaspar:421/facturas/";
                    tb_user.Text = "RefriautoGasFact";
                    tb_password.Text = "FTPf4ct.";
                }
                if (cb_ftp.Text == "Hermosillo ( Modelo )")
                {
                    tb_server.Text = "refriautomodelo.ddns.net/facturas/";
                    tb_user.Text = "RefriautoModFact";
                    tb_password.Text = "FTPf4ct.";
                }
                if (cb_ftp.Text == "Hermosillo ( San Benito )")
                {
                    tb_server.Text = "REFRIAUTOREFA.DDNS.NET/facturas/";
                    tb_user.Text = "RefriautoRefaFact";
                    tb_password.Text = "FTPf4ct.";
                }
                if (cb_ftp.Text == "Hermosillo ( Taller )")
                {
                    tb_server.Text = "refriautomodelo.ddns.net:41421/facturas/";
                    tb_user.Text = "refriautotallerfact";
                    tb_password.Text = "FTPf4ct.";
                }
                if (cb_ftp.Text == "La Paz")
                {
                    tb_server.Text = "refriautolapaz.ddns.net/facturas/";
                    tb_user.Text = "RefriautoPazFact";
                    tb_password.Text = "FTPf4ct.";
                }
                if (cb_ftp.Text == "Los Mochis")
                {
                    tb_server.Text = "refriautomochis.ddns.net/facturas/";
                    tb_user.Text = "RefriautoMocFact";
                    tb_password.Text = "FTPf4ct.";
                }
                if (cb_ftp.Text == "Mexicali")
                {
                    tb_server.Text = "refriautomexicali.ddns.net/facturas/";
                    tb_user.Text = "RefriautoMexFact";
                    tb_password.Text = "FTPf4ct.";
                }
                if (cb_ftp.Text == "Navojoa")
                {
                    tb_server.Text = "refriautonavojoa.ddns.net/facturas/";
                    tb_user.Text = "RefriautoNavFact";
                    tb_password.Text = "FTPf4ct.";
                }
                if (cb_ftp.Text == "Tuxtla Gutierrez")
                {
                    tb_server.Text = "refriautotuxtla.ddns.net/facturas/";
                    tb_user.Text = "RefriautotuxFact";
                    tb_password.Text = "FTPf4ct.";
                }
                if (cb_ftp.Text == "Veracruz")
                {
                    tb_server.Text = "refriautoveracruz.ddns.net/facturas/";
                    tb_user.Text = "RefriautoverFact";
                    tb_password.Text = "FTPf4ct.";
                }
                if (cb_ftp.Text == "Villa Hermosa")
                {
                    tb_server.Text = "refriautovillah.ddns.net/facturas/";
                    tb_user.Text = "RefriautoVilFact";
                    tb_password.Text = "FTPf4ct.";
                }

                /*  if (cb_ftp.Text == "")
                  {
                      tb_server.Text = "";
                      tb_user.Text = "";
                      tb_password.Text = "";
                  } */

            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            contador_ftp = 0;
                    FtpWebResponse response = null;
                    try
                    {
                        xserver = tb_server.Text;
                        xuser = tb_user.Text;
                        xpassword = tb_password.Text;

                        FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(xserver);
                        ftpRequest.Credentials = new NetworkCredential(xuser, xpassword);
                        ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                        response = (FtpWebResponse)ftpRequest.GetResponse();
                        StreamReader streamReader = new StreamReader(response.GetResponseStream());

                        List<string> directories = new List<string>();

                        int i = 0;
                        string line = streamReader.ReadLine();
                        while (!string.IsNullOrEmpty(line))
                        {
                            directories.Add(line);
                            line = streamReader.ReadLine();
                            if (line == null)
                            {
                                break;
                            }
                    string factura_pdf = "([Ff]+(000)+([0-9]{7})+(\\.[Pp][Dd][Ff]))";
                    string factura = "([Ff]+(000)+([0-9]{7})+(\\.[Xx][Mm][Ll]))";
                    string nota_credito = "([NC]+(000)+([0-9]{7})+(\\.xml))";
                    string nota_credito_pdf = "([NC]+(000)+([0-9]{7})+(\\.pdf))";
                    string comp_pago = "([REP]+(000)+([0-9]{7})+(\\.xml))";
                    string comp_pago_pdf = "([REP]+(000)+([0-9]{7})+(\\.pdf))";
                    if (Regex.IsMatch(line, factura_pdf) || Regex.IsMatch(line, nota_credito) || Regex.IsMatch(line, comp_pago) || Regex.IsMatch(line, factura_pdf) || Regex.IsMatch(line, nota_credito_pdf) || Regex.IsMatch(line, comp_pago_pdf))
                             {
                        contador_ftp++;
                             }
                        }
                    MessageBox.Show(""+contador_ftp);
                        streamReader.Close();
                    }
                    catch (WebException er)
                    {
                        MessageBox.Show(er.Message);
                    }  
        }

        private void contador_archivos()
        {
            {
                contador_ftp = 1;
                FtpWebResponse response = null;
                try
                {
                    xserver = tb_server.Text;
                    xuser = tb_user.Text;
                    xpassword = tb_password.Text;

                    FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(xserver);
                    ftpRequest.Credentials = new NetworkCredential(xuser, xpassword);
                    ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                    response = (FtpWebResponse)ftpRequest.GetResponse();
                    StreamReader streamReader = new StreamReader(response.GetResponseStream());

                    List<string> directories = new List<string>();

                    int i = 0;
                    string line = streamReader.ReadLine();
                    while (!string.IsNullOrEmpty(line))
                    {
                        directories.Add(line);
                        line = streamReader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                        string factura_pdf = "([Ff]+(000)+([0-9]{7})+(\\.[Pp][Dd][Ff]))";
                        string factura = "([Ff]+(000)+([0-9]{7})+(\\.[Xx][Mm][Ll]))";
                        string nota_credito = "([NC]+(000)+([0-9]{7})+(\\.xml))";
                        string nota_credito_pdf = "([NC]+(000)+([0-9]{7})+(\\.pdf))";
                        string comp_pago = "([REP]+(000)+([0-9]{7})+(\\.xml))";
                        string comp_pago_pdf = "([REP]+(000)+([0-9]{7})+(\\.pdf))";
                        if (Regex.IsMatch(line, factura) || Regex.IsMatch(line, nota_credito) || Regex.IsMatch(line, comp_pago) || Regex.IsMatch(line, factura_pdf) || Regex.IsMatch(line, nota_credito_pdf) || Regex.IsMatch(line, comp_pago_pdf))
                        {
                            contador_ftp++;
                        }
                    }
                  //  MessageBox.Show("" + contador_ftp);
                    streamReader.Close();
                }
                catch (WebException er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
          //  string carpeta_encriptada = generarClaveSHA1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fech = "2018-04-12 06:18:45 p. m.";
            MessageBox.Show(Convert.ToDateTime(fech).ToString("yyyy-mm-dd HH:mm:ss"));
            DateTime fecha = Convert.ToDateTime(fech);
         //   MessageBox.Show(fech.Substring(11, 8));
          //  MessageBox.Show(fecha.ToString("yyyy-MM-dd")+" "+ Convert.ToDateTime(fech).ToString("HH:mm:ss"));
        }
    }
}
