namespace ImageProcessingActivity
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnGrayscale = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnColorInversion = new System.Windows.Forms.Button();
            this.btnSepia = new System.Windows.Forms.Button();
            this.btnHistogram = new System.Windows.Forms.Button();
            this.btnSmoothing = new System.Windows.Forms.Button();
            this.btnGaussianBlur = new System.Windows.Forms.Button();
            this.btnSharpen = new System.Windows.Forms.Button();
            this.btnMeanRemoval = new System.Windows.Forms.Button();
            this.btnEmboss = new System.Windows.Forms.Button();
            this.laplascianToolStripMenuItem = new System.Windows.Forms.Button();
            this.horizontalVerticalToolStripMenuItem = new System.Windows.Forms.Button();
            this.allToolStripMenuItem = new System.Windows.Forms.Button();
            this.lossyToolStripMenuItem = new System.Windows.Forms.Button();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.Button();
            this.verticalToolStripMenuItem = new System.Windows.Forms.Button();
            this.btnCameraOn = new System.Windows.Forms.Button();
            this.btnCameraOff = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();

            // pictureBox1 (Original Image)
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Size = new System.Drawing.Size(320, 240);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // pictureBox2 (Processed Image)
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(348, 12);
            this.pictureBox2.Size = new System.Drawing.Size(320, 240);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // Buttons Layout
            int buttonHeight = 30;
            int buttonWidth = 150;
            int buttonSpacing = 10;  // increased spacing for clarity
            int baseX = 12;
            int baseY = 270;

            // Load Image Button
            this.btnLoadImage.Location = new System.Drawing.Point(baseX, baseY);
            this.btnLoadImage.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.Click += new System.EventHandler(this.openToolStripMenuItem_Click);

            // Save Image Button
            this.btnSaveImage.Location = new System.Drawing.Point(baseX + buttonWidth + buttonSpacing, baseY);
            this.btnSaveImage.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);

            baseY += buttonHeight + buttonSpacing; // Move to next row

            // Copy Button
            this.btnCopy.Location = new System.Drawing.Point(baseX, baseY);
            this.btnCopy.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.basicCopyToolStripMenuItem_Click);

            // Grayscale Button
            this.btnGrayscale.Location = new System.Drawing.Point(baseX + buttonWidth + buttonSpacing, baseY);
            this.btnGrayscale.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnGrayscale.Text = "Grayscale";
            this.btnGrayscale.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);

            baseY += buttonHeight + buttonSpacing;

            // Color Inversion Button
            this.btnColorInversion.Location = new System.Drawing.Point(baseX, baseY);
            this.btnColorInversion.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnColorInversion.Text = "Color Inversion";
            this.btnColorInversion.Click += new System.EventHandler(this.colorInversionToolStripMenuItem_Click);

            // Sepia Button
            this.btnSepia.Location = new System.Drawing.Point(baseX + buttonWidth + buttonSpacing, baseY);
            this.btnSepia.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnSepia.Text = "Sepia";
            this.btnSepia.Click += new System.EventHandler(this.sepiaToolStripMenuItem_Click);

            baseY += buttonHeight + buttonSpacing;

            // Histogram Button
            this.btnHistogram.Location = new System.Drawing.Point(baseX, baseY);
            this.btnHistogram.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnHistogram.Text = "Histogram";
            this.btnHistogram.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);

            // Smoothing Button
            this.btnSmoothing.Location = new System.Drawing.Point(baseX + buttonWidth + buttonSpacing, baseY);
            this.btnSmoothing.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnSmoothing.Text = "Smoothing";
            this.btnSmoothing.Click += new System.EventHandler(this.smoothingToolStripMenuItem_Click);

            baseY += buttonHeight + buttonSpacing;

            // Gaussian Blur Button
            this.btnGaussianBlur.Location = new System.Drawing.Point(baseX, baseY);
            this.btnGaussianBlur.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnGaussianBlur.Text = "Gaussian Blur";
            this.btnGaussianBlur.Click += new System.EventHandler(this.gausianBlurToolStripMenuItem_Click);

            // Sharpen Button
            this.btnSharpen.Location = new System.Drawing.Point(baseX + buttonWidth + buttonSpacing, baseY);
            this.btnSharpen.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnSharpen.Text = "Sharpen";
            this.btnSharpen.Click += new System.EventHandler(this.sharpenToolStripMenuItem_Click);

            baseY += buttonHeight + buttonSpacing;

            // Mean Removal Button
            this.btnMeanRemoval.Location = new System.Drawing.Point(baseX, baseY);
            this.btnMeanRemoval.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnMeanRemoval.Text = "Mean Removal";
            this.btnMeanRemoval.Click += new System.EventHandler(this.meanRemovalToolStripMenuItem_Click);

            // Emboss Button
            this.btnEmboss.Location = new System.Drawing.Point(baseX + buttonWidth + buttonSpacing, baseY);
            this.btnEmboss.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnEmboss.Text = "Emboss";
            this.btnEmboss.Click += new System.EventHandler(this.allDirectionToolStripMenuItem_Click);

            baseY += buttonHeight + buttonSpacing;

            // Laplascian Button
            this.laplascianToolStripMenuItem.Location = new System.Drawing.Point(baseX, baseY);
            this.laplascianToolStripMenuItem.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.laplascianToolStripMenuItem.Text = "Laplascian";
            this.laplascianToolStripMenuItem.Click += new System.EventHandler(this.laplascianToolStripMenuItem_Click);

            // Horizontal & Vertical Button
            this.horizontalVerticalToolStripMenuItem.Location = new System.Drawing.Point(baseX + buttonWidth + buttonSpacing, baseY);
            this.horizontalVerticalToolStripMenuItem.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.horizontalVerticalToolStripMenuItem.Text = "Horizontal & Vertical";
            this.horizontalVerticalToolStripMenuItem.Click += new System.EventHandler(this.horizontalVerticalToolStripMenuItem_Click);

            baseY += buttonHeight + buttonSpacing;

            // All Directions Button
            this.allToolStripMenuItem.Location = new System.Drawing.Point(baseX, baseY);
            this.allToolStripMenuItem.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.allToolStripMenuItem.Text = "All Directions";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allDirectionToolStripMenuItem_Click);

            // Lossy Button
            this.lossyToolStripMenuItem.Location = new System.Drawing.Point(baseX + buttonWidth + buttonSpacing, baseY);
            this.lossyToolStripMenuItem.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.lossyToolStripMenuItem.Text = "Lossy";
            this.lossyToolStripMenuItem.Click += new System.EventHandler(this.lossyToolStripMenuItem_Click);

            baseY += buttonHeight + buttonSpacing;

            // Horizontal Button
            this.horizontalToolStripMenuItem.Location = new System.Drawing.Point(baseX, baseY);
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.horizontalToolStripMenuItem.Text = "Horizontal";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);

            // Vertical Button
            this.verticalToolStripMenuItem.Location = new System.Drawing.Point(baseX + buttonWidth + buttonSpacing, baseY);
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.verticalToolStripMenuItem.Text = "Vertical";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);

            baseY += buttonHeight + buttonSpacing;

            // Camera Buttons
            this.btnCameraOn.Location = new System.Drawing.Point(baseX, baseY);
            this.btnCameraOn.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnCameraOn.Text = "Camera ON";
            this.btnCameraOn.Click += new System.EventHandler(this.oNToolStripMenuItem_Click);

            // Camera Off Button
            this.btnCameraOff.Location = new System.Drawing.Point(baseX + buttonWidth + buttonSpacing, baseY);
            this.btnCameraOff.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnCameraOff.Text = "Camera OFF";
            this.btnCameraOff.Click += new System.EventHandler(this.oFFToolStripMenuItem_Click);

            // Form
            int formHeight = baseY + buttonHeight + buttonSpacing; // Ensure enough height for all buttons
            int formWidth = 680; // Adjust form width to fit all buttons horizontally (or more as needed)

            // Set the form size
            this.ClientSize = new System.Drawing.Size(formWidth, formHeight);

            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnGrayscale);
            this.Controls.Add(this.btnColorInversion);
            this.Controls.Add(this.btnSepia);
            this.Controls.Add(this.btnHistogram);
            this.Controls.Add(this.btnSmoothing);
            this.Controls.Add(this.btnGaussianBlur);
            this.Controls.Add(this.btnSharpen);
            this.Controls.Add(this.btnMeanRemoval);
            this.Controls.Add(this.btnEmboss);
            this.Controls.Add(this.laplascianToolStripMenuItem);
            this.Controls.Add(this.horizontalVerticalToolStripMenuItem);
            this.Controls.Add(this.allToolStripMenuItem);
            this.Controls.Add(this.lossyToolStripMenuItem);
            this.Controls.Add(this.horizontalToolStripMenuItem);
            this.Controls.Add(this.verticalToolStripMenuItem);
            this.Controls.Add(this.btnCameraOn);
            this.Controls.Add(this.btnCameraOff);
            this.ResumeLayout(false);
        }


        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnGrayscale;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Button btnColorInversion;
        private System.Windows.Forms.Button btnSepia;
        private System.Windows.Forms.Button btnHistogram;
        private System.Windows.Forms.Button btnSmoothing;
        private System.Windows.Forms.Button btnGaussianBlur;
        private System.Windows.Forms.Button btnSharpen;
        private System.Windows.Forms.Button btnMeanRemoval;
        private System.Windows.Forms.Button btnEmboss;
        private System.Windows.Forms.Button laplascianToolStripMenuItem;
        private System.Windows.Forms.Button horizontalVerticalToolStripMenuItem;
        private System.Windows.Forms.Button allToolStripMenuItem;
        private System.Windows.Forms.Button lossyToolStripMenuItem;
        private System.Windows.Forms.Button horizontalToolStripMenuItem;
        private System.Windows.Forms.Button verticalToolStripMenuItem;
        private System.Windows.Forms.Button btnCameraOn;
        private System.Windows.Forms.Button btnCameraOff;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer timer1;
    }
}
