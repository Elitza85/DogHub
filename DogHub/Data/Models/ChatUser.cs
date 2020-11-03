using System;
using System.Collections.Generic;
using System.Text;

namespace DogHub.Data.Models
{
    public class ChatUser
    {
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string ChatId { get; set; }

        public virtual Chat Chat { get; set; }
    }
}
