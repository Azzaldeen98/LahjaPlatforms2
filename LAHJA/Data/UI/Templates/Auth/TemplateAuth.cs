using ApexCharts;
using AutoMapper;
using Domain.Entities.Auth.Request;
using Domain.Entities.Auth.Response;
using Domain.Wrapper;
using LAHJA.ApplicationLayer.Auth;
using LAHJA.Data.UI.Components.Base;
using LAHJA.Data.UI.Templates.Base;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Constants;
using Shared.Constants.Router;
using Shared.Wrapper;
using System;
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

public class TemplateAuth 
{

    //[Inject] private ClientAuthService ClientAuthService { get; set; }
    //[Inject] private IMapper _mapper { get; set; }
    //[Inject] private NavigationManager Navigation { get; set; }    

    private readonly ClientAuthService _clientAuthService;
    private readonly IMapper _mapper;
    private readonly NavigationManager _navigation;
    private readonly AppCustomAuthenticationStateProvider appCustomAuthenticationStateProvider;


    public  Func<DataBuildAuthBase, Task> OnSubmit { get; set; }
    public Func<string,Task> OnSubmitedForgetPassword { get; set; }
    public List<string>  Errors { get=>_errors; }

    private List<string> _errors ;


    public TemplateAuth(ClientAuthService clientAuthService, IMapper mapper,
        NavigationManager navigation,
        AppCustomAuthenticationStateProvider appCustomAuthenticationStateProvider)
    {
        OnSubmit = handleSubmitAsync;
        OnSubmitedForgetPassword = handleSubmitForgetPasswordAsync;
        this._clientAuthService = clientAuthService;
        _mapper = mapper;
        this._navigation = navigation;
        this.appCustomAuthenticationStateProvider = appCustomAuthenticationStateProvider;
        _errors = new List<string>();
    }

    //private LoginResponse Map(DataBuildAuthBase data)
    //{
    //    return _mapper.Map<LoginResponse>(data);
    //}

    //private DataBuildAuthBase Map(LoginResponse data)
    //{
    //    return _mapper.Map<DataBuildAuthBase>(data);
    //}


    private async Task handleSubmitAsync(DataBuildAuthBase dataBuildAuthBase)
    {

        if (dataBuildAuthBase != null)
        {
            if (dataBuildAuthBase.IsLogin)
            {
                var data= _mapper.Map<LoginRequest>(dataBuildAuthBase);
                 await handleApiLoginAsync(data);
                
            }
            else
            {
                var data = _mapper.Map<RegisterRequest>(dataBuildAuthBase);
                await handleApiRegisterAsync(data);
            }
        }

    }   
    private async Task handleSubmitForgetPasswordAsync(string email)
    {
        var response = await _clientAuthService.forgetPasswordAsync(email);
        if (response.Succeeded)
        {
 
            //_navigation.NavigateTo(RouterPage.HOME, forceLoad: true);

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
    private async Task handleApiLoginAsync(LoginRequest date)
    {
        var response = await _clientAuthService.loginAsync(date);
        if (response.Succeeded)
        {
            // toLoginMode = true;

            //appCustomAuthenticationStateProvider.StoreAuthenticationData(response.Data.accessToken);
            _navigation.NavigateTo(RouterPage.HOME, forceLoad: true);

        }
        else
        {
            if (response.Messages != null && response.Messages.Count() > 0)
            {
                // errorMessages.AddRange(response.Messages);
                _errors?.Clear();
                _errors.Add(MapperMessages.Map(ErrorMessages.INVALID_EMAIL_EN, ErrorMessages.IINVALID_EMAIL_AR));
                //Snackbar.Add(response.Messages[0], Severity.Error);
            }
        }
    }
    private async Task handleApiRegisterAsync(RegisterRequest data)
    {
        var response = await _clientAuthService.registerAsync(data);
        if (response.Succeeded)
        {
            // toLoginMode = true;
            _navigation.NavigateTo(RouterPage.LOGIN, forceLoad: true);

            //ChangeAuth();

        }
        else
        {
            if (response.Messages != null && response.Messages.Count() > 0)
            {
                // errorMessages.AddRange(response.Messages);
                _errors.Clear();
                _errors.Add(MapperMessages.Map(ErrorMessages.INVALID_EMAIL_EN, ErrorMessages.IINVALID_EMAIL_AR));
                //Snackbar.Add(response.Messages[0], Severity.Error);
            }
        }
    }



}