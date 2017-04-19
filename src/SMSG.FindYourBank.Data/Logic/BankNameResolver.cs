using SMSG.FindYourBank.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SMSG.FindYourBank.Data.Logic
{
    public class BankNameResolver : IBankNameResolver
    {
        private readonly int[] _weightVector = { 7, 1, 3, 9, 7, 1, 3 };

        private readonly string _countryCode = "2521";

        private readonly int _accountNumberLength = 26;

        //83 1010 1023 0000 2613 9510 0000
        //PL83 1010 1023 0000 2613 9510 0000
        //1010 1023 0000 2613 9510 0000PL83
        //1010 1023 0000 2613 9510 0000252183
        public bool IsAccountNumberCorrect(string accountNumber)
        {
            accountNumber = accountNumber.Replace(" ", String.Empty);

            if(accountNumber.Length != _accountNumberLength)
            {
                return false;
            }

            var checkSum = accountNumber.Substring(0, 2);
            var accountNumberWithoutCheckSum = accountNumber.Substring(2);
            var accountNumberToCheck = accountNumberWithoutCheckSum + _countryCode + checkSum;

            if (BigInteger.Parse(accountNumberToCheck) % 97 != 1)
            {
                return false;
            }

            var sum = 0;
            var bankCodeWithDivison = accountNumber.Substring(2, 8);

            for (int i = 0; i < _weightVector.Length; ++i)
            {
                sum += _weightVector[i] * Int32.Parse(bankCodeWithDivison[i].ToString());
            }

            if (sum % 10 != Int32.Parse(bankCodeWithDivison.Last().ToString()))
            {
                return false;
            }

            return true;
        }

        public string GetBankName(string accountNumber)
        {
            accountNumber = accountNumber.Replace(" ", String.Empty);

            if (!IsAccountNumberCorrect(accountNumber))
            {
                return null;
            }

            var service = new BankService();
            var banks = service.GetBanks();

            var bankCode = accountNumber.Substring(2, 4);

            return banks.FirstOrDefault(b => b.SortCodes.Contains(bankCode))?.Name;
        }
    }
}
