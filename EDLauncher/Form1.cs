using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDLauncher
{
    public partial class EDLauncher : Form
    {
        public Form2 _form2;
        
        public EDLauncher(Form2 form2)
        {
            _form2 = form2;
            InitializeComponent();
           
        }

        public void Run()
        {
            this.Refresh();

            string[] localFiles = Array.Empty<string>();

           

            if (_form2.selectedFolderLocal != "" && (_form2.selectedFolderLocal != null))
            {
                try
                {
                    localFiles = Directory.GetFiles(_form2.selectedFolderLocal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dossier non trouvé.");
                    return;
                }
            }
            else
            {
                richTextBox1.Invoke(new Action(() => appendText("\n Veuillez Entrer un Dossier Local et Une/Des Source(s).")));

                _form2.Show();
                return;
            }


            if (_form2.selectedFile1 != "" && _form2.selectedFile1 != null)
            {

                foreach (string localFile in localFiles)
                {

                    FileInfo localFileInfo = new FileInfo(localFile);
                    FileInfo serverFileInfo = new FileInfo(_form2.selectedFile1);
                    string localFileName = Path.GetFileName(localFile);
                    string serverFileName1 = Path.GetFileName(_form2.selectedFile1);
                    string serverFileName2 = Path.GetFileName(_form2.selectedFile2);
                    string serverFileName3 = Path.GetFileName(_form2.selectedFile3);
                    string serverFileName4 = Path.GetFileName(_form2.selectedFile4);
                    if (serverFileName1 == "" && serverFileName2 == "" && serverFileName3 == "" && serverFileName4 == "")
                    {
                        richTextBox1.Invoke(new Action(() => appendText("\n Aucune source n'est renseignée.")));
                        return;
                    }

                    if (localFileName == serverFileName1)
                    {
                        if (_form2.checkBox2.Checked)
                        {
                            richTextBox1.Invoke(new Action(() => appendText("\n Copie du fichier en cours..." + _form2.selectedFile1 + " ...")));
                            File.Copy(_form2.selectedFile1, localFile, true);
                            richTextBox1.Invoke(new Action(() => appendText("\n Copie du fichier terminée.")));
                           
                        }
                        if (!_form2.checkBox2.Checked)
                         
                        richTextBox1.Invoke(new Action(() => appendText("\n Analyse du fichier " + _form2.selectedFile1)));

                        if (!_form2.checkBox2.Checked && serverFileInfo.Length != localFileInfo.Length)
                        {
                            richTextBox1.Invoke(new Action(() => appendText("\n Copie du fichier " + _form2.selectedFile1 + " ...")));
                            File.Copy(_form2.selectedFile1, localFile, true);
                            richTextBox1.Invoke(new Action(() => appendText("\n Ok.")));
                        }
                        else
                        {
                            if (!_form2.checkBox1.Checked && !_form2.checkBox2.Checked)
                                Thread.Sleep(500);
                            richTextBox1.Invoke(new Action(() => appendText("\n" + _form2.selectedFile1 + " est à jour.")));
                        }
                    }

                    else if (localFileName == serverFileName2)
                    {
                        if (_form2.checkBox2.Checked)
                        {
                            richTextBox1.Invoke(new Action(() => appendText("\n Copie du fichier en cours..." + _form2.selectedFile2 + " ...")));
                            File.Copy(_form2.selectedFile2, localFile, true);
                            richTextBox1.Invoke(new Action(() => appendText("\n Copie du fichier terminée.")));
                            
                        }
                        if (!_form2.checkBox1.Checked)
                        {
                            Thread.Sleep(500);
                            richTextBox1.Invoke(new Action(() => appendText("\n Analyse du fichier " + _form2.selectedFile2)));
                        }
                           

                        if (!_form2.checkBox2.Checked && serverFileInfo.Length != localFileInfo.Length)
                        {
                            richTextBox1.Invoke(new Action(() => appendText("\n Copie du fichier en cours..." + _form2.selectedFile2 + " ...")));
                            File.Copy(_form2.selectedFile2, localFile, true);
                            richTextBox1.Invoke(new Action(() => appendText("\n Copie du fichier terminée.")));
                        }

                      
                        else
                        {
                            if (!_form2.checkBox1.Checked && !_form2.checkBox2.Checked)
                                Thread.Sleep(500);
                            richTextBox1.Invoke(new Action(() => appendText("\n" + _form2.selectedFile2 + " est à jour.")));
                        }
                    }


                    else if (localFileName == serverFileName3)
                    {
                        if (_form2.checkBox2.Checked)
                        {
                            richTextBox1.Invoke(new Action(() => appendText("\n Copie du fichier en cours..." + _form2.selectedFile3 + " ...")));
                            File.Copy(_form2.selectedFile2, localFile, true);
                            richTextBox1.Invoke(new Action(() => appendText("\n Copie du fichier terminée.")));
                            
                        }
                        if (!_form2.checkBox1.Checked)
                            Thread.Sleep(500);
                        richTextBox1.Invoke(new Action(() => appendText("\n Analyse du fichier " + _form2.selectedFile3)));
                        if (!_form2.checkBox2.Checked && serverFileInfo.Length != localFileInfo.Length)
                        {
                            richTextBox1.Invoke(new Action(() => appendText("\n Copie du fichier " + _form2.selectedFile3 + " ...")));
                            File.Copy(_form2.selectedFile3, localFile, true);
                            richTextBox1.Invoke(new Action(() => appendText("\n Ok.")));
                        }
                        else
                        {
                            if (!_form2.checkBox1.Checked && !_form2.checkBox2.Checked)
                                Thread.Sleep(500);
                            richTextBox1.Invoke(new Action(() => appendText("\n" + _form2.selectedFile3 + " est à jour.")));
                        }

                    }

                    else if (localFileName == serverFileName4)
                    {
                        if (_form2.checkBox2.Checked)
                        {
                            richTextBox1.Invoke(new Action(() => appendText("\n Copie du fichier en cours..." + _form2.selectedFile4 + " ...")));
                            File.Copy(_form2.selectedFile2, localFile, true);
                            richTextBox1.Invoke(new Action(() => appendText("\n Copie du fichier terminée.")));
                           
                        }
                       if (!_form2.checkBox1.Checked)
                            Thread.Sleep(500);
                        richTextBox1.Invoke(new Action(() => appendText("\n Analyse du fichier " + _form2.selectedFile4)));

                        if (!_form2.checkBox2.Checked && serverFileInfo.Length != localFileInfo.Length)
                        {
                            richTextBox1.Invoke(new Action(() => appendText("\n Copie du fichier " + _form2.selectedFile4 + " ...")));
                            File.Copy(_form2.selectedFile4, localFile, true);
                            richTextBox1.Invoke(new Action(() => appendText("\n Ok.")));


                        }
                        else
                        {
                            if (!_form2.checkBox1.Checked && !_form2.checkBox2.Checked)
                                Thread.Sleep(500);
                            richTextBox1.Invoke(new Action(() => appendText("\n" + _form2.selectedFile4 + " est à jour.")));


                        }
                    }


                }

            }
            if (!_form2.checkBox1.Checked)
                Thread.Sleep(500);
            richTextBox1.Invoke(new Action(() => appendText("\n Lancement du Programme.")));

            string executablePath = _form2.E3Path +".exe";
            string commandLineArgument = _form2.argument; 
           
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = executablePath;
                    process.StartInfo.Arguments = commandLineArgument;

                    process.Start();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Invoke(new Action(() => appendText("\n Échec du lancement : Vérifiez les paramètres d'exécution de l'application")));
                return;
            }

            if (_form2.checkBox1.Checked)
                this.Close();
        }

            private void appendText(string text)
        {
            richTextBox1.AppendText(text);
            richTextBox1.Refresh();
        }
        
       

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                _form2.Show();
            }
            catch
            {
                MessageBox.Show("Veuillez Relancer le programme.");
            }
            
        }

        private void EDLauncher_Shown(object sender, EventArgs e)
        {
            Run();
        }

        private void EDLauncher_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_ControlAdded(object sender, ControlEventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Attention! Une fois cette option activé vous devrez supprimer le fichier save pour accèder aux paramètres.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Refresh();
           
            Run();
        }
    }
}
