﻿using System.ComponentModel.DataAnnotations;

namespace MyStore_backend.Models.Dto.Auth
{
    public class RegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
