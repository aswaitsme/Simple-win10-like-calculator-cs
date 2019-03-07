using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ascalc
{
    public partial class Form1 : Form
    {
        String txtres="";
        char lastop = ' ';
        bool newnum = true, doneop = false;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (newnum)
            {
                newnum = false;
                result.Text = "";
            }
            Button b = (Button)sender; 
            result.Text += b.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            result.Text = "0";
            txtres = "";
            lastop = ' ';
            newnum = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            result.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if(result.Text!="0")
            result.Text = result.Text.Substring(0, result.Text.Length - 1);
            if (result.Text == "") result.Text = "0";

        }

        private void buttonop_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            bool inf = false;
            if (txtres == "")
            {
                
               lastop = b.Text[0];
                txtres = result.Text;
               // result.Text = "";

            }
            else
            {
                if (!doneop)
                {
                    double curnum = Convert.ToDouble(result.Text);
                    double lastnum = Convert.ToDouble(txtres);
                    result.Text = "";
                    switch (lastop)
                    {
                        case '+':
                            {
                                lastnum += curnum;
                                break;
                            }
                        case '-':
                            {
                                lastnum -= curnum;
                                break;
                            }
                        case 'x':
                            {
                                lastnum *= curnum;
                                break;
                            }
                        case '/':
                            {
                                if (curnum != 0)
                                {
                                    lastnum /= curnum;
                                }
                                else
                                {
                                    inf = true;
                                }

                                break;
                            }
                    }

                    if (inf)
                    {
                        result.Text = "Infinity";
                    }
                    else
                    {

                        txtres = lastnum.ToString();

                        if (b.Text[0] == '=')
                        {
                            reset();
                        }

                        result.Text = lastnum.ToString();


                    }
                }
                else
                {
                    lastop = b.Text[0];
                }

               

            }
            newnum = true;
        }
    }
}
