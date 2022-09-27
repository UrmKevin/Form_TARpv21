using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_TARpv21
{
    public partial class MinuOmaVorm : Form
    {
        TreeView puu;
        Button nupp;
        Label silt;
        CheckBox mruut1, mruut2;
        RadioButton rnupp1, rnupp2, rnupp3, rnupp4;
        PictureBox pilt;
        ProgressBar riba;
        Timer aeg;
        TextBox tekst;

        public MinuOmaVorm()
        {
            Height = 600;
            Width = 900;
            Text = "Minu oma vorm koos elementidega";
            puu = new TreeView();
            puu.Dock = DockStyle.Left;
            puu.Location = new Point(0, 0);
            TreeNode oksad = new TreeNode("Elemendid");
            oksad.Nodes.Add(new TreeNode("Nupp-Button"));
            oksad.Nodes.Add(new TreeNode("Silt-Label"));
            oksad.Nodes.Add(new TreeNode("Dialog MessageBox"));
            oksad.Nodes.Add(new TreeNode("Märkeruut-CheckBox"));
            oksad.Nodes.Add(new TreeNode("Radiobutton"));
            oksad.Nodes.Add(new TreeNode("Edenemisriba-ProgressBar"));
            oksad.Nodes.Add(new TreeNode("Tekstkast-TextBox"));
            oksad.Nodes.Add(new TreeNode("OmaVorm-MyForm"));

            puu.AfterSelect += Puu_AfterSelect;
            puu.Nodes.Add(oksad);
            puu.DoubleClick += Puu_DoubleClick;
            this.Controls.Add(puu);
        }

        private void Puu_DoubleClick(object sender, EventArgs e)
        {
            if (tekst.Enabled)
            {
                tekst.Enabled = false;
            }
            else
            {
                tekst.Enabled = true;
            }
        }

        private void Puu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            silt = new Label 
            { 
                Text = "Minu esimene vorm",
                Size=new Size(200, 30),
                Location=new Point(200,5),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Padding = new Padding(6),
                AutoSize = true,
                Font = new Font("Calibri", 18),
                BorderStyle = BorderStyle.FixedSingle
            };
            mruut1 = new CheckBox
            {
                Checked = false,
                Text = "Kollane",
                Location = new Point(silt.Left + 50 + silt.Width, 0),
                Height = 25
            };
            mruut2 = new CheckBox
            {
                Checked = false,
                Text = "Sinine",
                Location = new Point(silt.Left + 50 + silt.Width, mruut1.Height),
                Height = 25
            };
            if (e.Node.Text == "Nupp-Button")
            {
                nupp = new Button();
                nupp.Text = "Valjuta siia";
                nupp.Height = 30;
                nupp.Width = 60;
                nupp.Location = new Point(300, 50);
                nupp.Click += Nupp_Click;
                this.Controls.Add(nupp);
            }
            else if (e.Node.Text == "Silt-Label")
            {
                silt.MouseEnter += Silt_MouseEnter;
                silt.MouseLeave += Silt_MouseLeave;
                this.Controls.Add(silt);
            }
            else if (e.Node.Text == "Dialog MessageBox")
            {
                MessageBox.Show("...", "...");
                var vastus = MessageBox.Show("Kas paneme aken kinni?", "Valik", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (vastus == DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Siis töötma edasi", "Vastus oli ei");
                }
            }
            else if (e.Node.Text == "Märkeruut-CheckBox")
            {
                mruut1.CheckedChanged += Mruut1_CheckedChanged;
                mruut2.CheckedChanged += Mruut1_CheckedChanged;

                this.Controls.Add(mruut1);
                this.Controls.Add(mruut2);
            }
            else if (e.Node.Text == "Radiobutton")
            {
                rnupp1 = new RadioButton
                {
                    Text = "Paremale",
                    Width = 90,
                    Location = new Point(mruut2.Left + mruut2.Width, mruut1.Height + mruut2.Height)
                };
                rnupp2 = new RadioButton
                {
                    Text = "Vasakule",
                    Width = 90,
                    Location = new Point(mruut2.Left + mruut2.Width, rnupp1.Height + mruut1.Height + mruut2.Height)
                };
                rnupp3 = new RadioButton
                {
                    Text = "Ülesse",
                    Width = 90,
                    Location = new Point(mruut2.Left + mruut2.Width, rnupp1.Height + rnupp2.Height + mruut1.Height + mruut2.Height)
                };
                rnupp4 = new RadioButton
                {
                    Text = "Alla",
                    Width = 90,
                    Location = new Point(mruut2.Left + mruut2.Width, rnupp1.Height + rnupp3.Height + rnupp3.Height + mruut1.Height + mruut2.Height)
                };
                pilt = new PictureBox
                {
                    Image = new Bitmap("Susremaster.png"),
                    Location = new Point(400, 200),
                    Size = new Size(100, 100),
                    SizeMode=PictureBoxSizeMode.Zoom,
                };
                rnupp1.CheckedChanged += Rnupp1_CheckedChanged;
                rnupp2.CheckedChanged += Rnupp1_CheckedChanged;
                rnupp3.CheckedChanged += Rnupp1_CheckedChanged;
                rnupp4.CheckedChanged += Rnupp1_CheckedChanged;
                this.Controls.Add(rnupp1);
                this.Controls.Add(rnupp2);
                this.Controls.Add(rnupp3);
                this.Controls.Add(rnupp4);
                this.Controls.Add(pilt);
            }
            else if (e.Node.Text == "Edenemisriba-ProgressBar")
            {
                riba = new ProgressBar
                {
                    Width = 800,
                    Height = 40,
                    Value = 31,
                    Minimum = 0,
                    Maximum = 100,
                    Step = 1,
                    Dock = DockStyle.Bottom,
                };
                aeg = new Timer();
                aeg.Enabled = true;
                aeg.Tick += Aeg_Tick;
                this.Controls.Add(riba);
            }
            else if (e.Node.Text == "Tekstkast-TextBox")
            {
                tekst = new TextBox
                {
                    Font = new Font("Arial", 34, FontStyle.Italic),
                    Location = new Point(350, 400),
                    Enabled = false
                };
                this.Controls.Add(tekst);
            }
            else if (e.Node.Text == "OmaVorm-MyForm")
            {
                OmaVorm oma = new OmaVorm("Kuulame muusikat", "Valige fail");
                oma.ShowDialog();
            }
        }
        private void Aeg_Tick(object sender, EventArgs e)
        {
            riba.PerformStep();
            int x = 100;
            if (riba.Value == x)
            {
                x += 100;
                for (int i = 0; i < 1; i++)
                {
                    //string message = "Your IP is 1421.32.64.21";
                    //MessageBox.Show(message);
                    ProcessStartInfo sInfo = new ProcessStartInfo("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
                    Process.Start(sInfo);
                }
            }
        }
        private void Rnupp1_CheckedChanged(object sender, EventArgs e)
        {
            if (rnupp1.Checked == true)
            {
                pilt.Left += 20;
                rnupp1.Checked = false;
            }
            else if (rnupp2.Checked == true)
            {
                pilt.Left -= 20;
                rnupp2.Checked = false;
            }
            else if(rnupp3.Checked == true)
            {
                pilt.Top -= 20;
                rnupp3.Checked = false;
            }
            else if(rnupp4.Checked == true)
            {
                pilt.Top += 20;
                rnupp4.Checked = false;
            }
        }
        private void Mruut1_CheckedChanged(object sender, EventArgs e)
        {
            if (mruut1.Checked == false && mruut2.Checked == false)
            {
                this.BackColor = Color.White;
            }
            else if (mruut1.Checked == true && mruut2.Checked == false)
            {
                this.BackColor = Color.Yellow;
            }
            else if (mruut1.Checked == false && mruut2.Checked == true)
            {
                this.BackColor = Color.Blue;
            }
            else if (mruut1.Checked == true && mruut2.Checked == true)
            {
                this.BackColor = Color.Green;
            }
        }
        private void Silt_MouseLeave(object sender, EventArgs e)
        {
            silt.ForeColor = Color.Black;
            silt.BackColor = Color.Transparent;
        }
        private void Silt_MouseEnter(object sender, EventArgs e)
        {
            silt.ForeColor = Color.LightGreen;
            silt.BackColor = Color.Black;
        }
        Random random = new Random();
        private void Nupp_Click(object sender, EventArgs e)
        {
            int red, green, blue;
            red = random.Next(255);
            green = random.Next(255);
            blue = random.Next(255);
            this.BackColor = Color.FromArgb(red, green, blue);
            //ProcessStartInfo sInfo = new ProcessStartInfo("http://mysite.com/");
            //Process.Start(sInfo);
        }
    }
}
