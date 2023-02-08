using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Mvvm;
using System.Net.Http;

namespace View.Model
{
    public class Notes 
    {
        public List<Note> notes { get; set; }
        

    }
}
