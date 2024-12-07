

using Microsoft.AspNetCore.Components;

namespace BlazorASG.Nswag
{
    public abstract class NSwagFunctions : ComponentBase
    {
        [Inject] IHttpClientFactory _apiClientFactor { get; set; }

        

        
        // [Inject] IToaster Toaster { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

     
        public async Task<AuthClient> AuthClient() => new AuthClient("http://asg.tryasp.net/", _apiClientFactor.CreateClient("LocalApi"));
     
        protected Task RefreshComponent() => InvokeAsync(StateHasChanged);
        

        //protected async Task TryCatchError(Func<Task> action)
        //{
        //    try
        //    {
        //        await action.Invoke();
        //        await RefreshComponent();
        //    }
        //    catch (ApiException<Core.NHttpCleint.ProblemDetails> ex)
        //    {
        //        if (ex.Result.Status == StatusCodes.Status401Unauthorized)
        //        {
        //            var signout = new SignOutResult(new[] { "Cookies", "oidc" });
        //        }
        //        Toaster.Error(ex.Result.Detail, ex.Result.Title);
        //    }
        //    catch (ApiException ex)
        //    {
        //        if (ex.StatusCode == StatusCodes.Status401Unauthorized)
        //        {
        //            NavigationManager.NavigateTo("/Account/Logout", true);
        //        }
        //        else Toaster.Error($"ApiError: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("refused it"))
        //        {
        //            NavigationManager.NavigateTo("/Account/Logout", true);
        //        }
        //        else Toaster.Error($"Error: {ex.Message}");
        //    }
        //}

    }
}

