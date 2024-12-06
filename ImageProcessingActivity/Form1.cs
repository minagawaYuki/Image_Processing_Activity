using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ImageProcessingActivity
{
    public partial class Form1 : Form
    {
        Bitmap loaded, processed;
        Bitmap b;

        //AForge
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        int webcamMode;
        enum filter
        {
            None,
            Gray,
            Inversion,
            Contrast,
            Brightness,
            Rotate,
            MirrorHorizontal,
            MirrorVertical,
            Histogram,
            Scale,
            Binary,
            Sepia,
            Subtract,
            Smooth,
            GaussianBlur,
            Sharpen,
            MeanRemoval,
            EmbossLaplascian,
            EmbossHoriVerti,
            EmbossAllDirection,
            EmbossLossy,
            EmbossHorizontal,
            EmbossVertical
        }
        filter webcamFilter;

        public Form1()
        {
            InitializeComponent();
            webcamFilter = filter.None;
            webcamMode = 0;

            

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            Debug.WriteLine("DEVICES:  ");
            foreach (FilterInfo device in videoDevices)
                Debug.WriteLine($"Device [{device.Name}]");

            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No video devices found.");
            }
            this.FormClosing += new FormClosingEventHandler(Form_Closing);
        }

        // Event listener functions
        private void stretchPictureBox(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void turnOffTimer(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = frame; // Display the frame in pictureBox1
        }
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            turnOffCameraMode();
        }
        //-----------


        //AForge camera
        private void turnOnAForgeDevice(int deviceId)
        {
            turnOffCameraMode();
            if (videoDevices.Count >= deviceId + 1)
            {
                //first device
                var filterInfo = videoDevices[deviceId];
                Debug.WriteLine($"Connecting to [{filterInfo.Name}]...");
                videoSource = new VideoCaptureDevice(filterInfo.MonikerString);

                videoSource.NewFrame += new NewFrameEventHandler(Video_NewFrame);
                videoSource.Start();

                webcamMode = 2;
            }
            else
            {
                Debug.WriteLine("No video device found.");
            }
        }

        private void turnOffCameraMode()
        {
            if (webcamMode == 2)
            {
                if (videoSource != null && videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource.WaitForStop();
                }
            }

            pictureBox1.Image = null;
            webcamMode = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            b = getOneFrame();
            if (b == null)
                return;

            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            switch (webcamFilter)
            {
                case filter.Smooth:
                    BasicDIP.Smooth(b, ref processed);
                    break;
                case filter.GaussianBlur:
                    BasicDIP.GaussianBlur(b, ref processed);
                    break;
                case filter.Sharpen:
                    BasicDIP.Sharpen(b, ref processed);
                    break;
                case filter.MeanRemoval:
                    BasicDIP.MeanRemoval(b, ref processed);
                    break;
                case filter.EmbossLaplascian:
                    BasicDIP.EmbossLaplascian(b, ref processed);
                    break;
                case filter.EmbossHoriVerti:
                    BasicDIP.EmbossHoriVerti(b, ref processed);
                    break;
                case filter.EmbossAllDirection:
                    BasicDIP.EmbossAllDirections(b, ref processed);
                    break;
                case filter.EmbossLossy:
                    BasicDIP.EmbossLossy(b, ref processed);
                    break;
                case filter.EmbossHorizontal:
                    BasicDIP.EmbossHorizontal(b, ref processed);
                    break;
                case filter.EmbossVertical:
                    BasicDIP.EmbossVertical(b, ref processed);
                    break;
                default:
                    break;
            }
            pictureBox2.Image = processed;
        }

        private Bitmap getOneFrame()
        {
            if (webcamMode == 2)
                return getOneFrameAForge();
            return null;
        }

        private Bitmap getOneFrameAForge()
        {
            if (pictureBox1.Image == null)
            {
                return null;
            }
            return new Bitmap(pictureBox1.Image);
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

        //protected override void OnShown(EventArgs e)
        //{
        //    base.OnShown(e);
        //    turnOnAForgeDevice(0);
        //    var a = 3;
        //}

        private void oNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turnOnAForgeDevice(0);
        }

        private void oFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turnOffCameraMode();
        }

        private void smoothingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.Smooth(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void gausianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.GaussianBlur(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.Sharpen(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void meanRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.MeanRemoval(loaded, ref processed);
            pictureBox2.Image = processed;
        }
        private void allDirectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.EmbossAllDirections(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void laplascianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.EmbossLaplascian(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void horizontalVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.EmbossHoriVerti(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void lossyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.EmbossLossy(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.EmbossHorizontal(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            turnOffCameraMode();
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.EmbossVertical(loaded, ref processed);
            pictureBox2.Image = processed;
        }



    }

}