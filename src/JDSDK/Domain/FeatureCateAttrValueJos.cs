using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class FeatureCateAttrValueJos:JdObject{
      [JsonProperty("featureCn")]
public 				string

             featureCn
 { get; set; }
      [JsonProperty("featureKey")]
public 				string

             featureKey
 { get; set; }
      [JsonProperty("featureValue")]
public 				string

             featureValue
 { get; set; }
	}
}
