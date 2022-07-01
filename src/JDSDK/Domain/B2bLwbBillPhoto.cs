using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class B2bLwbBillPhoto:JdObject{
      [JsonProperty("attachmentUrl")]
public 				string

             attachmentUrl
 { get; set; }
      [JsonProperty("attachmentName")]
public 				string

             attachmentName
 { get; set; }
	}
}
