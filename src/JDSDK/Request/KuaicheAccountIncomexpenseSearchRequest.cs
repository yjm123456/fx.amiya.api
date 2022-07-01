using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class KuaicheAccountIncomexpenseSearchRequest : JdRequestBase<KuaicheAccountIncomexpenseSearchResponse>
    {
                                                                                                                   public  		Nullable<long>
                                                                                                                      inOutType
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<long>
              type
 {get; set;}
                                                          
                                                          public  		Nullable<long>
                                                                                      checkType
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      pageIndex
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.kuaiche.account.incomexpense.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("in_out_type", this.                                                                                                                    inOutType
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("check_type", this.                                                                                    checkType
);
                                                                                                        parameters.Add("page_index", this.                                                                                    pageIndex
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                    }
    }
}





        
 

