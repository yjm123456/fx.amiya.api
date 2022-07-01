using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CouponDetailExternal:JdObject{
      [JsonProperty("rtnCode")]
public 				int

             rtnCode
 { get; set; }
      [JsonProperty("couponDetailVo")]
public 				CouponDetailVo

             couponDetailVo
 { get; set; }
	}
}
