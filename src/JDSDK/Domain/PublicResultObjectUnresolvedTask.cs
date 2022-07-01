using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PublicResultObjectUnresolvedTask:JdObject{
      [JsonProperty("resultCode")]
public 				int

             resultCode
 { get; set; }
      [JsonProperty("unresolvedAfsService")]
public 				PageUnresolvedTask

             unresolvedAfsService
 { get; set; }
	}
}
