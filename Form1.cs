using System.IO;
using System.Text;

namespace CS_Lab1_2
{
    public partial class Form1 : Form
    {
        string FilePath;
        public Form1()
        {
            InitializeComponent();
            panel1.AllowDrop = true;
            panel1.DragDrop += Panel1_DragDrop;
            panel1.DragEnter += Panel1_DragEnter;
        }
        private void Panel1_DragDrop(object sender, DragEventArgs e)
        {
            panel1.BackColor = Color.Silver;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    FilePath = files[0];
                }
            }
            ProcessText();
        }
        private void Panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Any(IsAcceptableFileType))
                {
                    panel1.BackColor = Color.LightGreen;
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    panel1.BackColor = Color.IndianRed;
                    e.Effect = DragDropEffects.None;
                }
            }
        }
        private bool IsAcceptableFileType(string filePath)
        {
            string extension = Path.GetExtension(filePath)?.ToLower();
            string[] acceptableExtensions = { ".txt", ".zip", ".rar", ".7z", ".gz", ".bz2", ".xz" };
            return acceptableExtensions.Contains(extension);
        }

        private void ProcessText()
        {
            string filePath = FilePath;
            string fileName = Path.GetFileName(filePath);
            Title.Text = fileName;
            if (File.Exists(filePath))
            {
                try
                {
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    string base64String = EncodeToBase64(fileBytes);
                    tbBase64Output.Text = base64String.PadLeft(base64String.Length + 5);
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                    string fileExtension = Path.GetExtension(filePath);
                    string directory = Path.GetDirectoryName(filePath);
                   

                    string textFromFile = ReadTextFromFile(filePath);
                    Dictionary<char, double> characterFrequencies = CalculateCharacterFrequencies(base64String);
                    double averageEntropy = CalculateAverageEntropy(characterFrequencies);
                    double informationQuantity = InformationQuantity(averageEntropy, base64String.Length);
                    LabelQuanity.Text = $"Quantity: {Math.Round(informationQuantity, 1)}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid file path. Please select a valid file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string ReadTextFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }
        private Dictionary<char, double> CalculateCharacterFrequencies(string text)
        {
            Dictionary<char, int> characterCounter = new Dictionary<char, int>();
            foreach (char ch in text)
            {
                if (char.IsLetter(ch))
                {
                    if (characterCounter.ContainsKey(ch))
                    {
                        characterCounter[ch]++;
                    }
                    else
                    {
                        characterCounter[ch] = 1;
                    }
                }
            }
            int totalCharacters = characterCounter.Values.Sum();
            Dictionary<char, double> characterFrequencies = new Dictionary<char, double>();

            foreach (var kvp in characterCounter)
            {
                characterFrequencies[kvp.Key] = (double)kvp.Value / totalCharacters;
            }

            return characterFrequencies;
        }

        private double CalculateAverageEntropy(Dictionary<char, double> characterFrequencies)
        {
            double entropy = 0;

            foreach (var frequency in characterFrequencies.Values)
            {
                entropy -= frequency * Math.Log2(frequency);
            }

            return entropy;
        }

        private double InformationQuantity(double entropy, int fileSizeInBytes)
        {
            const double bitsPerByte = 8.0;
            return entropy * fileSizeInBytes * bitsPerByte;
        }
        private string EncodeToBase64(byte[] bytes)
        {
            StringBuilder base64StringBuilder = new StringBuilder();
            const int LineLength = 76;

            for (int i = 0; i < bytes.Length; i += 3)
            {
                int chunkSize = Math.Min(3, bytes.Length - i);

                byte[] chunk = new byte[3];
                Array.Copy(bytes, i, chunk, 0, chunkSize);

                string base64Chunk = ConvertChunkToBase64(chunk, chunkSize);
                    base64StringBuilder.Append(' ');
                

                base64StringBuilder.Append(base64Chunk);

                if (base64StringBuilder.Length % LineLength == 0)
                {
                    base64StringBuilder.Append(Environment.NewLine);
                }
            }

            return base64StringBuilder.ToString();
        }



        private string ConvertChunkToBase64(byte[] chunk, int chunkSize)
        {
            int[] indices = new int[4];
            indices[0] = (chunk[0] & 0xFC) >> 2;
            indices[1] = ((chunk[0] & 0x03) << 4) | ((chunk[1] & 0xF0) >> 4);
            indices[2] = ((chunk[1] & 0x0F) << 2) | ((chunk[2] & 0xC0) >> 6);
            indices[3] = chunk[2] & 0x3F;

            char[] base64Chars = new char[4];
            for (int i = 0; i < 4; i++)
            {
                if (i <= chunkSize)
                {
                    base64Chars[i] = EncodeBase64Index(indices[i]);
                }
                else
                {
                    base64Chars[i] = '=';
                }
            }

            return new string(base64Chars);
        }

        private char EncodeBase64Index(int index)
        {
            if (index < 26)
                return (char)('A' + index);
            if (index < 52)
                return (char)('a' + (index - 26));
            if (index < 62)
                return (char)('0' + (index - 52));
            if (index == 62)
                return '+';
            return '/';
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
