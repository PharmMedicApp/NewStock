using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace PhramMedicApp
{
    public partial class Camera : Form
    {

        public Camera()
        {
            InitializeComponent();
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice vcd;

        private void Startbtn_Click(object sender, EventArgs e)

        {
            vcd = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            vcd.NewFrame += VideoCaptureDevice_NewFrame;
            vcd.Start();
            timer1.Start();

        }

        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();

        }

        private void Camera_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo fi in filterInfoCollection)
            {
                comboBox1.Items.Add(fi.Name);
            }
            comboBox1.SelectedIndex = 0;
        }
        
        public void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pictureBox1.Image);
                if (result != null)
                {
                    timer1.Stop();
                    barcode = result.ToString();
                    CloseTheCam();
                    this.Close();
                }
            }
        }

        public string barcode { get; set; }
        public bool a { get; set; }

        private void Camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseTheCam();
        }

        private void CloseTheCam()
        {
            if (vcd.IsRunning)
            {
                
                vcd.Stop();
                a = true;
            }
            
        }
    }
}
