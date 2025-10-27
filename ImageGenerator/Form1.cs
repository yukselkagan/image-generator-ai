using ImageGenerator.Services;
using System.Diagnostics;

namespace ImageGenerator
{
    public partial class Form1 : Form
    {
        private PictureBox[] pictureBoxes = [];
        public Form1()
        {
            InitializeComponent();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBoxes = [pictureBox1, pictureBox2, pictureBox3, pictureBox4];
        }     

        private async void button1_Click(object sender, EventArgs e)
        {
            string input = promptInput.Text;
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Prompt is empty", "Notification",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowLoading();
            using var pythonBridge = new PythonBridge();
            try
            {
                string functionName = GetSelectedGenerationMode();
                int imageCount = GetSelectedImageCount();
                List<string> imagePathList = await Task.Run(() => pythonBridge.CallFunction(
                    functionName,
                    input,
                    imageCount.ToString()
                ));
                CompleteLoading();

                for (int i=0; i < imagePathList.Count; i++)
                {
                    string imagePath = Path.Combine(AppContext.BaseDirectory, @"artificial-intelligence", imagePathList[i]);
                    using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        PictureBox targetPictureBox = pictureBoxes[i];                       
                        if (targetPictureBox.Image != null) { targetPictureBox.Image.Dispose(); }
                        targetPictureBox.Image = Image.FromStream(fs);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
                StopLoading(ex.Message);
            }
        }

        private void openImageView(Image image)
        {
            ImageView viewer = new ImageView();
            viewer.showImage(image);
            viewer.ShowDialog();
            image.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Image imageCopy = (Image)pictureBox1.Image.Clone();
            openImageView(imageCopy);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Image imageCopy = (Image)pictureBox2.Image.Clone();
            openImageView(imageCopy);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Image imageCopy = (Image)pictureBox3.Image.Clone();
            openImageView(imageCopy);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Image imageCopy = (Image)pictureBox4.Image.Clone();
            openImageView(imageCopy);
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ShowLoading()
        {
            statusLabel.Text = "Status: Generating Image";
            progressBar1.Visible = true;
        }

        private void CompleteLoading()
        {
            statusLabel.Text = "Status: Completed";
            progressBar1.Visible = false;
        }

        private void StopLoading(string message)
        {
            statusLabel.Text = "Status: Error. " + message;
            progressBar1.Visible = false;
        }

        private int GetSelectedImageCount()
        {
            if (radioButton4Image.Checked)
            {
                return 4;
            }
            return 1;
        }

        private string GetSelectedGenerationMode()
        {
            if (radioButtonDetailed.Checked)
            {
                return "generate_image_high_detail";
            }
            return "generate_image";
        }


    }
}
