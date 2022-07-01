using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class FeatureCateAttrGroupJos:JdObject{
      [JsonProperty("attrGroupFeatureCn")]
public 				string

             attrGroupFeatureCn
 { get; set; }
      [JsonProperty("attrGroupFeatureKey")]
public 				string

             attrGroupFeatureKey
 { get; set; }
      [JsonProperty("attrGroupFeatureValue")]
public 				string

             attrGroupFeatureValue
 { get; set; }
	}
}
