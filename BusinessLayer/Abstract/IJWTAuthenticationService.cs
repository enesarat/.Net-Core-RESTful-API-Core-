using EntityLayer.Concrete;
using EntityLayer.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IJWTAuthenticationService
    {
        User Authenticate(UserLogin userLogin);
    }
}
