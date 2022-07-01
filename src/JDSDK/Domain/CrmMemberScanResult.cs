using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CrmMemberScanResult:JdObject{
      [JsonProperty("crm_members")]
public 				CrmMember[]

                                                                                     crmMembers
 { get; set; }
      [JsonProperty("total_result")]
public 				int

                                                                                     totalResult
 { get; set; }
      [JsonProperty("scroll_id")]
public 				string

                                                                                     scrollId
 { get; set; }
	}
}
