using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderPrintDataWare:JdObject{
      [JsonProperty("ware_id")]
public 				string

                                                                                     wareId
 { get; set; }
      [JsonProperty("ware_name")]
public 				string

                                                                                     wareName
 { get; set; }
      [JsonProperty("num")]
public 				string

             num
 { get; set; }
      [JsonProperty("jd_price")]
public 				string

                                                                                     jdPrice
 { get; set; }
      [JsonProperty("price")]
public 				string

             price
 { get; set; }
      [JsonProperty("produce_no")]
public 				string

                                                                                     produceNo
 { get; set; }
	}
}
