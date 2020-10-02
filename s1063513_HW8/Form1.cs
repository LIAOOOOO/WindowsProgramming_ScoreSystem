using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s1063513_HW8
{
    public partial class Form1 : Form
    {
        
        Rectangle rect1;
        Rectangle rect2;
        Rectangle rect3;
        Rectangle rect4;
        Image img1 = Properties.Resources.apple;
        float total;
        public Form1()
        {
            InitializeComponent();
            rect1 = new Rectangle(650, 59, 50, 50);
            rect2 = new Rectangle(700, 59, 50, 50);
            rect3 = new Rectangle(750, 59, 50, 50);
            rect4 = new Rectangle(800, 59, 50, 50);
            this.Text = "StudentsRecord";
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "StudentsRecord";
            // TODO: 這行程式碼會將資料載入 'studentDataSet.Students' 資料表。您可以視需要進行移動或移除。
            this.studentsTableAdapter.Fill(this.studentDataSet.Students);
            
            float num = float.Parse(textBox3.Text);
            float num2 = float.Parse(textBox4.Text);
            total = (num + num2) / 2;
            label8.Text = total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if ((this.studentsBindingSource.Find("StudentID", textBox1.Text)) != -1)
            {
                MessageBox.Show("This ID exists!");
            }
            else if (float.Parse(textBox3.Text) > 100 || float.Parse(textBox3.Text) < 0)
            {
                MessageBox.Show("Incorrect MidExam Score!");
            }
            else if (float.Parse(textBox4.Text) > 100 || float.Parse(textBox4.Text) < 0)
            {
                MessageBox.Show("Incorrect FinalExam Score!");
            }
            else
            {
                this.studentsTableAdapter.Insert(textBox1.Text, textBox2.Text
                , comboBox1.Text, textBox3.Text, textBox4.Text);
                this.studentsTableAdapter.Fill(this.studentDataSet.Students);

            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = textBox3.Text;
            string c = textBox4.Text;
            if (float.Parse(textBox3.Text) > 100 || float.Parse(textBox3.Text) < 0)
            {
                MessageBox.Show("Incorrect MidExam Score!");
            }
            else if ((this.studentsBindingSource.Find("StudentID", textBox1.Text)) != -1)
            {
                MessageBox.Show("This ID exists!");
            }
            else if (float.Parse(textBox4.Text) > 100 || float.Parse(textBox4.Text) < 0)
            {
                MessageBox.Show("Incorrect FinalExam Score!");
            }
            else
            {
                this.studentsBindingSource.EndEdit();
                this.studentsTableAdapter.Update(this.studentDataSet);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.studentsTableAdapter.Delete(textBox1.Text, textBox2.Text
               , comboBox1.Text, textBox3.Text, textBox4.Text);
            this.studentsTableAdapter.Fill(this.studentDataSet.Students);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = -1;
            switch (comboBox2.Text)
            {
                case "ID":
                    i = this.studentsBindingSource.Find("StudentID", textBox5.Text);
                    break;
                case "Name":
                    i = this.studentsBindingSource.Find("StudentName", textBox5.Text);
                    break;
                case "Gender":
                    i = this.studentsBindingSource.Find("Gender", textBox5.Text);
                    break;
                case "MidExam":
                    i = this.studentsBindingSource.Find("MidExam", textBox5.Text);
                    break;
                case "FinalExam":
                    i = this.studentsBindingSource.Find("FinalExam", textBox5.Text);
                    break;
            }

            if (i != -1)
                this.studentsBindingSource.Position = i;
            else
                MessageBox.Show("Not found!");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            float D = float.Parse(textBox3.Text); 
            float C = float.Parse(textBox4.Text);
            label8.Text = ((C + D) / 2).ToString();
            Graphics g1 = this.CreateGraphics();
            total = (C + D) / 2;
            g1.Clear(DefaultBackColor);
            if (total >= 90)
                g1.DrawImage(img1, rect4);
            if (total >= 80)
                g1.DrawImage(img1, rect3);
            if (total >= 70)
                g1.DrawImage(img1, rect2);
            if (total >= 60)
                g1.DrawImage(img1, rect1);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g1 = this.CreateGraphics();
            if (total >= 90)
                g1.DrawImage(img1, rect4);
            if (total >= 80)
                g1.DrawImage(img1, rect3);
            if (total >= 70)
                g1.DrawImage(img1, rect2);
            if (total >= 60)
                g1.DrawImage(img1, rect1);
        }
    }
}
