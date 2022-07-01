using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ComJdRuleManageApiServiceNewWareServiceRequest : JdRequestBase<ComJdRuleManageApiServiceNewWareServiceResponse>
    {
                                                                                                                                                                                                                public  		Nullable<long>
              spuId
 {get; set;}
                                                          
                                                                                      public  		string
              categoryId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              brandId
 {get; set;}
                                                          
                                                          public  		string
              spuName
 {get; set;}
                                                          
                                                          public  		string
              itemNumber
 {get; set;}
                                                          
                                                          public  		string
              tagUrl
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.com.jd.rule.manage.api.service.NewWareService";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("spuId", this.            spuId
);
                                                                                                        parameters.Add("categoryId", this.            categoryId
);
                                                                                                        parameters.Add("brandId", this.            brandId
);
                                                                                                        parameters.Add("spuName", this.            spuName
);
                                                                                                        parameters.Add("itemNumber", this.            itemNumber
);
                                                                                                        parameters.Add("tagUrl", this.            tagUrl
);
                                                                            }
    }
}





        
 

