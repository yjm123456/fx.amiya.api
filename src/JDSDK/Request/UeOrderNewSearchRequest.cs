using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderNewSearchRequest : JdRequestBase<UeOrderNewSearchResponse>
    {
                                                                                                                                              public  		string
              venderCode
 {get; set;}
                                                          
                                                          public  		string
              appid
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                                                           public  		string
              page
 {get; set;}
                                                          
                                                          public  		string
              serviceTypeId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ue.order.new.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                                                        parameters.Add("appid", this.            appid
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("serviceTypeId", this.            serviceTypeId
);
                                                                            }
    }
}





        
 

