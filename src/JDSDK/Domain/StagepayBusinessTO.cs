using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StagepayBusinessTO:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("businessNo")]
public 				long

             businessNo
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("stageNum")]
public 				int

             stageNum
 { get; set; }
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("storeId")]
public 				long

             storeId
 { get; set; }
      [JsonProperty("payStatus")]
public 				int

             payStatus
 { get; set; }
	}
}
