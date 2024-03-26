using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteTakingApplication.Data;
using Newtonsoft.Json;
using System.Text.Json;

namespace NoteTakingApplication.Data;

public class Notes
{
    private List<Note> _notes;


    public Notes()
    {
        _notes = new List<Note>();
    }

    public void AddNote(Note _note)
    {
        _notes.Add(_note);
    }

    public IEnumerator<Note> GetEnumerator() 
    {
        return _notes.GetEnumerator();
    }


}
