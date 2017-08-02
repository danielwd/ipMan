﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ipMan
{

    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        public void LoadAdapters()
        {
            var obj = new Adapters();
            var values = obj.net_adapters();
            listBox1.DataSource = values;
        }

        private void btnAdapterRefresh_Click(object sender, EventArgs e)
        {
            LoadAdapters();
        }
    }
    public class Adapters
    {
        public System.Collections.Generic.List<String> net_adapters()
        {
            List<String> values = new List<String>();
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                values.Add(nic.Name +"-"+ nic.Description + "-" + nic.OperationalStatus+"-"+ nic.NetworkInterfaceType);
            }
            return values;
        }
    }
}
