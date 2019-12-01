using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayer;


namespace PSR09554.API.TokenAuthorization
{
    public class UserMasterRepository : IDisposable
    {
        public Helpers.Models.AuthenticationModel ValidateUser(string username, string password)
        {
            var user = BL.getUserAPI(username).FirstOrDefault();
            if (Hash.MyHash.VerifyHashedPassword(user.hash, password))
            {
                return user;
            }
            return null;
        }
        public void Dispose()
        {

        }
    }
}