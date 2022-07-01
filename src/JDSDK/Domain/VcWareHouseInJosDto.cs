using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VcWareHouseInJosDto:JdObject{
      [JsonProperty("vendorCode")]
public 				string

             vendorCode
 { get; set; }
      [JsonProperty("docNo")]
public 				string

             docNo
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
      [JsonProperty("stockInType")]
public 				string

             stockInType
 { get; set; }
      [JsonProperty("stockInTypeName")]
public 				string

             stockInTypeName
 { get; set; }
      [JsonProperty("stockOutStatusName")]
public 				string

             stockOutStatusName
 { get; set; }
      [JsonProperty("docStatus")]
public 				string

             docStatus
 { get; set; }
      [JsonProperty("docStatusName")]
public 				string

             docStatusName
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("pickwareId")]
public 				string

             pickwareId
 { get; set; }
      [JsonProperty("unpackingTime")]
public 				DateTime

             unpackingTime
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
