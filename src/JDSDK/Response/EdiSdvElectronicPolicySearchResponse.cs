using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EdiSdvElectronicPolicySearchResponse:JdResponse{
      [JsonProperty("electronicPolicys")]
public 				List<string>

             electronicPolicys
 { get; set; }
	}
}
