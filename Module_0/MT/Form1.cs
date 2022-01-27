using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //string data = DoeIets();
            //UpdateLabel(data);
            //var ctx = SynchronizationContext.Current;
            //Task.Run(() =>
            //{
            //    var data = DoeIets();
            //    return data;
            //}).ContinueWith(pt =>
            //{
            //    ctx.Post(UpdateLabel, pt.Result);
            //    //UpdateLabel(pt.Result);
            //});
            //Task<string> t = DeTaakAsync();
            //t.ConfigureAwait(false);
            var data = await DoeIetsAsync().ConfigureAwait(true);
            UpdateLabel(data);
        }

        private async Task<string> DeTaakAsync()
        {  
            var data = await DoeIetsAsync();
            return data;
        }

        private void UpdateLabel(object data)
        {
            label1.Text = data.ToString();
        }

        private string DoeIets()
        {
            Task.Delay(5000).Wait();
            return "hoi";
        }
        Task<string> DoeIetsAsync()
        {
            return Task.Run(() => DoeIets());
        }
    }
}
