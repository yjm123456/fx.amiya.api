using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class CrmMemberSearchResponse:JdResponse{
      [JsonProperty("crm_member_result")]
public 				CrmMemberResult

                                                                                                                     crmMemberResult
 { get; set; }
	}
}
