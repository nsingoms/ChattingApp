using Microsoft.AspNetCore.Identity;

namespace ChattingApp.Shared.Models
{
    public class ApplicationUser : IdentityUser
    { 
        public ApplicationUser()
        {
            ChatMessagesFromUsers = new HashSet<ChatMessage>();
            ChatMessagesToUsers = new HashSet<ChatMessage>();
        }
        public virtual ICollection<ChatMessage> ChatMessagesFromUsers { get; set; }
        public virtual ICollection<ChatMessage> ChatMessagesToUsers { get; set; }
      
    }
}