using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace BeautyDesktopApp.Models.Entities
{
    public partial class Запись_на_услугу : IDataErrorInfo, INotifyPropertyChanged
    {
        public string this[string columnName]
        {
            get
            {
                StringBuilder errors = new StringBuilder();
                if (columnName == nameof(Дата_начала))
                    if (Дата_начала <= DateTime.Now)
                        errors.AppendLine(nameof(Дата_начала));
                if (columnName == nameof(Номер_карты) || columnName == nameof(SelectedPaymentType))
                {
                    bool isCardNull = string.IsNullOrWhiteSpace(Номер_карты);
                    bool isCardNotFull = Номер_карты?.Count(c => char.IsDigit(c)) != 16;
                    bool isPaymentByCard = SelectedPaymentType != null && (string)SelectedPaymentType.Content == "Картой";
                    if (isPaymentByCard && (isCardNull || isCardNotFull))
                    {
                        errors.AppendLine(nameof(Номер_карты));
                    }
                }

                if (columnName == nameof(ID_клиента))
                    if (ID_клиента == 0)
                        errors.AppendLine(nameof(ID_клиента));

                if (errors.Length > 0)
                {
                    IsValid = false;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Error)));
                    return errors.ToString();
                }
                else
                {
                    IsValid = true;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Error)));
                    return null;
                }
            }
        }

        public ComboBoxItem SelectedPaymentType { get; set; }

        public bool IsShouldUseCard => (string)SelectedPaymentType?.Content == "Картой";

        public string Error { get; set; }
        public bool IsValid { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
