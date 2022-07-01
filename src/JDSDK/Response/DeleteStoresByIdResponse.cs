using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DeleteStoresByIdResponse:JdResponse{
      [JsonProperty("deletestoresbyid_result")]
public 				ResultBean

                                                                                     deletestoresbyidResult
 { get; set; }
	}
}
