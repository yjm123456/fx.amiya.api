using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EptWarecenterWareGetResponse:JdResponse{
      [JsonProperty("getwareinfobyid_result")]
public 				WareApiVO

                                                                                     getwareinfobyidResult
 { get; set; }
	}
}
