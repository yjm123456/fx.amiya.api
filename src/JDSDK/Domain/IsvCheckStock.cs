using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class IsvCheckStock:JdObject{
      [JsonProperty("checkStockNo")]
public 				string

             checkStockNo
 { get; set; }
      [JsonProperty("warehouseId")]
public 				string

             warehouseId
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("createPin")]
public 				string

             createPin
 { get; set; }
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("details")]
public 				List<string>

             details
 { get; set; }
	}
}
