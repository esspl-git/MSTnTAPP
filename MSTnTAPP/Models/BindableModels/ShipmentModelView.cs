using System;

namespace MSTnTAPP.Models.BindableModels
{
    public class ShipmentModelView:Shipment
    {
        public ShipmentModelView(Shipment shipment)
        {
            JobReferenceNumber = shipment.JobReferenceNumber;
            JobId = shipment.JobId;
            JobType = shipment.JobType;
            TransportType = shipment.TransportType;
            TransportDirection = shipment.TransportDirection;
            ConsigneeName = shipment.ConsigneeName;
            DateSailed = shipment.DateSailed;
            CustomerReference = shipment.CustomerReference;
            PlaceOfReceipt = shipment.PlaceOfReceipt;
            VesselName = shipment.VesselName;
            PortOfLoading = shipment.PortOfLoading;
            PortOfDischarge = shipment.PortOfDischarge;
            FinalDestination = shipment.FinalDestination;
            ETA = shipment.ETA;
            Pieces = shipment.Pieces;
            Summary = shipment.Summary;
            ShipperName = shipment.ShipperName;
        }
        //Custom
        public string ShipmentImage
        {
            get
            {
                if (TransportType.Equals("Air"))
                {
                    return "plane.png";
                }
                else if (TransportType.Equals("Sea"))
                {
                    return "ship.png";
                }
                else if (TransportType.Equals("Land"))
                {
                    return "truck.png";
                }
                return "";
            }
        }
        public string ShipmentImageOverview
        {
            get
            {
                if (TransportType.Equals("Air") && TransportDirection.Equals("Export"))
                {
                    return "planeright.png";
                }
                else if (TransportType.Equals("Air") && TransportDirection.Equals("Import"))
                {
                    return "planeleft.png";
                }
                else if (TransportType.Equals("Sea") && TransportDirection.Equals("Export"))
                {
                    return "shipright.png";
                }
                else if (TransportType.Equals("Sea") && TransportDirection.Equals("Import"))
                {
                    return "shipleft.png";
                }
                else if (TransportType.Equals("Land") && TransportDirection.Equals("Export"))
                {
                    return "truckright.png";
                }
                else if (TransportType.Equals("Land") && TransportDirection.Equals("Import"))
                {
                    return "truckleft.png";
                }
                return "";
            }
        }
        public string _DateSailed
        {
            get
            {
                if (DateSailed == null)
                {
                    return DateTime.Now.ToString("dd MMMM yyyy");
                }
                else
                {
                    return ((DateTime)DateSailed).ToString("dd MMMM yyyy");
                }
            }
        }
        public string _ETA
        {
            get
            {
                if (ETA == null)
                {
                    return DateTime.Now.ToString("dd MMMM yyyy");
                }
                else
                {
                    return ((DateTime)ETA).ToString("dd MMMM yyyy");
                }
            }
        }
        public string Place_Date
        {
            get
            {
                return PlaceOfReceipt + " | " + _DateSailed;
            }
        }
        public string TransportTypeName
        {
            get
            {
                return TransportType;
            }
        }
    }
}
