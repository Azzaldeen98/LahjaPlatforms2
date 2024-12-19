using AutoMapper;
using Domain.Entities.Auth.Request;
using Domain.Entities.Auth.Response;
using Domain.Wrapper;
using LAHJA.ApplicationLayer.Auth;
using LAHJA.Data.UI.Components.Base;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Constants;
using Shared.Constants.Router;
using Shared.Wrapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LAHJA.Data.UI.Templates.Auth;


public enum TypeTemplateAuth
{

}


//public interface ITemplateAuth : ITemplateBase<DataBuildAuthBase, LoginResponse>
//{


//}

//}//public interface ITemplateAuth : ITemplateBase<DataBuildAuthBase,LoginResponse>
//{

//}
//public class TemplateAuth: TemplateBase<DataBuildAuthBase, LoginResponse>, ITemplateAuth
//{


//    public EventCallback<DataBuildAuthBase> OnSubmit { get; set; }

//    public EventCallback<string> OnSubmitedForgetPassword { get; set; }

//    public override DataBuildAuthBase Map(LoginResponse data)
//    {
//        throw new NotImplementedException();
//    }


//}
public interface IBuilderAuthComponent<T>: IBuilderComponents<T>
{
    public Func<T, Task> Submit { get; set; }
    public Func<T, Task> SubmitedForgetPassword { get; set; }
    public Func<T, Task> SubmitConfirmEmail { get; set; }
    public Func<T, Task> SubmitReSendConfirmEmail { get; set; }
    public Func<T, Task> SubmitResetPassword { get; set; }


}



public interface IBuilderAuthApi<T> : IBuilderApi<T>
{

     Task<Result<LoginResponse>> Login(T data);
     Task<Result<RegisterResponse>> Register(T data);
     Task<Result<ResetPasswordResponse>> ResetPassword(T data);
     Task<Result> ReSendConfirmationEmail(T data);
     Task<Result> SubmitConfirmEmail(T data);
     Task<Result> ForgetPassword(T data);
    

}

public abstract class BuilderAuthApi<T,E> : BuilderApi<T,E>, IBuilderAuthApi<E> 
{

    public BuilderAuthApi(IMapper mapper, T service) : base(mapper,service)
    {
      
    }
    public abstract Task<Result> ForgetPassword(E data);

    public abstract Task<Result<LoginResponse>> Login(E data);

    public abstract Task<Result<RegisterResponse>> Register(E data);
   
    public abstract Task<Result> ReSendConfirmationEmail(E data);

    public abstract Task<Result<ResetPasswordResponse>> ResetPassword(E data);

    public abstract Task<Result> SubmitConfirmEmail(E data);
   
}
public class BuilderAuthComponent<T> : IBuilderAuthComponent<T>
{
    public Func<T, Task> Submit { get ; set ; }
    public Func<T, Task> SubmitedForgetPassword { get; set; }
    public Func<T, Task> SubmitConfirmEmail { get; set; }
    public Func<T, Task> SubmitReSendConfirmEmail { get; set; }
    public Func<T, Task> SubmitResetPassword { get; set; }

}


public class TemplateAuthShare<T,E> : TemplateBase<T,E>
{
    protected readonly NavigationManager navigation;
    protected readonly IDialogService dialogService;
    protected readonly ISnackbar Snackbar;
    protected IBuilderAuthApi<E> builderApi;
    protected AppCustomAuthenticationStateProvider customAuthenticationStateProvider;

    private readonly IBuilderAuthComponent<E> builderComponents;
    public  IBuilderAuthComponent<E> BuilderComponents { get => builderComponents; }
    public TemplateAuthShare(
        
           IMapper mapper, 
           AuthService authService, 
            T client,
            AppCustomAuthenticationStateProvider customAuthenticationStateProvider,
            IBuilderAuthComponent<E> builderComponents,
            NavigationManager navigation,
            IDialogService dialogService,
            ISnackbar snackbar


        ) : base(mapper, authService, client)
    {


      
        builderComponents = new BuilderAuthComponent<E>();
        this.navigation = navigation;
        this.dialogService = dialogService;
        this.Snackbar = snackbar;
        //this.builderApi = builderApi;
        this.builderComponents = builderComponents;

        
    }

}


public class BuilderAuthApiClient : BuilderAuthApi<ClientAuthService, DataBuildAuthBase>, IBuilderAuthApi<DataBuildAuthBase>
{
    public BuilderAuthApiClient(IMapper mapper, ClientAuthService service) : base(mapper, service)
    {
    }

    public override async Task<Result> ForgetPassword(DataBuildAuthBase data)
    {
        var model = Mapper.Map<ForgetPasswordRequest>(data);


        return await Service.forgetPasswordAsync(model);
    }

    public override async Task<Result<LoginResponse>> Login(DataBuildAuthBase data)
    {
        var model = Mapper.Map<LoginRequest>(data);

         return await Service.loginAsync(model);
       
    }

    public override async Task<Result<RegisterResponse>> Register(DataBuildAuthBase data)
    {
        var model = Mapper.Map<RegisterRequest>(data);

        return await Service.registerAsync(model);
    }

    public override async Task<Result> ReSendConfirmationEmail(DataBuildAuthBase data)
    {
        var model = Mapper.Map<ResendConfirmationEmail>(data);

        return await Service.reConfirmationEmailAsync(model);
    }

    public override async Task<Result<ResetPasswordResponse>> ResetPassword(DataBuildAuthBase data)
    {
        var model = Mapper.Map<ResetPasswordRequest>(data);

        return await Service.resetPasswordAsync(model);
    }

    public override async Task<Result> SubmitConfirmEmail(DataBuildAuthBase data)
    {
        var model = Mapper.Map<ConfirmationEmail>(data);

        return await Service.confirmationEmailAsync(model);
    }
}


public class TemplateAuth: TemplateAuthShare<ClientAuthService, DataBuildAuthBase>
{
  
    public TemplateAuth(IMapper mapper,
        AuthService authService, 
        ClientAuthService client,
        AppCustomAuthenticationStateProvider customAuthenticationStateProvider, 
        IBuilderAuthComponent<DataBuildAuthBase> builderComponents, 
        NavigationManager navigation, 
        IDialogService dialogService, 
        ISnackbar snackbar) : base(mapper, authService, client, customAuthenticationStateProvider, builderComponents, navigation, dialogService, snackbar)
    {
        this.BuilderComponents.Submit = OnSubmit;
        this.BuilderComponents.SubmitConfirmEmail = OnSubmitConfirmEmail;
        this.BuilderComponents.SubmitReSendConfirmEmail = OnReSendConfirmationEmail;
        this.BuilderComponents.SubmitResetPassword = OnResetPassword;
        this.BuilderComponents.SubmitedForgetPassword = OnSubmitForgetPasswordAsync;
        this.builderApi = new BuilderAuthApiClient(mapper,client);

    }

  

    public List<string> Errors { get => _errors; }


    //public  IBuilderAuthComponent<DataBuildAuthBase, DataBuildAuthBase> BuilderAuthComponent { get => builderAuthComponents; }
    


    protected async Task OnReSendConfirmationEmail(DataBuildAuthBase dataBuildAuthBase)
    {
        var response = await builderApi.ReSendConfirmationEmail(dataBuildAuthBase);
        if (response.Succeeded)
        {

            navigation.NavigateTo(RouterPage.HOME, forceLoad: true);

        }
        else
        {
            if (response.Messages != null && response.Messages.Count() > 0)
            {

                _errors?.Clear();
                _errors.Add(MapperMessages.Map(ErrorMessages.INVALID_EMAIL_EN, ErrorMessages.IINVALID_EMAIL_AR));

            }
        }
    }

    protected async Task OnResetPassword(DataBuildAuthBase dataBuildAuthBase)
    {
        var response = await builderApi.ResetPassword(dataBuildAuthBase);
        if (response.Succeeded)
        {

            navigation.NavigateTo(RouterPage.HOME, forceLoad: true);

        }
        else
        {
            if (response.Messages != null && response.Messages.Count() > 0)
            {

                _errors?.Clear();
                _errors.Add(MapperMessages.Map(ErrorMessages.INVALID_EMAIL_EN, ErrorMessages.IINVALID_EMAIL_AR));

            }
        };
    }

    protected async Task OnSubmitConfirmEmail(DataBuildAuthBase dataBuildAuthBase)
    {

        var response = await builderApi.SubmitConfirmEmail(dataBuildAuthBase);
        if (response.Succeeded)
        {

            navigation.NavigateTo(RouterPage.HOME, forceLoad: true);

        }
        else
        {
            if (response.Messages != null && response.Messages.Count() > 0)
            {

                _errors?.Clear();
                _errors.Add(MapperMessages.Map(ErrorMessages.INVALID_EMAIL_EN, ErrorMessages.IINVALID_EMAIL_AR));

            }
        }
    }
    private async Task OnSubmit(DataBuildAuthBase dataBuildAuthBase)
    {

        if (dataBuildAuthBase != null)
        {
            if (dataBuildAuthBase.IsLogin)
            {

               
                await handleApiLoginAsync(dataBuildAuthBase);

            }
            else
            {
         
                await handleApiRegisterAsync(dataBuildAuthBase);
            }
        }

    }

    
    private async Task OnSubmitForgetPasswordAsync(DataBuildAuthBase data)
    {
        var response = await builderApi.ForgetPassword(data);
        if (response.Succeeded)
        {

            navigation.NavigateTo("/ForgetPassword", forceLoad: true);

        }
        else
        {
            if (response.Messages != null && response.Messages.Count() > 0)
            {

                _errors?.Clear();
                _errors.Add(MapperMessages.Map(ErrorMessages.INVALID_EMAIL_EN, ErrorMessages.IINVALID_EMAIL_AR));

            }
        }
    }
    private async Task handleApiLoginAsync(DataBuildAuthBase date)
    {
        var response =await builderApi.Login(date);
  
        if (response.Succeeded)
        {

            try
            {
                if(response.Data.accessToken!=null)
                    customAuthenticationStateProvider.StoreAuthenticationData(response.Data.accessToken);
            }
            finally
            {
                navigation.NavigateTo(RouterPage.HOME, forceLoad: true);
            }

        }
        else
        {
            if (response.Messages != null && response.Messages.Count() > 0)
            {
                // errorMessages.AddRange(response.Messages);
                _errors.Clear();
                if (response.Messages.Count > 0)
                {
                    if (response.Messages[0].Contains("Unauthorized"))
                        _errors.Add(MapperMessages.Map(ErrorMessages.INVALID_EMAIL_EN, ErrorMessages.IINVALID_EMAIL_AR));
                    else
                        _errors.AddRange(response.Messages);
                }
            }
        }
    }
    private async Task handleApiRegisterAsync(DataBuildAuthBase data)
    {
        var response = await builderApi.Register(data);
        if (response.Succeeded)
        {
            navigation.NavigateTo(RouterPage.LOGIN, forceLoad: true);

        }
        else
        {
            if (response.Messages != null && response.Messages.Count() > 0)
            {
                _errors.Clear();
                if (response.Messages.Count > 0)
                {
                    if (response.Messages[0].Contains("Unauthorized"))
                        _errors.Add(MapperMessages.Map(ErrorMessages.INVALID_EMAIL_EN, ErrorMessages.IINVALID_EMAIL_AR));
                    else
                        _errors.AddRange(response.Messages);

                    Snackbar.Add(response.Messages[0], Severity.Error);
                }
            }
        }
    }



}








//public class TemplateAuth
//{

//    [Inject] public ClientAuthService ClientAuthService { get; set; }
//    [Inject] public IMapper Mapper { get; set; }
//    [Inject] public NavigationManager Navigation { get; set; }

//    [Inject] public AppCustomAuthenticationStateProvider appCustomAuthenticationStateProvider { get; set; }

//    //private readonly ClientAuthService _clientAuthService;
//    //private readonly IMapper mapper;
//    //private readonly NavigationManager Navigation;
//    //private readonly AppCustomAuthenticationStateProvider appCustomAuthenticationStateProvider;


//    public Func<DataBuildAuthBase, Task> OnSubmit { get; set; }
//    public Func<string, Task> OnSubmitedForgetPassword { get; set; }
//    public List<string> Errors { get => _errors; }

//    private List<string> _errors=new List<string>();


//    public TemplateAuth(
//        //ClientAuthService clientAuthService, 
//        //IMapper mapper,
//        //NavigationManager navigation,
//        //AppCustomAuthenticationStateProvider appCustomAuthenticationStateProvider
//        )
//    {
//        OnSubmit = handleSubmitAsync;
//        OnSubmitedForgetPassword = handleSubmitForgetPasswordAsync;
//        //this._clientAuthService = clientAuthService;
//        //mapper = mapper;
//        //this.Navigation = navigation;
//        //this.appCustomAuthenticationStateProvider = appCustomAuthenticationStateProvider;
//        //_errors = new List<string>();
//    }

////private LoginResponse Map(DataBuildAuthBase data)
////{
////    return mapper.Map<LoginResponse>(data);
////}

////private DataBuildAuthBase Map(LoginResponse data)
////{
////    return mapper.Map<DataBuildAuthBase>(data);
////}


//private async Task handleSubmitAsync(DataBuildAuthBase dataBuildAuthBase)
//{

//    if (dataBuildAuthBase != null)
//    {
//        if (dataBuildAuthBase.IsLogin)
//        {
//            var data = Mapper.Map<LoginRequest>(dataBuildAuthBase);
//            await handleApiLoginAsync(data);

//        }
//        else
//        {
//            var data = Mapper.Map<RegisterRequest>(dataBuildAuthBase);
//            await handleApiRegisterAsync(data);
//        }
//    }

//}
//private async Task handleSubmitForgetPasswordAsync(string email)
//{
//    var response = await ClientAuthService.forgetPasswordAsync(email);
//    if (response.Succeeded)
//    {

//        //Navigation.NavigateTo(RouterPage.HOME, forceLoad: true);

//    }
//    else
//    {
//        if (response.Messages != null && response.Messages.Count() > 0)
//        {

//            _errors?.Clear();
//            _errors.Add(MapperMessages.Map(ErrorMessages.INVALID_EMAIL_EN, ErrorMessages.IINVALID_EMAIL_AR));

//        }
//    }
//}
//private async Task handleApiLoginAsync(LoginRequest date)
//{
//    var response = await ClientAuthService.loginAsync(date);
//    if (response.Succeeded)
//    {
//        // toLoginMode = true;

//        //appCustomAuthenticationStateProvider.StoreAuthenticationData(response.Data.accessToken);
//        Navigation.NavigateTo(RouterPage.HOME, forceLoad: true);

//    }
//    else
//    {
//        if (response.Messages != null && response.Messages.Count() > 0)
//        {
//            // errorMessages.AddRange(response.Messages);
//            _errors?.Clear();
//            _errors.Add(MapperMessages.Map(ErrorMessages.INVALID_EMAIL_EN, ErrorMessages.IINVALID_EMAIL_AR));
//            //Snackbar.Add(response.Messages[0], Severity.Error);
//        }
//    }
//}
//private async Task handleApiRegisterAsync(RegisterRequest data)
//{
//    var response = await ClientAuthService.registerAsync(data);
//    if (response.Succeeded)
//    {
//        // toLoginMode = true;
//        Navigation.NavigateTo(RouterPage.LOGIN, forceLoad: true);

//        //ChangeAuth();

//    }
//    else
//    {
//        if (response.Messages != null && response.Messages.Count() > 0)
//        {
//            // errorMessages.AddRange(response.Messages);
//            _errors.Clear();
//            _errors.Add(MapperMessages.Map(ErrorMessages.INVALID_EMAIL_EN, ErrorMessages.IINVALID_EMAIL_AR));
//            //Snackbar.Add(response.Messages[0], Severity.Error);
//        }
//    }
//}



//}