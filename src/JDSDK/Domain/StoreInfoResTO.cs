using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StoreInfoResTO:JdObject{
      [JsonProperty("exStoreId")]
public 				string

             exStoreId
 { get; set; }
      [JsonProperty("storeId")]
public 				long

             storeId
 { get; set; }
      [JsonProperty("storeName")]
public 				string

             storeName
 { get; set; }
      [JsonProperty("storePhone")]
public 				string

             storePhone
 { get; set; }
      [JsonProperty("storeMobile")]
public 				string

             storeMobile
 { get; set; }
      [JsonProperty("slogan")]
public 				string

             slogan
 { get; set; }
      [JsonProperty("businessBeginTime")]
public 				string

             businessBeginTime
 { get; set; }
      [JsonProperty("businessEndTime")]
public 				string

             businessEndTime
 { get; set; }
      [JsonProperty("storeBizType")]
public 				int

             storeBizType
 { get; set; }
      [JsonProperty("storeImage")]
public 				string

             storeImage
 { get; set; }
      [JsonProperty("firstAddress")]
public 				int

             firstAddress
 { get; set; }
      [JsonProperty("secondAddress")]
public 				int

             secondAddress
 { get; set; }
      [JsonProperty("thirdAddress")]
public 				int

             thirdAddress
 { get; set; }
      [JsonProperty("storeAddress")]
public 				string

             storeAddress
 { get; set; }
      [JsonProperty("storeStatus")]
public 				int

             storeStatus
 { get; set; }
      [JsonProperty("coordinate")]
public 				string

             coordinate
 { get; set; }
	}
}
