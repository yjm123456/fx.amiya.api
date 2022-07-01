using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class GetVoucherInfoResVo:JdObject{
      [JsonProperty("voucher")]
public 				string

             voucher
 { get; set; }
	}
}
