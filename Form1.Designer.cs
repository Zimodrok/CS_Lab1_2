namespace CS_Lab1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DragNDropPanel = new Panel();
            DNDPanelDisclaimer = new Label();
            FrequencyDataGrid = new DataGridView();
            panelFixedRows = new Panel();
            labelFileSize = new Label();
            labelInfoQuantity = new Label();
            labelEntropy = new Label();
            Title = new Label();
            dataGridViewHistory = new DataGridView();
            DragNDropPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FrequencyDataGrid).BeginInit();
            panelFixedRows.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).BeginInit();
            SuspendLayout();
            // 
            // DragNDropPanel
            // 
            DragNDropPanel.AllowDrop = true;
            DragNDropPanel.BackColor = Color.Silver;
            DragNDropPanel.Controls.Add(DNDPanelDisclaimer);
            DragNDropPanel.Location = new Point(2, 714);
            DragNDropPanel.Name = "DragNDropPanel";
            DragNDropPanel.Size = new Size(800, 151);
            DragNDropPanel.TabIndex = 0;
            DragNDropPanel.DragDrop += DragNDropPanel_DragDrop;
            DragNDropPanel.DragEnter += DragNDropPanel_DragEnter;
            DragNDropPanel.DragOver += DragNDropPanel_DragOver;
            DragNDropPanel.DragLeave += DragNDropPanel_DragLeave;
            // 
            // DNDPanelDisclaimer
            // 
            DNDPanelDisclaimer.AutoSize = true;
            DNDPanelDisclaimer.ForeColor = SystemColors.ControlDarkDark;
            DNDPanelDisclaimer.Location = new Point(606, 101);
            DNDPanelDisclaimer.MaximumSize = new Size(200, 0);
            DNDPanelDisclaimer.Name = "DNDPanelDisclaimer";
            DNDPanelDisclaimer.Size = new Size(191, 45);
            DNDPanelDisclaimer.TabIndex = 1;
            DNDPanelDisclaimer.Text = "Drop your FILE THERE\r\nAccetable formats - .txt, .zip, .7z, .rar, .txt.gz, .txt.bz2, .txt.xz";
            // 
            // FrequencyDataGrid
            // 
            FrequencyDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FrequencyDataGrid.Location = new Point(2, 46);
            FrequencyDataGrid.Margin = new Padding(0);
            FrequencyDataGrid.Name = "FrequencyDataGrid";
            FrequencyDataGrid.RowTemplate.Height = 25;
            FrequencyDataGrid.Size = new Size(282, 551);
            FrequencyDataGrid.TabIndex = 2;
            // 
            // panelFixedRows
            // 
            panelFixedRows.BackColor = SystemColors.ControlDark;
            panelFixedRows.Controls.Add(labelFileSize);
            panelFixedRows.Controls.Add(labelInfoQuantity);
            panelFixedRows.Controls.Add(labelEntropy);
            panelFixedRows.Location = new Point(2, 600);
            panelFixedRows.Name = "panelFixedRows";
            panelFixedRows.Size = new Size(282, 109);
            panelFixedRows.TabIndex = 3;
            // 
            // labelFileSize
            // 
            labelFileSize.AutoSize = true;
            labelFileSize.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelFileSize.Location = new Point(10, 73);
            labelFileSize.Name = "labelFileSize";
            labelFileSize.Size = new Size(63, 19);
            labelFileSize.TabIndex = 2;
            labelFileSize.Text = "File Size: ";
            // 
            // labelInfoQuantity
            // 
            labelInfoQuantity.AutoSize = true;
            labelInfoQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelInfoQuantity.Location = new Point(10, 45);
            labelInfoQuantity.Name = "labelInfoQuantity";
            labelInfoQuantity.Size = new Size(70, 19);
            labelInfoQuantity.TabIndex = 1;
            labelInfoQuantity.Text = "Quantity: ";
            // 
            // labelEntropy
            // 
            labelEntropy.AutoSize = true;
            labelEntropy.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelEntropy.Location = new Point(10, 15);
            labelEntropy.Name = "labelEntropy";
            labelEntropy.Size = new Size(118, 19);
            labelEntropy.TabIndex = 0;
            labelEntropy.Text = "Average Entropy: ";
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            Title.Location = new Point(114, 9);
            Title.MinimumSize = new Size(500, 0);
            Title.Name = "Title";
            Title.Size = new Size(500, 37);
            Title.TabIndex = 4;
            Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridViewHistory
            // 
            dataGridViewHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHistory.Location = new Point(287, 46);
            dataGridViewHistory.Name = "dataGridViewHistory";
            dataGridViewHistory.RowTemplate.Height = 25;
            dataGridViewHistory.Size = new Size(512, 663);
            dataGridViewHistory.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 869);
            Controls.Add(dataGridViewHistory);
            Controls.Add(Title);
            Controls.Add(panelFixedRows);
            Controls.Add(FrequencyDataGrid);
            Controls.Add(DragNDropPanel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            DragNDropPanel.ResumeLayout(false);
            DragNDropPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)FrequencyDataGrid).EndInit();
            panelFixedRows.ResumeLayout(false);
            panelFixedRows.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel DragNDropPanel;
        private DataGridView FrequencyDataGrid;
        private Panel panelFixedRows;
        private Label labelInfoQuantity;
        private Label labelEntropy;
        private Label DNDPanelDisclaimer;
        private Label Title;
        private DataGridView dataGridViewHistory;
        private Label labelFileSize;
    }
}
