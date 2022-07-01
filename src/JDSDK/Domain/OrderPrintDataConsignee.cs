using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderPrintDataConsignee:JdObject{
      [JsonProperty("cons_name")]
public 				string

                                                                                     consName
 { get; set; }
      [JsonProperty("cons_address")]
public 				string

                                                                                     consAddress
 { get; set; }
      [JsonProperty("cons_phone")]
public 				string

                                                                                     consPhone
 { get; set; }
      [JsonProperty("cons_handset")]
public 				string

                                                                                     consHandset
 { get; set; }
      [JsonProperty("desen_cons_phone")]
public 				string

                                                                                                                     desenConsPhone
 { get; set; }
      [JsonProperty("desen_cons_handset")]
public 				string

                                                                                                                     desenConsHandset
 { get; set; }
	}
}
