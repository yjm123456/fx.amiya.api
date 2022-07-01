using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BigShotDTO:JdObject{
      [JsonProperty("waybillCode")]
public 				string

             waybillCode
 { get; set; }
      [JsonProperty("bigShotName")]
public 				string

             bigShotName
 { get; set; }
      [JsonProperty("bigShotCode")]
public 				string

             bigShotCode
 { get; set; }
      [JsonProperty("gatherCenterName")]
public 				string

             gatherCenterName
 { get; set; }
      [JsonProperty("gatherCenterCode")]
public 				string

             gatherCenterCode
 { get; set; }
      [JsonProperty("branchName")]
public 				string

             branchName
 { get; set; }
      [JsonProperty("branchCode")]
public 				string

             branchCode
 { get; set; }
      [JsonProperty("secondSectionCode")]
public 				string

             secondSectionCode
 { get; set; }
      [JsonProperty("thirdSectionCode")]
public 				string

             thirdSectionCode
 { get; set; }
      [JsonProperty("toTabletrolleyCode")]
public 				string

             toTabletrolleyCode
 { get; set; }
      [JsonProperty("fromTabletrolleyCode")]
public 				string

             fromTabletrolleyCode
 { get; set; }
      [JsonProperty("toCrossCode")]
public 				string

             toCrossCode
 { get; set; }
      [JsonProperty("fromCrossCode")]
public 				string

             fromCrossCode
 { get; set; }
      [JsonProperty("road")]
public 				string

             road
 { get; set; }
      [JsonProperty("orderSign")]
public 				string

             orderSign
 { get; set; }
      [JsonProperty("packageNo")]
public 				string

             packageNo
 { get; set; }
      [JsonProperty("fromBranchName")]
public 				string

             fromBranchName
 { get; set; }
      [JsonProperty("toBranchName")]
public 				string

             toBranchName
 { get; set; }
	}
}
