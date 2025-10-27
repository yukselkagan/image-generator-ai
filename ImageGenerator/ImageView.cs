using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageGenerator
{
    public partial class ImageView : Form
    {
        public ImageView()
        {
            InitializeComponent();
        }

        public void showImage(Image image)
        {
            pictureBox1.Image = image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image to save!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Save Image";
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.FileName = $"Image_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var ext = Path.GetExtension(saveFileDialog.FileName).ToLower();
                        System.Drawing.Imaging.ImageFormat format = ext switch
                        {
                            ".jpg" => System.Drawing.Imaging.ImageFormat.Jpeg,
                            ".bmp" => System.Drawing.Imaging.ImageFormat.Bmp,
                            _ => System.Drawing.Imaging.ImageFormat.Png
                        };

                        pictureBox1.Image.Save(saveFileDialog.FileName, format);

                        MessageBox.Show($"Image saved to {saveFileDialog.FileName}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        
    }
}
