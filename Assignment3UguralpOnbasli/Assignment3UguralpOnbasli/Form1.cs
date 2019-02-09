using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3UguralpOnbasli
{
    public partial class Form1 : Form
    {
        Timer timer1 = new Timer() { Enabled = true, Interval = 2000 };
        Timer timer2 = new Timer() { Enabled = true, Interval = 2000 };
        Timer timer4 = new Timer() { Enabled = true, Interval = 2000 };
        Timer timer5 = new Timer() { Enabled = true, Interval = 2000 };
        Timer timer6 = new Timer() { Enabled = true, Interval = 2000 };
        Timer timer7 = new Timer() { Enabled = true, Interval = 2000 };

        SoundPlayer Player = new SoundPlayer();
        int gridViewCount = 0; bool powerOn = false;
        List<OxygenTank> oxygenTanks = new List<OxygenTank>();
        ValveClickable valveCheck = new ValveClickable();
        public Form1()
        {
            InitializeComponent();
            oxygenTanks.Add(new OxygenTank(true, false, 2));
            oxygenTanks.Add(new OxygenTank(false, true, 1));
            oxygenTanks.Add(new OxygenTank(false, true, 3));
            oxygenTanks.Add(new OxygenTank(false, true, 0));
            oxygenTanks.Add(new OxygenTank(true, false, 4));
            oxygenTanks.Add(new OxygenTank(false, true, 4));

            timer1.Tick += ValveAction1;
            timer2.Tick += ValveAction2;
            timer4.Tick += ValveAction3;
            timer5.Tick += ValveAction4;
            timer6.Tick += ValveAction5;
            timer7.Tick += ValveAction6;

            stopTimers();
            dataGridView1.DefaultCellStyle.Font = new Font("Times New Roman", 9);

        }

        public void ValveSettings()
        {
            valveCheck.Valve1 = false;
            valveCheck.Valve2 = false;
            valveCheck.Valve3 = false;
            valveCheck.Valve4 = false;
            valveCheck.Valve5 = false;
            valveCheck.Valve6 = false;

        }

        public void playAudio()
        {
            try
            {
                // Note: You may need to change the location specified based on
                // the sounds loaded on your computer.
                this.Player.SoundLocation = @"C:\Windows\Media\chimes.wav";
                this.Player.PlayLooping();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error playing sound");
            }
        }
        private void valve1Button_Click(object sender, EventArgs e)
        {
            /*
            Form2 npage = new Form2();
            npage.Show(); //or showdialog
            this.Hide();*/
            if (valveCheck.Valve1 == true)
            {
                this.Player.Stop();
                timer1.Start();
                timer3.Stop();
                button1.BackColor = Color.White;
                valveCheck.Valve1 = false;
                if (valve1Button.BackColor == Color.Red)
                {
                    valve1Button.BackColor = Color.Green;
                    valve1Button.Text = "Open";
                }
                else
                {
                    valve1Button.BackColor = Color.Red;
                    valve1Button.Text = "Closed";
                }

            }
            else
            {
                MessageBox.Show("Tank is not full or empty.");
            }

        }
        private void ValveAction6(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Today;
            valveCheck.Valve6 = false;
            oxygenTanks[5].Counter += 1;

            if (oxygenTanks[5].Bleeding == true)
            {
                if (oxygenTanks[5].Counter == 1)
                {
                    this.pictureBox6.Load("oxygentank.jpg");
                    this.pictureBox12.Load("100%gauge.png");
                }
                else if (oxygenTanks[5].Counter == 2)
                {
                    this.pictureBox6.Load("oxygentank75.jpg");
                    this.pictureBox12.Load("100%gauge.png");
                }
                else if (oxygenTanks[5].Counter == 3)
                {
                    this.pictureBox6.Load("oxygentank50.jpg");
                    this.pictureBox12.Load("50%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#6 Oxygen tank is 50%!", "Low");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Yellow;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.Black;
                    gridViewCount++;
                }
                else if (oxygenTanks[5].Counter == 4)
                {
                    this.pictureBox6.Load("oxygentank25.jpg");
                    this.pictureBox12.Load("0%gauge.png");
                }
                else if (oxygenTanks[5].Counter == 5)
                {
                    this.pictureBox6.Load("oxygentank0.jpg");
                    this.pictureBox12.Load("0%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#6 Oxygen tank is empty!", "High");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Red;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.White;

                    gridViewCount++;
                    oxygenTanks[5].Counter = 0;
                    oxygenTanks[5].Bleeding = false;
                    oxygenTanks[5].Filling = true;
                    valveCheck.Valve6 = true;
                    timer7.Stop();
                    oxygenTanks[5].Bleeding = false;
                    oxygenTanks[5].Filling = true;
                    //timer7.Tick -= new EventHandler(Bleeding);
                    //timer7.Tick += Filling1;
                    timer12.Start();
                    timer12.Interval = 500;
                    timer12.Enabled = true;
                    playAlarm();

                }
                else
                {
                    //Counter = 0;
                }
            }
            else
            {
                if (oxygenTanks[5].Counter == 1)
                {
                    this.pictureBox6.Load("oxygentank0.jpg");
                    this.pictureBox12.Load("0%gauge.png");
                }
                else if (oxygenTanks[5].Counter == 2)
                {
                    this.pictureBox6.Load("oxygentank25.jpg");
                    this.pictureBox12.Load("0%gauge.png");
                }
                else if (oxygenTanks[5].Counter == 3)
                {
                    this.pictureBox6.Load("oxygentank50.jpg");
                    this.pictureBox12.Load("50%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#6 Oxygen Tank is 50%", "Low");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Yellow;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.Black;
                    gridViewCount++;
                }
                else if (oxygenTanks[5].Counter == 4)
                {
                    this.pictureBox6.Load("oxygentank75.jpg");
                    this.pictureBox12.Load("100%gauge.png");
                }
                else if (oxygenTanks[5].Counter == 5)
                {
                    this.pictureBox6.Load("oxygentank.jpg");
                    this.pictureBox12.Load("100%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#6 Oxygen Tank is Full", "Normal");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Green;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.White;
                    oxygenTanks[5].Bleeding = true;
                    oxygenTanks[5].Filling = false;
                    valveCheck.Valve6 = true;
                    gridViewCount++;
                    oxygenTanks[5].Counter = 0;
                    timer7.Stop();
                    timer12.Start();
                    timer12.Interval = 500;
                    timer12.Enabled = true;
                    playAlarm();

                }
                else
                {
                    //Counter = 0;
                }
            }

        }
        private void ValveAction5(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Today;
            valveCheck.Valve5 = false;
            oxygenTanks[4].Counter += 1;

            if (oxygenTanks[4].Bleeding == true)
            {
                if (oxygenTanks[4].Counter == 1)
                {
                    this.pictureBox5.Load("oxygentank.jpg");
                    this.pictureBox11.Load("100%gauge.png");
                }
                else if (oxygenTanks[4].Counter == 2)
                {
                    this.pictureBox5.Load("oxygentank75.jpg");
                }
                else if (oxygenTanks[4].Counter == 3)
                {
                    this.pictureBox5.Load("oxygentank50.jpg");
                    this.pictureBox11.Load("50%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#5 Oxygen tank is 50%!", "Low");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Yellow;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.Black;
                    gridViewCount++;
                }
                else if (oxygenTanks[4].Counter == 4)
                {
                    this.pictureBox5.Load("oxygentank25.jpg");
                    this.pictureBox11.Load("0%gauge.png");
                }
                else if (oxygenTanks[4].Counter == 5)
                {
                    this.pictureBox5.Load("oxygentank0.jpg");
                    this.pictureBox11.Load("0%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#5 Oxygen tank is empty!", "High");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Red;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.White;

                    gridViewCount++;
                    oxygenTanks[4].Counter = 0;
                    oxygenTanks[4].Bleeding = false;
                    oxygenTanks[4].Filling = true;
                    valveCheck.Valve5 = true;
                    timer6.Stop();
                    oxygenTanks[4].Bleeding = false;
                    oxygenTanks[4].Filling = true;
                    //timer6.Tick -= new EventHandler(Bleeding);
                    //timer6.Tick += Filling1;
                    timer11.Start();
                    timer11.Interval = 500;
                    timer11.Enabled = true;
                    playAlarm();

                }
                else
                {
                    //Counter = 0;
                }
            }
            else
            {
                if (oxygenTanks[4].Counter == 1)
                {
                    this.pictureBox5.Load("oxygentank0.jpg");
                    this.pictureBox11.Load("0%gauge.png");
                }
                else if (oxygenTanks[4].Counter == 2)
                {
                    this.pictureBox5.Load("oxygentank25.jpg");
                    this.pictureBox11.Load("0%gauge.png");
                }
                else if (oxygenTanks[4].Counter == 3)
                {
                    this.pictureBox5.Load("oxygentank50.jpg");
                    this.pictureBox11.Load("50%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#5 Oxygen Tank is 50%", "Low");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Yellow;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.Black;
                    gridViewCount++;
                }
                else if (oxygenTanks[4].Counter == 4)
                {
                    this.pictureBox5.Load("oxygentank75.jpg");
                    this.pictureBox11.Load("100%gauge.png");
                }
                else if (oxygenTanks[4].Counter == 5)
                {
                    this.pictureBox5.Load("oxygentank.jpg");
                    this.pictureBox11.Load("100%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#5 Oxygen Tank is Full", "Normal");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Green;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.White;
                    oxygenTanks[4].Bleeding = true;
                    oxygenTanks[4].Filling = false;
                    valveCheck.Valve5 = true;
                    gridViewCount++;
                    oxygenTanks[4].Counter = 0;
                    timer6.Stop();
                    timer11.Start();
                    timer11.Interval = 500;
                    timer11.Enabled = true;
                    playAlarm();

                }
                else
                {
                    //Counter = 0;
                }
            }

        }
        private void ValveAction4(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Today;
            valveCheck.Valve4 = false;
            oxygenTanks[3].Counter += 1;

            if (oxygenTanks[3].Bleeding == true)
            {
                if (oxygenTanks[3].Counter == 1)
                {
                    this.pictureBox4.Load("oxygentank.jpg");
                    this.pictureBox10.Load("100%gauge.png");
                }
                else if (oxygenTanks[3].Counter == 2)
                {
                    this.pictureBox4.Load("oxygentank75.jpg");
                    this.pictureBox10.Load("100%gauge.png");
                }
                else if (oxygenTanks[3].Counter == 3)
                {
                    this.pictureBox4.Load("oxygentank50.jpg");
                    this.pictureBox10.Load("50%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#4 Oxygen tank is 50%!", "Low");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Yellow;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.Black;
                    gridViewCount++;
                }
                else if (oxygenTanks[3].Counter == 4)
                {
                    this.pictureBox4.Load("oxygentank25.jpg");
                    this.pictureBox10.Load("0%gauge.png");
                }
                else if (oxygenTanks[3].Counter == 5)
                {
                    this.pictureBox4.Load("oxygentank0.jpg");
                    this.pictureBox10.Load("0%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#4 Oxygen tank is empty!", "High");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Red;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.White;

                    gridViewCount++;
                    oxygenTanks[3].Counter = 0;
                    oxygenTanks[3].Bleeding = false;
                    oxygenTanks[3].Filling = true;
                    valveCheck.Valve4 = true;
                    timer5.Stop();
                    oxygenTanks[3].Bleeding = false;
                    oxygenTanks[3].Filling = true;
                    //timer5.Tick -= new EventHandler(Bleeding);
                    //timer5.Tick += Filling1;
                    timer10.Start();
                    timer10.Interval = 500;
                    timer10.Enabled = true;
                    playAlarm();

                }
                else
                {
                    //Counter = 0;
                }
            }
            else
            {
                if (oxygenTanks[3].Counter == 1)
                {
                    this.pictureBox4.Load("oxygentank0.jpg");
                    this.pictureBox10.Load("0%gauge.png");
                }
                else if (oxygenTanks[3].Counter == 2)
                {
                    this.pictureBox4.Load("oxygentank25.jpg");
                    this.pictureBox10.Load("0%gauge.png");
                }
                else if (oxygenTanks[3].Counter == 3)
                {
                    this.pictureBox4.Load("oxygentank50.jpg");
                    this.pictureBox10.Load("50%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#4 Oxygen Tank is 50%", "Low");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Yellow;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.Black;
                    gridViewCount++;
                }
                else if (oxygenTanks[3].Counter == 4)
                {
                    this.pictureBox4.Load("oxygentank75.jpg");
                    this.pictureBox10.Load("100%gauge.png");
                }
                else if (oxygenTanks[3].Counter == 5)
                {
                    this.pictureBox4.Load("oxygentank.jpg");
                    this.pictureBox10.Load("100%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#4 Oxygen Tank is Full", "Normal");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Green;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.White;
                    oxygenTanks[3].Bleeding = true;
                    oxygenTanks[3].Filling = false;
                    valveCheck.Valve4 = true;
                    gridViewCount++;
                    oxygenTanks[3].Counter = 0;
                    timer5.Stop();
                    timer10.Start();
                    timer10.Interval = 500;
                    timer10.Enabled = true;
                    playAlarm();

                }
                else
                {
                    //Counter = 0;
                }
            }

        }
        private void ValveAction3(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Today;
            valveCheck.Valve3 = false;
            oxygenTanks[2].Counter += 1;

            if (oxygenTanks[2].Bleeding == true)
            {
                if (oxygenTanks[2].Counter == 1)
                {
                    this.pictureBox3.Load("oxygentank.jpg");
                    this.pictureBox9.Load("100%gauge.png");
                }
                else if (oxygenTanks[2].Counter == 2)
                {
                    this.pictureBox3.Load("oxygentank75.jpg");
                    this.pictureBox9.Load("100%gauge.png");
                }
                else if (oxygenTanks[2].Counter == 3)
                {
                    this.pictureBox3.Load("oxygentank50.jpg");
                    this.pictureBox9.Load("50%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#3 Oxygen tank is 50%!", "Low");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Yellow;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.Black;
                    gridViewCount++;
                }
                else if (oxygenTanks[2].Counter == 4)
                {
                    this.pictureBox3.Load("oxygentank25.jpg");
                    this.pictureBox9.Load("0%gauge.png");
                }
                else if (oxygenTanks[2].Counter == 5)
                {
                    this.pictureBox3.Load("oxygentank0.jpg");
                    this.pictureBox9.Load("0%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#3 Oxygen tank is empty!", "High");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Red;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.White;

                    gridViewCount++;
                    oxygenTanks[2].Counter = 0;
                    oxygenTanks[2].Bleeding = false;
                    oxygenTanks[2].Filling = true;
                    valveCheck.Valve3 = true;
                    timer4.Stop();
                    oxygenTanks[2].Bleeding = false;
                    oxygenTanks[2].Filling = true;
                    //timer1.Tick -= new EventHandler(Bleeding);
                    //timer1.Tick += Filling1;
                    timer3.Start();
                    timer3.Interval = 500;
                    timer3.Enabled = true;
                    timer9.Start();
                    timer9.Interval = 500;
                    timer9.Enabled = true;
                    playAlarm();

                }
                else
                {
                    //Counter = 0;
                }
            }
            else
            {
                if (oxygenTanks[2].Counter == 1)
                {
                    this.pictureBox3.Load("oxygentank0.jpg");
                    this.pictureBox9.Load("0%gauge.png");
                }
                else if (oxygenTanks[2].Counter == 2)
                {
                    this.pictureBox3.Load("oxygentank25.jpg");
                    this.pictureBox9.Load("0%gauge.png");
                }
                else if (oxygenTanks[2].Counter == 3)
                {
                    this.pictureBox3.Load("oxygentank50.jpg");
                    this.pictureBox9.Load("50%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#3 Oxygen Tank is 50%", "Low");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Yellow;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.Black;
                    gridViewCount++;
                }
                else if (oxygenTanks[2].Counter == 4)
                {
                    this.pictureBox3.Load("oxygentank75.jpg");
                    this.pictureBox9.Load("100%gauge.png");
                }
                else if (oxygenTanks[2].Counter == 5)
                {
                    this.pictureBox3.Load("oxygentank.jpg");
                    this.pictureBox9.Load("100%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#3 Oxygen Tank is Full", "Normal");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Green;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.White;
                    oxygenTanks[2].Bleeding = true;
                    oxygenTanks[2].Filling = false;
                    valveCheck.Valve3 = true;
                    gridViewCount++;
                    oxygenTanks[2].Counter = 0;
                    timer4.Stop();
                    timer9.Start();
                    timer9.Interval = 500;
                    timer9.Enabled = true;
                    playAlarm();

                }
                else
                {
                    //Counter = 0;
                }
            }

        }

        private void ValveAction2(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Today;
            valveCheck.Valve2 = false;
            oxygenTanks[1].Counter += 1;

            if (oxygenTanks[1].Bleeding == true)
            {
                if (oxygenTanks[1].Counter == 1)
                {
                    this.pictureBox2.Load("oxygentank.jpg");
                    this.pictureBox8.Load("100%gauge.png");
                }
                else if (oxygenTanks[1].Counter == 2)
                {
                    this.pictureBox2.Load("oxygentank75.jpg");
                    this.pictureBox8.Load("100%gauge.png");
                }
                else if (oxygenTanks[1].Counter == 3)
                {
                    this.pictureBox2.Load("oxygentank50.jpg");
                    this.pictureBox8.Load("50%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#2 Oxygen tank is 50%!", "Low");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Yellow;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.Black;
                    gridViewCount++;
                }
                else if (oxygenTanks[1].Counter == 4)
                {
                    this.pictureBox2.Load("oxygentank25.jpg");
                    this.pictureBox8.Load("0%gauge.png");
                }
                else if (oxygenTanks[1].Counter == 5)
                {
                    this.pictureBox2.Load("oxygentank0.jpg");
                    this.pictureBox8.Load("0%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#2 Oxygen tank is empty!", "High");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Red;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.White;

                    gridViewCount++;
                    oxygenTanks[1].Counter = 0;
                    oxygenTanks[1].Bleeding = false;
                    oxygenTanks[1].Filling = true;
                    valveCheck.Valve2 = true;
                    timer2.Stop();
                    oxygenTanks[1].Bleeding = false;
                    oxygenTanks[1].Filling = true;
                    //timer1.Tick -= new EventHandler(Bleeding);
                    //timer1.Tick += Filling1;
                    timer8.Start();
                    timer8.Interval = 500;
                    timer8.Enabled = true;
                    playAlarm();

                }
                else
                {
                    //Counter = 0;
                }
            }
            else
            {
                if (oxygenTanks[1].Counter == 1)
                {
                    this.pictureBox2.Load("oxygentank0.jpg");
                    this.pictureBox8.Load("0%gauge.png");
                }
                else if (oxygenTanks[1].Counter == 2)
                {
                    this.pictureBox2.Load("oxygentank25.jpg");
                    this.pictureBox8.Load("0%gauge.png");
                }
                else if (oxygenTanks[1].Counter == 3)
                {
                    this.pictureBox2.Load("oxygentank50.jpg");
                    this.pictureBox8.Load("50%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#2 Oxygen Tank is 50%", "Low");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Yellow;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.Black;
                    gridViewCount++;
                }
                else if (oxygenTanks[1].Counter == 4)
                {
                    this.pictureBox2.Load("oxygentank75.jpg");
                    this.pictureBox8.Load("100%gauge.png");
                }
                else if (oxygenTanks[1].Counter == 5)
                {
                    this.pictureBox2.Load("oxygentank.jpg");
                    this.pictureBox8.Load("100%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#2 Oxygen Tank is Full", "Normal");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Green;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.White;
                    oxygenTanks[1].Bleeding = true;
                    oxygenTanks[1].Filling = false;
                    valveCheck.Valve2 = true;
                    gridViewCount++;
                    oxygenTanks[1].Counter = 0;
                    timer2.Stop();
                    timer8.Start();
                    timer8.Interval = 500;
                    timer8.Enabled = true;
                    playAlarm();

                }
                else
                {
                    //Counter = 0;
                }
            }

        }

        private void ValveAction1(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Today;
            valveCheck.Valve1 = false;
            oxygenTanks[0].Counter += 1;

            if(oxygenTanks[0].Bleeding == true)
            {
                   if (oxygenTanks[0].Counter == 1)
                    {
                        this.pictureBox1.Load("oxygentank.jpg");
                        this.pictureBox7.Load("100%gauge.png");
                }
                else if (oxygenTanks[0].Counter == 2)
                    {
                        this.pictureBox1.Load("oxygentank75.jpg");
                        this.pictureBox7.Load("100%gauge.png");
                }
                else if (oxygenTanks[0].Counter == 3)
                    {
                        this.pictureBox1.Load("oxygentank50.jpg");
                        this.pictureBox7.Load("50%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#1 Oxygen tank is 50%!", "Low");
                        dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Yellow;
                        dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.Black;
                        gridViewCount++;
                }
                    else if (oxygenTanks[0].Counter == 4)
                    {
                        this.pictureBox1.Load("oxygentank25.jpg");
                        this.pictureBox7.Load("0%gauge.png");
                }
                else if (oxygenTanks[0].Counter == 5)
                    {
                        this.pictureBox1.Load("oxygentank0.jpg");
                        this.pictureBox7.Load("0%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#1 Oxygen tank is empty!", "High");
                        dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Red;
                        dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.White;

                        gridViewCount++;
                        oxygenTanks[0].Counter = 0;
                        oxygenTanks[0].Bleeding = false;
                        oxygenTanks[0].Filling = true;
                        valveCheck.Valve1 = true;
                        timer1.Stop();
                        oxygenTanks[0].Bleeding = false;
                        oxygenTanks[0].Filling = true;
                        //timer1.Tick -= new EventHandler(Bleeding);
                        //timer1.Tick += Filling1;
                        timer3.Start();
                        timer3.Interval = 500;
                        timer3.Enabled = true;
                        playAlarm();

                    }
                    else
                    {
                        //Counter = 0;
                    }
            }
            else
            {
                if (oxygenTanks[0].Counter == 1)
                {
                    this.pictureBox1.Load("oxygentank0.jpg");
                    this.pictureBox7.Load("0%gauge.png");
                }
                else if (oxygenTanks[0].Counter == 2)
                {
                    this.pictureBox1.Load("oxygentank25.jpg");
                    this.pictureBox7.Load("0%gauge.png");
                }
                else if (oxygenTanks[0].Counter == 3)
                {
                    this.pictureBox1.Load("oxygentank50.jpg");
                    this.pictureBox7.Load("50%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#1 Oxygen Tank is 50%", "Low");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Yellow;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.Black;
                    gridViewCount++;
                }
                else if (oxygenTanks[0].Counter == 4)
                {
                    this.pictureBox1.Load("oxygentank75.jpg");
                    this.pictureBox7.Load("100%gauge.png");
                }
                else if (oxygenTanks[0].Counter == 5)
                {
                    this.pictureBox1.Load("oxygentank.jpg");
                    this.pictureBox7.Load("100%gauge.png");
                    dataGridView1.Rows.Add(thisDay.ToString("g"), "#1 Oxygen Tank is Full", "Normal");
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Green;
                    dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.White;
                    oxygenTanks[0].Bleeding = true;
                    oxygenTanks[0].Filling = false;
                    valveCheck.Valve1 = true;
                    gridViewCount++;
                    oxygenTanks[0].Counter = 0;
                    timer1.Stop();
                    playAlarm();

                }
                else
                {
                    //Counter = 0;
                }
            }
 
        }



        public void playAlarm()
        {
            try
            {
                // the sounds loaded on your computer.
                string path; path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                string fullPathToSound = Path.Combine(path, @"sound\alarm.wav");               
                // appending sound location
                this.Player.SoundLocation = fullPathToSound;
                this.Player.PlayLooping();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error playing sound");
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
                if (button1.BackColor == Color.Red)
                {
                    button1.BackColor = Color.White;
                }
                else
                {
                    button1.BackColor = Color.Red;
                }
        }

        private void valve2Button_Click(object sender, EventArgs e)
        {
            if (valveCheck.Valve2 == true)
            {
                this.Player.Stop();
                timer2.Start();
                timer8.Stop();
                button3.BackColor = Color.White;
                valveCheck.Valve2 = false;
                if (valve2Button.BackColor == Color.Red)
                {
                    valve2Button.BackColor = Color.Green;
                    valve2Button.Text = "Open";
                }
                else
                {
                    valve2Button.BackColor = Color.Red;
                    valve2Button.Text = "Closed";
                }

            }
            else
            {
                MessageBox.Show("Tank is not full or empty.");
            }
        }

        private void valve3Button_Click(object sender, EventArgs e)
        {
            if (valveCheck.Valve3 == true)
            {
                this.Player.Stop();
                timer4.Start();
                timer9.Stop();
                button4.BackColor = Color.White;
                valveCheck.Valve3 = false;
                if (valve3Button.BackColor == Color.Red)
                {
                    valve3Button.BackColor = Color.Green;
                    valve3Button.Text = "Open";
                }
                else
                {
                    valve3Button.BackColor = Color.Red;
                    valve3Button.Text = "Closed";
                }

            }
            else
            {
                MessageBox.Show("Tank is not full or empty.");
            }
        }

        private void valve4Button_Click(object sender, EventArgs e)
        {
            if (valveCheck.Valve4 == true)
            {
                this.Player.Stop();
                timer5.Start();
                timer10.Stop();
                button5.BackColor = Color.White;
                valveCheck.Valve4 = false;
                if (valve4Button.BackColor == Color.Red)
                {
                    valve4Button.BackColor = Color.Green;
                    valve4Button.Text = "Open";
                }
                else
                {
                    valve4Button.BackColor = Color.Red;
                    valve4Button.Text = "Closed";
                }

            }
            else
            {
                MessageBox.Show("Tank is not full or empty.");
            }
        }

        private void valve5Button_Click(object sender, EventArgs e)
        {
            if (valveCheck.Valve5 == true)
            {
                this.Player.Stop();
                timer6.Start();
                timer11.Stop();
                valveCheck.Valve5 = false;
                button6.BackColor = Color.White;
                if (valve5Button.BackColor == Color.Red)
                {
                    valve5Button.BackColor = Color.Green;
                    valve5Button.Text = "Open";
                }
                else
                {
                    valve5Button.BackColor = Color.Red;
                    valve5Button.Text = "Closed";
                }

            }
            else
            {
                MessageBox.Show("Tank is not full or empty.");
            }
        }

        private void valve6Button_Click(object sender, EventArgs e)
        {
            if (valveCheck.Valve6 == true)
            {
                this.Player.Stop();
                timer7.Start();
                timer12.Stop();
                button7.BackColor = Color.White;
                valveCheck.Valve6 = false;
                if (valve6Button.BackColor == Color.Red)
                {
                    valve6Button.BackColor = Color.Green;
                    valve6Button.Text = "Open";
                }
                else
                {
                    valve6Button.BackColor = Color.Red;
                    valve6Button.Text = "Closed";
                }

            }
            else
            {
                MessageBox.Show("Tank is not full or empty.");
            }
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.Red)
            {
                button3.BackColor = Color.White;
            }
            else
            {
                button3.BackColor = Color.Red;
            }
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.Red)
            {
                button4.BackColor = Color.White;
            }
            else
            {
                button4.BackColor = Color.Red;
            }
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.Red)
            {
                button5.BackColor = Color.White;
            }
            else
            {
                button5.BackColor = Color.Red;
            }
        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.Red)
            {
                button6.BackColor = Color.White;
            }
            else
            {
                button6.BackColor = Color.Red;
            }
        }

        private void timer12_Tick(object sender, EventArgs e)
        {
            if (button7.BackColor == Color.Red)
            {
                button7.BackColor = Color.White;
            }
            else
            {
                button7.BackColor = Color.Red;
            }
        }

        private void powerButton_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);


            if (powerOn == false)
            {
                powerButton.ForeColor = Color.Green;
                powerButton.Text = "ON";
                powerOn = true;
                startTimers();
            }
            else
            {
                MessageBox.Show("To close all of the tasks, please close the software.");
            }
        }

        public void startTimers()
        {
            timer1.Start();
            timer2.Start();
            timer4.Start();
            timer5.Start();
            timer6.Start();
            timer7.Start();
        }

        public void stopTimers()
        {
            timer1.Stop();
            timer2.Stop();
            timer4.Stop();
            timer5.Stop();
            timer6.Stop();
            timer7.Stop();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 info = new Form3();
            info.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 status = new Form2();
            status.ShowDialog();
        }
    }
}
