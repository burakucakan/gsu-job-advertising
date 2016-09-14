using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GSUKariyer.COMMON;

namespace GSUKariyer.BUS
{
    public class AdminSiteParams : SiteParams
    {
        static AdminSiteParams()
        {
            TurkeyCitiesCacheDuration = CacheDuration.FiveMinutes;
            CountriesCacheDuration = CacheDuration.FiveMinutes;
            PositionsCacheDuration = CacheDuration.FiveMinutes;
            SectorsCacheDuration = CacheDuration.FiveMinutes;
            GSClubsCacheDuration = CacheDuration.FiveMinutes;
            GenderCacheDuration = CacheDuration.FiveMinutes;
            MaritalStatusCacheDuration = CacheDuration.FiveMinutes;
            CigaretteUseTypeCacheDuration = CacheDuration.FiveMinutes;
            ContactTypeCacheDuration = CacheDuration.FiveMinutes;
            EducationStateCacheDuration = CacheDuration.FiveMinutes;
            EducationGradeSystemCacheDuration = CacheDuration.FiveMinutes;
            UniversityInfoCacheDuration = CacheDuration.FiveMinutes;
            CertificateCategoryCacheDuration = CacheDuration.FiveMinutes;
            AdvertisementTypeCacheDuration = CacheDuration.FiveMinutes;
            SiteContentTypeCacheDuration = CacheDuration.FiveMinutes;
            LanguagesCacheDuration = CacheDuration.FiveMinutes;
            ExamCacheDuration = CacheDuration.FiveMinutes;
            WorkerCountCacheDuration = CacheDuration.FiveMinutes;
            WorkingTypeCacheDuration = CacheDuration.FiveMinutes;
            PersonalCountCacheDuration = CacheDuration.FiveMinutes;
            ExperienceCacheDuration = CacheDuration.FiveMinutes;
            CVStatesCacheDuration = CacheDuration.FiveMinutes;
            WorkingStateCacheDuration = CacheDuration.FiveMinutes;
            WorkingExperienceCacheDuration = CacheDuration.FiveMinutes;
            UserAgeCacheDuration = CacheDuration.FiveMinutes;
            LastUploadedExcelFileCacheDuration = CacheDuration.None;
        }
    }
}
