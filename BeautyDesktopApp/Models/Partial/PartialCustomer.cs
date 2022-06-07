using System;
using System.ComponentModel;
using System.Linq;

namespace BeautyDesktopApp.Models.Entities
{
    public partial class Клиент : IDataErrorInfo, INotifyPropertyChanged
    {
        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(ФИО) && string.IsNullOrWhiteSpace(ФИО))
                {
                    return nameof(ФИО);
                }

                if (columnName == nameof(Логин) && string.IsNullOrWhiteSpace(Логин))
                {
                    return nameof(Логин);
                }

                if (columnName == nameof(Пароль) && string.IsNullOrWhiteSpace(Пароль))
                {
                    return nameof(Пароль);
                }

                if (columnName == nameof(Дата_рождения) && (Дата_рождения == null || !Дата_рождения.HasValue || Дата_рождения >= DateTime.Now))
                {
                    return nameof(Дата_рождения);
                }
                else
                if (columnName == nameof(Номер_телефона) && (string.IsNullOrWhiteSpace(Номер_телефона) || Номер_телефона.Count(n => char.IsDigit(n)) != 11))
                {
                    return nameof(Номер_телефона);
                }
                return null;
            }
        }

        public string Error => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsValid => !string.IsNullOrWhiteSpace(ФИО)
                               && !string.IsNullOrWhiteSpace(Логин)
                               && !string.IsNullOrWhiteSpace(Пароль)
                               && Дата_рождения != null && Дата_рождения.HasValue && Дата_рождения.Value < DateTime.Now
                               && !string.IsNullOrWhiteSpace(Номер_телефона) && Номер_телефона.Count(n => char.IsDigit(n)) == 11;
    }
}
