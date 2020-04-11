namespace AvitoMonitor
{
    partial class AvitoMonitor
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvitoMonitor));
            this.search = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.searchtextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.loadbd = new System.Windows.Forms.Button();
            this.comboBoxForCity = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.DeleteDB = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьБазуДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loadnewdb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(351, 59);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(76, 20);
            this.search.TabIndex = 0;
            this.search.Text = "Поиск";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 136);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(248, 43);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // searchtextBox
            // 
            this.searchtextBox.Location = new System.Drawing.Point(12, 59);
            this.searchtextBox.Name = "searchtextBox";
            this.searchtextBox.Size = new System.Drawing.Size(327, 20);
            this.searchtextBox.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(450, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(600, 485);
            this.dataGridView1.TabIndex = 3;
            // 
            // loadbd
            // 
            this.loadbd.Location = new System.Drawing.Point(12, 185);
            this.loadbd.Name = "loadbd";
            this.loadbd.Size = new System.Drawing.Size(248, 24);
            this.loadbd.TabIndex = 4;
            this.loadbd.Text = "Посмотреть все найденые объявления";
            this.loadbd.UseVisualStyleBackColor = true;
            this.loadbd.Click += new System.EventHandler(this.loadbd_Click);
            // 
            // comboBoxForCity
            // 
            this.comboBoxForCity.FormattingEnabled = true;
            this.comboBoxForCity.Items.AddRange(new object[] {
            "Абакан",
            "Азов",
            "Александров",
            "Алексин",
            "Альметьевск",
            "Анапа",
            "Ангарск",
            "Анжеро-Судженск",
            "Апатиты",
            "Арзамас",
            "Армавир",
            "Арсеньев",
            "Артем",
            "Архангельск",
            "Асбест",
            "Астрахань",
            "Ачинск",
            "Балаково",
            "Балахна",
            "Балашиха",
            "Балашов",
            "Барнаул",
            "Батайск",
            "Белгород",
            "Белебей",
            "Белово",
            "Белогорск (Амурская область)",
            "Белорецк",
            "Белореченск",
            "Бердск",
            "Березники",
            "Березовский (Свердловская область)",
            "Бийск",
            "Биробиджан",
            "Благовещенск (Амурская область)",
            "Бор",
            "Борисоглебск",
            "Боровичи",
            "Братск",
            "Брянск",
            "Бугульма",
            "Буденновск",
            "Бузулук",
            "Буйнакск",
            "Великие Луки",
            "Великий Новгород",
            "Верхняя Пышма",
            "Видное",
            "Владивосток",
            "Владикавказ",
            "Владимир",
            "Волгоград",
            "Волгодонск",
            "Волжск",
            "Волжский",
            "Вологда",
            "Вольск",
            "Воркута",
            "Воронеж",
            "Воскресенск",
            "Воткинск",
            "Всеволожск",
            "Выборг",
            "Выкса",
            "Вязьма",
            "Гатчина",
            "Геленджик",
            "Георгиевск",
            "Глазов",
            "Горно-Алтайск",
            "Грозный",
            "Губкин",
            "Гудермес",
            "Гуково",
            "Гусь-Хрустальный",
            "Дербент",
            "Дзержинск",
            "Димитровград",
            "Дмитров",
            "Долгопрудный",
            "Домодедово",
            "Донской",
            "Дубна",
            "Евпатория",
            "Егорьевск",
            "Ейск",
            "Екатеринбург",
            "Елабуга",
            "Елец",
            "Ессентуки",
            "Железногорск (Красноярский край)",
            "Железногорск (Курская область)",
            "Жигулевск",
            "Жуковский",
            "Заречный",
            "Зеленогорск",
            "Зеленодольск",
            "Златоуст",
            "Иваново",
            "Ивантеевка",
            "Ижевск",
            "Избербаш",
            "Иркутск",
            "Искитим",
            "Ишим",
            "Ишимбай",
            "Йошкар-Ола",
            "Казань",
            "Калининград",
            "Калуга",
            "Каменск-Уральский",
            "Каменск-Шахтинский",
            "Камышин",
            "Канск",
            "Каспийск",
            "Кемерово",
            "Керчь",
            "Кинешма",
            "Кириши",
            "Киров (Кировская область)",
            "Кирово-Чепецк",
            "Киселевск",
            "Кисловодск",
            "Клин",
            "Клинцы",
            "Ковров",
            "Когалым",
            "Коломна",
            "Комсомольск-на-Амуре",
            "Копейск",
            "Королев",
            "Кострома",
            "Котлас",
            "Красногорск",
            "Краснодар",
            "Краснокаменск",
            "Краснокамск",
            "Краснотурьинск",
            "Красноярск",
            "Кропоткин",
            "Крымск",
            "Кстово",
            "Кузнецк",
            "Кумертау",
            "Кунгур",
            "Курган",
            "Курск",
            "Кызыл",
            "Лабинск",
            "Лениногорск",
            "Ленинск-Кузнецкий",
            "Лесосибирск",
            "Липецк",
            "Лиски",
            "Лобня",
            "Лысьва",
            "Лыткарино",
            "Люберцы",
            "Магадан",
            "Магнитогорск",
            "Майкоп",
            "Махачкала",
            "Междуреченск",
            "Мелеуз",
            "Миасс",
            "Минеральные Воды",
            "Минусинск",
            "Михайловка",
            "Михайловск (Ставропольский край)",
            "Мичуринск",
            "Москва",
            "Мурманск",
            "Муром",
            "Мытищи",
            "Набережные Челны",
            "Назарово",
            "Назрань",
            "Нальчик",
            "Наро-Фоминск",
            "Находка",
            "Невинномысск",
            "Нерюнгри",
            "Нефтекамск",
            "Нефтеюганск",
            "Нижневартовск",
            "Нижнекамск",
            "Нижний Новгород",
            "Нижний Тагил",
            "Новоалтайск",
            "Новокузнецк",
            "Новокуйбышевск",
            "Новомосковск",
            "Новороссийск",
            "Новосибирск",
            "Новотроицк",
            "Новоуральск",
            "Новочебоксарск",
            "Новочеркасск",
            "Новошахтинск",
            "Новый Уренгой",
            "Ногинск",
            "Норильск",
            "Ноябрьск",
            "Нягань",
            "Обнинск",
            "Одинцово",
            "Озерск (Челябинская область)",
            "Октябрьский",
            "Омск",
            "Орел",
            "Оренбург",
            "Орехово-Зуево",
            "Орск",
            "Павлово",
            "Павловский Посад",
            "Пенза",
            "Первоуральск",
            "Пермь",
            "Петрозаводск",
            "Петропавловск-Камчатский",
            "Подольск",
            "Полевской",
            "Прокопьевск",
            "Прохладный",
            "Псков",
            "Пушкино",
            "Пятигорск",
            "Раменское",
            "Ревда",
            "Реутов",
            "Ржев",
            "Рославль",
            "Россия",
            "Россошь",
            "Ростов-на-Дону",
            "Рубцовск",
            "Рыбинск",
            "Рязань",
            "Салават",
            "Сальск",
            "Самара",
            "Санкт-Петербург",
            "Саранск",
            "Сарапул",
            "Саратов",
            "Саров",
            "Свободный",
            "Севастополь",
            "Северодвинск",
            "Северск",
            "Сергиев Посад",
            "Серов",
            "Серпухов",
            "Сертолово",
            "Сибай",
            "Симферополь",
            "Славянск-на-Кубани",
            "Смоленск",
            "Соликамск",
            "Солнечногорск",
            "Сосновый Бор",
            "Сочи",
            "Ставрополь",
            "Старый Оскол",
            "Стерлитамак",
            "Ступино",
            "Сургут",
            "Сызрань",
            "Сыктывкар",
            "Таганрог",
            "Тамбов",
            "Тверь",
            "Тимашевск",
            "Тихвин",
            "Тихорецк",
            "Тобольск",
            "Тольятти",
            "Томск",
            "Троицк",
            "Туапсе",
            "Туймазы",
            "Тула",
            "Тюмень",
            "Узловая",
            "Улан-Удэ",
            "Ульяновск",
            "Урус-Мартан",
            "Усолье-Сибирское",
            "Уссурийск",
            "Усть-Илимск",
            "Уфа",
            "Ухта",
            "Феодосия",
            "Фрязино",
            "Хабаровск",
            "Ханты-Мансийск",
            "Хасавюрт",
            "Химки",
            "Чайковский",
            "Чапаевск",
            "Чебоксары",
            "Челябинск",
            "Черемхово",
            "Череповец",
            "Черкесск",
            "Черногорск",
            "Чехов",
            "Чистополь",
            "Чита",
            "Шадринск",
            "Шали",
            "Шахты",
            "Шуя",
            "Щекино",
            "Щелково",
            "Электросталь",
            "Элиста",
            "Энгельс",
            "Южно-Сахалинск",
            "Юрга",
            "Якутск",
            "Ялта",
            "Ярославль"});
            this.comboBoxForCity.Location = new System.Drawing.Point(12, 109);
            this.comboBoxForCity.Name = "comboBoxForCity";
            this.comboBoxForCity.Size = new System.Drawing.Size(121, 21);
            this.comboBoxForCity.TabIndex = 5;
            this.comboBoxForCity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxForCity_KeyPress);
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Автомобили",
            "Аквариум",
            "Аудио и видео",
            "Билеты и путешествия",
            "Бытовая техника",
            "Бытовая электроника",
            "Вакансии",
            "Водный транспорт",
            "Велосипеды",
            "Гаражи и машиноместа",
            "Готовый бизнес",
            "Грузовики и спецтехника",
            "Детская одежда и обувь",
            "Для бизнеса",
            "Для дома и дачи",
            "Дома, дачи, коттеджи",
            "Другие животные",
            "Животные",
            "Запчасти и аксессуары",
            "Земельные участки",
            "Игры, приставки и программы",
            "Квартиры",
            "Книги и журналы",
            "Комнаты",
            "Коллекционирование",
            "Кошки",
            "Личные вещи",
            "Любая категория",
            "Мебель и интерьер",
            "Мотоциклы и мототехника",
            "Музыкальные инструменты",
            "Настольные компьютеры",
            "Недвижимость",
            "Недвижимость за рубежом",
            "Ноутбуки",
            "Оборудование для бизнеса",
            "Одежда, обувь, акскссуары",
            "Оргтехника и расходники",
            "Охота и рыбалка",
            "Планшеты и электонные книги",
            "Посуда и товары для кухни",
            "Птицы",
            "Продукты питания",
            "Работа",
            "Растения",
            "Ремонт и строительство",
            "Собаки",
            "Спорт и отдых",
            "Телефоны",
            "Товары для детей и игрушки",
            "Товары для компьютера",
            "Товары для животных",
            "Транспорт",
            "Услуги",
            "Фототехника",
            "Хобби и отдых",
            "Часы и украшения"});
            this.comboBoxType.Location = new System.Drawing.Point(139, 109);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxType.TabIndex = 6;
            this.comboBoxType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxType_KeyPress);
            // 
            // DeleteDB
            // 
            this.DeleteDB.Location = new System.Drawing.Point(12, 245);
            this.DeleteDB.Name = "DeleteDB";
            this.DeleteDB.Size = new System.Drawing.Size(248, 24);
            this.DeleteDB.TabIndex = 7;
            this.DeleteDB.Text = "Удалить базу данных";
            this.DeleteDB.UseVisualStyleBackColor = true;
            this.DeleteDB.Click += new System.EventHandler(this.DeleteDB_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1062, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.копироватьБазуДанныхToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // копироватьБазуДанныхToolStripMenuItem
            // 
            this.копироватьБазуДанныхToolStripMenuItem.Name = "копироватьБазуДанныхToolStripMenuItem";
            this.копироватьБазуДанныхToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.копироватьБазуДанныхToolStripMenuItem.Text = "Копировать базу данных";
            this.копироватьБазуДанныхToolStripMenuItem.Click += new System.EventHandler(this.копироватьБазуДанныхToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Выберите город";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Выберите категорию";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Введите текст поиска";
            // 
            // loadnewdb
            // 
            this.loadnewdb.Location = new System.Drawing.Point(12, 215);
            this.loadnewdb.Name = "loadnewdb";
            this.loadnewdb.Size = new System.Drawing.Size(248, 24);
            this.loadnewdb.TabIndex = 12;
            this.loadnewdb.Text = "Посмотреть новые объявления";
            this.loadnewdb.UseVisualStyleBackColor = true;
            this.loadnewdb.Click += new System.EventHandler(this.loadnewdb_Click_1);
            // 
            // AvitoMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 590);
            this.Controls.Add(this.loadnewdb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeleteDB);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.comboBoxForCity);
            this.Controls.Add(this.loadbd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.searchtextBox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AvitoMonitor";
            this.Text = "AvitoMonitor";
            this.Load += new System.EventHandler(this.AvitoMonitor_Load);
            this.Resize += new System.EventHandler(this.AvitoMonitor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox searchtextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button loadbd;
        private System.Windows.Forms.ComboBox comboBoxForCity;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Button DeleteDB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копироватьБазуДанныхToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loadnewdb;
    }
}

