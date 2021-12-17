using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Reflection;
using System.Data.Entity.Infrastructure;
using ProektsAgents.Classes;

namespace ProektsAgents
{
    public partial class EditProductWindow : Window
    {
        Agent currentAgent;
        bool newAgent;//Проверка на добавление нового агента
        byte[] imageInBytes;//Картинка
        string filePath;
        public EditProductWindow()//Добавление
        {
            InitializeComponent();
            currentAgent = new Agent();
            DataContext = currentAgent;
            newAgent = true;
            Title = "Добавить продукт";
            DeleteProductBtn.Visibility = Visibility.Hidden;
            FillComboBox();
        }
        public EditProductWindow(Agent selectedProduct)//Редактирование
        {
            currentAgent = selectedProduct;
            DataContext = currentAgent;
            InitializeComponent();
            newAgent = false;
            Title = "Редактировать продукт";
            DeleteProductBtn.Visibility = Visibility.Visible;
            FillComboBox();
        }

        private void FillComboBox()
        {
            List<AgentType> agentTypes = DBManager.GetContext().AgentType.ToList();
            AgentTypeCmb.ItemsSource = agentTypes;
        }

        private bool CheckIfNumPhone()//Проверка номера телефона
        {
            bool articleNotExist = true;
            List<Agent> products = DBManager.GetContext().Agent.ToList();
            foreach (var product in products)
                if (product.Phone.Contains(PhoneNumberBox.Text)
                    && product.ID != currentAgent.ID)
                {
                    articleNotExist = false;
                    break;
                }

            if (articleNotExist)
                return true;
            else
                return false;
        }
        private bool CheckIfУEmail()//Проверка номера телефона
        {
            bool articleNotExist = true;
            List<Agent> agents = DBManager.GetContext().Agent.ToList();
            foreach (var agent in agents)
                if (agent.Email.Contains(EmailNumberBox.Text)
                    && agent.ID != currentAgent.ID)
                {
                    articleNotExist = false;
                    break;
                }

            if (articleNotExist)
                return true;
            else
                return false;
        }

        private void UpdateData()//обновление данных
        {
            BindingManager.GetBindingExpression(AgentNameBox, TextBox.TextProperty);
            BindingManager.GetBindingExpression(AgentTypeCmb, ComboBox.SelectedItemProperty);
            BindingManager.GetBindingExpression(PhoneNumberBox, TextBox.TextProperty);
            BindingManager.GetBindingExpression(EmailNumberBox, TextBox.TextProperty);
            BindingManager.GetBindingExpression(INNBox, TextBox.TextProperty);
            BindingManager.GetBindingExpression(KPPBox, TextBox.TextProperty);
            BindingManager.GetBindingExpression(AddressBox, TextBox.TextProperty);
            BindingManager.GetBindingExpression(RegionBox, TextBox.TextProperty);
            BindingManager.GetBindingExpression(CityBox, TextBox.TextProperty);
            BindingManager.GetBindingExpression(StreetBox, TextBox.TextProperty);
            BindingManager.GetBindingExpression(NumHouseBox, TextBox.TextProperty);
            BindingManager.GetBindingExpression(DirectorSurName, TextBox.TextProperty);
            BindingManager.GetBindingExpression(DirectorName, TextBox.TextProperty);
            BindingManager.GetBindingExpression(DirectorLastName, TextBox.TextProperty);
            BindingManager.GetBindingExpression(PriorityBox, TextBox.TextProperty);
        }
        
        private void SaveChangesBtn_Click(object sender, RoutedEventArgs e)//Сохранение данных
        {
            if (Verification() && AgentTypeCmb.SelectedIndex != -1)//Проверка на пустые поля
            {
                SaveImage();//Метод сохранения изоображения
                if (CheckIfNumPhone())
                {
                    if (CheckIfУEmail())
                    {
                        if (newAgent)
                            AddAgent();//Добавление агента

                        UpdateData();
                        DBManager.GetContext().SaveChanges();//Сохранения записей

                        MessageBox.Show("Данные успешно внесены", "Информация",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                    }
                    else
                        MessageBox.Show("Агент с данной электронной почтой уже существует. Укажите другую электронную почту!",
                        "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Указанный номер телефона уже существует. Укажиет другой номер телефона!",
                        "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Поля почеркнутые красным не заполнены или заполнены некорректно. Повторите ввод!",
                    "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DeleteProductBtn_Click(object sender, RoutedEventArgs e)
        {
            //удаление агентов
            try
            {
                DBManager.GetContext().Agent.Remove(currentAgent);
                DBManager.GetContext().SaveChanges();

                MessageBox.Show("Данные удалены", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch
            {
                MessageBox.Show("Удаление данного агента невозможно", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void SaveImage()
        {
            //сохранения изоображений
            if (filePath == null && currentAgent.LogoImage == null)
            {
                var appDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var relativePath = @"picture.png";
                filePath = System.IO.Path.Combine(appDir, relativePath);
                imageInBytes = File.ReadAllBytes(filePath);
                currentAgent.LogoImage = imageInBytes;
            }
            else if (filePath != null)
            {
                imageInBytes = File.ReadAllBytes(filePath);
                currentAgent.LogoImage = imageInBytes;
            }
        }

        private void AddAgent()//Добавление агента в БД
        {
            Address address = new Address()//Добавление адреса
            {
                PostalCode = Convert.ToDecimal(AddressBox.Text),
                Region = RegionBox.Text,
                City = CityBox.Text,
                Street = StreetBox.Text,
                HouseNumber = Convert.ToDecimal(NumHouseBox.Text)
            };
            DBManager.GetContext().Address.Add(address);

            
            Director director = new Director()//Добавление директора 
            {
                Surname = DirectorSurName.Text,
                Name = DirectorName.Text,
                LastName = DirectorLastName.Text
            };
            DBManager.GetContext().Director.Add(director);

            DBManager.GetContext().SaveChanges();//Сохранение

            //Добавление адреса и директора к агенту
            List<Director> directors = DBManager.GetContext().Director.ToList();//Список о директорах
            List<Address> addresses = DBManager.GetContext().Address.ToList();//Список о адресах
            currentAgent.DirectorID = directors.Where(p => p == director).Select(с => с.ID).FirstOrDefault();//Запрос на проверку
            currentAgent.AddressID = addresses.Where(p => p == address).Select(c => c.ID).FirstOrDefault();//Запрос на проверку
            currentAgent.Discount = 0;

            //добавление агента в модель БД
            DBManager.GetContext().Agent.Add(currentAgent);//Добавление новых агентов
            DBManager.GetContext().SaveChanges();//Сохранение
        }

        private void LoadImageBtn_Click(object sender, RoutedEventArgs e)//Загрузка изображения вручную
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Title = "Загрузить изображение товара";
            openFileDialog.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(filePath, UriKind.Relative);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                ProductImage.Source = bitmap;
            }
        }
        private void WithoutWhiteSpace(object sender, KeyEventArgs e)
        {
            Verification();
            //if (e.Key == Key.Space)
            //    e.Handled = true;
        }
        private bool Verification()
        {
            Brush border = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFFF0000");
            Brush border1 = (SolidColorBrush)new BrushConverter().ConvertFromString("#46B29D");
            bool test = true;
            if (string.IsNullOrWhiteSpace(AgentNameBox.Text))
            {
                AgentNameBox.BorderBrush = border;
                test = true;
            }
            else AgentNameBox.BorderBrush = border1;
            if (string.IsNullOrWhiteSpace(PhoneNumberBox.Text))
            {
                PhoneNumberBox.BorderBrush = border;
                test = false;
            }
            else PhoneNumberBox.BorderBrush = border1;
            if (string.IsNullOrWhiteSpace(EmailNumberBox.Text))
            {
                EmailNumberBox.BorderBrush = border;
                test = false;
            }
            else EmailNumberBox.BorderBrush = border1;
            if (string.IsNullOrWhiteSpace(INNBox.Text))
            {
                INNBox.BorderBrush = border;
                test = false;
            }
            else INNBox.BorderBrush = border1;
            if (string.IsNullOrWhiteSpace(KPPBox.Text))
            {
                KPPBox.BorderBrush = border;
                test = false;
            }
            else KPPBox.BorderBrush = border1;
            if (string.IsNullOrWhiteSpace(AddressBox.Text))
            {
                AddressBox.BorderBrush = border;
                test = false;
            }
            else AddressBox.BorderBrush = border1;
            if (string.IsNullOrWhiteSpace(DirectorLastName.Text))
            {
                DirectorLastName.BorderBrush = border;
                test = false;
            }
            else DirectorLastName.BorderBrush = border1;
            if (string.IsNullOrWhiteSpace(PriorityBox.Text))
            {
                PriorityBox.BorderBrush = border;
                test = false;
            }
            else PriorityBox.BorderBrush = border1;
            if (string.IsNullOrWhiteSpace(DirectorName.Text))
            {
                DirectorName.BorderBrush = border;
                test = false;
            }
            else DirectorName.BorderBrush = border1;
            if (string.IsNullOrWhiteSpace(DirectorSurName.Text))
            {
                DirectorSurName.BorderBrush = border;
                test = false;
            }
            else DirectorSurName.BorderBrush = border1;
            if (string.IsNullOrWhiteSpace(AddressBox.Text))
            {
                AddressBox.BorderBrush = border;
                test = false;
            }
            else AddressBox.BorderBrush = border1;
            if (string.IsNullOrWhiteSpace(RegionBox.Text))
            {
                RegionBox.BorderBrush = border;
                test = false;
            }
            else RegionBox.BorderBrush = border1;
            if (string.IsNullOrWhiteSpace(CityBox.Text))
            {
                CityBox.BorderBrush = border;
                test = false;
            }
            else CityBox.BorderBrush = border1;
            if (string.IsNullOrWhiteSpace(StreetBox.Text))
            {
                StreetBox.BorderBrush = border;
                test = false;
            }
            else StreetBox.BorderBrush = border1;
            if (string.IsNullOrWhiteSpace(NumHouseBox.Text))
            {
                NumHouseBox.BorderBrush = border;
                test = false;
            }
            else NumHouseBox.BorderBrush = border1;

            return test;
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(IsGood);
        }
        private void OnPasting(object sender, DataObjectPastingEventArgs e)
        {
            var stringData = (string)e.DataObject.GetData(typeof(string));
            if (stringData == null || !stringData.All(IsGood))
                e.CancelCommand();
        }
        bool IsGood(char c)
        {
            if (c >= '0' && c <= '9')
                return true;
            return false;
        }
    }
}
