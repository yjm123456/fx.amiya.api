using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VenderAccountContent:JdObject{
      [JsonProperty("account_id")]
public 				long

                                                                                     accountId
 { get; set; }
      [JsonProperty("account_name")]
public 				string

                                                                                     accountName
 { get; set; }
      [JsonProperty("user_name")]
public 				string

                                                                                     userName
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("is_phone_open")]
public 				int

                                                                                                                     isPhoneOpen
 { get; set; }
      [JsonProperty("phone")]
public 				string

             phone
 { get; set; }
      [JsonProperty("auth_status")]
public 				int

                                                                                     authStatus
 { get; set; }
	}
}
