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

namespace ProektsAgents.Classes
{
    /// <summary>
    /// Логика взаимодействия для PriortiyChange.xaml
    /// </summary>
    public partial class PriortiyChange : Window
    {
        bool Prioritet = true;
        List<Agent> products;
        public PriortiyChange(List<Agent> selectedProducts)
        {
            InitializeComponent();
            products = selectedProducts;
        }

        private void SaveChangesBtn_Click(object sender, RoutedEventArgs e)//Сохранение
        {
            if (CountTB.Text != "")
            {
                foreach (Agent product in products)
                {
                    if(Prioritet == true)
                        product.Priority += Convert.ToInt32(CountTB.Text);
                    else
                        product.Priority -= Convert.ToInt32(CountTB.Text);
                }

                DBManager.GetContext().SaveChanges();

                MessageBox.Show("Приоритет изменен!",
                    "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
                MessageBox.Show("Поле не должно быть пустым!",
                    "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            Prioritet = false;
            label1.Content = "Уменьшить приоритет агентов на...";
        }
        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            Prioritet = true;
            label1.Content = "Увеличить приоритет агентов на...";
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
