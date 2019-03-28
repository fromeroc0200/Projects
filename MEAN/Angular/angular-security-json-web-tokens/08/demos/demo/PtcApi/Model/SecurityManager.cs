using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PtcApi.Model;

namespace PtcApi.Security
{
  public class SecurityManager
  {
    private JwtSettings _settings = null;
    public SecurityManager(JwtSettings settings)
    {
      _settings = settings;
    }

    public AppUserAuth ValidateUser(AppUser user)
    {
      AppUserAuth ret = new AppUserAuth();
      AppUser authUser = null;

      using (var db = new PtcDbContext())
      {
        // Attempt to validate user
        authUser = db.Users.Where(
          u => u.UserName.ToLower() == user.UserName.ToLower()
          && u.Password == user.Password).FirstOrDefault();
      }

      if (authUser != null)
      {
        // Build User Security Object
        ret = BuildUserAuthObject(authUser);
      }

      return ret;
    }

    protected List<AppUserClaim> GetUserClaims(AppUser authUser)
    {
      List<AppUserClaim> list = new List<AppUserClaim>();

      try
      {
        using (var db = new PtcDbContext())
        {
          list = db.Claims.Where(
                   u => u.UserId == authUser.UserId).ToList();
        }
      }
      catch (Exception ex)
      {
        throw new Exception(
            "Exception trying to retrieve user claims.", ex);
      }

      return list;
    }

    protected AppUserAuth BuildUserAuthObject(AppUser authUser)
    {
      AppUserAuth ret = new AppUserAuth();
      List<AppUserClaim> claims = new List<AppUserClaim>();

      // Set User Properties
      ret.UserName = authUser.UserName;
      ret.IsAuthenticated = true;
      ret.BearerToken = new Guid().ToString();

      // Get all claims for this user
      ret.Claims = GetUserClaims(authUser);

      // Set JWT bearer token
      ret.BearerToken = BuildJwtToken(ret);

      return ret;
    }

    protected string BuildJwtToken(AppUserAuth authUser)
    {
      SymmetricSecurityKey key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(_settings.Key));

      // Create standard JWT claims
      List<Claim> jwtClaims = new List<Claim>();
      jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Sub,
          authUser.UserName));
      jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Jti,
          Guid.NewGuid().ToString()));

      // Add custom claims
      foreach (var claim in authUser.Claims)
      {
        jwtClaims.Add(new Claim(claim.ClaimType, claim.ClaimValue));
      }

      // Create the JwtSecurityToken object
      var token = new JwtSecurityToken(
        issuer: _settings.Issuer,
        audience: _settings.Audience,
        claims: jwtClaims,
        notBefore: DateTime.UtcNow,
        expires: DateTime.UtcNow.AddMinutes(
            _settings.MinutesToExpiration),
        signingCredentials: new SigningCredentials(key,
                    SecurityAlgorithms.HmacSha256)
      );

      // Create a string representation of the Jwt token
      return new JwtSecurityTokenHandler().WriteToken(token); ;
    }
  }
}
