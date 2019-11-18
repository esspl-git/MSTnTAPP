using MSTnTAPP.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSTnTAPP.Services
{
    public interface IMetroDataService
    {
        //Search Button Click
        Task<ShipmentListResponse> GetSearchResult(GetShipmentsRequest getShipmentsRequest);

        //Search Type
        IList<SearchCriterion> GetSearchTypeList();

        //Recent Search List
        Task<ShipmentListResponse> GetRecentSearchItems(GetShipmentsRequest getShipmentsRequest);

        //Get Item by ID
        Shipment GetShipmentByID(string s);
    }
}
