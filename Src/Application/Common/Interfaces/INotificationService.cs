using System;
using SystemTask = System.Threading.Tasks.Task;
using Company.Project.Application.Notifications.Models;

namespace Company.Project.Application.Common.Interfaces
{
    public interface INotificationService
    {
        SystemTask SendAsync(MessageDto message);
    }
}
