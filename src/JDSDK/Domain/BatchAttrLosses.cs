using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BatchAttrLosses:JdObject{
      [JsonProperty("expiration_date_lot")]
public 				string

                                                                                                                     expirationDateLot
 { get; set; }
      [JsonProperty("production_date_lot")]
public 				string

                                                                                                                     productionDateLot
 { get; set; }
      [JsonProperty("isPo")]
public 				string

             isPo
 { get; set; }
      [JsonProperty("isSupplier")]
public 				string

             isSupplier
 { get; set; }
      [JsonProperty("isRcvDate")]
public 				string

             isRcvDate
 { get; set; }
      [JsonProperty("isPLU")]
public 				string

             isPLU
 { get; set; }
      [JsonProperty("isLogisticCompany")]
public 				string

             isLogisticCompany
 { get; set; }
      [JsonProperty("isOrigin")]
public 				string

             isOrigin
 { get; set; }
      [JsonProperty("isLot")]
public 				string

             isLot
 { get; set; }
      [JsonProperty("isManufacturer")]
public 				string

             isManufacturer
 { get; set; }
      [JsonProperty("isPackageBatch")]
public 				string

             isPackageBatch
 { get; set; }
      [JsonProperty("isBoxNo")]
public 				string

             isBoxNo
 { get; set; }
      [JsonProperty("isNosale")]
public 				string

             isNosale
 { get; set; }
      [JsonProperty("gysgL")]
public 				string

             gysgL
 { get; set; }
      [JsonProperty("isStore")]
public 				string

             isStore
 { get; set; }
	}
}
