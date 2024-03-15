using ZapatillasConEstilo.Application.Commons.Base;
using ZapatillasConEstilo.Application.DTO.Request;

namespace ZapatillasConEstilo.Application.UseCases.Register;

public interface IRegisterUseCase
{
    Task<BaseResponse<bool>> RegisterUserAsync(UserRequestDto user);
}
