using NoteTakingApplication.Data;
using NoteTakingApplication.Views;
using NoteTakingApplication.OutputTexts;
using System;
using System.Text.Json;
using Newtonsoft.Json;
using NoteTakingApplication.Operations;

namespace NoteTakingApplication.Data;

public class Log
{
    public int UserId { get; set; }

    public string Action { get; set; }

    public DateTime LogTime { get; set; }


    public Log(int _userId, string _Action)
    {
        UserId = _userId;
        Action = _Action;
        LogTime = DateTime.Now;
    }

}
