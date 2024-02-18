using System.Diagnostics;

namespace CS_Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DragNDropPanel.AllowDrop = true;
            FrequencyDataGrid.Columns.Add("Character", "Character");
            FrequencyDataGrid.Columns.Add("Frequency", "Frequency");

            dataGridViewHistory.Columns.Add("FileName", "File Name");
            dataGridViewHistory.Columns.Add("InfoQuantity", "Quantity (byte)");
            dataGridViewHistory.Columns.Add("FileSize", "File Size (KB)");
        }

        private bool isDragAcceptable = false;

        private void DragNDropPanel_DragDrop(object sender, DragEventArgs e)
        {
            DragNDropPanel.BackColor = Color.Silver;
            isDragAcceptable = false;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string filePath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                string fileName = Path.GetFileName(filePath);
                Title.Text = $"{fileName}";
                if (!string.IsNullOrEmpty(filePath))
                {
                    Debug.WriteLine($"File path updated in Form1.cs: {filePath}");
                    string textFromFile = ReadTextFromFile(filePath);
                    Dictionary<char, double> characterFrequencies = CalculateCharacterFrequencies(textFromFile);
                    double averageEntropy = CalculateAverageEntropy(characterFrequencies);
                    double informationQuantity = InformationQuantity(averageEntropy, textFromFile.Length);
                    long fileSizeInBytes = new FileInfo(filePath).Length;
                    DisplayResultsInDataGridView(fileName, characterFrequencies, averageEntropy, informationQuantity, fileSizeInBytes);
                }

            }
            DragNDropPanel.BackColor = SystemColors.Control;
        }

        private async void DragNDropPanel_DragOver(object sender, DragEventArgs e)
        {
            await Task.Delay(200);
            if (!isDragAcceptable)
            {
                DragNDropPanel.BackColor = Color.Silver;
            }
        }
        private void DragNDropPanel_DragLeave(object sender, EventArgs e)
        {
            DragNDropPanel.BackColor = Color.Silver;
            isDragAcceptable = false;
        }


        private void DragNDropPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Any(IsAcceptableFileType))
                {
                    DragNDropPanel.BackColor = Color.LightGreen;
                    e.Effect = DragDropEffects.Copy;
                    isDragAcceptable = true;
                }
                else
                {
                    DragNDropPanel.BackColor = Color.IndianRed;
                    e.Effect = DragDropEffects.None;
                    isDragAcceptable = false;
                }
            }
        }

        private string ReadTextFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        private bool IsAcceptableFileType(string filePath)
        {
            string extension = Path.GetExtension(filePath)?.ToLower();
            string[] acceptableExtensions = { ".txt", ".zip", ".rar", ".7z", ".gz", ".bz2", ".xz" };
            return acceptableExtensions.Contains(extension);
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
                //For each KeyValuePair charFreq for key = counter/ total 
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
        private string FileSizeToKB(long fileSizeInBytes)
        {
            double sizeInKB = fileSizeInBytes / 1024.0;
            return $"{sizeInKB:0.##}";
        }
        public void DisplayResultsInDataGridView(string fileName, Dictionary<char, double> characterFrequencies, double averageEntropy, double informationQuantity, long fileSizeInBytes)
        {
            FrequencyDataGrid.Rows.Clear();
            foreach (var kvp in characterFrequencies)
            {
                FrequencyDataGrid.Rows.Add(kvp.Key, kvp.Value.ToString("P"));
            }
            labelEntropy.Text = $"Average Entropy: {averageEntropy:F2}";
            string infoQuantityText;
            string Quanity;
            if (informationQuantity < 32)
            {
                Quanity = informationQuantity.ToString("F4"); ;
                infoQuantityText = $"Quantity: {Quanity} bits";
            }
            else
            {
                Quanity = informationQuantity.ToString();
                infoQuantityText = $"Quantity: {Math.Round(informationQuantity, 1)} bits";
            }
            labelInfoQuantity.Text = infoQuantityText;
            labelFileSize.Text = $"File Size: {FileSizeToKB(fileSizeInBytes)} KB";
            labelEntropy.Text = $"Average Entropy: {averageEntropy:F2}";
            labelInfoQuantity.Text = $"Information Quantity: {informationQuantity} bits";

            dataGridViewHistory.Rows.Add(fileName, (double.Parse(Quanity) / 8), FileSizeToKB(fileSizeInBytes));
        }
    }
}
