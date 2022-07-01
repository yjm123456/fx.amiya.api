using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopCrmGetMemberInVenderRequest : JdRequestBase<PopCrmGetMemberInVenderResponse>
    {
                                                                                                                   public  		string
              customerPin
 {get; set;}
                                                          
                                                          public  		string
                                                                                                                      openIdBuyer
 {get; set;}
                                                                                                                                                          
            public override string ApiName
            {
                get{return "jingdong.pop.crm.getMemberInVender";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("customerPin", this.            customerPin
);
                                                                                                        parameters.Add("open_id_buyer", this.                                                                                                                    openIdBuyer
);
                                                    }
    }
}





        
 

