using System;
using System.Drawing;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace textset
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class Form1 : Form
	{
		public Form1()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Form1Load(object sender, EventArgs e)
		{
//если dataset не имеет таблиц, т.е. пустой то происходит запрос к базе данных по полю textbox1.text
if(dataSet1.Tables.Count==0)
{
string cs = @"server=;userid=;password=;database=";
MySqlConnection conn = new MySqlConnection(cs);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            
            conn.Open();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand("ТУТ ВАШ ЗАПРОС(select поле1,поле2,поле3 и так далее from tablename where вашуникальныйID='"+textBox1.Text+"'", conn);
            MyDA.Fill(dataSet1);
            conn.Close();
    //DataGridView разместил только для отображения результатов
    bindingSource1.DataSource=dataSet1.Tables[0];
	dataGridView1.DataSource=bindingSource1;
}
	//для наглядного отображения что с первой формы структура и значения из dataset на главной форме перенесены сюда же
	if(dataSet1.Tables.Count>=1)
	{
	var result=dataSet1.Tables[0].Rows.Find(textBox1.Text);
	textBox2.Text=result.ItemArray[0].ToString();
	textBox3.Text=result.ItemArray[1].ToString();
	//DataGridView разместил только для отображения результатов
	bindingSource1.DataSource=dataSet1.Tables[0];
	dataGridView1.DataSource=bindingSource1;
}
			
		}
		
		
	}
}
