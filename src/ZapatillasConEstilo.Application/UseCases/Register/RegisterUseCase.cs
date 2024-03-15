using ZapatillasConEstilo.Application.Commons.Base;
using ZapatillasConEstilo.Application.DTO.Request;

namespace ZapatillasConEstilo.Application.UseCases.Register;

public class RegisterUseCase : IRegisterUseCase
{
    // private readonly IUnitOfWork _unitOfWork;

    public Task<BaseResponse<bool>> RegisterUserAsync(UserRequestDto user)
    {
        var response = new BaseResponse<bool>();
        return Task.FromResult(response);
    }
}
