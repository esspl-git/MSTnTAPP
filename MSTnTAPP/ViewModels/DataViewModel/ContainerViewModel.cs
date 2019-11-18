using MSTnTAPP.Models.Request;
using MSTnTAPP.Util.Enum.DataEnum;
using System.Collections.Generic;

namespace MSTnTAPP.ViewModels.DataViewModel
{
    public class ContainerViewModel:BaseViewModel
    {
        public ContainerViewModel(ShipmentBaseRequest requestObject)
        {

        }

        internal void GetContainerDetails() { }

        #region Old
        //private IList<List<Keyvalue>> containerLoadList { get; set; }

        //private IList<ContainerDetails> containerMainItems { get; set; }

        //public IList<ContainerDetails> ContainerMainItems
        //{
        //    get
        //    {
        //        return containerMainItems;
        //    }
        //    set
        //    {
        //        containerMainItems = value;
        //        OnPropertyChanged("ContainerMainItems");
        //    }
        //}

        //public IList<List<Keyvalue>> ContainerLoadList
        //{
        //    get
        //    {
        //        return containerLoadList;
        //    }
        //    set
        //    {
        //        containerLoadList = value;
        //        OnPropertyChanged("ContainerLoadList");
        //    }
        //}
        //public ContainerViewModel(ShipmentBaseRequest requestObject)
        //{
        //    ContainerMainItems = new List<ContainerDetails>()
        //    {
        //        new ContainerDetails(){
        //        ContainerName = "MRKU4772644",
        //        ContainerDate = "10th July 2019 09:03 AM",
        //        ContainerEnumList = new List<Keyvalue>()
        //        {
        //            new Keyvalue()
        //            {
        //                Key = Container.Type,
        //                Value = "40HC"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Gross_Kg,
        //                Value = "14060.00"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Cube,
        //                Value = "0.0000"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Cartons,
        //                Value = "195"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Seal_Number,
        //                Value = "42113"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Delivery_Reference,
        //                Value = "PERKINS 271"
        //            }
        //        }
        //        },

        //        new ContainerDetails(){
        //        ContainerName = "CMAU3109812",
        //        ContainerDate = "19th August 2019 08:03 AM",
        //        ContainerEnumList = new List<Keyvalue>()
        //        {
        //            new Keyvalue()
        //            {
        //                Key = Container.Type,
        //                Value = "883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Gross_Kg,
        //                Value = "883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Cube,
        //                Value = "25.0000"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Cartons,
        //                Value = "883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Seal_Number,
        //                Value = "883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Delivery_Reference,
        //                Value = "883527"
        //            }
        //        }
        //        },
        //        new ContainerDetails(){
        //        ContainerName = "MRKU4772644",
        //        ContainerDate = "10th July 2019 09:03 AM",
        //        ContainerEnumList = new List<Keyvalue>()
        //        {
        //            new Keyvalue()
        //            {
        //                Key = Container.Type,
        //                Value = "40HC"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Gross_Kg,
        //                Value = "14060.00"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Cube,
        //                Value = "0.0000"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Cartons,
        //                Value = "195"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Seal_Number,
        //                Value = "42113"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Delivery_Reference,
        //                Value = "PERKINS 271"
        //            }
        //        }
        //        },

        //        new ContainerDetails(){
        //        ContainerName = "CMAU3109812",
        //        ContainerDate = "19th August 2019 08:03 AM",
        //        ContainerEnumList = new List<Keyvalue>()
        //        {
        //            new Keyvalue()
        //            {
        //                Key = Container.Type,
        //                Value = "883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Gross_Kg,
        //                Value = "883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Cube,
        //                Value = "25.0000"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Cartons,
        //                Value = "883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Seal_Number,
        //                Value = "883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Delivery_Reference,
        //                Value = "883527"
        //            }
        //        }
        //        }

        //    };
        //}

        //internal void GetContainerDetails()
        //{
        //    ContainerLoadList = new List<List<Keyvalue>>() {
        //        new List<Keyvalue>(){
        //            new Keyvalue()
        //            {
        //                Key = Container.Order_Number,
        //                Value = "883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.SKU,
        //                Value = "E883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Cargo,
        //                Value = "AMC0754553"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.SKU_QTY,
        //                Value = "325"
        //            }
        //        },
        //        new List<Keyvalue>(){
        //            new Keyvalue()
        //            {
        //                Key = Container.Order_Number,
        //                Value = "883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.SKU,
        //                Value = "E883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Cargo,
        //                Value = "AMC0754553"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.SKU_QTY,
        //                Value = "325"
        //            }
        //        },
        //         new List<Keyvalue>(){
        //            new Keyvalue()
        //            {
        //                Key = Container.Order_Number,
        //                Value = "883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.SKU,
        //                Value = "E883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Cargo,
        //                Value = "AMC0754553"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.SKU_QTY,
        //                Value = "325"
        //            }
        //        },
        //        new List<Keyvalue>(){
        //            new Keyvalue()
        //            {
        //                Key = Container.Order_Number,
        //                Value = "883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.SKU,
        //                Value = "E883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Cargo,
        //                Value = "AMC0754553"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.SKU_QTY,
        //                Value = "325"
        //            }
        //        },
        //        new List<Keyvalue>(){
        //            new Keyvalue()
        //            {
        //                Key = Container.Order_Number,
        //                Value = "883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.SKU,
        //                Value = "E883527"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.Cargo,
        //                Value = "AMC0754553"
        //            },
        //            new Keyvalue()
        //            {
        //                Key = Container.SKU_QTY,
        //                Value = "325"
        //            }
        //        }
        //    };
        //}
        #endregion
    }
}
