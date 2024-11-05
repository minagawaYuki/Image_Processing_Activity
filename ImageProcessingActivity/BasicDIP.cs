using System;
using System.Drawing;

namespace ImageProcessingActivity
{
    static class BasicDIP
    {
        public static void Hist(Bitmap inputBitmap, ref Bitmap histogramBitmap)
        {
            // Create a new grayscale bitmap
            Bitmap grayBitmap = new Bitmap(inputBitmap.Width, inputBitmap.Height);
            Color sample;
            byte graydata;

            // Grayscale Conversion
            for (int x = 0; x < inputBitmap.Width; x++)
            {
                for (int y = 0; y < inputBitmap.Height; y++)
                {
                    sample = inputBitmap.GetPixel(x, y);
                    graydata = (byte)((sample.R + sample.G + sample.B) / 3);
                    grayBitmap.SetPixel(x, y, Color.FromArgb(graydata, graydata, graydata));
                }
            }

            int[] histdata = new int[256];

            // Histogram Calculation
            for (int x = 0; x < grayBitmap.Width; x++)
            {
                for (int y = 0; y < grayBitmap.Height; y++)
                {
                    sample = grayBitmap.GetPixel(x, y);
                    histdata[sample.R]++; // Use R since the image is now grayscale
                }
            }

            // Initialize the histogram bitmap
            histogramBitmap = new Bitmap(256, 800);
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 800; y++)
                {
                    histogramBitmap.SetPixel(x, y, Color.White);
                }
            }

            // Plot histogram data
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < Math.Min(histdata[x] / 5, histogramBitmap.Height - 1); y++)
                {
                    histogramBitmap.SetPixel(x, (histogramBitmap.Height - 1) - y, Color.Black);
                }
            }
        }
    }
}