using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VcWareHouseOutJosDto:JdObject{
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
      [JsonProperty("stockOutStatus")]
public 				int

             stockOutStatus
 { get; set; }
      [JsonProperty("stockOutStatusName")]
public 				string

             stockOutStatusName
 { get; set; }
      [JsonProperty("stockOutType")]
public 				string

             stockOutType
 { get; set; }
      [JsonProperty("stockOutTypeName")]
public 				string

             stockOutTypeName
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("checkTime")]
public 				DateTime

             checkTime
 { get; set; }
      [JsonProperty("remark1")]
public 				string

             remark1
 { get; set; }
      [JsonProperty("remark2")]
public 				string

             remark2
 { get; set; }
      [JsonProperty("remark3")]
public 				string

             remark3
 { get; set; }
      [JsonProperty("remark4")]
public 				string

             remark4
 { get; set; }
      [JsonProperty("remark5")]
public 				string

             remark5
 { get; set; }
	}
}
