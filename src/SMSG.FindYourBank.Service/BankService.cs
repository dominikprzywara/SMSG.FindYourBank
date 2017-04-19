using Newtonsoft.Json;
using SMSG.FindYourBank.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SMSG.FindYourBank.Service
{
    public class BankService : IBankService
    {
        public IList<Bank> GetBanks()
        {
            var fileContent = String.Empty;

            using (var sr = new StreamReader(
                GetType().GetTypeInfo().Assembly.GetManifestResourceStream("SMSG.FindYourBank.Service.Banks.txt")))
            {
                fileContent = sr.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<IList<Bank>>(fileContent);
        }
    }
}
