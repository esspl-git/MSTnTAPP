using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MSTnTAPP.Model.Models;
using MSTnTAPP.StaticDataModel;
using MSTnTAPP.Util;

namespace MSTnTAPP.Services
{
    public class MetroDataService : IMetroDataService
    {
        Shipment shipment;
        IList<Shipment> shipments;
        IList<Shipment> recent_shipments;

        public Task<ShipmentResponse> GetRecentSearchItems(GetShipmentsRequest getShipmentsRequest)
        {
            throw new NotImplementedException();
        }

        public Task<ShipmentResponse> GetSearchResult(GetShipmentsRequest getShipmentsRequest)
        {
            throw new NotImplementedException();
        }

        //public async Task<ShipmentListResponse> GetSearchResult(GetShipmentsRequest getShipmentsRequest)
        //{
        //    await Task.Delay(2000);
        //    getShipmentsRequest.TakeItemCount = AppSettings.ListItemCount + 1;
        //    if (getShipmentsRequest.SearchOn == "Reference Number")
        //    {
        //        shipments = ((List<Shipment>)ListDataModel.shipments).FindAll(
        //        delegate (Shipment sm)
        //        {
        //            return sm.JobReferenceNumber.ToLowerInvariant().Contains(getShipmentsRequest.SearchTerm.ToLowerInvariant());
        //        }
        //    );
        //        return await Task.FromResult(new ShipmentListResponse() {
        //            ReturnCode = "0",
        //            ReturnMessage = "Success",
        //            Shipments = shipments 
        //        });
        //    }
        //    // Container Reference
        //    //else if (type_Id == MSTnTApp.Util.Enum.SearchCriterion.CONTAINER_NUMBER.GetHashCode())
        //    //{
        //    //    return ((List<Shipment>)ListDataModel.shipments).FindAll(
        //    //    delegate (Shipment sm)
        //    //    {
        //    //        return sm.JobReferenceNumber == term;
        //    //    }
        //    //);
        //    //}
        //    else if (getShipmentsRequest.SearchOn == "Own Customer Reference Number")
        //    {
        //        shipments = ((List<Shipment>)ListDataModel.shipments).FindAll(
        //        delegate (Shipment sm)
        //        {
        //            return sm.ConsigneeName.ToLowerInvariant().Contains(getShipmentsRequest.SearchTerm.ToLowerInvariant());
        //        }
        //    );
        //        return await Task.FromResult(new ShipmentListResponse()
        //        {
        //            ReturnCode = "0",
        //            ReturnMessage = "Success",
        //            Shipments = shipments
        //        });
        //    }
        //    else
        //    {
        //        return await Task.FromResult(new ShipmentListResponse()
        //        {
        //            ReturnCode = "1",
        //            ReturnMessage = "API Token Invalid",
        //            Shipments = shipments
        //        });
        //    }
        //}
        public IList<SearchCriterion> GetSearchTypeList()
        {
            ObservableCollection<SearchCriterion> res = new ObservableCollection<SearchCriterion>()
                {
                    new SearchCriterion(MSTnTAPP.Util.Enum.SearchCriterion.METRO_REFERENCE_NUMBER.GetHashCode(), Constants.SEARCH_TYPE_METRO_REF_NUM),
                    new SearchCriterion(MSTnTAPP.Util.Enum.SearchCriterion.CONTAINER_NUMBER.GetHashCode(), Constants.SEARCH_TYPE_CONTAINER_NUM),
                    new SearchCriterion(MSTnTAPP.Util.Enum.SearchCriterion.OWN_CUSTOMER_REFERENCE_NUMBER.GetHashCode(), Constants.SEARCH_TYPE_CUSTOMER_REF_NUM)
                };
            return res;
        }
        //public async Task<ShipmentListResponse> GetRecentSearchItems(GetShipmentsRequest getShipmentsRequest)
        //{
        //    await Task.Delay(2000);
        //    getShipmentsRequest.TakeItemCount = AppSettings.ListItemCount;
        //    recent_shipments = RecentListDataModel.shipments;
        //    return await Task.FromResult(new ShipmentListResponse()
        //    {
        //        ReturnCode = "0",
        //        ReturnMessage = "Success",
        //        Shipments = recent_shipments
        //    });
        //}

        public Shipment GetShipmentByID(string s)
        {
            shipment = ((List<Shipment>)ListDataModel.shipments).Find(
                delegate (Shipment sm)
                {
                    return sm.JobReferenceNumber.ToLowerInvariant().Contains(s);
                });
            return shipment;
        }
    }
}