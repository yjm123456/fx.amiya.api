using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class CreateSplitAccountsEntityResponse:JdResponse{
      [JsonProperty("createSplitAccountsEntity_result")]
public 				ResponseMessageTO

                                                                                     createSplitAccountsEntityResult
 { get; set; }
	}
}
