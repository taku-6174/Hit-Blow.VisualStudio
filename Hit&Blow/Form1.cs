using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hit_Blow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        { }
        private void label7_Click(object sender, EventArgs e)
        { }
        private void label30_Click(object sender, EventArgs e)
        { }
        private void result1_Click(object sender, EventArgs e)
        { }
        private void resultLabel_Click(object sender, EventArgs e) { }
        private void button10_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            List<int> numbers = Enumerable.Range(0, 10).ToList(); // 0〜9 の数字リスト

            // シャッフルして先頭3つを使う
            for (int n = numbers.Count - 1; n > 0; n--)
            {
                int swapIndex = rnd.Next(n + 1);
                int temp = numbers[n];
                numbers[n] = numbers[swapIndex];
                numbers[swapIndex] = temp;
            }

            int i = numbers[0];
            int j = numbers[1];
            int k = numbers[2];


            random1.Text = i.ToString();
            random2.Text = j.ToString();
            random3.Text = k.ToString();

            resultLabel.Text = "";
            gameover.Text = "";
            result1.Text = "?";
            result2.Text = "?";
            result3.Text = "?";
            nabi.Text = "";

            start.Text = "プレイ中";
            start.Enabled = false;

            nabi.Text = "";
        }


        private void reset_Click(object sender, EventArgs e)
        {
            string removedText = ""; // 消した数字を一時保存

            if (input3.Text != "-")
            {
                removedText = input3.Text;
                input3.Text = "-";
            }
            else if (input2.Text != "-")
            {
                removedText = input2.Text;
                input2.Text = "-";
            }
            else if (input1.Text != "-")
            {
                removedText = input1.Text;
                input1.Text = "-";
            }

            // ボタンを再び有効化（Enabled = true）
            if (removedText != "")
            {
                foreach (Control c in this.Controls)
                {
                    if (c is Button btn && btn.Text == removedText)
                    {
                        btn.Enabled = true;
                        break;
                    }
                }
            }
        }

        private void Nunberbutton_Ckick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                if (input1.Text == "-")
                {
                    input1.Text = clickedButton.Text;
                    clickedButton.Enabled = false; // 押されたボタンを無効化
                }
                else if (input2.Text == "-")
                {
                    input2.Text = clickedButton.Text;
                    clickedButton.Enabled = false;
                }
                else if (input3.Text == "-")
                {
                    input3.Text = clickedButton.Text;
                    clickedButton.Enabled = false;
                }
            }
        }

        private void kettei_Click(object sender, EventArgs e)
        {

            if (input1.Text == random1.Text && input2.Text == random2.Text && input3.Text == random3.Text)
            {
                result1.Text = random1.Text;
                result2.Text = random2.Text;
                result3.Text = random3.Text;

                start.Text = "スタート";
                start.Enabled = true;

                resultLabel.Text = "正解!";
                label1.Text = "ここクリックして";
                // 全てのボタンを有効化（数字ボタンのみ）
                EnableAllNumberButtons(this);
            }

            if (input3.Text != "-")
            {
                if (time1.Text == "")
                {
                    h1.Text = "0";
                    b1.Text = "0";

                    if (input1.Text == random1.Text)
                    {
                        int i = 1;
                        h1.Text = i.ToString();
                        if (input2.Text == random2.Text)
                        {
                            i = 2;
                            h1.Text = i.ToString();
                            if (input3.Text == random3.Text)
                            {
                                i = 3;
                                h1.Text = i.ToString();
                            }
                        }
                        if (input3.Text == random3.Text)
                        {
                            i = 2;
                            h1.Text = i.ToString();
                            if (input2.Text == random2.Text)
                            {
                                i = 3;
                                h1.Text = i.ToString();
                            }
                        }
                    }
                    if (input2.Text == random2.Text)
                    {
                        int i = 1;
                        h1.Text = i.ToString();
                        if (input1.Text == random1.Text)
                        {
                            i = 2;
                            h1.Text = i.ToString();
                            if (input3.Text == random3.Text)
                            {
                                i = 3;
                                h1.Text = i.ToString();
                            }
                        }
                        if (input3.Text == random3.Text)
                        {
                            i = 2;
                            h1.Text = i.ToString();
                            if (input1.Text == random1.Text)
                            {
                                i = 3;
                                h1.Text = i.ToString();
                            }
                        }
                    }
                    if (input3.Text == random3.Text)
                    {
                        int i = 1;
                        h1.Text = i.ToString();
                        if (input1.Text == random1.Text)
                        {
                            i = 2;
                            h1.Text = i.ToString();
                            if (input2.Text == random2.Text)
                            {
                                i = 3;
                                h1.Text = i.ToString();
                            }
                        }
                        if (input2.Text == random2.Text)
                        {
                            i = 2;
                            h1.Text = i.ToString();
                            if (input1.Text == random1.Text)
                            {
                                i = 3;
                                h1.Text = i.ToString();
                            }
                        }
                    }
                    if (input1.Text == random2.Text || input1.Text == random3.Text)
                    {
                        int j = 1;
                        b1.Text = j.ToString();
                        if (input2.Text == random1.Text || input2.Text == random3.Text)
                        {
                            j = 2;
                            b1.Text = j.ToString();
                            if (input3.Text == random1.Text || input3.Text == random2.Text)
                            {
                                j = 3;
                                b1.Text = j.ToString();
                            }
                        }
                        if (input3.Text == random1.Text || input3.Text == random2.Text)
                        {
                            j = 2;
                            b1.Text = j.ToString();
                            if (input2.Text == random1.Text || input2.Text == random3.Text)
                            {
                                j = 3;
                                b1.Text = j.ToString();
                            }
                        }
                    }
                    if (input2.Text == random1.Text || input2.Text == random3.Text)
                    {
                        int j = 1;
                        b1.Text = j.ToString();
                        if (input1.Text == random2.Text || input1.Text == random3.Text)
                        {
                            j = 2;
                            b1.Text = j.ToString();
                            if (input3.Text == random1.Text || input3.Text == random2.Text)
                            {
                                j = 3;
                                b1.Text = j.ToString();
                            }
                        }
                        if (input3.Text == random1.Text || input3.Text == random2.Text)
                        {
                            j = 2;
                            b1.Text = j.ToString();
                            if (input1.Text == random2.Text || input1.Text == random3.Text)
                            {
                                j = 3;
                                b1.Text = j.ToString();
                            }
                        }
                    }
                    if (input3.Text == random1.Text || input3.Text == random2.Text)
                    {
                        int j = 1;
                        b1.Text = j.ToString();
                        if (input1.Text == random2.Text || input1.Text == random3.Text)
                        {
                            j = 2;
                            b1.Text = j.ToString();
                            if (input2.Text == random1.Text || input2.Text == random3.Text)
                            {
                                j = 3;
                                b1.Text = j.ToString();
                            }
                        }
                        if (input2.Text == random1.Text || input2.Text == random3.Text)
                        {
                            j = 2;
                            b1.Text = j.ToString();
                            if (input1.Text == random2.Text || input1.Text == random3.Text)
                            {
                                j = 3;
                                b1.Text = j.ToString();
                            }
                        }
                    }

                    time1.Text = input1.Text + input2.Text + input3.Text;
                    input1.Text = "-";
                    input2.Text = "-";
                    input3.Text = "-";
                    // 全てのボタンを有効化（数字ボタンのみ）
                    EnableAllNumberButtons(this);

                }
                else if (time2.Text == "")
                {
                    h2.Text = "0";
                    b2.Text = "0";
                    if (input1.Text == random1.Text)
                    {
                        int i = 1;
                        h2.Text = i.ToString();
                        if (input2.Text == random2.Text)
                        {
                            i = 2;
                            h2.Text = i.ToString();
                            if (input3.Text == random3.Text)
                            {
                                i = 3;
                                h2.Text = i.ToString();
                            }
                        }
                        if (input3.Text == random3.Text)
                        {
                            i = 2;
                            h2.Text = i.ToString();
                            if (input2.Text == random2.Text)
                            {
                                i = 3;
                                h2.Text = i.ToString();
                            }
                        }
                    }
                    if (input2.Text == random2.Text)
                    {
                        int i = 1;
                        h2.Text = i.ToString();
                        if (input1.Text == random1.Text)
                        {
                            i = 2;
                            h2.Text = i.ToString();
                            if (input3.Text == random3.Text)
                            {
                                i = 3;
                                h2.Text = i.ToString();
                            }
                        }
                        if (input3.Text == random3.Text)
                        {
                            i = 2;
                            h2.Text = i.ToString();
                            if (input1.Text == random1.Text)
                            {
                                i = 3;
                                h2.Text = i.ToString();
                            }
                        }
                    }
                    if (input3.Text == random3.Text)
                    {
                        int i = 1;
                        h2.Text = i.ToString();
                        if (input1.Text == random1.Text)
                        {
                            i = 2;
                            h2.Text = i.ToString();
                            if (input2.Text == random2.Text)
                            {
                                i = 3;
                                h2.Text = i.ToString();
                            }
                        }
                        if (input2.Text == random2.Text)
                        {
                            i = 2;
                            h2.Text = i.ToString();
                            if (input1.Text == random1.Text)
                            {
                                i = 3;
                                h2.Text = i.ToString();
                            }
                        }
                    }
                    if (input1.Text == random2.Text || input1.Text == random3.Text)
                    {
                        int j = 1;
                        b2.Text = j.ToString();
                        if (input2.Text == random1.Text || input2.Text == random3.Text)
                        {
                            j = 2;
                            b2.Text = j.ToString();
                            if (input3.Text == random1.Text || input3.Text == random2.Text)
                            {
                                j = 3;
                                b2.Text = j.ToString();
                            }
                        }
                        if (input3.Text == random1.Text || input3.Text == random2.Text)
                        {
                            j = 2;
                            b2.Text = j.ToString();
                            if (input2.Text == random1.Text || input2.Text == random3.Text)
                            {
                                j = 3;
                                b2.Text = j.ToString();
                            }
                        }
                    }
                    if (input2.Text == random1.Text || input2.Text == random3.Text)
                    {
                        int j = 1;
                        b2.Text = j.ToString();
                        if (input1.Text == random2.Text || input1.Text == random3.Text)
                        {
                            j = 2;
                            b2.Text = j.ToString();
                            if (input3.Text == random1.Text || input3.Text == random2.Text)
                            {
                                j = 3;
                                b2.Text = j.ToString();
                            }
                        }
                        if (input3.Text == random1.Text || input3.Text == random2.Text)
                        {
                            j = 2;
                            b2.Text = j.ToString();
                            if (input1.Text == random2.Text || input1.Text == random3.Text)
                            {
                                j = 3;
                                b2.Text = j.ToString();
                            }
                        }
                    }
                    if (input3.Text == random1.Text || input3.Text == random2.Text)
                    {
                        int j = 1;
                        b2.Text = j.ToString();
                        if (input1.Text == random2.Text || input1.Text == random3.Text)
                        {
                            j = 2;
                            b2.Text = j.ToString();
                            if (input2.Text == random1.Text || input2.Text == random3.Text)
                            {
                                j = 3;
                                b2.Text = j.ToString();
                            }
                        }
                        if (input2.Text == random1.Text || input2.Text == random3.Text)
                        {
                            j = 2;
                            b2.Text = j.ToString();
                            if (input1.Text == random2.Text || input1.Text == random3.Text)
                            {
                                j = 3;
                                b2.Text = j.ToString();
                            }
                        }
                    }
                    time2.Text = input1.Text + input2.Text + input3.Text;
                    input1.Text = "-";
                    input2.Text = "-";
                    input3.Text = "-";
                    // 全てのボタンを有効化（数字ボタンのみ）
                    EnableAllNumberButtons(this);
                }
                else if (time3.Text == "")
                {
                    h3.Text = "0";
                    b3.Text = "0";
                    if (input1.Text == random1.Text)
                    {
                        int i = 1;
                        h3.Text = i.ToString();
                        if (input2.Text == random2.Text)
                        {
                            i = 2;
                            h3.Text = i.ToString();
                            if (input3.Text == random3.Text)
                            {
                                i = 3;
                                h3.Text = i.ToString();
                            }
                        }
                        if (input3.Text == random3.Text)
                        {
                            i = 2;
                            h3.Text = i.ToString();
                            if (input2.Text == random2.Text)
                            {
                                i = 3;
                                h3.Text = i.ToString();
                            }
                        }
                    }
                    if (input2.Text == random2.Text)
                    {
                        int i = 1;
                        h3.Text = i.ToString();
                        if (input1.Text == random1.Text)
                        {
                            i = 2;
                            h3.Text = i.ToString();
                            if (input3.Text == random3.Text)
                            {
                                i = 3;
                                h3.Text = i.ToString();
                            }
                        }
                        if (input3.Text == random3.Text)
                        {
                            i = 2;
                            h3.Text = i.ToString();
                            if (input1.Text == random1.Text)
                            {
                                i = 3;
                                h3.Text = i.ToString();
                            }
                        }
                    }
                    if (input3.Text == random3.Text)
                    {
                        int i = 1;
                        h3.Text = i.ToString();
                        if (input1.Text == random1.Text)
                        {
                            i = 2;
                            h3.Text = i.ToString();
                            if (input2.Text == random2.Text)
                            {
                                i = 3;
                                h3.Text = i.ToString();
                            }
                        }
                        if (input2.Text == random2.Text)
                        {
                            i = 2;
                            h3.Text = i.ToString();
                            if (input1.Text == random1.Text)
                            {
                                i = 3;
                                h3.Text = i.ToString();
                            }
                        }
                    }
                    if (input1.Text == random2.Text || input1.Text == random3.Text)
                    {
                        int j = 1;
                        b3.Text = j.ToString();
                        if (input2.Text == random1.Text || input2.Text == random3.Text)
                        {
                            j = 2;
                            b3.Text = j.ToString();
                            if (input3.Text == random1.Text || input3.Text == random2.Text)
                            {
                                j = 3;
                                b3.Text = j.ToString();
                            }
                        }
                        if (input3.Text == random1.Text || input3.Text == random2.Text)
                        {
                            j = 2;
                            b3.Text = j.ToString();
                            if (input2.Text == random1.Text || input2.Text == random3.Text)
                            {
                                j = 3;
                                b3.Text = j.ToString();
                            }
                        }
                    }
                    if (input2.Text == random1.Text || input2.Text == random3.Text)
                    {
                        int j = 1;
                        b3.Text = j.ToString();
                        if (input1.Text == random2.Text || input1.Text == random3.Text)
                        {
                            j = 2;
                            b3.Text = j.ToString();
                            if (input3.Text == random1.Text || input3.Text == random2.Text)
                            {
                                j = 3;
                                b3.Text = j.ToString();
                            }
                        }
                        if (input3.Text == random1.Text || input3.Text == random2.Text)
                        {
                            j = 2;
                            b3.Text = j.ToString();
                            if (input1.Text == random2.Text || input1.Text == random3.Text)
                            {
                                j = 3;
                                b3.Text = j.ToString();
                            }
                        }
                    }
                    if (input3.Text == random1.Text || input3.Text == random2.Text)
                    {
                        int j = 1;
                        b3.Text = j.ToString();
                        if (input1.Text == random2.Text || input1.Text == random3.Text)
                        {
                            j = 2;
                            b3.Text = j.ToString();
                            if (input2.Text == random1.Text || input2.Text == random3.Text)
                            {
                                j = 3;
                                b3.Text = j.ToString();
                            }
                        }
                        if (input2.Text == random1.Text || input2.Text == random3.Text)
                        {
                            j = 2;
                            b3.Text = j.ToString();
                            if (input1.Text == random2.Text || input1.Text == random3.Text)
                            {
                                j = 3;
                                b3.Text = j.ToString();
                            }
                        }
                    }
                    time3.Text = input1.Text + input2.Text + input3.Text;
                    input1.Text = "-";
                    input2.Text = "-";
                    input3.Text = "-";
                    // 全てのボタンを有効化（数字ボタンのみ）
                    EnableAllNumberButtons(this);
                }
                else if (time4.Text == "")
                {
                    h4.Text = "0";
                    b4.Text = "0";
                    if (input1.Text == random1.Text)
                    {
                        int i = 1;
                        h4.Text = i.ToString();
                        if (input2.Text == random2.Text)
                        {
                            i = 2;
                            h4.Text = i.ToString();
                            if (input3.Text == random3.Text)
                            {
                                i = 3;
                                h4.Text = i.ToString();
                            }
                        }
                        if (input3.Text == random3.Text)
                        {
                            i = 2;
                            h4.Text = i.ToString();
                            if (input2.Text == random2.Text)
                            {
                                i = 3;
                                h4.Text = i.ToString();
                            }
                        }
                    }
                    if (input2.Text == random2.Text)
                    {
                        int i = 1;
                        h4.Text = i.ToString();
                        if (input1.Text == random1.Text)
                        {
                            i = 2;
                            h4.Text = i.ToString();
                            if (input3.Text == random3.Text)
                            {
                                i = 3;
                                h4.Text = i.ToString();
                            }
                        }
                        if (input3.Text == random3.Text)
                        {
                            i = 2;
                            h4.Text = i.ToString();
                            if (input1.Text == random1.Text)
                            {
                                i = 3;
                                h4.Text = i.ToString();
                            }
                        }
                    }
                    if (input3.Text == random3.Text)
                    {
                        int i = 1;
                        h4.Text = i.ToString();
                        if (input1.Text == random1.Text)
                        {
                            i = 2;
                            h4.Text = i.ToString();
                            if (input2.Text == random2.Text)
                            {
                                i = 3;
                                h4.Text = i.ToString();
                            }
                        }
                        if (input2.Text == random2.Text)
                        {
                            i = 2;
                            h4.Text = i.ToString();
                            if (input1.Text == random1.Text)
                            {
                                i = 3;
                                h4.Text = i.ToString();
                            }
                        }
                    }
                    if (input1.Text == random2.Text || input1.Text == random3.Text)
                    {
                        int j = 1;
                        b4.Text = j.ToString();
                        if (input2.Text == random1.Text || input2.Text == random3.Text)
                        {
                            j = 2;
                            b4.Text = j.ToString();
                            if (input3.Text == random1.Text || input3.Text == random2.Text)
                            {
                                j = 3;
                                b4.Text = j.ToString();
                            }
                        }
                        if (input3.Text == random1.Text || input3.Text == random2.Text)
                        {
                            j = 2;
                            b4.Text = j.ToString();
                            if (input2.Text == random1.Text || input2.Text == random3.Text)
                            {
                                j = 3;
                                b4.Text = j.ToString();
                            }
                        }
                    }
                    if (input2.Text == random1.Text || input2.Text == random3.Text)
                    {
                        int j = 1;
                        b4.Text = j.ToString();
                        if (input1.Text == random2.Text || input1.Text == random3.Text)
                        {
                            j = 2;
                            b4.Text = j.ToString();
                            if (input3.Text == random1.Text || input3.Text == random2.Text)
                            {
                                j = 3;
                                b4.Text = j.ToString();
                            }
                        }
                        if (input3.Text == random1.Text || input3.Text == random2.Text)
                        {
                            j = 2;
                            b4.Text = j.ToString();
                            if (input1.Text == random2.Text || input1.Text == random3.Text)
                            {
                                j = 3;
                                b4.Text = j.ToString();
                            }
                        }
                    }
                    if (input3.Text == random1.Text || input3.Text == random2.Text)
                    {
                        int j = 1;
                        b4.Text = j.ToString();
                        if (input1.Text == random2.Text || input1.Text == random3.Text)
                        {
                            j = 2;
                            b4.Text = j.ToString();
                            if (input2.Text == random1.Text || input2.Text == random3.Text)
                            {
                                j = 3;
                                b4.Text = j.ToString();
                            }
                        }
                        if (input2.Text == random1.Text || input2.Text == random3.Text)
                        {
                            j = 2;
                            b4.Text = j.ToString();
                            if (input1.Text == random2.Text || input1.Text == random3.Text)
                            {
                                j = 3;
                                b4.Text = j.ToString();
                            }
                        }
                    }
                    time4.Text = input1.Text + input2.Text + input3.Text;
                    input1.Text = "-";
                    input2.Text = "-";
                    input3.Text = "-";
                    // 全てのボタンを有効化（数字ボタンのみ）
                    EnableAllNumberButtons(this);
                }
                else if (time5.Text == "")
                {
                    h5.Text = "0";
                    b5.Text = "0";
                    if (input1.Text == random1.Text)
                    {
                        int i = 1;
                        h5.Text = i.ToString();
                        if (input2.Text == random2.Text)
                        {
                            i = 2;
                            h5.Text = i.ToString();
                            if (input3.Text == random3.Text)
                            {
                                i = 3;
                                h5.Text = i.ToString();
                            }
                        }
                        if (input3.Text == random3.Text)
                        {
                            i = 2;
                            h5.Text = i.ToString();
                            if (input2.Text == random2.Text)
                            {
                                i = 3;
                                h5.Text = i.ToString();
                            }
                        }
                    }
                    if (input2.Text == random2.Text)
                    {
                        int i = 1;
                        h5.Text = i.ToString();
                        if (input1.Text == random1.Text)
                        {
                            i = 2;
                            h5.Text = i.ToString();
                            if (input3.Text == random3.Text)
                            {
                                i = 3;
                                h5.Text = i.ToString();
                            }
                        }
                        if (input3.Text == random3.Text)
                        {
                            i = 2;
                            h5.Text = i.ToString();
                            if (input1.Text == random1.Text)
                            {
                                i = 3;
                                h5.Text = i.ToString();
                            }
                        }
                    }
                    if (input3.Text == random3.Text)
                    {
                        int i = 1;
                        h5.Text = i.ToString();
                        if (input1.Text == random1.Text)
                        {
                            i = 2;
                            h5.Text = i.ToString();
                            if (input2.Text == random2.Text)
                            {
                                i = 3;
                                h5.Text = i.ToString();
                            }
                        }
                        if (input2.Text == random2.Text)
                        {
                            i = 2;
                            h5.Text = i.ToString();
                            if (input1.Text == random1.Text)
                            {
                                i = 3;
                                h5.Text = i.ToString();
                            }
                        }
                    }
                    if (input1.Text == random2.Text || input1.Text == random3.Text)
                    {
                        int j = 1;
                        b5.Text = j.ToString();
                        if (input2.Text == random1.Text || input2.Text == random3.Text)
                        {
                            j = 2;
                            b5.Text = j.ToString();
                            if (input3.Text == random1.Text || input3.Text == random2.Text)
                            {
                                j = 3;
                                b5.Text = j.ToString();
                            }
                        }
                        if (input3.Text == random1.Text || input3.Text == random2.Text)
                        {
                            j = 2;
                            b5.Text = j.ToString();
                            if (input2.Text == random1.Text || input2.Text == random3.Text)
                            {
                                j = 3;
                                b5.Text = j.ToString();
                            }
                        }
                    }
                    if (input2.Text == random1.Text || input2.Text == random3.Text)
                    {
                        int j = 1;
                        b5.Text = j.ToString();
                        if (input1.Text == random2.Text || input1.Text == random3.Text)
                        {
                            j = 2;
                            b5.Text = j.ToString();
                            if (input3.Text == random1.Text || input3.Text == random2.Text)
                            {
                                j = 3;
                                b5.Text = j.ToString();
                            }
                        }
                        if (input3.Text == random1.Text || input3.Text == random2.Text)
                        {
                            j = 2;
                            b5.Text = j.ToString();
                            if (input1.Text == random2.Text || input1.Text == random3.Text)
                            {
                                j = 3;
                                b5.Text = j.ToString();
                            }
                        }
                    }
                    if (input3.Text == random1.Text || input3.Text == random2.Text)
                    {
                        int j = 1;
                        b5.Text = j.ToString();
                        if (input1.Text == random2.Text || input1.Text == random3.Text)
                        {
                            j = 2;
                            b5.Text = j.ToString();
                            if (input2.Text == random1.Text || input2.Text == random3.Text)
                            {
                                j = 3;
                                b5.Text = j.ToString();
                            }
                        }
                        if (input2.Text == random1.Text || input2.Text == random3.Text)
                        {
                            j = 2;
                            b5.Text = j.ToString();
                            if (input1.Text == random2.Text || input1.Text == random3.Text)
                            {
                                j = 3;
                                b5.Text = j.ToString();
                            }
                        }
                    }
                    time5.Text = input1.Text + input2.Text + input3.Text;
                    input1.Text = "-";
                    input2.Text = "-";
                    input3.Text = "-";
                    // 全てのボタンを有効化（数字ボタンのみ）
                    EnableAllNumberButtons(this);
                }
                else if (time6.Text == "")
                {
                    h6.Text = "0";
                    b6.Text = "0";
                    if (input1.Text == random1.Text)
                    {
                        int i = 1;
                        h6.Text = i.ToString();
                        if (input2.Text == random2.Text)
                        {
                            i = 2;
                            h6.Text = i.ToString();
                            if (input3.Text == random3.Text)
                            {
                                i = 3;
                                h6.Text = i.ToString();
                            }
                        }
                        if (input3.Text == random3.Text)
                        {
                            i = 2;
                            h6.Text = i.ToString();
                            if (input2.Text == random2.Text)
                            {
                                i = 3;
                                h6.Text = i.ToString();
                            }
                        }
                    }
                    if (input2.Text == random2.Text)
                    {
                        int i = 1;
                        h6.Text = i.ToString();
                        if (input1.Text == random1.Text)
                        {
                            i = 2;
                            h6.Text = i.ToString();
                            if (input3.Text == random3.Text)
                            {
                                i = 3;
                                h6.Text = i.ToString();
                            }
                        }
                        if (input3.Text == random3.Text)
                        {
                            i = 2;
                            h6.Text = i.ToString();
                            if (input1.Text == random1.Text)
                            {
                                i = 3;
                                h6.Text = i.ToString();
                            }
                        }
                    }
                    if (input3.Text == random3.Text)
                    {
                        int i = 1;
                        h6.Text = i.ToString();
                        if (input1.Text == random1.Text)
                        {
                            i = 2;
                            h6.Text = i.ToString();
                            if (input2.Text == random2.Text)
                            {
                                i = 3;
                                h6.Text = i.ToString();
                            }
                        }
                        if (input2.Text == random2.Text)
                        {
                            i = 2;
                            h6.Text = i.ToString();
                            if (input1.Text == random1.Text)
                            {
                                i = 3;
                                h6.Text = i.ToString();
                            }
                        }
                    }
                    if (input1.Text == random2.Text || input1.Text == random3.Text)
                    {
                        int j = 1;
                        b6.Text = j.ToString();
                        if (input2.Text == random1.Text || input2.Text == random3.Text)
                        {
                            j = 2;
                            b6.Text = j.ToString();
                            if (input3.Text == random1.Text || input3.Text == random2.Text)
                            {
                                j = 3;
                                b6.Text = j.ToString();
                            }
                        }
                        if (input3.Text == random1.Text || input3.Text == random2.Text)
                        {
                            j = 2;
                            b6.Text = j.ToString();
                            if (input2.Text == random1.Text || input2.Text == random3.Text)
                            {
                                j = 3;
                                b6.Text = j.ToString();
                            }
                        }
                    }
                    if (input2.Text == random1.Text || input2.Text == random3.Text)
                    {
                        int j = 1;
                        b6.Text = j.ToString();
                        if (input1.Text == random2.Text || input1.Text == random3.Text)
                        {
                            j = 2;
                            b6.Text = j.ToString();
                            if (input3.Text == random1.Text || input3.Text == random2.Text)
                            {
                                j = 3;
                                b6.Text = j.ToString();
                            }
                        }
                        if (input3.Text == random1.Text || input3.Text == random2.Text)
                        {
                            j = 2;
                            b6.Text = j.ToString();
                            if (input1.Text == random2.Text || input1.Text == random3.Text)
                            {
                                j = 3;
                                b6.Text = j.ToString();
                            }
                        }
                    }
                    if (input3.Text == random1.Text || input3.Text == random2.Text)
                    {
                        int j = 1;
                        b6.Text = j.ToString();
                        if (input1.Text == random2.Text || input1.Text == random3.Text)
                        {
                            j = 2;
                            b6.Text = j.ToString();
                            if (input2.Text == random1.Text || input2.Text == random3.Text)
                            {
                                j = 3;
                                b6.Text = j.ToString();
                            }
                        }
                        if (input2.Text == random1.Text || input2.Text == random3.Text)
                        {
                            j = 2;
                            b6.Text = j.ToString();
                            if (input1.Text == random2.Text || input1.Text == random3.Text)
                            {
                                j = 3;
                                b6.Text = j.ToString();
                            }
                        }
                    }
                    time6.Text = input1.Text + input2.Text + input3.Text;
                    input1.Text = "-";
                    input2.Text = "-";
                    input3.Text = "-";
                    // 全てのボタンを有効化（数字ボタンのみ）
                    EnableAllNumberButtons(this);
                }
                else
                {
                    if (input1.Text == random1.Text && input2.Text == random2.Text && input3.Text == random3.Text)
                    {
                        result1.Text = random1.Text;
                        result2.Text = random2.Text;
                        result3.Text = random3.Text;

                        start.Text = "スタート";
                        start.Enabled = true;

                        resultLabel.Text = "正解!";
                        label1.Text = "ここクリックして";
                        // 全てのボタンを有効化（数字ボタンのみ）
                        EnableAllNumberButtons(this);
                    }
                    else
                    {
                        result1.Text = random1.Text;
                        result2.Text = random2.Text;
                        result3.Text = random3.Text;

                        gameover.Text = "GAMEOVER";
                        label1.Text = "ここクリックして";
                        // 全てのボタンを有効化（数字ボタンのみ）
                        EnableAllNumberButtons(this);
                    }
                }
               

                }
                
            }
           

                
            
           
            
        

        // 再帰的にすべてのコントロールから数字ボタンを探して有効化
        private void EnableAllNumberButtons(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn && btn.Text.Length == 1 && btn.Text[0] >= '0' && btn.Text[0] <= '9')
                {
                    btn.Enabled = true;
                }

                // 子コントロールを再帰的に調べる
                if (c.HasChildren)
                {
                    EnableAllNumberButtons(c);
                }
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {
            start.Text = "スタート";
            start.Enabled = true;

            resultLabel.Text = "";
            nabi.Text = "↑最初にここ押して";
            result1.Text = "?";
            result2.Text = "?";
            result3.Text = "?";
            label1.Text = "";
            input1.Text = "-";
            input2.Text = "-";
            input3.Text = "-";
            time1.Text = "";
            time2.Text = "";
            time3.Text = "";
            time4.Text = "";
            time5.Text = "";
            time6.Text = "";
            time7.Text = "";
            h1.Text = "";
            h2.Text = "";
            h3.Text = "";
            h4.Text = "";
            h5.Text = "";
            h6.Text = "";
            h7.Text = "";
            b1.Text = "";
            b2.Text = "";
            b3.Text = "";
            b4.Text = "";
            b5.Text = "";
            b6.Text = "";
            b7.Text = "";
            gameover.Text = "";


        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}