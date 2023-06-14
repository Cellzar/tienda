using API.Dtos;
namespace API.Services;

public interface IUsuarioService
{
    Task<string> RegisterAsync(RegisterDto model);
    Task<DatosUsuarioDto> GetTokenAsync(LoginDto model);
    Task<string> AddRoleAsync(AddRoleDto model);
    Task<DatosUsuarioDto> RefreshTokenAsync(string refreshToken);
}
