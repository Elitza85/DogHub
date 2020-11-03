using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DogHub.Data.Models
{
    public class Chat
    {
        public Chat()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Messages = new HashSet<ChatMsg>();
            this.ChatsUsers = new HashSet<ChatUser>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ChatTopicMaxLength)]
        public string Topic { get; set; }

        public virtual ICollection<ChatMsg> Messages { get; set; }

        public virtual ICollection<ChatUser> ChatsUsers { get; set; }
    }
}
