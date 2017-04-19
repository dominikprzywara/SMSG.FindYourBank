using SMSG.FindYourBank.Data.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSG.FindYourBank.Data.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public readonly string Hint = "Gimmie account number";

        public readonly string ButtonTitle = "Check this for me";

        public string AccountNumber { get; set; }

        public string BankName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Find()
        {
            var bankNameResolver = new BankNameResolver();

            if (AccountNumber is null)
            {
                return;
            }

            BankName = bankNameResolver.GetBankName(AccountNumber);

            if (BankName is null)
            {
                BankName = "Account number is wrong";
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BankName"));
        } 
    }
}
