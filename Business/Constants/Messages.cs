using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string SuccessfullyAdded = "Successfully Added";
        public static string SuccessfullyUpdated = "Successfully Updated";
        public static string AuthorizationDenied="AuthorizationDenied";
        public static string UserRegistered="Bele istifadeci artiq elave olunub";
        public static string UserNotFound="Istifadeci tapilmadi";
        public static string PasswordError="Yanlis sifre";
        public static string SuccessfulLogin="Ugurla Login oldu!";
        public static string UserAlreadyExists="Bele Istifadeci artiq var";
        public static string AccessTokenCreated="AccessToken Created";
        public static string SuccessfullyDeleted = "Ugurla Silindi";
        public static string EntityNotFound = "Bu Id ile match tapilmadi";
        public static string NoData = "Data yoxdur bazada";
        public static string NotAdded = "Elave olunmadi";
        public static string NotUpdated= "Duzelis olunmadi";

    }
}
