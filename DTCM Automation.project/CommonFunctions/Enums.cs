using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTCM_Automation.project.CommonFunctions
{
   public class Enums
    {
        public enum Users
        {
            // Done
            Admin,
            Stackholder,
            Retailer,
            Poi,
            Configuration,

        }
        public enum Decisions
        {
            // Done
            Approve,
            Sendback,
            Cancel
        }
        public enum Stages
        {
            // Done
            Submission,
            Reviewdecision,
            Employeedecision,
            Managerdecision

        }

        public enum AccountType
        {
            Retailer,
            POI,
            RetailerandPOI
        }

        public enum LisenceNumber
        {
            DED,
            NonDED
        }

        public enum CalendarType
        {
            RetailCalendar,
            OffSeasonCalendar
        }

        public enum EventType
        {
            Festival,
            Activation,
            Offseasonperiod
        }

        public static Dictionary<Decisions, string> decisionsValues = new Dictionary<Decisions, string>()
        {
            // Done

            { Decisions.Approve,"Approve" },
            { Decisions.Sendback,"Send Back"},
            { Decisions.Cancel,"Cancel" }
        };

        public static Dictionary<Stages, string> StagesValues = new Dictionary<Stages, string>()
        {
            // Done
            { Stages.Submission,"Submission" },
            { Stages.Reviewdecision,"Review Decision"},
            { Stages.Employeedecision,"Employee Decision" },
            { Stages.Managerdecision,"Manager Decision" }
        };

        public static Dictionary<AccountType, string> Accounttype = new Dictionary<AccountType, string>()
        {
            // Done

            { AccountType.Retailer,"Retailer" },
            { AccountType.POI,"POI"},
            { AccountType.RetailerandPOI,"Retailer and POI" }
        };

        public static Dictionary<LisenceNumber, string> lisenceNumber = new Dictionary<LisenceNumber, string>()
        {
            // Done

            { LisenceNumber.DED,"DED" },
            { LisenceNumber.NonDED,"Non DED"},
        };

        public static Dictionary<CalendarType, string> calendarType = new Dictionary<CalendarType, string>()
        {
            // Done

            { CalendarType.RetailCalendar,"Retail Calendar" },
            { CalendarType.OffSeasonCalendar,"Off Season Calendar"},
        };

        public enum ServiceName 
        {// Done
            Login,
            Register,
            accountregistration,
            CompanyManagement3,
            RequestChangeCompanyCluster,
            RequestChangeBrandCategory,
            RequestAssociatetogoc,
            AddNewPoi,
            UpdatePoiType,
            calendarparticipationrequest,
            initiativeparticipationrequest,
            SubInitiativeParticipationReq
        };
        

        public static Dictionary<ServiceName, string> ServiceNameValue = new Dictionary<ServiceName, string>()
        {
            { ServiceName.Register,"register"},
            { ServiceName.accountregistration,"account-registration"},
            {ServiceName.CompanyManagement3,"CompanyManagement/3" },
            { ServiceName.Login,"Login" },
            { ServiceName.RequestChangeCompanyCluster,"RequestChangeCompanyCluster" },
            { ServiceName.RequestChangeBrandCategory,"RequestChangeBrandCategory" },
            { ServiceName.RequestAssociatetogoc,"RequestAssociatetogoc" },
            { ServiceName.AddNewPoi,"AddNewPoi" },
            { ServiceName.UpdatePoiType,"UpdatePoiType" },
            { ServiceName.calendarparticipationrequest,"calendarparticipationrequest" },
            { ServiceName.initiativeparticipationrequest,"initiativeparticipationrequest" },
            { ServiceName.SubInitiativeParticipationReq,"SubInitiativeParticipationReq" }
        };

        public enum Lisencetype
        {
            DED,
            NONDED
        }
        public static Dictionary<Lisencetype, string> lisencetype = new Dictionary<Lisencetype, string>()
        {

            { Lisencetype.DED,"DED".ToLower()},
            { Lisencetype.NONDED,"Non DED"}

        };

        public enum BranchType
        {
            Mall,
            Standalone
        }


        public enum Cluster
        {
            Singlebrand,
            Multiplebrand,
            Estore,
            Shoppingcenter,
            Restaurant,
            Distributor,
            Singlebrandanddistributor,
            Multiplebrandanddistributor
        }

        public static Dictionary<Cluster, string> clustervalue = new Dictionary<Cluster, string>()
        {

            { Cluster.Singlebrand,"Single brand".ToLower()},
            { Cluster.Multiplebrand,"Multiple brand".ToLower()},
            { Cluster.Estore,"E-store".ToLower()},
            { Cluster.Shoppingcenter,"Shopping center".ToLower()},
            { Cluster.Restaurant,"Restaurant".ToLower()},
            { Cluster.Distributor,"Distributor".ToLower()},
            { Cluster.Singlebrandanddistributor,"Single brand and distributor".ToLower()},
            { Cluster.Multiplebrandanddistributor,"Multiple brand and distributor".ToLower()},
        };

        //TODO POI Types
        public enum PoiType
        {
            type1,
            type2
        };
        //TODO POI sub-Types
        public enum PoiSubType
        {
            type1,
            type2
        };

        public enum Department
        {
            BusinessDevelopmentandSales,
            Managementandleadership,
            Marketingandcommunication,
            publicrelationsandoperations
        };
        public Dictionary<Department, string> department = new Dictionary<Department, string>()
        {
            
            { Department.BusinessDevelopmentandSales,"Business Development & Sales".ToLower()},
            { Department.Managementandleadership,"Management & leadership".ToLower()},
            { Department.Marketingandcommunication,"Marketing & communication".ToLower()},
            { Department.publicrelationsandoperations,"public relations & operations".ToLower()}

        };

        public enum PositionLevel
        {
            testposition
        }
        public Dictionary<PositionLevel, string> positionlevel = new Dictionary<PositionLevel, string>()
        {

            { PositionLevel.testposition,"Position Level".ToLower()},

        };

        public enum Participationselection
        {
            Brands,
            Branchs,
            Both
        }

        public enum Promotions
        {
            Discount,
            Sale,
            PartSale,
            Offer,
            Kiosk,
            Raffle,
            Scratchandwin
        }
        public enum SponsorType
        {
            None,
            Strategic,
            Sponsor
        }

    }
}
