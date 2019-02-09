using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3UguralpOnbasli
{
    class Test
    {
        //private void ValveAction6(object sender, EventArgs e)
        //{
        //    DateTime thisDay = DateTime.Today;
        //    valveCheck.Valve6 = false;
        //    oxygenTanks[6].Counter += 1;

        //    if (oxygenTanks[6].Bleeding == true)
        //    {
        //        if (oxygenTanks[6].Counter == 1)
        //        {
        //            this.pictureBox6.Load("oxygentank.jpg");
        //            this.pictureBox12.Load("100%gauge.png");
        //        }
        //        else if (oxygenTanks[6].Counter == 2)
        //        {
        //            this.pictureBox6.Load("oxygentank75.jpg");
        //        }
        //        else if (oxygenTanks[6].Counter == 3)
        //        {
        //            this.pictureBox6.Load("oxygentank50.jpg");
        //            this.pictureBox12.Load("50%gauge.png");
        //            dataGridView1.Rows.Add(thisDay.ToString("g"), "#1 Oxygen tank is 50%!", "Low");
        //            dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Yellow;
        //            dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.Black;
        //            gridViewCount++;
        //        }
        //        else if (oxygenTanks[6].Counter == 4)
        //        {
        //            this.pictureBox6.Load("oxygentank25.jpg");
        //        }
        //        else if (oxygenTanks[6].Counter == 5)
        //        {
        //            this.pictureBox6.Load("oxygentank0.jpg");
        //            this.pictureBox12.Load("0%gauge.png");
        //            dataGridView1.Rows.Add(thisDay.ToString("g"), "#1 Oxygen tank is empty!", "High");
        //            dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Red;
        //            dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.White;
        //            button1.BackColor = Color.Red;

        //            gridViewCount++;
        //            oxygenTanks[6].Counter = 0;
        //            oxygenTanks[6].Bleeding = false;
        //            oxygenTanks[6].Filling = true;
        //            valveCheck.Valve6 = true;
        //            timer7.Stop();
        //            oxygenTanks[5].Bleeding = false;
        //            oxygenTanks[5].Filling = true;
        //            //timer7.Tick -= new EventHandler(Bleeding);
        //            //timer7.Tick += Filling1;
        //            timer3.Start();
        //            timer3.Interval = 500;
        //            timer3.Enabled = true;
        //            playAlarm();

        //        }
        //        else
        //        {
        //            //Counter = 0;
        //        }
        //    }
        //    else
        //    {
        //        if (oxygenTanks[6].Counter == 1)
        //        {
        //            this.pictureBox6.Load("oxygentank0.jpg");
        //            this.pictureBox12.Load("0%gauge.png");
        //        }
        //        else if (oxygenTanks[6].Counter == 2)
        //        {
        //            this.pictureBox6.Load("oxygentank25.jpg");
        //        }
        //        else if (oxygenTanks[6].Counter == 3)
        //        {
        //            this.pictureBox6.Load("oxygentank50.jpg");
        //            this.pictureBox12.Load("50%gauge.png");
        //            dataGridView1.Rows.Add(thisDay.ToString("g"), "#1 Oxygen Tank is 50%", "Low");
        //            dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Yellow;
        //            dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.Black;
        //            gridViewCount++;
        //        }
        //        else if (oxygenTanks[6].Counter == 4)
        //        {
        //            this.pictureBox6.Load("oxygentank75.jpg");
        //        }
        //        else if (oxygenTanks[6].Counter == 5)
        //        {
        //            this.pictureBox6.Load("oxygentank.jpg");
        //            this.pictureBox12.Load("100%gauge.png");
        //            dataGridView1.Rows.Add(thisDay.ToString("g"), "#1 Oxygen Tank is Full", "Normal");
        //            dataGridView1.Rows[gridViewCount].DefaultCellStyle.BackColor = Color.Green;
        //            dataGridView1.Rows[gridViewCount].DefaultCellStyle.ForeColor = Color.White;
        //            oxygenTanks[6].Bleeding = true;
        //            oxygenTanks[6].Filling = false;
        //            valveCheck.Valve6 = true;
        //            gridViewCount++;
        //            oxygenTanks[6].Counter = 0;
        //            timer7.Stop();
        //            //playAlarm();

        //        }
        //        else
        //        {
        //            //Counter = 0;
        //        }
        //    }

        //}//
    }
}
