using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class UpdateEntityStoreResponse:JdResponse{
      [JsonProperty("updateentitystore_result")]
public 				ResultBean

                                                                                     updateentitystoreResult
 { get; set; }
	}
}
