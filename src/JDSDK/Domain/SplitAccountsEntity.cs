using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SplitAccountsEntity:JdObject{
      [JsonProperty("splitId")]
public 				long

             splitId
 { get; set; }
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("accountName")]
public 				string

             accountName
 { get; set; }
      [JsonProperty("walletName")]
public 				string

             walletName
 { get; set; }
      [JsonProperty("relStoreIds")]
public 				string

             relStoreIds
 { get; set; }
	}
}
