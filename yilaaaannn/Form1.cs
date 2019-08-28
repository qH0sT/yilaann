using System;
using System.Collections.Generic;            //Coded by 2007
using System.Drawing;
using System.Windows.Forms;

namespace yilaaaannn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pcbx.Add(pictureBox2);
            pcbx.Add(pictureBox3);
        }
        List<PictureBox> pcbx = new List<PictureBox>();
        int puan = 0;
        string yon = "sago go go";
        PictureBox pbx = new PictureBox();
        private void timer1_Tick(object sender, EventArgs e)
        {

            switch (yon)
            {
                case "sag":
                    Saga_git();
                    break;

                case "assagi":
                    Assagi_git();
                    break;

                case "yukari":
                    Yukari_git();
                    break;

                case "sol":
                    Sola_git();
                    break;

            }

        }


        private void Yukari_git()
        {
            pictureBox1.Top -= 10;
            for (int i = 0; i < pcbx.Count; i++)
            {
                try
                {
                    pcbx[i].Top = pictureBox1.Top + 15;
                    pcbx[i].Top = pcbx[i - 1].Top + 15;
                    pcbx[i].Left = pictureBox1.Left;

                }
                catch (Exception) { pcbx[0].Left = pictureBox1.Left; }
            }
        }

        private void Saga_git()
        {
            pictureBox1.Left += 10;
            for (int i = 0; i < pcbx.Count; i++)
            {
                try
                {
                    pcbx[i].Left = pictureBox1.Left - 15;
                    pcbx[i].Left = pcbx[i - 1].Left - 15;
                    pcbx[i].Top = pictureBox1.Top;
                    Application.DoEvents();

                }
                catch (Exception) { pcbx[0].Top = pictureBox1.Top; }
            }
        }

        private void Sola_git()
        {
            pictureBox1.Left -= 10;
            for (int i = 0; i < pcbx.Count; i++)
            {
                try
                {
                    pcbx[i].Left = pictureBox1.Left + 15;
                    pcbx[i].Left = pcbx[i - 1].Left + 15;
                    pcbx[i].Top = pictureBox1.Top;
                    Application.DoEvents();

                }
                catch (Exception) { pcbx[0].Top = pictureBox1.Top; }
            }
        }

        private void Assagi_git()
        {
            pictureBox1.Top += 10;
            for (int i = 0; i < pcbx.Count; i++)
            {
                try
                {
                    pcbx[i].Top = pictureBox1.Top - 15;
                    pcbx[i].Top = pcbx[i - 1].Top - 15;
                    pcbx[i].Left = pictureBox1.Left;
                    Application.DoEvents();
                }
                catch (Exception) { pcbx[0].Left = pictureBox1.Left; }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.W:
                    yon = "yukari";
                    label2.ForeColor = Color.Green;
                    break;

                case Keys.S:
                    yon = "assagi";
                    label4.ForeColor = Color.Green;
                    break;

                case Keys.D:
                    yon = "sag";
                    label5.ForeColor = Color.Green;
                    break;

                case Keys.A:
                    yon = "sol";
                    label3.ForeColor = Color.Green;
                    break;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int bas = pictureBox1.Top;
            int bas2 = pictureBox1.Left;

            int bas3 = pictureBox4.Top;
            int bas4 = pictureBox4.Left;

            int sonucX = bas3 - bas;
            int sonuxY = bas4 - bas2;

            if (sonucX < 0) { sonucX = bas - bas3; }
            if (sonuxY < 0) { sonuxY = bas2 - bas4; }

            //Text = "PC1 Top: " + pictureBox1.Top.ToString() + " PC4 Top:" + pictureBox4.Top.ToString() + " PC1 Left: " + pictureBox1.Left.ToString() + " PC4 Left: " + pictureBox4.Left.ToString() ;

            if (pictureBox1.Left <= 966 && pictureBox1.Left >= 886 || pictureBox1.Top >= 283 || pictureBox1.Left < 0 || pictureBox1.Top < 0) //Eğer duvarlara çarparsa yanarsınız.
            {
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show("Yandınız!!", "Yılan oyunu");
            }
            else if (sonucX <= Convert.ToInt32(numericUpDown1.Value) || sonuxY <= Convert.ToInt32(numericUpDown1.Value)) //Yem yedik mi ? tam koordinat vermiyorum, yaklaşık olsa yeter.
            {
                puan += 1;
                label1.Text = "Puan: " + puan.ToString();
                pictureBox4.Left = new Random().Next(0, 866);
                pictureBox4.Top = new Random().Next(0, 280);
                PictureBox pbox = new PictureBox();
                pbox.Location = new Point(418, 87);
                pbox.BackColor = Color.Red;
                pbox.Size = pictureBox1.Size;
                pcbx.Add(pbox);
                Controls.Add(pbox);
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    yon = "yukari";
                    label2.ForeColor = SystemColors.ControlText;
                    break;

                case Keys.S:
                    yon = "assagi";
                    label4.ForeColor = SystemColors.ControlText;
                    break;

                case Keys.D:
                    yon = "sag";
                    label5.ForeColor = SystemColors.ControlText;
                    break;

                case Keys.A:
                    yon = "sol";
                    label3.ForeColor = SystemColors.ControlText;
                    break;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Restart();
        }
    }
}
