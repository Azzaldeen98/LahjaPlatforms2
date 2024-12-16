

namespace LAHJA.Data.UI.Components.Payment.CreditCards
{
    public class CreditCardInput
    {
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CardHolder { get; set; }
        public string CardType { get; set; }
    }
    public class CreditCardDisplay
    {
        public string CardNumber { get; set; }    // رقم البطاقة، يمكننا إخفاء بعض الأرقام مثل "****"
        public string ExpiryDate { get; set; }    // تاريخ الانتهاء
        public string CardHolder { get; set; }    // اسم صاحب البطاقة
        public string CardType { get; set; }      // نوع البطاقة (ماستر كارد، فيزا، إلخ)
        public bool IsSelected { get; set; }      // هل البطاقة مختارة أم لا
    }
}
