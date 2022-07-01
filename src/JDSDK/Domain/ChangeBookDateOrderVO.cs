using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ChangeBookDateOrderVO:JdObject{
      [JsonProperty("orderNo")]
public 				string

             orderNo
 { get; set; }
      [JsonProperty("wishBookDate")]
public 				string

             wishBookDate
 { get; set; }
	}
}
