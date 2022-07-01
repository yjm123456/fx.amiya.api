using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class TransMainExtMain:JdObject{
      [JsonProperty("deptName")]
public 				string

             deptName
 { get; set; }
      [JsonProperty("orderType")]
public 				string

             orderType
 { get; set; }
      [JsonProperty("destWarehouseNo")]
public 				string

             destWarehouseNo
 { get; set; }
      [JsonProperty("sellerName")]
public 				string

             sellerName
 { get; set; }
      [JsonProperty("sellerNo")]
public 				string

             sellerNo
 { get; set; }
      [JsonProperty("orderStatus")]
public 				string

             orderStatus
 { get; set; }
      [JsonProperty("outWarehouseTime")]
public 				string

             outWarehouseTime
 { get; set; }
      [JsonProperty("startWarehouseNo")]
public 				string

             startWarehouseNo
 { get; set; }
      [JsonProperty("transNo")]
public 				string

             transNo
 { get; set; }
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("tranferNo")]
public 				string

             tranferNo
 { get; set; }
      [JsonProperty("startWarehouseName")]
public 				string

             startWarehouseName
 { get; set; }
      [JsonProperty("referTransNo")]
public 				string

             referTransNo
 { get; set; }
      [JsonProperty("destWarehouseName")]
public 				string

             destWarehouseName
 { get; set; }
      [JsonProperty("createTime")]
public 				string

             createTime
 { get; set; }
      [JsonProperty("restockTime")]
public 				string

             restockTime
 { get; set; }
      [JsonProperty("createUser")]
public 				string

             createUser
 { get; set; }
      [JsonProperty("itemList")]
public 				List<string>

             itemList
 { get; set; }
      [JsonProperty("operatingType")]
public 				string

             operatingType
 { get; set; }
	}
}
