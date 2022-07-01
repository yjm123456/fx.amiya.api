using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
													namespace Jd.Api.Response
{

public class WareProductbigfieldGetResponse:JdResponse{
      [JsonProperty("shou_hou")]
public 				string

                                                                                     shouHou
 { get; set; }
      [JsonProperty("wdis")]
public 				string

             wdis
 { get; set; }
      [JsonProperty("prop_code")]
public 				string

                                                                                     propCode
 { get; set; }
      [JsonProperty("ware_qd")]
public 				string

                                                                                     wareQd
 { get; set; }
	}
}
