﻿

namespace LAHJA.Data.UI.Components.Payment.Billing
{
    public class BillingContact
    {
        public string FullName { get; set; } = "Azdeen Talal";
        public string Email { get; set; } = "EngneerAzdd@gmail.com";
        public string SecondaryEmail { get; set; } = "EngneerAddzdd@gmail.com";
        public string MobilePhoneNumber { get; set; } = "+967774355690";
        public string Address1 { get; set; } = "Ibb";
        public string Address2 { get; set; } = "Tas";
        public string City { get; set; } = "Ibb";
        public string State { get; set; } = "dd";
        public string ZipCode { get; set; } = "dd";
        public string Country { get; set; } = "Yeman";
        public string BillingRegistrationNumber { get; set; } = "88";
        public string VatNumber { get; set; } = "hhh";
        public string Currency { get; set; } = "hh";
    }



  
    public class BillingSummary
    {
        public string NextPaymentAmount { get; set; } = "";
        public string UsageLink { get; set; } = "";
    }

    public class PaymentInfo
    {
        public string Title { get; set; } = "";
        public List<string> Links { get; set; } = new List<string>();
    }




}
