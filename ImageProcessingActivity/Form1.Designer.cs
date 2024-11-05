using System.Windows.Forms;
using System.Drawing;

namespace ImageProcessingActivity
{
    partial class Form1
    {
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGrayscale;
        private System.Windows.Forms.Button btnBasicCopy;
        private System.Windows.Forms.Button btnColorInversion;
        private System.Windows.Forms.Button btnHistogram;
        private System.Windows.Forms.Button btnSepia;
        private System.Windows.Forms.Button btnSubtraction;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelOriginal;
        private System.Windows.Forms.Label labelProcessed;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private Button btnStartWebcam;
        private Button btnStopWebcam;

        private void InitializeComponent()
        {
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGrayscale = new System.Windows.Forms.Button();
            this.btnBasicCopy = new System.Windows.Forms.Button();
            this.btnColorInversion = new System.Windows.Forms.Button();
            this.btnHistogram = new System.Windows.Forms.Button();
            this.btnSepia = new System.Windows.Forms.Button();
            this.btnSubtraction = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelOriginal = new System.Windows.Forms.Label();
            this.labelProcessed = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();

            // Form Settings
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Processing Tool";

            // Open Button
            this.btnOpen.Text = "Open";
            this.btnOpen.Location = new System.Drawing.Point(40, 40);
            this.btnOpen.Size = new System.Drawing.Size(100, 30);
            this.btnOpen.Click += new System.EventHandler(this.openToolStripMenuItem_Click);

            // Save Button
            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(150, 40);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);

            // Start Webcam Button
            btnStartWebcam = new Button
            {
                Text = "Start Webcam",
                Location = new Point(40, 80),
                Size = new Size(100, 30)
            };
            btnStartWebcam.Click += (s, e) => StartWebcam();

            // Stop Webcam Button
            btnStopWebcam = new Button
            {
                Text = "Stop Webcam",
                Location = new Point(150, 80),
                Size = new Size(100, 30)
            };
            btnStopWebcam.Click += (s, e) => StopWebcam();

            // Grayscale Button
            this.btnGrayscale.Text = "Grayscale";
            this.btnGrayscale.Location = new System.Drawing.Point(40, 650);
            this.btnGrayscale.Size = new System.Drawing.Size(100, 30);
            this.btnGrayscale.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);

            // Basic Copy Button
            this.btnBasicCopy.Text = "Basic Copy";
            this.btnBasicCopy.Location = new System.Drawing.Point(150, 650);
            this.btnBasicCopy.Size = new System.Drawing.Size(100, 30);
            this.btnBasicCopy.Click += new System.EventHandler(this.basicCopyToolStripMenuItem_Click);

            // Color Inversion Button
            this.btnColorInversion.Text = "Color Inversion";
            this.btnColorInversion.Location = new System.Drawing.Point(260, 650);
            this.btnColorInversion.Size = new System.Drawing.Size(100, 30);
            this.btnColorInversion.Click += new System.EventHandler(this.colorInversionToolStripMenuItem_Click);

            // Histogram Button
            this.btnHistogram.Text = "Histogram";
            this.btnHistogram.Location = new System.Drawing.Point(370, 650);
            this.btnHistogram.Size = new System.Drawing.Size(100, 30);
            this.btnHistogram.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);

            // Sepia Button
            this.btnSepia.Text = "Sepia";
            this.btnSepia.Location = new System.Drawing.Point(480, 650);
            this.btnSepia.Size = new System.Drawing.Size(100, 30);
            this.btnSepia.Click += new System.EventHandler(this.sepiaToolStripMenuItem_Click);

            // Subtraction Button
            this.btnSubtraction.Text = "Subtraction";
            this.btnSubtraction.Location = new System.Drawing.Point(590, 650);
            this.btnSubtraction.Size = new System.Drawing.Size(100, 30);
            this.btnSubtraction.Click += new System.EventHandler(this.subtractionBasicsToolStripMenuItem_Click);

            // PictureBoxes with labels
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(40, 120);
            this.pictureBox1.Size = new System.Drawing.Size(550, 500);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(610, 120);
            this.pictureBox2.Size = new System.Drawing.Size(550, 500);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // Labels
            this.labelOriginal.AutoSize = true;
            this.labelOriginal.Location = new System.Drawing.Point(40, 100);
            this.labelOriginal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelOriginal.Text = "Original Image";

            this.labelProcessed.AutoSize = true;
            this.labelProcessed.Location = new System.Drawing.Point(610, 100);
            this.labelProcessed.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelProcessed.Text = "Processed Image";

            // StatusStrip
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripStatusLabel1
            });
            this.statusStrip1.Location = new System.Drawing.Point(0, 720);
            this.statusStrip1.Size = new System.Drawing.Size(1200, 22);

            // ToolStripStatusLabel
            this.toolStripStatusLabel1.Text = "Ready";

            // Adding Controls to Form
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGrayscale);
            this.Controls.Add(this.btnBasicCopy);
            this.Controls.Add(this.btnColorInversion);
            this.Controls.Add(this.btnHistogram);
            this.Controls.Add(this.btnSepia);
            this.Controls.Add(this.btnSubtraction);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelOriginal);
            this.Controls.Add(this.labelProcessed);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(btnStartWebcam);
            this.Controls.Add(btnStopWebcam);
        }
    }
}