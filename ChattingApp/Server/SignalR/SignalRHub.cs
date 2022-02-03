namespace ChattingApp.Server.SignalR
{
    public class SignalRHub : Hub
    {
        public async Task SendMessgeAsync(ChatMessage message, string userName)
        {
            //Notifies the client who was logged in with a particular userId that a new message has been received.
            await Clients.All.SendAsync("ReceiveMessage", message, userName);
        }
        public async Task ChatNotificationAsync(string message, string receiverUserId, string senderUserId)
        {
            await Clients.All.SendAsync("ReceiveChatNotification", message, receiverUserId, senderUserId);
        }
    }
}
