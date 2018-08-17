using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MOSSWORKLOG.DATA;
using MOSSWORKLOG.DATA.Models.Enums;

namespace MOSSWORKLOG.Models
{
    #region [ Token ]

    public class TokenParameter
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    #endregion

    #region [ Login ]
    public class LoginParameter
    {
        public string LoginEmail { get; set; }
        public string password { get; set; }
    }

    public class UserExsitParameter
    {
        public string LoginEmail { get; set; }
    }

    public class RegisterUserParameter
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string AccessCode { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string Country { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }
        public string Password { get; set; }
        public string ZipCode { get; set; }
        public bool IsVerified { get; set; }
        public bool IsPaid { get; set; }
    }

    public class CountryParameter
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string ISDCode { get; set; }
    }

    public class CityParameter
    {
        public string CountryCode { get; set; }
        public string StateCode { get; set; }
    }

    #endregion


    public class CodeParameter
    {
        public string Code { get; set; }
    }


    #region [ User Log ]

    public class UserLogParameter
    {
        public IList<UserLog> logs { get; set; }
        public UserLogParameter()
        {
            this.logs = new List<UserLog>();
        }
    }


    public class UserLog
    {
        public int UserId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public DateTime? TimeStamp { get; set; }
        public string AreaName { get; set; }
    }
    #endregion


    #region [ Event ]
    public class EventSubTypeParameter
    {
        public EventTypeEnum EventType { get; set; }
    }

    public class EventParameter
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string ShortName { get; set; }
        public string ImageData { get; set; }
        public string EventMessage { get; set; }
        public EventTypeEnum EventType { get; set; }
        public EventStatEnum EventState { get; set; }
        public EventPublicPrivateEnum IsPublic { get; set; }
        public EventTemporaryPermanentEnum IsPermanent { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int EventSubType { get; set; }
    }

    public class EventReturnObject
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string ShortName { get; set; }
        public string ImageData { get; set; }
        public string EventMessage { get; set; }
        public EventTypeEnum EventType { get; set; }
        public EventStatEnum EventState { get; set; }
        public EventPublicPrivateEnum IsPublic { get; set; }
        public EventTemporaryPermanentEnum IsPermanent { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int EventSubType { get; set; }
        public int RouteCount { get; set; }
        public bool IsAdmin { get; set; }
        public double KM { get; set; }
    }


    public class EventParticipantParameter
    {
        public int Id { get; set; }
        public int EventId { get; set; }

        public int UserId { get; set; }

        public string UserEmail { get; set; }

        public string Message { get; set; }

        public bool IsTrackable { get; set; }

        public bool IsAlert { get; set; }

        public bool IsAdmin { get; set; }
    }

    public class EventParticipantReturnObject
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public int UserId { get; set; }

        public string UserEmail { get; set; }

        public string Message { get; set; }

        public bool IsTrackable { get; set; }

        public bool IsAlert { get; set; }

        public bool IsAdmin { get; set; }

        public string IsAccept { get; set; }
    }

    public class EventViewerParameter
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public int UserId { get; set; }
        public string UserEmail { get; set; }

        public string Message { get; set; }

        public bool IsTrackable { get; set; }

        public bool IsActive { get; set; }

    }

    public class EventViewerReturnObject
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public int UserId { get; set; }
        public string UserEmail { get; set; }

        public string Message { get; set; }

        public bool IsTrackable { get; set; }

        public bool IsActive { get; set; }

    }

    public class TrakMeRouteParameter
    {
        public int RouteId { get; set; }
        public int EventId { get; set; }
        public string RouteSortName { get; set; }
        public string Description { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool IsActive { get; set; }
        public string days { get; set; }
    }

    public class TrakMeRouteReturnObject
    {
        public int RouteId { get; set; }
        public int EventId { get; set; }
        public string RouteSortName { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool IsActive { get; set; }
        public string days { get; set; }
    }


    public class TrakMeRouteLocationParameter
    {
        public int RouteLocationId { get; set; }
        public int RouteId { get; set; }
        public int SequenceNo { get; set; }
        public string LocationMessage { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ScheduleTime { get; set; }
        public int TravelTime { get; set; }
        public int HoldTime { get; set; }
    }

    public class TrakMeRouteLocationReturnObject
    {
        public int RouteLocationId { get; set; }
        public int RouteId { get; set; }
        public int SequenceNo { get; set; }
        public string LocationMessage { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ScheduleTime { get; set; }
        public int TravelTime { get; set; }
        public int HoldTime { get; set; }
        public bool IsNotify { get; set; }
        public int EventCreateUserId { get; set; }
    }


    public class TrakMeSettingsParameter
    {
        public int UserId { get; set; }
        public string SettingPara { get; set; }
        public string SettingValue { get; set; }
    }


    public class TrakMeEventLog
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string TimeStamp { get; set; }
    }
    #endregion

    public class SendMessageParameter
    {

        public int EventId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
    }

    public class ReturnMessageParameter
    {

        public int EventId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public string TimeStamp { get; set; }
    }

    public class UserAccessCodeParameter
    {
        public int UserId { get; set; }
        public string AccessCode { get; set; }
    }

    public class NotifymeParameter
    {
        public int UserId { get; set; }

        public int EventId { get; set; }

        public int RouteLocationId { get; set; }
    }

    public class RouteLocationParameter
    {
        public int UserId { get; set; }

        public int RouteId { get; set; }
    }

    public class EventParticipateNotificationResponse
    {
        public int ParticipateId { get; set; }
        public string IsAccept { get; set; }
    }

    public class ChangePasswordParameter
    {
        public int UserId { get; set; }

        public string Password { get; set; }
    }

    public class Locationparam
    {
        public int RouteLocationId { get; set; }
        public int RouteId { get; set; }
        public int EventId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ScheduleTime { get; set; }
        public int TravelTime { get; set; }
        public int HoldTime { get; set; }
    }


    public class UserHistoryparam
    {
        public int UserId { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }

    public class EventListParam
    {
        public string KeyWord { get; set; }
        public int SubTypeId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double MaxKM { get; set; }
        public double MinKM { get; set; }

    }
}