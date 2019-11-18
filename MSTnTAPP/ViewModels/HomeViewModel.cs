using System;
using MSTnTAPP.Services;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MSTnTAPP.Models.BindableModels;
using MSTnTAPP.Models;
using MSTnTAPP.Models.Response;

namespace MSTnTAPP.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            RecentSearches = new ObservableCollection<ShipmentModelView>();
            SearchList = new ObservableCollection<ShipmentModelView>();

            SkipItemCount = 0;
            sts = new ShipmentTrackingService();
            SearchTypeList = sts.GetSearchTypeList();
            RecentSearchItems();
        }

        #region Variables
        ShipmentTrackingService sts;
        #endregion

        #region Public Properties
        public IList<SearchCriterion> SearchTypeList { get; private set; }
        public ObservableCollection<ShipmentModelView> RecentSearches { get; set; }
        public ObservableCollection<ShipmentModelView> SearchList { get; set; }
        public int SkipItemCount { get; private set; }
        public ShipmentResponse SearchedItemList { get; private set; }
        public double ListHeight { get; private set; }
        public bool ISBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                OnPropertyChanged("ISBusy");
            }
        }
        #endregion

        #region Private Properties
        private bool isBusy { get; set; }
        #endregion

        #region Methods
        public async void RecentSearchItems()
        {
            SearchedItemList = await sts.GetRecentSearches(AppSettings.ListItemCount);


            if (SearchedItemList.ReturnMessage == "API Token Invalid")
            {
                //ResultMessage = SearchedItemList.ReturnMessage;
            }
            else
            {
                foreach (Shipment s in SearchedItemList.Shipments)
                {
                    RecentSearches.Add(new ShipmentModelView(s));
                }
            }
        }
        public async Task<bool> SearchForItems(string searchTerm, int searchTypeId, string searchTypeName)
        {
            SkipItemCount = 0;
            ISBusy = true;
            SearchedItemList = await sts.GetShipments(searchTypeName, searchTerm, AppSettings.ListItemCount, SkipItemCount);
            if (SearchedItemList.ReturnMessage == "API Token Invalid")
            {
                ISBusy = false;
                return await Task.FromResult(false);
            }
            else
            {
                SkipItemCount += SearchedItemList.Shipments.Count;
                foreach (Shipment s in SearchedItemList.Shipments)
                {
                    SearchList.Add(new ShipmentModelView(s));
                }

                if (SearchList.Count > 0)
                {
                    ListHeight = SearchList.Count * 80 *0.8;
                    ISBusy = false;
                    return await Task.FromResult(true);
                }
                else
                {
                    ISBusy = false;
                    return await Task.FromResult(false);
                }
            }
        }
        public async Task<ShipmentModelView> GetNextItem(string searchTerm, int searchTypeId, string searchTypeName)
        {
            ISBusy = true;
            SearchedItemList = await sts.GetShipments(searchTypeName, searchTerm, AppSettings.ListItemCount, SkipItemCount);

            if (SearchedItemList.ReturnMessage == "API Token Invalid")
            {
                ISBusy = false;
                return await Task.FromResult(new ShipmentModelView(new Shipment()));
            }
            else
            {

                SkipItemCount += SearchedItemList.Shipments.Count;

                foreach (Shipment s in SearchedItemList.Shipments)
                { SearchList.Add(new ShipmentModelView(s)); }

                if (SearchList.Count > 0)
                {
                    ListHeight = SearchList.Count * 80 * 0.8;
                }
                ISBusy = false;
                return await Task.FromResult(new ShipmentModelView(SearchedItemList.Shipments[0]));
            }
        }
        #endregion
    }

    #region OLD
    //public class HomeViewModel : BaseViewModel
    //{
    //    ShipmentTrackingService sts;
    //    Boolean isBusy;
    //    Double frameHeight;
    //    String listLabel;
    //    Boolean isMenuVisible;

    //    private IList<ShipmentModelView> transportItems;
    //    private ShipmentListResponse recentSearchList;
    //    private ShipmentListResponse searchedItemList;
    //    private IList<SearchCriterion> searchTypeList;

    //    GetShipmentsRequest getShipmentsRequest;
    //    private IList<ShipmentModelView> recentTransportItems { get; set; }

    //    private bool isLoaded { get; set; }
    //    private bool isSearchLoaded { get; set; }
    //    private bool isError { get; set; }

    //    private bool isAvailable { get; set; }

    //    public int skipItemCount { get; set; }
    //    public int SkipItemCount
    //    {
    //        get
    //        {
    //            return skipItemCount;
    //        }
    //        set
    //        {
    //            skipItemCount = value;
    //        }
    //    }

    //    public HomeViewModel()
    //    {
    //        SkipItemCount = 0;
    //        sts = new ShipmentTrackingService();
    //        IsLoaded = false;
    //        IsError = false;
    //        SearchTypeList = new MetroDataService().GetSearchTypeList();
    //        RecentSearchItems();
    //        IsBusy = false;
    //        IsAvailable = false;
    //        IsMenuVisible = false;
    //    }
    //    public IList<ShipmentModelView> TransportItems
    //    {
    //        get { return transportItems; }
    //        set
    //        {
    //            Console.WriteLine("Inside get");
    //            transportItems = value;
    //            OnPropertyChanged("TransportItems");
    //        }
    //    }
    //    public IList<ShipmentModelView> RecentTransportItems
    //    {
    //        get { return recentTransportItems; }
    //        set
    //        {
    //            Console.WriteLine("Inside get");
    //            recentTransportItems = value;
    //            OnPropertyChanged("RecentTransportItems");
    //        }
    //    }
    //    public ShipmentListResponse RecentSearchList
    //    {
    //        get { return recentSearchList; }
    //        set
    //        {
    //            recentSearchList = value;
    //            OnPropertyChanged("RecentSearchList");
    //        }
    //    }
    //    public ShipmentListResponse SearchedItemList
    //    {
    //        get { return searchedItemList; }
    //        set
    //        {
    //            searchedItemList = value;
    //            OnPropertyChanged("SearchedItemList");
    //        }
    //    }
    //    public Boolean IsBusy
    //    {
    //        get { return isBusy; }
    //        set
    //        {
    //            isBusy = value;
    //            OnPropertyChanged("IsBusy");
    //        }
    //    }

    //    public Boolean IsError
    //    {
    //        get { return isError; }
    //        set
    //        {
    //            isError = value;
    //            OnPropertyChanged("IsError");
    //        }
    //    }
    //    public string resultMessage { get; set; }
    //    public string ResultMessage
    //    {
    //        get { return resultMessage; }
    //        set
    //        {
    //            resultMessage = value;
    //            OnPropertyChanged("ResultMessage");
    //        }
    //    }
    //    public Boolean IsLoaded
    //    {
    //        get { return isLoaded; }
    //        set
    //        {
    //            isLoaded = value;
    //            OnPropertyChanged("IsLoaded");
    //        }
    //    }
    //    public Boolean IsSearchLoaded
    //    {
    //        get { return isSearchLoaded; }
    //        set
    //        {
    //            isSearchLoaded = value;
    //            OnPropertyChanged("IsSearchLoaded");
    //        }
    //    }
    //    public Boolean IsAvailable
    //    {
    //        get { return isAvailable; }
    //        set
    //        {
    //            isAvailable = value;
    //            OnPropertyChanged("IsAvailable");
    //        }
    //    }
    //    public Double FrameHeight
    //    {
    //        get { return frameHeight + 20; }
    //    }
    //    public Double ListHeight
    //    {
    //        get { return frameHeight; }
    //        set
    //        {
    //            frameHeight = value;
    //            OnPropertyChanged("ListHeight");
    //        }
    //    }
    //    public String ListLabel
    //    {
    //        get { return listLabel; }
    //        set
    //        {
    //            listLabel = value;
    //            OnPropertyChanged("ListLabel");
    //        }
    //    }
    //    public Boolean IsMenuVisible
    //    {
    //        get { return isMenuVisible; }
    //        set
    //        {
    //            isMenuVisible = value;
    //            OnPropertyChanged("IsMenuVisible");
    //        }
    //    }
    //    public IList<SearchCriterion> SearchTypeList
    //    {
    //        get { return searchTypeList; }
    //        set
    //        {
    //            searchTypeList = value;
    //            OnPropertyChanged("SearchTypeList");
    //        }
    //    }
    //    public async Task<bool> SearchForItems(string searchTerm, int searchTypeId, string searchTypeName)
    //    {
    //        IsBusy = true;
    //        IsError = false;
    //        IsSearchLoaded = false;
    //        SkipItemCount = 0;
    //        getShipmentsRequest = new GetShipmentsRequest()
    //        {
    //            SearchOn = searchTypeName,
    //            SearchTerm = searchTerm,
    //            SkipItemCount = SkipItemCount
    //        };
    //        SearchedItemList = await sts.GetShipments(searchTypeName, searchTerm, AppSettings.ListItemCount, SkipItemCount);
    //        if (SearchedItemList.ReturnMessage == "API Token Invalid")
    //        {
    //            IsBusy = false;
    //            //IsLoaded = true;
    //            IsError = true;
    //            IsSearchLoaded = true;
    //            ResultMessage = SearchedItemList.ReturnMessage;
    //            return await Task.FromResult(false);
    //        }
    //        else
    //        {
    //            if (SearchedItemList.Shipments.Count == AppSettings.ListItemCount)
    //            {
    //                IsAvailable = true;
    //            }
    //            else
    //            {
    //                IsAvailable = false;
    //            }
    //            SkipItemCount += SearchedItemList.Shipments.Count;

    //            TransportItems = new List<ShipmentModelView>();
    //            foreach (Shipment s in SearchedItemList.Shipments)
    //            {
    //                TransportItems.Add(new ShipmentModelView(s));
    //            }

    //            ListLabel = "Search Result";
    //            IsBusy = false;
    //            IsSearchLoaded = true;
    //            //IsLoaded = true;
    //            IsMenuVisible = true;

    //            //var height = 20 + (TransportItems.Count * 80);
    //            if (TransportItems.Count > 0)
    //            {
    //                ListHeight = TransportItems.Count * 85;
    //                return await Task.FromResult(true);
    //            }
    //            else
    //            {
    //                // ListHeight = Constants.LIST_FRAME_HEIGHT;
    //                return await Task.FromResult(false);
    //            }
    //        }
    //    }

    //    public async void RecentSearchItems()
    //    {
    //        SearchedItemList = await sts.GetRecentSearches(AppSettings.ListItemCount);


    //        if (SearchedItemList.ReturnMessage == "API Token Invalid")
    //        {
    //            IsBusy = false;
    //            IsLoaded = true;
    //            IsError = true;
    //            ResultMessage = SearchedItemList.ReturnMessage;
    //        }
    //        else
    //        {
    //            RecentTransportItems = new List<ShipmentModelView>();
    //            foreach (Shipment s in SearchedItemList.Shipments)
    //            {
    //                RecentTransportItems.Add(new ShipmentModelView(s));
    //            }

    //            ListLabel = "Recent Search";
    //            IsMenuVisible = false;
    //        }
    //    }

    //    public async Task<ShipmentModelView> GetNextItem(string searchTerm, int searchTypeId, string searchTypeName)
    //    {
    //        //Show Loader
    //        IsBusy = true;
    //        IsLoaded = false;

    //        //Make Request Object
    //        getShipmentsRequest = new GetShipmentsRequest()
    //        {
    //            SearchOn = searchTypeName,
    //            SearchTerm = searchTerm,
    //            SkipItemCount = SkipItemCount
    //        };

    //        //Get API responce Object type ShipmentListResponse
    //        SearchedItemList = await sts.GetShipments(searchTypeName, searchTerm, AppSettings.ListItemCount, SkipItemCount);

    //        //Check for Valid Response
    //        if (SearchedItemList.ReturnMessage == "API Token Invalid")
    //        {
    //            IsBusy = false;
    //            IsLoaded = true;
    //            IsError = true;
    //            ResultMessage = SearchedItemList.ReturnMessage;
    //            return await Task.FromResult(new ShipmentModelView(new Shipment()));
    //        }
    //        else
    //        {
    //            //Checking for "View More" button Visibility
    //            if (SearchedItemList.Shipments.Count == AppSettings.ListItemCount)
    //            {
    //                //SearchedItemList.Shipments.RemoveAt(AppSettings.ListItemCount);
    //                IsAvailable = true;
    //            }
    //            else
    //            {
    //                IsAvailable = false;
    //            }

    //            //Set the SkipItemCount
    //            SkipItemCount += SearchedItemList.Shipments.Count;

    //            foreach (Shipment s in SearchedItemList.Shipments)
    //            { TransportItems.Add(new ShipmentModelView(s)); }

    //            //Check for maximum List count and hide if reached
    //            if (TransportItems.Count > AppSettings.MaxListItemCount)
    //            {
    //                IsAvailable = false;
    //            }

    //            //Bindable Property
    //            ListLabel = "Search Result";
    //            IsBusy = false;
    //            IsLoaded = true;

    //            if (TransportItems.Count > 0)
    //            {
    //                ListHeight = TransportItems.Count * 85 * 0.8;
    //            }

    //            //Returning The Item to scroll to
    //            return await Task.FromResult(new ShipmentModelView(SearchedItemList.Shipments[0]));
    //        }
    //    }
    //}
    #endregion

}