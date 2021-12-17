using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektsAgents.Classes
{
    public class DataFiltersList
    {
        public string Title { get; set; }

        public List<DataFiltersList> AddData()
        {
            //Заполнение списка типов агентов
            List<DataFiltersList> dataFiltersList = new List<DataFiltersList>()
            {
                new DataFiltersList { Title = "Нет фильтров"},
                new DataFiltersList { Title = "Название(А-Я)"},
                new DataFiltersList { Title = "Название(Я-А)"},
                new DataFiltersList { Title = "Размер скидки(Max-Min)"},
                new DataFiltersList { Title = "Размер скидки(Min-Max)"},
                new DataFiltersList { Title = "Приоритет(Max-Min)"},
                new DataFiltersList { Title = "Приоритет(Min-Max)"}
            };
            return dataFiltersList;//возврат списка
        }
    }

}
