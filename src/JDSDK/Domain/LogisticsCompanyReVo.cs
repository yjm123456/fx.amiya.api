using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class LogisticsCompanyReVo:JdObject{
      [JsonProperty("id")]
public 				int

             id
 { get; set; }
      [JsonProperty("company_sn")]
public 				string

                                                                                     companySn
 { get; set; }
      [JsonProperty("company_name")]
public 				string

                                                                                     companyName
 { get; set; }
      [JsonProperty("contact_person")]
public 				string

                                                                                     contactPerson
 { get; set; }
      [JsonProperty("contact_phone")]
public 				string

                                                                                     contactPhone
 { get; set; }
	}
}
