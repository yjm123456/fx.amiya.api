using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class CrmMemberScanResponse:JdResponse{
      [JsonProperty("crm_member_scan_result")]
public 				CrmMemberScanResult

                                                                                                                                                     crmMemberScanResult
 { get; set; }
	}
}
