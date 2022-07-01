using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class UserBaseInfoVo:JdObject{
      [JsonProperty("province")]
public 				int

             province
 { get; set; }
      [JsonProperty("city")]
public 				int

             city
 { get; set; }
      [JsonProperty("county")]
public 				int

             county
 { get; set; }
      [JsonProperty("nicknameShow")]
public 				string

             nicknameShow
 { get; set; }
      [JsonProperty("nickname")]
public 				string

             nickname
 { get; set; }
      [JsonProperty("gendar")]
public 				int

             gendar
 { get; set; }
      [JsonProperty("yunBigImageUrl")]
public 				string

             yunBigImageUrl
 { get; set; }
      [JsonProperty("yunMidImageUrl")]
public 				string

             yunMidImageUrl
 { get; set; }
      [JsonProperty("yunSmaImageUrl")]
public 				string

             yunSmaImageUrl
 { get; set; }
      [JsonProperty("countryCode")]
public 				string

             countryCode
 { get; set; }
      [JsonProperty("intactMobile")]
public 				string

             intactMobile
 { get; set; }
	}
}
