using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class NbhouseRentBrokerstaffAddRequest : JdRequestBase<NbhouseRentBrokerstaffAddResponse>
    {
                                                                                                                                              public  		string
              brokerStaffName
 {get; set;}
                                                          
                                                          public  		string
              brokerStaffPhone
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              brokerStaffGender
 {get; set;}
                                                          
                                                          public  		string
              brokerStaffImg
 {get; set;}
                                                          
                                                          public  		string
              brokerStaffIdCardNum
 {get; set;}
                                                          
                                                          public  		string
              brokerStaffIdcardfront
 {get; set;}
                                                          
                                                          public  		string
              brokerStaffIdcardback
 {get; set;}
                                                          
                                                          public  		string
              brokerName
 {get; set;}
                                                          
                                                                                           public  		string
              extensionPhone
 {get; set;}
                                                          
                                                          public  		string
              businessLicense
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.nbhouse.rent.brokerstaff.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("brokerStaffName", this.            brokerStaffName
);
                                                                                                        parameters.Add("brokerStaffPhone", this.            brokerStaffPhone
);
                                                                                                        parameters.Add("brokerStaffGender", this.            brokerStaffGender
);
                                                                                                        parameters.Add("brokerStaffImg", this.            brokerStaffImg
);
                                                                                                        parameters.Add("brokerStaffIdCardNum", this.            brokerStaffIdCardNum
);
                                                                                                        parameters.Add("brokerStaffIdcardfront", this.            brokerStaffIdcardfront
);
                                                                                                        parameters.Add("brokerStaffIdcardback", this.            brokerStaffIdcardback
);
                                                                                                        parameters.Add("brokerName", this.            brokerName
);
                                                                                                                                                        parameters.Add("extensionPhone", this.            extensionPhone
);
                                                                                                        parameters.Add("businessLicense", this.            businessLicense
);
                                                                            }
    }
}





        
 

