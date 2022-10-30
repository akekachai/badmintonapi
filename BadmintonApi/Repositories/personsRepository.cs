using BadmintonApi.Data;
using BadmintonApi.Models;
using BadmintonApi.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonApi.Repositories
{
    public class personsRepository : IpersonsRepositories<persons, int,string>
    {
        private readonly BadmintonContext _context;
        private IConfiguration _config;
        public personsRepository(BadmintonContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress)
        {
            var appuser = _context.persons.SingleOrDefault(x => x.userid == model.userid && x.password == model.password);

            if (appuser == null) return null;

            persons _person = new persons();
            //_user.Id = appuser.Id;
            _person.displayname = appuser.displayname;
            _person.userid = appuser.userid;
            _person.password = appuser.password;

            List<persons> persons = new List<persons>();

            // return null if user not found
            if (_person == null) return null;

            // authentication successful so generate jwt and refresh tokens
            var jwtToken = generateJwtToken(_person);
            var refreshToken = generateRefreshToken(ipAddress);

            List<RefreshTokens> refreshToken1 = new List<RefreshTokens>();
            refreshToken1.Add(new RefreshTokens
            {
                token = refreshToken.token,
                expires = refreshToken.expires,

            });
            // save refresh token

            persons.Add(new persons
            {
                id = appuser.id,
                userid = appuser.userid,
                password = appuser.password,
                displayname = appuser.displayname,
                activeflag = appuser.activeflag

            });

            appuser.jwtcode = jwtToken;

            appuser.expirestoken = refreshToken1[0].expires;
            appuser.refreshtoken = refreshToken.token;

            _context.SaveChanges();

            persons data = persons.SingleOrDefault();

            return new AuthenticateResponse(data, jwtToken, refreshToken.token);
        }

        public async Task<persons> GetById(int T2)
        {
            return await _context.persons.FindAsync(T2);
        }

        public async Task<IReadOnlyList<persons>> GetByUserId(string T3)
        {
            return await _context.persons.Where(p => p.userid == T3).ToListAsync(); ;
        }

        public async Task Insert(persons entity)
        {
            await _context.persons.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public AuthenticateResponse RefreshToken(string token, string ipAddress)
        {
            var appuser = _context.persons.SingleOrDefault(u => u.refreshtoken == token);

            // return null if no user found with token
            if (appuser == null) return null;

            persons _persons = new persons();
            _persons.id = appuser.id;
            _persons.displayname = appuser.displayname;
            _persons.userid = appuser.userid;
            _persons.password = appuser.password;
             _persons.activeflag = appuser.activeflag;


            var newRefreshToken = generateRefreshToken(ipAddress);


            // generate new jwt
            var jwtToken = generateJwtToken(_persons);

            appuser.jwtcode = jwtToken;

            appuser.expirestoken = newRefreshToken.expires;
            appuser.refreshtoken = newRefreshToken.token;

            _context.SaveChanges();

            return new AuthenticateResponse(_persons, jwtToken, newRefreshToken.token);
        }

        public bool RevokeToken(string token, string ipAddress)
        {
            throw new NotImplementedException();
        }

        public async Task Update(persons entity)
        {
             _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        private string generateJwtToken(persons _persons)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new  Claim(JwtRegisteredClaimNames.Sid, _persons.userid),
                new  Claim(JwtRegisteredClaimNames.Sub, _persons.displayname),
              //  new  Claim(JwtRegisteredClaimNames.Email, userinfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(15),
                signingCredentials: credentials);
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodetoken;
        }
        private RefreshTokens generateRefreshToken(string ipAddress)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {


                var randomBytes = new byte[32];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshTokens
                {
                    token = Convert.ToBase64String(randomBytes),
                    expires = DateTime.UtcNow.AddDays(1)

                };
            }
        }
    }
}
