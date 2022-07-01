using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ErsFangUnShelveByExternalIdResponse:JdResponse{
      [JsonProperty("deletebyexternalid_result")]
public 				Result

                                                                                     deletebyexternalidResult
 { get; set; }
	}
}
