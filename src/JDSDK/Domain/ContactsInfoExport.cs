using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ContactsInfoExport:JdObject{
      [JsonProperty("addressInfoExport")]
public 				AddressInfoExport

             addressInfoExport
 { get; set; }
      [JsonProperty("contactsName")]
public 				string

             contactsName
 { get; set; }
      [JsonProperty("contactsTel")]
public 				string

             contactsTel
 { get; set; }
      [JsonProperty("contactsPhone")]
public 				string

             contactsPhone
 { get; set; }
      [JsonProperty("contactsZipCode")]
public 				string

             contactsZipCode
 { get; set; }
	}
}
