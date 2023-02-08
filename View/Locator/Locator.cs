using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Model;

namespace View.Locator
{
    public static class LocatorList
    {
        public static List<Note> notes { get; set; }       
    }

    public static class LocatorSingle
    {
        public static Note note { get; set; }
    }
    

}
