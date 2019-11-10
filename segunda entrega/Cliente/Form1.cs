using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace Cliente
{    

    public partial class Form1 : Form
    {

        static private NetworkStream stream;//permitemanejar el flujo de informacion meanejarlo
        static private StreamWriter streamw;//permite escribir informacion en el flojo
        static private StreamReader streamr;//permite de el flujo de informacion
        static private TcpClient client = new TcpClient();//nos permite conectarnos al flijo de informacion
        static private string nick = "unknown";

        private delegate void DAddItem(String s); //sirve para mandar informacion entre procesos
        //*investigar delegados*//
            
              
        
        private void AddItem(String s)
        {
            listBox1.Items.Add(s);// se agrega el texto que esta en el flujo de informacion
        }



        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            streamw.WriteLine(textBox1.Text);
            streamw.Flush();
            textBox1.Clear();


        }


         void Listen()
        {
            while (client.Connected)//cuando el cliente este conectado
            {
                try
                {
                    this.Invoke(new DAddItem(AddItem), streamr.ReadLine());//se invoca al delegado que permite intecambiar informacion entre procesos deinido en las variables
                   // de no hacer esto no se puede hacer la comunicacion directa porque estamos en procesos diferentes
                }
                catch
                {
                    MessageBox.Show("No se ha podido conectar al servidor");
                    Application.Exit();
                }
            }
        }

         void Conectar()//aca se conecta al servidor
        {
            try
            {
                client.Connect("192.168.0.15", 8000);// poner el el cmd ipconfig y copiar lo que hay en el ipv4
                if (client.Connected)
                {
                    Thread t = new Thread(Listen);// si el cliente se conecta al hilo(procesos que trabajan a la vez), acepta por parametro la funcion listen

                    stream = client.GetStream();// se obtiene el flujo de informacion
                    streamw = new StreamWriter(stream);//busca que se quiere escribir
                    streamr = new StreamReader(stream);//leer de nuestro flijo de informacion

                    streamw.WriteLine(nick);//se manda al flujo de informacion el nick
                    streamw.Flush();//se limpia el flujo despues de enviar el mensaje

                    t.Start();//comienza el proceso
                }
                else
                {
                    MessageBox.Show("Servidor no Disponible");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Servidor no Disponible");
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox2.Visible = false;
            button2.Visible = false;
            listBox1.Visible = true;
            textBox1.Visible = true;
            Enviar.Visible = true;

            nick = textBox2.Text;

            Conectar();

        }
        private TreeNode CreaarArbol(DirectoryInfo  directoryInfo)
        {
            TreeNode treeNode = new TreeNode(directoryInfo.Name);

            foreach(var item in directoryInfo.GetDirectories())
            {
                treeNode.Nodes.Add(CreaarArbol(item));
            }

            foreach(var item in directoryInfo.GetFiles())
            {
                treeNode.Nodes.Add(new TreeNode(item.Name));
            }
            return treeNode;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string rutaBase = "C:\\Users\\necho\\Desktop\\cosas";
            treeView1.Nodes.Clear();
            DirectoryInfo directoryInfo = new DirectoryInfo(rutaBase);

            treeView1.Nodes.Add(CreaarArbol(directoryInfo));

            panel1.AllowDrop = true;
            panel1.DragEnter += new DragEventHandler(methodDragEnter);
            panel1.DragDrop += new DragEventHandler(methodDragDrop);
        }
        public void methodDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        public void methodDragDrop(object sender, DragEventArgs e)
        {
            listBox2.Items.Clear();

            string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach(string item in archivos)
            {
                listBox2.Items.Add(item);
            }

        }
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            string rutaAbsoluta = "C:\\Users\\necho\\Desktop\\" + treeView1.SelectedNode.FullPath;

            System.Diagnostics.Process.Start(rutaAbsoluta);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
