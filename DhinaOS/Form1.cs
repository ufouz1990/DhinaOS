using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DhinaOS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fork abbas = new Fork();
            abbas.forker();
            richTextBox1.Text = abbas.s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());

            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                richTextBox1.Text += "\t directory \n";
            }

            foreach (FileInfo f in dir.GetFiles())
            {
                richTextBox1.Text += "\t File" + f.Name +"\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Directory.GetCurrentDirectory();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            grep(textBox1.Text, richTextBox2.Text);
        }

        public void grep(string a, string b)
        {
            if (a==null || b==null)
            {
                richTextBox1.Text = "The syntax of the command is incorrect.";
            }
            else
            {
                b = b.Trim();
                string[] lines = b.Split('\n');
                foreach (string line in lines)
                {
                    if (line.Contains(a))
                    {
                        richTextBox1.Text = line;
                    }
                    else
                    {
                        richTextBox1.Text = "no match";
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Environment.UserName;
        }

        public string sjf()
        {
            string str = "";
            float avgwt,avgtt;
            string[] pname = new string[3];

            string[] c = new string[3];
            
            int[] wt,tt,bt,at;
            wt = new int[5];
            tt = new int[5];
            bt = new int[5];
            at = new int[5];
            int t,q,i,n=3,sum=0,sbt=0,j,ss=0;

            pname[0] = textBox2.Text;
            bt[0] = Convert.ToInt32(textBox3.Text);
            at[0] = Convert.ToInt32(textBox4.Text);

            pname[1] = textBox7.Text;
            bt[1] = Convert.ToInt32(textBox6.Text);
            at[1] = Convert.ToInt32(textBox5.Text);

            pname[2] = textBox10.Text;
            bt[2] = Convert.ToInt32(textBox9.Text);
            at[2] = Convert.ToInt32(textBox8.Text);


            
            for(i=0;i<n;i++)
                for(j=i+1;j<n;j++)
                {
                    if(at[i]==at[j])
                        if(bt[i]>bt[j])
                        {
                            t=at[i];
                            at[i]=at[j];
                            at[j]=t;
                            q=bt[i];
                            bt[i]=bt[j];
                            bt[j]=q;
                            c[i] = pname[i];
                            pname[i] = pname[j];
                            pname[j] = c[i];
                        }
                        if(at[i]!=at[j])
                            if(bt[i]>bt[j])
                            {
                                t=at[i];
                                at[i]=at[j];
                                at[j]=t;
                                q=bt[i];
                                bt[i]=bt[j];
                                bt[j]=q;
                                c[i] = pname[i];
                                pname[i] = pname[j];
                                pname[j] = c[i];
                            }
                }
                wt[0]=0;
                for(i=0;i<n;i++)
                {
                    wt[i+1]=wt[i]+bt[i];
                    sum=sum+(wt[i]-at[i]);
                    sbt=sbt+(wt[i+1]-at[i]);
                    tt[i]=wt[i]+bt[i];
                    ss=ss+bt[i];
                }
                str += "\n\n GANTT CHART";
                str += "\n\n ----------------------------------------------------------------------";
                str += "----------------------------------------------------------------------\n";
                for(i=0;i<n;i++)
                {
                    str += "|\t" + pname[i] + "\t";
                sbt=sbt+wt[i+1];
                tt[i]=wt[i]+bt[i];
                ss=ss+bt[i];
                }
                //str += "\n\nGANTT CHART";
                str += "\n ----------------------------------------------------------------------";
                str += "----------------------------------------------------------------------\n";
                //for(i=0;i<n;i++)
                //{
                //    str += "|\t" + pname[i] + "\t";
                //}
                //str += "\n\n ----------------------------------------------------------------------\n";
                for(i=0;i<n;i++)
                {
                str +=wt[i]+ "\t\t";
                }
                str += ss+ "\n";
                str += "----------------------------------------------------------------------";
                str += "----------------------------------------------------------------------\n";
                str += "\n\n Total WAITING TIME of the process="+ sum;
                str +=  "\n\nTotal TURNAROUND TIME of the process=" + sbt;
                avgwt=(float)sum/n;
                avgtt=(float)sbt/n;
                str += "\n\nAverage WAITING TIME of the process=" + avgwt;
                str += "\n\nAverage TURNAROUND TIME of the process=" + avgtt;
                return str;
        }

        public string fcfs()
        {
            string str = "";
            float avgwt, avgtt;
            string[] pname = new string[3];

            string[] c = new string[3];

            int[] wt, tt, bt, at;
            wt = new int[5];
            tt = new int[5];
            bt = new int[5];
            at = new int[5];
            int t, q, i, n = 3, sum = 0, sbt = 0, j, ss = 0;

            pname[0] = textBox2.Text;
            bt[0] = Convert.ToInt32(textBox3.Text);
            at[0] = Convert.ToInt32(textBox4.Text);

            pname[1] = textBox7.Text;
            bt[1] = Convert.ToInt32(textBox6.Text);
            at[1] = Convert.ToInt32(textBox5.Text);

            pname[2] = textBox10.Text;
            bt[2] = Convert.ToInt32(textBox9.Text);
            at[2] = Convert.ToInt32(textBox8.Text);



            for(i=0;i<n;i++)
            for(j=i+1;j<n;j++)
            {
                if(at[i]>at[j])
                {
                    t=at[i];
                    at[i]=at[j];
                    at[j]=t;
                    q=bt[i];
                    bt[i]=bt[j];
                    bt[j]=q;
                    c[i]= pname[i];
                    pname[i]=pname[j];
                    pname[j]=c[i];
                }
            }
            wt[0]=0;
            for(i=0;i<n;i++)
            {
                wt[i+1]=wt[i]+bt[i];
                sum=sum+(wt[i+1]-at[i]);
                tt[i]=wt[i]+bt[i];
                ss=ss+bt[i];
            }
            avgwt=(float) sum/n;
            avgtt=(float) sbt/n;
            str += "\n\nAverage waiting time=" + avgwt;
            str += "\n\nAverage turn-around time=" + avgtt;
            str += "\n\n GANTT CHART\n";
            str += "\n\n ----------------------------------------------------------------------";
            str += "----------------------------------------------------------------------\n";
            for(i=0;i<n;i++)
            {
                str += "|\t"+pname[i]+"\t";
            }
            str += "\n";
            str += "----------------------------------------------------------------------";
            str += "----------------------------------------------------------------------\n";
            for(i=0;i<n;i++)
            {
                str += wt[i]+"\t\t";
            }
            str += ss+"\n";
            str += "----------------------------------------------------------------------";
            str += "----------------------------------------------------------------------\n";
            str += "\n";
            
            return str;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = sjf();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = fcfs();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = mkdir(textBox11.Text);
        }

        public string mkdir(string a)
        {
            string str = "";

            try
            {
                if (Directory.Exists(a))
                {
                    str += "That path exists already.";
                    return str; ;
                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(a);
                    str += "The directory was created successfully at" + Directory.GetCreationTime(a);
                }

                //// Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                str += "The process failed: {0}" + e.ToString();
            }
            return str;
        }

        public string rmdir(string a)
        {
            string str = "";

            try
            {
                if (!Directory.Exists(a))
                {
                    str += "That path doesnt exists.";
                    return str; ;
                }
                else
                {
                    Directory.Delete(a);
                    str += "The directory was deleted successfully at" + Directory.GetCreationTime(a);
                }

            }
            catch (Exception e)
            {
                str += "The process failed: {0}" + e.ToString();
            }
            return str;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = rmdir(textBox11.Text);
        }
    }
}
