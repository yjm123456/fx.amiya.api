using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RequisitionInfoResultDto:JdObject{
      [JsonProperty("requisition_info_detail")]
public 				RequisitionInfoDetailDto

                                                                                                                     requisitionInfoDetail
 { get; set; }
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
      [JsonProperty("result_code")]
public 				string

                                                                                     resultCode
 { get; set; }
      [JsonProperty("result_message")]
public 				string

                                                                                     resultMessage
 { get; set; }
	}
}
