using ProektsAgents.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProektsAgents
{
    public partial class MainWindow : Window
    {
        int CountPages;//Кол-во страниц
        int CountAgentsPage = 10;//Кол-во агентов на одной странице
        int numPage = 1;//Номер странице
        int FilterType =0;//Номер фильтра(тип фильтра)
        DataFiltersList dataFilters = new DataFiltersList();//Обращение к классу с данными фильтрации
        List<Agent> selectedProducts = new List<Agent>(); //Получение списка агентов
        public MainWindow()
        {
            InitializeComponent();
            AgentTypeComboBox(DBManager.GetContext().AgentType.ToList());
            DataListBox(GetProductList());
            AddFilters(dataFilters.AddData());
        }

        private void AddFilters(List<DataFiltersList> dataFiltersLists)//Добавление фильтров в список (Cmb)
        {
            FilterCmb.ItemsSource = dataFiltersLists;//Добавление данных
            FilterCmb.SelectedIndex = 0;//выбор первого элемента из списка
        }

        //Получение списока типов агентов и запись в список (Cmb)
        private void AgentTypeComboBox(List<AgentType> agentTypes)
        {
            AgentType typeAll = new AgentType { Title = "Все типы" };
            typeAll.Title = "Все типы";
            agentTypes.Insert(0, typeAll);
            AgentTypeCmb.ItemsSource = agentTypes;
            AgentTypeCmb.SelectedIndex = 0;
        }

        private List<Agent> GetProductList()//Получение данных из бд (Таблица Agent)
        {
            return DBManager.GetContext().Agent.ToList();
        }

        private void DataListBox(List<Agent> agent)//Вывод данных
        {
            if (!string.IsNullOrWhiteSpace(SearchTextBox.Text))//Поиск через textBox по наименованию агента
                agent = agent.Where(x => x.Title.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            
            if (AgentTypeCmb.SelectedIndex != 0)//Выбор типа агентов
            {
                AgentType selectedType = AgentTypeCmb.SelectedItem as AgentType;
                agent = agent.Where(x => x.AgentType == selectedType).ToList();
            }
            if(FilterType!=0)//Фильтры
            agent = FiltersAgentList(agent);

            //Навигация по страницам
            CountPages = (int)Math.Ceiling((double)agent.Count / CountAgentsPage);//опр. кол-ва страниц
            CountPagesLb.Content = numPage + " / " + CountPages;//отображение текущей страници 

            agent = agent.Skip((numPage - 1) * CountAgentsPage).Take(CountAgentsPage).ToList();//Получение новых агентов
            ProductListBox.ItemsSource = agent;//вывод агентов
            
        }

        private List<Agent> FiltersAgentList(List<Agent> products)//Фильтрация
        {
            switch (FilterType)
            {
                case 1: products = products.OrderBy(x => x.Title).ToList(); break;
                case 2: products = products.OrderByDescending(x => x.Title).ToList(); break;
                case 3: products = products.OrderBy(x => x.Discount).ToList(); break;
                case 4: products = products.OrderByDescending(x => x.Discount).ToList(); break;
                case 5: products = products.OrderBy(x => x.Priority).ToList(); break;
                case 6: products = products.OrderByDescending(x => x.Priority).ToList(); break;
            }
            return products;
        }

        private void AgentTypeCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)//Выбор типов агентов
        {
            numPage = 1;//Переход на первую страницу
            DataListBox(GetProductList());//Вывод данных
        }
        //Выбор фильтра и вывод результата
        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterType = (int)FilterCmb.SelectedIndex;//Выбранный фильтр из списка
            DataListBox(GetProductList());//Вывод данных
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)//Поиск по наимен. агента 
        {
            DataListBox(GetProductList());//Вывод данных
        }
        private void Btn_Click(object sender, RoutedEventArgs e)//Пагинация
        {
            //Определяем нажатую кнопку по его тексту
            string test = sender.ToString().Remove(0, sender.ToString().IndexOf(": ")+2);
            switch(test)
            {
                case "|<": numPage = 1; break;
                case "<": numPage--; break;
                case ">": numPage++; break;
                case ">|": numPage = CountPages; break;
                case "Добавить":
                    EditProductWindow editProductWindow = new EditProductWindow();
                    editProductWindow.Show();
                    break;
                case "Изменить приоритет":
                    if (selectedProducts.Count != 0)
                    {
                        new PriortiyChange(selectedProducts).ShowDialog();
                        selectedProducts.Clear();
                        DataListBox(GetProductList());
                    }
                    else 
                        MessageBox.Show("Сделайте выбор нужных агентов", "Информация",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case "Редактировать":
                    new EditProductWindow((sender as Button).DataContext as Agent).ShowDialog();
                    DataListBox(GetProductList());
                    break;
            }
            //Граница страниц
            if (numPage > CountPages)
                numPage = CountPages;
            else if (numPage <= 0)
                numPage = 1;
            else
            DataListBox(GetProductList());//Вывод данных
        }

        private void CheckBox1_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
                selectedProducts.Add((sender as CheckBox).DataContext as Agent);
            else
                selectedProducts.Remove((sender as CheckBox).DataContext as Agent);
        }
    }
}

