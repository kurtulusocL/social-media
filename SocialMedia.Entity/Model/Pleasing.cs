﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Entity.Model
{
    public class Pleasing : BaseHome
    {
        public string Name { get; set; }

        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }
        public Pleasing()
        {
            IsConfirmed = true;
        }
    }
}
