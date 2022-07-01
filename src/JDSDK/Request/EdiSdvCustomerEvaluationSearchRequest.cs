using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiSdvCustomerEvaluationSearchRequest : JdRequestBase<EdiSdvCustomerEvaluationSearchResponse>
    {
                                                                                                                                              public  		string
              sku
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              score
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              sortType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              pin
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.edi.sdv.customer.evaluation.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("sku", this.            sku
);
                                                                                                        parameters.Add("score", this.            score
);
                                                                                                        parameters.Add("sortType", this.            sortType
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("pin", this.            pin
);
                                                                            }
    }
}





        
 

