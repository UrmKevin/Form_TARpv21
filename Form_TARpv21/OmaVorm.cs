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
        public OmaVorm() { }
        public OmaVorm(string Pealkiri, string Fail)
        {
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = Pealkiri;
            Button choosefile = new Button
            {
                Text = Fail,
                Location = new System.Drawing.Point(150, 10),
                Size = new System.Drawing.Size(100, 50),
                TabStop = false,
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.Orange,
            };
            choosefile.Click += Choosefile_Click;
            //Button nupp = new Button
            //{
            //    Text = Nupp,
            //    Location = new System.Drawing.Point(50, 50),
            //    Size = new System.Drawing.Size(100, 50),
            //    BackColor = System.Drawing.Color.Orange,
            //};
            //nupp.Click += Nupp_Click;
            Label failnimi = new Label
            {
                Text = Fail,
                Location = new System.Drawing.Point(50, 10),
                Size = new System.Drawing.Size(100, 50),
                BackColor = System.Drawing.Color.White,
            };
            //this.Controls.Add(nupp);
            this.Controls.Add(choosefile);
            this.Controls.Add(failnimi);
        }

        private void Choosefile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var vastus = MessageBox.Show("Kas tahad muusikat kuulata?", "Küsims", MessageBoxButtons.YesNo);
                if (vastus == DialogResult.Yes)
                {
                    string file = openFileDialog1.FileName;
                    try
                    {
                        MessageBox.Show(file);
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
        //    Button nupp_sender = (Button)sender;
        //    var vastus = MessageBox.Show("Kas tahad muusikat kuulata?","Küsims",MessageBoxButtons.YesNo);
        //    if (vastus == DialogResult.Yes)
        //    {
        //        using (var muusika = new SoundPlayer(@"..\..\Yoaimo.wav"))
        //        {
        //            MessageBox.Show("SUIIIIII");
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