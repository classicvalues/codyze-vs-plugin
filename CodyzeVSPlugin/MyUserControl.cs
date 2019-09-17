﻿using Microsoft.VisualStudio.Shell;
using System;
using System.Windows.Forms;

namespace CodyzeVSPlugin
{
    public partial class MyUserControl : UserControl
    {
        public class OptionPageCustom : DialogPage
        {
            public string OptionString { get; set; }

            protected override IWin32Window Window
            {
                get
                {
                    MyUserControl page = new MyUserControl
                    {
                        optionsPage = this
                    };
                    page.Initialize();
                    return page;
                }
            }
        }

        public MyUserControl()
        {
            InitializeComponent();
        }

        internal OptionPageCustom optionsPage;

        public void Initialize()
        {
            textBox1.Text = CustomSettingsManager.ReadPathSetting();
            textBox2.Text = CustomSettingsManager.ReadPathToMarkFilesSetting();
            textBox3.Text = CustomSettingsManager.ReadCommandLineArgumentsSetting();
        }

        private void ShowFolderBrowser()
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderBrowser.SelectedPath;
                    textBox1.Text = folderPath;
                    CustomSettingsManager.AddUpdatePathSettings(folderPath);
                }
            }
        }

        private void TextBox1_Leave_1(object sender, EventArgs e)
        {
            optionsPage.OptionString = textBox1.Text;
        }

        private void TextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            ShowFolderBrowser();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ShowFolderBrowser();
        }

        private void folderBrowserDialog3_HelpRequest(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog2_HelpRequest(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MarkFilesDialog();
        }

        private void MarkFilesDialog()
        {
            string path = SettingsHelper.ShowFolderBrowserForMarkFilesLocation(textBox2.Text);
            if (!path.Equals(textBox2.Text))
            {
                textBox2.Text = path;
                CustomSettingsManager.AddUpdatePathToMarkFilesSettings(path);
                textBox3.Text = CustomSettingsManager.ReadCommandLineArgumentsSetting();
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            MarkFilesDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void MyUserControl_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = SettingsHelper.CheckCommandLineArguments(textBox3.Text, textBox2.Text);
            CustomSettingsManager.AddUpdateCommandLineArgumentsSettings(textBox3.Text);
        }
    }
}
