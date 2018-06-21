using System;
namespace CustomerApp.src.Models
{
    public struct User
    {
		public string Id { get; set; }
		public string AccessToken { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string UserName { get; set; }
		public string Avatar { get; set; }
    }
}


/*
export class LoggedInUser {
    constructor(access_token: string, username: string, fullName: string, email: string, avatar: string, roles: any, permissions: any) {
        this.access_token = access_token;
        this.fullName = fullName;
        this.username = username;
        this.email = email;
        this.avatar = avatar;
        this.permissions = permissions;
        this.roles = roles;
    }
    public id: string;
    public access_token: string;
    public username: string;
    public fullName: string;
    public email: string;
    public avatar: string;
    public permissions: any;
    public roles: any;
    public phoneNumber: string;
    public birthday: string;
}
*/