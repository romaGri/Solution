using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public partial class Forum
    {
        public int Id { get; set; }
        public int? ForumId { get; set; }
        public string Value { get; set; }
    }
}
