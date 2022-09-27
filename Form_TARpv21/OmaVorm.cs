using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_TARpv21
{
    public class OmaVorm: Form
    {
        private string filename;
        TreeView mpuu;
        public OmaVorm() { }
        public OmaVorm(string Pealkiri, string valigeFail)
        {
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = Pealkiri;
            Button choosefile = new Button
            {
                Text = valigeFail,
                Location = new System.Drawing.Point(125, 5),
                Size = new System.Drawing.Size(190, 40),
                TabStop = false,
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.Orange,
            };
            choosefile.Click += Choosefile_Click;
            Label mPilt = new Label
            {
                Text = filename,
                Location = new System.Drawing.Point(320, 5),
                Size = new System.Drawing.Size(350, 350),
                BackColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            //Button nupp = new Button
            //{
            //    Text = "ASD",
            //    Location = new System.Drawing.Point(50, 50),
            //    Size = new System.Drawing.Size(100, 50),
            //    BackColor = System.Drawing.Color.Orange,
            //};
            //nupp.Click += Nupp_Click;

            //this.Controls.Add(nupp);
            this.Controls.Add(choosefile);
            this.Controls.Add(mPilt);
            Height = 400;
            Width = 695;
            Text = "Muusika";
            mpuu = new TreeView();
            mpuu.Dock = DockStyle.Left;
            TreeNode mOksad = new TreeNode("Muusika");
            mpuu.Nodes.Add(mOksad);
            this.Controls.Add(mpuu);
        }

        private void Choosefile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult tulemus = openFileDialog1.ShowDialog();
            if (tulemus == DialogResult.OK)
            {
                var vastus = MessageBox.Show("Kas tahad muusikat kuulata?", "Küsims", MessageBoxButtons.YesNo);
                if (vastus == DialogResult.Yes)
                {
                    string file = openFileDialog1.FileName;
                    try
                    {
                        string filename = Path.GetFileName(file);
                        //MessageBox.Show("Filename: " + filename);
                        Label failnimi = new Label
                        {
                            Text = filename,
                            Location = new System.Drawing.Point(125, 55),
                            Size = new System.Drawing.Size(190, 20),
                            BackColor = System.Drawing.Color.White,
                            Padding = new Padding(6),
                            AutoSize = true,
                            BorderStyle = BorderStyle.FixedSingle
                        };this.Controls.Add(failnimi);
                        string text = File.ReadAllText(file);
                        using (var muusika = new SoundPlayer(file))
                        {
                            muusika.Play();
                        }
                    }
                    catch (IOException) { }
                }
                else
                {
                    MessageBox.Show(":(");
                }
                
            }
        }
        //private void Nupp_Click(object sender, EventArgs e)
        //{
        //    var vastus = MessageBox.Show("Kas tahad muusikat kuulata?", "Küsims", MessageBoxButtons.YesNo);
        //    if (vastus == DialogResult.Yes)
        //    {
        //        using (var muusika = new SoundPlayer(@"..\..\Yoaimo.wav"))
        //        {
        //            MessageBox.Show("playing...");
        //            muusika.Play();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show(":(");
        //    }
        //}
    }
}