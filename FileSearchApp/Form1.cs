using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearchApp
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancellationToken;
        private ConcurrentQueue<string> foundFiles = new ConcurrentQueue<string>();
        private long allFilesFound = 0;
        private string currentDirectory = "";
        private Stopwatch sw = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
            LoadSettings();
        }
        private void LoadSettings()
        {
            txtStartDirectory.Text = Properties.Settings.Default.StartDirectory;
            txtFilePattern.Text = Properties.Settings.Default.FilePattern;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.StartDirectory = txtStartDirectory.Text;
            Properties.Settings.Default.FilePattern = txtFilePattern.Text;
            Properties.Settings.Default.Save();
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (cancellationToken != null && !cancellationToken.IsCancellationRequested)
            {
                cancellationToken.Cancel();
                btnSearch.Text = "Продолжить";
                return;
            }

            if (string.IsNullOrEmpty(txtStartDirectory.Text) || string.IsNullOrEmpty(txtFilePattern.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            SaveSettings();

            cancellationToken = new CancellationTokenSource();
            btnSearch.Text = "Остановить";
            treeViewFiles.Nodes.Clear();
            foundFiles = new ConcurrentQueue<string>();
            allFilesFound = 0;
            sw.Restart();

            try
            {
                await Task.Run(() => SearchFiles(txtStartDirectory.Text, new Regex(txtFilePattern.Text), cancellationToken.Token));
            }
            catch (OperationCanceledException)
            {
                // Поиск был отменен
            }
            finally
            {
                btnSearch.Text = "Поиск";
                sw.Stop();
            }
        }
        private void SearchFiles(string directory, Regex pattern, CancellationToken ct)
        {
            try
            {
                foreach (string file in Directory.GetFiles(directory))
                {
                    ct.ThrowIfCancellationRequested();

                    if (pattern.IsMatch(Path.GetFileName(file)))
                    {
                        foundFiles.Enqueue(file);
                    }

                    allFilesFound++;
                    UpdateUI();
                }

                foreach (string subDir in Directory.GetDirectories(directory))
                {
                    ct.ThrowIfCancellationRequested();
                    currentDirectory = subDir;
                    SearchFiles(subDir, pattern, ct);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Пропускаем директории, к которым нет доступа
            }
        }
        private void UpdateUI()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateUI));
                return;
            }

            while (foundFiles.TryDequeue(out string file))
            {
                AddFileToTree(file);
            }

            lblCurrentDirectory.Text = $"Текущая директория: {currentDirectory}";
            lblFileCount.Text = $"Найдено файлов: {treeViewFiles.GetNodeCount(true)} из {allFilesFound}";
            lblElapsedTime.Text = $"Прошло времени: {sw.Elapsed:hh\\:mm\\:ss}";
        }
        private void AddFileToTree(string filePath)
        {
            string[] pathParts = filePath.Split(Path.DirectorySeparatorChar);
            TreeNode currentNode = null;

            for (int i = 0; i < pathParts.Length; i++)
            {
                string part = pathParts[i];
                if (string.IsNullOrEmpty(part)) continue;

                if (currentNode == null)
                {
                    var existingNode = treeViewFiles.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == part);
                    if (existingNode == null)
                    {
                        currentNode = treeViewFiles.Nodes.Add(part);
                    }
                    else
                    {
                        currentNode = existingNode;
                    }
                }
                else
                {
                    var existingNode = currentNode.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == part);
                    if (existingNode == null)
                    {
                        currentNode = currentNode.Nodes.Add(part);
                    }
                    else
                    {
                        currentNode = existingNode;
                    }
                }
            }
            currentNode.Tag = filePath;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblCurrentDirectory_Click(object sender, EventArgs e)
        {

        }
    }
}
