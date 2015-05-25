using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace System.Web
{
    public class AuthenticationModel
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        [DisplayName("Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DisplayName("Пароль")]
        [UIHint("Password")]
        public string Password { get; set; }

        [DisplayName("Запомнить меня")]
        public bool RememberMe { get; set; }

        public bool isValid { get; set; }

        public bool isAjax { get; set; }

        public AuthenticationModel()
        {
            isValid = true;
            isAjax = true;
        }
        
    }

    public class RegistrationModel
    {
        [Required(ErrorMessage = "Укажите имя")]
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Укажите фамилию")]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [DisplayName("E-mail")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [DisplayName("Пароль")]
        [UIHint("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [DisplayName("Пароль еще раз")]
        [UIHint("Password")]
        public string PasswordConfirm { get; set; }

        [DisplayName("Я согласен")]
        public bool AgreementConfirm { get; set; }
    }

    public class RecoveryPassword
    {
        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [DisplayName("E-mail")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Введите текст")]
        [DisplayName("Защитный код")]
        public string Captcha { get; set; }
    }
}
