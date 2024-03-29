﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTCM_Automation.project.CommonFunctions
{
   public class Enums
    {
        public enum Participationtype
        {
            promotion,
            participation
        }
        public enum ServiceName
        {// Done
            Register,
            accountregistration,
            RequestChangeCompanyCluster,
            RequestChangeBrandCategory,
            RequestAssociatetogoc,
            AddNewPoi,
            UpdatePoiType,
            calendarparticipationrequest,
            initiativeparticipationrequest
        };

        public Dictionary<ServiceName, string> servicename = new Dictionary<ServiceName, string>()
        {
            { ServiceName.Register,"register".ToLower()},
            { ServiceName.accountregistration,"account-registration".ToLower()},

        };

        public enum Lisencetype
        {
            DED,
            NONDED
        }
        public Dictionary<Lisencetype, string> lisencetype = new Dictionary<Lisencetype, string>()
        {

            { Lisencetype.DED,"DED".ToLower()},
            { Lisencetype.NONDED,"NON DED".ToLower()}

        };



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

        public Dictionary<Cluster, string> cluster = new Dictionary<Cluster, string>()
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

    }
}
