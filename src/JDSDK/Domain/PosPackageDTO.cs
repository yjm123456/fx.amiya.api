using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PosPackageDTO:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("posPackageId")]
public 				long

             posPackageId
 { get; set; }
      [JsonProperty("campaignId")]
public 				long

             campaignId
 { get; set; }
      [JsonProperty("adGroupId")]
public 				long

             adGroupId
 { get; set; }
      [JsonProperty("campaignType")]
public 				int

             campaignType
 { get; set; }
      [JsonProperty("businessType")]
public 				int

             businessType
 { get; set; }
	}
}
