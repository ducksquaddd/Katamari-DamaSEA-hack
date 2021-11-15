using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace WaterHack
{
    public partial class Form1 : Form
    {
        Mem meme = new Mem();
        public string scorePointer = "#TeamSeas.exe+0x02093B20,E8,258,F0,50,20,50";
        public string timerPointer = "#TeamSeas.exe+0x02093B20,1C8,100,40,1E0";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int PID = meme.GetProcIdFromName("#TeamSeas.exe");
            if(PID>0)
            {
                meme.OpenProcess(PID);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            meme.WriteMemory(scorePointer, "int", textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            meme.WriteMemory(timerPointer, "double", textBox2.Text);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                double value = meme.ReadDouble(timerPointer);
                meme.FreezeValue(timerPointer, "double", value.ToString());
            }
            else
            {
                meme.UnfreezeValue(timerPointer);
            }
        }
    }
}
