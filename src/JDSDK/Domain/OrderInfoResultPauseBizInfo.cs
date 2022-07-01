using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderInfoResultPauseBizInfo:JdObject{
      [JsonProperty("pauseBizStatusList")]
public 				List<string>

             pauseBizStatusList
 { get; set; }
      [JsonProperty("pauseBizDataYy")]
public 				PauseBizDataYy

             pauseBizDataYy
 { get; set; }
	}
}
