using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopJosCenterGetPickupIntimeListRequest : JdRequestBase<LdopJosCenterGetPickupIntimeListResponse>
    {
                                                                                                                                              public  		string
              customerCode
 {get; set;}
                                                          
                                                          public  		string
              detailAddress
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.ldop.jos.center.getPickupIntimeList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("customerCode", this.            customerCode
);
                                                                                                        parameters.Add("detailAddress", this.            detailAddress
);
                                                                                                                            }
    }
}





        
 

