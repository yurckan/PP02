using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektsAgents.Classes
{
    public class DBManager
    {
        public static PrEntities context;
        public static PrEntities GetContext()
        {
            if (context == null)
                context = new PrEntities();
            return context;
        }
    }
}
