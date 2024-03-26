using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteTakingApplication.Data;

namespace NoteTakingApplication.Data;

public class Users
{
    private List<User> users;

    public Users()
    {
        users = new List<User>();
    }

    public void AddUser(User _user)
    {
        users.Add(_user);
    }

    public User GetUser(int _userId)
    {
        return users.Find(u => u.userId == _userId);
    }

    public void GetAllUsers()
    {
        foreach (User user in users) 
        {
            Console.WriteLine(user.GetUserInformation());
        }
    }

    public IEnumerator GetEnumerator()
    {
        return users.GetEnumerator();
    }

}
