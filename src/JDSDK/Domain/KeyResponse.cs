using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class KeyResponse:JdObject{
      [JsonProperty("status_code")]
public 				int

                                                                                     statusCode
 { get; set; }
      [JsonProperty("errorMsg")]
public 				string

             errorMsg
 { get; set; }
      [JsonProperty("tid")]
public 				string

             tid
 { get; set; }
      [JsonProperty("ts")]
public 				long

             ts
 { get; set; }
      [JsonProperty("enc_service")]
public 				string

                                                                                     encService
 { get; set; }
      [JsonProperty("key_cache_disabled")]
public 				int

                                                                                                                     keyCacheDisabled
 { get; set; }
      [JsonProperty("key_backup_disabled")]
public 				int

                                                                                                                     keyBackupDisabled
 { get; set; }
      [JsonProperty("service_key_list")]
public 				List<string>

                                                                                                                     serviceKeyList
 { get; set; }
	}
}
