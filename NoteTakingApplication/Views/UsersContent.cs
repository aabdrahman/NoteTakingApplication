using System;
using NoteTakingApplication.Data;
using NoteTakingApplication.Views;
using NoteTakingApplication.OutputTexts;
using NoteTakingApplication.Operations;
using System.Text;

namespace NoteTakingApplication.Views;

public class UsersContent
{
    private Users Users = null;


    public UsersContent()
    {
        
    }

    public void RunUsersContentView()
    {
        foreach (User user in Users)
        {
            Console.WriteLine(user.GetUserInformation());
        }
       
    }
}