using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace textset
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			//добавляем таблицу
			dataSet1.Tables.Add();
			//добавляем столбцы
			dataSet1.Tables[0].Columns.Add("name");
			dataSet1.Tables[0].Columns.Add("name2");
			//добавляем строки
			dataSet1.Tables[0].Rows.Add("To","Loshadka");
			dataSet1.Tables[0].Rows.Add("1234","5678");
			dataSet1.Tables[0].Rows.Add("row3columns0","row3columns1");
			//добавляем уникальный идентификатор
			dataSet1.Tables[0].PrimaryKey = new System.Data.DataColumn[] {dataSet1.Tables[0].Columns[0]};
			//устанавливаем источником данных для bindingSource1 
			bindingSource1.DataSource=dataSet1.Tables[0];
			//устанавливаем источником данных для dataGridView1 
			dataGridView1.DataSource=bindingSource1;
		}
		
		void DataGridView1CellClick(object sender, DataGridViewCellEventArgs e)
		{
			//
			Form1 f = new Form1();
			var tutu=dataSet1.Tables[0].Rows.Find(dataGridView1.CurrentRow.Cells[0].Value.ToString());
			//передаем значения на Form1 в поле textBox1 у которого свойство Public
			f.textBox1.Text=tutu.ItemArray[0].ToString();
			//Копируем содержимое и структуру данных из dataset1 на этой форме в Form1
			f.dataSet1=dataSet1.Copy();
			//Показываем Form1
			f.ShowDialog();
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			//для проверки поиска по dataset, по умолчанию Tables=-1
			var tutu=dataSet1.Tables[0].Rows.Find(textBox1.Text);
			//первый столбец, для строки
			textBox2.Text=tutu.ItemArray[0].ToString();
			//второй столбец, для строки
			textBox3.Text=tutu.ItemArray[1].ToString();
			
		}
	}
}
