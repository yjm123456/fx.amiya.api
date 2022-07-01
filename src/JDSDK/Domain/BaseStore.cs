using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BaseStore:JdObject{
      [JsonProperty("storeCode")]
public 				string

             storeCode
 { get; set; }
      [JsonProperty("storeName")]
public 				string

             storeName
 { get; set; }
	}
}
