using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DogHub.Data.Models
{
    public class ChatMsg
    {
        public ChatMsg()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public DateTime DateAndTimeAdded { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ChatMsgMaxLength)]
        public string MessageText { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string ChatId { get; set; }

        public virtual Chat Chat { get; set; }
    }
}
