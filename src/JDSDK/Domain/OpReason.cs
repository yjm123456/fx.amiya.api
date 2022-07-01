using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OpReason:JdObject{
      [JsonProperty("note")]
public 				string

             note
 { get; set; }
	}
}
