﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Domain.ViewModels.Users;
public class UserViewModel
{
    [Display(Name = "Id")]
    public long Id { get; set; }

    [Required(ErrorMessage = "Укажите роль")]
    [Display(Name = "Роль")]
    public string Role { get; set; }

    [Required(ErrorMessage = "Укажите логин")]
    [Display(Name = "Логин")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Укажите пароль")]
    [Display(Name = "Пароль")]
    public string Password { get; set; }
}
