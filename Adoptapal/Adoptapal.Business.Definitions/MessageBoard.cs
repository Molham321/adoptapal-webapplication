﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adoptapal.Business.Definitions
{
    public class MessageBoard
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime? PostTime { get; set; }

        public User? User { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}