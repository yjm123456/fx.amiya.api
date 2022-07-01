using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ResultInfoDTO:JdObject{
      [JsonProperty("rcode")]
public 				int

             rcode
 { get; set; }
      [JsonProperty("rmessage")]
public 				string

             rmessage
 { get; set; }
      [JsonProperty("sourcetSortCenterId")]
public 				int

             sourcetSortCenterId
 { get; set; }
      [JsonProperty("sourcetSortCenterName")]
public 				string

             sourcetSortCenterName
 { get; set; }
      [JsonProperty("originalCrossCode")]
public 				string

             originalCrossCode
 { get; set; }
      [JsonProperty("originalTabletrolleyCode")]
public 				string

             originalTabletrolleyCode
 { get; set; }
      [JsonProperty("targetSortCenterId")]
public 				int

             targetSortCenterId
 { get; set; }
      [JsonProperty("targetSortCenterName")]
public 				string

             targetSortCenterName
 { get; set; }
      [JsonProperty("destinationCrossCode")]
public 				string

             destinationCrossCode
 { get; set; }
      [JsonProperty("destinationTabletrolleyCode")]
public 				string

             destinationTabletrolleyCode
 { get; set; }
      [JsonProperty("siteId")]
public 				int

             siteId
 { get; set; }
      [JsonProperty("siteName")]
public 				string

             siteName
 { get; set; }
      [JsonProperty("road")]
public 				string

             road
 { get; set; }
      [JsonProperty("aging")]
public 				int

             aging
 { get; set; }
      [JsonProperty("agingName")]
public 				string

             agingName
 { get; set; }
      [JsonProperty("isHideName")]
public 				int

             isHideName
 { get; set; }
      [JsonProperty("isHideContractNumbers")]
public 				int

             isHideContractNumbers
 { get; set; }
      [JsonProperty("preSortCode")]
public 				int

             preSortCode
 { get; set; }
      [JsonProperty("transType")]
public 				int

             transType
 { get; set; }
      [JsonProperty("promiseTimeType")]
public 				int

             promiseTimeType
 { get; set; }
      [JsonProperty("promiseTimeTypeDownGrade")]
public 				bool

             promiseTimeTypeDownGrade
 { get; set; }
      [JsonProperty("orderId")]
public 				string

             orderId
 { get; set; }
      [JsonProperty("expressOperationMode")]
public 				int

             expressOperationMode
 { get; set; }
	}
}
