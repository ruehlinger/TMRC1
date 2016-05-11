using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VBATMRC.Models
{
    public class Announcement
    {
        public virtual string Title { get; set; }
        public virtual string Copy { get; set; }
        public virtual string Link { get; set; }
        public virtual string Path { get; set; }
        public virtual string ActionName { get; set; }
        public string LstIndex { get; set; }
    }
}