using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ImageProcessingActivity
{
    public partial class Form1 : Form
    {
        Bitmap loaded, processed;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        public Form1()
        {
            InitializeComponent();
            LoadVideoDevices();
        }

        private void LoadVideoDevices()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No video devices found.");
            }
        }

        private void StartWebcam()
        {
            if (videoDevices.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(Video_NewFrame);
                videoSource.Start();
                toolStripStatusLabel1.Text = "Webcam started.";
            }
            else
            {
                MessageBox.Show("No video devices found.");
            }
        }

        private void StopWebcam()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                pictureBox1.Image = null;
                toolStripStatusLabel1.Text = "Webcam stopped.";
            }
        }

        private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = frame;
        }

        private void btnStartWebcam_Click(object sender, EventArgs e)
        {
            StartWebcam();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
            openFileDialog1.Title = "Select an Image File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    loaded = new Bitmap(openFileDialog1.FileName);
                    pictureBox1.Image = loaded;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not load image. Original error: " + ex.Message);
                }
            }
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                processed = new Bitmap(pictureBox1.Image);
                Color pixel;
                int ave;

                for (int x = 0; x < processed.Width; x++)
                {
                    for (int y = 0; y < processed.Height; y++)
                    {
                        pixel = processed.GetPixel(x, y);
                        ave = (int)(pixel.R + pixel.G + pixel.B) / 3;
                        Color gray = Color.FromArgb(ave, ave, ave);
                        processed.SetPixel(x, y, gray);
                    }
                }
                pictureBox2.Image = processed;
            }
            else
            {
                MessageBox.Show("No image to process. Please start the webcam or load an image.");
            }
        }

        private void basicCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                processed = new Bitmap(pictureBox1.Image);
                pictureBox2.Image = processed;
            }
            else
            {
                MessageBox.Show("No image to copy. Please start the webcam or load an image.");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            processed.Save(saveFileDialog1.FileName);
        }

        private void colorInversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                processed = new Bitmap(pictureBox1.Image);
                Color pixel;

                for (int x = 0; x < processed.Width; x++)
                {
                    for (int y = 0; y < processed.Height; y++)
                    {
                        pixel = processed.GetPixel(x, y);
                        Color invert = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                        processed.SetPixel(x, y, invert);
                    }
                }
                pictureBox2.Image = processed;
            }
            else
            {
                MessageBox.Show("No image to invert colors. Please start the webcam or load an image.");
            }
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap currentFrame = new Bitmap(pictureBox1.Image);
                BasicDIP.Hist(currentFrame, ref processed);
                pictureBox2.Image = processed;
            }
            else
            {
                MessageBox.Show("No image available for histogram.");
            }
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                processed = new Bitmap(pictureBox1.Image);

                for (int x = 0; x < processed.Width; x++)
                {
                    for (int y = 0; y < processed.Height; y++)
                    {
                        Color originalColor = processed.GetPixel(x, y);

                        int tr = (int)(0.393 * originalColor.R + 0.769 * originalColor.G + 0.189 * originalColor.B);
                        int tg = (int)(0.349 * originalColor.R + 0.686 * originalColor.G + 0.168 * originalColor.B);
                        int tb = (int)(0.272 * originalColor.R + 0.534 * originalColor.G + 0.131 * originalColor.B);

                        int r = Math.Min(255, tr);
                        int g = Math.Min(255, tg);
                        int b = Math.Min(255, tb);

                        Color sepiaColor = Color.FromArgb(r, g, b);
                        processed.SetPixel(x, y, sepiaColor);
                    }
                }

                pictureBox2.Image = processed;
            }
            else
            {
                MessageBox.Show("No image to apply sepia effect. Please start the webcam or load an image.");
            }
        }

        private void subtractionBasicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 advancedForm = new Form2();
            advancedForm.Show();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            loaded = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = loaded;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            StartWebcam();
            var a = 3;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopWebcam();
            base.OnFormClosing(e);
        }
    }
}