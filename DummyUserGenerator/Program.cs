// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.Identity;

Console.WriteLine("This dummy passwordHash generator will generate two password hashes");




var user1Id = "11111111-1111-1111-1111-111111111111";
var user1 = new IdentityUser
{
    Id = user1Id,
    UserName = "dummyuser@example.com",
    NormalizedUserName = "DUMMYUSER@EXAMPLE.COM",
    Email = "dummyuser@example.com",
    NormalizedEmail = "DUMMYUSER@EXAMPLE.COM",
    EmailConfirmed = true,
    SecurityStamp = "8612E928-B2A4-465E-B7E9-18A6CBE615BB"
};

var user2Id = "22222222-2222-2222-2222-222222222222";
var user2 = new IdentityUser
{
    Id = user2Id,
    UserName = "anotheruser@example.com",
    NormalizedUserName = "ANOTHERUSER@EXAMPLE.COM",
    Email = "anotheruser@example.com",
    NormalizedEmail = "ANOTHERUSER@EXAMPLE.COM",
    EmailConfirmed = true,
    SecurityStamp = "B2D7A1F6-F90F-4B5D-85C9-A9B64C911A2F"
};


var hasher = new PasswordHasher<IdentityUser>();
var user1PasswordHash = hasher.HashPassword(user1, "Password123");
var user2PasswordHash = hasher.HashPassword(user2, "Password123");
Console.WriteLine($"user1PasswordHash: {user1PasswordHash}");
Console.WriteLine($"user2PasswordHash: {user2PasswordHash}");