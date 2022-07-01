using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopIllegalApiServiceVenderJingcreditApiServiceWriteBackPrivilegeRequest : JdRequestBase<PopIllegalApiServiceVenderJingcreditApiServiceWriteBackPrivilegeResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              gainInfoId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              privilegeType
 {get; set;}
                                                          
                                                          public  		string
              summaryYearMonth
 {get; set;}
                                                          
                                                          public  		string
              info
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.illegal.api.service.VenderJingcreditApiService.writeBackPrivilege";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("gainInfoId", this.            gainInfoId
);
                                                                                                        parameters.Add("privilegeType", this.            privilegeType
);
                                                                                                        parameters.Add("summaryYearMonth", this.            summaryYearMonth
);
                                                                                                        parameters.Add("info", this.            info
);
                                                                            }
    }
}





        
 

