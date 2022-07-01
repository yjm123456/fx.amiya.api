using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VendorStoreInfo:JdObject{
      [JsonProperty("vendorStoreId")]
public 				int

             vendorStoreId
 { get; set; }
      [JsonProperty("vendorStoreName")]
public 				string

             vendorStoreName
 { get; set; }
	}
}
