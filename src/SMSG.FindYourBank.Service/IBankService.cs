using System.Collections.Generic;
using SMSG.FindYourBank.Model;

namespace SMSG.FindYourBank.Service
{
    public interface IBankService
    {
        IList<Bank> GetBanks();
    }
}