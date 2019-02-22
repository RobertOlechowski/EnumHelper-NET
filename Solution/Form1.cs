using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnumDescriptionDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var elements = EnumHelper.GetValueDescriptionEnumerable<ExampleEnum>()
            .Select(a => new { wartosc = a.Item1, opis = a.Item2 })
            .ToList();

            comboBox1.DataSource = elements;
            comboBox1.DisplayMember = "opis";
            comboBox1.ValueMember = "wartosc";

        }
    }
}
