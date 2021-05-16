using System;
namespace CustomerShoppingApp.Token
{
    public interface IUserTokenGenerator
    {
        string GenerateToken(int userId);
    }
}
