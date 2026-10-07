using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using sahadLearn.API.models.DTO.auth;
using sahadLearn.API.Repository;

namespace sahadLearn.API.Controllers
{

    public class AuthContrller : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepo repo;
        public AuthContrller(UserManager<IdentityUser> userManager, ITokenRepo repo)
        {
            this.userManager = userManager;
            this.repo = repo;

        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] registerRequstDTO request)
        {
            var user = new IdentityUser
            {
                UserName = request.UserName,
                Email = request.Email
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await userManager.AddToRoleAsync(user, request.UserRole);

            return Ok("User registered successfully.");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] loginRequestDTO request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user == null || !await userManager.CheckPasswordAsync(user, request.Password))
            {
                return BadRequest("Invalid email or password.");
            }

            var roles = await userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();

            if (role == null)
            {
                return BadRequest("User has no role assigned.");
            }

            var jwtToken = repo.createToken(user, role);

            var response = new loginResponseDTO
            {
                UserName = user.UserName!,
                Email = user.Email!,
                JwtToken = jwtToken
            };

            return Ok(new { result = response });
        }
    }
    
}
