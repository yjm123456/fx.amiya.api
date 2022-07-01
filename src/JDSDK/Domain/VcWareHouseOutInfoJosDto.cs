using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VcWareHouseOutInfoJosDto:JdObject{
      [JsonProperty("vendorCode")]
public 				string

             vendorCode
 { get; set; }
      [JsonProperty("stockOutNo")]
public 				string

             stockOutNo
 { get; set; }
      [JsonProperty("companyCode")]
public 				string

             companyCode
 { get; set; }
      [JsonProperty("distribCenterCode")]
public 				string

             distribCenterCode
 { get; set; }
      [JsonProperty("warehouseCode")]
public 				string

             warehouseCode
 { get; set; }
      [JsonProperty("companyName")]
public 				string

             companyName
 { get; set; }
      [JsonProperty("distribCenterName")]
public 				string

             distribCenterName
 { get; set; }
      [JsonProperty("warehouseName")]
public 				string

             warehouseName
 { get; set; }
      [JsonProperty("stockOutStatus")]
public 				int

             stockOutStatus
 { get; set; }
      [JsonProperty("stockOutStatusName")]
public 				string

             stockOutStatusName
 { get; set; }
      [JsonProperty("returnPrice")]
public 					string

             returnPrice
 { get; set; }
      [JsonProperty("returnNum")]
public 				int

             returnNum
 { get; set; }
      [JsonProperty("erpCode")]
public 				string

             erpCode
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("settlementCode")]
public 				string

             settlementCode
 { get; set; }
      [JsonProperty("returnCode")]
public 				string

             returnCode
 { get; set; }
      [JsonProperty("remarkForOutBound")]
public 				string

             remarkForOutBound
 { get; set; }
      [JsonProperty("vcWareHouseOutSpareCodeJosDtoList")]
public 				List<string>

             vcWareHouseOutSpareCodeJosDtoList
 { get; set; }
	}
}
