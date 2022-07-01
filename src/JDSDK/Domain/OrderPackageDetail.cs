using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderPackageDetail:JdObject{
      [JsonProperty("weight")]
public 				string

             weight
 { get; set; }
      [JsonProperty("delivery_no")]
public 				string

                                                                                     deliveryNo
 { get; set; }
      [JsonProperty("carriers_id")]
public 				string

                                                                                     carriersId
 { get; set; }
      [JsonProperty("carriers_name")]
public 				string

                                                                                     carriersName
 { get; set; }
	}
}
