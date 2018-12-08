﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

using Newtonsoft.Json;

namespace vk_bot
{
    public partial class CommentForm : Form
    {
        public string access_token;
        public string groupId;
        public string postId;

        public CommentForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //long epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            //long epoch = DateTime.Now.ToFileTimeUtc(); 
            //DateTime td = new DateTime(epoch);
            
            string request = "https://api.vk.com/method/wall.createComment?owner_id=-" + groupId + "&post_id=" + postId + "&message=" + listBox1.Text + "&access_token=" + access_token + "&v=5.87";
            WebClient client = new WebClient();
            string answer = Encoding.UTF8.GetString(client.DownloadData(request));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItems[0]);
        }

        private void CommentForm_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }
    }
}
