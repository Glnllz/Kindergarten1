using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten1.DataBases
{
    public class data
    {
        public static DSADEntities _dbConnection = new DSADEntities();

        // Метод для получения подключения к базе данных
        public static DSADEntities GetContext()
        {
            if (_dbConnection == null)
            {
                _dbConnection = new DSADEntities();
            }
            return _dbConnection;
        }
        public static List<user> GetUser()
        {
            return _dbConnection.user.ToList();
        }
    }
}
