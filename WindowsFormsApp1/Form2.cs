using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2(string filePath)
        {
            InitializeComponent();
            
            using (var fileRdr = new StreamReader(filePath))
            {
                var columns = fileRdr.ReadLine().Split(", ".ToArray(), StringSplitOptions.RemoveEmptyEntries);

               
                foreach (var col in columns)
                {
                    var dataColumn = new DataGridViewTextBoxColumn();
                    dataColumn.Name = col;
                    dataColumn.HeaderText = col.ToUpper();
                    dataGridView1.Columns.Add(dataColumn);
                }

                while (!fileRdr.EndOfStream)
                {
                    var lineData = fileRdr.ReadLine().Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    dataGridView1.Rows.Add(lineData[0], lineData[1], lineData[2], lineData[3], lineData[4], lineData[5], lineData[6], lineData[7], lineData[8]);
                }

                fileRdr.Close();
                fileRdr.Dispose();
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {

        }
    }
}
