using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSUKariyer.BUS
{
    public partial class CVs
    {
        public class Forms
        {
            public enum MenuGroup
            {
                Welcome = 0,
                PersonalInfo = 1,
                EducationInfo = 2,
                WorkExperiences = 3,
                CVState = 4,
                Photo = 5
            }
            public struct ControlOrders
            {
                public const int WelcomeForm = 1;
                public const int PersonalInfoForm = 2;
                public const int ContactInfoForm = 3;
                public const int CityCountryInfoForm = 4;
                public const int CigaretteUsage = 5;
                public const int SocialClubs = 6;
                public const int EducationState = 7;
                public const int MasterInfo = 8;
                public const int UniversityInfo = 9;
                public const int HighSchoolInfo = 10;
                public const int LanguageInfo = 11;
                public const int ComputerInfo = 12;
                public const int CertificateInfo = 13;
                public const int ExamInfo = 14;
                public const int CourseInfo = 15;
                public const int DrivingLicense = 16;
                public const int InterestedJobPositions = 17;
                public const int WorkExperinces = 18;
                public const int Referances = 19;
                public const int CVState = 20;
                public const int Photo = 21;
                public const int CVResult = 22;
            }

            public static MenuGroup FindMenuGroup(int controlOrder)
            {
                MenuGroup retval= MenuGroup.Welcome;

                if (controlOrder == ControlOrders.WelcomeForm)
                    retval = MenuGroup.Welcome;
                else if (controlOrder >= ControlOrders.PersonalInfoForm && controlOrder <= ControlOrders.SocialClubs)
                    retval = MenuGroup.PersonalInfo;
                else if (controlOrder >= ControlOrders.EducationState && controlOrder <= ControlOrders.DrivingLicense)
                    retval = MenuGroup.EducationInfo;
                else if (controlOrder >= ControlOrders.InterestedJobPositions && controlOrder <= ControlOrders.CVState)
                    retval = MenuGroup.WorkExperiences;
                else if (controlOrder == ControlOrders.CVState)
                    retval = MenuGroup.CVState;
                else if (controlOrder == ControlOrders.Photo)
                    retval = MenuGroup.Photo;

                return retval;
            }
        }
    }
}
