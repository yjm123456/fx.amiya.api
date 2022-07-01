using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WarehouseDetail:JdObject{
      [JsonProperty("warehouse_no")]
public 				string

                                                                                     warehouseNo
 { get; set; }
      [JsonProperty("warehouse_name")]
public 				string

                                                                                     warehouseName
 { get; set; }
      [JsonProperty("warehouse_address")]
public 				string

                                                                                     warehouseAddress
 { get; set; }
      [JsonProperty("warehouse_phone")]
public 				string

                                                                                     warehousePhone
 { get; set; }
	}
}
