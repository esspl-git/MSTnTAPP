using MSTnTAPP.Models.Request;

namespace MSTnTAPP.ViewModels.DataViewModel
{
    public class DocumentViewModel:BaseViewModel
    {
        public DocumentViewModel(ShipmentBaseRequest requestObject)
        {
        }

        #region Old
        //private IList<Document> documentItems { get; set; }

        //public IList<Document> DocumentItems
        //{
        //    get
        //    {
        //        return documentItems;
        //    }
        //    set
        //    {
        //        documentItems = value;
        //        OnPropertyChanged("DocumentItems");
        //    }
        //}


        //public DocumentViewModel(ShipmentBaseRequest requestObject)
        //{
        //    DocumentItems = new List<Document>()
        //    {
        //        new Document()
        //        {
        //            DocumentName = "Proof of delivery.pdf",
        //            DocumentSize = "215.01 MB",
        //            DocumentDate = "Aug 05, 2019 11.31 PM",
        //            URL = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf"
        //        },
        //        new Document()
        //        {
        //            DocumentName = "Import acceptance.pdf",
        //            DocumentSize = "144.03 KB",
        //            DocumentDate = "Nov 15, 2019 08.35 PM",
        //            URL = "http://www.africau.edu/images/default/sample.pdf"
        //        },
        //        new Document()
        //        {
        //            DocumentName = "Commercial connection.pdf",
        //            DocumentSize = "2.56 KB",
        //            DocumentDate = "Dec 13, 2020",
        //            URL = "https://www.ets.org/Media/Tests/GRE/pdf/gre_research_validity_data.pdf"
        //        }
        //    };
        //}
        #endregion
    }
}
