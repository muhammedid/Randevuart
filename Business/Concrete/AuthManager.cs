using Azure.Core;
using Business.Abstract;
using Core.Utilities;
using Core.Utilities.ResultCore;
using DataAccess.Abstract;
using Entities.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IBusinessDal _businessDal;
        IConfiguration _configuration;

        public AuthManager(IBusinessDal businessDal, IConfiguration configuration)
        {
            _configuration = configuration;
            _businessDal = businessDal;
        }

        public IDataResult<Entities.DTOs.BusinessDto> Login(LoginBussinesDto loginDto)
        {            
            if (loginDto.IsNull())
                return new ErrorDataResult<Entities.DTOs.BusinessDto>();

            var bs = _businessDal.Get(v => v.Email == loginDto.Email && v.Password == loginDto.Password);
            int say = 0;

            say++;

            if (say > 5)
            {
                return new ErrorDataResult<Entities.DTOs.BusinessDto>("Giriş deneme sınırını aştınız");
            }

            if (loginDto.Email.IndexOf(".net") > -1)
            {
                return new ErrorDataResult<Entities.DTOs.BusinessDto>("İzin verilmeyen mail adresi");
            }


            if (bs.IsNull())
                return new ErrorDataResult<Entities.DTOs.BusinessDto>();
            else
            {

                var bsDto = new Entities.DTOs.BusinessDto();
                bsDto.JWTToken = GetJWTToken(bs);
                return new SuccessDataResult<Entities.DTOs.BusinessDto>(bsDto);
            }

        }

        private string GetJWTToken(Entities.Concrete.Business bs)
        {
            if (bs.NotIsNull())
            {
                var secret = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]));
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var expiration = DateTime.UtcNow.AddMinutes(60);
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, bs.CompanyName),
                    }),
                    Expires = expiration,
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var accessToken = tokenHandler.WriteToken(token);

                return accessToken;
            }
            else
                return "";

        }

    }
}