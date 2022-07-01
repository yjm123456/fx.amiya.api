using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
							namespace Jd.Api.Response
{

public class VasSubscribeGetByCodeResponse:JdResponse{
      [JsonProperty("item_code")]
public 				string

                                                                                     itemCode
 { get; set; }
      [JsonProperty("end_date")]
public 				string

                                                                                     endDate
 { get; set; }
	}
}
