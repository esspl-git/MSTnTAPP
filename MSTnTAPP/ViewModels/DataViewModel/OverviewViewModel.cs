using MSTnTAPP.Models;
using MSTnTAPP.Models.BindableModels;
using MSTnTAPP.Util.Enum.DataEnum;
using System.Collections.Generic;

namespace MSTnTAPP.ViewModels.DataViewModel
{
    public class OverviewViewModel:BaseViewModel
    {
        public OverviewViewModel(ShipmentModelView shipment)
        {
            ShipmentImage = shipment.ShipmentImageOverview;
            JobReferenceNumber = shipment.JobReferenceNumber;
            Place_Date = shipment.Place_Date;

            OverviewList = new List<Keyvalue>()
            {
                new Keyvalue()
                {
                    Key = OverView.Trasport_Type,
                    Value = shipment.TransportTypeName,
                },
                new Keyvalue()
                {
                    Key = OverView.Customer_Reference,
                    Value = shipment.CustomerReference,
                },
                new Keyvalue()
                {
                    Key = OverView.Job_Reference,
                    Value = shipment.JobReferenceNumber,
                },
                new Keyvalue()
                {
                    Key = OverView.Place_Of_Receipt,
                    Value = shipment.PlaceOfReceipt,
                },
                new Keyvalue()
                {
                    Key = OverView.Vessel_Name,
                    Value = shipment.VesselName,
                },
                new Keyvalue()
                {
                    Key = OverView.Port_Of_Loading,
                    Value = shipment.PortOfLoading,
                },
                new Keyvalue()
                {
                    Key = OverView.Port_of_Discharge,
                    Value = shipment.PortOfLoading,
                },
                new Keyvalue()
                {
                    Key = OverView.Final_Destination,
                    Value = shipment.PortOfLoading,
                },
                new Keyvalue()
                {
                    Key = OverView.ETA,
                    Value = shipment._ETA,
                },
                new Keyvalue()
                {
                    Key = OverView.Pieces,
                    Value = shipment.Pieces,
                },
                new Keyvalue()
                {
                    Key = OverView.ShipperName,
                    Value = shipment.ShipperName,
                },
                new Keyvalue()
                {
                    Key = OverView.ConsigeeName,
                    Value = shipment.ConsigneeName,
                }
            };
        }

        #region Private Property
        private string shipmentImage { get; set; }
        private string jobReferenceNumber { get; set; }
        private string place_Date { get; set; }
        private IList<Keyvalue> overviewList { get; set; }
        #endregion

        #region Public Property
        public string ShipmentImage
        {
            get
            {
                return shipmentImage;
            }
            set
            {
                shipmentImage = value;
                OnPropertyChanged("ShipmentImage");
            }
        }
        public string JobReferenceNumber
        {
            get
            {
                return jobReferenceNumber;
            }
            set
            {
                jobReferenceNumber = value;
                OnPropertyChanged("JobReferenceNumber");
            }
        }
        public string Place_Date
        {
            get
            {
                return place_Date;
            }
            set
            {
                place_Date = value;
                OnPropertyChanged("Place_Date");
            }
        }
        public IList<Keyvalue> OverviewList { 
            get
            {
                return overviewList;
            }
            set
            {
                overviewList = value;
                OnPropertyChanged("OverviewList");
            }
        }
        #endregion
    }
}
