using EntegrasyonSistemi.DatabaseObject;
using EntegrasyonSistemi.Entity;
using System.Text.RegularExpressions;

namespace EntegrasyonSistemi.Services.Utility
{
    public class SignupCheckUtility
    {
        static SignUpReturnDto sg = new SignUpReturnDto();
         
        public static SignUpReturnDto isValidSign(User user)
        {
            if (user.IdentityNumber.Length != 11)
            {
                sg.Message = "Tc Kimlik Numarası 11 Haneli olmalı";
                sg.Success = false;
            } else if(!Regex.IsMatch(user.IdentityNumber, @"^\d+$"))
            {
                sg.Message = "Tc Kimlik Numarası sadece rakamlardan oluşabilir";
                sg.Success = false;
            } else
            {
                sg.Message = "Başarılı";
                sg.Success = true;
            }
            return sg;
        }
    }
}
