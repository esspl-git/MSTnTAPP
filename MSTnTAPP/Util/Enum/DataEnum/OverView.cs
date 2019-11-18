using System;
using System.Collections.Generic;
using System.Text;

namespace MSTnTAPP.Util.Enum.DataEnum
{
    public static class OverView
    {
        public const string Trasport_Type = "Transport Type";
        public const string Customer_Reference = "Customer Reference";
        public const string Job_Reference = "Job Reference";
        public const string Place_Of_Receipt = "Place Of Receipt";
        public const string Vessel_Name = "Vessel Name";
        public const string Port_Of_Loading = "Port Of Loading";
        public const string Port_of_Discharge = "Port of Discharge";
        public const string Final_Destination = "Final Destination";
        public const string ETD = "ETD";
        public const string ETA = "ETA";
        public const string Product_Description = "Product Description";
        public const string Pieces = "Pieces";
        public const string Summary = "Summary";
        public const string ShipperName = "ShipperName";
        public const string ConsigeeName = "ConsigeeName";


        public static List<string> GetAllType = new List<string>()
        {
                Trasport_Type,
                Customer_Reference,
                Job_Reference,
                Place_Of_Receipt,
                Vessel_Name,
                Port_Of_Loading,
                Port_of_Discharge,
                Final_Destination,
                ETD,
                ETA,
                Product_Description,
                Pieces,
                Pieces,
                ShipperName,
                ConsigeeName
        };
    }
}
