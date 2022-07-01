using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BillStatusVo:JdObject{
      [JsonProperty("bill_Type")]
public 				string

                                                                                     billType
 { get; set; }
      [JsonProperty("bill_sn")]
public 				string

                                                                                     billSn
 { get; set; }
      [JsonProperty("bill_status")]
public 				string

                                                                                     billStatus
 { get; set; }
	}
}
