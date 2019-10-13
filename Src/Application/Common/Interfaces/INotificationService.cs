using System;
using System.Threading.Tasks;
using Company.Project.Application.Notifications.Models;

namespace Company.Project.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
