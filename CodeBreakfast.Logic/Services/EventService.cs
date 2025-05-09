using CodeBreakfast.Data;
using CodeBreakfast.Data.Entities;
using CodeBreakfast.Data.Repositories.Interfaces;
using CodeBreakfast.Logic.Data;
using CodeBreakfast.Logic.Services.Interfaces;

namespace CodeBreakfast.Logic.Services;

public class EventService(INotificationService notificationService, INotificationRepository notificationRepository)
    : IEventService
{
    public async Task TriggerNewsletter(NewsletterEventAdditionalData additionalData)
    {
        await notificationRepository.SaveNotificationAsync(new Notification
        {
            Id = Guid.NewGuid(),
            NotificationType = NotificationType.Newsletter,
            Title = additionalData.Newsletter.Title,
            Description = additionalData.Newsletter.Content
        });
        
        await notificationService.SendGlobalNotificationAsync(new NotificationData
        {
            NotificationType = NotificationType.Newsletter,
            Title = additionalData.Newsletter.Title,
            Description = additionalData.Newsletter.Content
        });
    }

    public async Task TriggerNewPrivateMessage(NewPrivateMessageEventAdditionalData additionalData)
    {
        await notificationRepository.SaveNotificationForUserAsync(new Notification
        {
            Id = Guid.NewGuid(),
            NotificationType = NotificationType.NewPrivateMessage,
            Title = "New Message",
            Description = $"New message from {additionalData.Sender}",
            AdditionalData = additionalData
        }, additionalData.RecipientId);
        
        await notificationService.SendNotificationAsync(new NotificationData
        {
            NotificationType = NotificationType.NewPrivateMessage,
            Title = "New Message",
            Description = $"New message from {additionalData.Sender}",
            AdditionalData = additionalData
        }, additionalData.RecipientId);
    }

    public async Task TriggerProfileFollow(ProfileFollowEventAdditionalData additionalData)
    {
        await notificationRepository.SaveNotificationForUserAsync(new Notification
        {
            Id = Guid.NewGuid(),
            NotificationType = NotificationType.ProfileFollow,
            Title = "Profile Follow",
            Description = "Someone followed to your profile",
            AdditionalData = additionalData
        }, additionalData.RecipientId);
        
        await notificationService.SendNotificationAsync(new NotificationData
        {
            NotificationType = NotificationType.ProfileFollow,
            Title = "Profile Follow",
            Description = "Someone followed to your profile",
            AdditionalData = additionalData
        }, additionalData.RecipientId);
    }

    public async Task TriggerCommentReply(CommentReplyEventAdditionalData additionalData)
    {
        await notificationRepository.SaveNotificationForUserAsync(new Notification
        {
            Id = Guid.NewGuid(),
            NotificationType = NotificationType.CommentReply,
            Title = "User Replied",
            Description = $"{additionalData.Username} replied",
            AdditionalData = additionalData
        }, additionalData.RecipientId);
        
        await notificationService.SendNotificationAsync(new NotificationData
        {
            NotificationType = NotificationType.CommentReply,
            Title = "User Replied",
            Description = $"{additionalData.Username} replied",
            AdditionalData = additionalData
        }, additionalData.RecipientId);
    }

    public async Task TriggerNewCourseContent(NewCourseContentEventAdditionalData additionalData)
    {
        await notificationRepository.SaveNotificationForCourseAsync(new Notification
        {
            Id = Guid.NewGuid(),
            NotificationType = NotificationType.NewCourseContent,
            Title = "New Course Content",
            Description = $"{additionalData.CourseName} got new content",
            AdditionalData = additionalData
        }, additionalData.CourseId);
        
        await notificationService.SendNotificationByCourseAsync(new NotificationData
        {
            NotificationType = NotificationType.NewCourseContent,
            Title = "New Course Content",
            Description = $"{additionalData.CourseName} got new content",
            AdditionalData = additionalData
        }, additionalData.CourseId);
    }

    public async Task TriggerCourseSubscribe(CourseSubscribeEventAdditionalData additionalData)
    {
        await notificationRepository.SaveNotificationForCourseAsync(new Notification
        {
            Id = Guid.NewGuid(),
            NotificationType = NotificationType.CourseSubscribe,
            Title = "Someone subscribed to your course",
            Description = $"{additionalData.Username} subsribed to your course",
            AdditionalData = additionalData
        }, additionalData.CourseId, CourseRole.Owner);
        
        await notificationService.SendNotificationByCourseAsync(new NotificationData
        {
            NotificationType = NotificationType.CourseSubscribe,
            Title = "Someone subscribed to your course",
            Description = $"{additionalData.Username} subsribed to your course",
            AdditionalData = additionalData
        }, additionalData.CourseId, CourseRole.Owner);
    }

    public async Task TriggerCourseComment(CourseCommentEventAdditionalData additionalData)
    {
        await notificationRepository.SaveNotificationForCourseAsync(new Notification
        {
            Id = Guid.NewGuid(),
            NotificationType = NotificationType.CourseComment,
            Title = "Someone commented to your course",
            Description = $"{additionalData.Username} commented to your course",
            AdditionalData = additionalData
        }, additionalData.CourseId, CourseRole.Owner);
        
        await notificationService.SendNotificationByCourseAsync(new NotificationData
        {
            NotificationType = NotificationType.CourseComment,
            Title = "Someone commented to your course",
            Description = $"{additionalData.Username} commented to your course",
            AdditionalData = additionalData
        }, additionalData.CourseId, CourseRole.Owner);
    }
}