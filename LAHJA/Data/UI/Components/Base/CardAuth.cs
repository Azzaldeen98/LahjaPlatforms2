
using Blazorise.Captcha.ReCaptcha;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using MudBlazor;
using Shared.Enums;
using Shared.Models;
using Shared.Wrapper;
using System.Text.RegularExpressions;

namespace LAHJA.Data.UI.Components.Base
{
   public enum TypeAuth
    {
        Login
    }


    public interface IAuthBaseComponentCard
    {
        
    }

    public class DataBuildAuth
    {

        private string email = "test@gmail.com";
        private string password = "Test@123";

      
    }



    public class DataBuildAuthBase
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set; }
        public bool IsLogin { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }


    public class CardAuth<T> : ComponentBaseCard<T>
    {
        public override TypeComponentCard Type => throw new NotImplementedException();

        public override void Build(T db)
        {
            DataBuild = db;
        }



        [Parameter] public EventCallback<T> OnSubmit { get; set; }
        [Parameter] public bool IsLogin { set; get; } = false;
        [Parameter] public EventCallback<string> OnSubmitedForgetPassword { get; set; }
        [Parameter] public List<string> ErrorMessages
        {
            set
            {
                if (value != null && value.Count() > 0)
                    errors = value.ToArray();
            }
        }

        protected bool success;
        protected string[] errors = { };
        protected MudTextField<string> pwField1;
        protected MudForm form;
        protected bool visibleForgetPassword = false;

        protected string phoneNumber;
        protected string email = "test@gmail.com";
        protected string password = "Test@123";
        protected string repeatPassword;



        protected IEnumerable<string> PasswordStrength(string pw)
        {
            if (string.IsNullOrWhiteSpace(pw))
            {
                yield return "Password is required!";
                yield break;


            }
            if (pw.Length < 8)
                yield return "Password must be at least of length 8";
            if (!Regex.IsMatch(pw, @"[A-Z]"))
                yield return "Password must contain at least one capital letter";
            if (!Regex.IsMatch(pw, @"[a-z]"))
                yield return "Password must contain at least one lowercase letter";
            if (!Regex.IsMatch(pw, @"[0-9]"))
                yield return "Password must contain at least one digit";
        }

        protected string PasswordMatch(string arg)
        {
            repeatPassword = pwField1.Value;
            if (pwField1.Value != arg)
                return "Passwords don't match";
            return null;
        }

        protected async Task onClickForgetPassword()
        {
            visibleForgetPassword = true;

            StateHasChanged();
        }

        

      

    }

    public class InputFieldProperties
    {
        public string T { set; get; } = "string";
        public bool Disabled { get; set; } = false;
        public bool Required { get; set; } = true;
        public string Label { get; set; } = string.Empty;
        public string RequiredError { get; set; } = string.Empty;
    }

    public interface ICardInput
    {
        InputFieldProperties Properties { set; get; }
    }
    public class CardInput<T> : ComponentBaseCard<T>, ICardInput
    {
        public override TypeComponentCard Type => throw new NotImplementedException();

        public InputFieldProperties Properties { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Build(T db)
        {
            DataBuild = db;
        }
    }

}