using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PreSortResult:JdObject{
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
      [JsonProperty("slideNo")]
public 				string

             slideNo
 { get; set; }
      [JsonProperty("sourceSortCenterId")]
public 				int

             sourceSortCenterId
 { get; set; }
      [JsonProperty("sourceSortCenterName")]
public 				string

             sourceSortCenterName
 { get; set; }
      [JsonProperty("sourceCrossCode")]
public 				string

             sourceCrossCode
 { get; set; }
      [JsonProperty("sourceTabletrolleyCode")]
public 				string

             sourceTabletrolleyCode
 { get; set; }
      [JsonProperty("targetSortCenterId")]
public 				int

             targetSortCenterId
 { get; set; }
      [JsonProperty("targetSortCenterName")]
public 				string

             targetSortCenterName
 { get; set; }
      [JsonProperty("targetTabletrolleyCode")]
public 				string

             targetTabletrolleyCode
 { get; set; }
      [JsonProperty("aging")]
public 				int

             aging
 { get; set; }
      [JsonProperty("agingName")]
public 				string

             agingName
 { get; set; }
      [JsonProperty("siteType")]
public 				int

             siteType
 { get; set; }
      [JsonProperty("isHideName")]
public 				int

             isHideName
 { get; set; }
      [JsonProperty("isHideContractNumbers")]
public 				int

             isHideContractNumbers
 { get; set; }
      [JsonProperty("collectionAddress")]
public 				string

             collectionAddress
 { get; set; }
      [JsonProperty("distributeCode")]
public 				string

             distributeCode
 { get; set; }
      [JsonProperty("coverCode")]
public 				string

             coverCode
 { get; set; }
      [JsonProperty("qrcodeUrl")]
public 				string

             qrcodeUrl
 { get; set; }
	}
}
