namespace FileSearchApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtStartDirectory = new System.Windows.Forms.TextBox();
            this.txtFilePattern = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.treeViewFiles = new System.Windows.Forms.TreeView();
            this.lblCurrentDirectory = new System.Windows.Forms.Label();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtStartDirectory
            // 
            this.txtStartDirectory.Location = new System.Drawing.Point(141, 26);
            this.txtStartDirectory.Name = "txtStartDirectory";
            this.txtStartDirectory.Size = new System.Drawing.Size(100, 20);
            this.txtStartDirectory.TabIndex = 0;
            // 
            // txtFilePattern
            // 
            this.txtFilePattern.Location = new System.Drawing.Point(141, 49);
            this.txtFilePattern.Name = "txtFilePattern";
            this.txtFilePattern.Size = new System.Drawing.Size(100, 20);
            this.txtFilePattern.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(141, 75);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // treeViewFiles
            // 
            this.treeViewFiles.Location = new System.Drawing.Point(254, 23);
            this.treeViewFiles.Name = "treeViewFiles";
            this.treeViewFiles.Size = new System.Drawing.Size(663, 429);
            this.treeViewFiles.TabIndex = 3;
            // 
            // lblCurrentDirectory
            // 
            this.lblCurrentDirectory.AutoSize = true;
            this.lblCurrentDirectory.Location = new System.Drawing.Point(56, 513);
            this.lblCurrentDirectory.Name = "lblCurrentDirectory";
            this.lblCurrentDirectory.Size = new System.Drawing.Size(126, 13);
            this.lblCurrentDirectory.TabIndex = 4;
            this.lblCurrentDirectory.Text = "Текущая директория: ?";
            this.lblCurrentDirectory.Click += new System.EventHandler(this.lblCurrentDirectory_Click);
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Location = new System.Drawing.Point(56, 549);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(106, 13);
            this.lblElapsedTime.TabIndex = 5;
            this.lblElapsedTime.Text = "Прошло времени: ?";
            // 
            // lblFileCount
            // 
            this.lblFileCount.AutoSize = true;
            this.lblFileCount.Location = new System.Drawing.Point(56, 479);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(104, 13);
            this.lblFileCount.TabIndex = 6;
            this.lblFileCount.Text = "Найдено файлов: ?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Стартовая директория";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Паттерн поиска";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 631);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFileCount);
            this.Controls.Add(this.lblElapsedTime);
            this.Controls.Add(this.lblCurrentDirectory);
            this.Controls.Add(this.treeViewFiles);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFilePattern);
            this.Controls.Add(this.txtStartDirectory);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStartDirectory;
        private System.Windows.Forms.TextBox txtFilePattern;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TreeView treeViewFiles;
        private System.Windows.Forms.Label lblCurrentDirectory;
        private System.Windows.Forms.Label lblElapsedTime;
        private System.Windows.Forms.Label lblFileCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

