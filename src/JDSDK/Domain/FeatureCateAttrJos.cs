using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class FeatureCateAttrJos:JdObject{
      [JsonProperty("attrFeatureCn")]
public 				string

             attrFeatureCn
 { get; set; }
      [JsonProperty("attrFeatureKey")]
public 				string

             attrFeatureKey
 { get; set; }
      [JsonProperty("attrFeatureValue")]
public 				string

             attrFeatureValue
 { get; set; }
	}
}
