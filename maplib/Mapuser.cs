﻿using System;
using System.Collections.Generic;

namespace maplib
{
    public partial class Mapuser
    {
        public Mapuser()
        {
            Useractions = new HashSet<Useractions>();
        }

        public int Id { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Useractions> Useractions { get; set; }
    }
}
