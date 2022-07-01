using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VenderRemarkQueryResult:JdObject{
      [JsonProperty("api_jos_result")]
public 				ApiJosResult

                                                                                                                     apiJosResult
 { get; set; }
      [JsonProperty("vender_remark")]
public 				VenderRemark

                                                                                     venderRemark
 { get; set; }
	}
}
