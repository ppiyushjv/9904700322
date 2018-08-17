using TrakME.Common;
using TrakME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrakME.DATA;
using TrakME.Enums;
using System.IO;
using System.Net;
using System.Text;
using System.Data.SqlClient;

namespace TrakME.Controllers
{
    public class TrakMeController : Controller
    {

        public static bool IsCheckToken = false;
        // GET: TrakMe
        public JsonResult Token(TokenParameter param)
        {
            var ticks = DateTime.UtcNow.Ticks; ;
            var token = Common.SecurityManager.GenerateToken(param.email, param.password, ticks);
            return Json(new { Success = true, Token = token }, JsonRequestBehavior.AllowGet);
        }

        public string stringToken(string email, string password = "password")
        {
            var ticks = DateTime.UtcNow.Ticks; ;
            var token = SecurityManager.GenerateToken(email, password, ticks);
            return token;
        }

        public JsonResult Data(string name, string param = "")
        {
            #region [ HELP ]
            if (param.Contains("HELP"))
            {
                return Json(new { Success = true, Data = SampleData(name) }, JsonRequestBehavior.AllowGet);
            }
            #endregion

            #region [ Token ]
            if (IsCheckToken)
            {
                var token = Request.Headers.GetValues("token");
                if (token == null || !SecurityManager.IsTokenValid(token[0].ToString()))
                    return Json(new { Success = false, Response = "Unauthorise API call" }, JsonRequestBehavior.AllowGet);
            }
            #endregion

            try
            {
                switch (name)
                {
                    case "Token":
                        return Token(Newtonsoft.Json.JsonConvert.DeserializeObject<TokenParameter>(param));

                    case "Login":
                        return Login(Newtonsoft.Json.JsonConvert.DeserializeObject<LoginParameter>(param));

                    case "CheckUser":
                        return CheckUser(Newtonsoft.Json.JsonConvert.DeserializeObject<UserExsitParameter>(param));

                    case "Register":
                        return Register(Newtonsoft.Json.JsonConvert.DeserializeObject<RegisterUserParameter>(param));
                        

                    case "Country":
                        return Country();
                        

                    case "City":
                        return GetCity(Newtonsoft.Json.JsonConvert.DeserializeObject<CityParameter>(param));
                        
                    case "State":
                        return GetState(Newtonsoft.Json.JsonConvert.DeserializeObject<CodeParameter>(param));
                        
                    case "ResendLink":
                        return ResendLink(Newtonsoft.Json.JsonConvert.DeserializeObject<UserExsitParameter>(param));
                        
                    case "EventSubType":
                        return EventSubType(Newtonsoft.Json.JsonConvert.DeserializeObject<EventSubTypeParameter>(param));
                        
                    case "UserOccupation":
                        return UserOccupation();
                        

                    case "UserLog":
                        return UserLog(Newtonsoft.Json.JsonConvert.DeserializeObject<UserLogParameter>(param));
                        


                    case "EventPublic":
                        return GetAllEvent(Newtonsoft.Json.JsonConvert.DeserializeObject<MyEventListParam>(param), EventPublicPrivateEnum.Public);
                        
                    case "EventPrivate":
                        return GetAllEvent(Newtonsoft.Json.JsonConvert.DeserializeObject<MyEventListParam>(param), EventPublicPrivateEnum.Private);
                        

                    case "EventAll":
                        return GetAllEvent(Newtonsoft.Json.JsonConvert.DeserializeObject<MyEventListParam>(param), null);
                        


                    case "Event":
                        return Event(Newtonsoft.Json.JsonConvert.DeserializeObject<EventParameter>(param));
                        


                    case "EventDelete":
                        return EventDelete(Newtonsoft.Json.JsonConvert.DeserializeObject<EventParameter>(param));

                        

                    case "EventParticipant":
                        return EventParticipant(Newtonsoft.Json.JsonConvert.DeserializeObject<EventParticipantParameter>(param));
                        
                    case "DeleteEventParticipate":
                        return DeleteEventParticipate(Newtonsoft.Json.JsonConvert.DeserializeObject<EventParticipantParameter>(param));
                        

                    case "EventViewer":
                        return EventViewer(Newtonsoft.Json.JsonConvert.DeserializeObject<EventViewerParameter>(param));
                        
                    case "DeleteEventViewer":
                        return DeleteEventViewer(Newtonsoft.Json.JsonConvert.DeserializeObject<EventViewerParameter>(param));
                        

                    case "EventRoute":
                        return EventRoute(Newtonsoft.Json.JsonConvert.DeserializeObject<TrakMeRouteParameter>(param));
                        
                    case "DeleteEventRoute":
                        return DeleteEventRoute(Newtonsoft.Json.JsonConvert.DeserializeObject<TrakMeRouteParameter>(param));
                        

                    case "EventRouteLocation":
                        return EventRouteLocation(Newtonsoft.Json.JsonConvert.DeserializeObject<TrakMeRouteLocationParameter>(param));
                        
                    case "DeleteEventRouteLocation":
                        return DeleteEventRouteLocation(Newtonsoft.Json.JsonConvert.DeserializeObject<CodeParameter>(param));
                        
                    case "GetMyEvent":
                        return GetMyEvent(Newtonsoft.Json.JsonConvert.DeserializeObject<CodeParameter>(param));
                        
                    case "GetEvent":
                        return GetEvent(Newtonsoft.Json.JsonConvert.DeserializeObject<CodeParameter>(param));
                        

                    case "GetEventParticipant":
                        return GetEventParticipant(Newtonsoft.Json.JsonConvert.DeserializeObject<CodeParameter>(param));
                        

                    case "GetEventViewer":
                        return GetEventViewer(Newtonsoft.Json.JsonConvert.DeserializeObject<CodeParameter>(param));
                        
                    case "GetEventRoutes":
                        return GetEventRoutes(Newtonsoft.Json.JsonConvert.DeserializeObject<CodeParameter>(param));
                        
                    case "GetEventRouteLocations":
                        return GetEventRouteLocations(Newtonsoft.Json.JsonConvert.DeserializeObject<RouteLocationParameter>(param));
                        
                    case "Settings":
                        return Settings(Newtonsoft.Json.JsonConvert.DeserializeObject<TrakMeSettingsParameter>(param));
                        
                    case "GetSettings":
                        return GetSettings(Newtonsoft.Json.JsonConvert.DeserializeObject<CodeParameter>(param));
                        
                    case "ForgotPassword":
                        return ForgotPassword(Newtonsoft.Json.JsonConvert.DeserializeObject<CodeParameter>(param));
                        
                    case "UpdateAccessCode":
                        return UpdateAccessCode(Newtonsoft.Json.JsonConvert.DeserializeObject<UserAccessCodeParameter>(param));
                        
                    case "GetMessage":
                        return GetMessage(Newtonsoft.Json.JsonConvert.DeserializeObject<ChatParameter>(param));
                        
                    case "SendMessage":
                        return SendMessage(Newtonsoft.Json.JsonConvert.DeserializeObject<SendMessageParameter>(param));
                        
                    case "GetEventLocation":
                        return GetEventLocation(Newtonsoft.Json.JsonConvert.DeserializeObject<CodeParameter>(param));
                        
                    case "NotifyMe":
                        return NotifyMe(Newtonsoft.Json.JsonConvert.DeserializeObject<NotifymeParameter>(param));
                        

                    case "RemoveNotifyMe":
                        return RemoveNotifyMe(Newtonsoft.Json.JsonConvert.DeserializeObject<NotifymeParameter>(param));
                        
                    case "EventRouteLocationNotification":
                        return EventRouteLocationNotification(Newtonsoft.Json.JsonConvert.DeserializeObject<CodeParameter>(param));
                        
                    case "EventParticipateResponse":
                        return EventParticipateResponse(Newtonsoft.Json.JsonConvert.DeserializeObject<EventParticipateNotificationResponse>(param));
                        

                    case "GetEventParticipatePendingAction":
                        return GetEventParticipatePendingAction(Newtonsoft.Json.JsonConvert.DeserializeObject<CodeParameter>(param));
                        
                    case "GetLocation":
                        return GetLocation(Newtonsoft.Json.JsonConvert.DeserializeObject<CodeParameter>(param));
                        
                    case "ChangePassword":
                        return ChangePassword(Newtonsoft.Json.JsonConvert.DeserializeObject<ChangePasswordParameter>(param));
                        

                    case "GetUserHistory":
                        return GetUserHistory(Newtonsoft.Json.JsonConvert.DeserializeObject<UserHistoryparam>(param));
                        
                    case "GetPublicEventList":
                        return GetPublicEventList(Newtonsoft.Json.JsonConvert.DeserializeObject<EventListParam>(param));
                        
                    case "SetIsTrakable":
                        return SetIsTrakable(Newtonsoft.Json.JsonConvert.DeserializeObject<SetIsTrakableParam>(param));
                        
                    default:
                        return Json(new { Success = false, Code = "000", Message = "Not yet implemented" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Code = "XXX", Message = "Error in API Call", Error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        internal Object SampleData(string function)
        {
            switch (function)
            {
                case "Token":
                    return new TokenParameter();
                    
                case "Login":
                    return new LoginParameter();
                    

                case "CheckUser":
                    return new UserExsitParameter();
                    
                case "Register":
                    return new RegisterUserParameter();
                    
                case "ResendLink":
                    return new UserExsitParameter();
                    
                case "City":
                    return new CityParameter();
                    
                case "State":
                    return new CodeParameter();
                    
                case "UserLog":
                    var a = new UserLogParameter();
                    a.logs.Add(new Models.UserLog());
                    return a;
                    
                case "Event":
                    return new EventParameter();
                    
                case "EventDelete":
                    return new EventParameter();

                case "EventSubType":
                    Dictionary<int, string> mydic = new Dictionary<int, string>();
                    foreach (EventTypeEnum foo in Enum.GetValues(typeof(EventTypeEnum)))
                    {
                        mydic.Add((int)foo, foo.ToString());
                    }
                    return new { parameter = new EventSubTypeParameter(), Value = mydic.ToList() };
                    
                case "EventParticipant":
                    return new EventParticipantParameter();
                    

                case "DeleteEventParticipate":
                    return new EventParticipantParameter();
                    
                case "EventViewer":
                    return new EventViewerParameter();
                    
                case "DeleteEventViewer":
                    return new EventViewerParameter();
                    

                case "EventRoute":
                    return new TrakMeRouteParameter();
                    
                case "DeleteEventRoute":
                    return new TrakMeRouteParameter();
                    
                case "EventRouteLocation":
                    return new TrakMeRouteLocationParameter();
                    
                case "DeleteEventRouteLocation":
                    return new CodeParameter();
                    
                case "GetMyEvent":
                    return new CodeParameter();

                case "GetEvent":
                    return new CodeParameter() {  Code = "Event Id"};

                case "GetEventParticipant":
                    return new CodeParameter();
                    
                case "GetEventViewer":
                    return new CodeParameter();
                    
                case "GetEventRoutes":
                    return new CodeParameter();
                    

                case "GetEventRouteLocations":
                    return new RouteLocationParameter();
                    
                case "Settings":
                    return new TrakMeSettingsParameter();
                    

                case "ForgotPassword":
                    return new CodeParameter();
                    

                case "GetSettings":
                    return new CodeParameter();
                    

                case "GetEventLocation":
                    return new CodeParameter();
                    
                case "UpdateAccessCode":
                    return new UserAccessCodeParameter();
                    
                case "GetMessage":
                    return new ChatParameter();
                    

                case "SendMessage":
                    return new SendMessageParameter();
                    

                case "NotifyMe":
                    return new NotifymeParameter();
                    
                case "RemoveNotifyMe":
                    return new NotifymeParameter();
                    

                case "EventRouteLocationNotification":
                    return new CodeParameter();
                    

                case "EventParticipateResponse":
                    return new EventParticipateNotificationResponse();
                    

                case "GetEventParticipatePendingAction":
                    return new CodeParameter() { Code = "User id" };
                    

                case "EventPublic":
                    return new MyEventListParam();
                    

                case "EventPrivate":
                    return new MyEventListParam();
                    

                case "EventAll":
                    return new MyEventListParam();
                    

                case "GetLocation":
                    return new CodeParameter() { Code = "User Id" };
                    
                case "ChangePassword":
                    return new ChangePasswordParameter();
                    

                case "GetUserHistory":
                    return new UserHistoryparam();
                    

                case "GetPublicEventList":
                    return new EventListParam();
                    


                case "SetIsTrakable":
                    return new SetIsTrakableParam();
                    

                default:
                    return "Not yet implemented";
                    
            }
        }

        public JsonResult ImageSave(string Imagedata)
        {
            String path = Server.MapPath("~/Upload"); //Path

            string imageName = Path.GetRandomFileName().ToString() + ".jpg";

            //set the image path
            string imgPath = Path.Combine(path, imageName);

            byte[] imageBytes = Convert.FromBase64String(Imagedata);
            System.IO.File.WriteAllBytes(imgPath, imageBytes);

            return Json(new { Success = true, Message = "Image stored", Path = "/Upload/" + imageName }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SendNotification(string deviceId, string txtmsg, string messageType,string title, int id = 0)
        {
            string serverKey = "AAAAkMW99c0:APA91bF00Av91A_nAc0gzQT5hdIBwlqDqOnguX7ObVunZEsl-49IgwEUfK_xHpcn2WIsSPlInmb-iJUBJOAHj8B0hiizmnxwBYFMWh1Kt1mD9Wosu0zgyLGglrYaffUNJ4ybCk66whn3";
            string senderId = "621792851405";

            // Create the web request with fire base API
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            //serverKey - Key from Firebase cloud messaging server  
            tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
            //Sender Id - From firebase project setting  
            tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
            tRequest.ContentType = "application/json";
            var payload = new
            {
                to = deviceId,
                data = new
                {
                    message = txtmsg,
                    title = title,
                    type = messageType,
                    id = id
                },
            };
            Byte[] byteArray = Encoding.UTF8.GetBytes((Newtonsoft.Json.JsonConvert.SerializeObject(payload)));
            tRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                WebResponse tResponse = tRequest.GetResponse();
                string response = new StreamReader(tResponse.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                tResponse.Close();

                return Json(new { Success = true, Message = "Send successfully", Data = response }, JsonRequestBehavior.AllowGet);
            }
        }

        #region [ User ]

        public ActionResult Verify(string id)
        {
            string errorMessage = "";
            string messageType = "";

            if (!string.IsNullOrWhiteSpace(id))
            {
                using (TrakMEEntities context = new TrakMEEntities())
                {
                    DateTime now = DateTime.UtcNow.AddHours(1);
                    var request = context.TrakMeRequests.SingleOrDefault(r => r.RequestId.Contains(id) && r.Type == RequestTypeEnum.Verify);

                    if (request != null)
                    {
                        if (request.Timestamp >= now)
                        {
                            errorMessage = "Verify Link Expired.";
                            messageType = "ERROR";
                        }
                        else
                        {

                            var user = context.TrakMeUsers.SingleOrDefault(x => x.UserId == request.RequestedUserId);
                            user.IsVerified = true;

                            context.TrakMeRequests.Remove(request);
                            context.SaveChanges();
                            return RedirectToAction("Verify", "Home");
                        }
                    }
                    else
                    {
                        errorMessage = "No data found";
                        messageType = "ERROR";
                    }
                }
            }
            else
            {
                errorMessage = "Invalid Parameters.";
                messageType = "ERROR";
            }

            return RedirectToAction("Index", "Home", new { area = "", message = errorMessage, type = messageType });
        }

        internal JsonResult Login(LoginParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var user = context.TrakMeUsers.SingleOrDefault(X => X.Email == param.LoginEmail);
            if (user == null)
                return Json(new { Success = false, Code = "004", Message = "Email address not found" }, JsonRequestBehavior.AllowGet);
            else if (user.Password != param.password)
                return Json(new { Success = false, Code = "005", Message = "Password wrong" }, JsonRequestBehavior.AllowGet);
            else if (!user.IsVerified)
                return Json(new { Success = false, Code = "002", Message = "Email address not verified" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Success = true, Code = "003", Message = "successfully logging.", Data = GetUserObject(user) }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult CheckUser(UserExsitParameter param)
        {
            using (TrakMEEntities context = new TrakMEEntities())
            {
                var user = context.TrakMeUsers.SingleOrDefault(X => X.Email == param.LoginEmail);
                if (user == null)
                    return Json(new { Success = true, Code = "001", Message = "Email address not registered" }, JsonRequestBehavior.AllowGet);
                else if (!user.IsVerified)
                    return Json(new { Success = true, Code = "002", Message = "Email address not verified" }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { Success = false, Code = "003", Message = "Email address allready registered" }, JsonRequestBehavior.AllowGet);
            };
        }

        internal JsonResult ChangePassword(ChangePasswordParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var user = context.TrakMeUsers.SingleOrDefault(x => x.UserId == param.UserId);
            user.Password = param.Password;
            context.SaveChanges();
            return Json(new { Success = true, Message = "Password Changed", Data = GetUserObject(user) }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult Register(RegisterUserParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var user = context.TrakMeUsers.SingleOrDefault(x => x.Email == param.Email);

            if (param.UserId == 0 && user == null)
            {
                user = new TrakMeUser()
                {
                    FirstName = param.FirstName,
                    LastName = param.LastName,
                    Email = param.Email,
                    BirthYear = param.BirthYear,
                    CountryId = param.CountryId,
                    StateCode = param.StateCode,
                    State = param.State,
                    CityId = param.CityId,
                    Gender = param.Gender,
                    IsVerified = true,
                    IsPaid = false,
                    Mobile = param.Mobile,
                    Password = param.Password,
                    Occupation = param.Occupation,
                    ZipCode = param.ZipCode,
                    AccessCode = param.AccessCode,
                    UserId = param.UserId,
                    OccupationId = param.OccupationId,
                    ProfileImage = param.ProfileImage,
                };

                context.TrakMeUsers.Add(user);
                context.SaveChanges();

                var request = new TrakMeRequest()
                {
                    RequestId = Guid.NewGuid().ToString(),
                    RequestedUserId = user.UserId,
                    RequestedUserEmaiId = user.Email,
                    Type = RequestTypeEnum.Verify,
                    Timestamp = DateTime.UtcNow
                };

                context.TrakMeRequests.Add(request);
                context.SaveChanges();

                string requestUrl = "/TrakMe/Verify/" + request.RequestId;

                //Send Mail
                Extension.SendEmailVerify(user.Email, requestUrl);
                return Json(new { Success = true, Message = "Register successfully", Data = GetUserObject(user) }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //user = context.TrakMeUsers.SingleOrDefault(x => x.UserId == param.UserId);
                user.FirstName = param.FirstName;
                user.LastName = param.LastName;
                user.Email = param.Email;
                user.BirthYear = param.BirthYear;
                user.CountryId = param.CountryId;
                user.StateCode = param.StateCode;
                user.State = param.State;
                user.CityId = param.CityId;
                user.Gender = param.Gender;
                user.Mobile = param.Mobile;
                user.Password = param.Password;
                user.Occupation = param.Occupation;
                user.ZipCode = param.ZipCode;
                user.AccessCode = param.AccessCode;
                user.OccupationId = param.OccupationId;
                user.ProfileImage = param.ProfileImage;

                context.SaveChanges();

                return Json(new { Success = true, Message = "Profile Updated", Data = GetUserObject(user) }, JsonRequestBehavior.AllowGet);
            }
        }

        internal JsonResult ResendLink(UserExsitParameter param)
        {
            using (TrakMEEntities context = new TrakMEEntities())
            {
                var request = new TrakMeRequest()
                {
                    RequestId = Guid.NewGuid().ToString(),
                    RequestedUserEmaiId = param.LoginEmail,
                    Type = RequestTypeEnum.Verify,
                    Timestamp = DateTime.Now
                };

                context.TrakMeRequests.Add(request);
                context.SaveChanges();

                string requestUrl = "/TrakMe/Verify/" + request.RequestId;

                try
                {
                    //Send Mail
                    Extension.SendEmailVerify(param.LoginEmail, requestUrl);
                    return Json(new { Success = true, Message = "Email sent" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { Success = false, Message = "Email sending faild", Errormsg = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            };
        }

        internal JsonResult ForgotPassword(CodeParameter param)
        {
            //var userId = Convert.ToUInt32(param.Code);
            TrakMEEntities context = new TrakMEEntities();
            var user = context.TrakMeUsers.SingleOrDefault(x => x.Email == param.Code);

            //Send Mail
            Extension.SendEmailForgot(user.Email, user.Password);

            return Json(new { Success = true, Message = "Passwrod sent on email" }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult UpdateAccessCode(UserAccessCodeParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var user = context.TrakMeUsers.SingleOrDefault(x => x.UserId == param.UserId);
            user.AccessCode = param.AccessCode;
            context.SaveChanges();

            return Json(new { Success = true, Message = "Access code updated", Data = GetUserObject(user) }, JsonRequestBehavior.AllowGet);
        }

        #region [ Country / State / City / Occupation  ]
        public JsonResult Country()
        {
            TrakMEEntities context = new TrakMEEntities();
            IList<CountryParameter> clist = new List<CountryParameter>();

            context.TrakMeCountries.OrderBy(x => x.CountryName).ToList().ForEach(x => clist.Add(new CountryParameter()
            {
                CountryId = x.CountryId,
                CountryName = x.CountryName,
                ISDCode = x.ShortCode,
                ShortCode = x.ISDCode
            }));
            return Json(new { Success = true, Data = clist }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult GetState(CodeParameter param)
        {
            using (TrakMEEntities context = new TrakMEEntities())
            {
                var state = (from t in context.TrakMeCities
                             where t.CoutryCode == param.Code
                             group t by new { t.StateCode, t.State }
                             into grp
                             select new
                             {
                                 State = grp.Key.State,
                                 StateCode = grp.Key.StateCode
                             }).ToList().Where(x => x.State != null);
                return Json(new { Success = true, Data = state.OrderBy(x => x.State) }, JsonRequestBehavior.AllowGet);
            };
        }

        internal JsonResult GetCity(CityParameter param)
        {
            using (TrakMEEntities context = new TrakMEEntities())
            {
                var city = context.TrakMeCities.
                    Where(x => x.StateCode == param.StateCode &&
                    x.CoutryCode == param.CountryCode)
                    .Select(x => new { CityId = x.Id, City = x.City })
                    .ToList().Where(x => x.City != null);

                return Json(new { Success = true, Data = city.OrderBy(x => x.City) }, JsonRequestBehavior.AllowGet);
            };
        }

        internal JsonResult UserOccupation()
        {
            TrakMEEntities context = new TrakMEEntities();
            return Json(new { Success = true, Data = context.TrakMeEventSubTypes.Where(x => x.Type == EventTypeEnum.Occupation).OrderBy(x => x.Description).ToList() }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion

        #region [ User Log] 
        internal JsonResult UserLog(UserLogParameter param)
        {
            using (TrakMEEntities context = new TrakMEEntities())
            {
                param.logs.ToList().ForEach(x => context.TrakMeUserLogs.Add(new TrakMeUserLog()
                {
                    UserId = x.UserId,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    AreaName = x.AreaName,
                    Timestamp = x.TimeStamp == null ? DateTime.UtcNow : x.TimeStamp.Value
                }));
                context.SaveChanges();
            };

            return Json(new { Success = true, Message = "Log added" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region [ Event ]

        internal JsonResult EventSubType(EventSubTypeParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            return Json(new { Success = true, Data = context.TrakMeEventSubTypes.Where(x => x.Type == param.EventType).OrderBy(x => x.Description).ToList() }, JsonRequestBehavior.AllowGet);
        }

        #region [ Event Details ]
        internal JsonResult Event(EventParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var newevent = new TrakMeEvent();

            if (param.EventId != 0)
                newevent = context.TrakMeEvents.SingleOrDefault(x => x.EventId == param.EventId);

            try
            {
                newevent.EndTime = param.EndTime;
                newevent.StartTime = param.StartTime;

            }
            catch { }

            newevent.EventMessage = param.EventMessage;
            newevent.EventState = param.EventState;
            newevent.EventSubType = param.EventSubType;
            newevent.EventType = param.EventType;
            newevent.ImageData = param.ImageData;
            newevent.IsPermanent = param.IsPermanent;
            newevent.IsPublic = param.IsPublic;
            newevent.ShortName = param.ShortName;
            newevent.UserId = param.UserId;



            if (param.EventId == 0)
                context.TrakMeEvents.Add(newevent);



            if (param.EventId == 0)
            {
                context.TrakMeEventParticipates.Add(new TrakMeEventParticipate()
                {
                    TrakMeEvent = newevent,
                    IsAdmin = true,
                    IsTrackable = true,
                    UserId = newevent.UserId,
                    Message = "Event Owner",
                    IsAccept = "1"
                });


                context.TrakMeEventViewers.Add(new TrakMeEventViewer()
                {
                    TrakMeEvent = newevent,
                    IsActive = true,
                    IsTrackable = true,
                    UserId = newevent.UserId,
                    Message = "Event Owner",
                });
            }
            context.SaveChanges();



            EventReturnObject eventR = new EventReturnObject();
            eventR.EventId = newevent.EventId;
            eventR.EndTime = param.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            eventR.EventMessage = param.EventMessage;
            eventR.EventState = param.EventState;
            eventR.EventSubType = param.EventSubType;
            eventR.EventType = param.EventType;
            eventR.ImageData = param.ImageData;
            eventR.IsPermanent = param.IsPermanent;
            eventR.IsPublic = param.IsPublic;
            eventR.ShortName = param.ShortName;
            eventR.StartTime = param.StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            eventR.UserId = param.UserId;

            if (param.EventId == 0)
                return Json(new { Success = true, Message = "Event Created....", Data = eventR }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Success = true, Message = "Update event....", Data = eventR }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult EventDelete(EventParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var newevent = new TrakMeEvent();

            if (param.EventId != 0)
            {
                newevent = context.TrakMeEvents.SingleOrDefault(x => x.EventId == param.EventId);

                var eventV = context.TrakMeEventViewers.Where(x => x.EventId == param.EventId);
                context.TrakMeEventViewers.RemoveRange(eventV);

                var eventP = context.TrakMeEventParticipates.Where(x => x.EventId == param.EventId);
                context.TrakMeEventParticipates.RemoveRange(eventP);

                var eventRoute = context.TrakMeRoutes.Where(x => x.EventId == param.EventId);
                foreach (var r in eventRoute)
                {
                    var eventRouteLocations = context.TrakMeRouteLocations.Where(x => x.RouteId == r.RouteId);
                    context.TrakMeRouteLocations.RemoveRange(eventRouteLocations);
                }

                context.TrakMeRoutes.RemoveRange(eventRoute);

                context.TrakMeEvents.Remove(newevent);

                context.SaveChanges();


                return Json(new { Success = true, Message = "Event deteted...." }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { Success = true, Message = "Event not found...." }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult EventParticipant(EventParticipantParameter param)
        {
            bool IsAdd = true;
            TrakMEEntities context = new TrakMEEntities();
            var participate = new TrakMeEventParticipate();

            if (param.Id != 0)
            {
                participate = context.TrakMeEventParticipates.SingleOrDefault(x => x.Id == param.Id);

                IsAdd = participate == null;

                if (participate == null)
                    participate = new TrakMeEventParticipate();
            }

            if (IsAdd)
                context.TrakMeEventParticipates.Add(participate);


            var user = context.TrakMeUsers.SingleOrDefault(x => x.Email == param.UserEmail);
            param.UserId = user.UserId;

            participate.EventId = param.EventId;
            participate.IsAdmin = param.IsAdmin;
            participate.IsAlert = param.IsAlert;
            participate.IsTrackable = param.IsTrackable;
            participate.Message = param.Message;
            participate.UserId = param.UserId;
            context.SaveChanges();
            param.Id = participate.Id;

            var evenT = context.TrakMeEvents.SingleOrDefault(x => x.EventId == param.EventId);

            if (IsAdd)
            {
                context.TrakMeEventViewers.Add(new TrakMeEventViewer()
                {
                    TrakMeEvent = participate.TrakMeEvent,
                    IsActive = true,
                    IsTrackable = true,
                    UserId = participate.UserId,
                    Message = "Event Participate",
                });
                context.SaveChanges();

                user = context.TrakMeUsers.SingleOrDefault(x => x.UserId == param.UserId);

                SendNotification(participate.TrakMeUser.AccessCode, "You are added as participate in traking event" + evenT.ShortName, "Participate",
                                            string.Format("{0}({1})",user.FirstName,user.Email), participate.Id);
            }

            if (IsAdd)
                return Json(new { Success = true, Message = "Participate Added", Data = param }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Success = true, Message = "Participate updated", Data = param }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult DeleteEventParticipate(EventParticipantParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var participate = context.TrakMeEventParticipates.SingleOrDefault(x => x.Id == param.Id);
            var viwer = context.TrakMeEventViewers.SingleOrDefault(x => x.EventId == participate.EventId && x.UserId == participate.UserId);

            if (viwer != null)
                context.TrakMeEventViewers.Remove(viwer);

            context.TrakMeEventParticipates.Remove(participate);
            context.SaveChanges();

            return Json(new { Success = true, Message = "Participate Deleted" }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult EventViewer(EventViewerParameter param)
        {
            bool IsAdd = true;
            TrakMEEntities context = new TrakMEEntities();
            var viewer = new TrakMeEventViewer();

            if (param.Id != 0)
            {
                viewer = context.TrakMeEventViewers.SingleOrDefault(x => x.Id == param.Id);

                IsAdd = viewer == null;

                if (viewer == null)
                    viewer = new TrakMeEventViewer();
            }

            if (IsAdd)
                context.TrakMeEventViewers.Add(viewer);

            if (!string.IsNullOrEmpty(param.UserEmail.ToString()))
                param.UserId = context.TrakMeUsers.SingleOrDefault(x => x.Email == param.UserEmail).UserId;


            viewer.EventId = param.EventId;
            viewer.IsActive = param.IsActive;
            viewer.IsTrackable = param.IsTrackable;
            viewer.Message = param.Message;
            viewer.UserId = param.UserId;

            context.SaveChanges();

            var user = context.TrakMeUsers.SingleOrDefault(x => x.UserId == param.UserId);

            param.Id = viewer.Id;
            var even = context.TrakMeEvents.SingleOrDefault(x => x.EventId == param.EventId);

            if (IsAdd)
                SendNotification(viewer.TrakMeUser.AccessCode, "You are added as Viewer in tracking event" + even.ShortName, "Viewer",
                                                            string.Format("{0}({1})",viewer.TrakMeUser.FirstName,viewer.TrakMeUser.Email));

            if (IsAdd)
                return Json(new { Success = true, Message = "Viewer Added", Data = param }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Success = true, Message = "Viewer Updated", Data = param }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult DeleteEventViewer(EventViewerParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var viewer = context.TrakMeEventViewers.SingleOrDefault(x => x.Id == param.Id);
            context.TrakMeEventViewers.Remove(viewer);
            context.SaveChanges();

            return Json(new { Success = true, Message = "Viewer Deleted" }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult EventRoute(TrakMeRouteParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var newroute = new TrakMeRoute();

            if (param.RouteId != 0)
                newroute = context.TrakMeRoutes.SingleOrDefault(x => x.RouteId == param.RouteId);


            newroute.days = param.days;
            newroute.Description = param.Description;
            newroute.EndTime = (TimeSpan)param.EndTime;
            newroute.EventId = param.EventId;
            newroute.IsActive = param.IsActive;
            newroute.RouteSortName = param.RouteSortName;
            newroute.StartTime = (TimeSpan)param.StartTime;

            if (param.RouteId == 0)
                context.TrakMeRoutes.Add(newroute);

            context.SaveChanges();

            param.RouteId = newroute.RouteId;

            var r = new TrakMeRouteReturnObject()
            {
                EndTime = newroute.EndTime.ToString(@"hh\:mm"),
                StartTime = newroute.StartTime.ToString(@"hh\:mm"),
                EventId = newroute.EventId,
                days = newroute.days,
                Description = newroute.Description,
                IsActive = newroute.IsActive,
                RouteId = newroute.RouteId,
                RouteSortName = newroute.RouteSortName
            };

            if (param.RouteId == 0)
                return Json(new { Success = true, Message = "Event Route Created", Data = r }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Success = true, Message = "Event Route Updated", Data = r }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult DeleteEventRoute(TrakMeRouteParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var newroute = context.TrakMeRoutes.SingleOrDefault(x => x.RouteId == param.RouteId);
            context.TrakMeRoutes.Remove(newroute);
            context.SaveChanges();

            return Json(new { Success = true, Message = "Event Route Deleted" }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult EventRouteLocation(TrakMeRouteLocationParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var newRouteLocation = new TrakMeRouteLocation();

            if (param.RouteLocationId != 0)
                newRouteLocation = context.TrakMeRouteLocations.SingleOrDefault(x => x.RouteLocationId == param.RouteLocationId);

            newRouteLocation.HoldTime = param.HoldTime;
            newRouteLocation.Latitude = param.Latitude;
            newRouteLocation.LocationMessage = param.LocationMessage;
            newRouteLocation.Longitude = param.Longitude;
            newRouteLocation.RouteId = param.RouteId;
            newRouteLocation.ScheduleTime = param.ScheduleTime;
            newRouteLocation.TravelTime = param.TravelTime;
            newRouteLocation.SequenceNo = param.SequenceNo;

            if (param.RouteLocationId == 0)
                context.TrakMeRouteLocations.Add(newRouteLocation);

            context.SaveChanges();

            param.RouteLocationId = newRouteLocation.RouteLocationId;


            if (param.RouteLocationId == 0)
                return Json(new { Success = true, Message = "Event Route Location Created", Data = param }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Success = true, Message = "Event Route Location Updated", Data = param }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult DeleteEventRouteLocation(CodeParameter param)
        {
            var id = Convert.ToInt32(param.Code);

            TrakMEEntities context = new TrakMEEntities();
            var newroute = context.TrakMeRouteLocations.SingleOrDefault(x => x.RouteLocationId == id);
            context.TrakMeRouteLocations.Remove(newroute);
            context.SaveChanges();

            return Json(new { Success = true, Message = "Event Route Location Deleted" }, JsonRequestBehavior.AllowGet);
        }
        #endregion


        internal JsonResult GetAllEvent(MyEventListParam param, EventPublicPrivateEnum? type)
        {

            TrakMEEntities context = new TrakMEEntities();
            IList<EventReturnObject> returnList = new List<EventReturnObject>();

            var userId = param.UserId;

            var trakMeEventViewers = context.TrakMeEventViewers.Where(x => x.UserId == userId
                                                                    ).ToList();

            if (type != null)
                trakMeEventViewers = trakMeEventViewers.Where(x => x.TrakMeEvent.IsPublic == type).ToList();

            if (!param.IsMyEvent)
                trakMeEventViewers = trakMeEventViewers.Where(x => x.TrakMeEvent.UserId != param.UserId).ToList();

            foreach (var trakMeEventViewer in trakMeEventViewers)
            {
                var trakMeEvent = trakMeEventViewer.TrakMeEvent;
                if (returnList.Count(y => y.EventId == trakMeEvent.EventId) == 0)
                {
                    var participate = context.TrakMeEventParticipates.SingleOrDefault(x => x.UserId == userId && x.EventId == trakMeEvent.EventId && x.IsAccept.Contains("1"));

                    bool IsAdmin = participate == null ? false : participate.IsAdmin;

                    var eventR = new EventReturnObject();
                    eventR.EventId = trakMeEvent.EventId;
                    eventR.EndTime = trakMeEvent.EndTime == null ? "" : trakMeEvent.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    eventR.EventMessage = trakMeEvent.EventMessage;
                    eventR.EventState = trakMeEvent.EventState;
                    eventR.EventSubType = trakMeEvent.EventSubType;
                    eventR.EventType = trakMeEvent.EventType;
                    eventR.ImageData = trakMeEvent.ImageData;
                    eventR.IsPermanent = trakMeEvent.IsPermanent;
                    eventR.IsPublic = trakMeEvent.IsPublic;
                    eventR.ShortName = trakMeEvent.ShortName;
                    eventR.StartTime = trakMeEvent.StartTime == null ? "" : trakMeEvent.StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    eventR.UserId = trakMeEvent.UserId;
                    eventR.IsAdmin = IsAdmin;

                    context.TrakMeRoutes.Where(y => y.EventId == trakMeEvent.EventId).ToList().ForEach(newroute => eventR.Route.Add(new TrakMeRouteReturnObject()
                    {
                        EndTime = newroute.EndTime.ToString(@"hh\:mm"),
                        StartTime = newroute.StartTime.ToString(@"hh\:mm"),
                        EventId = newroute.EventId,
                        days = newroute.days,
                        Description = newroute.Description,
                        IsActive = newroute.IsActive,
                        RouteId = newroute.RouteId,
                        RouteSortName = newroute.RouteSortName,
                        RouteLocationCount = newroute.TrakMeRouteLocations.Count()
                    }));


                    eventR.RouteCount = eventR.Route.Count();
                    returnList.Add(eventR);
                }
            }

            return Json(new { Success = true, Message = "Event list generated..", Data = returnList }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult GetPublicEventList(EventListParam param)
        {

            TrakMEEntities context = new TrakMEEntities();
            IList<EventReturnObject> list = new List<EventReturnObject>();

            var alist = context.TrakMeEvents.Where(x => x.IsPublic == EventPublicPrivateEnum.Public
                                                            && string.IsNullOrEmpty(param.KeyWord) ? true : (x.ShortName.Contains(param.KeyWord) || x.EventMessage.Contains(param.KeyWord))
                                                            ).ToList();


            if (param.SubTypeId != 0)
                alist = alist.Where(x => x.EventSubType == param.SubTypeId).ToList();

            foreach (var x in alist)
            {
                if (context.TrakMeEventViewers.Where(y => y.UserId == param.UserId && y.EventId == x.EventId).Count() == 0)
                {
                    var newevent = new EventReturnObject()
                    {
                        EventId = x.EventId,
                        EndTime = x.EndTime == null ? "" : x.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                        EventMessage = x.EventMessage,
                        EventState = x.EventState,
                        EventSubType = x.EventSubType,
                        EventType = x.EventType,
                        ImageData = x.ImageData,
                        IsPermanent = x.IsPermanent,
                        IsPublic = x.IsPublic,
                        ShortName = x.ShortName,
                        StartTime = x.StartTime == null ? "" : x.StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                        UserId = x.UserId,
                        RouteCount = context.TrakMeRoutes.Where(y => y.EventId == x.EventId).Count()
                    };
                    list.Add(newevent);
                }
            }

            list.ToList().ForEach(x => x.KM = GetEventKM(x.EventId, param));

            if (param.MaxKM != 0) // || param.MinKM == 0)
                list = list.Where(x => x.KM <= param.MaxKM).ToList();

            if (param.MinKM != 0)
                list = list.Where(x => x.KM >= param.MinKM).ToList();

            return Json(new { Success = true, Message = "Event list generated..", Data = list }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult GetMyEvent(CodeParameter param)
        {
            var userId = Convert.ToUInt32(param.Code);
            IList<EventReturnObject> events = new List<EventReturnObject>();


            TrakMEEntities context = new TrakMEEntities();
            context.TrakMeEvents.Where(x => x.UserId == userId).ToList().ForEach(X => events.Add(new EventReturnObject()
            {
                EventId = X.EventId,
                EndTime = X.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                EventMessage = X.EventMessage,
                EventState = X.EventState,
                EventSubType = X.EventSubType,
                EventType = X.EventType,
                ShortName = X.ShortName,
                StartTime = X.StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                ImageData = X.ImageData,
                IsPermanent = X.IsPermanent,
                IsPublic = X.IsPublic,
                UserId = X.UserId
            }));

            return Json(new { Success = true, Message = "Event list generated", Data = events }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult GetEvent(CodeParameter param)
        {
            var eventId = Convert.ToUInt32(param.Code);
            TrakMEEntities context = new TrakMEEntities();
            var X = context.TrakMeEvents.SingleOrDefault(x => x.EventId == eventId);

            var returnEvent = new EventReturnObject()
            {
                EventId = X.EventId,
                EndTime = X.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                EventMessage = X.EventMessage,
                EventState = X.EventState,
                EventSubType = X.EventSubType,
                EventType = X.EventType,
                ShortName = X.ShortName,
                StartTime = X.StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                ImageData = X.ImageData,
                IsPermanent = X.IsPermanent,
                IsPublic = X.IsPublic,
                UserId = X.UserId
            };

            return Json(new { Success = true, Message = "Event list generated", Data = returnEvent }, JsonRequestBehavior.AllowGet);
        }


        internal JsonResult GetEventParticipant(CodeParameter param)
        {
            var eventId = Convert.ToUInt32(param.Code);
            TrakMEEntities context = new TrakMEEntities();

            IList<EventParticipantReturnObject> list = new List<EventParticipantReturnObject>();

            context.TrakMeEventParticipates.Where(x => x.EventId == eventId).ToList().ForEach(x => list.Add(new EventParticipantReturnObject()
            {
                Id = x.Id,
                EventId = x.EventId,
                IsAdmin = x.IsAdmin,
                IsTrackable = x.IsTrackable,
                IsAlert = x.IsAlert,
                Message = x.Message,
                UserEmail = x.TrakMeUser.Email,
                UserId = x.UserId,
                IsAccept = x.IsAccept,
                EventTitle = x.TrakMeEvent.ShortName
            }));
            return Json(new { Success = true, Message = "Event participant list generated..", Data = list }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult GetEventViewer(CodeParameter param)
        {
            var eventId = Convert.ToUInt32(param.Code);
            TrakMEEntities context = new TrakMEEntities();
            IList<EventViewerReturnObject> list = new List<EventViewerReturnObject>();

            context.TrakMeEventViewers.Where(x => x.EventId == eventId).ToList().ForEach(x => list.Add(new EventViewerReturnObject()
            {
                Id = x.Id,
                EventId = x.EventId,
                IsActive = x.IsActive,
                IsTrackable = x.IsTrackable,
                Message = x.Message,
                UserId = x.UserId,
                UserEmail = x.TrakMeUser.Email
            }));



            return Json(new { Success = true, Message = "Event viewer list generated..", Data = list }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult GetEventRoutes(CodeParameter param)
        {
            var eventId = Convert.ToUInt32(param.Code);
            TrakMEEntities context = new TrakMEEntities();
            IList<TrakMeRouteReturnObject> list = new List<TrakMeRouteReturnObject>();
            context.TrakMeRoutes.Where(x => x.EventId == eventId).ToList().ForEach(x => list.Add(new TrakMeRouteReturnObject()
            {
                EndTime = x.EndTime.ToString(@"hh\:mm"),
                StartTime = x.StartTime.ToString(@"hh\:mm"),
                EventId = x.EventId,
                days = x.days,
                Description = x.Description,
                IsActive = x.IsActive,
                RouteId = x.RouteId,
                RouteSortName = x.RouteSortName
            }));
            return Json(new { Success = true, Message = "Event route list generated..", Data = list }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult GetEventRouteLocations(RouteLocationParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();

            IList<TrakMeRouteLocationReturnObject> list = new List<TrakMeRouteLocationReturnObject>();
            context.TrakMeRouteLocations.Where(x => x.RouteId == param.RouteId).ToList().ForEach(x => list.Add(new TrakMeRouteLocationReturnObject()
            {
                RouteLocationId = x.RouteLocationId,
                ScheduleTime = x.ScheduleTime,
                HoldTime = x.HoldTime,
                Latitude = x.Latitude,
                LocationMessage = x.LocationMessage,
                Longitude = x.Longitude,
                RouteId = x.RouteId,
                TravelTime = x.TravelTime,
                SequenceNo = x.SequenceNo,
                IsNotify = context.TrakMeUserRouteNotificaions.SingleOrDefault(z => z.RouteLocationId == x.RouteLocationId && z.EventId == x.TrakMeRoute.EventId && z.UserId == param.UserId) != null,
                EventCreateUserId = x.TrakMeRoute.TrakMeEvent.UserId
            }));
            return Json(new { Success = true, Message = "Event route location list generated..", Data = list }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult GetEventLocation(CodeParameter param)
        {
            var eventId = Convert.ToInt16(param.Code);

            TrakMEEntities context = new TrakMEEntities();
            IList<TrakMeEventLog> list = new List<TrakMeEventLog>();

            var eventP = context.TrakMeEventParticipates.Where(x => x.EventId == eventId && x.IsTrackable).ToList();

            foreach (var p in eventP)
            {
                var logs = context.TrakMeUserLogs.Where(x => x.UserId == p.UserId).OrderBy(X => X.Timestamp).ToList();

                if (logs.Count() != 0)
                {
                    var l = logs.Last();
                    var user = context.TrakMeUsers.SingleOrDefault(x => x.UserId == p.UserId);
                    list.Add(new TrakMeEventLog()
                    {
                        EventId = eventId,
                        Latitude = l.Latitude,
                        Longitude = l.Longitude,
                        UserId = p.UserId,
                        UserEmail = p.TrakMeUser.Email,
                        UserName = p.TrakMeUser.FirstName,
                        TimeStamp = l.Timestamp.ToString("yyyy-MM-dd HH:mm:ss")
                    });
                }
            }


            return Json(new { Success = true, Message = "Event list generated..", Data = list }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult NotifyMe(NotifymeParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            context.TrakMeUserRouteNotificaions.Add(new TrakMeUserRouteNotificaion()
            {
                EventId = param.EventId,
                RouteLocationId = param.RouteLocationId,
                UserId = param.UserId,
                Timestamp = param.Timestamp == null ? DateTime.UtcNow : param.Timestamp.Value
            });
            context.SaveChanges();
            return Json(new { Success = true, Message = "Added" }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult RemoveNotifyMe(NotifymeParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var n = context.TrakMeUserRouteNotificaions.SingleOrDefault(x => x.UserId == param.UserId &&
                x.EventId == param.EventId && x.RouteLocationId == param.RouteLocationId);

            context.TrakMeUserRouteNotificaions.Remove(n);
            context.SaveChanges();

            return Json(new { Success = true, Message = "Added" }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult EventRouteLocationNotification(CodeParameter param)
        {
            var routeLocationId = Convert.ToInt32(param.Code);
            TrakMEEntities context = new TrakMEEntities();
            var routelocations = context.TrakMeUserRouteNotificaions.Where(x => x.RouteLocationId == routeLocationId);

            foreach (var routelocation in routelocations)
            {
                SendNotification(routelocation.User.AccessCode, routelocation.RouteLocation.LocationMessage + " Reached", "NotifyMe","TrakME");
            }

            return Json(new { Success = true, Message = "Send successfully", Data = "" }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult EventParticipateResponse(EventParticipateNotificationResponse param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var participate = context.TrakMeEventParticipates.SingleOrDefault(x => x.Id == param.ParticipateId);
            participate.IsAccept = param.IsAccept;
            context.SaveChanges();


            return Json(new { Success = true, Message = "successfully update participate" }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult GetEventParticipatePendingAction(CodeParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var userId = Convert.ToInt32(param.Code);

            IList<EventParticipantReturnObject> list = new List<EventParticipantReturnObject>();
            context.TrakMeEventParticipates.Where(x => x.UserId == userId && string.IsNullOrEmpty(x.IsAccept)).ToList().ForEach(x => list.Add(new EventParticipantReturnObject()
            {
                Id = x.Id,
                EventId = x.EventId,
                EventTitle = x.TrakMeEvent.ShortName,
                IsAdmin = x.IsAdmin,
                IsTrackable = x.IsTrackable,
                IsAlert = x.IsAlert,
                Message = x.Message,
                UserEmail = x.TrakMeUser.Email,
                UserId = x.UserId,
                IsAccept = x.IsAccept
            }));
            return Json(new { Success = true, Message = "participate pending list ", Data = list }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult GetUserHistory(UserHistoryparam param)
        {
            TrakMEEntities context = new TrakMEEntities();

            IList<UserLogHistory> history = new List<UserLogHistory>();

            SqlParameter userId = new SqlParameter("@ID", param.UserId);
            SqlParameter Start = new SqlParameter("@Start", param.StartTime);
            SqlParameter End = new SqlParameter("@End", param.EndTime);
            SqlParameter Interval = new SqlParameter("@Interval", param.Interval);
            var logsn = context.Database.SqlQuery<TrakMeUserLog>("GetHistory @ID,@Start,@End,@Interval", userId, Start, End, Interval).ToList();

            logsn.ForEach(log => history.Add(new UserLogHistory()
            {
                AreaName = log.AreaName,
                Id = log.Id,
                Latitude = log.Latitude,
                Longitude = log.Longitude,
                Timestamp = log.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"),
                UserId = log.UserId
            }));



            //var logs = context.TrakMeUserLogs.Where(x => x.UserId == param.UserId 
            //                    && x.Timestamp >= param.StartTime
            //                    && x.Timestamp <= param.EndTime)
            //                    .OrderBy(x => x.Timestamp).ToList();

            //if (logs.Count() != 0)
            //{
            //    DateTime last = logs.First().Timestamp;
            //    int totalMinutes = 0;
            //    bool IsFirst = true;
            //    foreach (var log in logs)
            //    {
            //        if (IsFirst || totalMinutes == param.Interval)
            //        {
            //            history.Add(new UserLogHistory()
            //            {
            //                AreaName = log.AreaName,
            //                Id = log.Id,
            //                Latitude = log.Latitude,
            //                Longitude = log.Longitude,
            //                Timestamp = log.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"),
            //                UserId = log.UserId
            //            });
            //            totalMinutes = IsFirst ? 1 : 0;
            //            IsFirst = false;
            //        }
            //        totalMinutes = totalMinutes + (int)(log.Timestamp - last).TotalMinutes;
            //        last = log.Timestamp;
            //    }
            //}

            return Json(new { Success = true, Message = "History list ", Data = history.OrderByDescending(x => x.Timestamp) }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult GetLocation(CodeParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var userId = Convert.ToInt32(param.Code);

            var list = (from routeLocation in context.TrakMeRouteLocations
                        join route in context.TrakMeRoutes.Include("Event") on routeLocation.RouteId equals route.RouteId
                        where route.TrakMeEvent.UserId == userId
                        select new Locationparam()
                        {
                            EventId = route.EventId,
                            HoldTime = routeLocation.HoldTime,
                            Latitude = routeLocation.Latitude,
                            Longitude = routeLocation.Longitude,
                            RouteId = routeLocation.RouteId,
                            RouteLocationId = routeLocation.RouteLocationId,
                            ScheduleTime = routeLocation.ScheduleTime,
                            TravelTime = routeLocation.TravelTime,
                            EndTime = route.EndTime.ToString().Substring(0, 8),
                            StartTime = route.StartTime.ToString().Substring(0, 8),
                        }).ToList();

            return Json(new { Success = true, Message = "successfully list genrated", Data = list }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult SetIsTrakable(SetIsTrakableParam param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var participate = context.TrakMeEventParticipates.SingleOrDefault(x => x.Id == param.ParticipateId);
            participate.IsTrackable = param.IsTrackable;

            context.SaveChanges();

            return Json(new { Success = true, Message = "Updated" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region [ Settings ]
        internal JsonResult Settings(TrakMeSettingsParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var set = context.TrakMeSettings.SingleOrDefault(x => x.UserId == param.UserId && x.SettingPara.ToUpper().Trim() == param.SettingPara.Trim().ToUpper());

            if (set == null)
            {
                set = new TrakMeSetting();
                context.TrakMeSettings.Add(set);
            }

            set.UserId = param.UserId;
            set.SettingPara = param.SettingPara;
            set.SettingValue = param.SettingValue;
            context.SaveChanges();

            return Json(new { Success = true, Message = "Settings Added" }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult GetSettings(CodeParameter param)
        {
            var userId = Convert.ToUInt32(param.Code);
            IList<TrakMeSettingsParameter> list = new List<TrakMeSettingsParameter>();
            TrakMEEntities context = new TrakMEEntities();

            context.TrakMeSettings.Where(x => x.UserId == userId).ToList().ForEach(x => list.Add(new TrakMeSettingsParameter()
            {
                SettingPara = x.SettingPara,
                SettingValue = x.SettingValue,
                UserId = x.UserId
            }));

            return Json(new { Success = true, Message = "Settings list generated..", Data = list }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region [ chat ]
        internal JsonResult SendMessage(SendMessageParameter param)
        {
            TrakMEEntities context = new TrakMEEntities();
            context.TrakMeMessages.Add(new TrakMeMessage()
            {
                EventId = param.EventId,
                UserId = param.UserId,
                Message = param.Message,
                TimeSpan = param.TimeSpan == null ? DateTime.UtcNow : param.TimeSpan.Value
            });
            context.SaveChanges();

            var user = context.TrakMeUsers.SingleOrDefault(x => x.UserId == param.UserId);

            context.TrakMeEventViewers.Where(x => x.EventId == param.EventId && x.UserId != param.UserId).ToList()
                .ForEach(x => SendNotification(x.TrakMeUser.AccessCode, param.Message, "Chat",string.Format("{0} ({1})",user.FirstName,user.Email) ,param.EventId));

            context.TrakMeEventParticipates.Where(x => x.EventId == param.EventId && x.UserId != param.UserId && x.IsAccept.Contains("1")).ToList()
                .ForEach(x => SendNotification(x.TrakMeUser.AccessCode, param.Message, "Chat", string.Format("{0} ({1})", user.FirstName, user.Email), param.EventId));

            return GetMessage(new ChatParameter() { EventId = param.EventId , CurrentDateTime = param.TimeSpan.Value });
        }

        internal JsonResult GetMessage(ChatParameter param)
        {
            var StartDate = param.CurrentDateTime.Value.AddDays(-1);

            IList<ReturnMessageParameter> messages = new List<ReturnMessageParameter>();
            TrakMEEntities context = new TrakMEEntities();
            context.TrakMeMessages.Where(x => x.EventId == param.EventId
                                        && x.TimeSpan >= StartDate 
                                        && x.TimeSpan <= param.CurrentDateTime.Value 
                                        ).ToList().ForEach(y => messages.Add(new ReturnMessageParameter()
            {
                EventId = y.EventId,
                UserId = y.UserId,
                UserName = context.TrakMeUsers.SingleOrDefault(z => z.UserId == y.UserId).FirstName,
                Message = y.Message,
                TimeStamp = y.TimeSpan.ToString("yyyy-MM-dd HH:mm:ss")
            }));
            return Json(new { Success = true, Data = messages }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region  [  lat/lon calc ]
        internal double GetEventKM(int eventId, EventListParam param)
        {
            TrakMEEntities context = new TrakMEEntities();
            var list = (from pt in context.TrakMeEventParticipates
                        where pt.EventId == eventId
                        select pt.UserId).ToList();

            if (list.Count() != 0)
            {
                var ulog = context.TrakMeUserLogs.Where(x => list.Contains(x.UserId)).OrderBy(x => x.Timestamp).ToList();
                if (ulog.Count() != 0)
                {
                    var last = ulog.Last();
                    return DistanceTo(Convert.ToDouble(last.Latitude), Convert.ToDouble(last.Longitude), Convert.ToDouble(param.Latitude), Convert.ToDouble(param.Longitude));
                }
                else
                    return 0.0;
            }
            else
                return 0.0;

        }

        internal double DistanceTo(double lat1, double lon1, double lat2, double lon2, char unit = 'K')
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            switch (unit)
            {
                case 'K': //Kilometers -> default
                    return dist * 1.609344;
                case 'N': //Nautical Miles 
                    return dist * 0.8684;
                case 'M': //Miles
                    return dist;
            }

            return dist;
        }
        #endregion


        internal RegisterUserParameter GetUserObject(TrakMeUser user)
        {
            return new RegisterUserParameter()
            {
                AccessCode = user.AccessCode,
                BirthYear = user.BirthYear,
                CityId = user.CityId,
                City = user.TrakMeCity.City,
                Country = user.TrakMeCountry == null ? "" : user.TrakMeCountry.CountryName,
                CountryId = user.CountryId,
                Email = user.Email,
                FirstName = user.FirstName,
                Gender = user.Gender,
                IsPaid = user.IsPaid,
                IsVerified = user.IsVerified,
                LastName = user.LastName,
                Mobile = user.Mobile,
                OccupationId = user.OccupationId,
                Password = user.Password,
                ProfileImage = user.ProfileImage,
                State = user.State,
                StateCode = user.StateCode,
                UserId = user.UserId,
                ZipCode = user.ZipCode,
                Occupation = user.TrakMeEventSubType == null ? "" : user.TrakMeEventSubType.Description,
            };
        }

    }
}