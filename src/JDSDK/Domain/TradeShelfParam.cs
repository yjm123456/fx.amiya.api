using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class TradeShelfParam:JdObject{
      [JsonProperty("shelf_status")]
public 				string

                                                                                     shelfStatus
 { get; set; }
      [JsonProperty("wsale_price")]
public 					string

                                                                                     wsalePrice
 { get; set; }
      [JsonProperty("wsale_start_num")]
public 				int

                                                                                                                     wsaleStartNum
 { get; set; }
	}
}
