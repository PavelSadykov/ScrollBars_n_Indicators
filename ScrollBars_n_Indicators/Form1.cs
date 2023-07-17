using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ScrollBars_n_Indicators
{    
    public partial class Form1 : Form
    {
        private PictureBox selectedPictureBox; // Переменная для хранения выбранного PictureBox
        private Size originalSize; // Переменная для хранения изначального размера картинки
        public Form Tools;
        public Form1()
        {
            InitializeComponent();
            ShowToolTip();
                  // Привязка обработчика прокрутки к событию Scroll
            vScrollBar2.Scroll += vScrollBar2_Scroll;

            // Привязка обработчиков клика к каждому PictureBox
            pictureBox4.Click += PictureBox_Click;
            pictureBox2.Click += PictureBox_Click;
            pictureBox3.Click += PictureBox_Click;
        }
       

        public void ShowToolTip()
        {
            System.Windows.Forms.ToolTip myToolTip = new System.Windows.Forms.ToolTip();
            myToolTip.AutoPopDelay = 5000; // Время отображения
            myToolTip.InitialDelay = 1000; // Начальная задержка
            myToolTip.ReshowDelay = 100; // Задержка при повторном наведении
            
            myToolTip.ShowAlways = /*false */true; // Показывать подсказки когда
                                                   // родительское окно не активно
            //myToolTip.ShowAlways = false /*true*/;

            //myToolTip.IsBalloon = true;

            myToolTip.SetToolTip(this.vScrollBar1, "Перемещение объекта TextBox по вертикали");
            myToolTip.SetToolTip(this.hScrollBar1, "Нужно сделать TextBox перемещение объекта по горизонтали");
            myToolTip.SetToolTip(pictureBox1, "Картинка");
       }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
            vScrollBar1.Minimum = 0;
            //vScrollBar1.
            vScrollBar1.Maximum = 120;
            textBox1.Location = new Point(textBox1.Location.X,
                vScrollBar1.Value + 10);
            
            textBox1.Text = $"{textBox1.Location.X} : {textBox1.Location.Y}";
        }


        private void btnStartPB_MouseClick(object sender, MouseEventArgs e)
        {
            Timer timerPB = new Timer();
            timerPB.Enabled = true;
            timerPB.Interval = 1000;
            timerPB.Tick += TimerPB_Tick;
        }
        
        private void TimerPB_Tick(object sender, EventArgs e)
        {
            btnStartPB.Text = progBarDemo.Value.ToString();
            progBarDemo.PerformStep();
            //Text = ((Timer)sender).Interval.ToString();
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
            //numericUpDown1.
            var X = 445 + (int)numericUpDown1.Value;
            pictureBox1.Location = new Point(X, pictureBox1.Location.Y);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int Y = 137 + trackBar1.Value * 10;
            pictureBox1.Location = new Point(pictureBox1.Location.X, Y);
        }

        private void createElements(Form _form)
        {
            TextBox tbTools = new TextBox();
            tbTools.Location = new Point(10,10);
            tbTools.Size = new Size(50, 10);
            _form.Controls.Add(tbTools);
        }
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            if (Tools != null )
            {
                Tools.Dispose();
                Tools.Close();
                Tools = null;
            }
            else
            {
                Tools = new Form();
                createElements(Tools);
                Tools.Show();
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            hScrollBar1.Minimum = 0;
            hScrollBar1.Maximum = this.Width - textBox1.Width;

            textBox1.Location = new Point(hScrollBar1.Value, textBox1.Location.Y);

            int textBoxRight = textBox1.Location.X + textBox1.Width;
            int textBoxBottom = textBox1.Location.Y + textBox1.Height;

            textBox1.Text = $"Верхни левый: ({textBox1.Location.X}, {textBox1.Location.Y})\n" +
                            $"Нижний правый: ({textBoxRight}, {textBoxBottom})";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
       

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {

            if (selectedPictureBox != null)
            {
                UpdatePictureBoxSize(); // Обновляем размер выбранной картинки// Устанавливаем новый размер выбранной картинки
            }

        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            selectedPictureBox = (PictureBox)sender;
            selectedPictureBox.BorderStyle = BorderStyle.FixedSingle; // Подсветка выбранной картинки

            originalSize = selectedPictureBox.Image.Size; // Сохраняем изначальный размер картинки

            vScrollBar1.Value = 0; // Сбрасываем положение ползунка
            UpdatePictureBoxSize(); // Обновляем размер выбранной картинки
        }
        private void UpdatePictureBoxSize()
        {
            if (selectedPictureBox != null)
            {
                int delta = vScrollBar2.Value; // Значение прокрутки
                float scaleFactor = delta / 100f; // Изменение масштаба на основе приращения прокрутки

                int newWidth = (int)(originalSize.Width * scaleFactor);
                int newHeight = (int)(originalSize.Height * scaleFactor);

                selectedPictureBox.Size = new Size(newWidth, newHeight); // Устанавливаем новый размер выбранной картинки
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
           
        }
    }
}
