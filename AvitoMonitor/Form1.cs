using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using CsQuery;

namespace AvitoMonitor{
    public partial class AvitoMonitor : Form{
        public AvitoMonitor(){
            InitializeComponent();
            Support.CreationOfDataBase(Support.WAY);
            Support.CreationOfDirectory(Support.PATHtoIMG);
        }

        private void button1_Click(object sender, EventArgs e){
            try { 
                using (WebClient client = new WebClient()){
                    //Проверка комбобоксов
                    if (comboBoxForCity.Text.Trim() != "") { 
                        Support.SEARCHstring += "/" + Support.Cities[comboBoxForCity.Text];    
                    } else {
                        MessageBox.Show("Ошибка поиска, город не выбран",
                        "Вы должны выбрать город", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Support.SEARCHstring = "https://www.avito.ru";
                        return;
                    }
                    if (comboBoxType.Text.Trim() != "") {
                        Support.SEARCHstring += "/" + Support.Types[comboBoxType.Text];
                    } else {
                        MessageBox.Show("Ошибка поиска, категория не выбрана",
                        "Вы должны выбрать тип(категорию)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Support.SEARCHstring = "https://www.avito.ru";
                        return;
                    }
                    if (searchtextBox.Text.Replace(" ", "") != "") {
                        Support.SEARCHstring += "?s_trg=11&q=" + searchtextBox.Text;
                    } else if (searchtextBox.Text.Replace(" ", "") == "") {
                        Support.SEARCHstring += "?s_trg=11";
                    }
                    
                    //создание БД и деректории для картинок при их отсутствии
                    Support.CreationOfDataBase(Support.WAY);
                    Support.CreationOfDirectory(Support.PATHtoIMG);

                    richTextBox1.Clear();
                    richTextBox1.AppendText("Скачивание...\n");
                    richTextBox1.AppendText("Никуда не нажимайте до окончания процесса\n");
                    //Проверка на существование страницы
                    try {
                        Support.htmlCode = client.DownloadString(Support.SEARCHstring);
                    } catch {
                        richTextBox1.AppendText(Support.SEARCHstring);
                        MessageBox.Show("Ошибка поиска, страницы не существует или нет подключения к интернету",
                        "Проверьте правильность ввода и подключение к интернету", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        richTextBox1.AppendText("При скачивании произошла ошибка попробуйте еще раз\n");
                        return;
                    }
                
                    //Создание вспомогательной Базы данных 
                    string sourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Support.WAY);
                    string destFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Support.WAY_FOR_SUPPORT_DB);
                    File.Copy(sourceFile, destFile, true);

                    Encoding utf8 = Encoding.GetEncoding("UTF-8");
                    Encoding win1251 = Encoding.GetEncoding("Windows-1251");

                    byte[] utf8Bytes = win1251.GetBytes(Support.htmlCode);
                    byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);

                    Support.htmlCode = win1251.GetString(win1251Bytes);

                    CQ dom = Support.htmlCode;
                    CQ items = dom.Select(".item");
                    int j = 0;
                    CQ title = dom.Select(".item-description-title-link");
                    CQ itemphoto = dom.Select(".large-picture-img");
                    CQ itemtime = dom.Select(".js-item-date");
                    for (int i = 0; i < items.Count(); i++) {
                        CQ item = items[i].InnerHTML;
                        if (item == null || title == null || itemphoto == null || itemtime == null) {
                            MessageBox.Show("Ошибка поиска, По вашему запросу ничего не найдено",
                            "Ничего не найдено", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Support.SEARCHstring = "https://www.avito.ru";
                            return;
                        }
                        try { 
                            if (title[i]["title"] != "" && itemphoto[i]["src"] != "" &&
                                item[".price"].Text().Replace("?", "").Replace(" ", "") != "" &&
                                itemtime[i]["data-relative-date"] != "" && title[i]["href"] != "") {
                                string path = AppDomain.CurrentDomain.BaseDirectory +
                                        @"\" + Support.PATHtoIMG + @"\" + "img.jpg";
                                using (WebClient clientimg = new WebClient()){

                                    client.DownloadFile(Support.ImageString + itemphoto[j]["src"].Replace("https:", ""), 
                                        path);
                                    FileInfo _imgInfo = new FileInfo(path);
                                    long _numBytes = _imgInfo.Length;
                                    FileStream _fileStream = new FileStream(path, FileMode.Open, FileAccess.Read); // читаем изображение
                                    BinaryReader _binReader = new BinaryReader(_fileStream);
                                    byte[] _imageBytes = _binReader.ReadBytes((int)_numBytes); // изображение в байтах

                                    string imgFormat = Path.GetExtension(path).Replace(".", "").ToLower(); // запишем в переменную расширение изображения в нижнем регистре, не забыв удалить точку перед расширением, получим «jpg»
                                    string imgName = Path.GetFileName(path).Replace(Path.GetExtension(path), ""); // запишем в переменную имя файла, не забыв удалить расширение с точкой, получим «img»

                                    // записываем информацию в базы данных
                                    using (SQLiteConnection connectOP = new SQLiteConnection(Support.conectString)){
                                        DataTable dTable = new DataTable();
                                        string CommandTextOP = "SELECT * " +
                                            "FROM AvitoMonitor WHERE [Ссылка на Объявление]='" + Support.MainLink + title[i]["href"] + @"'"; // Если этот запрос не выполняется
                                        SQLiteCommand CommandOP = new SQLiteCommand(CommandTextOP, connectOP);
                                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(CommandTextOP, connectOP);
                                        adapter.Fill(dTable);
                                        if (dTable.Rows.Count == 0) {
                                            using (SQLiteConnection Connect = new SQLiteConnection(Support.conectString)){
                                                string commandText = "INSERT INTO [AvitoMonitor] ([Время], [Название], [Цена], [Город], [Опубликовано], [Тип], [Картинка], [Формат картинки], [Ссылка на Объявление]) " +
                                                    "VALUES(@time, @name, @price, @city, @addtime, @type, @image, @format, @add_link)";
                                                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                                                Command.Parameters.AddWithValue("@time", DateTime.Now.ToString());
                                                Command.Parameters.AddWithValue("@name", title[i]["title"]);
                                                Command.Parameters.AddWithValue("@price", item[".price"].Text().Replace("?", "P"));
                                                Command.Parameters.AddWithValue("@city", comboBoxForCity.Text);
                                                Command.Parameters.AddWithValue("@addtime", itemtime[i]["data-relative-date"]);
                                                Command.Parameters.AddWithValue("@type", comboBoxType.Text);
                                                Command.Parameters.AddWithValue("@image", _imageBytes);
                                                Command.Parameters.AddWithValue("@format", imgFormat);
                                                Command.Parameters.AddWithValue("@add_link", Support.MainLink + title[i]["href"].Replace(Support.MainLink,""));
                                                Connect.Open();
                                                Command.ExecuteNonQuery();
                                                Connect.Close();
                                            }
                                        }
                                    }
                                    
                                    using (SQLiteConnection connection = new SQLiteConnection(Support.conectString)) {
                                        DataTable dTable = new DataTable();
                                        string CommandText = "SELECT * " +
                                            "FROM AvitoMonitorNew WHERE [Ссылка на Объявление]='" + Support.MainLink + title[i]["href"] + @"'"; 
                                        SQLiteCommand Command = new SQLiteCommand(CommandText, connection);
                                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(CommandText, connection);
                                        adapter.Fill(dTable);

                                        if (dTable.Rows.Count == 0){
                                            CommandText = "INSERT INTO [AvitoMonitorNew] ([Время], [Название], [Цена], [Город], [Опубликовано], [Тип], [Картинка], [Формат картинки], [Ссылка на Объявление]) " +
                                            "VALUES(@time, @name, @price, @city, @addtime, @type, @image, @format, @add_link)";
                                            Command = new SQLiteCommand(CommandText, connection);
                                            Command.Parameters.AddWithValue("@time", DateTime.Now.ToString());
                                            Command.Parameters.AddWithValue("@name", title[i]["title"]);
                                            Command.Parameters.AddWithValue("@price", item[".price"].Text().Replace("?", "P"));
                                            Command.Parameters.AddWithValue("@city", comboBoxForCity.Text);
                                            Command.Parameters.AddWithValue("@addtime", itemtime[i]["data-relative-date"]);
                                            Command.Parameters.AddWithValue("@type", comboBoxType.Text);
                                            Command.Parameters.AddWithValue("@image", _imageBytes); 
                                            Command.Parameters.AddWithValue("@format", imgFormat);
                                            Command.Parameters.AddWithValue("@add_link", Support.MainLink + title[i]["href"].Replace(Support.MainLink, ""));
                                            connection.Open();
                                            Command.ExecuteNonQuery();
                                            connection.Close();
                                            Support.Marker = true;
                                        } else { 
                                            CommandText = "DELETE FROM [AvitoMonitorNew] WHERE [Ссылка на Объявление]='" + Support.MainLink + title[i]["href"] + @"'";
                                            Command = new SQLiteCommand(CommandText, connection);
                                            connection.Open();
                                            Command.ExecuteNonQuery();
                                            connection.Close();
                                        }
                                    }
                                    _fileStream.Close();
                                    File.Delete(path);
                                }
                            }
                            Support.ImageStringDefault();
                        } catch (Exception ex){ 
                            //MessageBox.Show(ex.Message);
                            continue;
                        }
                        j += item.Select(".large-picture-img").Count();
                    }
                    richTextBox1.AppendText("Скачивание прошло успешно\n");
                    if (Support.Marker) {
                        richTextBox1.AppendText("Программа нашла новые объявления\n");
                        MessageBox.Show("Найдены новые объявления",
                        "Есть новые объявления", MessageBoxButtons.OK);
                        Support.Marker = false;
                    } else {
                        richTextBox1.AppendText("Программа не нашла новых объявлений\n");
                        MessageBox.Show("Новых обьявлений не найдено",
                               "Нет новых объявлений", MessageBoxButtons.OK);
                        using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=" +
                            AppDomain.CurrentDomain.BaseDirectory + @"\" + Support.WAY + @"; Version=3;")) { 
                            DataTable dTable = new DataTable();
                            string CommandText = "SELECT * FROM AvitoMonitorNew";
                            SQLiteCommand Command = new SQLiteCommand(CommandText, connection);
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter(CommandText, connection);
                            adapter.Fill(dTable);
                            if (dTable.Rows.Count == 0){
                                string beginFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Support.WAY_FOR_SUPPORT_DB);
                                string endFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Support.WAY);
                                File.Copy(beginFile, endFile, true);
                            }
                        }
                    }
                    File.Delete(Support.WAY_FOR_SUPPORT_DB);
                    richTextBox1.AppendText(Support.SEARCHstring);
                    Support.SEARCHstringDefault();
                }
            } catch (Exception) {
                MessageBox.Show("Нет соеденения с интернетом",
                    "Подключение к сети отсутствует", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        void LoadData() {
            using(SQLiteConnection connection = new SQLiteConnection(Support.conectString)) {
                SQLiteCommand command = connection.CreateCommand();
                string ComandText = "select *from AvitoMonitor";
                SQLiteDataAdapter DB = new SQLiteDataAdapter(ComandText, connection);
                DataSet DS = new DataSet();
                DS.Reset();
                DB.Fill(DS);
                DataTable DT;
                DT = DS.Tables[0];
                dataGridView1.DataSource = DT;
                connection.Close();
                connection.Dispose();
            }
        }
        void LoadNewData() {
            using(SQLiteConnection connection = new SQLiteConnection(Support.conectString)) {
                SQLiteCommand command = connection.CreateCommand();
                string ComandText = "select *from AvitoMonitorNew";
                SQLiteDataAdapter DB = new SQLiteDataAdapter(ComandText, connection);
                DataSet DS = new DataSet();
                DS.Reset();
                DB.Fill(DS);
                DataTable DT;
                DT = DS.Tables[0];
                dataGridView1.DataSource = DT;
                connection.Close();
                connection.Dispose();
            }
        }

        private void AvitoMonitor_Load(object sender, EventArgs e){
            this.WindowState = FormWindowState.Maximized;
            dataGridView1.Width = ClientSize.Width/3*2;
            dataGridView1.Height = ClientSize.Height/4*3;
        }

        private void loadbd_Click(object sender, EventArgs e){
            dataGridView1.DataSource = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            if (!File.Exists(Support.WAY))
                Support.CreationOfDataBase(Support.WAY);
            LoadData();

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoResizeColumns();

            dataGridView1.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void loadnewdb_Click_1(object sender, EventArgs e){
            dataGridView1.DataSource = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            if (!File.Exists(Support.WAY))
                Support.CreationOfDataBase(Support.WAY);
            LoadNewData();

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoResizeColumns();

            dataGridView1.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void comboBoxType_KeyPress(object sender, KeyPressEventArgs e){
            ((ComboBox)sender).DroppedDown = true;
            if (char.IsControl(e.KeyChar))
                return;
            string Str = ((ComboBox)sender).Text.Substring(0, ((ComboBox)sender).SelectionStart) 
                + e.KeyChar.ToString();
            int Index = ((ComboBox)sender).FindStringExact(Str);
            if (Index == -1)
                Index = ((ComboBox)sender).FindString(Str);
            ((ComboBox)sender).SelectedIndex = Index;
            ((ComboBox)sender).SelectionStart = Str.Length;
            ((ComboBox)sender).SelectionLength = 
                ((ComboBox)sender).Text.Length - ((ComboBox)sender).SelectionStart;
            e.Handled = true;
        }

        private void comboBoxForCity_KeyPress(object sender, KeyPressEventArgs e){
            ((ComboBox)sender).DroppedDown = true;
            if (char.IsControl(e.KeyChar))
                return;
            string Str = ((ComboBox)sender).Text.Substring(0, ((ComboBox)sender).SelectionStart)
                + e.KeyChar.ToString();
            int Index = ((ComboBox)sender).FindStringExact(Str);
            if (Index == -1)
                Index = ((ComboBox)sender).FindString(Str);
            ((ComboBox)sender).SelectedIndex = Index;
            ((ComboBox)sender).SelectionStart = Str.Length;
            ((ComboBox)sender).SelectionLength =
                ((ComboBox)sender).Text.Length - ((ComboBox)sender).SelectionStart;
            e.Handled = true;
        }

        private void DeleteDB_Click(object sender, EventArgs e){
            if (File.Exists(Support.WAY)){
                try { 
                    dataGridView1.DataSource = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Support.DeleteDB(Support.WAY);
                    MessageBox.Show("Базы данных успешно удалены", "Удаление прошло успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.None);
                } catch (Exception ex) { 
                    MessageBox.Show(ex.Message, "Ошибка при удалении баз данных", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Вы не можите удалить базы данных, которых не существует",
                    "Ошибка при удалении баз данных", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void копироватьБазуДанныхToolStripMenuItem_Click(object sender, EventArgs e){
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.InitialDirectory = @"C:\";
            savedialog.Title = "Сохранить Базу Данных как...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter = "DataBase files(*.db)|*.db";
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK) { 
                try{
                    string sourcePath = AppDomain.CurrentDomain.BaseDirectory;
                    string targetPath = Path.GetFullPath(savedialog.FileName);
                    string sourceFile = Path.Combine(sourcePath, Support.WAY);
                    string destFile = Path.Combine(targetPath, savedialog.FileName);
                    File.Copy(sourceFile, destFile, true);
                } catch (Exception ex){
                    MessageBox.Show("Невозможно сохранить базу данных, возможно вы её удалили \n" 
                        + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AvitoMonitor_Resize(object sender, EventArgs e){
            //dataGridView1.Size = new Size(this.Width, this.Height);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}