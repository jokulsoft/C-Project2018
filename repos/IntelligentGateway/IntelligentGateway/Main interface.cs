using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentGateway
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string s = "aersfdgyxbcgvyfgetxcdfbrtdgfbcgyuidknshfbcgdectxuiosmjdhfvzaqplkdhgcbxgdbftesvxc" +
                "hsdydfgdbcjmfhdbdnchcuekwnxhfbdgdyehdnfhdjdhsyekljcokndoabvihfadbpihvojasdfbnvojndwojvbndfjbnvijafbvnojwdhvhjwhvj" +
                "dwjhfvpbeihvbowehvojnewopjncpejmckpnowencvpknmwepkcmpewkjfwemc";
            char[] r = new char[255];
            for(int i = 0; i<255; i++)
            {
                r[i] = char.Parse(s.Substring(i, 1));
            }
            this.textBox1.Text = s;
            string nm = null;
            this.textBox2.AppendText(nm);
            //this.textBox2.Text =PswCreate.PswStringCreate(s,"1975493");

        }
    }
}
