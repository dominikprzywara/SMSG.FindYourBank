namespace SMSG.FindYourBank.Data.Logic
{
    public interface IBankNameResolver
    {
        string GetBankName(string accountNumber);
        bool IsAccountNumberCorrect(string accountNumber);
    }
}