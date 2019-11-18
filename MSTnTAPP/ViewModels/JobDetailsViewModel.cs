using MSTnTAPP.Models.BindableModels;
using MSTnTAPP.Models.Request;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MSTnTAPP.ViewModels
{
    public class JobDetailsViewModel : BaseViewModel
    {
        public JobDetailsViewModel(ShipmentModelView shipment)
        {
            type = shipment.TransportTypeName;
            ShipmentBaseRequest requestObject = new ShipmentBaseRequest()
            {
                JobId = shipment.JobId,
                JobType = shipment.JobType
            };

            if (type == "Air")//Plane
            {
                //Set visibility
                OverviewVisible = true;
                TrackingVisible = true;
                ReferencesVisible = true;
                AddressesVisible = true;
                CarrierVisible = true;
                ContainerVisible = false;
                DocumentVisible = true;
                MapVisible = false;

                //Set Order
                OverviewPosition = 0;
                TrackingPosition = 1;
                AddressesPosition = 2;
                ReferencesPosition = 3;
                CarrierPosition = 4;
                DocumentPosition = 5;
                //MapPosition = ;
                //ContainerPosition = 4;


                MyItemsSource = new ObservableCollection<View>()
                    {
                    //Customize View collection
                    new Views.JobDetailsViews.Overview(shipment),
                    new  Views.JobDetailsViews.Tracking(requestObject),
                    new  Views.JobDetailsViews.Address(requestObject),
                    new  Views.JobDetailsViews.ReferenceView(requestObject),
                    //new  Views.JobDetailsViews.Container(requestObject),
                    new  Views.JobDetailsViews.Carrier(requestObject),
                    new  Views.JobDetailsViews.Document(requestObject),
                    //new  Views.JobDetailsViews.Map(),
                    };
            }
            else if (type == "Sea")//Ship
            {
                //Set visibility
                OverviewVisible = true;
                TrackingVisible = true;
                ReferencesVisible = true;
                AddressesVisible = true;
                CarrierVisible = true;
                ContainerVisible = true;
                DocumentVisible = true;
                MapVisible = false;

                //Set Order
                OverviewPosition = 0;
                TrackingPosition = 1;
                AddressesPosition = 2;
                ReferencesPosition = 3;
                CarrierPosition = 5;
                DocumentPosition = 6;
                //MapPosition = ;
                ContainerPosition = 4;


                MyItemsSource = new ObservableCollection<View>()
                    {
                    //Customize View collection
                    new Views.JobDetailsViews.Overview(shipment),
                    new  Views.JobDetailsViews.Tracking(requestObject),
                    new  Views.JobDetailsViews.Address(requestObject),
                    new  Views.JobDetailsViews.ReferenceView(requestObject),
                    new  Views.JobDetailsViews.Container(requestObject),
                    new  Views.JobDetailsViews.Carrier(requestObject),
                    new  Views.JobDetailsViews.Document(requestObject),
                    //new  Views.JobDetailsViews.Map(),
                    };
            }
            else if (type == "Land")//Truck
            {
                //Set visibility
                OverviewVisible = true;
                TrackingVisible = true;
                ReferencesVisible = true;
                AddressesVisible = true;
                CarrierVisible = true;
                ContainerVisible = true;
                DocumentVisible = true;
                MapVisible = false;

                //Set Order
                OverviewPosition = 0;
                TrackingPosition = 1;
                AddressesPosition = 2;
                ReferencesPosition = 3;
                CarrierPosition = 5;
                DocumentPosition = 6;
                //MapPosition = ;
                ContainerPosition = 4;


                MyItemsSource = new ObservableCollection<View>()
                    {
                    //Customize View collection
                    new Views.JobDetailsViews.Overview(shipment),
                    new  Views.JobDetailsViews.Tracking(requestObject),
                    new  Views.JobDetailsViews.Address(requestObject),
                    new  Views.JobDetailsViews.ReferenceView(requestObject),
                    new  Views.JobDetailsViews.Container(requestObject),
                    new  Views.JobDetailsViews.Carrier(requestObject),
                    new  Views.JobDetailsViews.Document(requestObject),
                    //new  Views.JobDetailsViews.Map(),
                    };
            }

            //No need to get in the if - else
            //Generate Grid binded object
            ViewrelationObjectList = new List<viewrelationObject>()
                {
                    new viewrelationObject()
                    {
                        Position = OverviewPosition,
                        Pointer = "Overview"
                    },
                    new viewrelationObject()
                    {
                        Position = TrackingPosition,
                        Pointer = "Tracking"
                    },
                    new viewrelationObject()
                    {
                        Position = AddressesPosition,
                        Pointer = "Addresses"
                    },
                    new viewrelationObject()
                    {
                        Position = ReferencesPosition,
                        Pointer = "Reference"
                    },
                    new viewrelationObject()
                    {
                        Position = ContainerPosition,
                        Pointer = "Container"
                    },
                    new viewrelationObject()
                    {
                        Position = CarrierPosition,
                        Pointer = "Carrier"
                    },
                    new viewrelationObject()
                    {
                        Position = DocumentPosition,
                        Pointer = "Document"
                    },
                    new viewrelationObject()
                    {
                        Position = MapPosition,
                        Pointer = "Map"
                    }
                };
        }

        #region Public Property
        public List<viewrelationObject> ViewrelationObjectList { get; set; }
        public string type { get; set; }
        public ObservableCollection<View> MyItemsSource
        {
            set
            {
                _myItemsSource = value;
                OnPropertyChanged("MyItemsSource");
            }
            get
            {
                return _myItemsSource;
            }
        }
        public int OverviewPosition
        {
            get
            {
                return _OverviewPosition;
            }
            set
            {
                _OverviewPosition = value;
                OnPropertyChanged("OverviewPosition");
            }
        }
        public int TrackingPosition
        {
            get
            {
                return _TrackingPosition;
            }
            set
            {
                _TrackingPosition = value;
                OnPropertyChanged("TrackingPosition");
            }
        }
        public int AddressesPosition
        {
            get
            {
                return _AddressesPosition;
            }
            set
            {
                _AddressesPosition = value;
                OnPropertyChanged("AddressesPosition");
            }
        }
        public int ReferencesPosition
        {
            get
            {
                return _ReferencesPosition;
            }
            set
            {
                _ReferencesPosition = value;
                OnPropertyChanged("ReferencesPosition");
            }
        }
        public int CarrierPosition
        {
            get
            {
                return _CarrierPosition;
            }
            set
            {
                _CarrierPosition = value;
                OnPropertyChanged("CarrierPosition");
            }
        }
        public int ContainerPosition
        {
            get
            {
                return _ContainerPosition;
            }
            set
            {
                _ContainerPosition = value;
                OnPropertyChanged("ContainerPosition");
            }
        }
        public int DocumentPosition
        {
            get
            {
                return _DocumentPosition;
            }
            set
            {
                _DocumentPosition = value;
                OnPropertyChanged("DocumentPosition");
            }
        }
        public int MapPosition
        {
            get
            {
                return _MapPosition;
            }
            set
            {
                _MapPosition = value;
                OnPropertyChanged("MapPosition");
            }
        }
        public bool OverviewVisible
        {
            get
            {
                return _visible1;
            }
            set
            {
                _visible1 = value;
                OnPropertyChanged("OverviewVisible");
            }
        }
        public bool TrackingVisible
        {
            get
            {
                return _visible2;
            }
            set
            {
                _visible2 = value;
                OnPropertyChanged("TrackingVisible");
            }
        }
        public bool AddressesVisible
        {
            get
            {
                return _visible3;
            }
            set
            {
                _visible3 = value;
                OnPropertyChanged("AddressesVisible");
            }
        }
        public bool ReferencesVisible
        {
            get
            {
                return _visible4;
            }
            set
            {
                _visible4 = value;
                OnPropertyChanged("ReferencesVisible");
            }
        }
        public bool CarrierVisible
        {
            get
            {
                return _visible5;
            }
            set
            {
                _visible5 = value;
                OnPropertyChanged("CarrierVisible");
            }
        }
        public bool ContainerVisible
        {
            get
            {
                return _visible6;
            }
            set
            {
                _visible6 = value;
                OnPropertyChanged("ContainerVisible");
            }
        }
        public bool DocumentVisible
        {
            get
            {
                return _visible7;
            }
            set
            {
                _visible7 = value;
                OnPropertyChanged("DocumentVisible");
            }
        }
        public bool MapVisible
        {
            get
            {
                return _visible8;
            }
            set
            {
                _visible8 = value;
                OnPropertyChanged("MapVisible");
            }
        }
        #endregion

        #region Private Property
        bool _visible1;
        bool _visible2;
        bool _visible3;
        bool _visible4;
        bool _visible5;
        bool _visible6;
        bool _visible7;
        bool _visible8;

        ObservableCollection<View> _myItemsSource;

        private int _OverviewPosition { get; set; }
        private int _MapPosition { get; set; }
        private int _DocumentPosition { get; set; }
        private int _ContainerPosition { get; set; }
        private int _CarrierPosition { get; set; }
        private int _ReferencesPosition { get; set; }
        private int _AddressesPosition { get; set; }
        private int _TrackingPosition { get; set; }
        #endregion
    }

    public class viewrelationObject
    {
        public int Position { get; set; }
        public string Pointer { get; set; }
    }
}