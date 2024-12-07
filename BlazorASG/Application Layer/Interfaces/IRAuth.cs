using Application.Common.Model;
using BlazorASG.VitsModel.Auth;

namespace BlazorASG.Application_Layer.Interfaces
{
    public interface IRAuth
    {

        Task<ResponseModel<OutputRigister>> Rigister(RegisterRequest registerRequest);
        Task<ResponseModel<OutputLogin>> Login(LoginRequest loginRequest );
        Task<ResponseModel<OutputLogout>> Logout(string Token);
    }
}