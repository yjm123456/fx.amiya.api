using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RequisitionInfoDetailDto:JdObject{
      [JsonProperty("ware_name")]
public 				string

                                                                                     wareName
 { get; set; }
      [JsonProperty("price")]
public 				string

             price
 { get; set; }
      [JsonProperty("warehouse_list")]
public 				List<string>

                                                                                     warehouseList
 { get; set; }
      [JsonProperty("reple_qty")]
public 				int

                                                                                     repleQty
 { get; set; }
	}
}
