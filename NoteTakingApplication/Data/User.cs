using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteTakingApplication.Data;

namespace NoteTakingApplication.Data;
public class User
{
    public int userId { get; set; }
    public string userName { get; set; }

    public DateTime CreatedDate { get; set; }

    public User(string _username)
    {
        userName = _username;
        userId = UniqueUserrIdGenerator();
        CreatedDate = DateTime.Now;
    }

    private static int UniqueUserrIdGenerator()
    {
        var randNum = new Random();
        int userid = randNum.Next(100000, 999999);

        return userid;
    }

    public string GetUserInformation()
    {
        string userInformation = $"User creation successfull!!\nYour user Id is: {userId} and username is: {userName} is created at: {CreatedDate}.";

        return userInformation;
    }

    public string GetBasicUserInformation()
    {
        string heading = $"Username: {userName.PadRight(6)}\nUserID: {userId.ToString().PadRight(6)}\tCreation Date: {CreatedDate.ToString().PadRight(12)}" ; 
        return heading;
    }
}
