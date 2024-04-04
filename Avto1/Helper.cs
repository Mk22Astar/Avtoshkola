using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avto1
{
    internal class Helper
    {
        private static AvtoshkolaContext s_restoranEntities = GetContext(); // Создание статичной приватной переменной, для обращения к контексту модели данных
                                                                           // Метод (публичный, чтобы к нему можно было обратиться из любой части программы) получения контекста данных, необходимый для создания подключения к базе данных
        public static AvtoshkolaContext GetContext()
        {
            if (s_restoranEntities == null) // Условие при котором проверяется, если подключение не установлено, то необходимо создать новое подключение
            {
                s_restoranEntities = new AvtoshkolaContext(); // Соединение нового подключения к базе данных
            }
            return s_restoranEntities; // в противном случае, вернуть ранее созданное подключение
        }

    }
}
