using System;
using System.Threading.Tasks;
using Company.Project.Application.Common.Interfaces;
using Company.Project.Application.Notifications.Models;

namespace Company.Project.Insfrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}
