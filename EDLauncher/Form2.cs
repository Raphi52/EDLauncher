using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDLauncher
{
    public partial class Form2 : Form
    {
        public EDLauncher _edLauncher;
            public Form2()
        {
            InitializeComponent();
            Load();
            splitE3Path();
        }
       public string selectedFolderLocal;
        public string selectedFile1;
        public string selectedFile2;
        public string selectedFile3;
        public string selectedFile4;
        public string selectedFolderE3;
        public bool filesAreTheSame = false;
        string[] e3Path;
        public string E3Path;
        public string argument;
        private void selectFile(string selectedFile, TextBox textBox)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string path = openFileDialog.FileName;
            textBox.Text = path;
            Save();
        }
      
        private void selectFolder(TextBox textBox, string folder)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            // Définir le répertoire initial du FolderBrowserDialog, si textBox1.Text contient un chemin valide
            if (!string.IsNullOrEmpty(textBox.Text) && System.IO.Directory.Exists(textBox.Text))
            {
                folderBrowserDialog.SelectedPath = textBox.Text;
            }
            // Afficher le FolderBrowserDialog
            DialogResult result = folderBrowserDialog.ShowDialog();

            // Vérifier si l'utilisateur a sélectionné un dossier et mettre à jour le textBox1.Text avec le chemin du dossier sélectionné
            if (result == DialogResult.OK)
            {
                textBox.Text = folderBrowserDialog.SelectedPath;
                folder = folderBrowserDialog.SelectedPath;
                textBox1.Text = folder;
            }
            Save();
        }
        private void Save()
        {// PROBLEME PATH
            string path = "./save.txt";
            File.WriteAllText(path, "");
            using (StreamWriter w = new StreamWriter(path))
            {
                w.WriteLine("Local Folder :");
                w.WriteLine(textBox1.Text);
                w.WriteLine("Server File 1:");
                w.WriteLine(textBox2.Text);
                w.WriteLine("Server File 2:");
                w.WriteLine(textBox3.Text);
                w.WriteLine("Server File 3:");
                w.WriteLine(textBox4.Text);
                w.WriteLine("Server File 4:");
                w.WriteLine(textBox5.Text);
                w.WriteLine("E3 Installation Folder :");
                w.WriteLine(textBox6.Text);
                w.WriteLine("Fast Launch :");
                if (checkBox1.Checked)
                    w.WriteLine("true");
                else
                    w.WriteLine("false");
                w.WriteLine("Always Update :");
                if (checkBox2.Checked)
                    w.WriteLine("true");
                else
                    w.WriteLine("false");
            }
        }
        public void Load()
        {
            try
            {
                using (StreamReader r = new StreamReader("save.txt"))
                {
                    if (!File.Exists("save.txt"))
                    {
                        return;
                    }
                    try
                    {
                        r.ReadLine();
                        textBox1.Text = r.ReadLine();
                        r.ReadLine();
                        textBox2.Text = r.ReadLine();
                        r.ReadLine();
                        textBox3.Text = r.ReadLine();
                        r.ReadLine();
                        textBox4.Text = r.ReadLine();
                        r.ReadLine();
                        textBox5.Text = r.ReadLine();
                        r.ReadLine();
                        textBox6.Text = r.ReadLine();
                        r.ReadLine();
                        if (r.ReadLine().Equals("true"))
                            checkBox1.Checked = true;
                        r.ReadLine();
                        if (r.ReadLine().Equals("true"))
                            checkBox2.Checked = true;

                        selectedFolderLocal = textBox1.Text;
                        selectedFile1 = textBox2.Text;
                        selectedFile2 = textBox3.Text;
                        selectedFile3 = textBox4.Text;
                        selectedFile4 = textBox5.Text;
                        selectedFolderE3 = textBox6.Text;
                    }catch (Exception ex) {
                     
                    } 
                }
            }
            catch (FileNotFoundException ex)
            {
            }

        }
        private void splitE3Path()
        {
            if (!string.IsNullOrEmpty(textBox6.Text))
            {
                if (textBox6.Text.Contains(".exe"))
                {
                    e3Path = textBox6.Text.Split(new string[] { ".exe" }, StringSplitOptions.None);
                }
                if (textBox6.Text.Contains(".lnk"))
                {
                    e3Path = textBox6.Text.Split(new string[] { ".lnk" }, StringSplitOptions.None);
                }
            }
                if (e3Path.Length >= 1)
                {
                    E3Path = e3Path[0].Trim('"'); // Retirer les guillemets du chemin du répertoire

                    if (e3Path.Length == 2)
                    {
                        argument = e3Path[1];
                    }
                    else
                    {
                        argument = string.Empty; // Aucun argument supplémentaire
                    }
                }
                else
                {
                    // Gérer le cas où la division ne produit pas au moins un élément
                    // Peut-être afficher un message d'erreur ou prendre une autre action appropriée
                }
            }
        private void button2_Click_1(object sender, EventArgs e)
        {
            selectFile(selectedFile1, textBox2);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            selectFile(selectedFile2, textBox3);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            selectFile(selectedFile3, textBox4);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            selectFile(selectedFile4, textBox5);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            selectFolder(textBox1, selectedFolderLocal);
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Save();
            MessageBox.Show("Paramètres enregistrés. Veuillez relancer le programme.");
            selectedFolderLocal = textBox1.Text;
            selectedFile1 = textBox2.Text;
            selectedFile2 = textBox3.Text;
            selectedFile3 = textBox4.Text;
            selectedFile4 = textBox5.Text;
            selectedFolderE3 = textBox6.Text;
            splitE3Path();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
